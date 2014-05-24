
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlServerCe;

using GiangManh.Utility;
using System.Windows.Forms;
using System.Globalization;

namespace GiangManh.Locate
{
    
    [Flags]
    public enum Signal {
        NULL = 0x00,
        /// <summary>
        /// ╔ góc trên trái - A
        /// </summary>
        A = 0x01, 
        /// <summary>
        /// ╚ góc dưới trái - B
        /// </summary>
        B = 0x02,
        /// <summary>
        /// ╝ góc dưới phải - C
        /// </summary>
        C = 0x04, 
        /// <summary>
        /// ╗ góc trên phải - D
        /// </summary>
        D = 0x08};
    public class Result
    {
        /// <summary>
        /// Tọa độ gốc
        /// </summary>
        public Point root;
        /// <summary>
        /// Kiểu tọa độ gốc
        /// </summary>
        public Signal type;
        /// <summary>
        /// Độ nghiêng (tính bằng rad)
        /// </summary>
        public double tilt;
        /// <summary>
        /// Tỉ lệ so với kích thước lý thuyết.
        /// </summary>
        public double ratio;
        public float x_ratio;
        public float y_ratio;
        public override string ToString()
        {
            return string.Format("root:{0}, type:{1}, tilt:{2}, ratio:{3}%",root,type,tilt.ToString("0.0000"),(ratio*100).ToString("00.00"));
        }
        
    }
    /// <summary>
    /// Nhận dạng. Tham số cần truyền (nếu muốn)
    ///     + CanAskUserHelp
    ///     + PriorOrder
    /// </summary>
    public class Anchor : MessageCapable
    {
        public static float WorkDpi = 100;
        /// <summary>
        /// Tỉ lệ đơn vị đo thực và lý thuyết. (mm/inch -> pixel)
        /// </summary> 
        public const float MeasureUnitRatio = 25.4f;         
        #region Hằng số đã tối ưu và thử nghiệm, không nên thay đổi giá trị
        /// <summary>
        /// Ngưỡng sáng tối dành cho điểm bên trong
        /// </summary>
        private static byte bwThreshold = 153;
        /// <summary>
        /// Ngưỡng sáng tối dành cho điểm rìa. 
        /// Cho giá trị với điểm rìa mờ
        /// </summary>
        private static byte blurThreshold = 217;          
        /// <summary>
        /// bán kính dấu hiệu điểm neo (tính theo milimetre)
        /// </summary>
        private static float signRadiusMm = 3.0f;
        private static int edgeTestSize = 2;
        private static int egdePrecision = 2;
        #endregion         
        private Bitmap bitmap;
        private Utility.ImageMap m;
        private static int limit;
        private static int R;        
        public static Point NOT_FOUND = new Point(0,0);
        Hashtable output = new Hashtable(4);        
        /// <summary>
        /// Có thể mở cửa sổ hỏi người dùng không?
        /// </summary>
        public bool CanAskUserHelp;
        /// <summary>
        /// Thứ tự ưu tiên tìm kiếm và tính toán
        /// </summary>
        private Signal[] priorOrder = { Signal.A, Signal.B, Signal.C, Signal.D };
        private Signal[] use;        
        /// <summary>
        /// Ưu tiên tìm hai điểm xác định, thường là trên đường chéo
        /// sẽ dùng 1 điểm là gốc, một điểm để tính góc quay.
        /// Nếu là null sẽ theo thứ tự A,B,C và D
        /// </summary>
        public Signal[] PriorOrder
        {
            get { return priorOrder; }
            set { priorOrder = value; }
        }
        public bool Acceptable
        {
            get
            {        
                int[] found = new int[4];
                int i = 0;
                int success = 0;
                foreach (Signal signal in priorOrder)
                {
                    found[i] = this[signal].IsEmpty ? 0 : 1;                    
                    success += found[i];
                    i++;
                }                
                if (success < 2)
                {
                    i = 0;
                    int retry = 0;
                    if (priorOrder != null)
                        
                    foreach (Signal signal in priorOrder)
                    {
                        if (found[i] == 0 && retry < 2 && CanAskUserHelp == true)
                        {
                            FormUserHelp fuh = new FormUserHelp();
                            FormUserHelp.Data data = new FormUserHelp.Data(this.bitmap, signal);
                            fuh.Tag = data;                            
                            fuh.Init();
                            if (fuh.ShowDialog() == DialogResult.OK)
                            {
                                retry++;
                                output[signal] = data.UserAnswer;
                            }
                        }
                        else retry++;
                        i++;
                    }
                    success = retry;
                }
                
                if (success >= 2)
                {
                    
                    return true;
                }
                else
                    return false;
            }
        }
        public Anchor() { }
        public Anchor(Image img)
        {
            if (img.VerticalResolution - WorkDpi <= 1)
                bitmap = (Bitmap)img;
            else
                bitmap = (Bitmap)Utility.ManipulateImage.Resample(WorkDpi, img);
            m = new ImageMap(bitmap);
            Init();
        }
        public void Init()
        {
            R = (int)Math.Round(signRadiusMm * WorkDpi / MeasureUnitRatio);
            limit = m.width / 5; // 20% the width    
            blackAreaThreshold = 9 * bwThreshold;
        }
        private bool blur(int x, int y)
        {
            return m.map[x + y*m.width] < blurThreshold;
        }
        /// <summary>
        /// Chú ý: phải đảm bảo tọa độ x,y nằm trong bound của bitmap
        /// [deprecated] slowly!!!
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>1: điểm bị tô;  0: điểm không bị tô</returns>
        private int black(int x, int y)
        {
             return bitmap.GetPixel(x, y).GetBrightness() < bwThreshold ? 1 : 0;
        }
        /// <summary>
        /// Đếm số điểm tô lọt vào một vùng hình vuông; (cx,cy) là tọa độ tâm
        /// </summary>
        /// <param name="cx"></param>
        /// <param name="cy"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        private int box(int cx, int cy, int r)
        {
            int fill = 0;
            for (int y = -r + cy; y <= r + cy; y++)
                for (int x = -r + cx; x <= r + cx; x++)
                    fill += m.map[x + y * m.width] < bwThreshold ? 1 : 0;
            return fill;
        }

