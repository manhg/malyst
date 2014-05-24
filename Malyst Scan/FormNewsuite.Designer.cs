namespace UI
{
    partial class FormNewsuite
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Ngoại ngữ");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Vật lý");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Hóa học");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Sinh học");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("Toán");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("Địa lý");
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("Lịch sử");
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("Tin học");
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("GDCD");
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("Tự chọn");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewsuite));
            this.label2 = new System.Windows.Forms.Label();
            this.numQuestions = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numWrongMark = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.gridProblems = new System.Windows.Forms.DataGridView();
            this.colProblem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGenerateCode = new System.Windows.Forms.Button();
            this.numProblem = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listSubject = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioDirect = new System.Windows.Forms.RadioButton();
            this.radioVisual = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.trackTestPortion = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblPortion = new System.Windows.Forms.Label();
            this.btnVisual = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numQuestions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWrongMark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProblems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProblem)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackTestPortion)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Số câu hỏi:";
            // 
            // numQuestions
            // 
            this.numQuestions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numQuestions.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numQuestions.Location = new System.Drawing.Point(70, 16);
            this.numQuestions.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.numQuestions.Name = "numQuestions";
            this.numQuestions.Size = new System.Drawing.Size(58, 16);
            this.numQuestions.TabIndex = 0;
            this.numQuestions.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numQuestions.Enter += new System.EventHandler(this.numQuestions_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Điểm trừ:";
            this.label3.Visible = false;
            // 
            // numWrongMark
            // 
            this.numWrongMark.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numWrongMark.DecimalPlaces = 2;
            this.numWrongMark.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numWrongMark.Location = new System.Drawing.Point(70, 42);
            this.numWrongMark.Name = "numWrongMark";
            this.numWrongMark.Size = new System.Drawing.Size(58, 16);
            this.numWrongMark.TabIndex = 1;
            this.numWrongMark.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 5;
            // 
            // gridProblems
            // 
            this.gridProblems.AllowUserToOrderColumns = true;
            this.gridProblems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridProblems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridProblems.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.gridProblems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridProblems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProblem,
            this.colKey});
            this.gridProblems.Location = new System.Drawing.Point(7, 172);
            this.gridProblems.Name = "gridProblems";
            this.gridProblems.RowHeadersVisible = false;
            this.gridProblems.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridProblems.RowTemplate.ErrorText = "Dữ liệu không đúng";
            this.gridProblems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridProblems.Size = new System.Drawing.Size(395, 134);
            this.gridProblems.TabIndex = 5;
            this.gridProblems.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridProblems_CellDoubleClick);
            this.gridProblems.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridProblems_CellEndEdit);
            this.gridProblems.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gridProblems_DataError);
            this.gridProblems.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridProblems_CellEnter);
            this.gridProblems.Resize += new System.EventHandler(this.gridProblems_Resize);
            // 
            // colProblem
            // 
            this.colProblem.HeaderText = "Mã đề";
            this.colProblem.MaxInputLength = 10;
            this.colProblem.Name = "colProblem";
            this.colProblem.Width = 70;
            // 
            // colKey
            // 
            this.colKey.HeaderText = "Đáp án";
            this.colKey.Name = "colKey";
            this.colKey.ToolTipText = "Nhấn đúp (double-click) để vào chế độ nhập trực quan";
            this.colKey.Width = 300;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "key.xml";
            this.saveFileDialog.SupportMultiDottedExtensions = true;
            this.saveFileDialog.Title = "Đặt tên và chỗ cho bộ đáp án";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::UI.Properties.Resources.saveHS;
            this.btnSave.Location = new System.Drawing.Point(242, 321);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(74, 24);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "&Lưu";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::UI.Properties.Resources.GoRtlHS;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnCancel.Location = new System.Drawing.Point(322, 322);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(69, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Info;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(262, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 139);
            this.label5.TabIndex = 12;
            this.label5.Text = "Ghi chú:\r\n- Có thể sinh mã mà không cần chọn môn.\r\n- Sau khi sinh mã, cần điền đầ" +
                "y đủ đáp án.\r\n- Tổng điểm = Điểm - Số câu sai * Điểm trừ.\r\n- Có thể nhấn đúp vào" +
                " ô đáp án để mở bộ soạn trực quan";
            // 
            // btnGenerateCode
            // 
            this.btnGenerateCode.Image = global::UI.Properties.Resources.BarCodeHS;
            this.btnGenerateCode.Location = new System.Drawing.Point(160, 145);
            this.btnGenerateCode.Name = "btnGenerateCode";
            this.btnGenerateCode.Size = new System.Drawing.Size(88, 23);
            this.btnGenerateCode.TabIndex = 4;
            this.btnGenerateCode.Text = "&Sinh mã đề";
            this.btnGenerateCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerateCode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGenerateCode.UseVisualStyleBackColor = true;
            this.btnGenerateCode.Click += new System.EventHandler(this.btnGenerateCode_Click);
            // 
            // numProblem
            // 
            this.numProblem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numProblem.Location = new System.Drawing.Point(7, 80);
            this.numProblem.Name = "numProblem";
            this.numProblem.Size = new System.Drawing.Size(53, 16);
            this.numProblem.TabIndex = 3;
            this.numProblem.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numProblem.Enter += new System.EventHandler(this.numProblem_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Số lượng đề:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 12;
            // 
            // listSubject
            // 
            this.listSubject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listSubject.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listSubject.HideSelection = false;
            listViewItem1.Tag = "1";
            listViewItem1.ToolTipText = "NN";
            listViewItem2.Tag = "12";
            listViewItem2.ToolTipText = "Lý";
            listViewItem3.Tag = "13";
            listViewItem3.ToolTipText = "Hoá";
            listViewItem4.Tag = "14";
            listViewItem4.ToolTipText = "Sinh";
            listViewItem5.Tag = "2";
            listViewItem5.ToolTipText = "Toán";
            listViewItem6.Tag = "23";
            listViewItem6.ToolTipText = "Địa";
            listViewItem7.Tag = "24";
            listViewItem7.ToolTipText = "Sử";
            listViewItem8.Tag = "3";
            listViewItem8.ToolTipText = "Tin";
            listViewItem9.Tag = "34";
            listViewItem9.ToolTipText = "GDCD";
            listViewItem10.Tag = "4";
            listViewItem10.ToolTipText = "TC";
            this.listSubject.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10});
            this.listSubject.Location = new System.Drawing.Point(160, 16);
            this.listSubject.MultiSelect = false;
            this.listSubject.Name = "listSubject";
            this.listSubject.Size = new System.Drawing.Size(96, 123);
            this.listSubject.TabIndex = 2;
            this.listSubject.UseCompatibleStateImageBehavior = false;
            this.listSubject.View = System.Windows.Forms.View.Tile;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Môn";
            this.columnHeader1.Width = 109;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioDirect);
            this.groupBox1.Controls.Add(this.radioVisual);
            this.groupBox1.Location = new System.Drawing.Point(14, 106);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(130, 60);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kiểu nhập đáp án";
            // 
            // radioDirect
            // 
            this.radioDirect.AutoSize = true;
            this.radioDirect.Checked = true;
            this.radioDirect.Location = new System.Drawing.Point(8, 35);
            this.radioDirect.Name = "radioDirect";
            this.radioDirect.Size = new System.Drawing.Size(68, 17);
            this.radioDirect.TabIndex = 1;
            this.radioDirect.TabStop = true;
            this.radioDirect.Text = "Trực tiếp";
            this.radioDirect.UseVisualStyleBackColor = true;
            // 
            // radioVisual
            // 
            this.radioVisual.AutoSize = true;
            this.radioVisual.Location = new System.Drawing.Point(8, 16);
            this.radioVisual.Name = "radioVisual";
            this.radioVisual.Size = new System.Drawing.Size(74, 17);
            this.radioVisual.TabIndex = 0;
            this.radioVisual.Text = "Trực quan";
            this.radioVisual.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(95, 426);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 13);
            this.label7.TabIndex = 15;
            // 
            // trackTestPortion
            // 
            this.trackTestPortion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trackTestPortion.AutoSize = false;
            this.trackTestPortion.LargeChange = 10;
            this.trackTestPortion.Location = new System.Drawing.Point(92, 324);
            this.trackTestPortion.Maximum = 100;
            this.trackTestPortion.Name = "trackTestPortion";
            this.trackTestPortion.Size = new System.Drawing.Size(97, 19);
            this.trackTestPortion.SmallChange = 5;
            this.trackTestPortion.TabIndex = 6;
            this.trackTestPortion.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackTestPortion.Value = 50;
            this.trackTestPortion.Scroll += new System.EventHandler(this.trackTestPortion_Scroll);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(195, 325);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Tự luận";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 325);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Trắc nghiệm";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 309);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Thang điểm: ";
            // 
            // lblPortion
            // 
            this.lblPortion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPortion.AutoSize = true;
            this.lblPortion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPortion.Location = new System.Drawing.Point(97, 309);
            this.lblPortion.Name = "lblPortion";
            this.lblPortion.Size = new System.Drawing.Size(105, 13);
            this.lblPortion.TabIndex = 20;
            this.lblPortion.Text = "50% trắc nghiệm";
            // 
            // btnVisual
            // 
            this.btnVisual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVisual.Image = global::UI.Properties.Resources.ZoomHS;
            this.btnVisual.Location = new System.Drawing.Point(337, 139);
            this.btnVisual.Name = "btnVisual";
            this.btnVisual.Size = new System.Drawing.Size(34, 24);
            this.btnVisual.TabIndex = 14;
            this.btnVisual.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVisual.UseVisualStyleBackColor = true;
            this.btnVisual.Click += new System.EventHandler(this.btnVisual_Click);
            // 
            // FormNewsuite
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(407, 351);
            this.Controls.Add(this.lblPortion);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.trackTestPortion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnVisual);
            this.Controls.Add(this.listSubject);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.numProblem);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnGenerateCode);
            this.Controls.Add(this.gridProblems);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numWrongMark);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numQuestions);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewsuite";
            this.ShowInTaskbar = false;
            this.Text = "Tao bo dap an";
            ((System.ComponentModel.ISupportInitialize)(this.numQuestions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWrongMark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProblems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProblem)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackTestPortion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numQuestions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numWrongMark;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView gridProblems;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnGenerateCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numProblem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView listSubject;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioVisual;
        private System.Windows.Forms.RadioButton radioDirect;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar trackTestPortion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblPortion;
        private System.Windows.Forms.Button btnVisual;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProblem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKey;
    }
}