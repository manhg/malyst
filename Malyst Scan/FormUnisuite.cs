using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class FormUnisuite : Form
    {
        static public bool HasInstanced = false;
        public FormUnisuite()
        {
            InitializeComponent();
            HighlightColor = Color.FromArgb(234, 234, 243);
            HasInstanced = true;
            this.Tag = new System.Collections.Hashtable();
        }

        private void FormUnisuite_Load(object sender, EventArgs e)
        {
            PopululateGrid();            
        }
        /// <summary>
        /// Đặt các keysuite vào grid
        /// </summary>
        private void PopululateGrid()
        {
            gridUnisuite.ClearSelection();
            gridUnisuite.Rows.Clear();
            for (int i = 0; i < Core.Ref.UniSuite.Count; i++)
            {
                gridUnisuite_CreateRow(i, Core.Ref.UniSuite[i]);
            }
        }
        Color HighlightColor;
        private void gridUnisuite_CreateRow(int index,Core.KeySuite suite)
        {
            
            DataGridViewRow row = new DataGridViewRow();
            if (index % 2 == 1) row.DefaultCellStyle.BackColor = HighlightColor;
            //StringBuilder description = new StringBuilder(string.Format("Số đề: {0}. Các mã: ", suite.Items.Length),1000);
            ////string date = "";
            //if (suite.Items.Length == 0) return;
            ////else date = suite.Items[0].date.ToString("dd/MM/yyyy hh:mm");
            //foreach (Core.Key key in suite.Items)
            //    description.AppendFormat("{0}, ", key.problem);
            row.CreateCells(gridUnisuite, suite.name,suite.ToString());
            row.Tag = index;
            gridUnisuite.ClearSelection();
            gridUnisuite.Rows.Add(row);
            row.Selected = true;
        }

        private void toolBtnSelect_Click(object sender, EventArgs e)
        {
            if (gridUnisuite.SelectedRows != null)
                Core.Ref.UniSuite.ActiveSuiteIndex = (int)gridUnisuite.SelectedRows[0].Tag;
            ((FormMain)this.MdiParent).toolStatusText.Text = 
                string.Format("Đã chọn bộ đáp án: {0}", Core.Ref.UniSuite.ActiveSuite.name);
            this.DialogResult = DialogResult.OK;            
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            ((FormMain)this.MdiParent).mnuItemFileNewSuite.PerformClick();
            PopululateGrid();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            ((FormMain)this.MdiParent).mnuFileOpen.PerformClick();
            PopululateGrid();
        }

        private void FormUnisuite_FormClosing(object sender, FormClosingEventArgs e)
        {            
            HasInstanced = false;
        }

        private void gridUnisuite_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            toolBtnSelect.PerformClick();
            this.Close();
        }

		private void toolMoreInfo_Click(object sender, EventArgs e)
		{
			if (gridUnisuite.SelectedRows.Count != 0 &&
				gridUnisuite.SelectedRows[0].Tag != null)
			{
				int i = (int)gridUnisuite.SelectedRows[0].Tag;
				Core.KeySuite suite = Core.Ref.UniSuite[i];
				StringBuilder s = new StringBuilder();
				s.AppendLine(suite.ToString());
				foreach(Core.Key k in suite.Items)
				{
					s.AppendFormat("{2} Đề: {0}, đáp án: {1} {2}", 
						k.problem, Core.Utility.ClearLook(k.key), Environment.NewLine);
				}
				Core.Utility.Msg(s.ToString());
			}
		}
    }
}
