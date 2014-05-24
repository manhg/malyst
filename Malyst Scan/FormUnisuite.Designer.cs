namespace UI
{
    partial class FormUnisuite
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUnisuite));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridUnisuite = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolEdit = new System.Windows.Forms.ToolStripButton();
            this.toolRemove = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBtnSelect = new System.Windows.Forms.ToolStripButton();
            this.toolMoreInfo = new System.Windows.Forms.ToolStripButton();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridUnisuite)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridUnisuite
            // 
            this.gridUnisuite.AllowUserToAddRows = false;
            this.gridUnisuite.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridUnisuite.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridUnisuite.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridUnisuite.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnDescription});
            this.gridUnisuite.Location = new System.Drawing.Point(0, 28);
            this.gridUnisuite.MultiSelect = false;
            this.gridUnisuite.Name = "gridUnisuite";
            this.gridUnisuite.ReadOnly = true;
            this.gridUnisuite.RowHeadersVisible = false;
            this.gridUnisuite.RowTemplate.Height = 20;
            this.gridUnisuite.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridUnisuite.ShowCellErrors = false;
            this.gridUnisuite.ShowEditingIcon = false;
            this.gridUnisuite.ShowRowErrors = false;
            this.gridUnisuite.Size = new System.Drawing.Size(471, 287);
            this.gridUnisuite.TabIndex = 0;
            this.gridUnisuite.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridUnisuite_CellDoubleClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.toolStripSeparator,
            this.toolEdit,
            this.toolRemove,
            this.toolStripSeparator1,
            this.toolBtnSelect,
            this.toolMoreInfo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(471, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(64, 22);
            this.newToolStripButton.Text = "Tạo mới";
            this.newToolStripButton.Click += new System.EventHandler(this.newToolStripButton_Click);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(44, 22);
            this.openToolStripButton.Text = "Mở ";
            this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // toolEdit
            // 
            this.toolEdit.Enabled = false;
            this.toolEdit.Image = ((System.Drawing.Image)(resources.GetObject("toolEdit.Image")));
            this.toolEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolEdit.Name = "toolEdit";
            this.toolEdit.Size = new System.Drawing.Size(76, 22);
            this.toolEdit.Text = "Hiệu chỉnh";
            // 
            // toolRemove
            // 
            this.toolRemove.Enabled = false;
            this.toolRemove.Image = ((System.Drawing.Image)(resources.GetObject("toolRemove.Image")));
            this.toolRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolRemove.Name = "toolRemove";
            this.toolRemove.Size = new System.Drawing.Size(61, 22);
            this.toolRemove.Text = "Loại bỏ";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolBtnSelect
            // 
            this.toolBtnSelect.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnSelect.Image")));
            this.toolBtnSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnSelect.Name = "toolBtnSelect";
            this.toolBtnSelect.Size = new System.Drawing.Size(52, 22);
            this.toolBtnSelect.Text = "Chọn";
            this.toolBtnSelect.ToolTipText = "Trong bảng các bộ đáp án, có thể nhấn đúp để chọn trực tiếp trên đó.";
            this.toolBtnSelect.Click += new System.EventHandler(this.toolBtnSelect_Click);
            // 
            // toolMoreInfo
            // 
            this.toolMoreInfo.Image = ((System.Drawing.Image)(resources.GetObject("toolMoreInfo.Image")));
            this.toolMoreInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolMoreInfo.Name = "toolMoreInfo";
            this.toolMoreInfo.Size = new System.Drawing.Size(99, 22);
            this.toolMoreInfo.Text = "Thông tin thêm";
            this.toolMoreInfo.Click += new System.EventHandler(this.toolMoreInfo_Click);
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Tên bộ đáp án";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            this.ColumnName.Width = 170;
            // 
            // ColumnDescription
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            this.ColumnDescription.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnDescription.HeaderText = "Mô tả";
            this.ColumnDescription.Name = "ColumnDescription";
            this.ColumnDescription.ReadOnly = true;
            this.ColumnDescription.Width = 300;
            // 
            // FormUnisuite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 315);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.gridUnisuite);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormUnisuite";
            this.ShowInTaskbar = false;
            this.Text = "Cac bo dap an";
            this.Load += new System.EventHandler(this.FormUnisuite_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormUnisuite_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gridUnisuite)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridUnisuite;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton toolBtnSelect;
        private System.Windows.Forms.ToolStripButton toolEdit;
        private System.Windows.Forms.ToolStripButton toolRemove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton toolMoreInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDescription;
    }
}