using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using Core;

namespace UI
{    
    public partial class FormInterpret : Form,Core.IInterpret
    {
        class MarkRowInfo
        {
            /// <summary>
            /// Tệp nguồn chứa bài làm của học sinh
            /// </summary>
            public string FileName;
            /// <summary>
            /// Chỉ mục trong toàn bộ lần chấm điểm (biến Result)
            /// </summary>
            public int GridIndex;
            /// <summary>
            /// Chỉ mục trong biến Result;
            /// </summary>
            public int ResultIndex;
            public Spot root;
        }
        /// <summary>
        /// Kết quả của toàn bộ quá trình chấm điểm
        /// </summary>
        public Core.Discovers Result;
        bool _isRecognized = false;
        int _previousGridHeight = 0;
        /// <summary>
        /// Số bài bị lỗi.
        /// </summary>
        int _numberBlurSources;
        public FormInterpret()
        {
            InitializeComponent();
            this.Tag = new Hashtable();
            this.Result = new Core.Discovers();
            gridMark.AutoScrollOffset = new Point(0, gridMark.RowTemplate.Height);                        
        }

        private void FormInterpret_Load(object sender, EventArgs e)
        {
            // Chú ý: khi instanate form này phải khởi tạo tag của nó các giá trị cần thiết
            // Thêm vào menu Window cửa sổ này
            Hashtable tag = (Hashtable)this.Tag;
            // Thay đổi tiêu đề
            this.Text = (string)tag[TagKeys.Caption];
            #region Xác định bộ đáp án (key suite)
            //if (Core.Ref.UniSuite.ActiveSuiteIndex != -1)
            //{
            //    if (Core.Utility.Confirm(string.Format("Bạn sẽ dùng bộ đáp án: {0}{1}", Environment.NewLine,
            //         Core.Ref.UniSuite.ActiveSuite.ToString())) == DialogResult.Yes)
            //    {
            //        toolBtnRecognize.PerformClick();
            //        return;
            //    }
            //}
            //if (!FormUnisuite.HasInstanced)
            //{
            //    FormUnisuite fus = new FormUnisuite();
            //    this.Left = -this.Width;
            //    this.Enabled = false;
            //    fus.Top = this.Top;
            //    fus.Left = this.Left + this.Width;
            //    fus.StartPosition = FormStartPosition.Manual;
            //    fus.FormClosing += new FormClosingEventHandler(fus_FormClosing);
            //    fus.MdiParent = this.MdiParent;
            //    fus.Show();
            //    fus.Focus();
            //}
            #endregion
        }

        void fus_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Enabled = true;
            this.Left = 0;
            this.Focus();
        }