        private bool isEdge(int x, int y,Point direct)
        {            
            // Hướng thuận
            int side1 = box(x + direct.X, y + direct.Y, edgeTestSize);
            // Hướng nghịch;
            int side2 = box(x - direct.X, y - direct.Y, edgeTestSize);
            return (side1 >= edgeTestSize*edgeTestSize - egdePrecision) && (side2 <= egdePrecision);
        }
        int peak_x_y;
        int peak_y;
        /// <summary>
        /// Có là đỉnh theo 1 hướng xác định?
        /// Ví dụ hướng (1,1)
        /// Dạng:
        ///      ■ ■ 
        ///      ■ ● □
        ///        □ □
        ///        
        /// Trong đó ● là điểm hiện tại
        ///          ■ là bị tô
        ///          □ là ko bị tô
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="direct"></param>
        /// <returns></returns>        
        private bool isPeak(int x, int y, Point direct)
        {
            peak_x_y = x + y * m.width;
            peak_y = direct.Y *m.width;
            if (!(m.map[direct.X + peak_x_y] < blurThreshold                
                  || m.map[peak_x_y + peak_y ] < blurThreshold
                  || m.map[ direct.X +  peak_y + peak_x_y] < blurThreshold))
            {
                if (m.map[peak_x_y - direct.X] < blurThreshold 
                    && m.map[peak_x_y - peak_y] < blurThreshold
                    && m.map[peak_x_y - direct.X - peak_y] < blurThreshold)
                {
                    return true;
                }
            }
            return false;
        }
        public Point this[Signal signal]
        {
            get
            {
                if (output.ContainsKey(signal))
                    return (Point)output[signal];
                else
                    return Find(signal);
            }
        }
        public Point Find(Signal signal)
        {            
            Point result = NOT_FOUND;
            Point direct = NOT_FOUND;
            Point start = NOT_FOUND;
            // Cộng để tránh OutOfBound trong khi GetPixel 
            // vì chắc chắn neo không ở gần rìa với khoảng cách R
            R = R + 1;
            switch (signal)
            {
                case Signal.A:
                    direct = new Point(1, 1);
                    start = new Point(R, R);
                    break;
                case Signal.B:
                    direct = new Point(1, -1);
                    start = new Point(R, m.height - R);
                    break;
                case Signal.C:
                    direct = new Point(-1, -1);
                    start = new Point(m.width - R, m.height - R);
                    break;
                case Signal.D:
                    direct = new Point(-1, 1);
                    start = new Point(m.width - R, R);
                    break;
            }
            R = R - 1;
            for (int y = start.Y; Math.Abs(y - start.Y) < limit; y += direct.Y)
            {
                for (int x = start.X; Math.Abs(x - start.X) < limit; x += direct.X)
                    if (isPeak(x, y, direct))
                        if (box(x - direct.X * R / 2, y - direct.Y * R / 2, 1) >= 7f)
                            if (box(x + direct.X * R / 2, y + direct.Y * R / 2, 1) <= 2f)
                                //if (box(x + direct.X * 2 * R, y + direct.Y * 2 * R, 1) <= 2f)
                                    if (box(x - direct.X * edgeTestSize, y + direct.Y * edgeTestSize, 1) <= 2f)
                                        if (box(x + direct.X * edgeTestSize, y - direct.Y * edgeTestSize, 1) <= 2f)
                                        {
                                            result = new Point(x, y);
                                            goto Finish;
                                        }
            }
        // Label Finish
        Finish:
            if (result.IsEmpty)
            {
                //result = Detect(signal);
            }
            this.output[signal] = result;
            if (this.CanMessage)
            {
                SendObject(this, signal, result.ToString());
            }
            return result;

        }
        /// <summary>
        /// Sử dụng chỉ khi Acceptable là true
        /// </summary>
        /// <param name="dimension">Kích thước các điểm định vị trên lý thuyết (milimet)
        /// Càng chính xác càng tốt
        /// </param>
        /// <returns></returns>
        public Locate.Result GetResult(PointF dimension)
        {            
            Locate.Result r = new Result();
            // gather in-use signals 
            int i = 0;
            Signal flag = 0;
            use = new Signal[2];
            foreach (Signal loc in priorOrder)
            {
                if (i < 2 && this[loc] != NOT_FOUND)
                {
                    use[i] = loc;
                    i++;
                    flag = flag | loc;                    
                }
            }
            // quyết định root và tính góc nghiêng, độ biến dạng
            // chiều quay: chiều dương là ngược chiều kim đồng hồ.
            PointF theoryDimension = new PointF(
                dimension.X * WorkDpi / MeasureUnitRatio,
                dimension.Y * WorkDpi / MeasureUnitRatio);
            PointF displace = new PointF();
            double theoryLength = 0;
            double actualLength = 0;            
            switch (flag)
            {
                case Signal.A | Signal.B:
                    r.root = this[Signal.A];
                    r.type = Signal.A;
                    displace = new PointF(
                        this[Signal.B].Y - this[Signal.A].Y
                        ,this[Signal.B].X - this[Signal.A].X);
                    theoryLength = theoryDimension.Y;
                    r.tilt = Math.Atan2(displace.Y, displace.X);
                    break;
                case Signal.A | Signal.C:
                    r.root = this[Signal.A];
                    r.type = Signal.A;
                    displace = new PointF(
                         this[Signal.C].X - this[Signal.A].X
                        ,this[Signal.C].Y - this[Signal.A].Y);
                    theoryLength = Miscellaneous.VectorLength(theoryDimension);
                    // complement, phần bù đối với hai điểm chéo         
                    r.tilt = (-Math.Atan2(theoryDimension.X, theoryDimension.Y)
                        + Math.Atan2(displace.X, displace.Y));
                    break;
                case Signal.A | Signal.D:
                    r.root = this[Signal.A];
                    r.type = Signal.A;
                    displace = new PointF(
                        this[Signal.D].Y - this[Signal.A].Y,
                        this[Signal.D].X - this[Signal.A].X);
                    theoryLength = theoryDimension.X;
                    r.tilt = -Math.Atan2(displace.X,displace.Y);
                    break;
                case Signal.B | Signal.C:
                    r.root = this[Signal.B];
                    r.type = Signal.B;
                    displace = new PointF(
                        this[Signal.C].Y - this[Signal.B].Y,
                        this[Signal.C].X - this[Signal.B].X);
                    theoryLength = theoryDimension.X;
                    r.tilt = -Math.Atan2(displace.X, displace.Y);
                    break;
                case Signal.B | Signal.D:
                    r.root = this[Signal.B];
                    r.type = Signal.B;
                    displace = new PointF(
                         this[Signal.D].X - this[Signal.B].X
                        , this[Signal.D].Y - this[Signal.B].Y);
                    theoryLength = Miscellaneous.VectorLength(theoryDimension);
                    // complement, phần bù đối với hai điểm chéo         
                    r.tilt = (Math.Atan2(theoryDimension.X, theoryDimension.Y)
                        - Math.Atan2(displace.X, -displace.Y));
                    break;
                case Signal.C | Signal.D:
                    r.root = this[Signal.C];
                    r.type = Signal.C;
                    displace = new PointF(
                        this[Signal.D].Y - this[Signal.C].Y
                        , this[Signal.D].X - this[Signal.C].X);
                    theoryLength = theoryDimension.Y;
                    r.tilt = -Math.Atan2(displace.Y, -displace.X);
                    break;
            }
            #region Ratio
            actualLength = Miscellaneous.VectorLength(displace);            
            r.ratio = actualLength / theoryLength;
            if (!this[Signal.A].IsEmpty)
            {
                if (!this[Signal.B].IsEmpty && !this[Signal.C].IsEmpty)
                {
                    r.y_ratio = (float)Miscellaneous.VectorLength(this[Signal.A], this[Signal.B]) / theoryDimension.Y;
                    r.x_ratio = (float)Miscellaneous.VectorLength(this[Signal.C], this[Signal.B]) / theoryDimension.X;
                }
                else if (!this[Signal.D].IsEmpty && !this[Signal.C].IsEmpty)
                {
                    r.x_ratio = (float)Miscellaneous.VectorLength(this[Signal.A], this[Signal.D]) / theoryDimension.X;
                    r.y_ratio = (float)Miscellaneous.VectorLength(this[Signal.C], this[Signal.D]) / theoryDimension.Y;
                }
                else if (!this[Signal.B].IsEmpty && !this[Signal.D].IsEmpty)
                {
                    r.x_ratio = (float)Miscellaneous.VectorLength(this[Signal.A], this[Signal.D]) / theoryDimension.X;
                    r.y_ratio = (float)Miscellaneous.VectorLength(this[Signal.B], this[Signal.A]) / theoryDimension.Y;
                }
            }
            #endregion
            return r;
        }        
        #region Phương án dự bị
        Color c;
        private byte _BlackWhiteThreshold = 160;                
        int blackAreaThreshold;
        
