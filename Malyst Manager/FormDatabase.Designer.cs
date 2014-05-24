namespace MalystManager
{
    partial class FormDatabase
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tTeacher = new System.Windows.Forms.DataGridView();
            this.tGroup = new System.Windows.Forms.DataGridView();
            this.tMark = new System.Windows.Forms.DataGridView();
            this.tStudent = new System.Windows.Forms.DataGridView();
            this.tCourse = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tTeacher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tMark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tStudent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tCourse)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(784, 527);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Data";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.tCourse, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tStudent, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tMark, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tGroup, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.tTeacher, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.81818F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.18182F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(778, 521);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tTeacher
            // 
            this.tTeacher.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tTeacher.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tTeacher.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.tTeacher.ColumnHeadersHeight = 22;
            this.tTeacher.Location = new System.Drawing.Point(547, 3);
            this.tTeacher.Name = "tTeacher";
            this.tTeacher.RowHeadersWidth = 10;
            this.tTeacher.Size = new System.Drawing.Size(228, 159);
            this.tTeacher.TabIndex = 4;
            // 
            // tGroup
            // 
            this.tGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tGroup.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tGroup.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.tGroup.ColumnHeadersHeight = 22;
            this.tGroup.Location = new System.Drawing.Point(547, 168);
            this.tGroup.Name = "tGroup";
            this.tGroup.RowHeadersWidth = 10;
            this.tGroup.Size = new System.Drawing.Size(228, 350);
            this.tGroup.TabIndex = 0;
            // 
            // tMark
            // 
            this.tMark.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tMark.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tMark.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.tMark.ColumnHeadersHeight = 22;
            this.tMark.Location = new System.Drawing.Point(314, 3);
            this.tMark.Name = "tMark";
            this.tMark.RowHeadersWidth = 10;
            this.tableLayoutPanel1.SetRowSpan(this.tMark, 2);
            this.tMark.Size = new System.Drawing.Size(227, 515);
            this.tMark.TabIndex = 2;
            // 
            // tStudent
            // 
            this.tStudent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tStudent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tStudent.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.tStudent.ColumnHeadersHeight = 22;
            this.tStudent.Location = new System.Drawing.Point(3, 168);
            this.tStudent.Name = "tStudent";
            this.tStudent.RowHeadersWidth = 10;
            this.tStudent.Size = new System.Drawing.Size(305, 350);
            this.tStudent.TabIndex = 1;
            // 
            // tCourse
            // 
            this.tCourse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tCourse.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tCourse.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.tCourse.ColumnHeadersHeight = 22;
            this.tCourse.Location = new System.Drawing.Point(3, 3);
            this.tCourse.Name = "tCourse";
            this.tCourse.RowHeadersWidth = 10;
            this.tCourse.Size = new System.Drawing.Size(305, 159);
            this.tCourse.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(792, 553);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(784, 527);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Option";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // FormDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 553);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormDatabase";
            this.ShowInTaskbar = false;
            this.Text = "FormDatabase";
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tTeacher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tMark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tStudent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tCourse)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView tCourse;
        private System.Windows.Forms.DataGridView tStudent;
        private System.Windows.Forms.DataGridView tMark;
        private System.Windows.Forms.DataGridView tGroup;
        private System.Windows.Forms.DataGridView tTeacher;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;


    }
}