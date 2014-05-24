using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlServerCe;
using System.Windows.Forms;
using System.Drawing;

using GiangManh.Utility;
using System.Drawing.Imaging;


namespace GiangManh.Locate
{
    public class Database : MessageCapable
    {
        public string FileName = @"D:\temp\locate\locate.sdf";
        public string FolderName = @"D:\temp\locate";
        public float HqDpi = 300;
        /// <summary>
        /// Tạo mới hay hay thêm vào một cơ sở dữ liệu có sẵn trong FileName
        /// </summary>
        public bool AddExsitingDatabase;
        /// <summary>
        /// in megabytes
        /// </summary>
        public int MaxSize = 1024;
        SqlCeConnection connection;
        SqlCeDataAdapter daSession;
        SqlCeDataAdapter daBitmap;
        SqlCeDataAdapter daSignal;
        SqlCeDataAdapter daHqimg;
        ImageConverter imageConverter;
        Type BYTE_ARRAY;
        public bool Init()
        {
            Directory.CreateDirectory(FolderName);
            this.Message+=new MessageEventHandler(DefaultViewer);
            imageConverter = new ImageConverter();
            BYTE_ARRAY = Type.GetType("System.Byte[]");
            connection = new SqlCeConnection(string.Format(
                "data source={0}; database password=;max database size={1}",
                FileName, MaxSize));
            if (!File.Exists(FileName) || AddExsitingDatabase)
            {
                this.createTables();
                Directory.CreateDirectory(this.FolderName);            
            }

            daSession = new SqlCeDataAdapter("SELECT * FROM sessions", connection);
            SqlCeCommandBuilder cmdb = new SqlCeCommandBuilder(daSession);
            daSession.InsertCommand = cmdb.GetInsertCommand();
            daSession.UpdateCommand = cmdb.GetUpdateCommand();
            daSession.DeleteCommand = cmdb.GetDeleteCommand();

            daBitmap = new SqlCeDataAdapter("SELECT * FROM bitmaps", connection);
            cmdb = new SqlCeCommandBuilder(daBitmap);
            daBitmap.InsertCommand = cmdb.GetInsertCommand();
            daBitmap.UpdateCommand = cmdb.GetUpdateCommand();
            daBitmap.DeleteCommand = cmdb.GetDeleteCommand();

            daSignal = new SqlCeDataAdapter("SELECT * FROM signals", connection);
            cmdb = new SqlCeCommandBuilder(daSignal);
            daSignal.InsertCommand = cmdb.GetInsertCommand();
            daSignal.UpdateCommand = cmdb.GetUpdateCommand();
            daSignal.DeleteCommand = cmdb.GetDeleteCommand();

            daHqimg = new SqlCeDataAdapter("SELECT * FROM hqimgs", connection);
            cmdb = new SqlCeCommandBuilder(daHqimg);
            daHqimg.InsertCommand = cmdb.GetInsertCommand();
            daHqimg.UpdateCommand = cmdb.GetUpdateCommand();
            daHqimg.DeleteCommand = cmdb.GetDeleteCommand();

            connection.Open();
            return true;
        }
        public string GetImageFile(int session_id, int img_id)
        { return string.Join(@"\", new string[] { 
            this.FolderName, 
            session_id.ToString(), 
            "bitmap", 
            img_id.ToString() + ".jpg" }); }
        public string GetHqimgFile(int session_id, int img_id, int region_id)
        { return string.Join(@"\", new string[] { 
            this.FolderName, 
            session_id.ToString(),
            "hqimg",
            img_id.ToString(), 
            region_id.ToString() + ".jpg" }); }
        public string GetHqimgPath(int session_id, int img_id)
        {
            return string.Join(@"\", new string[] { 
            this.FolderName, 
            session_id.ToString(),
            "hqimg",
            img_id.ToString()});
        }
        private void verify()
        {
            SqlCeEngine engine = new SqlCeEngine(connection.ConnectionString);
            if (!engine.Verify())
            {                
                engine.Repair(connection.ConnectionString, RepairOption.RecoverCorruptedRows);
            }
            else
            {
                engine.Shrink();                
            }
        }
        private void createTables()
        {
            string[] definitons = {
            "sessions(" +
                "session_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, " +
                "name NVARCHAR(50), date NVARCHAR(16))",

            "bitmaps" +
                "(img_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, " +
                "img IMAGE, session_id INT, " +
                "CONSTRAINT fk_session FOREIGN KEY(session_id) REFERENCES sessions)",

            "hqimgs" +
                "(hqimg_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, " +
                "img_id INT,region_id INT, hqimg IMAGE, " +
                "CONSTRAINT fk_img FOREIGN KEY(img_id) REFERENCES bitmaps)",            

            "signals" +
                "(signal_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY," +
                "img_id INT, root_x INT, root_y INT, type SMALLINT, tilt REAL, ratio REAL, " + 
                "CONSTRAINT fk_img FOREIGN KEY(img_id) REFERENCES bitmaps)"
            };
            SqlCeEngine engine = new SqlCeEngine(connection.ConnectionString);
            engine.CreateDatabase();
            engine.Dispose();            
            connection.Open();
            SqlCeCommand cmd = new SqlCeCommand();
            cmd.Connection = connection;
            foreach (string definition in definitons)
            {
                cmd.CommandText = "CREATE TABLE " + definition;
                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }
        public SqlCeResultSet Select(string sqlStatement)
        {
            SqlCeCommand cmd = new SqlCeCommand(sqlStatement, connection);
            return cmd.ExecuteResultSet(ResultSetOptions.Scrollable | ResultSetOptions.Updatable);
        }
        /// <summary>
        /// Chuyển kết quả select SQL được thành dạng string dễ đọc
        /// </summary>
        /// <param name="dr">Có thể là một ResultSet vì nó thừa kế từ DataReader</param>
        /// <returns></returns>
        public static string DataReaderToString(SqlCeDataReader dr)
        {
            string[] data = new string[dr.FieldCount];
            StringBuilder s = new StringBuilder();
            while (dr.Read())
            {
                for (int i = 0; i < dr.FieldCount; i++)
                    try
                    {
                        data[i] = dr[i].ToString();
                    }
                    catch (InvalidOperationException) { continue; }
                s.AppendLine(string.Join(", ", data));
            }
            return s.ToString();
        }        
       #region Session table
        public int SessionInsert(string name, string date)
        {
            SqlCeCommand insCmd = daSession.InsertCommand;
            insCmd.Parameters[0].Value = name;
            insCmd.Parameters[1].Value = date;
            insCmd.ExecuteNonQuery();
            int session_id = SessionCount();
            string session_root = FolderName + '\\' + session_id + '\\';
            string[] sub_folder = new string[] { "hqimg", "bitmap" };
            foreach (string folder in sub_folder)
                Directory.CreateDirectory(session_root + folder);
            return session_id;
        }        
        public int SessionCount() { return CountRows("sessions"); }
        public SqlCeDataReader SessionQuery()
        {
            SqlCeDataReader dr = daSession.SelectCommand.ExecuteReader();
            if (this.CanMessage)
            {
                DataTable dt = new DataTable("sessions");
                daSession.Fill(dt);
                SendObject(daSession, dt);
                //Inform(this, DataReaderToString(dr));
            }
            return dr;
        }        
       #endregion
       #region Bitmap Table
        public int BitmapInsert(Image img, int session_id)
        {
            SqlCeCommand insCmd = daBitmap.InsertCommand;            
            insCmd.Parameters[0].Value = DBNull.Value;
                //(byte[])imageConverter.ConvertTo(imgClone,BYTE_ARRAY);
            insCmd.Parameters[1].Value = session_id;
            insCmd.ExecuteNonQuery();
            int img_id = BitmapCount();
            Directory.CreateDirectory(GetHqimgPath(session_id, img_id));
            ((Bitmap)img).Save(GetImageFile(session_id, img_id),ImageFormat.Jpeg);

            return img_id;
        }
        public int BitmapCount() { return CountRows("bitmaps"); }        
        public SqlCeDataReader BitmapQuery()
        {
            SqlCeDataReader dr = daBitmap.SelectCommand.ExecuteReader();

            if (this.CanMessage)
            {
                DataTable dt = new DataTable("bitmaps");
                daBitmap.Fill(dt);
                SendObject(daBitmap, dt);
                //while (dr.Read())
                //{
                //    Image img = Image.FromStream(new MemoryStream(dr["img"] as byte[]));
                //    SendObject("Image", img, string.Format(
                //        "img_id: {0}; session_id: {1}", dr["img_id"].ToString(), dr["session_id"]));
                //}
            }
            return dr;
        }
        #endregion
       #region Signal Table
        public int SignalInsert(int img_id,Point root,Signal type, double tilt, double ratio)
        {
            SqlCeCommand insCmd = daSignal.InsertCommand;
            SqlCeParameterCollection param = insCmd.Parameters;
            param[0].Value = img_id;
            param[1].Value = root.X;
            param[2].Value = root.Y;
            param[3].Value = (int)type;
            param[4].Value = tilt;
            param[5].Value = ratio;
            insCmd.ExecuteNonQuery();
            return SignalCount();
        }
        public int SignalCount() { return CountRows("signals"); }        
        public SqlCeDataReader SignalQuery()
        {
            SqlCeDataReader dr = daSignal.SelectCommand.ExecuteReader();
            if (this.CanMessage)
            {
                //Inform(this,DataReaderToString(dr));
                DataTable dt = new DataTable("signals");
                daSignal.Fill(dt);
                SendObject(daSignal, dt);
            }
            return dr;
        }        
       #endregion
       #region Hqimg Table
        public int HqimgInsert(int session_id,int img_id,int region_id,Image hqimg)
        {
            SqlCeCommand insCmd = daHqimg.InsertCommand;
            insCmd.Parameters[0].Value = img_id;
            insCmd.Parameters[1].Value = region_id;            
            insCmd.Parameters[2].Value = DBNull.Value; //(byte[])imageConverter.ConvertTo(imgClone, BYTE_ARRAY);            
            insCmd.ExecuteNonQuery();
            ((Bitmap)hqimg).Save(GetHqimgFile(session_id, img_id, region_id), ImageFormat.Jpeg);
            return HqimgCount();            
        }
        public int HqimgCount() { return CountRows("hqimgs"); }
        public void HqimgQuery()
        {
            if (this.CanMessage)
            {
                DataTable dt = new DataTable("hqimgs");
                daHqimg.Fill(dt);
                SendObject(daHqimg, dt);
            }
        }
       #endregion

        public int CountRows(string table)
        {
            SqlCeCommand cmd = new SqlCeCommand("SELECT COUNT(*) AS num_row FROM " + table,connection);
            return (int)cmd.ExecuteScalar();                    
        }
        public void Close()
        {
            daSignal.Dispose();
            daSession.Dispose();
            daBitmap.Dispose();
            connection.Close();
        }
        public override string ToString()
        {
            return string.Format("{0} {1}",base.ToString(),this.FileName);
        }

        public void DefaultViewer(object sender, MessageEventArgs e)
        {
            switch (sender.GetType().Name)
            {
                case "SqlCeDataAdapter":
                    DataTable dt = e.Something as DataTable;
                    if (dt ==  null) break;
                    FormTableViewer viewer = new FormTableViewer();
                    viewer.Text = dt.TableName;
                    viewer.grid.DataSource = dt;
                    viewer.grid.DataMember = "";
                    switch (dt.TableName)
                    {
                        case "hqimgs":                                                        
                            break;
                        default:
                            break;
                    }
                    viewer.ShowDialog();
                    break;
            }
        }
    }
    public class AcquisitionSetting
    {
        /// <summary>
        /// Thứ tự ưu tiên hoặc các điểm cần định vị
        /// </summary>
        public Signal[] Prior;
        /// <summary>
        /// Các vùng cần cắt để đưa vào *hqimg*
        /// Đơn vị: mm
        /// </summary>
        public RectangleF[] HqRegion;
        /// <summary>
        /// Mã vùng cắt để phân biệt những mảnh cùng cắt từ 1 img_id
        /// </summary>
        public int[] HqRegionId;
        /// <summary>
        /// Kích thước vạch ra bởi bốn hoặc một số trong bốn điểm định vị
        /// Đơn vị: mm
        /// </summary>
        public PointF Dimension;
        /// <summary>
        /// Tên session lưu trong database
        /// </summary>
        public string SessionName;
        /// <summary>
        /// Các kiểu file hỗ trợ đối với workFolder 
        /// </summary>
        public string[] ImageTypes = new string[] {"*.jpg","*.bmp","*.tif"};
        public string Name;
        public object Extend;
    }
    /// <summary>
    /// Cần khởi tạo: 
    ///     + setting
    ///     + db 
    /// Mục tiêu:
    ///     - Lấy hình quét
    ///     - Downsample ảnh xuống WorkDpi và lưu trong cơ sở dữ liệu
    ///     - Thực hiện nhận dạng, lưu kết quả
    ///     - Bóc tách chất lượng cao một số vùng cần thiết
    /// </summary>
    public class Acquire : MessageCapable
    {
        int session_id;
        string[] files;
        public string[] Files
        {
            get { return files; }
            set { files = value; }
        }
        private AcquisitionSetting setting = new AcquisitionSetting();

        public AcquisitionSetting Setting
        {
            get { return setting; }
            set { setting = value; }
        }
        private Locate.Database data;
        public Locate.Database Data
        {
            get { return data; }
            set { data = value; }
        }
        public enum Error { None, InvalidImage, FileNotFound, Storage };
        Error error = Error.None;
        public Acquire(AcquisitionSetting setting, MessageEventHandler handler)
        {
            this.setting = setting;
        }
        public Acquire(MessageEventHandler handler)
        {
            this.MessageDelegates = handler;
        }
        public Acquire()
        {            
        }
        bool isInitialized = false;
        /// <summary>
        /// Khởi tạo: 
        ///     + Cơ sở dữ liệu
        ///     + Tạo session.
        /// </summary>
        public void Init()
        {
            if (!isInitialized)
            {
                // generate session info
                this.session_id = data.SessionInsert(setting.SessionName, Miscellaneous.GetIsoDate());
            }
        }
        public void WorkFolder(string path)
        {
            string filter = string.Join(";", setting.ImageTypes);
            this.files = Directory.GetFiles(path, filter);
            foreach (string file in files)
            {
                workFile(file);
            }
        }
        private void workFile(string fileName)
        {
            Bitmap bitmap;
            try
            {
                FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                bitmap = new Bitmap(stream);
                stream.Close();
            }
            catch (FileNotFoundException) { error = Error.FileNotFound; return; }
            catch (ArgumentException) { error = Error.InvalidImage; return; }
            catch (IOException) { error = Error.Storage; return; }
            Work(bitmap);
            
        }
        public void Work(Image img)
        {
            Init();
            Image smple = Utility.ManipulateImage.Resample(Anchor.WorkDpi, img);            
            Anchor r = new Anchor(smple);
            r.CanAskUserHelp = true;
            r.PriorOrder = setting.Prior;
            r.Init();
            if (r.Acceptable)
            {                
                Locate.Result result = r.GetResult(setting.Dimension);
                int img_id = data.BitmapInsert(
                    Utility.ManipulateImage.Rotate(smple,result.root,(float)(result.tilt * 180 / Math.PI)),
                    this.session_id);
                smple.Dispose();
                Point hqroot = new Point(
                        (int)Math.Round(result.root.X * img.HorizontalResolution / Anchor.WorkDpi),
                        (int)Math.Round(result.root.Y * img.VerticalResolution / Anchor.WorkDpi));
                Image hq = Utility.ManipulateImage.Rotate(img,hqroot,(float)(result.tilt * 180 / Math.PI));
                data.HqimgInsert(session_id,img_id,-1,hq); // ultimate source image
                RectangleF[] hqregion = setting.HqRegion;
                Miscellaneous.MmConverter converter= new Miscellaneous.MmConverter();
                converter.Dpi4mmToPixel = hq.HorizontalResolution;
                converter.ScaleX = (float)result.x_ratio;
                converter.ScaleY = (float)result.y_ratio;
                for (int i = 0; i < hqregion.Length; i++)
                {                    
                    Rectangle toclip = converter.MmToPixel(hqregion[i]);
                    toclip.Offset(hqroot);                    
                    Image hqregion_img = Utility.ManipulateImage.Clip(hq, toclip);
                    data.HqimgInsert(session_id,img_id, setting.HqRegionId[i], hqregion_img);
                    hqregion_img.Dispose();
                }
                data.SignalInsert(img_id, result.root, result.type,result.tilt,result.ratio);
            }
        }
    }
}
