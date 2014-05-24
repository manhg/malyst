using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace UI
{
    public partial class FormNewsuite : Form
    {
        static int instance = 0;
        
        static int newSuiteIndex = -1;
        /// <summary>
        /// Suite vừa mới tạo bằng một form nào đó.
        /// Dùng để truyền cho các của sổ khác.
        /// Biến này chứa index của suite mới trong UniSuite
        /// </summary>
        public static int NewSuiteIndex
        {
            get { return FormNewsuite.newSuiteIndex; }
            set { FormNewsuite.newSuiteIndex = value; }
        }
        /// <summary>
        /// Lấy số instance của loại form này
        /// </summary>
        public static int Instance
        {
            get { return FormNewsuite.instance; }
        }
        public FormNewsuite()
        {
            instance++;
            InitializeComponent();
            this.Tag = new Hashtable();
            this.Text = "Tạo bộ đáp án " + FormNewsuite.Instance;
            colKey.ValueType = ("").GetType();
            colProblem.ValueType = (0).GetType();
        }

        private void gridProblems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = gridProblems[e.ColumnIndex, e.RowIndex];
            if (cell.EditedFormattedValue == null) return;
            switch (e.ColumnIndex)
            {
                case 1:
                    // Cột đáp án
                    string key = cell.EditedFormattedValue.ToString();
                    if (key != "")
                    {
                        if (Core.Utility.Clarify(key).Length != numQuestions.Value)
                        {
                            cell.Style.BackColor = Color.Yellow;
                            object problem = gridProblems["colProblem", e.RowIndex].Value;
                            Core.Utility.Error(
                                problem == null ? "Chưa có mã đề tương ứng" : "Mã đề " + (int)problem + 
                                " : Số câu trong đáp án không trùng với số câu đã định trong bộ đáp án.");
                        }
                        else
                        {
                            cell.Value = Core.Utility.ClearLook(key);
                            cell.Style.BackColor = Color.White;
                        }
                    }
                    break;
            }
        }

        private void gridProblems_Resize(object sender, EventArgs e)
        {
            colKey.Width = gridProblems.Width - colProblem.Width - 20;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Core.KeySuite keysuite = new Core.KeySuite();
            keysuite.name = "";
            if (listSubject.SelectedItems != null && listSubject.SelectedItems.Count >= 1)
            {
                keysuite.name = listSubject.SelectedItems[0].ToolTipText;
            }
            saveFileDialog.Filter = UI.Properties.Settings.Default.KeyFileFilter;
            // Tên file mặc định là môn và ngày tháng            
            saveFileDialog.FileName = keysuite.name + DateTime.Now.ToString(" ddMMyyyy-hhmm");
            keysuite.name += " {0}" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {                
                keysuite.questions = (int)Math.Round(numQuestions.Value);
                keysuite.portion = trackTestPortion.Value;
                for (int i = 0; i < gridProblems.RowCount - 1; i++)
                {
                    Core.Key key = new Core.Key();
                    key.date = DateTime.Now;
                    if (gridProblems.Rows[i].Cells["colProblem"].Value != null
                        && gridProblems.Rows[i].Cells["colKey"].Value != null)
                    {
                        key.problem = (int)gridProblems.Rows[i].Cells["colProblem"].Value;
                        key.key = (string)gridProblems.Rows[i].Cells["colKey"].Value;                        
                        if (key.problem == 0 || key.key == "") continue;
                        keysuite.AddItem(key);
                    }
                }
                Core.Utility.XmlSerialize(saveFileDialog.FileName, keysuite, Core.Utility.MyXmlFileType.KeySuite,
                    ((FormMain)this.MdiParent).toolProgressStrip,
                ((FormMain)this.MdiParent).toolStatusText);
                // Tự động thêm key suite mới vào Unisuite            
                FormNewsuite.newSuiteIndex = Core.Ref.UniSuite.Add(keysuite);
                this.Close();
            }                      
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (Core.Utility.Confirm("Bạn có chắc chắn muốn hủy bỏ?")
                == DialogResult.Yes)
            {
                FormNewsuite.newSuiteIndex = -1;
                this.Close();
                this.Dispose();
            }
        }
        private void btnGenerateCode_Click(object sender, EventArgs e)
        {

            int subjectCode;
            if (listSubject.SelectedItems.Count != 0)
                subjectCode = int.Parse(listSubject.SelectedItems[0].Tag.ToString());
            else subjectCode = 0;
            Random rand = new Random();
            ArrayList exsit = new ArrayList();
            gridProblems.Rows.Clear();
            int code;
            gridProblems.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            // Sinh mã đề và đưa nó vào grid
            for (int i = 0; i < numProblem.Value; i++)
            {
                do
                {
                    int[] problem = new int[3];
                    problem[0] = rand.Next(5, 9);
                    problem[1] = rand.Next(problem[0] + 1, 10);
                    problem[2] = rand.Next(problem[1] + 1, 11) % 10;
                    code = subjectCode * 1000 + problem[0] * 100 + problem[1] * 10 + problem[2];
                } while (exsit.IndexOf(code) != -1);
                exsit.Add(code);
                gridProblems.Rows.Add(code, "");
            }
        }

        private void gridProblems_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string message = "Dữ liệu sai. ";
            switch (e.ColumnIndex)
            {
                case 0:
                    // Cột mã đề
                    message += "Mã đề phải là một số. Bạn nên dùng nút sinh mã đề ở trên, không nên sửa trực tiếp mục này";
                    break;
                case 1:
                    // Cột key (đáp án)
                    message += "Dữ liệu phải là một chuỗi theo dạng quy ước";
                    break;
            }
            Core.Utility.Error(message);

        }

        private void gridProblems_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==1 && radioVisual.Checked)
            {
                btnVisual.PerformClick();
            }
        }

        void visualizer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hashtable tag = ((Form)sender).Tag as Hashtable;
            int column = (int)tag[FormKeyVisualize.TagKeys.Column],
                row = (int)tag[FormKeyVisualize.TagKeys.Row];
            gridProblems[column, row].Value = (string)(tag[FormKeyVisualize.TagKeys.Answer]);
            this.Enabled = true;
            colKey.Selected = true;
            this.gridProblems.SelectionMode = DataGridViewSelectionMode.CellSelect;
            this.gridProblems[0, row].Selected = true;
        }

        private void btnVisual_Click(object sender, EventArgs e)
        {
            if (gridProblems.SelectedCells.Count == 0) return;
            DataGridViewCell cell = gridProblems[1,gridProblems.SelectedCells[0].RowIndex];            
            //if (cell.ColumnIndex == 1)
            {
                this.Enabled = false;
                FormKeyVisualize visualizer = new FormKeyVisualize();
                Hashtable tag = visualizer.Tag as Hashtable;
                tag.Add(FormKeyVisualize.TagKeys.Answer, cell.Value == null ? "" : (string)cell.Value);
                tag.Add(FormKeyVisualize.TagKeys.Questions, (int)numQuestions.Value);
                tag.Add(FormKeyVisualize.TagKeys.Column, cell.ColumnIndex);
                tag.Add(FormKeyVisualize.TagKeys.Row, cell.RowIndex);
                visualizer.FormClosing += new FormClosingEventHandler(visualizer_FormClosing);
                visualizer.MdiParent = this.MdiParent;
                visualizer.Top = this.Top;
                visualizer.Left = this.Left + this.Width;
                visualizer.StartPosition = FormStartPosition.Manual;
                visualizer.Show();
            }
        }

        private void numQuestions_Enter(object sender, EventArgs e)
        {
            numQuestions.Select();
        }

        private void numProblem_Enter(object sender, EventArgs e)
        {
            numProblem.Select();
        }

        private void gridProblems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnVisual.PerformClick();
        }

        private void trackTestPortion_Scroll(object sender, EventArgs e)
        {
            lblPortion.Text = trackTestPortion.Value.ToString() + "% trắc nghiệm";
        }
    }
}