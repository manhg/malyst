using System;
using System.Windows.Forms;
using Microsoft.Win32;
namespace UI
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuAll = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemFileNewSuite = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileClose = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileScanner = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFilePrintSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFilePrint = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRecognize = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRecognizeBrowseSuite = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.g1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRecognizeFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRecognizeFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRecognizeScanner = new System.Windows.Forms.ToolStripMenuItem();
            this.g2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuG2Folder = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuG2File = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuG2Scanner = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuRecognizeOption = new System.Windows.Forms.ToolStripMenuItem();
            this.mẫuPhiếuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.sửaMẫuPhiếuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuData = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDataBrowse = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDataServerSync = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDataReport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDataRandomizeProblem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDataRotateSplit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDataRotate90CWSplitVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDataResample = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDataExport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDataExportRtf = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindowCascade = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindowTileVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindowTileHorizonal = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuWindowAssistant = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.inMẫuTrắcNghiệmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quétBàiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpGeneral = new System.Windows.Forms.ToolStripMenuItem();
            this.càiĐặtChươngTrìnhĐọcPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.máyInẢoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolBtnGroup = new System.Windows.Forms.ToolStripButton();
            this.toolDropUnisuite = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBtnRotateSplit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.tool50 = new System.Windows.Forms.ToolStripButton();
            this.tool80 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.pageSetupDialog = new System.Windows.Forms.PageSetupDialog();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolProgressStrip = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStatusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.menuAll.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuAll
            // 
            this.menuAll.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuRecognize,
            this.mẫuPhiếuToolStripMenuItem,
            this.mnuData,
            this.mnuWindow,
            this.mnuHelp});
            this.menuAll.Location = new System.Drawing.Point(0, 0);
            this.menuAll.Name = "menuAll";
            this.menuAll.Size = new System.Drawing.Size(742, 24);
            this.menuAll.TabIndex = 0;
            this.menuAll.Text = "Thực đơn chính của Malyst";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemFileNewSuite,
            this.mnuFileOpen,
            this.mnuFileSave,
            this.mnuFileClose,
            this.mnuFileCloseAll,
            this.toolStripSeparator9,
            this.mnuFileGroup,
            this.toolStripSeparator6,
            this.mnuFileScanner,
            this.toolStripSeparator1,
            this.mnuFilePrintSetting,
            this.mnuFilePrint,
            this.toolStripSeparator5,
            this.mnuFileExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "&Tệp";
            // 
            // mnuItemFileNewSuite
            // 
            this.mnuItemFileNewSuite.Name = "mnuItemFileNewSuite";
            this.mnuItemFileNewSuite.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnuItemFileNewSuite.Size = new System.Drawing.Size(182, 22);
            this.mnuItemFileNewSuite.Text = "Tạo bộ đáp án";
            this.mnuItemFileNewSuite.Click += new System.EventHandler(this.mnuItemFileNewSuite_Click);
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuFileOpen.Size = new System.Drawing.Size(182, 22);
            this.mnuFileOpen.Text = "Nạp đáp án";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // mnuFileSave
            // 
            this.mnuFileSave.Name = "mnuFileSave";
            this.mnuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSave.Size = new System.Drawing.Size(182, 22);
            this.mnuFileSave.Text = "Lưu";
            this.mnuFileSave.Click += new System.EventHandler(this.mnuFileSave_Click);
            // 
            // mnuFileClose
            // 
            this.mnuFileClose.Name = "mnuFileClose";
            this.mnuFileClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
            this.mnuFileClose.Size = new System.Drawing.Size(182, 22);
            this.mnuFileClose.Text = "Đóng cửa sổ";
            this.mnuFileClose.Click += new System.EventHandler(this.mnuFileClose_Click);
            // 
            // mnuFileCloseAll
            // 
            this.mnuFileCloseAll.Name = "mnuFileCloseAll";
            this.mnuFileCloseAll.Size = new System.Drawing.Size(182, 22);
            this.mnuFileCloseAll.Text = "Đóng tất cả";
            this.mnuFileCloseAll.Click += new System.EventHandler(this.mnuFileCloseAll_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(179, 6);
            // 
            // mnuFileGroup
            // 
            this.mnuFileGroup.Name = "mnuFileGroup";
            this.mnuFileGroup.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.mnuFileGroup.Size = new System.Drawing.Size(182, 22);
            this.mnuFileGroup.Text = "Học sinh / Lớp học";
            this.mnuFileGroup.Click += new System.EventHandler(this.mnuItemGroup_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(179, 6);
            // 
            // mnuFileScanner
            // 
            this.mnuFileScanner.Enabled = false;
            this.mnuFileScanner.Name = "mnuFileScanner";
            this.mnuFileScanner.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F11)));
            this.mnuFileScanner.Size = new System.Drawing.Size(182, 22);
            this.mnuFileScanner.Text = "Máy quét";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(179, 6);
            // 
            // mnuFilePrintSetting
            // 
            this.mnuFilePrintSetting.Name = "mnuFilePrintSetting";
            this.mnuFilePrintSetting.Size = new System.Drawing.Size(182, 22);
            this.mnuFilePrintSetting.Text = "Thiết lập in";
            this.mnuFilePrintSetting.Click += new System.EventHandler(this.mnuFilePrintSetting_Click);
            // 
            // mnuFilePrint
            // 
            this.mnuFilePrint.Name = "mnuFilePrint";
            this.mnuFilePrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.mnuFilePrint.Size = new System.Drawing.Size(182, 22);
            this.mnuFilePrint.Text = "In";
            this.mnuFilePrint.Click += new System.EventHandler(this.mnuFilePrint_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(179, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mnuFileExit.Size = new System.Drawing.Size(182, 22);
            this.mnuFileExit.Text = "Thoát";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuItemFileExit_Click);
            // 
            // mnuRecognize
            // 
            this.mnuRecognize.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRecognizeBrowseSuite,
            this.toolStripSeparator4,
            this.g1ToolStripMenuItem,
            this.g2ToolStripMenuItem,
            this.toolStripSeparator12,
            this.mnuRecognizeOption});
            this.mnuRecognize.Name = "mnuRecognize";
            this.mnuRecognize.Size = new System.Drawing.Size(71, 20);
            this.mnuRecognize.Text = "&Chấm điểm";
            // 
            // mnuRecognizeBrowseSuite
            // 
            this.mnuRecognizeBrowseSuite.Name = "mnuRecognizeBrowseSuite";
            this.mnuRecognizeBrowseSuite.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.mnuRecognizeBrowseSuite.Size = new System.Drawing.Size(153, 22);
            this.mnuRecognizeBrowseSuite.Text = "Bộ đáp án";
            this.mnuRecognizeBrowseSuite.Click += new System.EventHandler(this.mnuRecognizeBrowseSuite_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(150, 6);
            // 
            // g1ToolStripMenuItem
            // 
            this.g1ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRecognizeFolder,
            this.mnuRecognizeFile,
            this.mnuRecognizeScanner});
            this.g1ToolStripMenuItem.Name = "g1ToolStripMenuItem";
            this.g1ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.g1ToolStripMenuItem.Text = "Mẫu 50 câu (G1)";
            // 
            // mnuRecognizeFolder
            // 
            this.mnuRecognizeFolder.Name = "mnuRecognizeFolder";
            this.mnuRecognizeFolder.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.mnuRecognizeFolder.Size = new System.Drawing.Size(160, 22);
            this.mnuRecognizeFolder.Text = "Thư mục";
            this.mnuRecognizeFolder.Click += new System.EventHandler(this.mnuRecognizeFolder_Click);
            // 
            // mnuRecognizeFile
            // 
            this.mnuRecognizeFile.Name = "mnuRecognizeFile";
            this.mnuRecognizeFile.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.mnuRecognizeFile.Size = new System.Drawing.Size(160, 22);
            this.mnuRecognizeFile.Text = "Tệp";
            this.mnuRecognizeFile.Click += new System.EventHandler(this.mnuRecognizeFile_Click);
            // 
            // mnuRecognizeScanner
            // 
            this.mnuRecognizeScanner.Enabled = false;
            this.mnuRecognizeScanner.Name = "mnuRecognizeScanner";
            this.mnuRecognizeScanner.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.mnuRecognizeScanner.Size = new System.Drawing.Size(160, 22);
            this.mnuRecognizeScanner.Text = "Từ máy quét";
            // 
            // g2ToolStripMenuItem
            // 
            this.g2ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuG2Folder,
            this.mnuG2File,
            this.mnuG2Scanner});
            this.g2ToolStripMenuItem.Name = "g2ToolStripMenuItem";
            this.g2ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.g2ToolStripMenuItem.Text = "Mẫu 80 câu (G2)";
            // 
            // mnuG2Folder
            // 
            this.mnuG2Folder.Name = "mnuG2Folder";
            this.mnuG2Folder.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F9)));
            this.mnuG2Folder.Size = new System.Drawing.Size(164, 22);
            this.mnuG2Folder.Text = "Thư mục";
            this.mnuG2Folder.Click += new System.EventHandler(this.mnuRecognizeG2Folder_Click);
            // 
            // mnuG2File
            // 
            this.mnuG2File.Name = "mnuG2File";
            this.mnuG2File.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F10)));
            this.mnuG2File.Size = new System.Drawing.Size(164, 22);
            this.mnuG2File.Text = "Tệp";
            this.mnuG2File.Click += new System.EventHandler(this.mnuG2File_Click);
            // 
            // mnuG2Scanner
            // 
            this.mnuG2Scanner.Enabled = false;
            this.mnuG2Scanner.Name = "mnuG2Scanner";
            this.mnuG2Scanner.Size = new System.Drawing.Size(164, 22);
            this.mnuG2Scanner.Text = "Máy quét";
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(150, 6);
            // 
            // mnuRecognizeOption
            // 
            this.mnuRecognizeOption.Enabled = false;
            this.mnuRecognizeOption.Name = "mnuRecognizeOption";
            this.mnuRecognizeOption.Size = new System.Drawing.Size(153, 22);
            this.mnuRecognizeOption.Text = "Tùy chọn";
            this.mnuRecognizeOption.Click += new System.EventHandler(this.mnuRecognizeOption_Click);
            // 
            // mẫuPhiếuToolStripMenuItem
            // 
            this.mẫuPhiếuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.aToolStripMenuItem,
            this.toolStripSeparator13,
            this.sửaMẫuPhiếuToolStripMenuItem});
            this.mẫuPhiếuToolStripMenuItem.Name = "mẫuPhiếuToolStripMenuItem";
            this.mẫuPhiếuToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.mẫuPhiếuToolStripMenuItem.Text = "Mẫu phiếu";
            this.mẫuPhiếuToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mẫuPhiếuToolStripMenuItem_DropDownItemClicked);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(145, 22);
            this.toolStripMenuItem4.Text = "30";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(145, 22);
            this.toolStripMenuItem2.Text = "50";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(145, 22);
            this.toolStripMenuItem3.Text = "80";
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.aToolStripMenuItem.Text = "80A";
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(142, 6);
            // 
            // sửaMẫuPhiếuToolStripMenuItem
            // 
            this.sửaMẫuPhiếuToolStripMenuItem.Enabled = false;
            this.sửaMẫuPhiếuToolStripMenuItem.Name = "sửaMẫuPhiếuToolStripMenuItem";
            this.sửaMẫuPhiếuToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.sửaMẫuPhiếuToolStripMenuItem.Text = "Sửa mẫu phiếu";
            // 
            // mnuData
            // 
            this.mnuData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDataBrowse,
            this.mnuDataServerSync,
            this.mnuDataReport,
            this.toolStripSeparator8,
            this.mnuDataRandomizeProblem,
            this.toolStripSeparator15,
            this.mnuDataRotateSplit,
            this.mnuDataRotate90CWSplitVertical,
            this.mnuDataResample,
            this.mnuDataExport});
            this.mnuData.Name = "mnuData";
            this.mnuData.Size = new System.Drawing.Size(52, 20);
            this.mnuData.Text = "&Dữ liệu";
            // 
            // mnuDataBrowse
            // 
            this.mnuDataBrowse.Image = global::UI.Properties.Resources.Network_Internet;
            this.mnuDataBrowse.Name = "mnuDataBrowse";
            this.mnuDataBrowse.Size = new System.Drawing.Size(232, 22);
            this.mnuDataBrowse.Text = "Malyst Manager";
            this.mnuDataBrowse.Click += new System.EventHandler(this.mnuDataBrowse_Click);
            // 
            // mnuDataServerSync
            // 
            this.mnuDataServerSync.Enabled = false;
            this.mnuDataServerSync.Image = global::UI.Properties.Resources.VPN;
            this.mnuDataServerSync.Name = "mnuDataServerSync";
            this.mnuDataServerSync.Size = new System.Drawing.Size(232, 22);
            this.mnuDataServerSync.Text = "Cập nhật máy chủ";
            // 
            // mnuDataReport
            // 
            this.mnuDataReport.Enabled = false;
            this.mnuDataReport.Name = "mnuDataReport";
            this.mnuDataReport.Size = new System.Drawing.Size(232, 22);
            this.mnuDataReport.Text = "Báo cáo";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(229, 6);
            // 
            // mnuDataRandomizeProblem
            // 
            this.mnuDataRandomizeProblem.Enabled = false;
            this.mnuDataRandomizeProblem.Name = "mnuDataRandomizeProblem";
            this.mnuDataRandomizeProblem.Size = new System.Drawing.Size(232, 22);
            this.mnuDataRandomizeProblem.Text = "Trộn đề tự động";
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(229, 6);
            // 
            // mnuDataRotateSplit
            // 
            this.mnuDataRotateSplit.Name = "mnuDataRotateSplit";
            this.mnuDataRotateSplit.Size = new System.Drawing.Size(232, 22);
            this.mnuDataRotateSplit.Text = "Xoay - cắt";
            this.mnuDataRotateSplit.Click += new System.EventHandler(this.mnuDataRotateSplit_Click);
            // 
            // mnuDataRotate90CWSplitVertical
            // 
            this.mnuDataRotate90CWSplitVertical.Name = "mnuDataRotate90CWSplitVertical";
            this.mnuDataRotate90CWSplitVertical.Size = new System.Drawing.Size(232, 22);
            this.mnuDataRotate90CWSplitVertical.Text = "Xoay 90 kim đồng hồ, cắt đôi dọc";
            this.mnuDataRotate90CWSplitVertical.Click += new System.EventHandler(this.mnuDataRotate90CWSplitVertical_Click);
            // 
            // mnuDataResample
            // 
            this.mnuDataResample.Name = "mnuDataResample";
            this.mnuDataResample.Size = new System.Drawing.Size(232, 22);
            this.mnuDataResample.Text = "Chuyển bài quét về 100 dpi";
            this.mnuDataResample.Click += new System.EventHandler(this.mnuDataResample_Click);
            // 
            // mnuDataExport
            // 
            this.mnuDataExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDataExportRtf});
            this.mnuDataExport.Name = "mnuDataExport";
            this.mnuDataExport.Size = new System.Drawing.Size(232, 22);
            this.mnuDataExport.Text = "Chuyển sang";
            this.mnuDataExport.DropDownOpening += new System.EventHandler(this.mnuDataExport_DropDownOpening);
            // 
            // mnuDataExportRtf
            // 
            this.mnuDataExportRtf.Name = "mnuDataExportRtf";
            this.mnuDataExportRtf.Size = new System.Drawing.Size(147, 22);
            this.mnuDataExportRtf.Text = "Microsoft Word";
            this.mnuDataExportRtf.Click += new System.EventHandler(this.mnuDataExportRtf_Click);
            // 
            // mnuWindow
            // 
            this.mnuWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuWindowCascade,
            this.mnuWindowTileVertical,
            this.mnuWindowTileHorizonal,
            this.toolStripSeparator3,
            this.mnuWindowAssistant});
            this.mnuWindow.Name = "mnuWindow";
            this.mnuWindow.Size = new System.Drawing.Size(53, 20);
            this.mnuWindow.Text = "&Cửa sổ";
            // 
            // mnuWindowCascade
            // 
            this.mnuWindowCascade.Name = "mnuWindowCascade";
            this.mnuWindowCascade.Size = new System.Drawing.Size(168, 22);
            this.mnuWindowCascade.Text = "Xếp chồng lên nhau";
            this.mnuWindowCascade.Click += new System.EventHandler(this.mnuWindowCascade_Click);
            // 
            // mnuWindowTileVertical
            // 
            this.mnuWindowTileVertical.Name = "mnuWindowTileVertical";
            this.mnuWindowTileVertical.Size = new System.Drawing.Size(168, 22);
            this.mnuWindowTileVertical.Text = "Xếp so le dọc";
            this.mnuWindowTileVertical.Click += new System.EventHandler(this.mnuWindowTileVertical_Click);
            // 
            // mnuWindowTileHorizonal
            // 
            this.mnuWindowTileHorizonal.Name = "mnuWindowTileHorizonal";
            this.mnuWindowTileHorizonal.Size = new System.Drawing.Size(168, 22);
            this.mnuWindowTileHorizonal.Text = "Xếp so le ngang";
            this.mnuWindowTileHorizonal.Click += new System.EventHandler(this.mnuWindowTileHorizonal_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(165, 6);
            // 
            // mnuWindowAssistant
            // 
            this.mnuWindowAssistant.CheckOnClick = true;
            this.mnuWindowAssistant.Name = "mnuWindowAssistant";
            this.mnuWindowAssistant.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F1)));
            this.mnuWindowAssistant.Size = new System.Drawing.Size(168, 22);
            this.mnuWindowAssistant.Text = "Chỉ dẫn";
            this.mnuWindowAssistant.CheckStateChanged += new System.EventHandler(this.mnuWindowAssistant_CheckStateChanged);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inMẫuTrắcNghiệmToolStripMenuItem,
            this.quétBàiToolStripMenuItem,
            this.mnuHelpGeneral,
            this.càiĐặtChươngTrìnhĐọcPDFToolStripMenuItem,
            this.máyInẢoToolStripMenuItem,
            this.toolStripSeparator2,
            this.mnuHelpAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(58, 20);
            this.mnuHelp.Text = "&Trợ giúp";
            // 
            // inMẫuTrắcNghiệmToolStripMenuItem
            // 
            this.inMẫuTrắcNghiệmToolStripMenuItem.Name = "inMẫuTrắcNghiệmToolStripMenuItem";
            this.inMẫuTrắcNghiệmToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.inMẫuTrắcNghiệmToolStripMenuItem.Text = "In mẫu trắc nghiệm";
            this.inMẫuTrắcNghiệmToolStripMenuItem.Click += new System.EventHandler(this.inMẫuTrắcNghiệmToolStripMenuItem_Click);
            // 
            // quétBàiToolStripMenuItem
            // 
            this.quétBàiToolStripMenuItem.Name = "quétBàiToolStripMenuItem";
            this.quétBàiToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.quétBàiToolStripMenuItem.Text = "Quét bài";
            this.quétBàiToolStripMenuItem.Click += new System.EventHandler(this.quétBàiToolStripMenuItem_Click);
            // 
            // mnuHelpGeneral
            // 
            this.mnuHelpGeneral.Name = "mnuHelpGeneral";
            this.mnuHelpGeneral.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.mnuHelpGeneral.Size = new System.Drawing.Size(214, 22);
            this.mnuHelpGeneral.Text = "Tổng quan";
            this.mnuHelpGeneral.Click += new System.EventHandler(this.mnuHelpGeneral_Click);
            // 
            // càiĐặtChươngTrìnhĐọcPDFToolStripMenuItem
            // 
            this.càiĐặtChươngTrìnhĐọcPDFToolStripMenuItem.Name = "càiĐặtChươngTrìnhĐọcPDFToolStripMenuItem";
            this.càiĐặtChươngTrìnhĐọcPDFToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.càiĐặtChươngTrìnhĐọcPDFToolStripMenuItem.Text = "Cài đặt chương trình đọc PDF";
            this.càiĐặtChươngTrìnhĐọcPDFToolStripMenuItem.Click += new System.EventHandler(this.càiĐặtChươngTrìnhĐọcPDFToolStripMenuItem_Click);
            // 
            // máyInẢoToolStripMenuItem
            // 
            this.máyInẢoToolStripMenuItem.Name = "máyInẢoToolStripMenuItem";
            this.máyInẢoToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.máyInẢoToolStripMenuItem.Text = "Máy in ảo";
            this.máyInẢoToolStripMenuItem.Click += new System.EventHandler(this.máyInẢoToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(211, 6);
            // 
            // mnuHelpAbout
            // 
            this.mnuHelpAbout.Name = "mnuHelpAbout";
            this.mnuHelpAbout.Size = new System.Drawing.Size(214, 22);
            this.mnuHelpAbout.Text = "About";
            this.mnuHelpAbout.Click += new System.EventHandler(this.mnuHelpAbout_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Chọn thư mục lưu ảnh của bài làm đã quét. Chương trình chỉ sử dụng các file nằm t" +
                "rực tiếp trong thư mục đó (các tệp trong thư mục con không tính).";
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "key.xml";
            this.openFileDialog.Filter = "Bộ đáp án của Malyst|*.key.xml";
            this.openFileDialog.SupportMultiDottedExtensions = true;
            this.openFileDialog.Title = "Mở tệp";
            // 
            // toolStripMain
            // 
            this.toolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.toolBtnGroup,
            this.toolDropUnisuite,
            this.toolStripSeparator10,
            this.toolBtnRotateSplit,
            this.toolStripSeparator,
            this.saveToolStripButton,
            this.toolStripSeparator16,
            this.tool50,
            this.tool80,
            this.toolStripSeparator7,
            this.helpToolStripButton});
            this.toolStripMain.Location = new System.Drawing.Point(0, 24);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(742, 25);
            this.toolStripMain.TabIndex = 2;
            this.toolStripMain.Text = "toolStrip";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(81, 22);
            this.newToolStripButton.Text = "Tạo đáp án";
            this.newToolStripButton.Click += new System.EventHandler(this.newToolStripButton_Click);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(82, 22);
            this.openToolStripButton.Text = "Nạp đáp án";
            this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
            // 
            // toolBtnGroup
            // 
            this.toolBtnGroup.Image = global::UI.Properties.Resources.Users;
            this.toolBtnGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnGroup.Name = "toolBtnGroup";
            this.toolBtnGroup.Size = new System.Drawing.Size(61, 22);
            this.toolBtnGroup.Text = "Lớp/HS";
            this.toolBtnGroup.Click += new System.EventHandler(this.toolBtnGroup_Click);
            // 
            // toolDropUnisuite
            // 
            this.toolDropUnisuite.Image = global::UI.Properties.Resources.Keys;
            this.toolDropUnisuite.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDropUnisuite.Name = "toolDropUnisuite";
            this.toolDropUnisuite.Size = new System.Drawing.Size(62, 22);
            this.toolDropUnisuite.Text = "Đáp án";
            this.toolDropUnisuite.Click += new System.EventHandler(this.toolDropUnisuite_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // toolBtnRotateSplit
            // 
            this.toolBtnRotateSplit.Image = global::UI.Properties.Resources.cut;
            this.toolBtnRotateSplit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnRotateSplit.Name = "toolBtnRotateSplit";
            this.toolBtnRotateSplit.Size = new System.Drawing.Size(83, 22);
            this.toolBtnRotateSplit.Text = "Quay && Cắt";
            this.toolBtnRotateSplit.Click += new System.EventHandler(this.toolBtnRotateSplit_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Lưu dữ liệu trong cửa sổ hiện tại";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(6, 25);
            // 
            // tool50
            // 
            this.tool50.Image = global::UI.Properties.Resources.Favorites;
            this.tool50.Name = "tool50";
            this.tool50.Size = new System.Drawing.Size(69, 22);
            this.tool50.Text = "Chấm 50";
            this.tool50.Click += new System.EventHandler(this.tool50_Click);
            // 
            // tool80
            // 
            this.tool80.Image = global::UI.Properties.Resources.preferences;
            this.tool80.Name = "tool80";
            this.tool80.Size = new System.Drawing.Size(69, 22);
            this.tool80.Text = "Chấm 80";
            this.tool80.Click += new System.EventHandler(this.tool80_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(66, 22);
            this.helpToolStripButton.Text = "Trợ giúp";
            this.helpToolStripButton.Click += new System.EventHandler(this.helpToolStripButton_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.SupportMultiDottedExtensions = true;
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            this.printDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument_BeginPrint);
            // 
            // pageSetupDialog
            // 
            this.pageSetupDialog.Document = this.printDocument;
            this.pageSetupDialog.EnableMetric = true;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolProgressStrip,
            this.toolStatusText});
            this.statusStrip.Location = new System.Drawing.Point(0, 451);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(742, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolProgressStrip
            // 
            this.toolProgressStrip.AutoSize = false;
            this.toolProgressStrip.AutoToolTip = true;
            this.toolProgressStrip.Name = "toolProgressStrip";
            this.toolProgressStrip.Size = new System.Drawing.Size(150, 16);
            this.toolProgressStrip.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.toolProgressStrip.ToolTipText = "Trạng thái của thao tác đang thực hiện";
            // 
            // toolStatusText
            // 
            this.toolStatusText.Name = "toolStatusText";
            this.toolStatusText.Size = new System.Drawing.Size(0, 17);
            this.toolStatusText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 473);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.menuAll);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuAll;
            this.Name = "FormMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.menuAll.ResumeLayout(false);
            this.menuAll.PerformLayout();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpGeneral;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuWindow;
        private System.Windows.Forms.ToolStripMenuItem mnuWindowCascade;
        private System.Windows.Forms.ToolStripMenuItem mnuWindowTileVertical;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuFileGroup;
        private System.Windows.Forms.ToolStripMenuItem mnuRecognize;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mnuRecognizeOption;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem mnuFilePrintSetting;
        private System.Windows.Forms.ToolStripMenuItem mnuFilePrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem mnuData;
        private System.Windows.Forms.ToolStripMenuItem mnuDataServerSync;
        private System.Windows.Forms.ToolStripMenuItem mnuDataBrowse;
        private System.Windows.Forms.ToolStripMenuItem mnuDataReport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem mnuFileScanner;
        private System.Windows.Forms.ToolStripMenuItem mnuWindowTileHorizonal;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem mnuFileCloseAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem mnuDataRandomizeProblem;
        private System.Windows.Forms.ToolStripMenuItem mnuWindowAssistant;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog;
        private System.Windows.Forms.StatusStrip statusStrip;
        internal System.Windows.Forms.ToolStripProgressBar toolProgressStrip;
        internal System.Windows.Forms.ToolStripStatusLabel toolStatusText;
        private System.Windows.Forms.ToolStripButton toolDropUnisuite;
        internal System.Windows.Forms.MenuStrip menuAll;
        internal System.Windows.Forms.ToolStripMenuItem mnuFile;
        public System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        public System.Windows.Forms.ToolStripMenuItem mnuFileClose;
        public System.Windows.Forms.ToolStripMenuItem mnuItemFileNewSuite;
        private System.Windows.Forms.ToolStripButton toolBtnRotateSplit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton toolBtnGroup;
        private System.Windows.Forms.ToolStripMenuItem mnuRecognizeBrowseSuite;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
		public System.Windows.Forms.ToolStripMenuItem mnuFileSave;
		public System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.ToolStripMenuItem mnuDataExport;
        private System.Windows.Forms.ToolTip toolTipMain;
        private System.Windows.Forms.ToolStripMenuItem g1ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem mnuRecognizeFolder;
        private System.Windows.Forms.ToolStripMenuItem mnuRecognizeFile;
        private System.Windows.Forms.ToolStripMenuItem mnuRecognizeScanner;
        private ToolStripSeparator toolStripSeparator15;
        private ToolStripMenuItem inMẫuTrắcNghiệmToolStripMenuItem;
        private ToolStripMenuItem quétBàiToolStripMenuItem;
        private ToolStripButton tool50;
        private ToolStripButton tool80;
        private ToolStripSeparator toolStripSeparator16;
        private ToolStripMenuItem càiĐặtChươngTrìnhĐọcPDFToolStripMenuItem;
        private ToolStripMenuItem mẫuPhiếuToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem aToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator13;
        private ToolStripMenuItem sửaMẫuPhiếuToolStripMenuItem;
        private ToolStripMenuItem g2ToolStripMenuItem;
        private ToolStripMenuItem mnuG2Folder;
        private ToolStripMenuItem mnuG2File;
        private ToolStripMenuItem mnuG2Scanner;
        private ToolStripMenuItem mnuDataRotate90CWSplitVertical;
        private ToolStripMenuItem mnuDataResample;
        private ToolStripMenuItem mnuDataRotateSplit;
        public ToolStripMenuItem mnuDataExportRtf;
        private ToolStripMenuItem máyInẢoToolStripMenuItem;
    }
}

