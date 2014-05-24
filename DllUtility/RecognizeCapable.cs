using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace GiangManh.Utility
{
    public class CallRecognizeEventArgs : EventArgs
    {
        private PointF position;
        /// <summary>
        /// Vị trí cần nhận dạng (mm)
        /// </summary>
        public PointF Position
        {
            get { return position; }
            set { position = value; }
        }
        private int isFill = -1;
        /// <summary>
        /// Kết quả nhận dạng:
        /// 1 : bị tô,
        /// 0 : không bị tô,
        /// -1 : không xác định.
        /// </summary>
        public int IsFill
        {
            get { return isFill; }
            set { isFill = value; }
        }
        public CallRecognizeEventArgs(PointF position) { this.position = position; }
        public CallRecognizeEventArgs(float x, float y) { this.position = new PointF(x, y); }
    }
    public delegate void RecognizeEventHandler(object sender, CallRecognizeEventArgs e);
    public class CallRecognizeCapable
    {
        protected RecognizeEventHandler recognizeDelegate;
        public event RecognizeEventHandler Recognizer
        {
            add { recognizeDelegate += value; }
            remove { recognizeDelegate -= value; }
        }
        /// <summary>
        /// Có handler nào để truyền thông điệp không
        /// Thường dùng để xem có nên tạo thông điệp để truyền hay không
        /// </summary>
        public bool CanRecognize
        {
            get { return recognizeDelegate != null; }
        }
        public void ClearHandler() { recognizeDelegate = null; }
        /// <summary>
        /// Thực hiện nhận dạng
        /// </summary>
        /// <param name="position">Vị trí ảnh điểm (mm)</param>
        /// <returns></returns>
        public int Recognize(PointF position)
        {
            CallRecognizeEventArgs e = new CallRecognizeEventArgs(position);
            recognizeDelegate(this, e);
            return e.IsFill;
        }
    }
    
}
