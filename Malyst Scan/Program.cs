/*
 * Mục đích: chứa các lệnh entry vào chương trình.
 * Đọc các dữ liệu cần thiết, khởi động giao diện đồ họa.
 */

using System;
using System.Collections.Generic;
using System.Collections;
using System.Windows.Forms;

namespace Core
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                // Cho phép điều chỉnh dữ liệu liên thread
                Control.CheckForIllegalCrossThreadCalls = false;

                // Khởi tạo
                Core.Ref.UniGroup = new Core.Groups();
                Core.Ref.UniSuite = new Core.SuiteList();
                // Đọc dữ liệu trong lần làm việc trước
                LoadGroup();
                LoadSuite();
                // Chạy UI
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new UI.FormMain());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message + "\n" + ex.Source + "\n" + ex.StackTrace); }
        }
		static void CoreMsg_Handler(object sender, EventArgs e)
		{
		}
        /// <summary>
        /// Nạp danh sách lớp/HS
        /// </summary>
        public static void LoadGroup()
        {
            object obj1;
            if (System.IO.File.Exists(UI.Properties.Settings.Default.GroupsFile))
            {
                Core.Utility.XmlDeserialize(UI.Properties.Settings.Default.GroupsFile, out obj1, Core.Utility.MyXmlFileType.Groups, null, null);
                if (obj1 != null) Core.Ref.UniGroup = (Core.Groups)obj1;
            }
        }
        /// <summary>
        /// Nạp các bộ đáp án được lưu
        /// </summary>
        public static void LoadSuite()
        {
            object obj2;
            if (System.IO.File.Exists(UI.Properties.Settings.Default.SuiteFile))
            {
                Core.Utility.XmlDeserialize(UI.Properties.Settings.Default.SuiteFile, out obj2, Core.Utility.MyXmlFileType.KeySuite, null, null);
                if (obj2 != null) Core.Ref.UniSuite = (Core.SuiteList)obj2;
            }
        }

    }
}
