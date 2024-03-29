/*
 * Chương trình nhận dữ liệu quét, xử lí và phân tích bài làm trắc nghiệm.
 * Dùng trong trường THPT và THCS.
 * Author: Giang Mạnh
 * Copyright (c) 2008
 * Date: 2008-06
 * 
 * This module: Core classes
 * Provides important classes to process and anlayze what users scan.
*/
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using UI.Properties;

namespace Core
{
    interface IInterpret
    {
        Core.Discovers IResult { get; }
    }
    public class CoreMsgEventArgs : EventArgs
    {
        /// <summary>
        /// Thông điệp chuyển đi
        /// </summary>
        public string Message;
        /// <summary>
        /// Đối tượng chuyển đi
        /// </summary>
        public object Something;
        public CoreMsgEventArgs(string message)
        {
            this.Message = message;
        }
        public CoreMsgEventArgs(object something)
        {
            this.Something = something;
        }
    }
    public delegate void CoreMsgEventHandler(object sender, CoreMsgEventArgs e);
    /// <summary>
    /// Cho class khả năng truyền thông báo đến các thành phần khác qua event. Để nhận
    /// được thông điệp, lớp truyền đi phải thừa kế lớp này (CoreMsgCapable), lớp nhận
    /// sử dụng một instance của lớp truyền phải add một event handler cho event CoreMsg 
    /// </summary>
    public class CoreMsgCapable
    {
        /// <summary>
        /// Thông điệp truyền đi có dành cho form Interpret không?
        /// </summary>
        public bool IsForFormInterpret = false;
        /// <summary>
        /// Có dành cho tất cả không (tất nhiên là ngoại trừ những đối tượng
        /// được chỉ định đích xác bằng biến riêng.
        /// </summary>
        public bool IsForAll = true;
        public CoreMsgEventHandler CoreMsgDelegates;
        /// <summary>
        /// Event truyền thông điệp.
        /// </summary>        
        public event CoreMsgEventHandler CoreMsg
        {
            add { CoreMsgDelegates += value; }
            remove { CoreMsgDelegates -= value; }
        }
        /// <summary>
        /// Thực hiện gửi thông điệp
        /// Đối tượng nhận phải cài đặt handler cho event CoreMsg 
        /// và thuộc tính IsFor ... cho đối tượng đó là true;
        /// CHÚ Ý:
        /// Nếu là loại đối tượng chung chung, ta luôn có thể kiểm tra IsForAll
        /// Đúng ra phải kiểm tra event CoreMsg có cái nào handler chưa, nếu không sẽ
        /// phát sinh Excpection. Để sửa, phải chắc chắn có một event handler của đối tượng
        /// phát sinh thông điệp này
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="message"></param>
        public void Inform(object sender, string message)
        {
            CoreMsgDelegates(sender, new CoreMsgEventArgs(message));
        }
        public void Inform(object sender, string format, params object[] parameters)
        {
            // Đúng ra phải kiểm tra event CoreMsg có cái nào handler chưa, nếu không sẽ
            // phát sinh Excpection. Để sửa, phải chắc chắn có một event handler của đối tượng
            // phát sinh thông điệp này
            CoreMsgDelegates(sender, new CoreMsgEventArgs(string.Format(format, parameters)));
        }
        /// <summary>
        /// Gửi đi một đối tượng, yêu cầu tương tự gửi thông điệp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="obj"></param>
        public void SendObj(object sender, object obj)
        {
            CoreMsgDelegates(sender, new CoreMsgEventArgs(obj));
        }
    }
    public struct Spot
    {
        public int X, Y;
        public bool IsNull()
        { return (X == 0 && Y == 0); }
        public Spot(int x, int y) { this.X = x; this.Y = y; }
        public Spot(double x, double y) { this.X = (int)Math.Round(x); this.Y = (int)Math.Round(y); }
        public Spot FromPreciseSpot(PreciseSpot preciseSpot)
        { return new Spot(preciseSpot.X, preciseSpot.Y); }
        public override string ToString()
        {
            return string.Format("({0},{1})", X, Y);
        }
        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="rhs"></param>        
        public Spot(Spot rhs)
        {
            X = rhs.X;
            Y = rhs.Y;
        }
        public static explicit operator Spot(PreciseSpot rhs)
        {
            return new Spot((int)Math.Round(rhs.X), (int)Math.Round(rhs.Y));
        }
        public static double Distance(Spot lhs, Spot rhs)
        {
            return Math.Sqrt((lhs.X - rhs.X) * (lhs.X - rhs.X)
              + (lhs.Y - rhs.Y) * (lhs.Y - rhs.Y));
        }
        public static Spot operator +(Spot lhs, Spot rhs)
        {
            return new Spot(lhs.X + rhs.Y, lhs.X + rhs.Y);
        }
    }
    public struct PreciseSpot
    {
        public double X, Y;
        public PreciseSpot(double x, double y) { this.X = x; this.Y = y; }
        public override string ToString()
        {
            return string.Format("{0},{1}", X, Y);
        }
        public static implicit operator PreciseSpot(Spot lhs)
        {
            return new PreciseSpot(lhs.X, lhs.Y);
        }
        public static PreciseSpot operator +(PreciseSpot lhs, PreciseSpot rhs)
        {
            return new PreciseSpot(lhs.X + rhs.Y, lhs.X + rhs.Y);
        }
    }
    public class Prepare : CoreMsgCapable
    {
        Bitmap bmp;
        string fileName;
        public Acquired[] Cropped;
        public readonly int Height, Width;
        public readonly float Dpi;
        public Prepare(string fileName,CoreMsgEventHandler handler)
        {
            this.CoreMsg += handler;
            bmp = null;
            IsForFormInterpret = true;
            // Inform(this, "Reading file {0}", fileName);
            Inform(this,"Đang đọc tệp: " + fileName);
            try
            {
                FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                bmp = new Bitmap(stream);
                if (bmp.VerticalResolution == bmp.HorizontalResolution) this.Dpi = bmp.HorizontalResolution;
                else { Inform(this, "Độ phân giải ngang và dọc khác nhau, quá trình chuẩn bị dừng."); return; }
                this.Height = bmp.Height;
                this.Width = bmp.Width;
                stream.Close();
                this.fileName = fileName;
            }
            catch (IOException ex) { Inform(this, "Có vấn đề khi đọc tệp: {0}. Quá trình dừng.", ex.Message); }
            catch (Exception) { };
        }
        /// <summary>
        /// Quay/đối xứng hình. Chiều quay là chiều kim đồng hồ
        /// </summary>
        /// <param name="rotateType"></param>
        public void Rotate(RotateFlipType rotateType)
        { bmp.RotateFlip(rotateType); }
        /// <summary>
        /// Hướng cắt. 
        /// Horizonal: cắt theo đường ngang ở chính giữa
        /// Vertical: cắt theo đường dọc ở chính giữa
        /// </summary>
        public enum CropDirection { Vertical, Horizonal }
        /// <summary>
        /// Cắt đôi hình theo một chiều nào đó.
        /// Sử dụng để chuyển hình quét A4 thành 2 hình A5
        /// 
        /// </summary>
        /// <param name="direction">Hướng cắt</param>
        /// <returns>Kết quả được lưu trong mảng Cropped</returns>
        public void Crop(CropDirection direction)
        {
            #region Source##
            // Marshal ảnh điểm nguồn vào mảng src
            Rectangle srcRect = new Rectangle(0, 0, this.bmp.Width, this.bmp.Height);
            BitmapData srcBmpData =
                this.bmp.LockBits(srcRect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                this.bmp.PixelFormat);
            // Get the address of the first line.
            IntPtr srcptr = srcBmpData.Scan0;
            int srcBytes = srcBmpData.Stride * srcBmpData.Height;
            int destBytes;
            byte[] src = new byte[srcBytes];
            // Marshal
            System.Runtime.InteropServices.Marshal.Copy(srcptr, src, 0, srcBytes);
            this.bmp.UnlockBits(srcBmpData);
            #endregion
            Cropped = new Acquired[2];
            Cropped[0] = new Acquired();
            Cropped[1] = new Acquired();
            switch (direction)
            {
                case CropDirection.Horizonal:

                    destBytes = srcBmpData.Stride * (srcBmpData.Height / 2);
                    Cropped[0].Height = Cropped[1].Height = bmp.Height / 2;
                    Cropped[0].Width = Cropped[1].Width = bmp.Width;
                    Cropped[0].ImagePixelFormat = Cropped[1].ImagePixelFormat = bmp.PixelFormat;
                    Cropped[0].Stride = Cropped[1].Stride = srcBmpData.Stride;
                    Cropped[0].BytesPerPixel = Cropped[1].BytesPerPixel = srcBmpData.Stride / srcBmpData.Width;
                    Cropped[0].pixel = new byte[destBytes];
                    Cropped[1].pixel = new byte[destBytes];
                    Array.Copy(src, 0, Cropped[0].pixel, 0, destBytes);
                    Array.Copy(src, destBytes, Cropped[1].pixel, 0, destBytes);
                    break;
                case CropDirection.Vertical:
                    int cropStride = srcBmpData.Stride / 2;
                    destBytes = cropStride * srcBmpData.Height;
                    Cropped[0].Height = Cropped[1].Height = bmp.Height;
                    Cropped[0].Width = Cropped[1].Width = bmp.Width / 2;
                    Cropped[0].ImagePixelFormat = Cropped[1].ImagePixelFormat = bmp.PixelFormat;
                    Cropped[0].Stride = Cropped[1].Stride = cropStride;
                    Cropped[0].BytesPerPixel = Cropped[1].BytesPerPixel = srcBmpData.Stride / srcBmpData.Width;
                    Cropped[0].pixel = new byte[destBytes];
                    Cropped[1].pixel = new byte[destBytes];
                    for (int y = 0; y < srcBmpData.Height; y++)
                    {
                        Array.Copy(src, y * srcBmpData.Stride, Cropped[0].pixel, cropStride * y, cropStride);
                        Array.Copy(src, y * srcBmpData.Stride + cropStride, Cropped[1].pixel, cropStride * y, cropStride);
                    }
                    break;
                default:
                    Cropped = null;
                    break;
            }            

        }
        /// <summary>
        /// Crop (khoét) một vùng bất kỳ trong hình, tức lọc ra.
        /// </summary>
        /// <param name="sx"></param>
        /// <param name="sy"></param>
        /// <param name="ex"></param>
        /// <param name="ey"></param>
        public void Crop(int sx, int sy, int ex, int ey)
        {
			#region Source##
			// Marshal ảnh điểm nguồn vào mảng src
			Rectangle srcRect = new Rectangle(0, 0, this.bmp.Width, this.bmp.Height);
			BitmapData srcBmpData =
				this.bmp.LockBits(srcRect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
				this.bmp.PixelFormat);
			// Get the address of the first line.
			IntPtr srcptr = srcBmpData.Scan0;
			int srcBytes = srcBmpData.Stride * srcBmpData.Height;
			int destBytes;
			byte[] src = new byte[srcBytes];
			// Marshal
			System.Runtime.InteropServices.Marshal.Copy(srcptr, src, 0, srcBytes);
			this.bmp.UnlockBits(srcBmpData);
			#endregion
			Acquired crop = new Acquired(bmp,this.CoreMsgDelegates);
			int width =  ex - sx;
			int height = ey - sy;
			crop.Height = height;
			crop.Width =  width;
			destBytes = srcBmpData.Stride * (srcBmpData.Height / 2);
			
			crop.ImagePixelFormat = bmp.PixelFormat;
			int stride = (int)Math.Ceiling(srcBmpData.Stride * width * 1.0 / bmp.Width);
			crop.Stride = stride;
			crop.BytesPerPixel = srcBmpData.Stride / srcBmpData.Width;
			crop.pixel = new byte[stride * height];
			for (int i = sy; i < ey; i++)
			{
				Array.Copy(src, i * srcBmpData.Stride + sx, crop.pixel, (i - sy) * stride, stride); // width * crop.BytesPerPixel);
			}

			// save to file
			//unsafe
			//{
			//    fixed (byte* bmpPtr = crop.pixel)
			//    {
			//        Bitmap name = new Bitmap(crop.Width, crop.Height,stride,
			//            crop.ImagePixelFormat, new IntPtr(bmpPtr));
			//        name.Save(@"D:\temp\" + DateTime.Today.ToFileTime());
			//    }
			//}
        }
        public Bitmap BitmapFromCropped(int no)
        {
            unsafe
            {                
                fixed (byte* bmpPtr = Cropped[no].pixel)
                {
                    return new Bitmap(Cropped[no].Width, Cropped[no].Height, Cropped[no].Stride,
                        Cropped[no].ImagePixelFormat, new IntPtr(bmpPtr));
                }
            }
        }
        public enum Clip { Horizon, Vertical, None};
        /// <summary>
        /// Thực hiện những thao tác hay dùng: Quay rồi cắt đồng thời để tạo ra nguồn ảnh
        /// </summary>
        /// <param name="option"></param>
        public void Perform(RotateFlipType rotate, Clip clip, string folder, string file)
        {
            bmp.RotateFlip(rotate);
            switch (clip)
            {
                case Clip.None:
                    try
                    {
                        bmp.Save(string.Format("{0}{1}N{2}", folder,
                            Core.Utility.FolderSeparator, Core.Utility.GetSafeFileName(file)));
                    }
                    catch (Exception ex) { }
                    return;
                case Clip.Horizon:
                    Crop(CropDirection.Horizonal);
                    break;
                case Clip.Vertical:
                    Crop(CropDirection.Vertical);
                    break;
            }
            try
            {
                BitmapFromCropped(0).Save(string.Format("{0}{1}X{2}", folder,
                    Core.Utility.FolderSeparator, Core.Utility.GetSafeFileName(file)));
                BitmapFromCropped(1).Save(string.Format("{0}{1}Y{2}", folder,
                    Core.Utility.FolderSeparator, Core.Utility.GetSafeFileName(file)));
            }
            catch (Exception) { };
        }
    
    }
    public enum AnchorType { TopLeft, TopRight, BottomLeft, BottomRight }
    public class Anchor : CoreMsgCapable
    {
        Acquired acq;
        Spot[] anchors = new Spot[4];
        /// <summary>
        /// Anchor có đủ thông tin để xử lí tiếp hay không?
        /// </summary>
        public bool Acceptable
        {
            get
            {
                #region Cố gắng tìm ra anchor từ các anchor đã nhận dạng được
                if (anchors[(int)AnchorType.TopLeft].IsNull())
                {
                    if (!anchors[(int)AnchorType.TopRight].IsNull() &&
                        !anchors[(int)AnchorType.BottomRight].IsNull())
                    {

                    }
                }
                #endregion
                if (anchors[(int)AnchorType.TopLeft].IsNull() && anchors[(int)AnchorType.TopLeft].IsNull())
                    return false;
                else return true;
            }
        }
        /// <summary>
        /// Vùng tìm kiếm anchor(s), 
        /// tính bằng dộ dài cạnh hình vuông tìm kiếm (đơn vị: pixel)
        /// Giá trị gán lúc constructor của class, bằng Width/3
        /// </summary>
        int SearchAnchorBoxSize;
        /// <summary>
        /// Đường chéo của ô neo
        /// Có thể viết làm thế nào để khi không tìm thấy neo, nó giảm số này đi
        /// để tìm lại và thông báo người dùng quét cẩn thận hơn, không để bị quá nghiêng
        /// </summary>
        int dDiagonal = (int)Math.Round(
            ((3) * UI.Properties.Settings.Default.DefaultDpi / UI.Properties.Settings.Default.dConvertValueRatio)
            / Math.Sqrt(2)); // 3mm bán kính, 0.5mm độ rộng nét
        public Spot this[AnchorType anchorType]
        {
            get { return anchors[(int)anchorType]; }
        }
        public Anchor(Acquired acq, CoreMsgEventHandler handler)
        {
            this.CoreMsg += handler;
            this.acq = acq;
            SearchAnchorBoxSize = acq.Width / 4;
        }
        public bool Detect(AnchorType anchorType)
        {
            int dx, dy;
            int startX, startY, endX, endY, stepX, stepY;
            dx = dy = startX = startY = endX = endY = stepX = stepY = 0;
            bool hasTry = false; // Giới hạn detect lại
            for (; !hasTry; )
            {
                switch (anchorType)
                {
                    #region Khởi tạo các giá trị dx,dy, ...
                    case AnchorType.TopLeft:
                        dx = -1;
                        dy = -1;
                        startX = 1;
                        endX = SearchAnchorBoxSize;
                        startY = 1;
                        endY = SearchAnchorBoxSize;
                        stepX = 1;
                        stepY = 1;
                        break;
                    case AnchorType.BottomLeft:
                        dx = -1;
                        dy = 1;
                        startX = 1;
                        endX = SearchAnchorBoxSize;
                        startY = acq.Height - 1;
                        endY = acq.Height - SearchAnchorBoxSize;
                        stepX = 1;
                        stepY = -1;
                        break;
                    case AnchorType.BottomRight:
                        dx = 1;
                        dy = 1;
                        startX = acq.Width - 1;
                        endX = acq.Width - SearchAnchorBoxSize;
                        startY = acq.Height - 1;
                        endY = acq.Height - SearchAnchorBoxSize;
                        stepX = -1;
                        stepY = -1;
                        break;
                    case AnchorType.TopRight:
                        dx = 1;
                        dy = -1;
                        startX = acq.Width - 1;
                        startY = 1;
                        endX = acq.Width - SearchAnchorBoxSize;
                        endY = SearchAnchorBoxSize;
                        stepX = -1;
                        stepY = 1;
                        break;
                    #endregion
                }
                for (int y = startY; (y - endY) * stepY < 0; y += stepY)
                {
                    for (int x = startX; (x - endX) * stepX < 0; x += stepX)
                    {
                        if (// Ô hiện tại và 3 ô hướng khác gần kín
                            ((acq.IsBlack(x, y) + acq.IsBlack(x + dx, y + dy)
                                + acq.IsBlack(x + dx, y) + acq.IsBlack(x, y + dy)) >= 3)
                            // Hướng ngược lại là trắng
                            && ((acq.IsBlack(x - dx, y - dy)
                                + acq.IsBlack(x - dx, y) + acq.IsBlack(x, y - dy)) == 0)
                            // Tâm hướng chéo trên phải đậm
                            && (acq.CaculateBlackArea(x + dDiagonal * dx /2, y + dDiagonal * dy /2) >= 9*0.7)
							// Điểm xa chéo là trống.
							&& (acq.IsBlack(x + 2 * dDiagonal * dx, y + 2* dDiagonal* dy) == 0))
							
                        {                            
                            this.anchors[(int)anchorType].X = x;
                            this.anchors[(int)anchorType].Y = y;
                            return true;
                        }
                    }
                }
                if (!hasTry)
                {
                    hasTry = true;
                    dDiagonal = dDiagonal - 2;
                }
                else
                {
                    Inform(this, "{0}: không tìm thấy!!!", anchorType.ToString());
                    return false;
                }

            }
            return false;
        }
        /// <summary>
        /// Nếu chỉ tìm được 2 anchor, ta cần phải suy ra vị trí các anchor khác.
        /// DEVELOP*
        /// </summary>
        public bool Infer()
        {
            return false;
        }
    }
    public class Acquired : CoreMsgCapable
    {
        // Setting zone
        //
        [ThreadStatic]
        internal static int BlackWhiteThreshold = UI.Properties.Settings.Default.BlackWhiteThreshold;
        /// <summary>
        /// Ngưỡng màu chì (với loại 2B)
        /// Lấy từ thực tế
        /// </summary>
        [ThreadStatic]
        internal static int PencilThreshold = UI.Properties.Settings.Default.PencilThreshold;
        [ThreadStatic]
        internal static int R = (int)(2 * UI.Properties.Settings.Default.DefaultDpi / UI.Properties.Settings.Default.dConvertValueRatio);
        static int XR = (int)(1.6 / 0.254);
        static int XRR = XR * XR;
        internal static int XRequireFill = (int)((UI.Properties.Settings.Default.RequireFillCoefficient * Math.PI * XRR));
        [ThreadStatic]
        internal static int RR = R * R;
        [ThreadStatic]
        internal static int RequireFill = (int)((UI.Properties.Settings.Default.RequireFillCoefficient * Math.PI * RR) / 4);
        
