namespace UI
{
	partial class FormGetStarted
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGetStarted));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.btnClose = new System.Windows.Forms.Button();
			this.linkNewsuite = new System.Windows.Forms.LinkLabel();
			this.linkInterpret = new System.Windows.Forms.LinkLabel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::UI.Properties.Resources.logo;
			this.pictureBox1.Location = new System.Drawing.Point(12, 107);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(346, 208);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(546, 3);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(67, 23);
			this.btnClose.TabIndex = 1;
			this.btnClose.Text = "Đóng";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// linkNewsuite
			// 
			this.linkNewsuite.AutoSize = true;
			this.linkNewsuite.Location = new System.Drawing.Point(414, 126);
			this.linkNewsuite.Name = "linkNewsuite";
			this.linkNewsuite.Size = new System.Drawing.Size(78, 13);
			this.linkNewsuite.TabIndex = 2;
			this.linkNewsuite.TabStop = true;
			this.linkNewsuite.Text = "Tạo bộ đáp án";
			this.linkNewsuite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkNewsuite_LinkClicked);
			// 
			// linkInterpret
			// 
			this.linkInterpret.AutoSize = true;
			this.linkInterpret.Location = new System.Drawing.Point(414, 151);
			this.linkInterpret.Name = "linkInterpret";
			this.linkInterpret.Size = new System.Drawing.Size(60, 13);
			this.linkInterpret.TabIndex = 3;
			this.linkInterpret.TabStop = true;
			this.linkInterpret.Text = "Chấm điểm";
			this.linkInterpret.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkInterpret_LinkClicked);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(393, 107);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(86, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Thao tác nhanh:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(406, 78);
			this.label2.TabIndex = 5;
			this.label2.Text = resources.GetString("label2.Text");
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 389);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(113, 26);
			this.label3.TabIndex = 6;
			this.label3.Text = "Malyst Assistant Beta\r\nPhiên bản thử nghiệm.";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 332);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(374, 39);
			this.label4.TabIndex = 7;
			this.label4.Text = resources.GetString("label4.Text");
			// 
			// FormGetStarted
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.ClientSize = new System.Drawing.Size(616, 424);
			this.ControlBox = false;
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.linkInterpret);
			this.Controls.Add(this.linkNewsuite);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "FormGetStarted";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = " ";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.LinkLabel linkNewsuite;
		private System.Windows.Forms.LinkLabel linkInterpret;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
	}
}