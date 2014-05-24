namespace UI
{
    partial class FormInterpret
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInterpret));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bgWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolBtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolScale = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolVisual = new System.Windows.Forms.ToolStripButton();
            this.toolCloseOrgin = new System.Windows.Forms.ToolStripButton();
            this.toolOrgin = new System.Windows.Forms.ToolStripButton();
            this.toolBtnRecognize = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.printToolStripButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolPrintByGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolPrintByMark = new System.Windows.Forms.ToolStripMenuItem();
            this.toolToWord = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ghépTênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.gridMark = new System.Windows.Forms.DataGridView();
            this.colGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProblem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel = new System.Windows.Forms.Panel();
            this.lblSourceFile = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.picture = new System.Windows.Forms.PictureBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.prDoc = new System.Drawing.Printing.PrintDocument();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMark)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.SuspendLayout();
            // 
            // bgWorker1
            // 
            this.bgWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.bgWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // toolStrip
            // 
            this.toolStrip.AllowItemReorder = true;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBtnSave,
            this.toolScale,
            this.toolVisual,
            this.toolCloseOrgin,
            this.toolOrgin,
            this.toolBtnRecognize,
            this.toolStripSeparator1,
            this.saveToolStripButton,
            this.printToolStripButton,
            this.toolStripSeparator,
            this.toolStripLabel1});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(632, 25);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "toolStrip";
            // 
            // toolBtnSave
            // 
            this.toolBtnSave.Image = global::UI.Properties.Resources.Folder_Front;
            this.toolBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnSave.Name = "toolBtnSave";
            this.toolBtnSave.Size = new System.Drawing.Size(84, 22);
            this.toolBtnSave.Text = "Lưu nhật ký";
            this.toolBtnSave.Click += new System.EventHandler(this.toolBtnSave_Click);
            // 
            // toolScale
            // 
            this.toolScale.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolScale.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
            this.toolScale.Image = global::UI.Properties.Resources.search;
            this.toolScale.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolScale.Name = "toolScale";
            this.toolScale.Size = new System.Drawing.Size(55, 22);
            this.toolScale.Text = "Tỉ lệ";
            this.toolScale.Visible = false;
            this.toolScale.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolScale_DropDownItemClicked);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(103, 22);
            this.toolStripMenuItem2.Tag = "25";
            this.toolStripMenuItem2.Text = "25%";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(103, 22);
            this.toolStripMenuItem3.Tag = "50";
            this.toolStripMenuItem3.Text = "50%";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(103, 22);
            this.toolStripMenuItem4.Tag = "75";
            this.toolStripMenuItem4.Text = "75%";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(103, 22);
            this.toolStripMenuItem5.Tag = "100";
            this.toolStripMenuItem5.Text = "100%";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(103, 22);
            this.toolStripMenuItem6.Tag = "200";
            this.toolStripMenuItem6.Text = "200%";
            // 
            // toolVisual
            // 
            this.toolVisual.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolVisual.Image = global::UI.Properties.Resources.AutoList;
            this.toolVisual.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolVisual.Name = "toolVisual";
            this.toolVisual.Size = new System.Drawing.Size(76, 22);
            this.toolVisual.Text = "Trực quan";
            this.toolVisual.Click += new System.EventHandler(this.toolVisual_Click);
            // 
            // toolCloseOrgin
            // 
            this.toolCloseOrgin.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolCloseOrgin.Image = global::UI.Properties.Resources.delete;
            this.toolCloseOrgin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCloseOrgin.Name = "toolCloseOrgin";
            this.toolCloseOrgin.Size = new System.Drawing.Size(53, 22);
            this.toolCloseOrgin.Text = "Đóng";
            this.toolCloseOrgin.Visible = false;
            this.toolCloseOrgin.Click += new System.EventHandler(this.toolCloseOrgin_Click);
            // 
            // toolOrgin
            // 
            this.toolOrgin.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolOrgin.Image = global::UI.Properties.Resources.Generic_Document;
            this.toolOrgin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolOrgin.Name = "toolOrgin";
            this.toolOrgin.Size = new System.Drawing.Size(61, 22);
            this.toolOrgin.Text = "Bài gốc";
            this.toolOrgin.ToolTipText = "Khi ở chế độ xem bản gốc, để tránh nhầm lẫn không sử dụng phím Enter ";
            this.toolOrgin.Click += new System.EventHandler(this.toolOrgin_Click);
            // 
            // toolBtnRecognize
            // 
            this.toolBtnRecognize.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolBtnRecognize.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolBtnRecognize.Image = global::UI.Properties.Resources.Calculator;
            this.toolBtnRecognize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnRecognize.Name = "toolBtnRecognize";
            this.toolBtnRecognize.Size = new System.Drawing.Size(76, 22);
            this.toolBtnRecognize.Text = "Chấm 50";
            this.toolBtnRecognize.Click += new System.EventHandler(this.toolBtnRecognize_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(84, 22);
            this.saveToolStripButton.Text = "&Lưu kết quả";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolPrintByGroup,
            this.toolPrintByMark,
            this.toolToWord,
            this.toolStripSeparator2,
            this.ghépTênToolStripMenuItem});
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(46, 22);
            this.printToolStripButton.Text = "&In";
            this.printToolStripButton.Click += new System.EventHandler(this.printToolStripButton_Click);
            // 
            // toolPrintByGroup
            // 
            this.toolPrintByGroup.Name = "toolPrintByGroup";
            this.toolPrintByGroup.Size = new System.Drawing.Size(215, 22);
            this.toolPrintByGroup.Text = "Theo danh sách lớp";
            this.toolPrintByGroup.Click += new System.EventHandler(this.toolPrintByGroup_Click);
            // 
            // toolPrintByMark
            // 
            this.toolPrintByMark.Name = "toolPrintByMark";
            this.toolPrintByMark.Size = new System.Drawing.Size(215, 22);
            this.toolPrintByMark.Text = "Theo điểm từ cao xuống thấp";
            this.toolPrintByMark.Click += new System.EventHandler(this.toolPrintByMark_Click);
            // 
            // toolToWord
            // 
            this.toolToWord.Name = "toolToWord";
            this.toolToWord.Size = new System.Drawing.Size(215, 22);
            this.toolToWord.Text = "Chuyển sang Word";
            this.toolToWord.Click += new System.EventHandler(this.toolToWord_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(212, 6);
            // 
            // ghépTênToolStripMenuItem
            // 
            this.ghépTênToolStripMenuItem.Name = "ghépTênToolStripMenuItem";
            this.ghépTênToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.ghépTênToolStripMenuItem.Text = "Ghép tên";
            this.ghépTênToolStripMenuItem.Click += new System.EventHandler(this.ghépTênToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(86, 22);
            this.toolStripLabel1.Text = "Mẫu G1 (50 câu)";
            // 
            // gridMark
            // 
            this.gridMark.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridMark.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridMark.ColumnHeadersHeight = 22;
            this.gridMark.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridMark.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colGroup,
            this.colStudentID,
            this.colProblem,
            this.colMark,
            this.colDetail});
            this.gridMark.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridMark.Location = new System.Drawing.Point(3, 28);
            this.gridMark.MultiSelect = false;
            this.gridMark.Name = "gridMark";
            this.gridMark.RowHeadersVisible = false;
            this.gridMark.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridMark.ShowCellErrors = false;
            this.gridMark.ShowEditingIcon = false;
            this.gridMark.ShowRowErrors = false;
            this.gridMark.Size = new System.Drawing.Size(630, 177);
            this.gridMark.TabIndex = 5;
            this.toolTip.SetToolTip(this.gridMark, "Nhấn nút ngoại lệ để xem bản gốc của bài làm và trực tiếp sửa trên kết quả nhận đ" +
                    "ược nếu có sai sót.");
            this.gridMark.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridMark_CellValueChanged);
            this.gridMark.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridMark_RowEnter);
            this.gridMark.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridMark_CellMouseDoubleClick);
            // 
            // colGroup
            // 
            this.colGroup.HeaderText = "Lớp";
            this.colGroup.Name = "colGroup";
            this.colGroup.Width = 70;
            // 
            // colStudentID
            // 
            this.colStudentID.HeaderText = "Mã HS";
            this.colStudentID.Name = "colStudentID";
            this.colStudentID.Width = 70;
            // 
            // colProblem
            // 
            this.colProblem.HeaderText = "Đề";
            this.colProblem.Name = "colProblem";
            this.colProblem.Width = 70;
            // 
            // colMark
            // 
            this.colMark.HeaderText = "Điểm";
            this.colMark.Name = "colMark";
            this.colMark.Width = 50;
            // 
            // colDetail
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDetail.DefaultCellStyle = dataGridViewCellStyle1;
            this.colDetail.HeaderText = "Bài làm chi tiết";
            this.colDetail.Name = "colDetail";
            this.colDetail.Width = 500;
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.AutoScroll = true;
            this.panel.Controls.Add(this.lblSourceFile);
            this.panel.Controls.Add(this.label);
            this.panel.Controls.Add(this.picture);
            this.panel.Location = new System.Drawing.Point(3, 72);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(630, 306);
            this.panel.TabIndex = 6;
            this.panel.Visible = false;
            // 
            // lblSourceFile
            // 
            this.lblSourceFile.BackColor = System.Drawing.SystemColors.Info;
            this.lblSourceFile.Location = new System.Drawing.Point(83, 8);
            this.lblSourceFile.Name = "lblSourceFile";
            this.lblSourceFile.Size = new System.Drawing.Size(562, 13);
            this.lblSourceFile.TabIndex = 5;
            this.lblSourceFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(9, 8);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(64, 13);
            this.label.TabIndex = 4;
            this.label.Text = "Dữ liệu gốc:";
            // 
            // picture
            // 
            this.picture.Location = new System.Drawing.Point(0, 24);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(246, 246);
            this.picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picture.TabIndex = 0;
            this.picture.TabStop = false;
            this.toolTip.SetToolTip(this.picture, resources.GetString("picture.ToolTip"));
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.BackColor = System.Drawing.SystemColors.Info;
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLog.Location = new System.Drawing.Point(3, 208);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(632, 166);
            this.txtLog.TabIndex = 4;
            this.txtLog.Text = "Tốc ký:";
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 1000;
            this.toolTip.ShowAlways = true;
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.toolTip.ToolTipTitle = "Chú ý:";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(0, 382);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(631, 10);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 7;
            // 
            // prDoc
            // 
            this.prDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocResult_PrintPage);
            // 
            // FormInterpret
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 390);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.gridMark);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.toolStrip);
            this.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormInterpret";
            this.ShowInTaskbar = false;
            this.Text = "Chấm điểm";
            this.Load += new System.EventHandler(this.FormInterpret_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMark)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bgWorker1;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolBtnRecognize;
        private System.Windows.Forms.ToolStripButton toolBtnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolOrgin;
        private System.Windows.Forms.DataGridView gridMark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProblem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetail;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label lblSourceFile;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.PictureBox picture;
        internal System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripDropDownButton toolScale;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton toolVisual;
        private System.Windows.Forms.ToolStripButton toolCloseOrgin;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Drawing.Printing.PrintDocument prDoc;
        private System.Windows.Forms.ToolStripDropDownButton printToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem toolPrintByGroup;
        private System.Windows.Forms.ToolStripMenuItem toolPrintByMark;
        private System.Windows.Forms.ToolStripMenuItem toolToWord;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ghépTênToolStripMenuItem;
    }
}