namespace GiangManh.MM
{
    partial class FormTableViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTableViewer));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grid = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.checkColumnsResize = new System.Windows.Forms.CheckBox();
            this.checkDeleteWithoutAsking = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioVerbose = new System.Windows.Forms.RadioButton();
            this.radioSilent = new System.Windows.Forms.RadioButton();
            this.checkUpdate = new System.Windows.Forms.CheckBox();
            this.checkDelete = new System.Windows.Forms.CheckBox();
            this.checkAdd = new System.Windows.Forms.CheckBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.textInfo = new System.Windows.Forms.ToolStripTextBox();
            this.dropdown = new System.Windows.Forms.ToolStripSplitButton();
            this.reorderButton = new System.Windows.Forms.ToolStripButton();
            this.toolMore = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, -3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(533, 392);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grid);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(525, 366);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Thông tin";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grid
            // 
            this.grid.AllowUserToOrderColumns = true;
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Font = global::MalystManager.Properties.Settings.Default.gridFont;
            this.grid.Location = new System.Drawing.Point(3, 3);
            this.grid.Name = "grid";
            this.grid.RowHeadersWidth = 20;
            this.grid.Size = new System.Drawing.Size(519, 360);
            this.grid.TabIndex = 1;
            this.grid.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grid_UserDeletingRow);
            this.grid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grid_ColumnHeaderMouseClick);
            this.grid.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellMouseEnter);
            this.grid.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellEnter);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.checkColumnsResize);
            this.tabPage2.Controls.Add(this.checkDeleteWithoutAsking);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.checkUpdate);
            this.tabPage2.Controls.Add(this.checkDelete);
            this.tabPage2.Controls.Add(this.checkAdd);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(525, 366);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tùy chọn";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // checkColumnsResize
            // 
            this.checkColumnsResize.AutoSize = true;
            this.checkColumnsResize.Location = new System.Drawing.Point(21, 234);
            this.checkColumnsResize.Name = "checkColumnsResize";
            this.checkColumnsResize.Size = new System.Drawing.Size(145, 17);
            this.checkColumnsResize.TabIndex = 5;
            this.checkColumnsResize.Text = "Cho thay đổi bề rộng cột";
            this.checkColumnsResize.UseVisualStyleBackColor = true;
            this.checkColumnsResize.CheckedChanged += new System.EventHandler(this.checkColumnsResize_CheckedChanged);
            // 
            // checkDeleteWithoutAsking
            // 
            this.checkDeleteWithoutAsking.AutoSize = true;
            this.checkDeleteWithoutAsking.Location = new System.Drawing.Point(21, 211);
            this.checkDeleteWithoutAsking.Name = "checkDeleteWithoutAsking";
            this.checkDeleteWithoutAsking.Size = new System.Drawing.Size(113, 17);
            this.checkDeleteWithoutAsking.TabIndex = 4;
            this.checkDeleteWithoutAsking.Text = "Xóa không cần hỏi";
            this.checkDeleteWithoutAsking.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioVerbose);
            this.groupBox1.Controls.Add(this.radioSilent);
            this.groupBox1.Location = new System.Drawing.Point(21, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(517, 88);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chế độ hiển thị lỗi";
            // 
            // radioVerbose
            // 
            this.radioVerbose.AutoSize = true;
            this.radioVerbose.Checked = true;
            this.radioVerbose.Location = new System.Drawing.Point(19, 51);
            this.radioVerbose.Name = "radioVerbose";
            this.radioVerbose.Size = new System.Drawing.Size(287, 17);
            this.radioVerbose.TabIndex = 1;
            this.radioVerbose.TabStop = true;
            this.radioVerbose.Text = "Rõ ràng. Lỗi sẽ được hiển thị trong một hộp thoại riêng";
            this.radioVerbose.UseVisualStyleBackColor = true;
            // 
            // radioSilent
            // 
            this.radioSilent.AutoSize = true;
            this.radioSilent.Location = new System.Drawing.Point(19, 26);
            this.radioSilent.Name = "radioSilent";
            this.radioSilent.Size = new System.Drawing.Size(368, 17);
            this.radioSilent.TabIndex = 0;
            this.radioSilent.Text = "Thầm lặng. Chỉ có một dấu đỏ cho biết là có lỗi - tự động hủy các sai sót";
            this.radioSilent.UseVisualStyleBackColor = true;
            // 
            // checkUpdate
            // 
            this.checkUpdate.AutoSize = true;
            this.checkUpdate.Checked = true;
            this.checkUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkUpdate.Location = new System.Drawing.Point(21, 70);
            this.checkUpdate.Name = "checkUpdate";
            this.checkUpdate.Size = new System.Drawing.Size(114, 17);
            this.checkUpdate.TabIndex = 2;
            this.checkUpdate.Text = "Cho phép thay đổi";
            this.checkUpdate.UseVisualStyleBackColor = true;
            this.checkUpdate.CheckedChanged += new System.EventHandler(this.checkUpdate_CheckedChanged);
            // 
            // checkDelete
            // 
            this.checkDelete.AutoSize = true;
            this.checkDelete.Checked = true;
            this.checkDelete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkDelete.Location = new System.Drawing.Point(21, 45);
            this.checkDelete.Name = "checkDelete";
            this.checkDelete.Size = new System.Drawing.Size(93, 17);
            this.checkDelete.TabIndex = 1;
            this.checkDelete.Text = "Cho phép xóa";
            this.checkDelete.UseVisualStyleBackColor = true;
            this.checkDelete.CheckedChanged += new System.EventHandler(this.checkDelete_CheckedChanged);
            // 
            // checkAdd
            // 
            this.checkAdd.AutoSize = true;
            this.checkAdd.Checked = true;
            this.checkAdd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAdd.Location = new System.Drawing.Point(21, 20);
            this.checkAdd.Name = "checkAdd";
            this.checkAdd.Size = new System.Drawing.Size(99, 17);
            this.checkAdd.TabIndex = 0;
            this.checkAdd.Text = "Cho phép thêm";
            this.checkAdd.UseVisualStyleBackColor = true;
            this.checkAdd.CheckedChanged += new System.EventHandler(this.checkAddNew_CheckedChanged);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textInfo,
            this.dropdown,
            this.reorderButton,
            this.toolMore,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 394);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(526, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // textInfo
            // 
            this.textInfo.AutoSize = false;
            this.textInfo.Font = new System.Drawing.Font("Tahoma", 9F);
            this.textInfo.Name = "textInfo";
            this.textInfo.Size = new System.Drawing.Size(250, 22);
            this.textInfo.Leave += new System.EventHandler(this.textInfo_Leave);
            this.textInfo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textInfo_KeyUp);
            // 
            // dropdown
            // 
            this.dropdown.Image = global::MalystManager.Properties.Resources.OpenSelectedItemHS;
            this.dropdown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dropdown.Name = "dropdown";
            this.dropdown.Size = new System.Drawing.Size(64, 22);
            this.dropdown.Text = "Chọn";
            // 
            // reorderButton
            // 
            this.reorderButton.Image = ((System.Drawing.Image)(resources.GetObject("reorderButton.Image")));
            this.reorderButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.reorderButton.Name = "reorderButton";
            this.reorderButton.Size = new System.Drawing.Size(66, 22);
            this.reorderButton.Text = "Reorder";
            this.reorderButton.Visible = false;
            this.reorderButton.Click += new System.EventHandler(this.reorderButton_Click_1);
            // 
            // toolMore
            // 
            this.toolMore.Image = global::MalystManager.Properties.Resources.NewReportHS;
            this.toolMore.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolMore.Name = "toolMore";
            this.toolMore.Size = new System.Drawing.Size(78, 22);
            this.toolMore.Text = "Công cụ";
            this.toolMore.ToolTipText = "Các chức năng thêm";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::MalystManager.Properties.Resources.Help;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Trợ giúp";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // FormTableViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 419);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormTableViewer";
            this.Opacity = 0.75;
            this.ShowInTaskbar = false;
            this.Activated += new System.EventHandler(this.FormTableViewer_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTableViewer_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox checkAdd;
        private System.Windows.Forms.CheckBox checkDelete;
        private System.Windows.Forms.CheckBox checkUpdate;
        public System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioVerbose;
        public System.Windows.Forms.RadioButton radioSilent;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox textInfo;
        public System.Windows.Forms.ToolStripSplitButton dropdown;
        private System.Windows.Forms.ToolStripButton reorderButton;
        private System.Windows.Forms.CheckBox checkDeleteWithoutAsking;
        private System.Windows.Forms.ToolStripSplitButton toolMore;
        private System.Windows.Forms.CheckBox checkColumnsResize;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}