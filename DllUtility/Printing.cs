using System;
using System.Text;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;

namespace GiangManh.Utility
{
    public class PrintJob
    {
        PageSettings defaultPageSetting;
        /// <summary>
        /// Thiết lập cỡ giấy mặc định
        /// </summary>
        public PageSettings DefaultPageSetting
        {
            get
            {
                if (defaultPageSetting == null)
                {
                    defaultPageSetting = new PageSettings();
                    defaultPageSetting.PaperSize = new PaperSize("A4", 210 * 1000 / 254, 297 * 1000 / 254);
                    defaultPageSetting.Margins = new Margins();
                    defaultPageSetting.Margins.Bottom
                        = defaultPageSetting.Margins.Top
                        = defaultPageSetting.Margins.Left
                        = defaultPageSetting.Margins.Right = 20000 / 254;
                    return defaultPageSetting;
                }
                else
                {
                    return defaultPageSetting;
                }
            }
            set { defaultPageSetting = value; }
        }
        private static Font defaultFont = new Font(FontFamily.GenericMonospace, 8.5f);

        public static Font DefaultFont
        {
            get
            {
                return defaultFont;
            }
            set { defaultFont = value; }
        }

        PrintDocument doc;
        string stringToPrint;
        int pageNumber = 1;
        /// <summary>
        /// In văn bản thuần túy (cho phép nhiều trang)
        /// </summary>
        /// <param name="data">Văn bản</param>
        /// <param name="title">Tên tài liệu</param>
        public void Text(string data,string title)
        {
            doc = new PrintDocument();            
            doc.DefaultPageSettings = DefaultPageSetting;
            stringToPrint = data;
            doc.DocumentName = title;
            PrintDialog printDlg = new PrintDialog();            
            printDlg.AllowCurrentPage = false;
            printDlg.Document = doc;
            printDlg.UseEXDialog = true;
            if (printDlg.ShowDialog() == DialogResult.OK)
            {
                doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);
                Thread thread = new Thread(new ThreadStart(thread_Printing));
                thread.Name = "Print " + title;
                thread.IsBackground = true;
                thread.Priority = ThreadPriority.BelowNormal;                
                thread.Start();
            }
        }
        public PrintDocument TextPrintDoc(string data, string title)
        {
            doc = new PrintDocument();
            doc.DefaultPageSettings = DefaultPageSetting;
            stringToPrint = data;
            doc.DocumentName = title;
            doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);
            return doc;
        }
        public void TextPreview(string data, string title)
        {
            PrintPreviewDialog previewDlg = new PrintPreviewDialog();
            previewDlg.Document = TextPrintDoc(data, title);
            previewDlg.ShowDialog();
        }
        public void TextTable(string[,] table, string title)
        {
            PrintPreviewDialog previewDlg = new PrintPreviewDialog();
            PrintDocument tablePrintDoc = new PrintDocument();
            tablePrintDoc.DefaultPageSettings = DefaultPageSetting;
            tablePrintDoc.PrintPage += new PrintPageEventHandler(tablePrintDoc_PrintPage);
        }

        void tablePrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            throw new NotImplementedException();
        }
        private void thread_Printing()
        {
            doc.Print();
        }
        private void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            // This segment is from MSDN
            int charactersOnPage = 0;
            int linesPerPage = 0;

            // Sets the value of charactersOnPage to the number of characters 
            // of stringToPrint that will fit within the bounds of the page.
            e.Graphics.MeasureString(stringToPrint, PrintJob.defaultFont,
                e.MarginBounds.Size, StringFormat.GenericTypographic,
                out charactersOnPage, out linesPerPage);

            // Draws the string within the bounds of the page
            e.Graphics.DrawString(stringToPrint, PrintJob.defaultFont, Brushes.Black,
                e.MarginBounds,StringFormat.GenericTypographic);
            e.Graphics.DrawString("Trang " + pageNumber.ToString(),PrintJob.defaultFont,Brushes.Black,
                new PointF
                    (e.PageBounds.Width * 0.50f,
                    e.PageBounds.Height -  4 * PrintJob.defaultFont.Height));
            // Remove the portion of the string that has been printed.
            stringToPrint = stringToPrint.Substring(charactersOnPage);

            // Check to see if more pages are to be printed.
            e.HasMorePages = (stringToPrint.Length > 0);
            if (e.HasMorePages) pageNumber++;
            else pageNumber = 1;
        }        
    }
    public class PrintTable
    {
        PageSettings defaultPageSetting;
        /// <summary>
        /// Thiết lập cỡ giấy mặc định
        /// </summary>
        public PageSettings DefaultPageSetting
        {
            get
            {
                if (defaultPageSetting == null)
                {
                    defaultPageSetting = new PageSettings();
                    defaultPageSetting.PaperSize = new PaperSize("A4", 210 * 1000 / 254, 297 * 1000 / 254);
                    defaultPageSetting.Margins = new Margins();
                    defaultPageSetting.Margins.Bottom
                        = defaultPageSetting.Margins.Top
                        = defaultPageSetting.Margins.Left
                        = defaultPageSetting.Margins.Right = 20000 / 254;
                    return defaultPageSetting;
                }
                else
                {
                    return defaultPageSetting;
                }
            }
            set { defaultPageSetting = value; }
        }
        public Font font = new Font("Palatino Linotype", 9.0f);
        public PrintDocument doc;
        string LeftTitle, CenterTitle;
        string[,] content;
        public PrintTable() { init(); }
        public PrintTable(string leftTitle, string centerTitle, string[,] content)
        {
            this.LeftTitle = leftTitle;
            this.CenterTitle = centerTitle;
            this.content = content;
            init();
        }
        public void init()
        {
            doc = new PrintDocument();
            doc.BeginPrint += new PrintEventHandler(doc_BeginPrint);
            doc.EndPrint += new PrintEventHandler(doc_EndPrint);
            doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);
        }
        void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawString("OK", font, Brushes.Black, defaultPageSetting.PrintableArea);
        }

        void doc_EndPrint(object sender, PrintEventArgs e)
        {
            
        }
        int currentPage;
        int totalPages;
        Font titleFont;
        void doc_BeginPrint(object sender, PrintEventArgs e)
        {
            currentPage = 0;
            titleFont = new Font(font.FontFamily.Name, font.Size * 1.5f, FontStyle.Bold);
            int titleLines = GetNumLines(LeftTitle) + GetNumLines(CenterTitle);
            int totalLines = (int)(DefaultPageSetting.PrintableArea.Height / font.Height);
            int firstPageLines = totalLines - titleFont.Height * titleLines;
        }
        int GetNumLines(string src)
        {
            if (src == null) return 0;
            char[] c = new char[src.Length];
            src.CopyTo(0, c, 0, src.Length);
            int r = 1;
            for (int i = 0; i < c.Length; i++)
                if (c[i] == '\n') r++;
            return r;
        }
    }
}