        /// <summary>
        /// Ngưỡng bắt đầu đếm lại.
        /// </summary>
        [ThreadStatic]
        internal static int RecalculateThreshold = (int)(0.5 * RequireFill);
        //
        // Variables
        string fileName;
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        public override string ToString()
        {

            string generalInfo = string.Format("{0} {1}x{2}\n", fileName, Width, Height);
            StringBuilder content = new StringBuilder();
            content.Append("   ");
            for (int x = 0; x < Width; x++) content.Append(x % 10).ToString();
            content.Append("\n");
            char block = (char)0x2588;
            for (int y = 0; y < Height; y++)
            {
                content.Append(y.ToString("D2") + " ");
                for (int x = 0; x < Width; x++)
                    content.Append(IsBlack(x, y) == 1 ? block : ' ');
                content.Append("\n");
            }
            return generalInfo + content;
        }
        /// <summary>
        /// Thông tin về ảnh điểm
        /// </summary>
        internal byte[] pixel;
        int place;
        /// <summary>
        /// Đếm số ảnh điểm nằm trong vùng cần kiểm tra.
        /// </summary>
        int fill;
        public int IsBlack(int x, int y)
        {
            place = Stride * y + x * BytesPerPixel;
            if (!(x >= 0 && x < Width && y >= 0 && y < Height)) return 0;
            else
            {
                try
                {
                    switch (ImagePixelFormat)
                    {
                        case PixelFormat.Format24bppRgb:
                        case PixelFormat.Format32bppArgb:
                            return ((pixel[place + 2] < BlackWhiteThreshold)
                                && (pixel[place + 1] < BlackWhiteThreshold)
                                && (pixel[place] < BlackWhiteThreshold))
                                ? 1 : 0;
                        case PixelFormat.Format8bppIndexed:
                            return (pixel[Stride * y + x * BytesPerPixel] < BlackWhiteThreshold) ? 1 : 0;

                    }
                }
                catch (IndexOutOfRangeException) { return 0; }
                return 0;
            }
        }
        public int IsBlack(Spot spot) { return IsBlack(spot.X, spot.Y); }
		public int CaculateBlackArea(int x, int y)
		{
			return (IsBlack(x - 1, y - 1) + IsBlack(x, y - 1) + IsBlack(x + 1, y - 1) +
					IsBlack(x - 1, y) + IsBlack(x, y) + IsBlack(x + 1, y) +
					IsBlack(x - 1, y + 1) + IsBlack(x, y + 1) + IsBlack(x + 1, y + 1));
		}
        /// <summary>
        /// Kiểm tra vùng có bị tô chì không
        /// Tiêu chí tô chì sẽ có ngưỡng rộng hơn tiêu chí bị đánh dấu
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int IsPencil(int x, int y)
        {
            place = Stride * y + x * BytesPerPixel;
            if (!(x>=0&&x< Width  && y>=0&& y<Height) )return 0;
            else
            {
                switch (ImagePixelFormat)
                {
                    case PixelFormat.Format24bppRgb:
                    case PixelFormat.Format32bppArgb:
                        return ((pixel[place + 2] < PencilThreshold)
                            && (pixel[place + 1] < PencilThreshold)
                            && (pixel[place] < PencilThreshold))
                            ? 1 : 0;
                    case PixelFormat.Format8bppIndexed:
                        return ((pixel[place] < PencilThreshold) ? 1 : 0);
                }
                return 0;
            }
        }
        public int IsPencil(Spot point)
        {
            return IsPencil(point.X, point.Y);
        }

