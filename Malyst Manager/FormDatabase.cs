using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GiangManh.MM;
using System.Data.SqlServerCe;

namespace MalystManager
{
    public partial class FormDatabase : Form
    {
        private GiangManh.MM.Database database;
        public GiangManh.MM.Database Database
        {
            get { return database; }
            set
            {
                database = value;
                DataTable[] dt = new DataTable[5];
                Database.Tables[] table = new Database.Tables[]
                    { Database.Tables.Courses,
                        Database.Tables.Groups,
                        Database.Tables.Marks,
                        Database.Tables.Students,
                        Database.Tables.Teachers};
                DataGridView[] grid = new DataGridView[] 
                {
                    tCourse,tGroup,tMark,tStudent,tTeacher
                };
                int w;
                for (int i = 0; i < grid.Length; i++)
                {
                    SqlCeResultSet r = database.Select(string.Format("SELECT * FROM {0}", table[i]));
                    grid[i].DataSource = r;
                    grid[i].DataMember = string.Empty;                                        
                    for (int j = 0; j < grid[i].Columns.Count; j++)
                    {
                        grid[i].Columns[j].HeaderText = database.TableCaptions(table[i], j);
                        w = database.TableWidth(table[i], j);
                        if (w != -1)
                            grid[i].Columns[j].Width = w;
                    }
                }
            }
        }
        public FormDatabase()
        {
            InitializeComponent();
        }
    }
}
