/**
 * Chức năng:
 * Các định nghĩa về lớp kết hợp sử dụng để mô tả XML
 * Các lớp này có thể trực tiếp serialize để lưu ra dưới dạng XML
 * và ngược lại, đọc trực tiếp file XML và chuyển thẳng vào thể hiện của đối tượng
 * 
 * Mục đích: 
 * + Đơn giản hóa quá trình nhập xuất của chương trình
 * + Tương thích cao, chuẩn hóa.
 */
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Text.RegularExpressions;

namespace Core
{
    /// <summary>
    /// Lớp XML Serialzation để nhập xuất thông tin về lớp/học sinh
    /// Để tránh trùng với từ khóa class, ta gọi một lớp là một *group*
    /// </summary>
    [XmlRoot("groups")]
    public class Groups
    {
        private ArrayList groups;
        public Groups() { groups = new ArrayList(); }
        [XmlElement("group")]
        public Group[] Items
        {
            get
            {
                Group[] rg = new Group[groups.Count];
                groups.CopyTo(rg);
                return rg;
            }
            set
            {
                if (value == null) return;
                Group[] sg = (Group[])value;
                groups.Clear();
                foreach (Group g in sg) groups.Add(g);
            }
        }
        public int AddItem(Group g)
        { return groups.Add(g); }
        public Group this[int code]
        {
            get
            {
                foreach (Group g in groups)
                    if (g.code == code) return g;
                return null;
            }
        }
        public override string ToString()
        {
            return groups.Count.ToString();
        }

        public string GetName(int group, int student)
        {
            string r = "";
            foreach (Group g in groups)
            {
                if (g.code == group)
                {
                    foreach (Student s in g.Items)
                    {
                        if (s.no == student)
                            r = s.name + " - " + g.name;
                    }
                    break;
                }                
            }
            return r;
        }
    }

    public class Group
    {
        [XmlAttribute("code")]
        public int code;
        [XmlAttribute("name")]
        public string name;
        private ArrayList students;
        [XmlElement("student")]
        public Student[] Items
        {
            get
            {
                Student[] rs = new Student[students.Count];
                students.CopyTo(rs);
                return rs;
            }
            set
            {
                if (value == null) return;
                Student[] ss = (Student[])value;
                students.Clear();
                foreach (Student s in ss) students.Add(s);
            }
        }
        public Group() { students = new ArrayList(); }
        public Group(string name, int code)
        {
            this.code = code;
            this.name = name; students = new ArrayList();
        }
        public int AddItem(Student s)
        { return students.Add(s); }
        /// <summary>
        /// Tìm học sinh số thứ tự là no trong lớp
        /// </summary>
        /// <param name="no"></param>
        /// <returns>null nếu không tìm thấy</returns>
        public Student this[int no]
        {
            get
            {
                foreach (Student s in students)
                    if (s.no == no) return s;
                return null;
            }
            set
            {
                if (value == null) return;
                object ss = value;
                students.Clear();
                foreach (Student s in (Student[])ss) students.Add(s);
            }
        }
        public override string ToString()
        {
            return string.Format("Code: {0}, {1} S", code, students.Count);
        }
        /// <summary>
        /// Sinh mã lớp dựa theo tên lớp
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int GenerateCode(string name)
        {
            Regex regex = new Regex("^([0-9]+)([a-zA-Z]*)?([0-9]*)?");
            Match cmpnt = regex.Match(name.ToUpper());
            if (cmpnt.Success)
            {
                string code = ""; //mã lớp
                // Khối lớp
                if (cmpnt.Groups.Count >= 2)
                {
                    switch (cmpnt.Groups[1].Value)
                    {
                        case "12": code = "2"; break;
                        case "11": code = "1"; break;
                        case "10": code = "12"; break;
                    }
                }
                // Thứ tự lớp trong khối
                int order;
                if (cmpnt.Groups.Count == 4
                    && int.TryParse(cmpnt.Groups[3].Value, out order)
                    && order <= 16)
                {
                    order--; // Do tính chỉ số từ 0
                    string[] noRef = { "0", "3", "4", "5" };
                    for (int i = 0; i < 6; i++)
                    {
                        if ((order & (1 << i)) != 0)
                            code += noRef[i];
                    }
                }
                // Năm bắt đầu sử dụng
                switch (DateTime.Now.Year - int.Parse(UI.Properties.Resources.InstallYear))
                {
                    case 0: break;
                    case 1: code += "6"; break;
                    case 2: code += "7"; break;
                    case 3: code += "67"; break;

                }
                if (cmpnt.Groups.Count >= 3)
                {
                    switch (cmpnt.Groups[2].Value)
                    {
                        case "A": break;
                        case "B": code += "9"; break;
                        case "C": code += "8"; break;
                        case "D": code += "89"; break;
                    }
                }
                if (code == "") return -1;
                return int.Parse(code);
            }
            return -1;
        }
    }

