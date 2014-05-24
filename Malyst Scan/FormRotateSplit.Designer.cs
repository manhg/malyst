namespace UI
{
    partial class FormRotateSplit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRotateSplit));
            this.btnWork = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.checkAutoInterpret = new System.Windows.Forms.CheckBox();
            this.txtSrc = new System.Windows.Forms.TextBox();
            this.txtDest = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowSrc = new System.Windows.Forms.Button();
            this.btnBrowseDest = new System.Windows.Forms.Button();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.checkAutoDest = new System.Windows.Forms.CheckBox();
            this.groupIllustrate = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.r_split = new System.Windows.Forms.PictureBox();
            this.cropBox = new System.Windows.Forms.ComboBox();
            this.r_dest = new System.Windows.Forms.PictureBox();
            this.rotateBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.r_src = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupLog = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.groupIllustrate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.r_split)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.r_dest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.r_src)).BeginInit();
            this.groupLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnWork
            // 
            this.btnWork.Location = new System.Drawing.Point(256, 283);
            this.btnWork.Name = "btnWork";
            this.btnWork.Size = new System.Drawing.Size(75, 23);
            this.btnWork.TabIndex = 2;
            this.btnWork.Text = "Thực hiện";
            this.btnWork.UseVisualStyleBackColor = true;
            this.btnWork.Click += new System.EventHandler(this.btnWork_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(341, 283);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // checkAutoInterpret
            // 
            this.checkAutoInterpret.AutoSize = true;
            this.checkAutoInterpret.Enabled = false;
            this.checkAutoInterpret.Location = new System.Drawing.Point(4, 240);
            this.checkAutoInterpret.Name = "checkAutoInterpret";
            this.checkAutoInterpret.Size = new System.Drawing.Size(197, 17);
            this.checkAutoInterpret.TabIndex = 4;
            this.checkAutoInterpret.Text = "Tự động chấm điểm dữ liệu đưa vào";
            this.checkAutoInterpret.UseVisualStyleBackColor = true;
            // 
            // txtSrc
            // 
            this.txtSrc.Location = new System.Drawing.Point(139, 188);
            this.txtSrc.Name = "txtSrc";
            this.txtSrc.ReadOnly = true;
            this.txtSrc.Size = new System.Drawing.Size(173, 21);
            this.txtSrc.TabIndex = 5;
            // 
            // txtDest
            // 
            this.txtDest.Location = new System.Drawing.Point(139, 214);
            this.txtDest.Name = "txtDest";
            this.txtDest.ReadOnly = true;
            this.txtDest.Size = new System.Drawing.Size(173, 21);
            this.txtDest.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Thư mục chứa ảnh nguồn:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Thư mục lưu kết quả:";
            // 
            // btnBrowSrc
            // 
            this.btnBrowSrc.Location = new System.Drawing.Point(318, 185);
            this.btnBrowSrc.Name = "btnBrowSrc";
            this.btnBrowSrc.Size = new System.Drawing.Size(97, 23);
            this.btnBrowSrc.TabIndex = 7;
            this.btnBrowSrc.Text = "Duyệt thư mục";
            this.btnBrowSrc.UseVisualStyleBackColor = true;
            this.btnBrowSrc.Click += new System.EventHandler(this.btnBrowSrc_Click);
            // 
            // btnBrowseDest
            // 
            this.btnBrowseDest.Location = new System.Drawing.Point(319, 214);
            this.btnBrowseDest.Name = "btnBrowseDest";
            this.btnBrowseDest.Size = new System.Drawing.Size(97, 23);
            this.btnBrowseDest.TabIndex = 7;
            this.btnBrowseDest.Text = "Duyệt thư mục";
            this.btnBrowseDest.UseVisualStyleBackColor = true;
            this.btnBrowseDest.Click += new System.EventHandler(this.btnBrowseDest_Click);
            // 
            // folderBrowser
            // 
            this.folderBrowser.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // checkAutoDest
            // 
            this.checkAutoDest.AutoSize = true;
            this.checkAutoDest.Checked = true;
            this.checkAutoDest.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAutoDest.Location = new System.Drawing.Point(4, 260);
            this.checkAutoDest.Name = "checkAutoDest";
            this.checkAutoDest.Size = new System.Drawing.Size(272, 17);
            this.checkAutoDest.TabIndex = 9;
            this.checkAutoDest.Text = "Chuyển kết quả đến mặc định trong thư mục nguồn";
            this.checkAutoDest.UseVisualStyleBackColor = true;
            // 
            // groupIllustrate
            // 
            this.groupIllustrate.Controls.Add(this.label7);
            this.groupIllustrate.Controls.Add(this.label6);
            this.groupIllustrate.Controls.Add(this.r_split);
            this.groupIllustrate.Controls.Add(this.cropBox);
            this.groupIllustrate.Controls.Add(this.r_dest);
            this.groupIllustrate.Controls.Add(this.rotateBox);
            this.groupIllustrate.Controls.Add(this.label4);
            this.groupIllustrate.Controls.Add(this.r_src);
            this.groupIllustrate.Controls.Add(this.label3);
            this.groupIllustrate.Location = new System.Drawing.Point(4, 5);
            this.groupIllustrate.Name = "groupIllustrate";
            this.groupIllustrate.Size = new System.Drawing.Size(422, 187);
            this.groupIllustrate.TabIndex = 0;
            this.groupIllustrate.TabStop = false;
            this.groupIllustrate.Text = "Minh họa";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(220, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Kết quả:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Ảnh gốc:";
            // 
            // r_split
            // 
            this.r_split.Location = new System.Drawing.Point(289, 60);
            this.r_split.Name = "r_split";
            this.r_split.Size = new System.Drawing.Size(123, 117);
            this.r_split.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.r_split.TabIndex = 15;
            this.r_split.TabStop = false;
            // 
            // cropBox
            // 
            this.cropBox.Location = new System.Drawing.Point(289, 33);
            this.cropBox.Name = "cropBox";
            this.cropBox.Size = new System.Drawing.Size(123, 21);
            this.cropBox.TabIndex = 13;
            this.cropBox.SelectedIndexChanged += new System.EventHandler(this.cropBox_SelectedIndexChanged);
            // 
            // r_dest
            // 
            this.r_dest.Image = global::UI.Properties.Resources.rs_dest;
            this.r_dest.Location = new System.Drawing.Point(149, 94);
            this.r_dest.Name = "r_dest";
            this.r_dest.Size = new System.Drawing.Size(65, 83);
            this.r_dest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.r_dest.TabIndex = 1;
            this.r_dest.TabStop = false;
            // 
            // rotateBox
            // 
            this.rotateBox.FormattingEnabled = true;
            this.rotateBox.Location = new System.Drawing.Point(149, 57);
            this.rotateBox.Name = "rotateBox";
            this.rotateBox.Size = new System.Drawing.Size(83, 21);
            this.rotateBox.TabIndex = 14;
            this.rotateBox.SelectedValueChanged += new System.EventHandler(this.rotateBox_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(259, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Cắt đôi (với ảnh sau khi quay)";
            // 
            // r_src
            // 
            this.r_src.Image = global::UI.Properties.Resources.rs_dest;
            this.r_src.Location = new System.Drawing.Point(14, 36);
            this.r_src.Name = "r_src";
            this.r_src.Size = new System.Drawing.Size(116, 141);
            this.r_src.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.r_src.TabIndex = 0;
            this.r_src.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(146, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Quay góc (đơn vị độ) :";
            // 
            // groupLog
            // 
            this.groupLog.Controls.Add(this.txtLog);
            this.groupLog.Controls.Add(this.progressBar);
            this.groupLog.Location = new System.Drawing.Point(12, 293);
            this.groupLog.Name = "groupLog";
            this.groupLog.Size = new System.Drawing.Size(437, 194);
            this.groupLog.TabIndex = 10;
            this.groupLog.TabStop = false;
            this.groupLog.Text = " Tốc ký";
            this.groupLog.Visible = false;
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.SystemColors.Info;
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLog.Location = new System.Drawing.Point(6, 19);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(423, 153);
            this.txtLog.TabIndex = 1;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(6, 178);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(425, 10);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 0;
            // 
            // FormRotateSplit
            // 
            this.AcceptButton = this.btnWork;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(430, 312);
            this.Controls.Add(this.groupLog);
            this.Controls.Add(this.checkAutoDest);
            this.Controls.Add(this.btnBrowseDest);
            this.Controls.Add(this.btnBrowSrc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDest);
            this.Controls.Add(this.txtSrc);
            this.Controls.Add(this.checkAutoInterpret);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnWork);
            this.Controls.Add(this.groupIllustrate);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRotateSplit";
            this.ShowInTaskbar = false;
            this.Text = "Xoay & cat anh";
            this.Load += new System.EventHandler(this.FormRotateSplit_Load);
            this.groupIllustrate.ResumeLayout(false);
            this.groupIllustrate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.r_split)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.r_dest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.r_src)).EndInit();
            this.groupLog.ResumeLayout(false);
            this.groupLog.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWork;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox checkAutoInterpret;
        private System.Windows.Forms.TextBox txtSrc;
        private System.Windows.Forms.TextBox txtDest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowSrc;
        private System.Windows.Forms.Button btnBrowseDest;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.CheckBox checkAutoDest;
        private System.Windows.Forms.GroupBox groupIllustrate;
        private System.Windows.Forms.GroupBox groupLog;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cropBox;
        private System.Windows.Forms.ComboBox rotateBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox r_src;
        private System.Windows.Forms.PictureBox r_dest;
        private System.Windows.Forms.PictureBox r_split;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}