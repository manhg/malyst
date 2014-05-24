using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace GiangManh.MM
{
    public partial class FormTableViewer : Form, MalystManager.ISearchtable
    {
        public FormMM _MMHostForm;
        public DataGridView IGrid
        {
            get { return this.grid; }
            set { this.grid = value; }
        }
        public FormTableViewer()
        {
            InitializeComponent();
        }
        FormTableViewerTag tag;
        string toolTipText = "Sử dụng dấu phẩy để phân cách các thành phần. \n";
        public void Init()
        {                        
            tag = this.Tag as FormTableViewerTag;
            if (tag == null) return;
            
            switch (tag.Table)
            {                    
                case Database.Tables.Teachers:
                    toolTipText += "Gõ <Họ và tên> <Môn dạy viết tắt>";
                    toolTipText += "Bảng các môn viết tắt như sau:\n" +
@" Toán      T-TO
  Vật lý    L-LY-LI
  Hóa học   H-HO 
  Ngữ văn   V-VA 
  Lịch sử   S-SU 
  Địa lý    D-DI 
  Công nghệ CO-CN       
  Tin học   TI 
  Tiếng Anh A-AN 
  Mỹ thuật  M-MI-MY
  Âm nhạc   AM 
  GDCD      GD-GI 
  Sinh học  SI-SH 
  Thể dục   TH-TD 
  Ngoại ngữ NN";
                    ToolStripMenuItem reportPersonalNotebook = new ToolStripMenuItem("Lập sổ điểm cá nhân");
                    reportPersonalNotebook.Click += new EventHandler(reportPersonalNotebook_Click);
                    toolMore.DropDownItems.Add(reportPersonalNotebook);
                    break;
                case Database.Tables.Groups:
                    toolTipText += "Gõ <Lớp ID>, <Tên lớp> ";
                    ToolStripMenuItem generateGroupCodeTool = new ToolStripMenuItem();
                    generateGroupCodeTool.Text = "Tạo mã lớp";
                    generateGroupCodeTool.Click += new EventHandler(generateGroupCodeTool_Click);
                    toolMore.DropDownItems.Add(generateGroupCodeTool);
                    break;
                case Database.Tables.Students:
                    toolTipText += "Gõ <Họ tên> (không cần viết hoa) hoặc <Họ tên>, <Ngày sinh>";
                    object[] _gr = tag.Db.GetGroupsList();
                    string[] gr = (string[])_gr[0];
                    int[] gr_id = (int[])_gr[1];
                    for (int i = 0; i < gr.Length; i++)
                    {
                        ToolStripMenuItem item = new ToolStripMenuItem(gr[i]);
                        item.Tag = gr_id[i];
                        dropdown.DropDownItems.Add(item);                        
                    }
                    ToolStripMenuItem reorderStudentNo = new ToolStripMenuItem("Sắp xếp HS và điền thứ tự");
                    reorderStudentNo.Click += new EventHandler(reorderStudentNo_Click);
                    ToolStripMenuItem addStudentFromExcel = new ToolStripMenuItem("Lấy danh sách lớp từ Excel");
                    addStudentFromExcel.Click += new EventHandler(addStudentFromExcel_Click);
                    toolMore.DropDownItems.Add(reorderStudentNo);
                    toolMore.DropDownItems.Add(addStudentFromExcel);
                    break;    
                case Database.Tables.Marks:                    
                    toolTipText += "Gõ <Điểm>, <Thứ tự>, <Hệ số>\n hoặc <Điểm>, <Thứ tự>,\n " +
                        "hoặc <Điểm>.\n Thứ tự và hệ số của lần trước đó được ghi nhớ.\n"+
                        "Điểm thi có thể nhập dạng số nguyên hoặc như bình thường, VD 85 sẽ hiểu là 8.5\n" +
                        "Dấu phân cách phần thập phân luôn là dấu chấm (.)";
                    try
                    {
                        object[] _co = tag.Db.GetCoursesList();
                        string[] co = (string[])_co[0];
                        int[] co_id = (int[])_co[1];
                        for (int i = 0; i < co.Length; i++)
                        {
                            ToolStripMenuItem item = new ToolStripMenuItem(co[i]);
                            item.Tag = co_id[i];
                            dropdown.DropDownItems.Add(item);
                        }
                    }
                    catch (Exception) { }
                    ToolStripMenuItem importMark = new ToolStripMenuItem();
                    importMark.Text = "Nhập điểm từ Malyst Scan";
                    importMark.Click += new EventHandler(importMark_Click);

                    toolMore.DropDownItems.Add(importMark);
                    break;
                case Database.Tables.Courses:
                    //toolTipText += "Gõ <Lớp>\n hoặc <Lớp>,<GVID>\nHoặc <Lớp>,<GVID>,<Môn>.\nNội dung trước đó luôn được"
                    //    + "ghi nhớ một cách tự động. Có thể nhập <Lớp ID> thay cho lớp, <Môn viết tắt> thay cho môn.";
                    ToolStripMenuItem itemTeacher = new ToolStripMenuItem("Hiện thầy cô");
                    itemTeacher.Tag = 1;
                    dropdown.DropDownItems.Add(itemTeacher);
                    ToolStripMenuItem itemGroup = new ToolStripMenuItem("Hiện lớp");
                    itemGroup.Tag = 2;
                    dropdown.DropDownItems.Add(itemGroup);
                    ToolStripMenuItem itemSubject = new ToolStripMenuItem("Nhóm theo môn");
                    itemSubject.Tag = 3;
                    dropdown.DropDownItems.Add(itemSubject);

                    ToolStripMenuItem testCoursesCompletion = new ToolStripMenuItem();
                    testCoursesCompletion.Text = "Kiểm tra điểm";
                    testCoursesCompletion.ToolTipText = "Chọn các BGID cần kiểm tra";
                    testCoursesCompletion.Click += new EventHandler(testCoursesComplettion_Click);

                    ToolStripButton staticsToolStripButton = new ToolStripButton("Tính điểm");
                    staticsToolStripButton.Click += new EventHandler(staticsToolStripButton_Click);
                    toolStrip1.Items.Add(staticsToolStripButton);
                    ToolStripMenuItem importMark1 = new ToolStripMenuItem();
                    importMark1.Text = "Nhập điểm từ Malyst Scan";
                    importMark1.Click += new EventHandler(importMark_Click);                    
                    toolMore.DropDownItems.Add(importMark1);
                    toolMore.DropDownItems.Add(testCoursesCompletion);

                    grid.CellValueChanged += new DataGridViewCellEventHandler(grid_Courses_CellValueChanged);
                    break;
                case Database.Tables.CoursesSumUp:
                    break;
            }
            dropdown.DropDownItemClicked += new ToolStripItemClickedEventHandler(dropdown_DropDownItemClicked);
            textInfo.ToolTipText = string.Empty;
        }

        void reportPersonalNotebook_Click(object sender, EventArgs e)
        {
            if (grid.SelectedCells.Count == 0)
            {
                Utility.Miscellaneous.Message("Vui lòng chọn giáo viên cần lập sổ điểm cá nhân.\n" +
                    "Để lập sổ điểm cho tất cả giáo viên, hãy chọn từ menu \"Dữ liệu > Lập sổ điểm cho tất cả giáo viên\"");
                return;
            }
            try
            {
                int te_id = (int)grid[0, grid.SelectedCells[0].RowIndex].Value;
                string fileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + tag.Db.GetTip("te_id", te_id) + " sổ điểm.excel.xml";
                Utility.OfficeExcelXml.MultipleSheets(tag.Db.BuildTeacherNotebook(te_id), fileName,true);
            }
            catch (Exception ex) {
                Utility.Miscellaneous.ErrorMessage("Có lỗi khi lập sổ điểm cá nhân! \n" + ex.Message);
            }
        }

        void grid_Courses_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (grid.Columns[e.ColumnIndex].Name == "te_id")
            {
                try
                {
                    int te_id = (int)grid[e.ColumnIndex, e.RowIndex].Value;
                    string subject = (string)tag.Db.SelectScalar("SELECT subject FROM teachers WHERE te_id=" + te_id);
                    grid[3, e.RowIndex].Value = subject;
                }
                catch (Exception) { }
            }
        }

        void addStudentFromExcel_Click(object sender, EventArgs e)
        {
            if (Utility.Miscellaneous.Confirm(
@"Để nhập danh sách từ Excel, tệp tin Excel của bạn phải:
1. Đặt danh sách từ dòng thứ nhất, cột A ghi họ tên, cột B (có thể có hoặc không) ghi ngày sinh
2. Mỗi một lớp  đặt trong một Worksheet. Lớp ID được tạo theo thời gian.
   Sau khi nhập danh sách học sinh, bạn nên đổi lại mã lớp.
3. Vào File > Save as (đối với Office 2003) hoặc chọn Nút Office > Save as > Other Format (đối với Office 2007)
4. Chọn Save as type là XML Spreadsheet với Office 2003 hoặc XML Spreadsheet 2003 với Office 2007 rồi lưu lại.

Bạn đã thự hiện xong những điều trên chưa? Nếu rồ, nhấn Yes và chọn tệp mà bạn vừa lưu.") == true)
            {
                OpenFileDialog openDlg = new OpenFileDialog();
                openDlg.Filter = "XML Excel Spreadsheet|*.xml";
                openDlg.Multiselect = false;
                openDlg.Title = "Chon tep de lay danh sach hoc sinh";
                if (openDlg.ShowDialog() == DialogResult.OK)
                {
                    string gr_list = tag.Db.ImportStudents(openDlg.OpenFile());
                    Utility.Miscellaneous.Message("Đã nhận xong danh sách học sinh từ tệp: "
                        + Environment.NewLine + openDlg.FileName + Environment.NewLine
                        + "Xin vui lòng sửa Lớp ID cũng như tên lớp, mã lớp trong danh sách các lớp sau:" + Environment.NewLine
                        + gr_list);
                }

            }
        }

        void reorderStudentNo_Click(object sender, EventArgs e)
        {
            if (id_selected != -1)
            {
                tag.Db.StudentReorderInGroup(id_selected);
                Utility.Miscellaneous.Message("Học sinh trong lớp : " + tag.Db.GetTip("gr_id",id_selected) +
                    Environment.NewLine + "đã được thay đổi thứ tự theo vần alphabeta dùng trong trong bài kiểm tra.");
            }
            else Utility.Miscellaneous.ErrorMessage
                ("Chọn một lớp cần xếp thứ tự học sinh trước khi nhấn nút này.\n" +
                "Nếu cần đổi thứ tự tất cả các lớp, vào menu Tools > "); 
        }

        void generateGroupCodeTool_Click(object sender, EventArgs e)
        {
            tag.Db.GroupsGenerateCode();
            grid_refresh();
        }

        void importMark_Click(object sender, EventArgs e)
        {
            try
            {
                switch (tag.Table)
                {
                    case Database.Tables.Courses:
                        if (grid.SelectedCells.Count == 0
                            || grid.Columns[grid.SelectedCells[0].ColumnIndex].Name[0] != 'r')
                        {
                            MessageBox.Show("Vui lòng chọn MỘT ô chứa HỆ SỐ trong dòng mô tả\n" +
                            "BGID cần nhập điểm từ Malyst Scanner.");
                            return;
                        }
                        DataGridViewCell cell = grid.SelectedCells[0];

                        OpenFileDialog openDlg = new OpenFileDialog();
                        openDlg.Title = "Chon tep ket qua cua Malyst Scan";
                        openDlg.Filter = "Kết quả chấm từ Malyst Scann *.log.xml|*.log.xml";
                        openDlg.Multiselect = false;
                        openDlg.SupportMultiDottedExtensions = true;
                        if (openDlg.ShowDialog() == DialogResult.OK)
                        {
                            int co_id = int.Parse(grid[0, cell.RowIndex].Value.ToString());
                            int gr_id = int.Parse(grid[2, cell.RowIndex].Value.ToString());
                            tag.Db.ImportMark(openDlg.FileName, co_id, gr_id, int.Parse(grid.Columns[cell.ColumnIndex].HeaderText.ToString()));
                            Utility.Miscellaneous.Message("Đã nhập xong điểm vào cho lớp/giáo viên " + tag.Db.GetTip("co_id", co_id) +
                                " từ tệp: " + Environment.NewLine + openDlg.FileName);
                        }
                        //int[] co_ids = new int[grid.SelectedCells.Count];
                        //for (int i = 0; i < grid.SelectedCells.Count; i++)
                        //    try
                        //    {
                        //        co_ids[i] = (int)grid.Rows[grid.SelectedCells[i].RowIndex].Cells[0].Value;
                        //    }
                        //    catch (Exception) { continue; }
                        break;
                    case Database.Tables.Marks:                        
                        MalystManager.FormList listTe = new MalystManager.FormList();
                        listTe.grid.DataSource = tag.Db.Select("SELECT * FROM teachers");
                        listTe.grid.ReadOnly = true;
                        listTe.guide.Text = "Chọn giáo viên mà bạn muốn nhập điểm và gõ hệ số của bài làm mà bạn muốn nhập  vào ô dưới cạnh nút OK";
                        listTe.text.Text = "Hệ số";
                        if (listTe.ShowDialog() == DialogResult.OK)
                        {
                            int r = 0;
                            try { r = int.Parse(listTe.text.Text); }
                            catch (Exception)
                            {
                                Utility.Miscellaneous.ErrorMessage("Hệ số không đúng.");
                                return;
                            }
                            int te_id = (int)listTe.grid[0, listTe.grid.SelectedCells[0].RowIndex].Value;
                            OpenFileDialog openDlg2 = new OpenFileDialog();
                            openDlg2.Title = "Chon tep ket qua cua Malyst Scan";
                            openDlg2.Filter = "Kết quả chấm từ Malyst Scann *.log.xml|*.log.xml";
                            openDlg2.Multiselect = false;
                            openDlg2.SupportMultiDottedExtensions = true;
                            if (openDlg2.ShowDialog() == DialogResult.OK)
                            {
                                tag.Db.ImportMark(openDlg2.FileName, r, te_id);
                                Utility.Miscellaneous.Message("Đã nhập xong điểm vào cho giáo viên " + tag.Db.GetTip("te_id", te_id) +
                                " từ tệp: " + Environment.NewLine + openDlg2.FileName);
                                grid.DataSource = tag.Db.Select("SELECT * FROM marks");
                            }
                        }                        
                        break;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message + ex.StackTrace); }
        }

        void staticsToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                string table = tag.Db.CourseSumUp((int)grid[0, grid.SelectedCells[0].RowIndex].Value);
                if (table != string.Empty)
                {
                    ((FormMM)this.MdiParent).getCoursesSumUpViewer(table).Show();
                }
            }
            catch (Exception ex) { Utility.Miscellaneous.ErrorMessage(ex.Message); }
        }

        void testCoursesComplettion_Click(object sender, EventArgs e)
        {
            if (grid.SelectedCells.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn các BGID cần kiểm tra xem đã hoàn thành việc nhập điểm hay chưa");
                return;
            }
            int[] co_ids = new int[grid.SelectedCells.Count];
            for (int i = 0; i < grid.SelectedCells.Count; i++)
                try
                {
                    co_ids[i] = (int)grid.Rows[grid.SelectedCells[i].RowIndex].Cells[0].Value;
                }
                catch (Exception) { continue; }
            FormTableViewer ftv_cc = new FormTableViewer();
            ftv_cc.grid.AutoSize = false;            
            ftv_cc.grid.DataSource = tag.Db.CoursesCompletionDataTable(co_ids);
            ftv_cc.grid.DataMember = "";            
            ftv_cc.grid.GridColor = Color.SkyBlue;
            ftv_cc.MdiParent = this.MdiParent;
            ftv_cc.Text = "CC";
            ftv_cc.grid.ReadOnly = true;            
            ftv_cc.Show();
            
        }
        int id_selected = -1;
        void dropdown_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            id_selected = (int)(e.ClickedItem.Tag);
            dropdown.Text = e.ClickedItem.Text;
            grid_refresh();
        }
        bool markFullView = false;
        private void grid_refresh()
        {
            try
            {
                switch (tag.Table)
                {
                    case Database.Tables.Teachers:
                        grid.DataSource = tag.Db.Select("SELECT * FROM teachers");
                        break;
                    case Database.Tables.Groups:
                        grid.DataSource = tag.Db.Select("SELECT * FROM groups");
                        break;
                    case Database.Tables.Students:
                        grid.DataSource = tag.Db.Select("SELECT * FROM students WHERE gr_id = " + id_selected);
                        break;
                    case Database.Tables.Marks:
                        if (markFullView)
                            grid.DataSource = tag.Db.Select
                                ("SELECT marks.co_id,marks.st_id, students.name AS [Học sinh], marks.mark, marks.r, marks.date " +
                                 "FROM marks,students WHERE marks.st_id = students.st_id");
                        else
                            grid.DataSource = tag.Db.Select
                                ("SELECT * FROM marks WHERE co_id=" + id_selected + " ORDER BY st_id ASC, r ASC");
                        break;
                    case Database.Tables.Courses:
                        switch (id_selected)
                        {
                            case 1:
                                grid.DataSource = tag.Db.Select
                                        ("SELECT courses.co_id,teachers.name AS [Thầy cô],courses.gr_id, courses.name ," +
                                        "courses.r1,courses.r2,courses.r3,courses.rx FROM courses, teachers " +
                                        "WHERE courses.te_id = teachers.te_id ORDER BY courses.te_id");
                                break;
                            case 2:
                                grid.DataSource = tag.Db.Select
                                        ("SELECT courses.co_id,groups.name AS [Lớp],courses.te_id, courses.name ," +
                                        "courses.r1,courses.r2,courses.r3,courses.rx FROM courses, groups " +
                                        "WHERE (courses.gr_id = groups.gr_id) ORDER BY groups.name");
                                break;
                            case 3:
                                grid.DataSource = tag.Db.Select
                                        ("SELECT courses.co_id,groups.name AS [Lớp],courses.te_id, courses.name ," +
                                        "courses.r1,courses.r2,courses.r3,courses.rx FROM courses, groups " +
                                        "WHERE (courses.gr_id = groups.gr_id) ORDER BY courses.name");
                                break;
                        }
                        break;
                }
                grid_ScrollToLast();
            }
            catch (Exception ex) { }
        }
        private void grid_ScrollToLast()
        {
            grid.FirstDisplayedScrollingRowIndex = grid.RowCount - 1;
        }

        private void checkAddNew_CheckedChanged(object sender, EventArgs e)
        {
            grid.AllowUserToAddRows = checkAdd.Checked;
        }

        private void checkDelete_CheckedChanged(object sender, EventArgs e)
        {
            grid.AllowUserToDeleteRows = checkDelete.Checked;
        }

        private void checkUpdate_CheckedChanged(object sender, EventArgs e)
        {
            grid.ReadOnly = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            errorProvider.Clear();
            timer1.Enabled = false;
        }

        int last_no = 0;
        int last_r = 1;
        int last_te = 0;
        int last_gr = 0;
        private void textInfo_Leave(object sender, EventArgs e)
        {
            if (textInfo.Text == string.Empty) return;
            FormTableViewerTag tag = this.Tag as FormTableViewerTag;
            SqlCeCommand cmd = new SqlCeCommand();
            if (tag == null) return;
            string[] p = null;            
            if (textInfo.Text.IndexOf(',') == -1) 
                p = new string[] { textInfo.Text };
            else p = textInfo.Text.Split(',');
            try
            {
                switch (tag.Table)
                {
                    case Database.Tables.Groups:
                        if (p.Length == 2)
                        {
                            tag.Db.SelectNonQuery("INSERT INTO groups (gr_id, name) VALUES(" + p[0] + ",'" + p[1] + "')");
                        }
                        break;
                    case Database.Tables.Students:
                        if (p.Length >= 1 && id_selected != -1)
                        {                            
                                tag.Db.SelectNonQuery
                                    (string.Format("INSERT INTO students (name,gr_id,birth) VALUES('{0}',{1},'{2}')",
                                    Utility.Miscellaneous.ValidName(p[0]), id_selected, p.Length == 2 ? p[1] : ""));                                                      
                        }
                        break;
                    case Database.Tables.Marks:
                        if (p.Length >= 1)
                        {
                            if (id_selected == -1)
                            {
                                MessageBox.Show("Vui lòng chọn một \"mục báo giảng\" trước khi nhập điểm.");
                                return;
                            }
                            double mark = double.Parse(p[0]);
                            if (mark > 10) mark = mark / 10;
                            
                            if (p.Length >= 2) last_no = int.Parse(p[1]) - 1;
                            else last_no++;
                            cmd.Connection = tag.Db.Connection;
                            cmd.CommandText = "SELECT courses.gr_id FROM courses WHERE courses.co_id = " + id_selected;
                            int gr_id = (int)cmd.ExecuteScalar();
                            int st_id =  tag.Db.GetStudentId(gr_id,last_no + 1);
                            cmd.CommandText =
                                string.Format("INSERT INTO marks (co_id,st_id,r,mark,date) VALUES({0},{1},{2},{3},'{4}')",
                                id_selected, 
                                st_id, 
                                (p.Length == 3) ? last_r = int.Parse(p[2]) : last_r, mark,
                                DateTime.Today.ToString("dd-MM-yyyy"));
                            ((FormMM)this.MdiParent).statusText.Text = "Bạn vừa vào điểm cho:  " + tag.Db.GetTip("st_id", st_id).TrimEnd();
                            cmd.ExecuteNonQuery();                            
                        }
                        break;
                    case Database.Tables.Teachers:

                        if (p.Length >= 1)
                        {
                            string name = Utility.Miscellaneous.ValidName(p[0]);
                            string subject = p.Length == 2? p[1]:string.Empty;
                            Database.SUBJECTS_ABBR abbr;
                            try
                            {
                                abbr = (Database.SUBJECTS_ABBR)
                                    Enum.Parse(Database.SUBJECTS_ABBR.NONE.GetType(), subject, true);
                                subject = Database.subjects[(int)abbr];
                            }
                            catch (ArgumentException) { abbr = Database.SUBJECTS_ABBR.NONE; subject = string.Empty; };
                            tag.Db.SelectNonQuery("INSERT INTO teachers(name, subject) VALUES ('"
                                + name + "','" + subject + "')");
                        }                            
                        break;
                    case Database.Tables.Courses:
                        break;
                }
                textInfo.Text = string.Empty;
                textInfo.Focus();
                grid_refresh();
            }
            catch (Exception ex) { System.Media.SystemSounds.Exclamation.Play(); }
            
        }

        private void textInfo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textInfo_Leave(null, null);
            }
        }

        private void grid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {            
            try
            {
                if (e.RowIndex == -1 || e.ColumnIndex == -1) return;
                // Đệm thông tin hay không ở chỗ này
                //if (grid[e.ColumnIndex, e.RowIndex].ToolTipText != string.Empty) return;
                if (grid.Columns[e.ColumnIndex].Name.Contains("id")
                    && grid.Columns[e.ColumnIndex].Name.Substring(0, 2).ToUpper() != tag.Table.ToString().Substring(0, 2).ToUpper())
                {

                    grid[e.ColumnIndex, e.RowIndex].ToolTipText = Environment.NewLine +
                        tag.Db.GetTip(grid.Columns[e.ColumnIndex].Name,
                        (int)grid[e.ColumnIndex, e.RowIndex].Value);
                }
            }
            catch (Exception ex) { }
        }

        private void grid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void reorderButton_Click_1(object sender, EventArgs e)
        {                       
        }

        private void grid_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            e.SortResult = e.CellValue1.ToString().CompareTo(e.CellValue2.ToString());
        }

        private void grid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {            
        }

        private void grid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!checkDeleteWithoutAsking.Checked)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa dòng dữ liệu này?", "",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    e.Cancel = true;
                else e.Cancel = false;
            }
        }

        private void FormTableViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (grid.DataSource is SqlCeResultSet)
                ((SqlCeResultSet)grid.DataSource).Dispose();
            if (!Disposing)
                Dispose(true);
        }

        private void FormTableViewer_Activated(object sender, EventArgs e)
        {
            if (_MMHostForm != null) _MMHostForm._MMActiveForm = this;
        }

        private void checkColumnsResize_CheckedChanged(object sender, EventArgs e)
        {
            if (checkColumnsResize.Checked)
                grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            else
                grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            grid.Invalidate();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(toolTipText);
        }
    }
    public class FormTableViewerTag
    {
        Database db;

        public Database Db
        {
            get { return db; }
            set { db = value; }
        }
        GiangManh.MM.Database.Tables table;

        public GiangManh.MM.Database.Tables Table
        {
            get { return table; }
            set
            {
                table = value;
                
            }
        }
        public string expand;
        public FormTableViewerTag(Database db, Database.Tables table)
        {
            this.db = db;
            this.Table = table;
        }
    }
}
