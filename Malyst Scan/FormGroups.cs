using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Text.RegularExpressions;


namespace UI
{
    public partial class FormGroups : Form
    {
        public static bool hasInstance;
        public FormGroups()
        {
            hasInstance = true;
            InitializeComponent();
            this.Tag = new Hashtable();
        }

        private void FormGroups_Load(object sender, EventArgs e)
        {
            // Thêm vào menu Window cửa sổ này
            //ToolStripMenuItem mnuItemWindowGroup = new ToolStripMenuItem();
            //mnuItemWindowGroup.Text = "Lớp học";
            //mnuItemWindowGroup.ShortcutKeys = (Keys)(Keys.Alt | Keys.F7);
            //mnuItemWindowGroup.ShowShortcutKeys = true;           
            //mnuItemWindowGroup.Click += new EventHandler(mnuItemWindowGroup_Click);
            //MenuStrip menuAll = (MenuStrip)this.MdiParent.MainMenuStrip;
            //ToolStripMenuItem mnuWindow = (ToolStripMenuItem)menuAll.Items["mnuWindow"];
            //((Hashtable)this.Tag).Add("WindowIndex", mnuWindow.DropDownItems.Add(mnuItemWindowGroup));

            // Đưa danh sách lớp vào grid
            for (int i = 0; i < Core.Ref.UniGroup.Items.Length; i++)
            {
                Core.Group g = Core.Ref.UniGroup.Items[i];
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(gridGroup, g.name, g.code);
                row.Tag = i; // chứa index của lớp trong UniGroup                                
                gridGroup.Rows.Add(row);
            }
            // Tag của grid sẽ chứa những group thêm và sửa đổi cùng trạng thái
            gridGroup.Tag = -1;
        }

        void mnuItemWindowGroup_Click(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void FormGroups_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormGroups.hasInstance = false;
            if (Core.Utility.Confirm("Bạn có muốn lưu những thay đổi không?") == DialogResult.No)
            {
                // Nạp lại dữ liệu đã lưu
                Core.Program.LoadGroup();
            }
            else
            {
                toolSave.PerformClick();
            }            
        }
        /// <summary>
        /// Hiển thị danh sách lớp tương ứng khi chọn một lớp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridGroup_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            object index = gridGroup.Rows[e.RowIndex].Tag;            
            gridStudent.Rows.Clear();
            if (index == null)
            {
                // Đây là ô trống để thêm bản ghi mới

                gridGroup.Tag = -1;
                return;
            }
            gridGroup.Tag = index;
            Core.Group g = Core.Ref.UniGroup.Items[(int)index];
            for (int i = 0; i < g.Items.Length; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(gridStudent, g.Items[i].no, g.Items[i].name);
                row.Tag = i;
                gridStudent.Rows.Add(row);

            }
        }

