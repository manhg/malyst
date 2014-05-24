namespace UI
{
    partial class FormGroups
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGroups));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkDirectChange = new System.Windows.Forms.CheckBox();
            this.txtStudentName = new System.Windows.Forms.TextBox();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.gridGroup = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pseudoSave = new System.Windows.Forms.Button();
            this.gridStudent = new System.Windows.Forms.DataGridView();
            this.colStudentNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolAdd = new System.Windows.Forms.ToolStripButton();
            this.toolClose = new System.Windows.Forms.ToolStripButton();
            this.toolSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolAutotext = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolTextFind = new System.Windows.Forms.ToolStripTextBox();
            this.groupBox1.SuspendLayout();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridStudent)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.checkDirectChange);
            this.groupBox1.Controls.Add(this.txtStudentName);
            this.groupBox1.Controls.Add(this.txtGroupName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 62);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thêm vào danh sách";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(131, 42);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(61, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Viết tắt";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Họ và tên học sinh:";
            // 
            // checkDirectChange
            // 
            this.checkDirectChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkDirectChange.AutoSize = true;
            this.checkDirectChange.Location = new System.Drawing.Point(131, 19);
            this.checkDirectChange.Name = "checkDirectChange";
            this.checkDirectChange.Size = new System.Drawing.Size(89, 17);
            this.checkDirectChange.TabIndex = 6;
            this.checkDirectChange.Text = "Sửa trực tiếp";
            this.toolTip.SetToolTip(this.checkDirectChange, "Đánh dấu ô này sẽ cho phép thay đổi nội dung của bảng các lớp\r\n và danh sách học " +
                    "sinh tương ứng. ");
            this.checkDirectChange.UseVisualStyleBackColor = true;
            this.checkDirectChange.CheckedChanged += new System.EventHandler(this.checkDirectChange_CheckedChanged);
            // 
            // txtStudentName
            // 
            this.txtStudentName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtStudentName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStudentName.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentName.Location = new System.Drawing.Point(225, 34);
            this.txtStudentName.Multiline = true;
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.Size = new System.Drawing.Size(259, 20);
            this.txtStudentName.TabIndex = 2;
            this.toolTip.SetToolTip(this.txtStudentName, "Nhấn Enter để thêm.\r\n Tên học sinh sẽ tự động được Viết Hoa khi đưa vào danh sách" +
                    "");
            this.txtStudentName.TextChanged += new System.EventHandler(this.txtStudentName_TextChanged);
            this.txtStudentName.Leave += new System.EventHandler(this.txtStudentName_Leave);
            // 
            // txtGroupName
            // 
            this.txtGroupName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGroupName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGroupName.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGroupName.Location = new System.Drawing.Point(12, 36);
            this.txtGroupName.Multiline = true;
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(100, 20);
            this.txtGroupName.TabIndex = 1;
            this.toolTip.SetToolTip(this.txtGroupName, "Nhấn Enter để thêm");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên lớp: ";
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainer.Location = new System.Drawing.Point(0, 103);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.gridGroup);
            this.splitContainer.Panel1.Controls.Add(this.pseudoSave);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.gridStudent);
            this.splitContainer.Size = new System.Drawing.Size(495, 278);
            this.splitContainer.SplitterDistance = 201;
            this.splitContainer.TabIndex = 7;
            // 
            // gridGroup
            // 
            this.gridGroup.AllowUserToAddRows = false;
            this.gridGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridGroup.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridGroup.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.gridGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.gridGroup.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridGroup.Location = new System.Drawing.Point(0, 3);
            this.gridGroup.MultiSelect = false;
            this.gridGroup.Name = "gridGroup";
            this.gridGroup.ReadOnly = true;
            this.gridGroup.RowHeadersVisible = false;
            this.gridGroup.RowHeadersWidth = 15;
            this.gridGroup.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.gridGroup.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.gridGroup.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridGroup.Size = new System.Drawing.Size(201, 275);
            this.gridGroup.TabIndex = 2;
            this.toolTip.SetToolTip(this.gridGroup, "Để sửa nội dung bạn phải chọn ô sửa trực tiếp ở dưới. \r\nBấm đúp (double-click) nộ" +
                    "i dung để sửa. Nhấn Delete để xóa.\r\nĐể thêm vào danh sách bạn sử dụng các ô ở ph" +
                    "ía dưới");
            this.gridGroup.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridGroup_CellValueChanged);
            this.gridGroup.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.gridGroup_UserDeletingRow);
            this.gridGroup.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridGroup_RowEnter);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Lớp";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Mã lớp";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // pseudoSave
            // 
            this.pseudoSave.Location = new System.Drawing.Point(12, 3);
            this.pseudoSave.Name = "pseudoSave";
            this.pseudoSave.Size = new System.Drawing.Size(72, 22);
            this.pseudoSave.TabIndex = 8;
            this.pseudoSave.Text = "pseudoSave";
            this.pseudoSave.UseVisualStyleBackColor = true;
            this.pseudoSave.Click += new System.EventHandler(this.pseudoSave_Click);
            // 
            // gridStudent
            // 
            this.gridStudent.AllowUserToAddRows = false;
            this.gridStudent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridStudent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridStudent.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.gridStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridStudent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStudentNo,
            this.colStudentName});
            this.gridStudent.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridStudent.Location = new System.Drawing.Point(0, 3);
            this.gridStudent.Name = "gridStudent";
            this.gridStudent.ReadOnly = true;
            this.gridStudent.RowHeadersVisible = false;
            this.gridStudent.RowHeadersWidth = 15;
            this.gridStudent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridStudent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridStudent.Size = new System.Drawing.Size(290, 275);
            this.gridStudent.TabIndex = 3;
            this.gridStudent.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridStudent_CellValueChanged);
            this.gridStudent.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.gridStudent_SortCompare);
            // 
            // colStudentNo
            // 
            this.colStudentNo.HeaderText = "MHS";
            this.colStudentNo.Name = "colStudentNo";
            this.colStudentNo.ReadOnly = true;
            this.colStudentNo.Width = 50;
            // 
            // colStudentName
            // 
            this.colStudentName.HeaderText = "Họ và tên";
            this.colStudentName.Name = "colStudentName";
            this.colStudentName.ReadOnly = true;
            this.colStudentName.ToolTipText = "Nhấn vào để sắp xếp lại";
            this.colStudentName.Width = 200;
            // 
            // toolTip
            // 
            this.toolTip.IsBalloon = true;
            this.toolTip.ShowAlways = true;
            this.toolTip.ToolTipTitle = "Chỉ dẫn";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAdd,
            this.toolClose,
            this.toolSave,
            this.toolStripSeparator,
            this.toolAutotext,
            this.toolStripSeparator1,
            this.toolTextFind});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(495, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolAdd
            // 
            this.toolAdd.Image = global::UI.Properties.Resources.newFolder;
            this.toolAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAdd.Name = "toolAdd";
            this.toolAdd.Size = new System.Drawing.Size(53, 22);
            this.toolAdd.Text = "Thêm";
            this.toolAdd.Click += new System.EventHandler(this.toolAdd_Click);
            // 
            // toolClose
            // 
            this.toolClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolClose.Image = global::UI.Properties.Resources.HomeHS;
            this.toolClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolClose.Name = "toolClose";
            this.toolClose.Size = new System.Drawing.Size(53, 22);
            this.toolClose.Text = "Đóng";
            this.toolClose.Click += new System.EventHandler(this.toolClose_Click);
            // 
            // toolSave
            // 
            this.toolSave.Image = ((System.Drawing.Image)(resources.GetObject("toolSave.Image")));
            this.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSave.Name = "toolSave";
            this.toolSave.Size = new System.Drawing.Size(45, 22);
            this.toolSave.Text = "Lưu";
            this.toolSave.Click += new System.EventHandler(this.toolSave_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // toolAutotext
            // 
            this.toolAutotext.Enabled = false;
            this.toolAutotext.Image = ((System.Drawing.Image)(resources.GetObject("toolAutotext.Image")));
            this.toolAutotext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAutotext.Name = "toolAutotext";
            this.toolAutotext.Size = new System.Drawing.Size(62, 22);
            this.toolAutotext.Text = "Viết tắt";
            this.toolAutotext.Click += new System.EventHandler(this.toolAutotext_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolTextFind
            // 
            this.toolTextFind.Enabled = false;
            this.toolTextFind.Name = "toolTextFind";
            this.toolTextFind.Size = new System.Drawing.Size(100, 25);
            this.toolTextFind.Text = "Tìm kiếm";
            // 
            // FormGroups
            // 
            this.AcceptButton = this.pseudoSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 381);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormGroups";
            this.ShowInTaskbar = false;
            this.Text = "Lop hoc va hoc sinh";
            this.Load += new System.EventHandler(this.FormGroups_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGroups_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridStudent)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStudentName;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkDirectChange;
        private System.Windows.Forms.SplitContainer splitContainer;
        public System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolAdd;
        private System.Windows.Forms.ToolStripButton toolClose;
        private System.Windows.Forms.ToolStripButton toolSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton toolAutotext;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox toolTextFind;
        private System.Windows.Forms.DataGridView gridGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridView gridStudent;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button pseudoSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStudentNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStudentName;


    }
}