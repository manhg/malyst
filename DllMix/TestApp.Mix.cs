/* 
 * TestApp
 * Author: Giang Manh
 * 2008
 * 
 */
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Drawing;
using System.Text;

namespace GiangManh.TestApp.Mix
{    
    public class Setting
    {
        private GiangManh.Locate.AcquisitionSetting acquisition = new GiangManh.Locate.AcquisitionSetting();
        /// <summary>
        /// Acquistion.HqimgId đánh số theo kiểu:
        /// Hàng đơn vị là vùng trong một câu. 0 - 3 là bốn phương án ABCD, 4 là câu hỏi
        /// Số của các hàng còn lại là số thứ tự câu hỏi
        /// </summary>
        public GiangManh.Locate.AcquisitionSetting Acquisition
        {
            get { return acquisition; }
            set { acquisition = value; }
        }
        public Setting()
        {
            this.acquisition.Name = "Mix";            
            this.acquisition.Prior = new Locate.Signal[] { Locate.Signal.A, Locate.Signal.B, Locate.Signal.C };
            this.acquisition.Dimension = new PointF(Spec.Width, Spec.Height);
        }
        private Spec.Type type;

        public Spec.Type Type
        {
            get { return type; }
            set
            {
                type = value;
                this.Acquisition.SessionName = Spec.GetName(type);
                this.capacity = Spec.GetCapacity(type);
                int tagline = Spec.GetLineTag(type);
                acquisition.HqRegion = new RectangleF[5 * capacity];
                acquisition.HqRegionId = new int[acquisition.HqRegion.Length];
                Spec.HqRegion hqregion = Spec.GetHqRegions(type);
                hqregion.Offset(Spec.Offset);                     
                for (int i = 0; i < capacity; i++)
                {
                    RectangleF[] regionThisTag = hqregion.Offset(i*tagline);
                    regionThisTag.CopyTo(acquisition.HqRegion, 5 * i);
                    for (int j = 0; j < 5; j++)
                    {
                        acquisition.HqRegionId[i * 5 + j] = i * 10 + j;
                    }
                }
            }
        }
        private int capacity;
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
    }
    /// <summary>
    /// Phải gọi init trước khi sử dụng đối tượng này
    /// </summary>
    public class Spec
    {
        public static float Width = 180;
        public static float Height = 260;
        public static float Line = 8;
        /// <summary>
        /// offset từ gốc (mặc định là Signal.A) đến góc trên trái của đề bài
        /// </summary>
        public static PointF Offset = new Point(0, 6);
        /// <summary>
        /// Với N,T,H,V, lấy log2(x) sẽ ra số tương ứng
        /// Với _1, _2, _3, _4, lấy log2(x/16) sẽ ra số tương ứng
        /// </summary>
        [Flags]
        public enum Type { 
            NULL = 0,
            /// <summary>
            /// Câu ngắn
            /// </summary>
            N = 1, 
            /// <summary>
            /// Câu trung bình
            /// </summary>
            T = 2,
            /// <summary>
            /// Câu có hình minh họa, câu dài
            /// </summary>
            H = 4, 
            /// <summary>
            /// Câu có đoạn văn hay các câu có dữ kiện chung
            /// </summary>
            V = 8,
            X = 1024,
            /// <summary>
            /// 1 dòng 4 phương án
            /// </summary>
            _0 = 16,
            /// <summary>
            /// 2 dòng, mỗi dòng 2 phương án
            /// </summary>
            _1 = 32,
            /// <summary>
            /// 4 dòng, mỗi dòng 1 phương án
            /// </summary>
            _2 = 64,
            /// <summary>
            /// 8 dòng, 2 dòng 1 phương án
            /// </summary>
            _3 = 128};                        
        /// <summary>
        /// Dạng câu hỏi
        /// </summary>
        public static Spec.Type[] Classes = new Type[] { Type.N, Type.T,Type.H,Type.V };
        /// <summary>
        /// Dạng trình bày phương án
        /// </summary>
        public static Type[] Layout = new Type[] {Type._0, Type._1, Type._2, Type._3 };
        private static Hashtable capacity = new Hashtable();
        public static int GetCapacity(Spec.Type type)
        {
            Spec.Type pure = Spec.GetPureType(type);
            if (Spec.capacity.ContainsKey(pure))
            {
                return (int)Spec.capacity[pure];
            }
            else return -1;
        }
        public static Spec.Type GetPureType(Spec.Type type) { return Spec.GetClass(type) | Spec.GetLayout(type); }
        private static bool isInitialized = false;
        public static void Init()
        {
            if (!isInitialized)
            {
                #region Capacity
                Spec.capacity.Add(Type.N | Type._0, 14);
                Spec.capacity.Add(Type.N | Type._1, 9);
                Spec.capacity.Add(Type.N | Type._2, 7);
                #endregion
                #region Line
                line.Add(Type._0, 1);
                line.Add(Type._1, 2);
                line.Add(Type._2, 4);
                line.Add(Type._3, 8);
                line.Add(Type.N, 1);
                line.Add(Type.T, 3);
                line.Add(Type.H, 5);
                line.Add(Type.V, 10);
                line.Add(Type.X, 0);
                line.Add(Type.NULL, 0);
                #endregion
                isInitialized = true;
            }
        }
        
