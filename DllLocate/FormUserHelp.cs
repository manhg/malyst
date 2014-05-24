using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace GiangManh.Locate
{
    /// <summary>
    /// Chú ý:
    /// + Truyền một FormUserHelpData vào Tag
    /// + Phải gọi Init() trước khi show()
    /// </summary>
    public partial class FormUserHelp : Form
    {
        int zoom = 400; // %
        int checkSize = 3;
        string title = "";
        Data data;
        public class Data
        {
            internal Image img;
            internal Signal signal;
            internal Point userAnswer = Locate.Anchor.NOT_FOUND;

            public Point UserAnswer
            {
                get { return userAnswer; }
                set { userAnswer = value; }
            }
            public Data(Image img, Signal signal)
            {
                this.img = img;
                this.signal = signal;
            }
        }
        public FormUserHelp()
        {
            InitializeComponent();            
        }
        public void Init()
        {
            data = this.Tag as Data;
            picture.Image = data.img.Clone() as Image;
            picture.Size = new Size(data.img.Width * zoom / 100, data.img.Height * zoom / 100);
            picture.SizeMode = PictureBoxSizeMode.Zoom;
            this.Text += ": " + data.signal.ToString();
            switch (data.signal)
            {
                case GiangManh.Locate.Signal.B:
                    picture.Location = new Point(0, -picture.Height + this.Height);
                    break;
                case GiangManh.Locate.Signal.C:
                    picture.Location = new Point(this.Width - picture.Width, -picture.Height + this.Height);
                    break;
                case GiangManh.Locate.Signal.D:
                    picture.Location = new Point(this.Width - picture.Width, 0);
                    break;
            }
        }

        private void FormUserHelp_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (data.userAnswer.IsEmpty)
                this.DialogResult = DialogResult.Cancel;
            else
                this.DialogResult = DialogResult.OK;
        }

        private void picture_MouseClick(object sender, MouseEventArgs e)
        {
            this.data.userAnswer = new Point(e.X * 100 / zoom, e.Y * 100 / zoom);
            if (title == "") title = this.Text;
            this.Text = string.Format("{0} {1}",title, this.data.userAnswer.ToString());
            Graphics g = picture.CreateGraphics();
            g.DrawEllipse(Pens.Red, new Rectangle(e.X - checkSize, e.Y - checkSize, 2 * checkSize, 2 * checkSize));
        }

        private void picture_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            picture_MouseClick(sender, e);
            this.Close();
        }
    }
    
}
