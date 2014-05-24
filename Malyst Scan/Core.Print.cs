using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms;

namespace Core.Print
{
	public class Result
	{
		/// <summary>
		/// Bộ đếm dùng cho phương thức Print
		/// </summary>
		public static int startIndex = 0;
		public static bool PrintCross(Discovers d,PrintPageEventArgs e)
		{
			if (d == null || d.Items.Length == 0)
			{
				return false;
			}			
			StringBuilder s = new StringBuilder();
			s.AppendLine("Kết quả chấm điểm");
			s.AppendLine("Ngày: " + d.Items[0].date.ToString("dd/MM/yyyy hh:mm"));
			s.AppendLine();			
			s.AppendFormat("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{8}",
				"\t","STT", "Lớp", "Đề", "MHS","Họ và tên", "Điểm", "Tự luận", Environment.NewLine);

			int endIndex = startIndex + UI.Properties.Settings.Default.PrintRows;
			if (endIndex >= d.Items.Length)
			{
				e.HasMorePages = false;
				endIndex = d.Items.Length;
			}
			else
			{
				e.HasMorePages = true;
			}

			for (int i = startIndex; i < endIndex; i++)
			{
				Discover r = d[i];
                string name = Core.Ref.UniGroup.GetName(r.group, r.student);
				s.AppendFormat("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{8}", 
					"\t",i+1,r.group,r.problem , r.student, name, r.mark,r.xmark,Environment.NewLine);				
			}
			s.AppendLine();
			s.AppendLine(string.Format("{0:50}{1}", "Malyst Result, Page: ", 
				(startIndex / UI.Properties.Settings.Default.PrintRows + 1)));
			Graphics g = e.Graphics;
			Brush brush = Brushes.Black;
			Font font = UI.Properties.Settings.Default.PrintFont;
			g.DrawString(s.ToString(),font,brush,e.MarginBounds);

			Result.startIndex = endIndex;
			if (endIndex == d.Items.Length)
			{
				// Đặt lại giá trị cho lần in sau.
				startIndex = 0;
			}
			return true;
		}
		/// <summary>
		/// In kèm tên lấy từ bài quét.
		/// </summary>
		/// <param name="d"></param>
		/// <param name="e"></param>
		/// <returns></returns>
		public static bool PrintWithName(Discovers d, PrintPageEventArgs e)
		{
			if (d == null || d.Items.Length == 0)
			{
				return false;
			}
			StringBuilder s = new StringBuilder();
			s.AppendLine("Kết quả chấm điểm");
            s.AppendLine("Ngày: " + d.Items[0].date.ToString("dd/MM/yyyy hh:mm") + 
                " Trang: " + (startIndex / UI.Properties.Settings.Default.PrintRows + 1));
			s.AppendLine();
			s.AppendFormat("{1,-65}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{7}",
				"\t", "Họ và tên","Điểm","Tự luận", "Lớp", "Đề","MHS", Environment.NewLine);
            
			int endIndex = startIndex + UI.Properties.Settings.Default.PrintRowsWithName;
			if (endIndex >= d.Items.Length)
			{
				e.HasMorePages = false;
				endIndex = d.Items.Length;
			}
			else
			{
				e.HasMorePages = true;
			}
			Graphics g = e.Graphics;
			Brush brush = Brushes.Black;
			Font font = UI.Properties.Settings.Default.PrintFont;

			Rectangle sourceRect = new Rectangle(12, 12, 272,36);
            g.DrawString(s.ToString(), font, brush, new PointF(80, 100));
			for (int i = startIndex; i < endIndex; i++)
			{
                try
                {
                    Discover r = d[i];
                    if (r.file == null) continue;
                    Image img = Bitmap.FromFile(r.file);
                    Rectangle currentRectName = sourceRect;
                    currentRectName.Offset(r.root.X,r.root.Y);
                    g.DrawImage(img,
                        80, 190 + (i - startIndex) * 36, currentRectName,
                        GraphicsUnit.Pixel);
                    g.DrawString(string.Format("{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{6}",
                        "\t", r.mark,r.xmark, r.group, r.problem, r.student, Environment.NewLine),
                        font, brush, new Point(80 + 272, 200 + (i - startIndex) * 36));
                }
                catch (System.IO.FileNotFoundException ex)
                {
                    Core.Utility.Error("Lỗi khi tạo bản in. " + ex.Message);
                }
                catch (Exception)
                {
                }
			}			

			Result.startIndex = endIndex;
			if (endIndex == d.Items.Length)
			{
				// Đặt lại giá trị cho lần in sau.
				startIndex = 0;
			}
			return true;
		}
		/// <summary>
		/// Chuyển kết quả thành một chuỗi để lưu vào file RTF;
		/// </summary>
		/// <param name="d"></param>
		/// <returns></returns>
		public static bool ExportRtf(Discovers d,string rtfFileName)
		{
            if (d == null || d.Items.Length == 0)
            {
                return false;
            }
            StringBuilder s = new StringBuilder();
            s.AppendLine("Kết quả chấm điểm");
            s.AppendLine("Ngày: " + d.Items[0].date.ToString("dd/MM/yyyy hh:mm"));
            s.AppendLine();
            s.AppendFormat("{1}{0}{2}{0}{3}{0}{4}{0}{5,-55}{6}{0}{7}{8}",
                "\t", "STT", "Lớp", "Đề", "MHS", "Họ và tên", "Điểm","Tự luận", Environment.NewLine);

            for (int i = 0; i < d.Items.Length; i++)
            {
                Discover r = d[i];
                string name = Core.Ref.UniGroup.GetName(r.group, r.student);
                s.AppendFormat("{1}{0}{2}{0}{3}{0}{4}{0}{5,-55}{6}{0}{7}{8}",
                    "\t", i + 1, r.group, r.problem, r.student, name, r.mark,r.xmark, Environment.NewLine);
            }
			RichTextBox rtf = new RichTextBox();
			rtf.AppendText(s.ToString());
			rtf.SaveFile(rtfFileName, RichTextBoxStreamType.RichText);
            System.Diagnostics.Process.Start(rtfFileName);
            rtf = null;
			return true;
			
		}		
	}
}