        /// <summary>
        /// Lấy tên của một Spec.Type
        /// </summary>
        /// <param name="obj">Tổ hợp của các Spec.Type</param>
        /// <returns></returns>
        public static string GetName(Spec.Type type)
        {
            return string.Format("{0}{2}{1}", 
                GetClass(type),GetLayout(type), GetHandWriting(type) ? "X" : "");
        }
        public static Spec.Type GetClass(Spec.Type type)
        {            
            foreach (Spec.Type clss in Spec.Classes)
                if ((type & clss) != 0)
                {
                    return clss;
                }
            return Spec.Type.NULL;
        }
        public static Spec.Type GetLayout(Spec.Type type)
        {
            foreach (Spec.Type layout in Spec.Layout)
                if ((type & layout) != 0)
                {
                    return layout;
                }
            return Spec.Type.NULL;
        }
        public static Spec.Type GetType(int[] signal)
        {
            if (signal.Length == 5)
            {
                Spec.Type clss = (Type) (1 <<(signal[1] * 2 + signal[0]));
                Spec.Type layout = (Type) (16 * (1 << (signal[3] * 2 + signal[2])));
                Spec.Type handwriter = signal[4] == 1 ? Type.X : Type.NULL;
                return (clss | layout | handwriter);
            }
            else return Type.NULL;
        }
        public static bool GetHandWriting(Spec.Type type) { return ((type & Type.X) != 0 ? true : false); }
        private static Hashtable line = new Hashtable();
        public static int GetLine(Spec.Type type)
        {
            if (Spec.line.ContainsKey(type)) return (int)line[type];
            else return -1;
        }
        public static int GetLineTag(Spec.Type type)
        {
            return GetLine(GetClass(type)) + GetLine(GetLayout(type));
        }
        /// <summary>
        /// Thông tin về region chứa trong
        /// một mảng Rectangle[6], Rectangle[0] chứa toàn bộ, 
        /// Rectangle[1] đến 4 là các phương án trả lời
        /// Rectangle[5] là câu hỏi
        /// </summary>
        public class HqRegion
        {
            private RectangleF[] region = new RectangleF[6];
            public RectangleF[] Raw
            {
                get { 
                    return new RectangleF[5] 
                        { this.Question, this.A, this.B, this.C, this.D }; 
                }
            }
            #region acessors
            public RectangleF Skin
            {
                get { return region[0]; }
                set { region[0] = value; }
            }
            public RectangleF Question
            {
                get { return region[5]; }
                set { region[5] = value; }
            }
            public RectangleF A
            {
                get { return region[1]; }
                set { region[1] = value; }
            }
            public RectangleF B
            {
                get { return region[2]; }
                set { region[2] = value; }
            }
            public RectangleF C
            {
                get { return region[3]; }
                set { region[3] = value; }
            }
            public RectangleF D
            {
                get { return region[4]; }
                set { region[4] = value; }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="no">0 - 3</param>
            /// <returns></returns>
            public RectangleF this[int no] 
            {
                get { return region[no + 1]; }
                set { region[no + 1] = value; }
            }
            #endregion     
            /// <summary>
            /// Offset cho tất cả các region, lưu thay đổi vào đây
            /// </summary>
            /// <param name="root">Độ offset</param>
            public void Offset(PointF root)
            {
                for(int i=0;i<region.Length;i++)
                {
                    this.region[i].Offset(root.X, root.Y);
                }
            }
            /// <summary>
            /// Offset cho tất cả các region, tạo ra bộ mới
            /// </summary>
            /// <param name="tag">STT của câu hỏi</param>
            /// <returns></returns>
            public RectangleF[] Offset(int tag)
            {
                RectangleF[] r = new RectangleF[5];
                Array.Copy(region, 1, r, 0, 5);
                for (int i = 0; i < 5; i++)
                {
                    r[i].Offset(0, tag * Spec.Line);
                }
                return r;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static HqRegion GetHqRegions(Spec.Type type)
        {
            HqRegion r = new HqRegion();
            Type layout = GetLayout(type);
            int ques_line = GetLine(GetClass(type));
            int choice_line = GetLine(layout);
            r.Skin = new RectangleF(0, 0,
                Spec.Width, (ques_line + choice_line) * Spec.Line);
            r.Question = new RectangleF(0, 0, 
                Spec.Width, ques_line * Spec.Line);
            for (int i = 0; i < 4; i++)
            {
                switch (layout)
                {
                    case Type._0:
                        r[i] = new RectangleF(
                            i * Spec.Width / 4, r.Question.Height,
                            Spec.Width / 4, Spec.Line);
                        break;
                    case Type._1:
                        r[i] = new RectangleF(
                            (i % 2) * Spec.Width / 2, r.Question.Height + (i / 2) * Spec.Line,
                            Spec.Width / 2, Spec.Line);
                        break;
                    case Type._2:
                        r[i] = new RectangleF(
                            0, r.Question.Height + i * Spec.Line,
                            Spec.Width, Spec.Line);
                        break;
                    case Type._3:
                        r[i] = new RectangleF(
                            0, r.Question.Height + i * Spec.Line,
                            Spec.Width, 2* Spec.Line);
                        break;
                }
            }
            return r;
        }
        /// <summary>
        /// Lấy vùng bên trong một biên
        /// </summary>
        /// <param name="region"></param>
        /// <param name="safemargin">Khoảng cách an toàn để hình không bị mất mà vẫn giữ khoảng cách với biên</param>
        /// <returns></returns>
        public static RectangleF GetSafeRegion(RectangleF region, float safemargin)
        {
            return new RectangleF(
                region.X + safemargin,
                region.Y + safemargin,
                region.Width - 2 * safemargin,
                region.Height - 2 * safemargin);
        }
    }
}
