using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class FormR : Form
    {
        public FormR()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked &&
                Core.Utility.Test(textBox1.Text + "K9A" + DateTime.Today.ToString("yyyy-MM-dd"),
                textBox2.Text.Trim().ToUpper()))
            {
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("Cảm ơn đã sử dụng sản phẩm này.");
            }
            else this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
