using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using GiangManh.Utility;

namespace GiangManh.TestApp
{
    public class Recognizer
    {
        /// <summary>
        /// mm - bán kính của tick
        /// </summary>
        public float TickRadius = 2;
        /// <summary>
        /// Gọi Init() nếu thay đổi giá trị này
        /// </summary>
        public float AcceptThreshold = 0.5f;
        public byte BlackWhiteThreshold = 220;
        Locate.Result locate;
        ImageMap m;
        Miscellaneous.MmConverter converter;
        public Recognizer() { }
        public Recognizer(Locate.Result locate, Bitmap bmp)
        {
            m = new GiangManh.Utility.ImageMap(bmp);
            this.locate = locate;
            converter = new Miscellaneous.MmConverter();
            converter.Dpi4mmToPixel = Locate.Anchor.WorkDpi;
            converter.ScaleX = locate.x_ratio;
            converter.ScaleY = locate.y_ratio;
            Init();
        }
        public void Init()
        {
            rx = converter.MmToPixelByX(TickRadius);
            ry = converter.MmToPixelByY(TickRadius);
            threshold = (int)Math.Round(AcceptThreshold * rx * ry * Math.PI);
        }
        /// <summary>
        /// Bán kính theo hai hướng khác nhau.
        /// </summary>
        int rx, ry;  
        /// <summary>
        /// Ngưỡng tô
        /// </summary>
        int threshold;
        int fill,y,x;
        public void Process(object sender, Utility.CallRecognizeEventArgs e)
        {
            Point c = new Point(converter.MmToPixel(e.Position));
            c.Offset(locate.root);
            fill = 0;
            for (y = 0; y < ry; y++)
                for (x = 0; x < rx; x++)
                    if (m.map[x + y * m.width] < BlackWhiteThreshold) fill++;
            e.IsFill = fill >= threshold ? 1 : 0;
        }
    }
}