        private void gridStudent_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            switch (e.Column.Name)
            {
                case "colStudentName":
                    char[] separator = { ' ' };
                    string[] name1Split = ((string)e.CellValue1).Split(separator);
                    string name1 =
                        (name1Split.Length == 0) ?
                        (string)e.CellValue1
                        : name1Split[name1Split.Length - 1];
                    string[] name2Split = ((string)e.CellValue2).Split(separator);
                    string name2 =
                        (name2Split.Length == 0) ?
                        (string)e.CellValue2
                        : name2Split[name2Split.Length - 1];
                    e.SortResult = string.Compare(name1, name2);
                    break;
                case "colStudentNo":
                    e.SortResult = Math.Sign((int)e.CellValue1 - (int)e.CellValue2);
                    break;
            }
        }

        private void txtStudentName_Leave(object sender, EventArgs e)
        {
            txtStudentName.Text = Core.Utility.ValidName(txtStudentName.Text);
        }

        private void checkDirectChange_CheckedChanged(object sender, EventArgs e)
        {
            gridStudent.ReadOnly = !checkDirectChange.Checked;
            gridGroup.ReadOnly = !checkDirectChange.Checked;            
        }
        /// <summary>
        /// Xác nhận người dùng có phải muốn xóa không.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridGroup_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (Core.Utility.Confirm(string.Format(
                    "Bạn có chắc chắn chắn muốn xóa bỏ lớp:{0} *{1} có mã {2}* không?",
                    Environment.NewLine,
                    gridGroup[e.Row.Index, 0].Value, gridGroup[e.Row.Index, 0].Value))
                == DialogResult.No)
                e.Cancel = true;
            else
            {
                if (gridGroup.Rows[e.Row.Index].Tag == null) return;
                int gi = (int)gridGroup.Rows[e.Row.Index].Tag;

            }
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            if (txtGroupName.Text != "")
            {
                txtGroupName.Focus();
                string name = txtGroupName.Text;
                int code = Core.Group.GenerateCode(name);
                if (code == -1)
                {
                    Core.Utility.Msg("Tên lớp " + name + "không hợp lệ.");
                    return;
                }
                int index = Core.Ref.UniGroup.AddItem(new Core.Group(name, code));

                row.CreateCells(gridGroup, name, code);
                row.Tag = index;
                gridGroup.Rows.Add(row);
                txtGroupName.Text = "";
            }
            if (txtStudentName.Text != "")
            {
                txtStudentName.Focus();
                int grpIndex = (int)gridGroup.Tag;
                if (grpIndex == -1)
                {
                    Core.Utility.Msg("Vui lòng chọn một lớp trước khi nhập danh sách học sinh.");
                    return;
                }
                Core.Group g = Core.Ref.UniGroup.Items[grpIndex];
                Core.Student s = new Core.Student(g.Items.Length + 1, Core.Utility.ValidName(txtStudentName.Text));
                row.Tag = g.AddItem(s);
                row.CreateCells(gridStudent, s.no, s.name);
                int index = gridStudent.Rows.Add(row);
                gridStudent.ClearSelection();
                int oldGridHeight = gridStudent.Height;                
                gridStudent.Height = 2 * 22;
                gridStudent.FirstDisplayedScrollingRowIndex = index;
                gridStudent.Height = oldGridHeight;
                txtStudentName.Text = "";
            }
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            Core.Utility.XmlSerialize(UI.Properties.Settings.Default.GroupsFile, Core.Ref.UniGroup,
                Core.Utility.MyXmlFileType.Groups,
                ((FormMain)this.MdiParent).toolProgressStrip,
                ((FormMain)this.MdiParent).toolStatusText);
        }

        private void toolClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pseudoSave_Click(object sender, EventArgs e)
        {
            toolAdd.PerformClick();
        }

        private void toolAutotext_Click(object sender, EventArgs e)
        {
            gridStudent.FirstDisplayedCell = gridStudent[0, 2];
            //gridStudent.PerformLayout();
        }

        private void txtStudentName_TextChanged(object sender, EventArgs e)
        {

        }

        private void gridGroup_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!gridGroup.IsCurrentCellInEditMode) return;
            if (e.RowIndex != -1)
            {
                try
                {
                    DataGridViewRow row = gridGroup.Rows[e.RowIndex];
                    int index = (int)row.Tag;
                    Core.Ref.UniGroup.Items[index].code = int.Parse(row.Cells[1].Value.ToString());
                    Core.Ref.UniGroup.Items[index].name = row.Cells[0].Value.ToString();
                }
                catch (Exception) { }
            }
        }

        private void gridStudent_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!gridStudent.IsCurrentCellInEditMode) return;
            if (e.RowIndex != -1)
            {
                try
                {
                    int gr_index = (int)gridGroup.Tag;
                    DataGridViewRow row = gridStudent.Rows[e.RowIndex];
                    
                    int st_index = (int)row.Tag;
                    Core.Ref.UniGroup.Items[gr_index].Items[st_index].no = int.Parse(row.Cells[0].Value.ToString());
                    Core.Ref.UniGroup.Items[gr_index].Items[st_index].name = row.Cells[1].Value.ToString();
                }
                catch (Exception) { }
            }
        }
    }
}
