using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Drawing;

namespace Core
{
    internal class Utility:CoreMsgCapable
    {
        public static void Msg(string text)
        {
            MessageBox.Show(text, UI.Properties.Settings.Default.WindowCaption,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void Error(string text)
        {
            MessageBox.Show(text, UI.Properties.Settings.Default.WindowCaption,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult Confirm(string text)
        {
            return MessageBox.Show(text, UI.Properties.Settings.Default.WindowCaption,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public static string FilterDocumentFile = "Dữ liệu (lớp, phiên quét, danh sách,... của Malyst |*.Malyst|Tất cả|*.*";
        //static DateTime start;
        /// <summary>
        /// Bắt đầu đếm thời gian thực hiện một đoạn mã
        /// </summary>
        //public static void Timing() { Inform(this, "#Timing..."); start = DateTime.Now; }
        /// <summary>
        /// Hiển thị thời gian thực hiện một đoạn mã.
        /// </summary>
        //public static void Timed() { Inform(this, "#Elapsed time (ms):{0:D15}", DateTime.Now - start); }
        /// <summary>
        /// Chuyển xâu ký tự thành tên theo quy cách viết hoa ở đầu từ
        /// </summary>
        /// <param name="name">i cần chuyển thành tên</param>
        /// <returns></returns>
        public static string ValidName(string name)
        {
            string r = "";
            bool spacePrev = false;
            name = name.Trim();
            if (name != "")
            {
                r += name[0].ToString().ToUpper();
                for (int i = 1; i < name.Length; i++)
                    if (name[i] == ' ') spacePrev = true;
                    else
                    {
                        if (spacePrev)
                        {
                            r += " " + name[i].ToString().ToUpper();
                            spacePrev = false;
                        }
                        else r += name[i];
                    }
            }
            return r;
        }
        public static string Tester(string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            System.Security.Cryptography.MD5 md5Hasher = System.Security.Cryptography.MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        public static bool Test(string input, string hash)
        {
            // Hash the input.
            string hashOfInput = Tester(input);

            // Create a StringComparer an comare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Đã mất bao nhiêu thời gian cho trò vui này nhỉ hình như là 5 tiếng đồng hồ thì phải
        /// Rốt cuộc cái tên (Default) của một value chỉ là một xâu rỗng. Một bài học không nói lên lời
        /// 
        /// Nhưng vẫn phải nói lại, đây là hàm đăng ký một loại tệp tin mới và gán cho nó một biểu tượng.
        /// Cần phải khởi động lại để hệ thống nhận diện loại tệp tin mới. Có một cách là dùng hàm 
        /// SHChangeNotify() nhưng hiện tại vẫn chưa biết nó nằm trong library nào cả!!!
        /// </summary>
        /// <param name="extension">Đuôi của tệp tin, kể cả ký tự</param>
        /// <param name="description">Mô tả kiểu tệp</param>
        /// <param name="iconPath">Đường dẫn đến tệp biểu tượng, có thể là .DLL, .EXE hoặc .ICO
        /// Có thể sử dụng thêm những đường dẫn tượng trưng, ví dụ %ProgramFiles% %SystemRoot%</param>
        public static void AssociateFileType(string extension, string description, string iconPath)
        {
            RegistryKey fileExt = Registry.ClassesRoot.CreateSubKey(extension);
            fileExt.SetValue("", UI.Properties.Settings.Default.WindowCaption + extension);
            RegistryKey extHandler = Registry.ClassesRoot.CreateSubKey(Application.ProductName + extension);
            RegistryKey extIcon = extHandler.CreateSubKey("DefaultIcon");
            extIcon.SetValue("", iconPath);
            extHandler.SetValue("", description);
            extIcon.Close();
            extHandler.Close();
            fileExt.Close();
        }
        public static Bitmap Resample(float destDpi, Image img)
        {
            // scale factors
            float sx = (float)destDpi / img.VerticalResolution;
            float sy = (float)destDpi / img.HorizontalResolution;
            int newWidth = (int)Math.Ceiling(img.Width * sx);
            int newHeight = (int)Math.Ceiling(img.Height * sy);
            Bitmap bmp = new Bitmap(newWidth, newHeight,System.Drawing.Imaging.PixelFormat.Format24bppRgb);            
            bmp.SetResolution(destDpi, destDpi);
            Graphics g = Graphics.FromImage(bmp);
            g.DrawImage(img, 0, 0, newWidth, newHeight);
            g.Dispose();
            return bmp;
        }
        /// <summary>
        /// Lọc bằng clarify ra chỉ các ký tự ABCD
        /// Cứ nhóm 5, thêm một dấu cách 
        /// </summary>
        /// <param name="answer"></param>
        /// <returns></returns>
        public static string ClearLook(string key)
        {
            string seprator = " ";
            StringBuilder s = new StringBuilder();
            string _key = Clarify(key);
            for (int i = 0; i < _key.Length; i++)
            {
                s.Append(_key[i]);
                if ((i + 1) % 5 == 0) s.Append(seprator);
            }
            return s.ToString();
        }
        /// <summary>
        /// STT đi kèm với đáp án / câu trả lời; (dạng tường minh)
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string ExplicitLook(string key)
        {
            StringBuilder s = new StringBuilder();
            string _key = Clarify(key);
            for (int i = 0; i < _key.Length; i++)
            {
                s.AppendFormat("{0}.{1} ", i+1, _key[i]);                
            }
            return s.ToString();
        }
        /// <summary>
        /// Trong chuỗi bài làm / đáp án, bỏ các ký tự thừa (khác A,B,C,D và ký tự đánh dấu 
        /// không phương án nào được chọn
        /// </summary>
        /// <param name="answer"></param>
        /// <returns></returns>
        public static string Clarify(string answer)
        {
            StringBuilder s = new StringBuilder();
            string t = answer.ToUpper();
            for (int i = 0; i < t.Length; i++)
                if ((t[i] >= 'A' && t[i] <= 'D') || t[i] == UI.Properties.Settings.Default.BlankChar)
                    s.Append(t[i]);
            return s.ToString();
        }
        public enum MyXmlFileType { KeySuite, Groups, Discovers, SuiteList }
        /// <summary>
        /// Xác định kiểu của obj, sử dụng để Serialize hoặc Deserialize XML
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Type GetXmlFileType(MyXmlFileType type)
        {
            Type fileType = typeof(object);
            switch (type)
            {
                case MyXmlFileType.Discovers: fileType = typeof(Discovers); break;
                case MyXmlFileType.Groups: fileType = typeof(Groups); break;
                case MyXmlFileType.KeySuite: fileType = typeof(KeySuite); break;
                case MyXmlFileType.SuiteList: fileType = typeof(SuiteList); break;
            }
            return fileType;
        }
        /// <summary>
        /// Serialize biến keysuite rồi ghi nội dung ra tệp filename
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="keysuite"></param>
        public static void XmlSerialize(string filename,object obj,MyXmlFileType type,ToolStripProgressBar progress,ToolStripLabel label)
        {
            if (progress != null) progress.Value = 0;
            if (label != null) label.Text = "Đang tạo bản lưu tệp, vui lòng chờ...";
            XmlSerializer xmlserialer = new XmlSerializer(GetXmlFileType(type));
            try
            {
                TextWriter w = new StreamWriter(filename);
                if (progress != null) progress.Value = 50;
                xmlserialer.Serialize(w, obj);
                w.Close();
                if (progress != null) progress.Value = 100;
                if (label != null) label.Text = "Đã lưu tệp xong tệp xong. ";
            }
            catch (IOException ex) { Error(ex.Message); }
        }
        /// <summary>
        /// Lấy nội dung XML có trong tệp filename rồi gán vào biến obj
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="keysuite">Biến không khởi tạo. Cho null nếu lỗi.</param>
        public static void XmlDeserialize(string filename, out object obj, MyXmlFileType type, ToolStripProgressBar progress, ToolStripLabel label)
        {            
            XmlSerializer xmlserialer = new XmlSerializer(GetXmlFileType(type));
            if (progress != null) progress.Value = 0;
            if (label != null) label.Text = "Đang đọc tệp, vui lòng chờ ...";
            try
            {
                TextReader r = new StreamReader(filename);
                if (progress != null) progress.Value = 50;
                obj = xmlserialer.Deserialize(r);
                r.Close();
                if (progress != null) progress.Value = 100;
                if (label != null) label.Text = "Đã đọc tệp xong. ";
                return;
            }
            catch (IOException ex) { Error(ex.Message); obj = null; }            
        }        
        /// <summary>
        /// Cấu trúc dữ liệu lưu yêu cầu đối với việc trộn mã đề
        /// </summary>
        //public struct RandomRequire
        //{
        //    /// <summary>
        //    /// Số lượng đề cần trộn
        //    /// </summary>
        //    int quantity;
        //    /// <summary>
        //    /// Mã đề tương ứng khi trộn ra.
        //    /// </summary>
        //    int[] problem;            
        //}
        /// <summary>
        /// Phương thức:
        /// Trộn đề dựa trên một file văn bản đơn giản / Tệp Word/Excel
        /// Làm thế nào để giữ được hình ảnh cùng với đề là tốt nhất
        /// Phát triển sau.
        /// </summary>
        /// <param name="docFileName">Là một tệp mã Unicode hoặc UTF-8
        /// Các quy ước trong đề:
        /// Chỉ sử dụng các ký hiệu '#' và '#?' theo quy ước
        /// Phần tiêu đề nội dung tùy ý 
        /// Phần câu hỏi:
        /// Mỗi câu hỏi theo khuôn:
        /// ##XX 
        /// {
        ///     Nội dung câu hỏi
        ///     #@[N |D | C] 
        ///     #A Phương án A
        ///     #B Phương án B
        ///     #C Phương án C
        ///     #D Phương án D
        ///     #!K
        /// }
        /// trong đó:
        ///     XX là số thứ tự của câu hỏi.
        ///     Dấu '{' và '}' dùng để mở hoặc đóng một câu hỏi.
        ///     #@ là phần xác định dạng trình bày của đáp án. Có ba kiểu
        ///         Kiểu 'N': ngang. Bố trí đều 4 đáp án theo chiều ngang.
        ///         VD: "A. Cùng chiều      B. Ngược chiều      C. Không xác định   D. Phụ thuộc môi trường"
        ///         Kiểu 'D': dọc. Bố trí mỗi phương án một dòng.
        ///            "A. Cùng chiều      
        ///             B. Ngược chiều      
        ///             C. Không xác định   
        ///             D. Phụ thuộc môi trường"
        ///         Kiểu 'C': chia đôi. Có hai cột, mỗi cột hai phương án
        ///             "A. Cùng chiều      B. Ngược chiều      
        ///             C. Không xác định   D. Phụ thuộc môi trường"
        ///         #! có thể có hoặc không, là đáp án của câu hỏi.
        ///     Phải có dấu dóng và dấu mở đúng.
        ///     <example>
        ///     Ví dụ:
        ///         ##3
        ///         {
        ///             Có những vật bằng sắt được mạ bằng những kim loại khác nhau dưới đây.
        ///             Nếu các  vật này đều bị xây sát sâu đến lớp sắt thì vật nào bị gỉ 
        ///             chậm nhất?
        ///             #@ C
        ///             #A Sắt tráng kẽm
        ///             #B Sắt tráng thiếc
        ///             #C Sắt tráng niken
        ///             #D Sắt tráng đồng       
        ///         }
        ///         Kết quả sẽ là:
        ///         " Câu 3: 
        ///             Có những vật bằng sắt được mạ bằng những kim loại khác nhau dưới đây.
        ///             Nếu các  vật này đều bị xây sát sâu đến lớp sắt thì vật nào bị gỉ 
        ///             chậm nhất?
        ///             A. Sắt tráng kẽm             C. Sắt tráng niken
        ///             B. Sắt tráng thiếc           D. Sắt tráng đồng "
        ///     </example>
        /// </param>
        /// <param name="resultFileName">File kết quả, nên để ở dạng Word để dễ sửa chữa và thân
        /// thiện hơn với mọi người</param>
        public static void RandomizeQuestion(string txtFileName, string resultFileName)
        {

        }
        /// <summary>
        /// Ký tự phân cách thư mục
        /// </summary>
        public const char FolderSeparator = '\\';

        /// <summary>
        /// Bỏ đường dẫn, chỉ lấy tên tệp và extension
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string GetSafeFileName(string filename)
        {
            
            int pos = filename.LastIndexOf(FolderSeparator);
            if (pos != -1)
            {
                return filename.Substring(pos+1);
            }
            else
            {
                return filename;
            }
        }
    }    
}