        public void CoreMsg_Handler(object sender, Core.CoreMsgEventArgs e)
        {
            //if (((Core.CoreMsgCapable)sender).IsForFormInterpret)
                txtLog.Text += Environment.NewLine + e.Message;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {            
            
        }     
        /// <summary>
        /// Chuyển kết quả interpret ra grid.
        /// </summary>
        /// <param name="discover"></param>
        /// <param name="index">Grid index</param>
        /// <param name="fileName"></param>
        private void gridMark_Populate(Core.Discover discover, int index, string fileName)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(gridMark, 
                new object[] { 
                    discover.group, 
                    discover.student, 
                    discover.problem, 
                    discover.mark, 
                    Core.Utility.ClearLook(discover.answer)});
            MarkRowInfo info = new MarkRowInfo();
            row.Tag = info;
            info.FileName = fileName;
            info.GridIndex = index;
            info.root = discover.root;
            // Thêm
            info.ResultIndex = gridMark.Rows.Add(row);
            if ((float)row.Cells[3].Value == -1)
            {
                // điểm là -1, cần xem xét vì đâylà một ngoại lệ.
                row.DefaultCellStyle.BackColor = Color.Tomato;
                row.DefaultCellStyle.ForeColor = Color.White;
                _numberBlurSources++;
            }            
        }
        private string[] _files;
        private Core.KeySuite _keys;
        private Core.Automate _automate;
        private void toolBtnRecognize_Click(object sender, EventArgs e)
        {
            if (_isRecognized) return;            
            if (Core.Ref.UniSuite.ActiveSuiteIndex == -1)
            {
                Core.Utility.Msg("Chưa có bộ đáp án nào được chọn");
                return;
            }
            _keys = Core.Ref.UniSuite.ActiveSuite;            
            // Tạm dừng hoạt động, tránh người sử dụng bấm lung tung -> hỏng việc
            // : )
            
            toolBtnRecognize.Enabled = false;
            #region Xác định nguồn dữ liệu quuét
            Hashtable tag = (Hashtable)this.Tag;
            _automate = new Core.Automate();
            _automate.CoreMsg += new Core.CoreMsgEventHandler(CoreMsg_Handler);
            switch ((Core.Automate.Source)tag[TagKeys.AutomateSource])
            {

                case Core.Automate.Source.Files:
                    _files = (string[])tag[TagKeys.Files];
                    break;
                case Core.Automate.Source.Folder:
                    _automate.Folder((string)tag[TagKeys.Path]);
                    _files = _automate.FileList;
                    break;
            }
            if (_files == null)
            {
                _automate.Inform(_automate, "Không có tệp nào.");
                return;
            }
            UseWaitCursor = true;
            #endregion            
            #region Kiểu cũ: dựa vào dropDown
            //if (tag[TagKeys.KeySuite] != null && Core.Ref.UniSuite[(int)tag[TagKeys.KeySuite]] != null)
            //    // Lấy thẳng từ tag của form trỏ đến Unisuite
            //    _keys = Core.Ref.UniSuite[(int)tag[TagKeys.KeySuite]] as Core.KeySuite;
            //else
            //{
            //    // Tìm nguồn suite thay thế
            //    DialogResult doAction = MessageBox.Show(string.Format(
            //        "Chưa có bộ đáp án nào được chuyển đến để chấm điểm.{0}" +
            //        "\tChọn Yes nếu muốn *tạo mới* một bộ đáp án.{0}" +
            //        "\tChọn No nếu muốn *mở hay nạp* một bộ đáp án có sẵn.{0}" +
            //        "\tChọn Cancel để nhận dạng bài làm thuần tuý Trong lúc đó bạn sẽ nhập bộ đáp án {0}" +
            //        "\tvà việc lên điểm diễn ra sau cùng.", Environment.NewLine),
            //        UI.Properties.Settings.Default.WindowCaption, MessageBoxButtons.YesNoCancel,
            //        MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            //    switch (doAction)
            //    {
            //        case DialogResult.Yes:
            //            #region Tạo mới một bộ đáp án và chuyển luôn vào của sổ hiện tại
                        
            //                FormNewsuite fns = new FormNewsuite();
            //                fns.MdiParent = this.MdiParent;
            //                this.Enabled = false;
            //                fns.Show();
            //                fns.FormClosing += new FormClosingEventHandler(fns_FormClosing);
            //                return;
                        
                        
            //            #endregion
            //        case DialogResult.No:
            //            #region Mở một bộ đáp án có sẵn

            //            ToolStripMenuItem mnuFile = (this.ParentForm.MainMenuStrip.Items["mnuFile"]) as ToolStripMenuItem;
            //            ToolStripMenuItem mnuFileOpen = mnuFile.DropDownItems["mnuFileOpen"] as ToolStripMenuItem;
            //            if (mnuFileOpen == null)
            //            {
            //                Core.Utility.Error("Develop: Không tìm thấy chức năng Open trong menu File");
            //                return;
            //            }
            //            mnuFileOpen.PerformClick();
            //            if (mnuFileOpen.Tag == null)
            //            {
            //                Core.Utility.Msg("Quá trình chấm điểm dừng do không có tệp nào *được chọn*.");
            //            }
            //            else
            //            {
            //                _keys = Core.Ref.UniSuite[(int)mnuFileOpen.Tag] as Core.KeySuite;
            //            }
            //            break;
            //            #endregion
            //        case DialogResult.Cancel:
            //            #region Quét ngầm, tạo mới đáp án, lên điểm sau cùng.
            //            return;

            #endregion            
            #region Chấm
            gridMark.Hide();
            _numberBlurSources=0;
            UseWaitCursor = true;
            Cursor = Cursors.WaitCursor;
            int ri;// result index in Discovers
            for (int i = 0; i < _files.Length; i++)
            {
                txtLog.AppendText(string.Format("{1}#{0}{1}", i, Environment.NewLine));
                Core.Discover result = _automate.OneFile(_files[i], ref _keys);			
                #region Chuyển kết quả vào grid và cập nhật trạng thái
                if (result != null)
                {
                    result.date = DateTime.Now;
                    ri = this.Result.AddItem(result);
                    gridMark_Populate(result, ri, _files[i]);                    
                }
                progressBar.Value = (int)((i + 1) * 100.0f / _files.Length);
                #endregion
            }
            #endregion 
            UseWaitCursor = false;
            Cursor = Cursors.Default;
            System.Media.SystemSounds.Beep.Play();
            if (_numberBlurSources != 0)
            {
                Core.Utility.Error(string.Format("Có   {0}*   bài không nhận dạng được do:{1}" +                    
                    "1. Giấy bị mờ chặc bẩn (đặc biệt ở bốn góc) {1}" +
                    "2. Khi quét nghiêng quá mức, quăn mép; dữ liệu không đúng chuẩn. {1}" +
                    "3. Học sinh tô không đủ đậm, cần nhắc nhở. {1}" +
                    "4. Mã đề trong đáp án không đúng với mã đề trong bài làm.{1}{1}" +
                    "Những bài chắc chắn có lỗi được tô đỏ, hãy dùng nút 'Bài gốc' để xem lại{1}" +
                    "và hiệu chỉnh cho đúng. Nhấn vào tiêu đề cột điểm sẽ liệt kê chúng.",
                    _numberBlurSources,
                    Environment.NewLine));
            }
            toolBtnRecognize.Enabled = true;
            toolBtnRecognize.Text = "Chấm lại";
            _isRecognized = true;
            toolBtnRecognize.Click += new EventHandler(toolBtnRecaculate_Click);
            gridMark.Show();
        }
        void toolBtnRecaculate_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridMark.Rows.Count;i++ )
            {
                if (gridMark.Rows[i].Cells[colMark.Index].Value == null) continue;
                if (gridMark.Rows[i].Cells[colMark.Index].Value.ToString() == "-1")
                {
                    gridMark.FirstDisplayedCell = gridMark.Rows[i].Cells[0];
                    gridMark.ClearSelection();
                    gridMark.Rows[i].Selected = true;
                    toolOrgin.PerformClick();
                    return;
                }
            }
        }

        void fns_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FormNewsuite.NewSuiteIndex == -1)
            {
                Core.Utility.Msg("Quá trình chấm điểm dừng do không có tệp nào được *tạo mới.*");
                ((Form)sender).MdiParent.Close();
                return;
            }
            else
            {
                ((Hashtable)this.Tag)[TagKeys.KeySuite] = FormNewsuite.NewSuiteIndex;
                this.Enabled = true;
                toolBtnRecognize.Enabled = true;
                toolBtnRecognize.PerformClick();
            }
        }

        private void toolOrgin_Click(object sender, EventArgs e)
        {            
            if (gridMark.SelectedRows.Count != 0)
            {
                toolOrgin.Visible = false;
                // Giảm chiều cao để đưa dòng được chọn về đỉnh
                if (_previousGridHeight == 0)
                    _previousGridHeight = gridMark.Height;
                gridMark.Height = 3 * gridMark.ColumnHeadersHeight;
                DataGridViewRow row = gridMark.SelectedRows[0];
                if (row.Index == -1) return;
                if ((MarkRowInfo)row.Tag == null) return;
                gridMark.FirstDisplayedCell = row.Cells[0];
                
                string fileName = ((MarkRowInfo)row.Tag).FileName;

                toolCloseOrgin.Visible = true;
                panel.Visible = true;                
                toolScale.Visible = true;

                if (File.Exists(fileName))
                {
                    picture.Image = Bitmap.FromFile(fileName);
                    lblSourceFile.Text = fileName;
                    txtLog.Visible = false;
                    picture_Scale(this.scale);
                }
            }
            else Core.Utility.Msg("Chọn một dòng kết quả để xem dữ liệu gốc của dòng đó.");
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }

        private void toolBtnSave_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(UI.Properties.Settings.Default.InterpretLogFile,
                true, // append
                Encoding.UTF8);
            sw.Write(txtLog.Text);
            sw.Flush();
            sw.Close();
            toolBtnSave.Enabled = false;
        }       

        void visualizer_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                FormKeyVisualize visualizer = (FormKeyVisualize)sender;
                DataGridViewRow row = gridMark.Rows[visualizer.rowIndex];
                //row.Frozen = false;
                // Bỏ chọn cũ
                gridMark.ClearSelection();
                // Chọn riêng ô Detail
                row.Cells[colDetail.Index].Selected = true;
                gridMark.BeginEdit(false);
                row.Cells[colDetail.Index].Selected = false;
                row.Cells[colDetail.Index].Value = visualizer.returnAns;
                gridMark.EndEdit();
                gridMark.InvalidateCell(row.Cells[colDetail.Index]);
                
                // Tính lại kết quả.
                //gridMark_CellValueChanged(
                //    visualizer,
                //    new DataGridViewCellEventArgs(colDetail.Index, gridMark.SelectedRows[0].Index));
                // Chọn lại dòng
                
                gridMark.ClearSelection();

                // Cách để nó "refresh" cho mình sau khi Visualize
                gridMark.FirstDisplayedCell = row.Cells[0];
                row.Cells[colMark.Index].Selected = true;
                gridMark.BeginEdit(false);
                gridMark.EndEdit();
                row.Selected = true;
                
            }
            catch (Exception ex)
            {
                Core.Utility.Msg("Bạn thao tác chưa đúng. Xin vui lòng xin lại chỉ dẫn" + ex.Message);
                return;
            }
        }
        int scale = 65;
        private void toolScale_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            toolScale.DropDown.Close();
            scale = int.Parse((string)e.ClickedItem.Tag);
            picture_Scale(this.scale);
        }
        private void picture_Scale(int scale)
        {
            picture.Size = new Size(picture.Image.Width * scale / 100, picture.Image.Height * scale / 100);
            picture.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void gridMark_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!picture.Visible)
                toolOrgin.PerformClick();
            if (e.ColumnIndex == colDetail.Index)
                toolVisual.PerformClick();
        }

        void interpret_CoreMsg(object sender, Core.CoreMsgEventArgs e)
        {
            // Không được xoá để interpret trống hoạt động
        }

        private void gridMark_CellValueChanged(object sender, DataGridViewCellEventArgs e)        
        {
            if (e.RowIndex == -1) return;
            DataGridViewRow row = gridMark.Rows[e.RowIndex];
            if (!row.IsNewRow && gridMark[e.ColumnIndex,e.RowIndex].IsInEditMode)
            {
                try
                {
                    int resultIndex = ((MarkRowInfo)gridMark.Rows[e.RowIndex].Tag).ResultIndex;
                    Core.Interpret interpret = new Core.Interpret();
                    interpret.CoreMsg += new Core.CoreMsgEventHandler(interpret_CoreMsg);
                    interpret.keys = _keys;
                    interpret.Result.answer = Core.Utility.Clarify((string)
                        gridMark[colDetail.Index, e.RowIndex].Value);
                    interpret.Result.problem = int.Parse(row.Cells[colProblem.Index].Value.ToString());
                    interpret.Result.group = int.Parse(row.Cells[colGroup.Index].Value.ToString());
                    interpret.Result.student = int.Parse(row.Cells[colStudentID.Index].Value.ToString());
                    interpret.FindMark();
                    interpret.Result.file = Result[resultIndex].file;
                    interpret.Result.root = Result[resultIndex].root;
                    row.Cells[colMark.Index].Value = interpret.Result.mark;

                    // Cập nhật dữ liệu mới.
                    Result[resultIndex] = interpret.Result;
                }
                catch (FormatException ex)
                {
                    Core.Utility.Msg("Dữ liệu không đúng. Xin cẩn thận." + ex.Message);
                    return;
                }
                catch (Exception ex2)
                {
                    Core.Utility.Msg("Lỗi nghiêm trọng. Xin vui lòng xem lại hướng dẫn trước khi thực hiện sửa chữa trực tiếp."
                        + ex2.Message);
                    return;
                }
            }
            else
            {
                // cập nhật dữ liệu các cột khác với Result
            }
        }

        private void toolVisual_Click(object sender, EventArgs e)
        {
            if (gridMark.SelectedRows == null)
            {
                Core.Utility.Msg("Hãy chọn dòng mà bạn muốn hiển thị bài làm trực quan");
                return;
            }            
            DataGridViewRow row = gridMark.SelectedRows[0];
            gridMark.FirstDisplayedCell = row.Cells[0];
            // tránh người dùng thay đổi khi đã vào chế độ visualizer
            //row.Frozen = true;
            FormKeyVisualize visualizer = new FormKeyVisualize();
            Hashtable tag = visualizer.Tag as Hashtable;
            MarkRowInfo rowtag = (MarkRowInfo)row.Tag;
            tag.Add(FormKeyVisualize.TagKeys.Answer, (string)row.Cells["colDetail"].Value);
            tag.Add(FormKeyVisualize.TagKeys.Questions, _keys.questions);
            tag.Add(FormKeyVisualize.TagKeys.Column, -1);
            visualizer.rowIndex = rowtag.GridIndex;
            visualizer.FormClosing += new FormClosingEventHandler(visualizer_FormClosing);
            visualizer.MdiParent = this.MdiParent;
            visualizer.Top = this.Top;
            visualizer.Left = this.Left + this.Width;
            visualizer.StartPosition = FormStartPosition.Manual;
            visualizer.Show();
        }

        private void toolCloseOrgin_Click(object sender, EventArgs e)
        {
            toolScale.Visible = false;
            toolOrgin.Visible = true;
            panel.Visible = false;
            txtLog.Visible = true;
            txtLog.BringToFront();
            gridMark.Height = _previousGridHeight;
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
			((FormMain)this.MdiParent).mnuFileSave.PerformClick();
        }

		private void printToolStripButton_Click(object sender, EventArgs e)
		{            

			
		}
        private void Print()
        {
            PrintPreviewDialog prPreview = new PrintPreviewDialog();
            prPreview.Name = "Malyst";

            prPreview.Document = prDoc;
            prPreview.MdiParent = this.MdiParent;
            prDoc.DocumentName = "Ket qua Malyst";
            prDoc.DefaultPageSettings.PaperSize =
                new System.Drawing.Printing.PaperSize("A4", (int)(210 * 100 / 25.4f), (int)(297 * 100 / 25.4f));
            int margin = UI.Properties.Settings.Default.PrintMargin;
            prDoc.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(margin, margin, margin, margin);
            prPreview.Show();
        }
		private void printDocResult_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			
			bool status = Core.Print.Result.PrintWithName(this.Result, e);
			if (status == false)
			{
			}
		}
		
        private void gridMark_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (picture.Visible && gridMark.Rows[e.RowIndex].Tag != null)
            {
                gridMark.ClearSelection();
                gridMark.Rows[e.RowIndex].Selected = true;
                toolOrgin_Click(null, null);
                this.Invalidate(true);
            }
        }

        private void toolPrintByGroup_Click(object sender, EventArgs e)
        {
            this.Result.Sort(Core.Discovers.UserOrder.GroupStudent);
            this.Print();
        }

        private void toolPrintByMark_Click(object sender, EventArgs e)
        {
            this.Result.Sort(Core.Discovers.UserOrder.Mark);
            this.Print();
        }

        private void toolToWord_Click(object sender, EventArgs e)
        {
            this.Result.Sort(Core.Discovers.UserOrder.GroupStudent);
            ((FormMain)this.MdiParent).mnuDataExportRtf.PerformClick();
        }

        private void ghépTênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Result.Sort(Core.Discovers.UserOrder.GroupStudent);
            this.PrintCross();
        }

        private void PrintCross()
        {
            PrintPreviewDialog prPreview = new PrintPreviewDialog();
            prPreview.Name = "Malyst";

            prPreview.Document = new PrintDocument();
            prPreview.Document.PrintPage += new PrintPageEventHandler(crosst_PrintPage);
            prPreview.MdiParent = this.MdiParent;
            prDoc.DocumentName = "Ket qua Malyst";
            prDoc.DefaultPageSettings.PaperSize =
                new System.Drawing.Printing.PaperSize("A4", (int)(210 * 100 / 25.4f), (int)(297 * 100 / 25.4f));
            int margin = UI.Properties.Settings.Default.PrintMargin;
            prDoc.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(margin, margin, margin, margin);
            prPreview.Show();
        }

        void crosst_PrintPage(object sender, PrintPageEventArgs e)
        {
            Core.Print.Result.PrintCross(this.Result, e);
        }

        #region IInterpret Members

        public Discovers IResult
        {
            get { return Result; }
        }

        #endregion
    }    
}
