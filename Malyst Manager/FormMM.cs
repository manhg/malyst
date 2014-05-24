using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Collections;
using System.IO;

namespace GiangManh.MM
{
    public partial class FormMM : Form
    {        
        GiangManh.MM.Database db;
        public Form _MMActiveForm;
        public FormMM()
        {
            InitializeComponent();
            db = new GiangManh.MM.Database();
            db.Init(Application.StartupPath);                        
        }

        private void groupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        void grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            SqlCeException ex = e.Exception as SqlCeException;
            string message = "";
            DataGridView grid = sender as DataGridView;
            string source = " ở dòng: " + (e.RowIndex + 1).ToString() +
                       ", trong cột: \"" + grid.Columns[e.ColumnIndex].HeaderText + "\"";
            if (ex != null)
            {
                
                switch (ex.NativeError)
                {                    
                    case 25026:
                        // Message	"A foreign key value cannot be inserted because a corresponding primary key value does not exist.                      
                        message = "Thông tin không đúng" + source;  
                        break;
                    case 25016:
                        // Message	"A duplicate value cannot be inserted into a unique index. 
                        message = "Thông tin bị trùng" + source +". Hãy xem lại!";
                        break;
                    default:
                        message = e.Exception.Message;
                        break;
                }
            }
            else
            {
                switch (e.Exception.GetType().Name)
                {
                    case "FormatException":
                        message = "Dạng thông tin không đúng. Rất có thể bạn đã nhập một chữ vào" + 
                            " ô chỉ có thể nhập một số! Sửa lại" + source;
                        break;
                    case "InvalidOperationException":
                        if (e.Exception.Message.Contains("max"))
                            message = "Độ dài thông tin vượt quá mức cho phép. \r\n" + e.Exception.Message;
                        break;
                }
            }
            FormTableViewer f = ((FormTableViewer)grid.Parent.Parent.Parent);
            if (f.radioSilent.Checked)
            {
                f.timer1.Enabled = true;
                System.Media.SystemSounds.Asterisk.Play();
                f.errorProvider.BindToDataAndErrors(grid.DataSource, "");
                f.errorProvider.SetError(f, message);
                statusText.Text = message;
            }
            else
            {
                Utility.Miscellaneous.ErrorMessage(message);
            }
            
        }

