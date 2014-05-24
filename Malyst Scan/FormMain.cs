using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Microsoft.Win32;
using System.IO;

namespace UI
{
   
    public partial class FormMain : Form
    {
        public static int ActiveKeysuiteIndex = -1;       
        public FormMain()
        {
            InitializeComponent();			
        }

        private void mnuItemFileNewSuite_Click(object sender, EventArgs e)
        {
            FormNewsuite formNewSuite = new FormNewsuite();
            formNewSuite.MdiParent = this;
            AddWindowMenuItem(formNewSuite, "Tao bo dap an " + FormNewsuite.Instance);
            formNewSuite.Show();			
        }

        private void mnuItemFileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuItemGroup_Click(object sender, EventArgs e)
        {
            if (!FormGroups.hasInstance)
            {
                FormGroups formGroup = new FormGroups();
                formGroup.MdiParent = this;
                AddWindowMenuItem(formGroup, "Quản lý lớp học");
                formGroup.Show();
            }
        }

        private void mnuRecognizeFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                FormInterpret formInterpret = new FormInterpret();
                formInterpret.MdiParent = this;
                Hashtable tag = (Hashtable)formInterpret.Tag;
                tag.Add(TagKeys.AutomateSource,Core.Automate.Source.Folder);
                tag.Add(TagKeys.Caption, "Chấm điểm thư mục " + folderBrowserDialog.SelectedPath);
                tag.Add(TagKeys.Path, folderBrowserDialog.SelectedPath);
                AddWindowMenuItem(formInterpret, (string)tag[TagKeys.Caption]);
                formInterpret.Show();
            }
        }
        private void mnuRecognizeG2Folder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                FInterpretG2 formInterpret = new FInterpretG2();
                formInterpret.MdiParent = this;
                Hashtable tag = (Hashtable)formInterpret.Tag;
                tag.Add(TagKeys.AutomateSource, Core.Automate.Source.Folder);
                tag.Add(TagKeys.Caption, "Chấm điểm thư mục " + folderBrowserDialog.SelectedPath);
                tag.Add(TagKeys.Path, folderBrowserDialog.SelectedPath);
                AddWindowMenuItem(formInterpret, (string)tag[TagKeys.Caption]);
                formInterpret.Show();
            }
        }
        /// <summary>
        /// Chuẩn bị hộp thoại để chọn file nhận dạng
        /// </summary>
        private void PrepareFileDlg2Interpret()
        {
            openFileDialog.Filter = "Ảnh quét được từ scanner (*.bmp,*.jpg, *.tif)|*.bmp;*.jpg;*.tif;*.tiff";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
            openFileDialog.Multiselect = true;
            openFileDialog.Title = "Chọn ảnh quét (1 hoặc nhiều file)";
        }

        private void mnuRecognizeFile_Click(object sender, EventArgs e)
        {
            PrepareFileDlg2Interpret();
            if (openFileDialog.ShowDialog() == DialogResult.OK && openFileDialog.FileNames.Length >=1)
            {
                FormInterpret formInterpret = new FormInterpret();
                formInterpret.MdiParent = this;
                Hashtable tag = (Hashtable)formInterpret.Tag;
                tag.Add(TagKeys.AutomateSource,Core.Automate.Source.Files);
                string[] fileNames = openFileDialog.FileNames;
                string[] safeFileName = new string[fileNames.Length];
                for (int i = 0; i < fileNames.Length; i++)
                {
                    safeFileName[i] = Core.Utility.GetSafeFileName(fileNames[i]);
                }
                formInterpret.txtLog.AppendText(string.Join(Environment.NewLine, safeFileName));
                tag.Add(TagKeys.Caption, "Cham diem:  "+ string.Join(",",safeFileName));
                tag.Add(TagKeys.Files, fileNames);
                AddWindowMenuItem(formInterpret, (string)tag[TagKeys.Caption]);
                formInterpret.Show();
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
        private void mnuFileClose_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
        }

        private void mnuWindowCascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void mnuWindowTileVertical_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void mnuWindowTileHorizonal_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }
        private void AddWindowMenuItem(Form form, string caption)
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem(caption);
            menuItem.Tag = form;
            menuItem.Click += new EventHandler(menuItem_Click);
            mnuWindow.DropDownItems.Add(menuItem);
            Hashtable h = (Hashtable)form.Tag;
            h.Add(TagKeys.MenuEntry, menuItem);
            form.FormClosing += new FormClosingEventHandler(RemoveWindowMenuItem);
        }

        void RemoveWindowMenuItem(object sender, FormClosingEventArgs e)
        {
            Hashtable tag = (Hashtable)(((Form)sender).Tag);
            ((ToolStripItem)(tag[TagKeys.MenuEntry])).Dispose();
        }
        /// <summary>
        /// Khi click vào Entry Item trong menu Window, cửa sổ tương ứng
        /// sẽ được activate bằng Focus và đưa cửa sổ ra góc trái trên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void menuItem_Click(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Tag != null)
            {
                Form f = ((ToolStripMenuItem)sender).Tag as Form;
                f.Focus();
                f.Top = 0;
                f.Left = 0;
            }
        }
        /// <summary>
        /// Đóng tất cả các cửa sổ MDI child lại
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuFileCloseAll_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form != null) form.Close();
            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            mnuItemFileNewSuite.PerformClick();
        }
        /// <summary>
        /// Mở cửa sổ chọn bộ đáp án/ đáp án để chấm
        /// Index của suite được nạp sẽ lưu vào tag của mnuFileOpen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = UI.Properties.Settings.Default.KeyFileFilter;
            openFileDialog.Title = "Nạp bộ đáp án để chấm điểm";
            openFileDialog.FileName = "";            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Core.KeySuite keys;
                object _keys;
                Core.Utility.XmlDeserialize(openFileDialog.FileName, out _keys, 
                    Core.Utility.MyXmlFileType.KeySuite,
                    toolProgressStrip, toolStatusText);
                keys = _keys as Core.KeySuite;
                if (keys == null)
                {
                    Core.Utility.Error(string.Format(
                        "Tệp {0} không đọc được. Có thể nội dung đã bị hỏng. Chi tiết: {1}",
                        openFileDialog.FileName));
                    mnuFileOpen.Tag = null;
                    return;
                }
                if (Core.Ref.UniSuite.Contains(keys.name))
                {
                    Core.Utility.Msg(string.Format("Đáp án về: {0} đã được nạp trước đó.", keys.name));
                    mnuFileOpen.Tag = null;
                    return;
                }
                else
                {
                    // Tag của menu này chứa index trong Core.Ref.Unisuite
                    // của bộ đáp án mới được nạp. Dùng để truyền cho các cửa sổ khác
                    mnuFileOpen.Tag = Core.Ref.UniSuite.Add(keys);
                    Core.Ref.UniSuite.ActiveSuiteIndex = (int)mnuFileOpen.Tag;
                    toolStatusText.Text = "Đã nạp: " + Core.Ref.UniSuite.ActiveSuite.ToString();
                }
                //// Lưu thiết lập lại
                //Core.Utility.XmlSerialize(UI.Properties.Settings.Default.SuiteFile,
                //    Core.Ref.UniSuite, Core.Utility.MyXmlFileType.KeySuite);
            }
        }
        /// <summary>
        /// Mở menu thả xuống chứa danh sách các bộ đáp án đã được nạp
        /// nếu của sổ đang chọn là một Interpret form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolDropUnisuite_Click(object sender, EventArgs e)
        {
            mnuRecognizeBrowseSuite.PerformClick();
            //toolDropUnisuite.DropDownItems.Clear();
            //// 2: một là dest, hai là separator
            //ToolStripItem[] items;
            //ToolStripMenuItem dest;
            //if (this.ActiveMdiChild is FormInterpret)
            //{
            //    items = new ToolStripItem[Core.Ref.UniSuite.Count + 2];
            //    dest = new ToolStripMenuItem(
            //       string.Format("Chuyển tới: {0}", this.ActiveMdiChild.Text));
            //    ToolStripSeparator separator = new ToolStripSeparator();
            //    items[1] = separator;
            //    for (int i = 0; i < Core.Ref.UniSuite.Count; i++)
            //    {
            //        ToolStripMenuItem item = new ToolStripMenuItem(
            //            ((Core.KeySuite)Core.Ref.UniSuite[i]).name);
            //        //item.CheckOnClick = true;
            //        //item.CheckState = CheckState.Indeterminate;
            //        //item.CheckStateChanged += new EventHandler(item_CheckStateChanged);
            //        //if (i == FormMain.ActiveKeysuiteIndex) item.Checked = true;
            //        item.Tag = i;
            //        item.Click += new EventHandler(item_Click);
            //        items[i + 2] = item;
            //    }
            //}
            //else
            //{
            //    items = new ToolStripItem[1];
            //    dest = new ToolStripMenuItem("Hãy mở một cửa sổ chấm điểm trước.");
            //}
            //dest.Enabled = false;
            //items[0] = dest;
            //toolDropUnisuite.DropDownItems.AddRange(items);
            //toolDropUnisuite.ShowDropDown();
        }
        /// <summary>
        /// Xảy ra khi mục chọn trong DropDownUnisuite thay đổi
        /// Mục đích: gán vào Tag của FormMain bộ suite đang được chọn để sử dụng cho nhận dạng.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void item_CheckStateChanged(object sender, EventArgs e)
        {
            FormMain.ActiveKeysuiteIndex = (int)(((ToolStripMenuItem)sender).Tag);
        }

        void item_Click(object sender, EventArgs e)
        {
            Hashtable tag = (Hashtable)this.ActiveMdiChild.Tag;
            Core.KeySuite suite;
            if (tag.ContainsKey(TagKeys.KeySuite))
            {
                suite = Core.Ref.UniSuite[(int)tag[TagKeys.KeySuite]] as Core.KeySuite;
                DialogResult replace = Core.Utility.Confirm(string.Format(
                    "Trong cửa sổ: '{0}'" + Environment.NewLine
                    + "đã nhận chấm dựa trên bộ đáp án: '{1}'." + Environment.NewLine
                    + "Bạn có muốn thay thế bằng bộ đáp án mới chọn: '{2}' không?",
                    this.ActiveMdiChild.Text,
                    suite.name,
                    ((ToolStripMenuItem)sender).Text));
                if (replace == DialogResult.OK)
                {
                    tag[TagKeys.KeySuite] = (int)(((ToolStripMenuItem)sender).Tag);
                }
                else return;
            }
            else
            {
                tag.Add(TagKeys.KeySuite,(int)((ToolStripMenuItem)sender).Tag);
            }
            suite = Core.Ref.UniSuite[(int)tag[TagKeys.KeySuite]] as Core.KeySuite;
            FormInterpret form = this.ActiveMdiChild as FormInterpret;
            form.txtLog.AppendText(Environment.NewLine + 
                "Bộ đáp án được chọn: " + suite.ToString());
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            mnuFileOpen.PerformClick();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {            
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.Text = "Malyst Scan - Cham trac nghiem tu dong - K9A ® 2008 v." + Application.ProductVersion;
            this.Hide();
            FormR r = new FormR();
            try
            {                                
                object f = Registry.GetValue("HKEY_CLASSES_ROOT\\mgd", "", 0);
                if (f == null || f.ToString() != "120401081989")
                {
                    if (r.ShowDialog() == DialogResult.OK)
                    {
                        this.Show();                        
                        RegistryKey k = Registry.ClassesRoot.CreateSubKey("mgd");
                        k.SetValue("", 120401081989);

                    }
                    else
                    {
                        this.Close();
                    }
                }
                else this.Show();
            }
            catch (Exception) { Core.Utility.Error("Không thể đăng ký trên hệ điều hành: " + Environment.OSVersion.ToString()); }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void mnuWindowAssistant_CheckStateChanged(object sender, EventArgs e)
        {
            if (mnuWindowAssistant.Checked)
            {
                FormAssistant formAssistant = new FormAssistant();
                formAssistant.MdiParent = this;
                formAssistant.Left = this.Width - formAssistant.Width - 25;
                formAssistant.Top = 15;
                formAssistant.Show();
                mnuWindowAssistant.Tag = formAssistant;
            }
            else
            {
                if (mnuWindowAssistant.Tag != null)
                {
                    ((Form)mnuWindowAssistant.Tag).Close();
                }
                else
                {
                    MessageBox.Show("Cửa sổ đã đóng hoặc thoát không đúng cách.");
                }
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {

            mnuFileSave.PerformClick();
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            mnuFilePrint.PerformClick();
        }        
        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
			if (this.ActiveMdiChild is FormInterpret)
			{
				
			}
        }
        private void PutLine(Graphics g, Core.Discover d, PointF topleft)
        {
            int[] space = { 1, 2, 3, 4, 8 };
            int ratio = 100;
            PointF[] pace=new PointF[space.Length];
            for (int i = 0; i < space.Length; i++)
            {
                space[i] *= ratio;
                pace[i] = new PointF(space[i] + topleft.X , topleft.Y);
            }
            Put2Point(g, d.student.ToString(), pace[0]);
            Put2Point(g, d.problem.ToString(), pace[1]);
            Put2Point(g, d.mark.ToString(), pace[2]);
            Put2Point(g, d.group.ToString(), pace[3]);
        }
        private void Put2Page(Graphics g, string s, RectangleF bound)
        {
            g.DrawString(s, UI.Properties.Settings.Default.DefaultPrintFont, Brushes.Black, bound);
        }
        private void Put2Page(Graphics g, string s, RectangleF bound,StringFormat format)
        {
            g.DrawString(s, UI.Properties.Settings.Default.DefaultPrintFont, Brushes.Black, bound,format);
        }
        private void Put2Point(Graphics g, string s,PointF place)
        {
            g.DrawString(s, UI.Properties.Settings.Default.DefaultPrintFont, Brushes.Black, place);
        }
        private Size Measure(Graphics g, string s)
        {
            return g.MeasureString(s, Properties.Settings.Default.DefaultPrintFont).ToSize();
        }

        private void mnuFilePrint_Click(object sender, EventArgs e)
        {
            
        }

        private void printDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            
        }

        private void mnuFilePrintSetting_Click(object sender, EventArgs e)
        {
            pageSetupDialog.EnableMetric = true;
            if (pageSetupDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.PrinterSettings = pageSetupDialog.PrinterSettings;                
            }

        }

        private void mnuDataRotate90CWSplitVertical_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = UI.Properties.Settings.Default.ImageFileFilter;
            openFileDialog.Title = "Dữ liệu quét cần quay 90CW và cắt đôi theo chiều dọc";
            openFileDialog.Multiselect = true;
            openFileDialog.AddExtension = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string path = System.IO.Directory.GetParent(openFileDialog.FileNames[0]).ToString() + "\\RS";
                    for (int i = 0; i < openFileDialog.FileNames.Length; i++)
                    {
                        Core.Prepare prepare = new Core.Prepare(openFileDialog.FileNames[i],
                            new Core.CoreMsgEventHandler(prepare_CoreMsg));

                        Directory.CreateDirectory(path);
                        prepare.Perform(RotateFlipType.Rotate90FlipNone, Core.Prepare.Clip.Vertical,
                            path,
                            openFileDialog.FileNames[i]);
                        toolProgressStrip.Value = (int)Math.Ceiling((i + 1) * 100.0 / openFileDialog.FileNames.Length);
                    }
                    MessageBox.Show("Đã quay-cắt xong");
                    System.Diagnostics.Process.Start(path);
                    toolStatusText.Text = "Xử lý xong.";
                }
                catch (Exception ex) { Core.Utility.Error("Có lỗi khi thực hiện. \n" + ex.Message); }
            }
        }

        void prepare_CoreMsg(object sender, Core.CoreMsgEventArgs e)
        {
            toolStatusText.Text = e.Message;
            toolProgressStrip.Invalidate();
        }

        private void toolBtnRotateSplit_Click(object sender, EventArgs e)
        {
            mnuDataRotateSplit.PerformClick();
        }

        private void mnuRecognizeOption_Click(object sender, EventArgs e)
        {
            FormOption fo = new FormOption();
            fo.MdiParent = this;
            fo.Show();
        }

        private void toolBtnGroup_Click(object sender, EventArgs e)
        {
            mnuFileGroup.PerformClick();
        }

        private void mnuRecognizeBrowseSuite_Click(object sender, EventArgs e)
        {
            if (!FormUnisuite.HasInstanced)
            {
                FormUnisuite unisuite = new FormUnisuite();
                unisuite.MdiParent = this;
                AddWindowMenuItem(unisuite, "Quản lý các bộ đáp án");
                unisuite.Show();
            }
        }

        private void mnuDataRotateSplit_Click(object sender, EventArgs e)
        {
            FormRotateSplit frs = new FormRotateSplit();
            frs.MdiParent = this;
            frs.Show();
        }

        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            Core.IInterpret iInterpret = this.ActiveMdiChild as Core.IInterpret;
            if (iInterpret == null) return;
            if (iInterpret.IResult.Items.Length == 0)
            {
                Core.Utility.Msg(string.Format(
                    "Không có bài làm nào được chấm trong cửa sổ {1} '{0}'.",
                    Environment.NewLine, this.ActiveMdiChild.Text));
                return;
            }
            saveFileDialog.Filter = UI.Properties.Settings.Default.LogFileFilter;
            saveFileDialog.SupportMultiDottedExtensions = true;
            saveFileDialog.FileName = DateTime.Today.ToString("dd-MM-yyyy hhmmss") + ".log.xml";
            saveFileDialog.Title = "Luu ket qua tu: " + this.ActiveMdiChild.Text;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Core.Utility.XmlSerialize(saveFileDialog.FileName, iInterpret.IResult, Core.Utility.MyXmlFileType.Discovers,
                    toolProgressStrip, toolStatusText);
            }
        }

		private void mnuDataExport_DropDownOpening(object sender, EventArgs e)
		{
			if (this.ActiveMdiChild is FormInterpret)
				mnuDataExportRtf.Enabled = true;
			else
				mnuDataExportRtf.Enabled = false;
		}

		private void mnuDataExportRtf_Click(object sender, EventArgs e)
		{
			if (this.ActiveMdiChild is FormInterpret)
			{
				FormInterpret fi = this.ActiveMdiChild as FormInterpret;
				saveFileDialog.Filter = UI.Properties.Settings.Default.FilterRtf;
				saveFileDialog.Title = "Luu ket qua cho Word";
				saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					Core.Print.Result.ExportRtf(fi.Result, saveFileDialog.FileName);
				}
			}
		}

        private void mnuG2File_Click(object sender, EventArgs e)
        {
            PrepareFileDlg2Interpret();
            if (openFileDialog.ShowDialog() == DialogResult.OK && openFileDialog.FileNames.Length >= 1)
            {
                FInterpretG2 fig2 = new FInterpretG2();
                fig2.MdiParent = this;
                Hashtable tag = (Hashtable)fig2.Tag;
                tag.Add(TagKeys.AutomateSource, Core.Automate.Source.Files);
                string[] fileNames = openFileDialog.FileNames;
                string[] safeFileName = new string[fileNames.Length];
                for (int i = 0; i < fileNames.Length; i++)
                {
                    safeFileName[i] = Core.Utility.GetSafeFileName(fileNames[i]);
                }
                fig2.txtLog.AppendText(string.Join(Environment.NewLine, safeFileName));
                tag.Add(TagKeys.Caption, "Cham diem:  " + string.Join(",", safeFileName));
                tag.Add(TagKeys.Files, fileNames);
                AddWindowMenuItem(fig2, (string)tag[TagKeys.Caption]);
                fig2.Show();
            }
        }
        private void T()
        {
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            mnuHelpGeneral.PerformClick();   
        }

        private void mnuHelpGeneral_Click(object sender, EventArgs e)
        {
            //FormAssistant assistant = new FormAssistant();
            //assistant.MdiParent = this;
            try
            {
                //assistant.webBrowser1.Url = new Uri("file:///" + Application.StartupPath.Replace('\\', '/') + "/manual.htm");
                System.Diagnostics.Process.Start(Application.StartupPath + "\\Manual\\manual.wpl");
            }
            catch (Exception) { MessageBox.Show("Không tìm thấy trợ giúp!\r\n Xin vui lòng cài đặt lại để tham khảo trợ giúp."); }
            //assistant.Show();
        }

        private void mnuHelpAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Malyst \n" + 
               "Version: " + Application.ProductVersion + " Copyright (r) 2008 Giang Đức Mạnh\n" +
               "Ha Noi University of technology. All right reserved. Copying this program without permission is prohibited!!!\n" +
               "Product of K9A - Ha Tay ethic boarding high school 2000 - 2007. Special thanks for my teachers.\n" + 
               "\nContact: Giang Đức Mạnh - manhgd at gmail.com, support phone: 0979 439 458.\n" + 
               "Thank you for registering this product. Please send me your feedback.");
        }

        private void inMẫuTrắcNghiệmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Để in mẫu trắc nghiệm, bạn cần cài một chương trình đọc tệp PDF như Abode Reader hoặc Foxit Reader\n" +
                "Sau đó vào Start\\Program\\Malyst\\Mau 50/80 cau để in mẫu.\n" +
                "Chú ý quan trọng:\n" +
                "Để chương trình hoạt động hiệu quả, bạn cần chú ý bốn hình quạt đen ở bốn góc mẫu khi in phải đen đều,\n" +
                "không bị lỗ chỗ, mờ nhạt. In ở độ phân giải càng cao càng tốt. Khi dùng photo cũng vậy.");                
        }

        private void mnuDataResample_Click(object sender, EventArgs e)
        {
            //openFileDialog.Filter = UI.Properties.Settings.Default.ImageFileFilter;
            //openFileDialog.Title = "Chon anh can dua ve 100dpi";
            //openFileDialog.Multiselect = true;
            //if (openFileDialog.ShowDialog() == DialogResult.OK)
            //{                
            folderBrowserDialog.ShowNewFolderButton = false;
            folderBrowserDialog.Description = "Chọn thư mục chứa các ảnh cần đưa về 100 dpi. Các file ảnh hỗ trợ gồm *.jpg, *.bmp, *.tif";
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                System.Collections.Specialized.StringCollection files = new System.Collections.Specialized.StringCollection();
                string[] jpg = Directory.GetFiles(folderBrowserDialog.SelectedPath, "*.jpg");
                string[] bmp = Directory.GetFiles(folderBrowserDialog.SelectedPath, "*.bmp");
                string[] tif = Directory.GetFiles(folderBrowserDialog.SelectedPath, "*.tif");
                if (jpg != null) files.AddRange(jpg);
                if (bmp != null) files.AddRange(bmp);
                if (tif != null) files.AddRange(tif);
                StringBuilder err = new StringBuilder();
                string path = folderBrowserDialog.SelectedPath + "\\100dpi";
                Directory.CreateDirectory(path);
                foreach (string file in files)
                {
                    try
                    {
                        Image img = Image.FromFile(file);
                        Core.Utility.Resample(100, img).Save(
                             path + "\\" + Core.Utility.GetSafeFileName(file) + ".jpg",
                            System.Drawing.Imaging.ImageFormat.Jpeg);
                        img.Dispose();
                    }
                    catch (Exception ex) { err.AppendLine("Không chuyển được file: " + file + ". Vui lòng kiểm tra lại. \n" + ex.Message); }
                }
                if (err.Length != 0) Core.Utility.Error(err.ToString());
                Core.Utility.Msg("Đã chuyển song sang thư mục: " + path);
                System.Diagnostics.Process.Start(path);
            }
        }

        private void quétBàiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Core.Utility.Msg("Chú ý quan trọng\n" +
                "1. Luôn luôn đặt máy quét ở:" +
                "   a. 100 dpi\n" +
                "   b.màu grayscale hoặc RGB 24bit\n" +
                "   để đạt tốc độ cao nhất\n" +
                "2. Sử dụng trình \"Get Image Wizard from scanner\"của Windows nếu giao diện chương trình quét\n" +
                "của hãng sản xuất quá phức tạp (thường phải chờ quét sơ bộ sẽ rất lâu. Có thể vào chương trình\n" +
                "này bằng cách nhấn phím Windows + E và nháy phải lên máy quét.\n" +
                "3. Xếp bài đã quét theo thứ tự để có thể tìm lại bản gốc khi cần thiết.\n" +
                "4. Với máy quét ADF,  luôn đặt giấy theo chiều ngang.\n\n" +
                "Chúc bạn sẽ làm được một cách hiệu quả nhất!!!");

        }

        private void tool50_Click(object sender, EventArgs e)
        {
            mnuRecognizeFile.PerformClick();
        }

        private void tool80_Click(object sender, EventArgs e)
        {
            mnuG2File.PerformClick();
        }

        private void mẫuThếHệThứNhấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\M50-G1.pdf");
            }
            catch (Exception) { MessageBox.Show("Bạn đã cài đặt thiếu chương trình này. Xin vui lòng cài đặt lại."); }
        }

        private void càiĐặtChươngTrìnhĐọcPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\foxit-pdf-reader.exe");
            }
            catch (Exception) { MessageBox.Show("Bạn đã cài đặt thiếu chương trình này. Xin vui lòng cài đặt lại."); }
        }

        private void mẫuPhiếuToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\" + e.ClickedItem.Text + ".pdf");
            }
            catch (Exception) { MessageBox.Show("Bạn đã cài đặt thiếu chương trình này. Xin vui lòng cài đặt lại."); }
        }

        private void mnuDataBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\MalystManager.exe");
            }
            catch (Exception) { MessageBox.Show("Bạn đã cài đặt thiếu chương trình này. Xin vui lòng cài đặt lại."); }
        }

        private void máyInẢoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\virtual-printer.exe");
            }
            catch (Exception) { MessageBox.Show("Bạn đã cài đặt thiếu chương trình này. Xin vui lòng cài đặt lại."); }
        }

        
       
    }
    /// <summary>
    /// Các khóa dùng với Tag của cửa sổ
    /// </summary>
    public enum TagKeys
    {
        /// <summary>
        /// string
        /// Tiêu đề của cửa sổ
        /// </summary>
        Caption,
        /// <summary>
        /// enum Core.Automate.Source
        /// Loại tự động phân tích
        /// </summary>
        AutomateSource,
        /// <summary>
        /// Danh sách các files gửi đến để automate
        /// </summary>
        Files,
        /// <summary>
        /// string:
        /// Thư mục gửi đến để automate
        /// </summary>
        Path,
        /// <summary>
        /// int (lưu index):
        /// Bộ đáp án được chọn gắn với cửa sổ interpret
        /// </summary>
        KeySuite,
        /// <summary>
        /// int (index): 
        /// Toolstrip menu item trỏ đến cửa sổ
        /// </summary>
        MenuEntry
    }
    
}
