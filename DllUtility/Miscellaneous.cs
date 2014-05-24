using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using System.Data;

namespace GiangManh.Utility
{
    public class Miscellaneous
    {
        public static bool Confirm(string message)
        {
            return MessageBox.Show
                (message, Application.ProductName, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes;
        }
        public static void Message(string message)
        {
            MessageBox.Show(message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult ConfirmWithCancel(string message)
        {
            return MessageBox.Show
                (message, Application.ProductName, MessageBoxButtons.YesNoCancel);                
        }
        /// <summary>
        /// Lấy ngày chuẩn. Dạng: dd-MM-yyyy HH:mm
        /// 
        /// </summary>
        /// <returns>Chiều dài: 16, kiểu string</returns>
        public static string GetIsoDate()
        {
            return DateTime.Now.ToString("dd-MM-yyyy HH:mm");
        }
        /// <summary>
        /// Lấy chiều dài một véctơ
        /// 
        /// </summary>
        /// <param name="peak"></param>
        /// <returns></returns>
        public static double VectorLength(PointF peak)
        {
            return Math.Sqrt(peak.X * peak.X + peak.Y * peak.Y);
        }
        public static double VectorLength(PointF O, PointF A)
        { return VectorLength(new PointF(A.X - O.X, A.Y - O.Y)); }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="digit">Mảng các chữ số 0 - 9. Hàng đơn vị là số cuối cùng</param>
        /// <returns>Số thập phân thành lập từ digit</returns>
        public static int GetNumber(int[] digit)
        {
            int r = 0;
            for (int i = digit.Length - 1; i >= 0; i--)
            {
                r = 10 * r + digit[i];
            }
            return r;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="digit">Mảng các chữ số 0 - 1. Hàng đơn vị là số cuối cùng</param>
        /// <returns>Số thập phân thành lập từ dãy nhị phân</returns>
        public static int GetNumBinary(int[] digit)
        {
            int r = 0;
            for (int i = digit.Length - 1; i >= 0; i--)
            {
                r = 2 * r + digit[i];
            }
            return r;
        }
        public class MmConverter
        {
            private float scale_x = 1.0f;
            private float scale_y = 1.0f;
            public float ScaleX
            {
                get { return scale_x; }
                set { scale_x = value; }
            }
            public float ScaleY
            {
                get { return scale_y; }
                set { scale_y = value; }
            }
            private float dpi4mmToPixel = 0;

            public float Dpi4mmToPixel
            {
                get { return dpi4mmToPixel; }
                set { dpi4mmToPixel = value; }
            }
            public int MmToPixelByX(float mm)
            { return (int)Math.Round(scale_x * mm * dpi4mmToPixel / 25.4f); }
            public int MmToPixelByY(float mm)
            { return (int)Math.Round(scale_y * mm * dpi4mmToPixel / 25.4f); }
            /// <summary>
            /// Chú ý: Thiết lập Dpi và scale trước khi gọi
            /// </summary>
            /// <param name="mm"></param>
            /// <returns></returns>           
            public Point MmToPixel(PointF mm)
            {
                return new Point(MmToPixelByX(mm.X), MmToPixelByY(mm.Y));
            }            
            /// <summary>
            /// Chú ý: Thiết lập Dpi trước khi gọi
            /// </summary>
            /// <param name="mm"></param>
            /// <returns></returns>
            public Rectangle MmToPixel(RectangleF mm)
            {
                return new Rectangle(
                    MmToPixelByX(mm.X),
                    MmToPixelByY(mm.Y),
                    MmToPixelByX(mm.Width),
                    MmToPixelByY(mm.Height));
            }
        }
        public static void ErrorMessage(string message)
        {
            MessageBox.Show(message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
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
        /// <summary>
        /// [column, row]
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public static string[,] GetGridContent(DataGridView g)
        {            
            int row_num = g.RowCount + 1; // thêm hàng header
            if (g.AllowUserToAddRows) row_num--;
            string[,] r = new string[g.ColumnCount, row_num];
            for (int i = 0; i < g.ColumnCount; i++)
            {                
                r[i, 0] = g.Columns[i].HeaderText;
            }

            for (int y = 0; y < row_num - 1; y++)
            {
                for (int x = 0; x < g.ColumnCount; x++)
                {
                    try
                    {
                        r[x, y + 1] = g[x, y].Value.ToString();
                    }
                    catch (NullReferenceException) { r[x, y + 1] = string.Empty; }
                }
            }
            return r;
        }
        public static int[] GetGridWidth(DataGridView g)
        {
            int[] cols = new int[g.ColumnCount];
            for (int i = 0; i < cols.Length; i++)
            {
                cols[i] = g.Columns[i].HeaderCell.Size.Width;
            }
            return cols;
        }
        public static string GetTabText(string[,] data)
        {
            StringBuilder r = new StringBuilder();
            int cols = data.GetLength(0);
            int rows = data.GetLength(1);
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols - 1; x++)
                {
                    r.Append(data[x, y] + '\t');
                }
                r.AppendLine(data[cols - 1, y]);
            }
            return r.ToString();
        }
        public static string GetTabPad(string[,] data,int[] cols_width,int scale)
        {
            StringBuilder r = new StringBuilder();
            int cols = data.GetLength(0);
            int rows = data.GetLength(1);
            for (int y = 0; y < rows; y++)
            {
                r.Append(y.ToString().PadRight(7));
                for (int x = 0; x < cols - 1; x++)
                {
                    r.Append(data[x, y].PadRight(cols_width[x] / scale));
                }
                r.AppendLine(data[cols - 1, y]);
            }
            return r.ToString();
        }
    }
    public class OfficeWordXml
    {
        static string header =
@"<?xml version='1.0' encoding='UTF-8' standalone='yes'?><?mso-application progid='Word.Document'?>
<w:wordDocument xmlns:aml='http://schemas.microsoft.com/aml/2001/core' xmlns:dt='uuid:C2F41010-65B3-11d1-A29F-00AA00C14882' xmlns:ve='http://schemas.openxmlformats.org/markup-compatibility/2006' xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:v='urn:schemas-microsoft-com:vml' xmlns:w10='urn:schemas-microsoft-com:office:word' xmlns:w='http://schemas.microsoft.com/office/word/2003/wordml' xmlns:wx='http://schemas.microsoft.com/office/word/2003/auxHint' xmlns:wsp='http://schemas.microsoft.com/office/word/2003/wordml/sp2' xmlns:sl='http://schemas.microsoft.com/schemaLibrary/2003/core' w:macrosPresent='no' w:embeddedObjPresent='no' w:ocxPresent='no' xml:space='preserve'><w:ignoreSubtree w:val='http://schemas.microsoft.com/office/word/2003/wordml/sp2'/><o:DocumentProperties><o:Author>Giang Manh</o:Author><o:LastAuthor>Giang Manh</o:LastAuthor><o:Revision>5</o:Revision><o:TotalTime>4</o:TotalTime><o:Created>2008-08-06T01:10:00Z</o:Created><o:LastSaved>2008-08-06T01:23:00Z</o:LastSaved><o:Pages>1</o:Pages><o:Words>6</o:Words><o:Characters>35</o:Characters><o:Company>DHBK HN</o:Company><o:Lines>1</o:Lines><o:Paragraphs>1</o:Paragraphs><o:CharactersWithSpaces>40</o:CharactersWithSpaces><o:Version>12</o:Version></o:DocumentProperties><w:fonts><w:defaultFonts w:ascii='Times New Roman' w:fareast='Times New Roman' w:h-ansi='Times New Roman' w:cs='Times New Roman'/><w:font w:name='Times New Roman'><w:panose-1 w:val='02020603050405020304'/><w:charset w:val='00'/><w:family w:val='Roman'/><w:pitch w:val='variable'/><w:sig w:usb-0='20002A87' w:usb-1='80000000' w:usb-2='00000008' w:usb-3='00000000' w:csb-0='000001FF' w:csb-1='00000000'/></w:font><w:font w:name='Arial'><w:panose-1 w:val='020B0604020202020204'/><w:charset w:val='00'/><w:family w:val='Swiss'/><w:pitch w:val='variable'/><w:sig w:usb-0='20002A87' w:usb-1='80000000' w:usb-2='00000008' w:usb-3='00000000' w:csb-0='000001FF' w:csb-1='00000000'/></w:font><w:font w:name='Cambria Math'><w:panose-1 w:val='02040503050406030204'/><w:charset w:val='01'/><w:family w:val='Roman'/><w:notTrueType/><w:pitch w:val='variable'/><w:sig w:usb-0='00000000' w:usb-1='00000000' w:usb-2='00000000' w:usb-3='00000000' w:csb-0='00000000' w:csb-1='00000000'/></w:font></w:fonts><w:styles><w:versionOfBuiltInStylenames w:val='7'/><w:latentStyles w:defLockedState='off' w:latentStyleCount='267'><w:lsdException w:name='Normal'/><w:lsdException w:name='heading 1'/><w:lsdException w:name='heading 2'/><w:lsdException w:name='heading 3'/><w:lsdException w:name='heading 4'/><w:lsdException w:name='heading 5'/><w:lsdException w:name='heading 6'/><w:lsdException w:name='heading 7'/><w:lsdException w:name='heading 8'/><w:lsdException w:name='heading 9'/><w:lsdException w:name='caption'/><w:lsdException w:name='Title'/><w:lsdException w:name='Subtitle'/><w:lsdException w:name='Strong'/><w:lsdException w:name='Emphasis'/><w:lsdException w:name='No Spacing'/><w:lsdException w:name='List Paragraph'/><w:lsdException w:name='Quote'/><w:lsdException w:name='Intense Quote'/><w:lsdException w:name='Subtle Emphasis'/><w:lsdException w:name='Intense Emphasis'/><w:lsdException w:name='Subtle Reference'/><w:lsdException w:name='Intense Reference'/><w:lsdException w:name='Book Title'/><w:lsdException w:name='TOC Heading'/></w:latentStyles><w:style w:type='paragraph' w:default='on' w:styleId='Normal'><w:name w:val='Normal'/><w:rsid w:val='0058350F'/><w:pPr><w:ind w:first-line='360'/></w:pPr><w:rPr><wx:font wx:val='Times New Roman'/><w:sz w:val='22'/><w:sz-cs w:val='22'/><w:lang w:val='EN-US' w:fareast='EN-US' w:bidi='EN-US'/></w:rPr></w:style><w:style w:type='paragraph' w:styleId='Heading1'><w:name w:val='heading 1'/><wx:uiName wx:val='Heading 1'/><w:basedOn w:val='Normal'/><w:next w:val='Normal'/><w:link w:val='Heading1Char'/><w:rsid w:val='0058350F'/><w:pPr><w:pBdr><w:bottom w:val='single' w:sz='12' wx:bdrwidth='30' w:space='1' w:color='365F91'/></w:pBdr><w:spacing w:before='600' w:after='80'/><w:ind w:first-line='0'/><w:outlineLvl w:val='0'/></w:pPr><w:rPr><w:rFonts w:ascii='Arial' w:h-ansi='Arial'/><wx:font wx:val='Arial'/><w:b/><w:b-cs/><w:color w:val='365F91'/><w:sz w:val='24'/><w:sz-cs w:val='24'/></w:rPr></w:style><w:style w:type='paragraph' w:styleId='Heading2'><w:name w:val='heading 2'/><wx:uiName wx:val='Heading 2'/><w:basedOn w:val='Normal'/><w:next w:val='Normal'/><w:link w:val='Heading2Char'/><w:rsid w:val='0058350F'/><w:pPr><w:pBdr><w:bottom w:val='single' w:sz='8' wx:bdrwidth='20' w:space='1' w:color='4F81BD'/></w:pBdr><w:spacing w:before='200' w:after='80'/><w:ind w:first-line='0'/><w:outlineLvl w:val='1'/></w:pPr><w:rPr><w:rFonts w:ascii='Arial' w:h-ansi='Arial'/><wx:font wx:val='Arial'/><w:color w:val='365F91'/><w:sz w:val='24'/><w:sz-cs w:val='24'/></w:rPr></w:style><w:style w:type='paragraph' w:styleId='Heading3'><w:name w:val='heading 3'/><wx:uiName wx:val='Heading 3'/><w:basedOn w:val='Normal'/><w:next w:val='Normal'/><w:link w:val='Heading3Char'/><w:rsid w:val='0058350F'/><w:pPr><w:pBdr><w:bottom w:val='single' w:sz='4' wx:bdrwidth='10' w:space='1' w:color='95B3D7'/></w:pBdr><w:spacing w:before='200' w:after='80'/><w:ind w:first-line='0'/><w:outlineLvl w:val='2'/></w:pPr><w:rPr><w:rFonts w:ascii='Arial' w:h-ansi='Arial'/><wx:font wx:val='Arial'/><w:color w:val='4F81BD'/><w:sz w:val='24'/><w:sz-cs w:val='24'/></w:rPr></w:style><w:style w:type='paragraph' w:styleId='Heading4'><w:name w:val='heading 4'/><wx:uiName wx:val='Heading 4'/><w:basedOn w:val='Normal'/><w:next w:val='Normal'/><w:link w:val='Heading4Char'/><w:rsid w:val='0058350F'/><w:pPr><w:pBdr><w:bottom w:val='single' w:sz='4' wx:bdrwidth='10' w:space='2' w:color='B8CCE4'/></w:pBdr><w:spacing w:before='200' w:after='80'/><w:ind w:first-line='0'/><w:outlineLvl w:val='3'/></w:pPr><w:rPr><w:rFonts w:ascii='Arial' w:h-ansi='Arial'/><wx:font wx:val='Arial'/><w:i/><w:i-cs/><w:color w:val='4F81BD'/><w:sz w:val='24'/><w:sz-cs w:val='24'/></w:rPr></w:style><w:style w:type='paragraph' w:styleId='Heading5'><w:name w:val='heading 5'/><wx:uiName wx:val='Heading 5'/><w:basedOn w:val='Normal'/><w:next w:val='Normal'/><w:link w:val='Heading5Char'/><w:rsid w:val='0058350F'/><w:pPr><w:spacing w:before='200' w:after='80'/><w:ind w:first-line='0'/><w:outlineLvl w:val='4'/></w:pPr><w:rPr><w:rFonts w:ascii='Arial' w:h-ansi='Arial'/><wx:font wx:val='Arial'/><w:color w:val='4F81BD'/></w:rPr></w:style><w:style w:type='paragraph' w:styleId='Heading6'><w:name w:val='heading 6'/><wx:uiName wx:val='Heading 6'/><w:basedOn w:val='Normal'/><w:next w:val='Normal'/><w:link w:val='Heading6Char'/><w:rsid w:val='0058350F'/><w:pPr><w:spacing w:before='280' w:after='100'/><w:ind w:first-line='0'/><w:outlineLvl w:val='5'/></w:pPr><w:rPr><w:rFonts w:ascii='Arial' w:h-ansi='Arial'/><wx:font wx:val='Arial'/><w:i/><w:i-cs/><w:color w:val='4F81BD'/></w:rPr></w:style><w:style w:type='paragraph' w:styleId='Heading7'><w:name w:val='heading 7'/><wx:uiName wx:val='Heading 7'/><w:basedOn w:val='Normal'/><w:next w:val='Normal'/><w:link w:val='Heading7Char'/><w:rsid w:val='0058350F'/><w:pPr><w:spacing w:before='320' w:after='100'/><w:ind w:first-line='0'/><w:outlineLvl w:val='6'/></w:pPr><w:rPr><w:rFonts w:ascii='Arial' w:h-ansi='Arial'/><wx:font wx:val='Arial'/><w:b/><w:b-cs/><w:color w:val='9BBB59'/><w:sz w:val='20'/><w:sz-cs w:val='20'/></w:rPr></w:style><w:style w:type='paragraph' w:styleId='Heading8'><w:name w:val='heading 8'/><wx:uiName wx:val='Heading 8'/><w:basedOn w:val='Normal'/><w:next w:val='Normal'/><w:link w:val='Heading8Char'/><w:rsid w:val='0058350F'/><w:pPr><w:spacing w:before='320' w:after='100'/><w:ind w:first-line='0'/><w:outlineLvl w:val='7'/></w:pPr><w:rPr><w:rFonts w:ascii='Arial' w:h-ansi='Arial'/><wx:font wx:val='Arial'/><w:b/><w:b-cs/><w:i/><w:i-cs/><w:color w:val='9BBB59'/><w:sz w:val='20'/><w:sz-cs w:val='20'/></w:rPr></w:style><w:style w:type='paragraph' w:styleId='Heading9'><w:name w:val='heading 9'/><wx:uiName wx:val='Heading 9'/><w:basedOn w:val='Normal'/><w:next w:val='Normal'/><w:link w:val='Heading9Char'/><w:rsid w:val='0058350F'/><w:pPr><w:spacing w:before='320' w:after='100'/><w:ind w:first-line='0'/><w:outlineLvl w:val='8'/></w:pPr><w:rPr><w:rFonts w:ascii='Arial' w:h-ansi='Arial'/><wx:font wx:val='Arial'/><w:i/><w:i-cs/><w:color w:val='9BBB59'/><w:sz w:val='20'/><w:sz-cs w:val='20'/></w:rPr></w:style><w:style w:type='character' w:default='on' w:styleId='DefaultParagraphFont'><w:name w:val='Default Paragraph Font'/></w:style><w:style w:type='table' w:default='on' w:styleId='TableNormal'><w:name w:val='Normal Table'/><wx:uiName wx:val='Table Normal'/><w:rPr><wx:font wx:val='Times New Roman'/><w:lang w:val='EN-US' w:fareast='EN-US' w:bidi='AR-SA'/></w:rPr><w:tblPr><w:tblInd w:w='0' w:type='dxa'/><w:tblCellMar><w:top w:w='0' w:type='dxa'/><w:left w:w='108' w:type='dxa'/><w:bottom w:w='0' w:type='dxa'/><w:right w:w='108' w:type='dxa'/></w:tblCellMar></w:tblPr></w:style><w:style w:type='list' w:default='on' w:styleId='NoList'><w:name w:val='No List'/></w:style><w:style w:type='character' w:styleId='Heading1Char'><w:name w:val='Heading 1 Char'/><w:basedOn w:val='DefaultParagraphFont'/><w:link w:val='Heading1'/><w:rsid w:val='0058350F'/><w:rPr><w:rFonts w:ascii='Arial' w:fareast='Times New Roman' w:h-ansi='Arial' w:cs='Times New Roman'/><w:b/><w:b-cs/><w:color w:val='365F91'/><w:sz w:val='24'/><w:sz-cs w:val='24'/></w:rPr></w:style><w:style w:type='character' w:styleId='Heading2Char'><w:name w:val='Heading 2 Char'/><w:basedOn w:val='DefaultParagraphFont'/><w:link w:val='Heading2'/><w:rsid w:val='0058350F'/><w:rPr><w:rFonts w:ascii='Arial' w:fareast='Times New Roman' w:h-ansi='Arial' w:cs='Times New Roman'/><w:color w:val='365F91'/><w:sz w:val='24'/><w:sz-cs w:val='24'/></w:rPr></w:style><w:style w:type='character' w:styleId='Heading3Char'><w:name w:val='Heading 3 Char'/><w:basedOn w:val='DefaultParagraphFont'/><w:link w:val='Heading3'/><w:rsid w:val='0058350F'/><w:rPr><w:rFonts w:ascii='Arial' w:fareast='Times New Roman' w:h-ansi='Arial' w:cs='Times New Roman'/><w:color w:val='4F81BD'/><w:sz w:val='24'/><w:sz-cs w:val='24'/></w:rPr></w:style><w:style w:type='character' w:styleId='Heading4Char'><w:name w:val='Heading 4 Char'/><w:basedOn w:val='DefaultParagraphFont'/><w:link w:val='Heading4'/><w:rsid w:val='0058350F'/><w:rPr><w:rFonts w:ascii='Arial' w:fareast='Times New Roman' w:h-ansi='Arial' w:cs='Times New Roman'/><w:i/><w:i-cs/><w:color w:val='4F81BD'/><w:sz w:val='24'/><w:sz-cs w:val='24'/></w:rPr></w:style><w:style w:type='character' w:styleId='Heading5Char'><w:name w:val='Heading 5 Char'/><w:basedOn w:val='DefaultParagraphFont'/><w:link w:val='Heading5'/><w:rsid w:val='0058350F'/><w:rPr><w:rFonts w:ascii='Arial' w:fareast='Times New Roman' w:h-ansi='Arial' w:cs='Times New Roman'/><w:color w:val='4F81BD'/></w:rPr></w:style><w:style w:type='character' w:styleId='Heading6Char'><w:name w:val='Heading 6 Char'/><w:basedOn w:val='DefaultParagraphFont'/><w:link w:val='Heading6'/><w:rsid w:val='0058350F'/><w:rPr><w:rFonts w:ascii='Arial' w:fareast='Times New Roman' w:h-ansi='Arial' w:cs='Times New Roman'/><w:i/><w:i-cs/><w:color w:val='4F81BD'/></w:rPr></w:style><w:style w:type='character' w:styleId='Heading7Char'><w:name w:val='Heading 7 Char'/><w:basedOn w:val='DefaultParagraphFont'/><w:link w:val='Heading7'/><w:rsid w:val='0058350F'/><w:rPr><w:rFonts w:ascii='Arial' w:fareast='Times New Roman' w:h-ansi='Arial' w:cs='Times New Roman'/><w:b/><w:b-cs/><w:color w:val='9BBB59'/><w:sz w:val='20'/><w:sz-cs w:val='20'/></w:rPr></w:style><w:style w:type='character' w:styleId='Heading8Char'><w:name w:val='Heading 8 Char'/><w:basedOn w:val='DefaultParagraphFont'/><w:link w:val='Heading8'/><w:rsid w:val='0058350F'/><w:rPr><w:rFonts w:ascii='Arial' w:fareast='Times New Roman' w:h-ansi='Arial' w:cs='Times New Roman'/><w:b/><w:b-cs/><w:i/><w:i-cs/><w:color w:val='9BBB59'/><w:sz w:val='20'/><w:sz-cs w:val='20'/></w:rPr></w:style><w:style w:type='character' w:styleId='Heading9Char'><w:name w:val='Heading 9 Char'/><w:basedOn w:val='DefaultParagraphFont'/><w:link w:val='Heading9'/><w:rsid w:val='0058350F'/><w:rPr><w:rFonts w:ascii='Arial' w:fareast='Times New Roman' w:h-ansi='Arial' w:cs='Times New Roman'/><w:i/><w:i-cs/><w:color w:val='9BBB59'/><w:sz w:val='20'/><w:sz-cs w:val='20'/></w:rPr></w:style><w:style w:type='paragraph' w:styleId='Caption'><w:name w:val='caption'/><wx:uiName wx:val='Caption'/><w:basedOn w:val='Normal'/><w:next w:val='Normal'/><w:rsid w:val='0058350F'/><w:rPr><wx:font wx:val='Times New Roman'/><w:b/><w:b-cs/><w:sz w:val='18'/><w:sz-cs w:val='18'/></w:rPr></w:style><w:style w:type='paragraph' w:styleId='Title'><w:name w:val='Title'/><w:basedOn w:val='Normal'/><w:next w:val='Normal'/><w:link w:val='TitleChar'/><w:rsid w:val='0058350F'/><w:pPr><w:pBdr><w:top w:val='single' w:sz='8' wx:bdrwidth='20' w:space='10' w:color='A7BFDE'/><w:bottom w:val='single' w:sz='24' wx:bdrwidth='60' w:space='15' w:color='9BBB59'/></w:pBdr><w:ind w:first-line='0'/><w:jc w:val='center'/></w:pPr><w:rPr><w:rFonts w:ascii='Arial' w:h-ansi='Arial'/><wx:font wx:val='Arial'/><w:i/><w:i-cs/><w:color w:val='243F60'/><w:sz w:val='60'/><w:sz-cs w:val='60'/></w:rPr></w:style><w:style w:type='character' w:styleId='TitleChar'><w:name w:val='Title Char'/><w:basedOn w:val='DefaultParagraphFont'/><w:link w:val='Title'/><w:rsid w:val='0058350F'/><w:rPr><w:rFonts w:ascii='Arial' w:fareast='Times New Roman' w:h-ansi='Arial' w:cs='Times New Roman'/><w:i/><w:i-cs/><w:color w:val='243F60'/><w:sz w:val='60'/><w:sz-cs w:val='60'/></w:rPr></w:style><w:style w:type='paragraph' w:styleId='Subtitle'><w:name w:val='Subtitle'/><w:basedOn w:val='Normal'/><w:next w:val='Normal'/><w:link w:val='SubtitleChar'/><w:rsid w:val='0058350F'/><w:pPr><w:spacing w:before='200' w:after='900'/><w:ind w:first-line='0'/><w:jc w:val='right'/></w:pPr><w:rPr><wx:font wx:val='Times New Roman'/><w:i/><w:i-cs/><w:sz w:val='24'/><w:sz-cs w:val='24'/></w:rPr></w:style><w:style w:type='character' w:styleId='SubtitleChar'><w:name w:val='Subtitle Char'/><w:basedOn w:val='DefaultParagraphFont'/><w:link w:val='Subtitle'/><w:rsid w:val='0058350F'/><w:rPr><w:rFonts w:ascii='Times New Roman'/><w:i/><w:i-cs/><w:sz w:val='24'/><w:sz-cs w:val='24'/></w:rPr></w:style><w:style w:type='character' w:styleId='Strong'><w:name w:val='Strong'/><w:basedOn w:val='DefaultParagraphFont'/><w:rsid w:val='0058350F'/><w:rPr><w:b/><w:b-cs/><w:spacing w:val='0'/></w:rPr></w:style><w:style w:type='character' w:styleId='Emphasis'><w:name w:val='Emphasis'/><w:rsid w:val='0058350F'/><w:rPr><w:b/><w:b-cs/><w:i/><w:i-cs/><w:color w:val='5A5A5A'/></w:rPr></w:style><w:style w:type='paragraph' w:styleId='NoSpacing'><w:name w:val='No Spacing'/><w:basedOn w:val='Normal'/><w:link w:val='NoSpacingChar'/><w:rsid w:val='0058350F'/><w:pPr><w:ind w:first-line='0'/></w:pPr><w:rPr><wx:font wx:val='Times New Roman'/></w:rPr></w:style><w:style w:type='character' w:styleId='NoSpacingChar'><w:name w:val='No Spacing Char'/><w:basedOn w:val='DefaultParagraphFont'/><w:link w:val='NoSpacing'/><w:rsid w:val='0058350F'/></w:style><w:style w:type='paragraph' w:styleId='ListParagraph'><w:name w:val='List Paragraph'/><w:basedOn w:val='Normal'/><w:rsid w:val='0058350F'/><w:pPr><w:ind w:left='720'/><w:contextualSpacing/></w:pPr><w:rPr><wx:font wx:val='Times New Roman'/></w:rPr></w:style><w:style w:type='paragraph' w:styleId='Quote'><w:name w:val='Quote'/><w:basedOn w:val='Normal'/><w:next w:val='Normal'/><w:link w:val='QuoteChar'/><w:rsid w:val='0058350F'/><w:rPr><w:rFonts w:ascii='Arial' w:h-ansi='Arial'/><wx:font wx:val='Arial'/><w:i/><w:i-cs/><w:color w:val='5A5A5A'/></w:rPr></w:style><w:style w:type='character' w:styleId='QuoteChar'><w:name w:val='Quote Char'/><w:basedOn w:val='DefaultParagraphFont'/><w:link w:val='Quote'/><w:rsid w:val='0058350F'/><w:rPr><w:rFonts w:ascii='Arial' w:fareast='Times New Roman' w:h-ansi='Arial' w:cs='Times New Roman'/><w:i/><w:i-cs/><w:color w:val='5A5A5A'/></w:rPr></w:style><w:style w:type='paragraph' w:styleId='IntenseQuote'><w:name w:val='Intense Quote'/><w:basedOn w:val='Normal'/><w:next w:val='Normal'/><w:link w:val='IntenseQuoteChar'/><w:rsid w:val='0058350F'/><w:pPr><w:pBdr><w:top w:val='single' w:sz='12' wx:bdrwidth='30' w:space='10' w:color='B8CCE4'/><w:left w:val='single' w:sz='36' wx:bdrwidth='90' w:space='4' w:color='4F81BD'/><w:bottom w:val='single' w:sz='24' wx:bdrwidth='60' w:space='10' w:color='9BBB59'/><w:right w:val='single' w:sz='36' wx:bdrwidth='90' w:space='4' w:color='4F81BD'/></w:pBdr><w:shd w:val='clear' w:color='auto' w:fill='4F81BD'/><w:spacing w:before='320' w:after='320' w:line='300' w:line-rule='auto'/><w:ind w:left='1440' w:right='1440'/></w:pPr><w:rPr><w:rFonts w:ascii='Arial' w:h-ansi='Arial'/><wx:font wx:val='Arial'/><w:i/><w:i-cs/><w:color w:val='FFFFFF'/><w:sz w:val='24'/><w:sz-cs w:val='24'/></w:rPr></w:style><w:style w:type='character' w:styleId='IntenseQuoteChar'><w:name w:val='Intense Quote Char'/><w:basedOn w:val='DefaultParagraphFont'/><w:link w:val='IntenseQuote'/><w:rsid w:val='0058350F'/><w:rPr><w:rFonts w:ascii='Arial' w:fareast='Times New Roman' w:h-ansi='Arial' w:cs='Times New Roman'/><w:i/><w:i-cs/><w:color w:val='FFFFFF'/><w:sz w:val='24'/><w:sz-cs w:val='24'/><w:shd w:val='clear' w:color='auto' w:fill='4F81BD'/></w:rPr></w:style><w:style w:type='character' w:styleId='SubtleEmphasis'><w:name w:val='Subtle Emphasis'/><w:rsid w:val='0058350F'/><w:rPr><w:i/><w:i-cs/><w:color w:val='5A5A5A'/></w:rPr></w:style><w:style w:type='character' w:styleId='IntenseEmphasis'><w:name w:val='Intense Emphasis'/><w:rsid w:val='0058350F'/><w:rPr><w:b/><w:b-cs/><w:i/><w:i-cs/><w:color w:val='4F81BD'/><w:sz w:val='22'/><w:sz-cs w:val='22'/></w:rPr></w:style><w:style w:type='character' w:styleId='SubtleReference'><w:name w:val='Subtle Reference'/><w:rsid w:val='0058350F'/><w:rPr><w:color w:val='auto'/><w:u w:val='single' w:color='9BBB59'/></w:rPr></w:style><w:style w:type='character' w:styleId='IntenseReference'><w:name w:val='Intense Reference'/><w:basedOn w:val='DefaultParagraphFont'/><w:rsid w:val='0058350F'/><w:rPr><w:b/><w:b-cs/><w:color w:val='76923C'/><w:u w:val='single' w:color='9BBB59'/></w:rPr></w:style><w:style w:type='character' w:styleId='BookTitle'><w:name w:val='Book Title'/><w:basedOn w:val='DefaultParagraphFont'/><w:rsid w:val='0058350F'/><w:rPr><w:rFonts w:ascii='Arial' w:fareast='Times New Roman' w:h-ansi='Arial' w:cs='Times New Roman'/><w:b/><w:b-cs/><w:i/><w:i-cs/><w:color w:val='auto'/></w:rPr></w:style><w:style w:type='paragraph' w:styleId='TOCHeading'><w:name w:val='TOC Heading'/><w:basedOn w:val='Heading1'/><w:next w:val='Normal'/><w:rsid w:val='0058350F'/><w:pPr><w:outlineLvl w:val='9'/></w:pPr><w:rPr><wx:font wx:val='Arial'/></w:rPr></w:style><w:style w:type='table' w:styleId='TableGrid'><w:name w:val='Table Grid'/><w:basedOn w:val='TableNormal'/><w:rsid w:val='00524F55'/><w:rPr><wx:font wx:val='Times New Roman'/></w:rPr><w:tblPr><w:tblInd w:w='0' w:type='dxa'/><w:tblBorders><w:top w:val='single' w:sz='4' wx:bdrwidth='10' w:space='0' w:color='000000'/><w:left w:val='single' w:sz='4' wx:bdrwidth='10' w:space='0' w:color='000000'/><w:bottom w:val='single' w:sz='4' wx:bdrwidth='10' w:space='0' w:color='000000'/><w:right w:val='single' w:sz='4' wx:bdrwidth='10' w:space='0' w:color='000000'/><w:insideH w:val='single' w:sz='4' wx:bdrwidth='10' w:space='0' w:color='000000'/><w:insideV w:val='single' w:sz='4' wx:bdrwidth='10' w:space='0' w:color='000000'/></w:tblBorders><w:tblCellMar><w:top w:w='0' w:type='dxa'/><w:left w:w='108' w:type='dxa'/><w:bottom w:w='0' w:type='dxa'/><w:right w:w='108' w:type='dxa'/></w:tblCellMar></w:tblPr></w:style></w:styles><w:shapeDefaults><o:shapedefaults v:ext='edit' spidmax='5122'/><o:shapelayout v:ext='edit'><o:idmap v:ext='edit' data='1'/></o:shapelayout></w:shapeDefaults><w:docPr><w:view w:val='print'/><w:zoom w:percent='100'/><w:doNotEmbedSystemFonts/><w:defaultTabStop w:val='720'/><w:drawingGridHorizontalSpacing w:val='110'/><w:displayHorizontalDrawingGridEvery w:val='2'/><w:displayVerticalDrawingGridEvery w:val='2'/><w:punctuationKerning/><w:characterSpacingControl w:val='DontCompress'/><w:optimizeForBrowser/><w:validateAgainstSchema/><w:saveInvalidXML w:val='off'/><w:ignoreMixedContent w:val='off'/><w:alwaysShowPlaceholderText w:val='off'/><w:compat><w:breakWrappedTables/><w:snapToGridInCell/><w:wrapTextWithPunct/><w:useAsianBreakRules/><w:dontGrowAutofit/></w:compat><wsp:rsids><wsp:rsidRoot wsp:val='00524F55'/><wsp:rsid wsp:val='00031FBB'/><wsp:rsid wsp:val='001F4EE3'/><wsp:rsid wsp:val='003E453F'/><wsp:rsid wsp:val='00524F55'/><wsp:rsid wsp:val='0058350F'/><wsp:rsid wsp:val='005B50F0'/><wsp:rsid wsp:val='005D04C7'/><wsp:rsid wsp:val='006352A9'/><wsp:rsid wsp:val='00974E22'/><wsp:rsid wsp:val='00D513F1'/><wsp:rsid wsp:val='00E425E9'/><wsp:rsid wsp:val='00FD183D'/></wsp:rsids></w:docPr><w:body>";
        static string paragraph =
@"<w:p wsp:rsidR='00524F55' wsp:rsidRDefault='005B50F0' wsp:rsidP='005B50F0'>";
        static string footer =
@"<w:sectPr wsp:rsidR='005B50F0' wsp:rsidSect='0058350F'><w:pgSz w:w='11907' w:h='16839' w:code='9'/><w:pgMar 
w:top='1134' w:right='1134' w:bottom='1134' w:left='1134' w:header='720' w:footer='720' w:gutter='0'/>
<w:cols w:space='720'/><w:docGrid w:line-pitch='360'/></w:sectPr></w:body>
</w:wordDocument>";
        static int margin = 1134;
        static int availWidth = 9500;
        public static void Write(Stream stream,int[] cols, string[,] rows)
        {
            StreamWriter sw = new StreamWriter(stream);
            int col_num = cols.Length;
            sw.Write(header);
            string colFormat = tabs(cols);
            for (int i = 0; i < rows.GetLength(1); i++)
            {                
                sw.Write(row(colFormat,rows,i,col_num));
            }
            sw.Write(footer);
            sw.Flush();
            sw.Close();
            sw.Dispose();
        }
        public static void Write(string file, int[] cols, string[,] rows)
        {
            StreamWriter sw = new StreamWriter(file);
            int col_num = cols.Length;
            sw.Write(header);
            string colFormat = tabs(cols);
            for (int i = 0; i < rows.GetLength(1); i++)
            {
                sw.Write(row(colFormat, rows, i, col_num));
            }
            sw.Write(footer);
            sw.Flush();
            sw.Close();
            sw.Dispose();
        }
        public static string tabs(int[] col)
        {
            StringBuilder r = new StringBuilder();
            r.AppendLine("<w:pPr><w:tabs>");
            int[] width = new int[col.Length];
            double sum = 0;
            for (int i = 0; i < col.Length; i++)
            {
                sum += col[i];
            }
            for (int i = 0; i < col.Length - 1; i++)
            {
                width[i] =  (i > 0? width[i-1] : 0) + (int)Math.Truncate(col[i] * availWidth / 510.0f); //( sum /600) / sum);
                r.AppendLine("<w:tab w:val='left' w:pos='" + (width[i] + margin) + "'/>");
            }
            r.AppendLine("</w:tabs></w:pPr>");
            return r.ToString();
        }
        public static string row(string tab, string[,] value,int offset,int col_num)
        {            
            StringBuilder r = new StringBuilder();
            r.AppendLine(paragraph);
            r.AppendLine(tab);
            r.AppendLine("<w:r><w:t>" + value[0,offset] + "</w:t></w:r>");
            for (int i = 1; i < col_num; i++)
            {
                r.AppendLine("<w:r><w:tab/><w:t>" + value[i,offset] + "</w:t></w:r>");
            }
            r.AppendLine("</w:p>");
            return r.ToString();
        }
    }
    public class OfficeExcelXml
    {
        // TODO:
        public static string xmlExcelHeader =
@"<?xml version='1.0'?>
<?mso-application progid='Excel.Sheet'?>
<Workbook xmlns='urn:schemas-microsoft-com:office:spreadsheet'
 xmlns:o='urn:schemas-microsoft-com:office:office'
 xmlns:x='urn:schemas-microsoft-com:office:excel'
 xmlns:ss='urn:schemas-microsoft-com:office:spreadsheet'
 xmlns:html='http://www.w3.org/TR/REC-html40'>
 <DocumentProperties xmlns='urn:schemas-microsoft-com:office:office'>
  <Author>Giang Manh</Author>
  <LastAuthor>Giang Manh</LastAuthor>
  <Created>2008-08-05T03:14:23Z</Created>
  <Company>K9A (r) DHBK HN</Company>
  <Version>12.00</Version>
 </DocumentProperties>
<ExcelWorkbook xmlns='urn:schemas-microsoft-com:office:excel'>
  <WindowHeight>8520</WindowHeight>
  <WindowWidth>19125</WindowWidth>
  <WindowTopX>0</WindowTopX>
  <WindowTopY>105</WindowTopY>
  <ActiveSheet>1</ActiveSheet>
  <ProtectStructure>False</ProtectStructure>
  <ProtectWindows>False</ProtectWindows>
 </ExcelWorkbook>
 <Styles>
  <Style ss:ID='Default' ss:Name='Normal'>
   <Alignment ss:Vertical='Bottom'/>
   <Borders/>
   <Font ss:FontName='Times New Roman' x:Family='Swiss' ss:Size='12'
    ss:Color='#000000'/>
   <Interior/>
   <NumberFormat/>
   <Protection/>
  </Style>
 </Styles>";
        public static string xmlExelWorksheetFormat =
@"<Worksheet ss:Name='{0}'>
<Table ss:ExpandedColumnCount='{1}' ss:ExpandedRowCount='{2}'
 x:FullColumns='1' x:FullRows='1' ss:DefaultColumnWidth='54' ss:DefaultRowHeight='15.75'>";

        public static string xmlExcelSheetHeaderFormat =
@"<Worksheet ss:Name='{0}'>
<Table ss:ExpandedColumnCount='{1}' ss:ExpandedRowCount='{2}'
 x:FullColumns='1' x:FullRows='1' ss:DefaultColumnWidth='54' ss:DefaultRowHeight='15.75'>";

        public static string xmlExcelSheetFooter = @"</Table>
  <WorksheetOptions xmlns='urn:schemas-microsoft-com:office:excel'>
   <PageSetup>
    <Header x:Margin='0.3'/>
    <Footer x:Margin='0.3'/>
    <PageMargins x:Bottom='0.75' x:Left='0.7' x:Right='0.7' x:Top='0.75'/>
   </PageSetup>
   <Panes>
    <Pane>
     <Number>3</Number>
     <ActiveCol>1</ActiveCol>
    </Pane>
   </Panes>
   <ProtectObjects>False</ProtectObjects>
   <ProtectScenarios>False</ProtectScenarios>
  </WorksheetOptions>
 </Worksheet>";
        public static string xmlExcelCellFormat =
            @"<Cell><Data ss:Type='{0}'>{1}</Data></Cell>";
        public static string xmlExcelCellStringFormat =
           @"<Cell><Data ss:Type='String'>{0}</Data></Cell>";
        public static string xmlExcelCellNumberFormat =
           @"<Cell><Data ss:Type='Number'>{0}</Data></Cell>";
        public static string xmlExcelFooter =
@"</Table>
  <WorksheetOptions xmlns='urn:schemas-microsoft-com:office:excel'>
   <PageSetup>
    <Header x:Margin='0.3'/>
    <Footer x:Margin='0.3'/>
    <PageMargins x:Bottom='0.75' x:Left='0.7' x:Right='0.7' x:Top='0.75'/>
   </PageSetup>
   <Panes>
    <Pane>
     <Number>3</Number>
     <ActiveCol>1</ActiveCol>
    </Pane>
   </Panes>
   <ProtectObjects>False</ProtectObjects>
   <ProtectScenarios>False</ProtectScenarios>
  </WorksheetOptions>
 </Worksheet>
</Workbook>
";
        public static void Write(Stream stream, string[,] rows,string name)
        {
            StreamWriter sw = new StreamWriter(stream);
            sw.Write(xmlExcelHeader);
            sw.Write(string.Format(xmlExelWorksheetFormat,name,rows.GetLength(0),rows.GetLength(1)));
            StringBuilder s;
            for (int i = 0; i < rows.GetLength(1); i++)
            {
                s = new StringBuilder("<Row>");
                for (int x = 0; x < rows.GetLength(0); x++)
                {
                    s.Append(string.Format(xmlExcelCellFormat, "String", rows[x, i]));
                }
                s.Append("</Row>");
                sw.Write(s.ToString());
            }
            sw.Write(xmlExcelFooter);
            sw.Flush();
            sw.Close();
            sw.Dispose();
        }
        StreamWriter multiple_sheet_writer;
        public OfficeExcelXml(string file)
        {
            multiple_sheet_writer = new StreamWriter(file);
            multiple_sheet_writer.Write(xmlExcelHeader);
        }
        public void Write(DataTable t)
        {
            multiple_sheet_writer.WriteLine(string.Format
                (xmlExcelSheetHeaderFormat, t.TableName, t.Columns.Count, t.Rows.Count));
            string cell;
            for (int y = 0; y < t.Rows.Count; y++)
            {
                multiple_sheet_writer.WriteLine("<Row>");
                for (int x = 0; x < t.Columns.Count; x++)
                {
                    cell = t.Rows[y].ItemArray[x].ToString();
                    try
                    {
                        double.Parse(cell);
                        multiple_sheet_writer.Write(string.Format
                        (xmlExcelCellNumberFormat, cell));
                    }
                    catch (Exception)
                    {
                        multiple_sheet_writer.Write(string.Format
                        (xmlExcelCellStringFormat, cell));
                    }
                }
                multiple_sheet_writer.WriteLine("</Row>");
            }
            multiple_sheet_writer.WriteLine(xmlExcelSheetFooter);
        }
        public void Finish()
        {
            multiple_sheet_writer.WriteLine("</Workbook>");
            multiple_sheet_writer.Close();
            multiple_sheet_writer.Dispose();
        }
        public static void MultipleSheets(DataTable[] r, string fileName,bool open)
        {
            if (r.Length == 0)
            {
                Utility.Miscellaneous.ErrorMessage("Không thể tạo tệp " + fileName + "\nVì nếu tạo, tệp này sẽ không có dữ liệu gì cả.");
                return;
            }
            Utility.OfficeExcelXml doc = new GiangManh.Utility.OfficeExcelXml
                    (fileName);
            for (int i = 0; i < r.Length;i++ )
                doc.Write(r[i]);
            doc.Finish();
            if (open)
                System.Diagnostics.Process.Start(fileName);
        }
    }
    public class OfficeExcel:IDisposable
    {
        OleDbConnection connection;
        public bool Connect(string filename)
        {
            bool state = true;
            try
            {
                string conStr = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                        "Data Source=" + filename + ";" +
                        "Extended Properties=\"Excel 8.0;HDR=YES\"";
                connection = new OleDbConnection(conStr);
                connection.Open();
            }
            catch (Exception ex) {
                Utility.Miscellaneous.ErrorMessage(ex.Message);
                state = false;
            }            
            return state;
        }
        public void SelectNonQuery(string sql)
        {
            using (OleDbCommand cmd = new OleDbCommand(sql, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }
        public OleDbDataReader SelectReader(string sql)
        {
            using (OleDbCommand cmd = new OleDbCommand(sql, connection))
            {
                return cmd.ExecuteReader();
            }
        }
        #region IDisposable Members

        public void Dispose()
        {
            if (connection != null)
            {
                connection.Close();
                connection.Dispose();
            }
        }

        #endregion
    }
}