        private void backUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "Cơ sở dữ liệu Malyst Manager |*.sdf";
            saveDlg.FileName = db.FileName;            
            saveDlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveDlg.RestoreDirectory = true;
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                
                System.IO.File.Copy(System.Windows.Forms.Application.StartupPath + "\\" + db.FileName, saveDlg.FileName,true);
            }
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult ensure = MessageBox.Show(
                "Bạn có chắc chắn muốn phục hồi từ một cơ sở dữ liệu có sẵn? Dữ liệu cũ sẽ bị thay thế!", "Nhắc lại",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ensure == DialogResult.No) return;
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Filter = "Cơ sở dữ liệu Malyst Manager|*.sdf";            
            openDlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openDlg.RestoreDirectory  = true;
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.Copy(System.Windows.Forms.Application.StartupPath + "\\" + db.FileName,
                    System.Windows.Forms.Application.StartupPath + "\\backup_" + db.FileName, true);
                foreach (Form form in MdiChildren)
                    form.Close();
                db.Close();
                System.IO.File.Copy(openDlg.FileName, System.Windows.Forms.Application.StartupPath + "\\" + db.FileName);
                db.Init(Application.StartupPath);
            }
        }
        public FormTableViewer getCoursesSumUpViewer(string table)
        {            
            SqlCeResultSet r = db.Select(string.Format
                ("SELECT [{0}].st_id, students.name, [{0}].mark FROM [{0}], students WHERE [{0}].st_id = students.st_id", table));
            FormTableViewer viewer = new FormTableViewer();
            viewer._MMHostForm = this;
            viewer.MdiParent = this;
            viewer.Text = string.Format("{0} {1} {2}", viewer.Text,
                table,db.GetTip("co_id",int.Parse(table.Substring(("co_sta_").Length))));
            viewer.grid.DataSource = r;
            FormTableViewerTag tag = new FormTableViewerTag(db, Database.Tables.CoursesSumUp);
            tag.expand = table;
            viewer.Tag = tag;
            viewer.grid.DataError += new DataGridViewDataErrorEventHandler(grid_DataError);
            viewer.grid.CellValueChanged += new DataGridViewCellEventHandler(grid_CellValueChanged);
            string[] caption = db.TableCaptions(Database.Tables.CoursesSumUp);
            if (caption.Length == viewer.grid.Columns.Count)
            {
                for (int i = 0; i < viewer.grid.Columns.Count; i++)
                {
                    viewer.grid.Columns[i].HeaderText = caption[i];
                }
            }
            return viewer;
        }
        public FormTableViewer getViewer(GiangManh.MM.Database.Tables table)
        {
            string sql = "SELECT * FROM {0} ";
            switch (table)
            {
                case Database.Tables.Marks:
                    sql += "ORDER BY st_id";
                    break;
                case Database.Tables.Students:
                    sql += "ORDER BY gr_id ASC, no ASC";
                    break;
            }
            SqlCeResultSet r = db.Select(string.Format(sql,table));
            FormTableViewer viewer = new FormTableViewer();
            viewer._MMHostForm = this;
            viewer.MdiParent = this;
            viewer.Text =  string.Format("{0} {1}",viewer.Text,table);
            viewer.grid.DataSource = r;            
            FormTableViewerTag tag = new FormTableViewerTag(db,table);
            tag.expand = string.Format("{0}",table);
            viewer.Tag = tag;
            viewer.grid.DataError += new DataGridViewDataErrorEventHandler(grid_DataError);
            viewer.grid.CellValueChanged += new DataGridViewCellEventHandler(grid_CellValueChanged);
            string[] caption = db.TableCaptions(table);
            if (caption.Length == viewer.grid.Columns.Count)
            {
                for (int i = 0; i < viewer.grid.Columns.Count; i++)
                {
                    viewer.grid.Columns[i].HeaderText = caption[i];
                }
            }
            return viewer;
        }

        void grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView grid = sender as DataGridView;
                if (grid.Columns[e.ColumnIndex].Name == "name" && e.RowIndex != -1)
                {
                    grid[e.ColumnIndex, e.RowIndex].Value =
                        Utility.Miscellaneous.ValidName(grid[e.ColumnIndex, e.RowIndex].Value.ToString());
                }
            }
            catch (Exception) { }
        }

        private void tablesToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                object table = Enum.Parse(MM.Database.Tables.NULL.GetType(), e.ClickedItem.ToolTipText.Substring(1), true);
                if (table is MM.Database.Tables)
                {
                    FormTableViewer viewer = getViewer((MM.Database.Tables)table);
                    FormTableViewerTag tag = new FormTableViewerTag(db, (MM.Database.Tables)table);
                    viewer.Tag = tag;
                    viewer.Init();
                    viewer.Show();
                }
            }
            catch (ArgumentException) { }
            catch (NullReferenceException) { }
        }
        public const string configFile = "MM.config.xml";
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string configF = Application.StartupPath + "\\" + configFile;
            Option.OptionDialog optionDlg = new GiangManh.Option.OptionDialog(false,false,true);
            if (File.Exists(configF))
            {
                optionDlg.LoadOptionFile(configF);
            }
            optionDlg.MdiParent = this;
            optionDlg.Show();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDlg = new SaveFileDialog();

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Filter = "Cơ sở dữ liệu Malyst Manager|*.sdf";            
            openDlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openDlg.RestoreDirectory  = true;
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                MalystManager.FormDatabase fdb = new MalystManager.FormDatabase();
                Database db = new Database();
                db.FileName = openDlg.FileName;
                db.Init(Application.StartupPath);
                fdb.Database = db;
                fdb.MdiParent = this;
                fdb.Show();
            }
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void tileHorizonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void arrageIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void FormMM_FormClosing(object sender, FormClosingEventArgs e)
        {
            db.Close();            
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ActiveMdiChild.Close();
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form mdiChild in this.MdiChildren)
                mdiChild.Close();
        }

        private void searchBox_KeyUp(object sender, KeyEventArgs e)
        {           
            bool searchAll = false;
            if (e.KeyData == (Keys.Shift | Keys.Enter)) searchAll = true;
            if (e.KeyCode == Keys.Enter || searchAll)
            {                
                MalystManager.ISearchtable target = this.ActiveMdiChild as MalystManager.ISearchtable;
                if (target == null) target = this._MMActiveForm as MalystManager.ISearchtable;
                string search = searchBox.Text.Trim();
                if (target != null && searchBox.Text != "")
                {
                    DataGridView g = target.IGrid;
                    g.ClearSelection();
                    for (int r = 0; r < g.RowCount; r++)
                        for (int c = 0; c < g.ColumnCount; c++)
                            try
                            {
                                if (g[c, r].Value.ToString().Contains(search))
                                {
                                    g[c, r].Selected = true;
                                    if (!searchAll)
                                    {
                                        g.FirstDisplayedCell = g[c, r];
                                        return;
                                    }
                                }
                            }
                            catch (NullReferenceException) { }
                    if (g.SelectedCells.Count == 0) 
                        MessageBox.Show
                        ("Không tìm thấy! Chú ý là có phân biệt chữ hoa và chữ thường.\nNhấn Esc để thoát hộp thoại này.");
                    else
                    {
                        g.FirstDisplayedScrollingRowIndex = g.SelectedCells[0].RowIndex;
                    }
                }
                e.SuppressKeyPress = false;                
            }
        }

        private void searchAll_Click(object sender, EventArgs e)
        {
            searchBox_KeyUp(null, new KeyEventArgs(Keys.Shift | Keys.Enter));
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FormTableViewer activeViewer = this.ActiveMdiChild as FormTableViewer;
            if (activeViewer == null) activeViewer = this._MMActiveForm as FormTableViewer;
            if (activeViewer == null)
            {
                Utility.Miscellaneous.ErrorMessage("Vui lòng mở cửa sổ chứa bảo dữ liệu cần chuyển sang Excel\n" +
                    "trước khi vào mục này.\n");
                return;
            }
            FormTableViewerTag tag = activeViewer.Tag as FormTableViewerTag;
            if (tag == null)
            {
                MessageBox.Show("Bảng dữ liệu này chỉ có thể dùng Quick Report để đưa sang Excel");
                return;
            }
            string title = "";
            switch (tag.Table)
            {
                case Database.Tables.CoursesSumUp:
                    title = "BẢNG TỔNG KẾT ĐIỂM LỚP " + db.GetTip("co_id", int.Parse(tag.expand.Substring(("co_sta_").Length))); break;
                case Database.Tables.Courses:
                    title = "DANH SÁCH PHÂN CÔNG GIẢNG DẠY"; break;
                case Database.Tables.Groups:
                    title = "DANH SÁCH CÁC LỚP"; break;
                case Database.Tables.Marks:
                    title = "BẢNG ĐIỂM LỚN"; break;
                case Database.Tables.Students:
                    title = "DANH SÁCH HỌC SINH"; break;
                case Database.Tables.Teachers:
                    title = "DANH SÁCH GIÁO VIÊN"; break;
            }
            SaveFileDialog saveFileDlg = new SaveFileDialog();
            saveFileDlg.Filter = "Excel XML Document |*.excel.xml";
            saveFileDlg.FileName = string.Format("{0} {1}", tag.Table, DateTime.Today.ToString("dd-MM-yyyy"));
            saveFileDlg.SupportMultiDottedExtensions = true;
            saveFileDlg.Title = "Xuat bang du lieu sang Excel";
            if (saveFileDlg.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = null;
                try
                {
                    sw = new StreamWriter(saveFileDlg.OpenFile());
                    if (tag.Table == Database.Tables.CoursesSumUp)
                    {
                        sw.Write(tag.Db.ExportExcelXml(tag.expand,
                            string.Format
                            ("SELECT [{0}].st_id, students.name, [{0}].mark FROM [{0}],"
                            + "students WHERE [{0}].st_id = students.st_id", tag.expand),
                            title));}
                    else 
                        sw.Write(tag.Db.ExportExcelXml(tag.Table.ToString(),string.Empty,title));
                        sw.Flush();
                        if (Utility.Miscellaneous.Confirm
                            ("Đã lưu xong:\n" + saveFileDlg.FileName + "\nBạn có muốn mở xem thử không?"))
                        {
                            System.Diagnostics.Process.Start(saveFileDlg.FileName);
                        }
                    
                }
                catch (Exception ex)
                {
                    Utility.Miscellaneous.ErrorMessage("Có lỗi khi lưu kết quả\n" + ex.Message);

                }
                finally { if(sw!=null) sw.Close(); }
            }
        }

        private void exportToolStrip_Click(object sender, EventArgs e)
        {
            excelToolStripMenuItem.PerformClick();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            marksToolStripMenuItem.PerformClick();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            coursesToolStripMenuItem.PerformClick();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            studentsToolStripMenuItem.PerformClick();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            groupsToolStripMenuItem.PerformClick();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            teachersToolStripMenuItem.PerformClick();
        }

        private void FormMM_Load(object sender, EventArgs e)
        {
            this.Text += " v." + Application.ProductVersion;
        }

        private void reorderAllGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Utility.Miscellaneous.Confirm("Bạn có chắc chắn muốn đánh số thứ tự lại toàn bộ học sinh?") == true)
            {
                object[] gr = db.GetGroupsList();
                int[] id = (int[])gr[1];
                int c = id.Length;
                for (int i = 0; i < c; i++)
                {
                    try
                    {
                        db.StudentReorderInGroup(id[i]);
                    }
                    catch (Exception ex) { }
                }
                MessageBox.Show("Đã đánh số thứ tự xong danh sách tất cả học sinh.");
            }
        }

        private void reportSplitButton_DropDownOpening(object sender, EventArgs e)
        {
            //if (reportToolStripMenuItem.DropDownItems.Count != 0)
            //{
            //    reportSplitButton.DropDown = reportToolStripMenuItem.DropDown;
            //}
        }

        private void reportToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            //if (reportSplitButton.DropDownItems.Count != 0)
            //{
            //    reportToolStripMenuItem.DropDown = reportSplitButton.DropDown;
            //}
        }

        private void groupsOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {            
        }        

        private void reportDestToolItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //reportDestToolItem.Text = e.ClickedItem.Text;
            //reportDestToolItem.Image = e.ClickedItem.Image;
        }

        private void reportDestToolItem_Click(object sender, EventArgs e)
        {
            //reportDestToolItem.DropDown.Show();
        }

        private void reportSplitButton_Click(object sender, EventArgs e)
        {
            MalystManager.ISearchtable iSearch = this.ActiveMdiChild as MalystManager.ISearchtable;
            if (iSearch == null) iSearch = this._MMActiveForm as MalystManager.ISearchtable;
            if (iSearch == null)
            {
                MessageBox.Show("Vui lòng chọn một cửa sổ muốn lập báo cáo nhanh");
                return;
            }
            StringBuilder r = new StringBuilder();
            DataGridView g = iSearch.IGrid;
            MalystManager.FormText ft = new MalystManager.FormText();
            ft.MdiParent = this;
            ft.richTextBox.Text = Utility.Miscellaneous.GetTabText(Utility.Miscellaneous.GetGridContent(g));
            ft.Show();
        }

        private void toolQRWord_Click(object sender, EventArgs e)
        {
            MalystManager.ISearchtable iSearch = this.ActiveMdiChild as MalystManager.ISearchtable;
            if (iSearch == null) iSearch = this._MMActiveForm as MalystManager.ISearchtable;
            if (iSearch == null)
            {
                MessageBox.Show("Vui lòng chọn một cửa sổ muốn lập báo cáo nhanh");
                return;
            } 
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "Microsoft Word XML document|*.word.xml";
            saveDlg.SupportMultiDottedExtensions = true;
            try
            {
                saveDlg.FileName = this.ActiveMdiChild.Text + DateTime.Now.ToFileTime();
            }
            catch (Exception) { }
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                DataGridView g = iSearch.IGrid;                      
                Utility.OfficeWordXml.Write(saveDlg.OpenFile(),
                    Utility.Miscellaneous.GetGridWidth(g),Utility.Miscellaneous.GetGridContent(g));
                System.Diagnostics.Process.Start(saveDlg.FileName);
            }
        }
        private void toolQRExcel_Click(object sender, EventArgs e)
        {
            MalystManager.ISearchtable iSearch = this.ActiveMdiChild as MalystManager.ISearchtable;
            if (iSearch == null) iSearch = this._MMActiveForm as MalystManager.ISearchtable;
            if (iSearch == null)
            {
                MessageBox.Show("Vui lòng chọn một cửa sổ muốn lập báo cáo nhanh");
                return;
            }
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "Microsoft Excel XML document|*.excel.xml";
            saveDlg.SupportMultiDottedExtensions = true;
            try
            {
                saveDlg.FileName = this.ActiveMdiChild.Text + DateTime.Now.ToFileTime();
            }
            catch (Exception) { }
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                DataGridView g = iSearch.IGrid;
                Utility.OfficeExcelXml.Write(saveDlg.OpenFile(),
                    Utility.Miscellaneous.GetGridContent(g), this.ActiveMdiChild.Text!=string.Empty ? this.ActiveMdiChild.Text: DateTime.Now.ToString("ddMMyyyy"));
                System.Diagnostics.Process.Start(saveDlg.FileName);
            }
        }

        private void printablePagetoolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                MalystManager.ISearchtable iSearch = this.ActiveMdiChild as MalystManager.ISearchtable;
                if (iSearch == null) iSearch = this._MMActiveForm as MalystManager.ISearchtable;
                if (iSearch == null)
                {
                    MessageBox.Show("Vui lòng chọn một cửa sổ muốn lập báo cáo nhanh");
                    return;
                }
                DataGridView g = iSearch.IGrid;
                string[,] r = Utility.Miscellaneous.GetGridContent(g);
                Utility.PrintJob preview = new GiangManh.Utility.PrintJob();
                preview.Text(
                    textPrintTitle.Text + Environment.NewLine + Environment.NewLine +
                    Utility.Miscellaneous.GetTabPad(r, Utility.Miscellaneous.GetGridWidth(g), 5),
                    this.ActiveMdiChild.Text);
            }
            catch (Exception) { }
        }

        private void toolQRPlain_Click(object sender, EventArgs e)
        {
            try
            {
                MalystManager.ISearchtable iSearch = this.ActiveMdiChild as MalystManager.ISearchtable;
                if (iSearch == null) iSearch = this._MMActiveForm as MalystManager.ISearchtable;
                if (iSearch == null)
                {
                    MessageBox.Show("Vui lòng chọn một cửa sổ muốn lập báo cáo nhanh");
                    return;
                }
                SaveFileDialog saveDlg = new SaveFileDialog();
                saveDlg.Filter = "Plain Unicode Text|*.txt";
                saveDlg.SupportMultiDottedExtensions = true;
                saveDlg.FileName = this.ActiveMdiChild.Text + DateTime.Now.ToFileTime();
                if (saveDlg.ShowDialog() == DialogResult.OK)
                {
                    DataGridView g = iSearch.IGrid;
                    string[,] r = Utility.Miscellaneous.GetGridContent(g);

                    StreamWriter sw = new StreamWriter(saveDlg.OpenFile());
                    sw.Write(Utility.Miscellaneous.GetTabText(r));
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                    System.Diagnostics.Process.Start(saveDlg.FileName);
                }
            }
            catch (Exception) { }
        }
        double transprancy = 0.75f;
        ArrayList outerForm = new ArrayList();
        bool transparent = false;
        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            try
            {
                if (!transparent)
                {

                    foreach (Form f in this.MdiChildren)
                    {
                        f.MdiParent = null;
                        f.Opacity = transprancy;
                        f.ShowInTaskbar = true;
                        //f.TopMost = true;
                        outerForm.Add(f);

                    }
                    transparent = true;
                }
                else
                {
                    foreach (object obj in outerForm)
                    {
                        Form f = obj as Form;
                        if (f != null)
                        {
                            f.Opacity = 1;
                            f.MdiParent = this;
                            f.ShowInTaskbar = false;
                            //f.TopMost = false;
                        }
                        else outerForm.Remove(obj);
                        transparent = false;
                    }
                }
            }
            catch (Exception) { }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void en_vi_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            this.Invalidate();
        }

        private void sortWinstoolStripButton_Click(object sender, EventArgs e)
        {
            tileHorizonalToolStripMenuItem.PerformClick();
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is FormTableViewer)
            {
                FontDialog fontDlg = new FontDialog();
                fontDlg.Font = ((FormTableViewer)this.ActiveMdiChild).grid.Font;
                fontDlg.ShowDialog();
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printablePagetoolStripButton_Click(null, null);
        }

        private void wordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolReportWord.PerformClick();
        }
        string previousTitleText;
        private void textPrintTitle_Enter(object sender, EventArgs e)
        {
            previousTitleText = textPrintTitle.Text;
            textPrintTitle.Text = string.Empty;
            textPrintTitle.ForeColor = Color.Black;
        }        
        private void tùyChọnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            if (fontDlg.ShowDialog() == DialogResult.OK)
            {
                Utility.PrintJob.DefaultFont = fontDlg.Font;
            }
        }

        private void printTableToolStripButton_Click(object sender, EventArgs e)
        {

            Utility.FormPrintTable fpt = new GiangManh.Utility.FormPrintTable();
            fpt.MdiParent = this;
            fpt.Show();
        }

        private void timesNewRomanToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripSplitButton1_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {            
        }

        private void teacherNotebookAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] te_list = db.GetTeachersList();
            if (te_list == null)
            {
                Utility.Miscellaneous.Message("Không có giáo viên nào cả.");
                return;
            }
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            folderDlg.RootFolder = Environment.SpecialFolder.MyDocuments;
            folderDlg.Description = "Chọn thư mục sẽ chứa các sổ điểm của các giáo viên, nên tạo một thư mục mới vì sẽ có rất nhiều tệp tương ứng với mỗi giáo viên.";
            if (folderDlg.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < te_list.Length; i++)
                {
                    Utility.OfficeExcelXml.MultipleSheets(db.BuildTeacherNotebook
                        (te_list[i]), folderDlg.SelectedPath + "\\" + db.GetTip("te_id", te_list[i]) + " sổ điểm.excel.xml", false);
                }
                System.Diagnostics.Process.Start(folderDlg.SelectedPath);
            }  
        }

        private void lookUpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
