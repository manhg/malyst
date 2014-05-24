using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{    
    public partial class FormKeyVisualize : Form
    {
        /// <summary>
        /// Keys dùng trong Tag của form
        /// </summary>
        public enum TagKeys { 
            /// <summary>
            /// Số câu hỏi
            /// </summary>
            Questions, 
            /// <summary>
            /// Trạng thái hiện tại
            /// </summary>
            Answer,
            /// <summary>
            /// Dòng cột trong new suite mà  truyền kết quả vào.
            /// </summary>
            Column,Row,            
        };
        public string returnAns;
        public int rowIndex; 
        /// <summary>
        /// Số câu hỏi trong một cột hiển thị
        /// </summary>
        private const int QuestionsEachColumn = 20;
        /// <summary>
        /// Số lượng câu hỏi
        /// </summary>
        private int _questions;
        /// <summary>
        /// chuỗi đáp án/bài làm nguyên thủy ban đầu.
        /// </summary>
        private string _prime;
        public char[] ans;
        public FormKeyVisualize()
        {
            InitializeComponent();
            this.Tag = new Hashtable();
        }

        private void FormKeyVisualize_Load(object sender, EventArgs e)
        {
            int no;
            #region Kiểm tra đầu vào, chuyển đổi
            if (this.Tag == null)
            {
                Core.Utility.Error("Không có dữ liệu được truyền cho hộp thoại Visualizer.");
                this.Close();
                return;
            }
            Hashtable tag = this.Tag as Hashtable;
            this._prime = Core.Utility.Clarify((string)tag[TagKeys.Answer]);
            this._questions = (int)tag[TagKeys.Questions];
            if (_questions <= 0)
            {
                Core.Utility.Error("Số câu hỏi truyền đến không hợp lệ.");
                return;
            }
            ans = new char[_questions];            
            for (no = 0; no < _questions; no++)
            {
                if (no >= _prime.Length)
                    ans[no] = UI.Properties.Settings.Default.BlankChar;
                else
                    ans[no] = _prime[no];
            }
            #endregion
            #region Đưa dữ liệu hiện tại vào cửa sổ.
            int pairsColumn = (int)Math.Ceiling(_questions * 1.0f / QuestionsEachColumn);                                  
            for (int i = 0; i < QuestionsEachColumn; i++)
            {
                DataGridViewRow row = new DataGridViewRow();                              
                row.CreateCells(gridVisual, new object[pairsColumn * 2]);
                for (int c = 0; c < pairsColumn; c++)
                {
                    no = c * QuestionsEachColumn + i;
                    if (no >= _questions) continue;
                    row.Cells[2 * c].Value = no + 1;
                    row.Cells[2 * c + 1].Tag = no;
                    row.Cells[2 * c + 1].Value = ans[no];                    
                }                
                gridVisual.Rows.Add(row);
            }
            BlankColor = Color.FromArgb(235, 235, 235);
            HighlightColor = Color.FromArgb(234, 234, 243);
            for (int i = 0; i < gridVisual.Rows.Count; i++)
                for (int j = 0; j < gridVisual.Rows[i].Cells.Count; j++)
                    ColorizeCell(gridVisual.Rows[i].Cells[j]);
            gridVisual.Focus();
            gridVisual.EditMode = DataGridViewEditMode.EditOnEnter;
            gridVisual[0, 0].Selected = false;
            gridVisual.Columns[0].ReadOnly = true;
            gridVisual.Columns[2].ReadOnly = true;
            gridVisual.Columns[4].ReadOnly = true;
            gridVisual.Columns[6].ReadOnly = true;
            //gridVisual[1, 0].Selected = true;            
            //gridVisual.BeginEdit(true);                        
            #endregion
        }
        private Color HighlightColor;
        private Color BlankColor;
        /// <summary>
        /// Đặt màu cho các ô
        /// Nếu là cột giá trị, hiện màu tro với BlankChar và Black cho phương án bình thường
        /// </summary>
        /// <param name="cell"></param>        
        private void ColorizeCell(DataGridViewCell cell)
        {
            if (cell.ColumnIndex % 2 == 1 && cell.Value!=null)
            {                
                if ((cell.Value.ToString())[0] == UI.Properties.Settings.Default.BlankChar)
                    cell.Style.ForeColor = BlankColor;
                else
                    cell.Style.ForeColor = Color.Black;
            }
            if (cell.RowIndex % 2 == 1)
                cell.Style.BackColor = HighlightColor;
        }

        private void gridVisual_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            gridVisual[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.Black;
            e.Cancel = false;
        }

        private void gridVisual_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex % 2 == 1 && e.RowIndex >= 0)
            {
                DataGridViewCell cell = gridVisual[e.ColumnIndex, e.RowIndex];
                if (cell.Value is char || cell.Value is string)
                {
                    char c = (cell.Value.ToString().ToUpper())[0];
                    if (('A' <= c && c <= 'D') || c == UI.Properties.Settings.Default.BlankChar)
                        cell.Value = c;
                    else if (('1'<=c)&&(c<='4')) cell.Value=(char)(64 + int.Parse(c.ToString()));
                    else cell.Value = UI.Properties.Settings.Default.BlankChar;
                }
                ColorizeCell(cell);
                object index = gridVisual[e.ColumnIndex, e.RowIndex].Tag;
                if (index != null)
                {
                    if (cell.Value == null)
                    {
                        ans[(int)index] = UI.Properties.Settings.Default.BlankChar;
                        cell.Value = ans[(int)index];
                    }
                    else ans[(int)index] = (char)cell.Value;
                }
            }
        }

        private void FormKeyVisualize_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Chuyển kết quả sang string.
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < _questions; i++)
            {
                s.Append(ans[i]);
            }
            this.returnAns = Core.Utility.ClearLook(s.ToString());
            ((Hashtable)this.Tag)[TagKeys.Answer] = this.returnAns;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
