using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MalystManager
{
    interface ISearchtable
    {
        DataGridView IGrid { get; set; }
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //try
            //{
                //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("vi-VN");
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("vi");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new GiangManh.MM.FormMM());
            //} catch (Exception  ex) {MessageBox.Show(ex.Message + "\n"  + ex.Source  + "\n" + ex.StackTrace);}
        }
    }
}