    public class Student
    {
        [XmlAttribute("no")]
        public int no;
        [XmlAttribute("name")]
        public string name;
        public Student() { }
        public Student(int no, string name)
        {
            this.name = name;
            this.no = no;
        }
        public override string ToString()
        {
            object[] objs = new object[] { no, name };
            return string.Format("{0,-3},{1}", objs);
        }
    }
    [XmlRoot("discovers")]
    public class Discovers
    {
        private ArrayList discovers;
        public Discovers() { discovers = new ArrayList(); }
        [XmlElement("discover")]
        public Discover[] Items
        {
            get
            {
                Discover[] gd = new Discover[discovers.Count];
                discovers.CopyTo(gd);
                return gd;
            }
            set
            {
                if (value == null) return;
                Discover[] sd = (Discover[])value;
                discovers.Clear();
                foreach (Discover d in sd) discovers.Add(d);
            }
        }
        public int AddItem(Discover d)
        {
            return discovers.Add(d);
        }
        public Discover this[int n]
        {
            get { return (Discover)this.discovers[n]; }
            set { discovers[n] = value; }
        }
        
        public enum UserOrder { GroupStudent, Mark }
        public void Sort(UserOrder order)
        {
            IComparer comparer = null;
            switch (order)
            {
                case UserOrder.GroupStudent:
                    comparer = new IComparerDiscoverByGroup();                    
                    break;
                case UserOrder.Mark:
                    comparer = new IComparerDiscoverByMark();
                    break;
            }
            if (comparer != null)
            {
                discovers.Sort(comparer);
            }
        }
        public override string ToString()
        {
            return discovers.Count.ToString();
        }
    }
    /// <summary>
    /// Chứa thông tin nhận được từ quá trình Interpret
    /// </summary>
    public class Discover
    {
        [XmlAttribute("student")]
        public int student;
        [XmlAttribute("group")]
        public int group;
        [XmlAttribute("problem")]
        public int problem;
        [XmlAttribute("mark")]
        public float mark;
        [XmlAttribute("xmark")]        
        public float xmark;
        [XmlAttribute("portion")]
        public int portion;
        [XmlAttribute("date")]
        public DateTime date;
		[XmlAttribute("file")]
		public string file;
        public Spot root;
        /// <summary>
        /// Chuỗi chứa kết quả nhận dạng phần bài làm.
        /// Khởi tạo chuỗi gồm các ký tự trắng, số phần tử tối đa lấy từ Application Setting
        /// </summary>
        [XmlText]
        public string answer;       
        private int[] _raw;   
        /// <summary>
        /// Indexer truy cập đến từng câu hỏi
        /// Chú ý đánh số từ 1
        /// </summary>
        /// <param name="no">1-based</param>
        /// <returns></returns>
        public int this[int no]
        {
            get { return _raw[no]; }
            set
            {
                _raw[no] = value;
            }            
        }
        /// <summary>
        /// Chuyển đổi một phần gồm n phần tử đầu tiên trong raw
        /// mảng giá trị sang xâu chứa trong answer;
        /// </summary>
        public string Convert(int n)
        {
            StringBuilder s = new StringBuilder();
            for (int i = 1; i <= n; i++)
            {
                if (_raw[i] == -1) s.Append(UI.Properties.Settings.Default.BlankChar);
                else s.Append(Interpret.KeySymbol[_raw[i]]);
            }
            return (answer = s.ToString());
        }
        /// <summary>
        /// Chuyển sang chuỗi với toàn bộ chiều dài.
        /// </summary>
        public string Convert()
        {
            return Convert(_raw.Length);
        }
        public Discover() 
        {            
            _raw = new int[UI.Properties.Settings.Default.MaximumQuestion];
            for (int i = 0; i < _raw.Length; i++) _raw[i] = -1;
        }
        public Discover(int student, int group, int problem, float mark, float xmark , int portion,string file)
        {
            _raw = new int[UI.Properties.Settings.Default.MaximumQuestion];
            for (int i = 0; i < _raw.Length; i++) _raw[i] = -1;
            this.student = student;
            this.group = group;
            this.problem = problem;
            this.mark = mark;
			this.file = file;
            this.xmark = xmark;
            this.portion = portion;
        }
        public override string ToString()
        {
            return string.Format(
                "TT Học sinh: {0} / Mã lớp: {1} / Mã đề: {2} / Điểm: {3} / Trả lời: {4}",
                student, group, problem, mark, Convert());
        }
        
    }
    /// <summary>
    /// Comparer để sắp xếp theo lớp.
    /// Nguyên tắc: xếp từng lớp tăng dần, mỗi lớp theo số thứ tự mã học sinh tăng dần
    /// </summary>
    public class IComparerDiscoverByGroup : IComparer
    {
        int IComparer.Compare(Object obj1, Object obj2)
        {
            Discover d1 = obj1 as Discover;
            Discover d2 = obj2 as Discover;
            if (d1 == null || d2 == null) return 0;
            int g = d1.group - d2.group;
            if (g == 0)
            {
                return d1.student - d2.student;
            }
            else
            {
                return g;
            }
        }
    }
    /// <summary>
    /// Comparer so sánh 
    /// Nguyên tắc: điểm xếp giảm dần.
    /// </summary>
    public class IComparerDiscoverByMark : IComparer
    {
        int IComparer.Compare(Object obj1, Object obj2)
        {
            Discover d1 = obj1 as Discover;
            Discover d2 = obj2 as Discover;
            if (d1 == null || d2 == null) return 0;
            return Math.Sign(d2.mark - d1.mark);
        }
    }
    /// <summary>
    /// Chứa danh sách các KeySuite
    /// </summary>
    [XmlRoot("suitelist")]
    public class SuiteList
    {
        private ArrayList suites;
        private int activeSuiteIndex = -1;
        public KeySuite ActiveSuite
        {
            get { return this[activeSuiteIndex]; }
        }
        /// <summary>
        /// Bộ đáp án đang được chọn. 
        /// Bằng -1 nếu không có bộ đáp án nào được chọn
        /// </summary>
        public int ActiveSuiteIndex
        {
            get { return activeSuiteIndex; }
            set { activeSuiteIndex = value; }
        }
        public SuiteList() { suites = new ArrayList(); }
        [XmlElement("suite")]
        public KeySuite[] Items
        {
            get
            {
                KeySuite[] gs = new KeySuite[suites.Count];
                suites.CopyTo(gs);
                return gs;
            }
            set
            {
                if (value == null) return;
                KeySuite[] ss = (KeySuite[])value;
                suites.Clear();
                foreach (KeySuite s in ss) suites.Add(s);
            }
        }
        public int Count { get { return suites.Count; } }
        public int Add(KeySuite s)
        { return suites.Add(s); }
        public KeySuite this[int i]
        {
            get {
                if (suites.Count <= i) return null;
                return (KeySuite)suites[i]; 
            }
        }
        public bool Contains(string keyName)
        {
            foreach (KeySuite s in suites)
                if (s.name == keyName) return true;
            return false;
        }
        public override string ToString()
        {
            return suites.Count.ToString();
        }
    }
    [XmlRoot("keysuite")]
    /// <summary>
    /// Bộ đáp án
    /// </summary>
    public class KeySuite
    {
        private ArrayList keysuite;
        [XmlAttribute("name")]
        public string name;
        [XmlAttribute("questions")]
        public int questions;
        [XmlAttribute("portion")]
        public int portion;
        public KeySuite() { keysuite = new ArrayList(); }
        public KeySuite(string name, int questions, int portion)
        {
            this.name = name;
            this.questions = questions;
            this.portion = portion;
        }
        [XmlElement("key")]
        public Key[] Items
        {
            get
            {
                Key[] gk = new Key[keysuite.Count];
                keysuite.CopyTo(gk);
                return gk;
            }
            set
            {
                if (value == null) return;
                Key[] sk = (Key[])value;
                keysuite.Clear();
                foreach (Key k in sk) keysuite.Add(k);
            }
        }
        public int AddItem(Key k)
        {
            return keysuite.Add(k);
        }
        public Key this[int problem]
        {
            get
            {
                foreach (Key k in keysuite)
                    if (k.problem == problem) return k;
                return null;
            }
        }
        /// <summary>
        /// Kiểm tra suite có chứa một key nào đó không
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool Contains(Key k)
        {
            foreach (Key key in keysuite)
                if (key.Equals(k)) return true;
            return false;
        }
        /// <summary>
        /// Chuyển thành dạng text "user friendly"
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string problems = "";
            foreach (Key k in Items)
                problems += string.Format("{0}  ", k.problem);
            return string.Format(
                " {0} / Số câu hỏi: {1} / Số đề:{2} / Các mã: {3}",
                name, questions, keysuite.Count,problems);
        }
    }
    /// <summary>
    /// Đáp án cho một mã đề nào đó
    /// </summary>
    public class Key
    {
        [XmlAttribute("problem")]
        public int problem;
        [XmlAttribute("date")]
        public DateTime date;
        
        [XmlText]
        public string key;
        
        public Key() { }
        public Key(int problem, DateTime date, string key)
        {
            this.problem = problem;
            this.date = date;
            this.key = key;
        }
        public override string ToString()
        {
            return string.Format(
                "{0} / {1} / {2:g}",
                problem, key, date);
        }
        public override bool Equals(object obj)
        {
            Key k = obj as Key;
            if (k == null) return false;
            else return (k.date == this.date && k.key == this.key && k.problem == this.problem);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
