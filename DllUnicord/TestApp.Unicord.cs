/*
 * 
 * Nhận dạng điểm đánh dấu trên hệ lưới đối tượng thống nhất Unicord
 * Mô tả các mẫu bằng hệ thống lưới thống nhất
 * Chuyển đổi sang dữ liệu cần thiết.
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using GiangManh;
namespace GiangManh.TestApp.Unicord
{
    /// <summary>
    /// Thiết lập Offset, First rồi mới đến Capacity
    /// </summary>
    public class Group : GiangManh.Utility.CallRecognizeCapable
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public static PointF Vertical = new PointF(0, 6);
        public static PointF Horizonal = new PointF(6, 0);

        private PointF offset = Group.Horizonal; // mặc định là ngang.
        /// <summary>
        /// Hướng của dãy các thành phần trong nhóm
        /// Khoảng cách giữa hai thành phần kề nhau
        /// Có hai giá trị thiết lập sẵn trong class này
        /// </summary>
        public PointF Direction
        {
            get { return offset; }
            set { offset = value; }
        }
        private PointF first;
        public PointF First
        {
            get { return first; }
            set { first = value; }
        }
        public Group(PointF offset, PointF first, int capacity)
        {
            this.offset = offset;
            this.first = first;
            this.Capacity = capacity;
        }
        /// <summary>
        /// mm. Chuyển đổi là việc của recongizer
        /// </summary>
        PointF[] members;
        private int[] value;
        internal void getValue()
        {
            hasnotGetValue = false;
            value = new int[capacity];
            for (int i = 0; i < members.Length; i++)
            {
                value[i] = Recognize(members[i]);
            }
        }
        private bool hasnotGetValue = true;
        /// <summary>
        /// Khi lấy giá trị:
        /// Nếu chưa lấy lần nào, thực hiện Recognize và phân tích giá trị
        /// Nếu đã từng lấy thì trả về giá trị đó.
        /// </summary>
        public int Value
        {
            get
            {
                if (hasnotGetValue) getValue();
                return  Utility.Miscellaneous.GetNumber(value);
            }            
        }
        public int[] ValueArray
        {
            get
            {
                if (hasnotGetValue) getValue(); 
                return value;
            }
        }
        public PointF[] Members
        {
            get { return members; }
            set { members = value; }
        }
        private int capacity;
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; SetMemebers(); }
        }
        /// <summary>
        /// Thiết lập các điểm cần nhận dạng (mm).
        /// </summary>
        public void SetMemebers()
        {
            members = new PointF[capacity];            
            members[0] = first;
            for (int i = 1; i < capacity; i++)
            {                
                members[i] = new PointF(
                    members[i - 1].X + offset.X, 
                    members[i - 1].Y + offset.Y);
            }
        }
    }
    public class Template 
    {
        public Group[] group;
        string name;
        public Utility.RecognizeEventHandler recognizer;
        public Template(Utility.RecognizeEventHandler recognizer) { this.recognizer = recognizer; }
        public void Process()
        {
            if (group != null && recognizer != null)
            {
                for (int i = 0; i < group.Length; i++)
                {
                    group[i].Recognizer += recognizer;
                    group[i].getValue();
                }
            }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }    
}