        /// <summary>
        /// Định hướng góc phần tư để kiểm tra xem vùng có vị tick không.
        /// </summary>
        public int[,] TickPart = { { 1, 1 }, // Dưới phải
                                 { -1, -1 }, // Trên trái
                                 { -1, 1 },  // Dưới trái
                                 { 1, -1 }  // Trêm phải
                                 };
        /// <summary>
        /// Kiểm tra ô có bị đánh dấu hay không.
        /// Điều kiện: điểm tâm center phải rơi vào trong ô đó
        /// Phương pháp: Quét ô hiện tại với góc phần tư
        /// 
        /// Develop: tương lai có lẽ nên dùng phương pháp loang vì điểm tâm không đạt độ
        /// chính xác cao lắm.
        /// </summary>
        /// <param name="center"></param>
        /// <returns></returns>
        public bool IsTicked(Spot center)
        {           
            // Kiểm tra góc tư dưới phải
            for (int part = 0; part < 4; part++)
            {
                fill = 0;
                for (int y = 0; y <= R; y++)
                    for (int x = 0; x <= Math.Sqrt(RR - y * y); x++)
                        fill += IsPencil(center.X + x * TickPart[part, 0], center.Y + y * TickPart[part, 1]);
                if (fill >= RequireFill) return true;
                
            }
            return false;
        }
        public bool IsSmallTicked(Spot center)
        {
            // Kiểm tra góc tư dưới phải
            fill = 0;
            for (int part = 0; part < 4; part++)
            {                
                for (int y = 0; y <= XR; y++)
                    for (int x = 0; x <= Math.Sqrt(XRR - y * y); x++)
                        fill += IsBlack(center.X + x * TickPart[part, 0], center.Y + y * TickPart[part, 1]);                
            }
            if (fill >= XRequireFill) return true;
            else return false;
        }
        /// <summary>
        /// Số bytes mà mỗi dòng điểm ảnh chứa
        /// Vì Windows chạy nền 32bit nên số nguyên 4 bytes là kích thức nhỏ nhất, rất có thê số bytes này
        /// không chia hết cho số bytes cho mỗi pixel như đã tính. Có thể những byte cuối thừa ra và nhận 
        /// giá trị 0. Cần phải cẩn thận với giá trị này.
        /// </summary>
        public int Stride;
        public PixelFormat ImagePixelFormat;
        public int BytesPerPixel;
        public int Width;
        public int Height;
        /// <summary>
        /// Depracted: use with care!
        /// Cái này chỉ dùng để tạo acquire theo ý mình mà không thông qua một bitmap nào cả.
        /// </summary>
        public Acquired()
        {
        }
        /// <summary>
        /// Constuctor with import
        /// </summary>
        /// <param name="fileName">Tệp nguồn ảnh</param>
        /// <param name="handler">Handler của đối tượng tạo ra đối tượng này
        /// Sử dụng để gắn handler của đối tượng gốc cho nó</param>
        public Acquired(Bitmap bmp, CoreMsgEventHandler handler)
        {
            this.CoreMsg += handler;            
            this.ImagePixelFormat = bmp.PixelFormat;
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData =
                bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                bmp.PixelFormat);
            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;
            // Declare an array to hold the bytes of the bitmap.
            this.Stride = bmpData.Stride;
            this.BytesPerPixel = bmpData.Stride / bmpData.Width;
            this.Height = bmp.Height;
            this.Width = bmp.Width;
            int bytes = bmpData.Stride * bmp.Height;
            this.pixel = new byte[bytes];
            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(ptr, pixel, 0, bytes);
            bmp.UnlockBits(bmpData);
            Inform(this, "Đọc xong {0}.", this.FileName);
        }
    }
    public enum PlaceType { Solution, Student, Problem, Class, XMark }
    public partial class Place : CoreMsgCapable
    {
        PreciseSpot root;
        double angle;
        double absoluteAngle;
        double space;
        /// <summary>
        /// Tỉ lệ co hình so với tính toán lý thuyết
        /// </summary>
        double scale;
        /// <summary>
        /// Khoảng cách cơ sở trong thiết kế mẫu
        /// </summary>
        double d = UI.Properties.Settings.Default.dBaseLength * UI.Properties.Settings.Default.DefaultDpi / UI.Properties.Settings.Default.dConvertValueRatio;
        public Place(Anchor anchor, CoreMsgEventHandler handler)
        {
            this.CoreMsg += handler;
            root = anchor[AnchorType.TopLeft];
            angle = Math.Atan2(
                anchor[AnchorType.TopLeft].X - anchor[AnchorType.BottomLeft].X,
                anchor[AnchorType.BottomLeft].Y - anchor[AnchorType.TopLeft].Y);
            // Tỉ lệ = Khoảng cách thực TL-BL với chiều dài lý thuyết.
            scale = Spot.Distance(anchor[AnchorType.TopLeft], anchor[AnchorType.BottomLeft])
                / (UI.Properties.Settings.Default.dHorizonalAnchorDistanceByBase * d);
            root = R2A(d * UI.Properties.Settings.Default.dRootOffsetByX,
                d * UI.Properties.Settings.Default.dRootOffsetByY);

        }
        /// <summary>
        /// Tính lại tọa độ theo tỉ lệ co
        /// Chỉ áp dụng trong hệ tương đối
        /// </summary>
        /// <param name="spot"></param>
        /// <returns></returns>
        public Spot Scale(double x, double y)
        {
            return new Spot(x, y);
        }
        public Spot Scale(PreciseSpot spot)
        {
            return new Spot(spot.X, spot.Y);
        }
        /// <summary>
        /// R2A: relative to absolute
        /// Đổi tọa độ tương đối so với tâm ô 1-A sang tọa độ tuyệt đối
        /// so với khung hình quét
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Spot R2A(double x, double y)
        {
            absoluteAngle = Math.Atan2(y, x) + angle;
            space = scale * Math.Sqrt(x * x + y * y);
            return new Spot(
                root.X + space * Math.Cos(absoluteAngle),
                root.Y + space * Math.Sin(absoluteAngle));
        }
        /// <summary>
        /// Where: tìm vị trí (tâm) của một thành phần nào đó
        /// thuộc PlaceType
        /// </summary>
        /// <param name="place">Loại place <see cref="PlaceType"/></param>
        /// <param name="no">Thứ tự (dòng thứ bao nhiêu, thành phần thứ mấy).
        /// Chú ý Index tính từ 1</param>
        /// <param name="detail">Chi tiết (ô A,B,C hay D; ...). Index tính từ 0</param>
        /// <returns></returns>
        public Spot Where(PlaceType place, int no, int detail)
        {
            Settings def = Settings.Default;
            switch (place)
            {
                case PlaceType.Solution:
                    if ((def.C1_StartNo <= no) && (no <= def.C1_EndNo))
                        return R2A(
                            (detail + def.C1_Xoffset)* d,
                            (no - def.C1_StartNo + def.C1_Yoffset) * d * 1.5f);

                    else if ((def.C2_StartNo <= no) && (no <= def.C2_EndNo))
                        return R2A(
                            (detail + def.C2_Xoffset) * d,
                            (no - def.C2_StartNo + def.C2_Yoffset) * d * 1.5f);
                    else if ((def.C3_StartNo <= no) && (no <= def.C3_EndNo))
                        return R2A(
                            (detail + def.C3_Xoffset) * d,
                            (no - def.C3_StartNo + def.C3_Yoffset) * d * 1.5f);
                    else
                    {
                        Inform(this, "Số thứ tự câu hỏi không hợp lệ. {0} ", no);
                        return new Spot(0, 0);
                    }
                case PlaceType.Student:
                    return R2A(
                        (detail + def.CStudent_Xoffset) * d,
                        no == 0 ? 10 * d : no * d);
                case PlaceType.Problem:
                    if (no <= 5) return R2A(
                        def.CProblem_Xoffset * d,
                        (no + def.CProblem_Yoffset) * d);
                    else return R2A(
                        (def.CProblem_Xoffset + 1) * d,
                        ((no - 5) + def.CProblem_Yoffset) * d);
                case PlaceType.Class:
                    if (no <= 5) return R2A(
                        def.CGroup_Xoffset * d, 
                        (no + def.CGroup_Yoffset) * d);
                    else return R2A((
                        def.CGroup_Xoffset + 1)* d, 
                        ((no - 5) + def.CGroup_Yoffset) * d);
                case PlaceType.XMark:
                    PointF rx = new PointF(78.75f, -16.25f);
                    float d_ = 4;
                    switch (no)
                    {
                        case 11:
                            return R2A(
                                (6 * d_ + rx.X) / 0.254f, 
                                rx.Y / 0.254f);
                        case 10:
                            return R2A(
                                (6 * d_ + rx.X) / 0.254f,
                                (rx.Y + 1*d_) / 0.254f);
                        default:
                            return R2A((rx.X + (no % 5) * d_) / 0.254f,
                                (rx.Y + (no / 5) * d_) / 0.254f);
                    }
                default:
                    {
                        Inform(this, "Vị trí không mong đợi.");
                        return new Spot(0, 0);
                    }
            }
        }
        
    }
    public class Automate : CoreMsgCapable
    {
        static string[] SupportFileTypes = { "*.jpg", "*.tif", "*.bmp" };
        internal string[] FileList;
        /// <summary>
        /// Đối tượng mà phương thức tự động hóa dựa trên
        /// </summary>
        public enum Source { Files, Folder, Scanner }
        public Discover OneFile(string fileName,ref KeySuite keys)
        {
            if (!File.Exists(fileName))
            {
                Inform(this, "Tệp {0} không có thực!", fileName); 
                return null;
            }
            else Inform(this, "Xử lý: '{0}'", fileName);
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            Acquired acq;
            try
            {
                Bitmap sourceBitmap = new Bitmap(fs);
                switch (sourceBitmap.PixelFormat)
                {
                    case PixelFormat.Format24bppRgb:
                    case PixelFormat.Format32bppArgb:
                    case PixelFormat.Format8bppIndexed:
                        break;
                    default:
                        Inform(this, "Hệ màu không hỗ trợ. Chỉnh lại cấu hình quét về màu RGB hoặc Grey 8-bit.");
                        return null;
                }
                acq = new Acquired(sourceBitmap, CoreMsgDelegates);
                acq.FileName = fileName;
            }
            catch (ArgumentException) { Inform(this, "Tệp'{0}' bị hỏng.", fileName); return null; }
            finally { fs.Close(); }
            Anchor anchor = new Anchor(acq, this.CoreMsgDelegates);
            anchor.Detect(AnchorType.TopLeft);
            anchor.Detect(AnchorType.TopRight);
            anchor.Detect(AnchorType.BottomLeft);
            anchor.Detect(AnchorType.BottomRight);             
            Inform(this,string.Format("Neo: TL{0}  TR{1}  BL{2}  BR{3}",
                anchor[AnchorType.TopLeft].ToString(),
                anchor[AnchorType.TopRight].ToString(),
                anchor[AnchorType.BottomLeft].ToString(),
                anchor[AnchorType.BottomRight].ToString()));
            if (anchor.Acceptable)
            {
                Interpret interpret = new Interpret(keys,acq, anchor, this.CoreMsgDelegates);
                interpret.FindAnswer();                
                interpret.FindStudent();
                interpret.FindProblem();
                interpret.FindGroup();
                interpret.FindMark();
                interpret.Result.root = anchor[AnchorType.TopLeft];
                interpret.Result.portion = keys.portion;
                return interpret.Result;
            }
            else return null;
        }
        /// <summary>
        /// Thực hiện tìm các file có khả năng nhận dạng trong path cho trước.
        /// Các file tìm thấy lưu trong instance ở biến FileList
        /// </summary>
        /// <param name="path"></param>
        /// <returns>Trả về bool: có tệp nào tìm thấy không</returns>
        public bool Folder(string path)
        {
            ArrayList files = new ArrayList();
            if (!Directory.Exists(path)) return false;
            Inform(this, "Tìm các ảnh quét được hỗ trợ trong thư mục: {0}", path);
            for (int i = 0; i < SupportFileTypes.Length; i++)
            {
                try
                {
                    files.AddRange(Directory.GetFiles(path,
                        SupportFileTypes[i], SearchOption.TopDirectoryOnly));
                }
                catch (Exception ex)
                {
                    Inform(this, "Lỗi: {1}", ex.Message);
                }
            }
            if (files.Count != 0)
            {
                FileList = (string[])files.ToArray(("").GetType());
                Inform(this, "Tìm thấy {0} tệp để xử lý.", FileList.Length);                            
                return true;
            }
            
            return false;
        }
        public void Analyze()
        {
        }

        internal Discover OneFileG2(string fileName, ref KeySuite keys)
        {
            if (!File.Exists(fileName))
            {
                Inform(this, "Tệp {0} không có thực!", fileName);
                return null;
            }
            else Inform(this, "Xử lý: '{0}'", fileName);
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            Acquired acq;
            try
            {
                Bitmap sourceBitmap = new Bitmap(fs);
                switch (sourceBitmap.PixelFormat)
                {
                    case PixelFormat.Format24bppRgb:
                    case PixelFormat.Format32bppArgb:
                    case PixelFormat.Format8bppIndexed:
                        break;
                    default:
                        Inform(this, "Hệ màu không hỗ trợ. Chỉnh lại cấu hình quét về màu RGB hoặc Grey 8-bit.");
                        return null;
                }
                acq = new Acquired(sourceBitmap, CoreMsgDelegates);
                acq.FileName = fileName;
            }
            catch (ArgumentException) { Inform(this, "Tệp'{0}' bị hỏng.", fileName); return null; }
            finally { fs.Close(); }
            Anchor anchor = new Anchor(acq, this.CoreMsgDelegates);
            anchor.Detect(AnchorType.TopLeft);
            anchor.Detect(AnchorType.TopRight);
            anchor.Detect(AnchorType.BottomLeft);
            anchor.Detect(AnchorType.BottomRight);
            Inform(this, string.Format("Neo: TL{0}  TR{1}  BL{2}  BR{3}",
                anchor[AnchorType.TopLeft].ToString(),
                anchor[AnchorType.TopRight].ToString(),
                anchor[AnchorType.BottomLeft].ToString(),
                anchor[AnchorType.BottomRight].ToString()));
            if (anchor.Acceptable)
            {
                InterpretG2 interpret = new InterpretG2(keys, acq, anchor, this.CoreMsgDelegates);
                interpret.FindAnswer();
                interpret.FindStudent();
                interpret.FindProblem();
                interpret.FindGroup();
                interpret.FindMark();
                interpret.Result.portion = keys.portion;
                interpret.Result.root = anchor[AnchorType.TopLeft];
                return interpret.Result;
            }
            else return null;
        }
    }
    /// <summary>
    /// Chứa các câu trả lời
    /// </summary>
    public class Interpret : CoreMsgCapable
    {
        [ThreadStatic]
        public static string KeySymbol = UI.Properties.Settings.Default.KeySymbol; // char[] Symbol = {'A', 'B', 'C', 'D'};        
        Acquired acq;
        internal Place place;
        internal KeySuite keys;
        /// <summary>
        /// Chứa kết quả quá trình interpret
        /// </summary>
        private Discover result = new Discover();        
        public Discover Result
        {
            get { return result; }
            set { result = value; }
        }
        public Interpret() { }
        public Interpret(KeySuite keys, Acquired acquired, Anchor anchor, CoreMsgEventHandler handler)
        {
            this.result = new Discover();
			this.result.file = acquired.FileName;
            this.CoreMsg += handler;
            this.acq = acquired;
            this.keys = keys;
            place = new Place(anchor, this.CoreMsgDelegates);
        }
		/// <summary>
		/// Cắt nguyên phần tên học sinh trong bài làm để lưu ra.
		/// </summary>
		public void FindName()
		{
			Bitmap bmp = (Bitmap)Bitmap.FromFile(acq.FileName);			
		}
        /// <summary>
        /// Nhận dạng bài làm.
        /// Xử lý với nhiều lựa chọn: lấy lựa chọn cuối cùng
        /// </summary>
        public void FindAnswer()
        {            
            for (int no = 1; no <= keys.questions; no++)
            {                
                for (int detail = 0; detail < 4; detail++)
                    if (acq.IsTicked(place.Where(PlaceType.Solution, no, detail)))
                    {
                        if (result[no] == -1) result[no] = detail;
                        else
                        {
                            result[no] = -1; // Đánh dấu thừa.
                            break;
                        }
                    }                
            }
            Inform(this, "\tBài làm:" + Core.Utility.ExplicitLook(result.Convert(keys.questions)));
        }
        /// <summary>
        /// Nhận dạng mã học sinh
        /// Kết quả lưu trong biến probem
        /// </summary>
        public void FindStudent()
        {
            result.student = 0;
            //Cột thứ nhất
            for (int no = 1; no <= 10; no++)
                if (acq.IsTicked(place.Where(PlaceType.Student, no, 0)))
                {
                    result.student = (no % 10) * 10;
                    break;
                }
            // Cột thứ hai
            for (int no = 1; no <= 10; no++)
                if (acq.IsTicked(place.Where(PlaceType.Student, no, 1)))
                {
                    result.student += (no % 10);
                    break;
                }
            Inform(this,string.Format("\tMã học sinh: {0}",result.student));
        }
        /// <summary>
        /// Nhận dạng mã đề
        /// </summary>
        public void FindProblem()
        {
            result.problem = 0;
            for (int no = 1; no <= 10; no++)
                if (acq.IsTicked(place.Where(PlaceType.Problem, no, 0)))
                    result.problem = result.problem * 10 + no % 10;
            Inform(this, string.Format("\tMã đề: {0}", result.problem));
        }
        /// <summary>
        /// Nhận dạng mã lớp
        /// </summary>
        public void FindGroup()
        {
            //Cột thứ nhất
            result.group = 0;
            for (int no = 1; no <= 10; no++)
                if (acq.IsTicked(place.Where(PlaceType.Class, no, 0)))
                    result.group = result.group * 10 + no % 10;
            Inform(this, string.Format("\tMã lớp: {0}", result.group));
        }
        /// <summary>
        /// Tính điểm.
        /// </summary>
        public void FindMark()
        {
            
            result.mark = -1;                        
            if (this.keys != null)
            {
                foreach (Key key in keys.Items)
                {                    
                    key.key = Utility.Clarify(key.key);
                    if (key.problem == this.result.problem)
                    {
                        result.mark = 0;
                        for (int i = 0; i < keys.questions; i++)
                            if (result.answer[i] == key.key[i] || key.key[i] == UI.Properties.Settings.Default.BlankChar)
                                result.mark++;
                        result.mark = UI.Properties.Settings.Default.MarkTheme * result.mark / keys.questions;
                    }
                }
            }
            if (result.mark == -1)
                Inform(this, string.Format("Bài làm HS: {0} mã đề: {1} không đúng.",
                    result.student, result.problem));
            else Inform(this, string.Format("\tĐiểm: {0}", result.mark));

            FindXMark();
        }
        public void FindXMark()
        {
            result.xmark = 0;
            result.portion = keys.portion;
            if (keys.portion != 100 && keys.portion != 0)
            {
                if (acq.IsSmallTicked(place.Where(PlaceType.XMark, 10, 0)))
                {
                    result.xmark = 10;

                    return;
                }
                else
                {
                    if (acq.IsSmallTicked(place.Where(PlaceType.XMark, 11, 0)))
                    {
                        result.xmark = 0.5f;
                    }
                    for (int i = 0; i <= 9; i++)
                    {
                        if (acq.IsSmallTicked(place.Where(PlaceType.XMark, i, 0)))
                        {
                            result.xmark += i;
                            break;
                        }
                    }
                }
                Inform(this, "Tỉ lệ điểm: " + result.portion + "%. Điểm tự luận: " + result.xmark);
            }
        }
    }    
    /// <summary>
    /// Thông tin tham chiếu.
    /// Được nạp một lần lúc bắt đầu chạy chương trình và 
    /// thông tin được cập nhật theo yêu cầu người dùng.
    /// </summary>
    public class Ref
    {
        /// <summary>
        /// Đối tượng tĩnh, chứa tất cả các thông tin về các lớp hiện đang được sử dụng.
        /// </summary>
        public static Groups UniGroup;
        /// <summary>
        /// Đối tượng tĩnh, chứa tất cả các bộ đáp án được nạp.
        /// </summary>
        public static SuiteList UniSuite;
    }    
}
