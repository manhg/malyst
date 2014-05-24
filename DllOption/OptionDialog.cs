using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace GiangManh.Option
{       
    /// <summary>
    /// Thao tác với tùy chọn của chương trình. Có thể sử dụng nhiều
    /// bộ tùy chọn khác nhau nằm trong các file riêng biệt.
    ///     
    /// </summary>    
    public partial class OptionDialog : Form
    {
        public enum AvailableLanguage { Vietnamese, English };
        /// <summary>
        /// Cấu trúc:
        ///     Bảng [0] là bảng chứa các trương mục cho các nhóm tùy chọn
        ///         Bảng có một cột Name duy nhất, chứa danh sách đó
        ///     Các bảng còn lại có tên tương ứng là các dòng trong bảng [0].
        ///         Mỗi bảng có 3 cột: Key, Value, Description
        /// </summary>
        public DataSet Data
        {
            get { return dataset; }
            set { dataset = value; }
        }
        public AvailableLanguage Language
        {
            set
            {
                lang = value;
                if (lang == AvailableLanguage.Vietnamese)
                {

                    toolPart.Text = "Mục";
                    grid.Columns[0].HeaderText = "Tùy chọn";
                    this.Text = "Tùy chỉnh";
                }
            }
            get { return lang; }
        }
        public bool IsDenyChangeKey
        {
            get { return isDenyChangeKey; }
            set { isDenyChangeKey = value; }
        }
        public bool IsDenyChangeParts
        {
            get { return isDenyChangeParts; }
            set { isDenyChangeParts = value; }
        }
        public bool AllowNew
        {
            get { return allowNew; }
            set { allowNew = value; }
        }        
        /// <summary>
        /// Hộp thoại thiết lập các tùy chọn
        /// Dữ liệu nằm trong properties Data
        /// </summary>
        /// <param name="isDenyChangeParts">Cấm thay đổi các trương mục</param>
        /// <param name="isDenyChangeKey">Cấm thay đổi tên và mô tả tùy chọn</param>
        /// <param name="allowNew">Cho phép tạo mới một tùy chọn hay một trương mục</param>
        public OptionDialog(bool isDenyChangeParts, bool isDenyChangeKey, bool allowNew)
        {
            this.isDenyChangeKey = isDenyChangeKey;
            this.isDenyChangeParts = isDenyChangeParts;
            this.allowNew = allowNew;
            InitializeComponent();
            dataset = new DataSet("Options");
            tables = dataset.Tables;
            tablePart = new DataTable("All");            
            tablePart.RowChanged += new DataRowChangeEventHandler(tablePart_RowChanged);
            tablePart.Columns.Add("Name");
            dataset.Tables.Add(tablePart);
            grid.DataSource = tablePart;
            setPermission("All");         
        }
        public void LoadOptionFile(string fileName)
        {
            grid.DataMember = "";
            grid.DataSource = null;
            tablePart.Clear();

            dataset.Clear();
            dataset.Tables.Clear();
            dataset.ReadXml(fileName);

            tables = dataset.Tables;
            tablePart = tables["All"];
            tablePart.RowChanged += new DataRowChangeEventHandler(tablePart_RowChanged);
            grid.DataSource = tablePart;
            grid.DataMember = "";
            this.Text = fileName;

            setPermission("All");
        }

        #region private data
        private const string _XmlFileFilter = "XML Document|*.xml";
        private DataSet dataset;
        private DataTableCollection tables;
        private DataTable tablePart;
        private AvailableLanguage lang = AvailableLanguage.English;
        private bool isDenyChangeKey = false;
        private bool isDenyChangeParts = false;
        private bool allowNew = true;
        private string[] viGridHeader = { "Tùy chọn", "Giá trị", "Mô tả" };
        #endregion
        #region private method
        private void setPermission(string tableName)
        {
            switch (tableName)
            {
                case "All":
                case "Tất cả":
                    grid.ReadOnly = isDenyChangeParts;
                    break;
                default:
                    grid.ReadOnly = false;
                    if (grid.ColumnCount >= 1)
                        grid.Columns[0].ReadOnly = isDenyChangeKey;
                    if (grid.ColumnCount == 3)
                        grid.Columns[2].ReadOnly = isDenyChangeKey;
                    break;
            }
            grid.AllowUserToAddRows = allowNew;
        }
        private void tablePart_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            DataTable itsTable = null;
            switch (e.Action)
            {
                case DataRowAction.Add:
                    try { itsTable = tables.Add(e.Row.ItemArray[0].ToString()); }
                    catch (DuplicateNameException) { return; }
                    itsTable.ExtendedProperties.Add("RelatedRow", e.Row);
                    itsTable.Columns.Add("Key");
                    itsTable.Columns.Add("Value");
                    itsTable.Columns.Add("Description");                    
                    break;
                case DataRowAction.Change:
                    foreach (DataTable t in tables)
                    {
                        if (t.ExtendedProperties.ContainsKey("RelatedRow") &&
                            e.Row.Equals(t.ExtendedProperties["RelatedRow"] as DataRow))
                        {
                            itsTable = t;
                            itsTable.TableName = e.Row.ItemArray[0].ToString();
                            break;
                        }
                    }                    
                    break;
            }            
        }       

        private void toolPart_Populate()
        {            
            ToolStripMenuItem listPart = new ToolStripMenuItem("All");
            if (lang == AvailableLanguage.Vietnamese) listPart.Text = "Tất cả";
            ToolStripSeparator seperator1 = new ToolStripSeparator();                     
            toolPart.DropDownItems.Clear();
            toolPart.DropDownItems.Add(listPart);
            toolPart.DropDownItems.Add(seperator1);
            
            if (tablePart.Rows.Count != 0)
            {
                ToolStripMenuItem[] items = new ToolStripMenuItem[tablePart.Rows.Count];
                int i = 0;
                foreach (DataRow row in tablePart.Rows)
                {
                    items[i] = new ToolStripMenuItem(row.ItemArray[0].ToString());
                    i++;
                }
                toolPart.DropDownItems.AddRange(items);
            }
            
        }        

        private void toolPart_DropDownOpening(object sender, EventArgs e)
        {
            toolPart_Populate();
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDlg = new SaveFileDialog();
            saveFileDlg.Filter = OptionDialog._XmlFileFilter;
            if (saveFileDlg.ShowDialog() == DialogResult.OK)
            {
                dataset.WriteXml(saveFileDlg.FileName);
            }
        }

        private void toolOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.Multiselect = false;
            openFileDlg.SupportMultiDottedExtensions = true;
            openFileDlg.Filter = OptionDialog._XmlFileFilter;
            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                LoadOptionFile(openFileDlg.FileName);
            }
            
        }       

        private void toolPart_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string tableName = e.ClickedItem.Text;
            if (tableName == "All" || tableName == "Tất cả")
            {
                grid.DataSource = tablePart;
                toolPart.Text = tableName;
                if (lang == AvailableLanguage.Vietnamese)
                    grid.Columns[0].HeaderText = "Tùy chọn";
            }
            else
            {
                if (tables.Contains(tableName))
                {
                    grid.DataSource = tables[tableName];
                    switch (Language)
                    {
                        case AvailableLanguage.Vietnamese:
                            for (int i = 0; i < grid.Columns.Count; i++)
                                grid.Columns[i].HeaderText = viGridHeader[i];
                            toolPart.Text = "Mục: " + tableName;
                            break;
                        case AvailableLanguage.English:
                            toolPart.Text = "Part: " + tableName;
                            break;
                    }
                }
                else
                {
                    grid.DataMember = "";
                }
            }
            setPermission(tableName);
        }
        #endregion
    }
}
