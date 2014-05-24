using System;
using System.Collections.Generic;
using System.Text;

namespace GiangManh.Utility
{
    public class MessageEventArgs : EventArgs
    {
        /// <summary>
        /// Thông điệp chuyển đi
        /// </summary>
        public string Message;
        /// <summary>
        /// Đối tượng chuyển đi
        /// </summary>
        public object Something;
        public MessageEventArgs()
        {
        }
        public MessageEventArgs(string message)
        {
            this.Message = message;
        }
        public MessageEventArgs(object something)
        {
            this.Something = something;
        }
    }
    public delegate void MessageEventHandler(object sender, MessageEventArgs e);
    /// <summary>
    /// Cho class khả năng truyền thông báo đến các thành phần khác qua event. Để nhận
    /// được thông điệp, lớp truyền đi phải thừa kế lớp này.
    /// </summary>
    public class MessageCapable
    {        
        protected MessageEventHandler MessageDelegates;
        /// <summary>
        /// Event truyền thông điệp.
        /// </summary>        
        public event MessageEventHandler Message
        {
            add { MessageDelegates += value; }
            remove { MessageDelegates -= value; }
        }
        /// <summary>
        /// Có handler nào để truyền thông điệp không
        /// Thường dùng để xem có nên tạo thông điệp để truyền hay không
        /// </summary>
        public bool CanMessage
        {
            get { return MessageDelegates != null; }
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
            if (MessageDelegates != null)
            {
                MessageDelegates(sender, new MessageEventArgs(message));
            }
        }
        public void Inform(object sender, string format, params object[] parameters)
        {
            MessageDelegates(sender, new MessageEventArgs(string.Format(format, parameters)));
        }
        /// <summary>
        /// Gửi đi một đối tượng, yêu cầu tương tự gửi thông điệp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="obj"></param>
        public void SendObject(object sender, object obj)
        {
            MessageDelegates(sender, new MessageEventArgs(obj));
        }
        public void SendObject(object sender, object obj, string message)
        {
            MessageEventArgs agr = new MessageEventArgs();
            agr.Something = obj;
            agr.Message = message;
            MessageDelegates(sender, agr);
        }

    }    
}
