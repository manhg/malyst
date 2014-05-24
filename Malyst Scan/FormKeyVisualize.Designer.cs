namespace UI
{
    partial class FormKeyVisualize
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormKeyVisualize));
            this.gridVisual = new System.Windows.Forms.DataGridView();
            this.C1T20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.V1T20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C21T40 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.V21T40 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C41T60 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.V41T60 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C61T80 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.V61T80 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridVisual)).BeginInit();
            this.SuspendLayout();
            // 
            // gridVisual
            // 
            this.gridVisual.AllowUserToAddRows = false;
            this.gridVisual.AllowUserToDeleteRows = false;
            this.gridVisual.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.gridVisual.ColumnHeadersHeight = 20;
            this.gridVisual.ColumnHeadersVisible = false;
            this.gridVisual.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.C1T20,
            this.V1T20,
            this.C21T40,
            this.V21T40,
            this.C41T60,
            this.V41T60,
            this.C61T80,
            this.V61T80});
            this.gridVisual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridVisual.Location = new System.Drawing.Point(0, 0);
            this.gridVisual.MultiSelect = false;
            this.gridVisual.Name = "gridVisual";
            this.gridVisual.RowHeadersVisible = false;
            this.gridVisual.RowTemplate.Height = 20;
            this.gridVisual.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.gridVisual.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridVisual.ShowEditingIcon = false;
            this.gridVisual.ShowRowErrors = false;
            this.gridVisual.Size = new System.Drawing.Size(202, 464);
            this.gridVisual.TabIndex = 0;
            this.gridVisual.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridVisual_CellBeginEdit);
            this.gridVisual.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridVisual_CellEndEdit);
            // 
            // C1T20
            // 
            this.C1T20.HeaderText = "20";
            this.C1T20.Name = "C1T20";
            this.C1T20.Width = 20;
            // 
            // V1T20
            // 
            this.V1T20.HeaderText = "";
            this.V1T20.Name = "V1T20";
            this.V1T20.Width = 30;
            // 
            // C21T40
            // 
            this.C21T40.HeaderText = "40";
            this.C21T40.Name = "C21T40";
            this.C21T40.Width = 20;
            // 
            // V21T40
            // 
            this.V21T40.HeaderText = "";
            this.V21T40.Name = "V21T40";
            this.V21T40.Width = 30;
            // 
            // C41T60
            // 
            this.C41T60.HeaderText = "60";
            this.C41T60.Name = "C41T60";
            this.C41T60.Width = 20;
            // 
            // V41T60
            // 
            this.V41T60.HeaderText = "";
            this.V41T60.Name = "V41T60";
            this.V41T60.Width = 30;
            // 
            // C61T80
            // 
            this.C61T80.HeaderText = "80";
            this.C61T80.Name = "C61T80";
            this.C61T80.Width = 20;
            // 
            // V61T80
            // 
            this.V61T80.HeaderText = "";
            this.V61T80.Name = "V61T80";
            this.V61T80.Width = 30;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.AutoSize = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::UI.Properties.Resources.GoRtlHS;
            this.btnClose.Location = new System.Drawing.Point(91, 440);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(24, 24);
            this.btnClose.TabIndex = 1;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnClose, "Bạn có thể dùng số 1,2,3,4 thay vì A,B,C,D để nhập đáp án");
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ShowAlways = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Chỉ dẫn";
            // 
            // FormKeyVisualize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(202, 464);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gridVisual);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormKeyVisualize";
            this.ShowInTaskbar = false;
            this.Text = "Bo soan truc quan";
            this.toolTip1.SetToolTip(this, "Bạn có thể dùng số 1,2,3,4 thay vì A,B,C,D để nhập đáp án");
            this.Load += new System.EventHandler(this.FormKeyVisualize_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormKeyVisualize_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gridVisual)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridVisual;
        private System.Windows.Forms.DataGridViewTextBoxColumn C1T20;
        private System.Windows.Forms.DataGridViewTextBoxColumn V1T20;
        private System.Windows.Forms.DataGridViewTextBoxColumn C21T40;
        private System.Windows.Forms.DataGridViewTextBoxColumn V21T40;
        private System.Windows.Forms.DataGridViewTextBoxColumn C41T60;
        private System.Windows.Forms.DataGridViewTextBoxColumn V41T60;
        private System.Windows.Forms.DataGridViewTextBoxColumn C61T80;
        private System.Windows.Forms.DataGridViewTextBoxColumn V61T80;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}