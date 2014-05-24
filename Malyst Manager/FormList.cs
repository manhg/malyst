using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MalystManager
{
    public partial class FormList : Form
    {
        public FormList()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (grid.SelectedCells.Count != 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else GiangManh.Utility.Miscellaneous.Message("Vui lòng chọn ít nhất một lựa chọn.");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void text_Enter(object sender, EventArgs e)
        {
            text.Text = "";
        }
    }
}
