using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class FormRotateSplit : Form
    {
        public FormRotateSplit()
        {
            InitializeComponent();
            List<string> crop = new List<string> { "Không cắt","Cắt ngang", "Cắt dọc" };
            List<int> rotate = new List<int> { 0, 90, 180, 270 };
            cropBox.DataSource = crop;
            rotateBox.DataSource = rotate;
        }

        private void radioH180_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioH_CheckedChanged(object sender, EventArgs e)
        {            
        }

        private void radioV90ACW_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioV90CW_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void btnBrowSrc_Click(object sender, EventArgs e)
        {
            folderBrowser.SelectedPath = "";
            folderBrowser.Description = "Chọn thư mục mà bạn muốn thực hiện quay - cắt. Lưu ý chỉ các ảnh nằm trực tiếp trong thư mục đó bị ảnh hưởng.";
            folderBrowser.ShowNewFolderButton = false;
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                txtSrc.Text = folderBrowser.SelectedPath;
                if (checkAutoDest.Checked)
                {
                    txtDest.Text = folderBrowser.SelectedPath + UI.Properties.Settings.Default.PreprocessFolder;
                    try
                    {
                        System.IO.Directory.CreateDirectory(txtDest.Text);
                    }
                    catch (System.IO.IOException ex)
                    {
                        Core.Utility.Error("Không tạo được thư mục mặc định chứa kết quả xử lý. " + Environment.NewLine
                            + ex.Message);
                    }
                }
            }
        }

        private void btnBrowseDest_Click(object sender, EventArgs e)
        {
            folderBrowser.SelectedPath = "";
            folderBrowser.Description = "Chọn thư mục đích chứa kết quả. Không chọn trùng với thư mục nguồn ở trên. Bạn có tạo mới thư mục đích trực tiếp trong này.";
            folderBrowser.ShowNewFolderButton = true;            
            if (folderBrowser.ShowDialog() == DialogResult.OK)
                txtDest.Text = folderBrowser.SelectedPath;
        }

        private void btnWork_Click(object sender, EventArgs e)
        {
            if (txtDest.Text == "" || txtSrc.Text == "")
            {
                Core.Utility.Msg("Nguồn dữ liệu và nơi lưu kết quả cần chọn trước" + Environment.NewLine +
                    "Nhấn nút duyệt thư mục để chọn.");
                return;
            }
            UseWaitCursor = true;
            Cursor = Cursors.WaitCursor;
            // Hiện group Log
            groupLog.Location = groupIllustrate.Location;
            groupIllustrate.Visible = false;
            groupLog.Visible = true;
            // Lấy danh sách các tệp cần xử lý.
            Core.Automate automate = new Core.Automate();
            automate.CoreMsg += new Core.CoreMsgEventHandler(automate_CoreMsg);            
            automate.Folder(txtSrc.Text);
            Core.Prepare.Clip[] c_types = new Core.Prepare.Clip[]
            {
                Core.Prepare.Clip.None,
                Core.Prepare.Clip.Horizon,
                Core.Prepare.Clip.Vertical
            };
            Core.Prepare.Clip clip = c_types[cropBox.SelectedIndex];
            RotateFlipType[] r_types = new RotateFlipType[] { 
                RotateFlipType.RotateNoneFlipNone,
                RotateFlipType.Rotate90FlipNone,
                RotateFlipType.Rotate180FlipNone,
                RotateFlipType.Rotate270FlipNone};
            RotateFlipType rotate = r_types[rotateBox.SelectedIndex];
            if (automate.FileList == null)
            {
                Core.Utility.Error("Không có tệp ảnh quét nào được tìm thấy trong thư mục: \n"
                    + txtSrc.Text);
                return;
            }
            for (int i = 0; i < automate.FileList.Length; i++)
            {                
                Core.Prepare prepare = new Core.Prepare(automate.FileList[i],new Core.CoreMsgEventHandler(automate_CoreMsg));                 
                prepare.Perform(rotate,clip, txtDest.Text,automate.FileList[i]);
                automate.Inform(this, automate.FileList[i] + " xong" + Environment.NewLine);				
                progressBar.Value = (int)Math.Ceiling((i + 1) * 100.0 / automate.FileList.Length);
            }
            UseWaitCursor = false;
            Cursor = Cursors.Default;
            System.Diagnostics.Process.Start(txtDest.Text);
            this.Close();  
            
        }

        void automate_CoreMsg(object sender, Core.CoreMsgEventArgs e)
        {
            txtLog.AppendText(e.Message);
        }
        private void FormRotateSplit_Load(object sender, EventArgs e)
        {

        }
        Bitmap[] r_illus = new Bitmap[] {
                global::UI.Properties.Resources.rs_dest,
            global::UI.Properties.Resources.rs_90,
            global::UI.Properties.Resources.rs_180,
            global::UI.Properties.Resources.rs_270};
        private void rotateBox_SelectedValueChanged(object sender, EventArgs e)
        {            
            r_src.Image = r_illus[rotateBox.SelectedIndex];
        }

        Bitmap[] s_illus = new Bitmap[] {
            global::UI.Properties.Resources.Generic_Document,
            global::UI.Properties.Resources.rs_horz,
            global::UI.Properties.Resources.rs_vert};
        private void cropBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            r_split.Image = s_illus[cropBox.SelectedIndex];
        }
    }
}
