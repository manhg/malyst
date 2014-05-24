using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using GiangManh;
using System.Runtime.InteropServices;
namespace GiangManh.Utility
{
    /// <summary>
    /// Cung cấp truy cập trực tiếp đến từng điểm ảnh trong một image
    /// </summary>
    public class ImageMap
    {
        public byte[] map;
        public int width;
        public int height;
        /// <summary>
        /// Dùng cái này chậm hơn so với đọc trực tiếp bằng obj.map[x + y*obj.width]
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public byte this[int x, int y]
        {
            get
            {
                return map[x + y * width];                
            }
        }
        public ImageMap(Bitmap b)
        {
            int w = b.Width, h = b.Height;
            this.width = w;
            this.height = h;
            map = new byte[w * h];
            Rectangle r = new Rectangle(0, 0, w, h);
            BitmapData bdat;
            Bitmap temp;
            Graphics g;
            switch (b.PixelFormat)
            {
                case PixelFormat.Format8bppIndexed:
                    bdat = b.LockBits(r, ImageLockMode.ReadOnly, b.PixelFormat);
                    unsafe
                    {
                        Marshal.Copy(bdat.Scan0, map, 0, w * h);
                    }
                    b.UnlockBits(bdat);
                    break;
                case PixelFormat.Indexed:
                    System.Windows.Forms.MessageBox.Show(
                        "Lỗi nghiêm trọng: Không được sử dụng các ảnh quét black-white hay index khác \n" +
                        "Format8bpp (grayscale). Xin vui lòng quét lại. Chương trình sẽ dừng.", "Thông báo",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    System.Windows.Forms.Application.Exit();
                    break;
                default:
                    if (b.PixelFormat != PixelFormat.Format24bppRgb)
                    {
                        temp = new Bitmap(w, h, PixelFormat.Format24bppRgb);
                        g = Graphics.FromImage(temp);
                        g.DrawImage(b, r, 0, 0, w, h, GraphicsUnit.Pixel);
                        g.Dispose(); b = temp;
                    }

                    bdat = b.LockBits(r, ImageLockMode.ReadOnly, b.PixelFormat);
                    unsafe
                    {
                        IntPtr p = Marshal.AllocHGlobal(w * h);
                        int index;
                        for (int y = 0; y < h; y++)
                        {
                            for (int x = 0; x < w; x++)
                            {
                                index = y * bdat.Stride + (x * 3);
                                Marshal.WriteByte(
                                    p,  // Ô nhớ                                    
                                    w * y + x,
                                    // độ xám 0 - 255                                        
                                        (byte)((Marshal.ReadByte(bdat.Scan0, index + 2) +
                                        Marshal.ReadByte(bdat.Scan0, index + 1) +
                                        Marshal.ReadByte(bdat.Scan0, index))
                                        / 3));
                            }
                        }
                        Marshal.Copy(p, map, 0, w * h);
                        Marshal.FreeHGlobal(p);                        
                    }
                    b.UnlockBits(bdat);
                    break;
            }
        }
    }
    public class ManipulateImage
    {
        public static Bitmap Rotate(Image img, PointF center, float degree)
        {
            Bitmap r = new Bitmap(img.Width, img.Height);
            r.SetResolution(img.HorizontalResolution, img.VerticalResolution);
            Graphics g = Graphics.FromImage(r);
            // Phủ nền trắng cho phần hình
            GraphicsUnit unit = GraphicsUnit.Pixel;
            g.FillRectangle(Brushes.White, r.GetBounds(ref unit));
            // Quay
            Matrix m = new Matrix();
            m.RotateAt(degree, center);
            g.MultiplyTransform(m);
            g.DrawImage(img, new Point(0, 0));
            return r;
        }
        public static Bitmap Resample(float destDpi, Image img)
        {            
            // scale factors
            float sx = (float)destDpi / img.VerticalResolution;
            float sy = (float)destDpi / img.HorizontalResolution;
            int newWidth = (int)Math.Ceiling(img.Width * sx);
            int newHeight = (int)Math.Ceiling(img.Height * sy);                       
            Bitmap bmp = new Bitmap(newWidth, newHeight);            
            bmp.SetResolution(destDpi, destDpi);
            Graphics g = Graphics.FromImage(bmp);            
            g.DrawImage(img, 0, 0, newWidth, newHeight);
            g.Dispose();
            return bmp;
        }
        public static Image Clip(Image img,Rectangle bound)
        {
            Bitmap r = new Bitmap(bound.Width, bound.Height);
            r.SetResolution(img.HorizontalResolution, img.VerticalResolution);
            Graphics g = Graphics.FromImage(r);
            //g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(img, 0, 0, bound,GraphicsUnit.Pixel);
            return r;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="img"></param>
        /// <param name="gamma">0.1 - 2.2, càng bé càng sáng</param>
        /// <returns></returns>
        public static Image SetGamma(Image img, float gamma)
        {
            Bitmap bmp = new Bitmap(img.Width,img.Height);            
            ImageAttributes imgAttr = new ImageAttributes();
            imgAttr.SetGamma(gamma);
            Graphics g = Graphics.FromImage(bmp);
            g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height),
                0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgAttr);
            return bmp;
        }        
    }    
}
