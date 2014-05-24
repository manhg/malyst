/* Chứa các lớp dùng cho việc sử dụng mẫu thế hệ 2
 * 
 * 
 *
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace Core
{    
        /// <summary>
        /// Phân tích nhận dạng thế hệ 2
        /// </summary>
        public class InterpretG2 : CoreMsgCapable
    {
        [ThreadStatic]
        public static string KeySymbol = UI.Properties.Settings.Default.KeySymbol;
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
        public InterpretG2() { }
        public InterpretG2(KeySuite keys, Acquired acquired, Anchor anchor, CoreMsgEventHandler handler)
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
                    if (acq.IsTicked(place.WhereG2(PlaceType.Solution, no, detail)))
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
                if (acq.IsTicked(place.WhereG2(PlaceType.Student, no, 0)))
                {
                    result.student = (no % 10) * 10;
                    break;
                }
            // Cột thứ hai
            for (int no = 1; no <= 10; no++)
                if (acq.IsTicked(place.WhereG2(PlaceType.Student, no, 1)))
                {
                    result.student += (no % 10);
                    break;
                }
            Inform(this, string.Format("\tMã học sinh: {0}", result.student));
        }
        /// <summary>
        /// Nhận dạng mã đề
        /// </summary>
        public void FindProblem()
        {
            result.problem = 0;
            for (int no = 1; no <= 10; no++)
                if (acq.IsTicked(place.WhereG2(PlaceType.Problem, no, 0)))
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
                if (acq.IsTicked(place.WhereG2(PlaceType.Class, no, 0)))
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
                Inform(this, "Tỉ lệ điểm: " + result.portion + "% . Điểm tự luận: " + result.xmark);
            }
        }
    }
        /// <summary>
        /// Phần trong Place sử dụng mẫu thế hệ 2 (G2)
        /// </summary>
        public partial class Place
        {
            /// <summary>
            /// Dùng cho mẫu thế hệ 2 (G2)
            /// Where: tìm vị trí (tâm) của một thành phần nào đó
            /// thuộc PlaceType
            /// </summary>
            /// <param name="place">Loại place <see cref="PlaceType"/></param>
            /// <param name="no">Thứ tự (dòng thứ bao nhiêu, thành phần thứ mấy).
            /// Chú ý Index tính từ 1</param>
            /// <param name="detail">Chi tiết (ô A,B,C hay D; ...). Index tính từ 0</param>
            /// <returns></returns>
            public Spot WhereG2(PlaceType place, int no, int detail)
            {                
                switch (place)
                {
                    case PlaceType.Solution:
                        if ((1 <= no) && (no <= 27))
                            return R2A(
                                (detail + 0) * d,
                                (no - 1 + 0) * d);

                        else if ((28 <= no) && (no <= 53))
                            return R2A(
                                (detail + 6) * d,
                                (no - 28 + 1) * d);
                        else if ((54 <= no) && (no <= 80))
                            return R2A(
                                (detail + 12) * d,
                                (no - 54 + 0) * d);
                        else
                        {
                            Inform(this, "Số thứ tự câu hỏi không hợp lệ. {0} ", no);
                            return new Spot(0, 0);
                        }
                    case PlaceType.Student:
                        return R2A(
                            (detail + 18) * d,
                            no == 0 ? 10 * d : (no) * d); // 9  -1
                    case PlaceType.Problem:
                        if (no <= 5) return R2A(
                            18 * d,
                            (no + 11) * d); // 10
                        else return R2A(
                            (18 + 1) * d,
                            ((no - 5) + 11) * d); // 10
                    case PlaceType.Class:
                        if (no <= 5) return R2A(
                            18 * d,
                            (no + 17) * d); // 16
                        else return R2A((
                            18 + 1) * d,
                            ((no - 5) + 17) * d); // 16
                    default:
                        {
                            Inform(this, "Vị trí không mong đợi.");
                            return new Spot(0, 0);
                        }
                }
            }
        }
}

