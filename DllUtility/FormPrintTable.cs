using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Threading;

namespace GiangManh.Utility
{
    public partial class FormPrintTable : Form
    {
        Utility.PrintTable printTable;
        public FormPrintTable()
        {
            InitializeComponent();
            printTable = new PrintTable();
            this.printPreview.Document = printTable.doc;
        }

        private void zoom_Scroll(object sender, EventArgs e)
        {
            printPreview.Zoom = zoom.Value / 100.0;
            label5.Text = zoom.Value + "%";
        }
        public PrintDocument Document
        {
            set { printPreview.Document = value; }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            printDlg.AllowCurrentPage = false;
            printDlg.Document = printTable.doc;
            printDlg.UseEXDialog = true;
            if (printDlg.ShowDialog() == DialogResult.OK)
            {                
                Thread thread = new Thread(new ThreadStart(thread_Printing));
                thread.Name = DateTime.Now.ToString("dd-MM-yyyy hhmmss");
                thread.IsBackground = true;
                thread.Priority = ThreadPriority.BelowNormal;
                thread.Start();
            }
        }
        private void thread_Printing()
        {
            printTable.doc.Print();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                printTable.font = new Font(comboBox1.Text, 11);
                txtCenter.Font = printTable.font ;
                txtLeft.Font = printTable.font;
            }
            catch (Exception) { }
        }

    }
}