        public int blackarea(int x, int y)
        {
            return (m.map[x - 1 + (y - 1) * m.width]
                    + m.map[x + (y - 1) * m.width]
                    + m.map[x + 1 + (y - 1) * m.width]
                    + m.map[x - 1 + y * m.width]
                    + m.map[x + y * m.width]
                    + m.map[x + 1 + y * m.width]
                    + m.map[x - 1 + (y + 1) * m.width]
                    + m.map[x + (y + 1) * m.width]
                    + m.map[x + 1 + (y + 1) * m.width])
                    / blackAreaThreshold;
                    
        }
        /// <summary>
        /// deprecated: slowly!!!
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int isblack(int x, int y)
        { return m.map[x + y * m.width] < bwThreshold ? 1 : 0; }
        public Point Detect(Signal signal)
        {                        
            int dDiagonal = (int)Math.Round((signRadiusMm * WorkDpi / MeasureUnitRatio)/Math.Sqrt(2));                
            int dx, dy;
            int startX, startY, endX, endY, stepX, stepY;
            dx = dy = startX = startY = endX = endY = stepX = stepY = 0;
            bool hasTry = false; // Giới hạn detect lại
            int tryRange = 3;
            while (!hasTry)
            {
                switch (signal)
                {
                    #region Khởi tạo các giá trị dx,dy, ...
                    case Signal.A:
                        dx = -1;
                        dy = -1;
                        startX = dDiagonal;
                        endX = limit;
                        startY = dDiagonal;
                        endY = limit;
                        stepX = 1;
                        stepY = 1;
                        break;
                    case Signal.B:
                        dx = -1;
                        dy = 1;
                        startX = dDiagonal;
                        endX = limit;
                        startY = m.height - dDiagonal;
                        endY = m.height - limit;
                        stepX = 1;
                        stepY = -1;
                        break;
                    case Signal.C:
                        dx = 1;
                        dy = 1;
                        startX = m.width - dDiagonal;
                        endX = m.width - limit;
                        startY = m.height - dDiagonal;
                        endY = m.height - limit;
                        stepX = -1;
                        stepY = -1;
                        break;
                    case Signal.D:
                        dx = 1;
                        dy = -1;
                        startX = m.width - dDiagonal;
                        startY = dDiagonal;
                        endX = m.width - limit;
                        endY = limit;
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
                            ((isblack(x, y) + isblack(x + dx, y + dy)
                                + isblack(x + dx, y) + isblack(x, y + dy)) >= 3)
                            // Hướng ngược lại là trắng
                            && ((isblack(x - dx, y - dy)
                                + isblack(x - dx, y) + isblack(x, y - dy)) == 0)
                            // Tâm hướng chéo trên phải đậm
                            && (blackarea(x + dDiagonal * dx / 2, y + dDiagonal * dy / 2) >= 6)
                            // Điểm xa chéo là trống.
                            && (isblack(x + 2 * dDiagonal * dx, y + 2 * dDiagonal * dy) == 0))
                        {
                            return new Point(x, y);
                        }
                    }
                }
                hasTry = true;
                dDiagonal = dDiagonal - tryRange;                

            }
            return new Point(-1, -1);
        }
        #endregion
        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}", 
                this[Signal.A], this[Signal.B], this[Signal.C], this[Signal.D]);            
        }
    }    
}
