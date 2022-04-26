using System;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Phan_Mem_Quan_Ly_Cam_Do.DoiTuong;

namespace Phan_Mem_Quan_Ly_Cam_Do.QuanLyDuLieu
{
    public delegate void BackupErrorEventHander(object sender, string message);

    public delegate void BackupProcessEventHander(object sender, PercentCompleteEventArgs e);

    public delegate void BackupCompleteEventHander(
        object sender, ServerMessageEventArgs e);

    public delegate void RestoreErrorEventHander(object sender, string message);

    public delegate void RestoreProcessEventHander(object sender, PercentCompleteEventArgs e);

    public delegate void RestoreCompleteEventHander(
        object sender, ServerMessageEventArgs e);

    public delegate void AttachErrorEventHander(object sender, string message);

    public delegate void AttachCompleteEventHander(object sender);

    public delegate void CreatedErrorEventHander(object sender, string message);

    public delegate void CreatedProcessEventHander(object sender, PercentCompleteEventArgs e);

    public delegate void CreatedCompleteEventHander(
        object sender, ServerMessageEventArgs e);

    public delegate void DetachErrorEventHander(object sender, string message);

    public delegate void DetachCompleteEventHander(object sender);

    public delegate void DeletedErrorEventHander(object sender, string message);

    public delegate void DeletedCompleteEventHander(object sender);

    public delegate void ServerReloadEventHander(object sender, DataTable data);

    public delegate void DatabaseErrorEventHander(object sender, string message);

    public delegate void DatabaseCompleteEventHander(object sender, DataTable data);

    public delegate void DatabaseFoundEventHander(object sender, DATA item);

    public delegate void DatabasePercentEventHander(object sender, int e);

    public class DataController
    {
        private static string _mConnectString = "Data Source=(local);Initial Catalog=master;Integrated Security=True";

        public static string ConnectString
        {
            get { return _mConnectString; }
            set { _mConnectString = value; }
        }

        #region Delegate

        #region Backup

        public event BackupErrorEventHander BackupError;
        public event BackupProcessEventHander BackupProcess;
        public event BackupCompleteEventHander BackupComplete;

        private void RaiseBackupProcessEventHander(PercentCompleteEventArgs e)
        {
            if (BackupProcess != null) BackupProcess(this, e);
        }

        private void RaiseBackupErrorEventHander(string message)
        {
            if (BackupError != null) BackupError(this, message);
        }

        private void RaiseBackupCompleteEventHander(ServerMessageEventArgs e)
        {
            if (BackupComplete != null) BackupComplete(this, e);
        }

        #endregion

        #region Restore

        public event RestoreProcessEventHander RestoreProcess;
        public event RestoreErrorEventHander RestoreError;
        public event RestoreCompleteEventHander RestoreComplete;

        private void RaiseRestoreErrorEventHander(string message)
        {
            if (RestoreError != null) RestoreError(this, message);
        }

        private void RaiseRestoreProcessEventHander(PercentCompleteEventArgs e)
        {
            if (RestoreProcess != null) RestoreProcess(this, e);
        }

        private void RaiseRestoreCompleteEventHander(ServerMessageEventArgs e)
        {
            if (RestoreComplete != null) RestoreComplete(this, e);
        }

        #endregion

        #region Attach

        public event AttachErrorEventHander AttachError;
        public event AttachCompleteEventHander AttachComplete;

        private void RaiseAttachErrorEventHander(string message)
        {
            if (AttachError != null) AttachError(this, message);
        }

        private void RaiseAttachCompleteEventHander()
        {
            if (AttachComplete != null) AttachComplete(this);
        }

        #endregion

        #region Created

        public event CreatedErrorEventHander CreatedError;
        public event CreatedProcessEventHander CreatedProcess;
        public event CreatedCompleteEventHander CreatedComplete;

        private void RaiseCreatedErrorEventHander(string message)
        {
            if (CreatedError != null) CreatedError(this, message);
        }

        private void RaiseCreatedProcessEventHander(PercentCompleteEventArgs e)
        {
            if (CreatedProcess != null) CreatedProcess(this, e);
        }

        private void RaiseCreatedCompleteEventHander(ServerMessageEventArgs e)
        {
            if (CreatedComplete != null) CreatedComplete(this, e);
        }

        #endregion

        #region Detach

        public event DetachErrorEventHander DetachError;
        public event DetachCompleteEventHander DetachComplete;

        private void RaiseDetachErrorEventHander(string message)
        {
            if (DetachError != null) DetachError(this, message);
        }

        private void RaiseDetachCompleteFinishEventHander()
        {
            if (DetachComplete != null) DetachComplete(this);
        }

        #endregion

        #region Deleted

        public event DeletedCompleteEventHander DeletedComplete;

        public event DeletedErrorEventHander DeletedError;

        private void RaiseDeletedErrorEventHander(string message)
        {
            if (DeletedError != null) DeletedError(this, message);
        }

        private void RaiseDeletedCompleteEventHander()
        {
            if (DeletedComplete != null) DeletedComplete(this);
        }

        #endregion

        #endregion

        #region Created

        public void Created(string source, string desc, string database)
        {
            try
            {
                var fileInfo = new FileInfo(source);
                if (!fileInfo.Exists)
                {
                    RaiseCreatedErrorEventHander("Không thể tạo được cơ sở dữ liệu.\nChi Tiết:\n\tCở dữ liệu nguồn không tồn tại vui lòng cài đặt lại phần mềm");
                    return;
                }
                if (!Directory.Exists(desc))
                {
                    RaiseCreatedErrorEventHander("Không thể tạo được cơ sở dữ liệu.\nChi Tiết:\n\tThư mục tạo cơ sở dữ liệu không tồn tại.Vui lòng tạo hay chọn một thư mục khác.");
                    return;
                }


                var backupFilePath = source;
                var destinationDatabaseName = database;
                var databaseFolder = desc;

                var cnn = new SqlConnection(_mConnectString);
                cnn.Open();
                var conn = new ServerConnection(cnn);
                var myServer = new Server(conn);
                //var db = new Database(myServer, database);
                
               // db.StoredProcedures.ItemById(0).Script(new ScriptingOptions());

                var myRestore = new Restore {Database = destinationDatabaseName};

                //Database currentDb = myServer.Databases[destinationDatabaseName];
                //if (currentDb != null)
                //myServer.KillAllProcesses(destinationDatabaseName);

                myRestore.Devices.AddDevice(backupFilePath, DeviceType.File);
                var dt = myRestore.ReadFileList(myServer);
                var databaseFileName = "ERP";
                var databaseLogFileName = "ERP_Log";
                if (dt == null)
                {
                    RaiseCreatedErrorEventHander("Không thể tạo được cơ sở dữ liệu.\nChi Tiết:\n\tTập tin cơ sở dữ liệu nguồn không đúng, vui lòng cài đặt lại phần mềm.");
                    return;
                }
                if (dt.Rows.Count != 0)
                {
                    databaseFileName = dt.Rows[0][0].ToString();
                    databaseLogFileName = dt.Rows[1][0].ToString();
                }

                var dataFileLocation = databaseFolder + "\\" + destinationDatabaseName + ".mdf";
                var logFileLocation = databaseFolder + "\\" + destinationDatabaseName + "_log.ldf";
                myRestore.RelocateFiles.Add(new RelocateFile(databaseFileName, dataFileLocation));
                myRestore.RelocateFiles.Add(new RelocateFile(databaseLogFileName, logFileLocation));
                myRestore.ReplaceDatabase = true;
                myRestore.PercentCompleteNotification = 10;
                myRestore.PercentComplete +=
                    myRestore_PercentComplete;
                myRestore.Complete += myRestore_Complete;
                myRestore.SqlRestore(myServer);
                cnn.Close();
            }

            catch (Exception ex)
            {
                if (ex.Message.IndexOf("failed for Server") != -1)
                {
                    RaiseCreatedErrorEventHander("Không thể tạo được cơ sở dữ liệu.\nChi Tiết:\n\tThư mục tạo cơ sở dữ liệu đã được bảo vệ, vui lòng chọn thư mục khác.");
                }
                else
                {
                    RaiseCreatedErrorEventHander("Không thể tạo được cơ sở dữ liệu.\nChi Tiết:\n\t" + ex.Message);
                }

            }
        }

        private void myRestore_Complete
            (object sender, ServerMessageEventArgs e)
        {
            RaiseCreatedCompleteEventHander(e);
        }

        private void myRestore_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            RaiseCreatedProcessEventHander(e);
        }

        #endregion

        #region Deleted

        public void Deleted(string database)
        {
            try
            {
                var cnn = new SqlConnection(_mConnectString);
                cnn.Open();
                var conn = new ServerConnection(cnn);
                var myServer = new Server(conn);
                myServer.KillAllProcesses(database);
                myServer.KillDatabase(database);
                //myServer.DetachDatabase(database, true);
                RaiseDeletedCompleteEventHander();
                cnn.Close();
            }
            catch (Exception ex)
            {
                //XtraMessageBox.Show("Error:\n\t" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RaiseDeletedErrorEventHander(ex.Message);
            }
        }

        #endregion

        #region Attach

        //public void Attach(string db, string mdffile)
        //{
        //    try
        //    {
        //        //SqlConnection cnn = new SqlConnection(_mConnectString);
        //        //cnn.Open();
        //        var sqlHelper = new SqlHelper(_mConnectString);

        //        if (sqlHelper.Exists(db) != "OK")
        //        {
        //            RaiseAttachErrorEventHander("Không thể đăng ký được cơ sở dữ liệu.\nChi tiết:\n\tCơ sỡ dữ liệu đã tồn tại.");
        //            return;
        //        }

        //        var result = sqlHelper.Open();
        //        if (result != "OK")
        //        {
        //            RaiseAttachErrorEventHander("Không thể đăng ký được cơ sở dữ liệu.\nChi tiết:\n\t" + result);
        //            return;
        //        }

        //        var conn = new ServerConnection(sqlHelper.Connection);
        //        var myServer = new Server(conn);
        //        var cl = new StringCollection
        //                     {
        //                         myServer.EnumDetachedDatabaseFiles(mdffile)[0],
        //                         myServer.EnumDetachedLogFiles(mdffile)[0]
        //                     };
        //        myServer.AttachDatabase(db, cl);
        //        RaiseAttachCompleteEventHander();
        //        //cnn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        RaiseAttachErrorEventHander("Không thể đăng ký được cơ sở dữ liệu.\nChi tiết:\n\t" + ex.Message);
        //    }
        //}

        #endregion

        #region Detach

        public void Detach(string database)
        {
            try
            {
                var cnn = new SqlConnection(_mConnectString);
                cnn.Open();
                var conn = new ServerConnection(cnn);
                var myServer = new Server(conn);
                myServer.KillAllProcesses(database);
                myServer.DetachDatabase(database, true);
                RaiseDetachCompleteFinishEventHander();
                cnn.Close();
            }
            catch (Exception ex)
            {
                RaiseDetachErrorEventHander(ex.Message);
            }
        }

        #endregion

        #region Backup

        public void BackupDataBase(string databaseName, string destinationPath)
        {
            try
            {
                SqlConnection.ClearAllPools();
                var cnn = new SqlConnection(_mConnectString);
                cnn.Open();
                var conn = new ServerConnection(cnn);
                var myServer = new Server(conn);

                var backup = new Backup {Action = BackupActionType.Database, Database = databaseName};
                //destinationPath = System.IO.Path.Combine(destinationPath, databaseName + ".bak");
                backup.Devices.Add(new BackupDeviceItem(destinationPath, DeviceType.File));
                backup.Initialize = true;
                backup.Checksum = true;
                backup.ContinueAfterError = true;
                backup.Incremental = false;
                backup.LogTruncation = BackupTruncateLogType.Truncate;
                backup.PercentComplete += backup_PercentComplete;
                backup.Complete +=
                    backup_Complete;
                // Perform backup.

                backup.SqlBackup(myServer);
                cnn.Close();
            }
            //catch (FailedOperationException failedOperationException)
            //{
            //    MessageBox.Show(failedOperationException.Message);
            //    RaiseCreatedErrorEventHander("Không thể sao lưu dữ liệu.\nChi Tiết:\n\tThư mục sao lưu đã được bảo vệ, vui lòng chọn thư mục khác.");
            //}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (ex.Message.IndexOf("failed for Server") != -1)
                {
                    RaiseCreatedErrorEventHander("Không thể sao lưu dữ liệu.\nChi Tiết:\n\tThư mục sao lưu đã được bảo vệ, vui lòng chọn thư mục khác.");
                }
                else
                {
                    RaiseBackupErrorEventHander(ex.Message);
                }

            }
        }

        //The event handlers
        private void backup_Complete
            (object sender, ServerMessageEventArgs e)
        {
            RaiseBackupCompleteEventHander(e);
        }

        private void backup_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            RaiseBackupProcessEventHander(e);
        }

      

        #endregion

        #region Restore

        public void RestoreDatabase(
            string backupFilePath,
            string destinationDatabaseName
            )
        {
            Database currentDb;
            Server myServer;
            try
            {
                //SqlConnection.ClearAllPools();
                var cnn = new SqlConnection(_mConnectString);
                cnn.Open();
                var conn = new ServerConnection(cnn);
                myServer = new Server(conn);

                var myRestore = new Restore {Database = destinationDatabaseName};
                currentDb = myServer.Databases[destinationDatabaseName];
                if (currentDb != null)
                    myServer.KillAllProcesses(destinationDatabaseName);

                myRestore.Devices.AddDevice(backupFilePath, DeviceType.File);
                // DataTable dt = myRestore.ReadFileList(myServer);


                //myRestore.RelocateFiles.Add(new RelocateFile(DatabaseFileName, DataFileLocation));
                //myRestore.RelocateFiles.Add(new RelocateFile(DatabaseLogFileName, LogFileLocation));
                myRestore.ReplaceDatabase = true;
                myRestore.PercentCompleteNotification = 10;
                myRestore.Complete += myRestore_Complete1;
                myRestore.PercentComplete += myRestore_PercentComplete1;
                //WriteToLogAndConsole("Restoring:{0}", destinationDatabaseName);
                 

                myRestore.SqlRestore(myServer);
                currentDb = myServer.Databases[destinationDatabaseName];
                currentDb.SetOnline();
                cnn.Close();
            }
            catch (Exception ex)
            {
                RaiseRestoreErrorEventHander(ex.Message);
            }
        }

        private void myRestore_Complete1
            (object sender, ServerMessageEventArgs e)
        {
            RaiseRestoreCompleteEventHander(e);
        }

        private void myRestore_PercentComplete1(object sender, PercentCompleteEventArgs e)
        {
            RaiseRestoreProcessEventHander(e);
        }

        #endregion

        #region GetServers

        private event ServerReloadEventHander ServerReload;

        private void RaiseServerReloadEventHander(DataTable data)
        {
            if (ServerReload != null) ServerReload(this, data);
        }

        public static bool CorrectConnection(string serverConnectionString)
        {
            var cur = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            using (var connection = new SqlConnection(serverConnectionString))
            {
                try
                {
                    connection.Open();
                    connection.Close();
                }
                catch
                {
                    //XtraMessageBox.Show(, ServerModeStrings.failedConnectionCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false; ;
                }
                finally
                {
                    Cursor.Current = cur;
                }
            }
            return true;
        }

        public DataTable GetServer()
        {
            return GetServer(true);
        }

        private DataTable GetServer(bool localOnly)
        {
            var dtServers = SmoApplication.EnumAvailableSqlServers(localOnly);
            RaiseServerReloadEventHander(dtServers);
            return dtServers;
        }
        #endregion

        #region GetAllDatabase

        private event DatabaseErrorEventHander DatabaseError;

        private void RaiseDatabaseErrorEventHander(string message)
        {
            if (DatabaseError != null) DatabaseError(this, message);
        }

        private event DatabaseCompleteEventHander DatabaseComplete;

        private void RaiseDatabaseCompleteEventHander(DataTable data)
        {
            if (DatabaseComplete != null) DatabaseComplete(this, data);
        }

        private event DatabaseFoundEventHander DatabaseFound;

        private void RaiseDatabaseFoundEventHander(DATA data)
        {
            if (DatabaseFound != null) DatabaseFound(this, data);
        }

        public SqlConnection Connection(string serverConnectionString)
        {
            Cursor cur = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            SqlConnection connection = new SqlConnection(serverConnectionString);

            try
            {
                connection.Open();
                //connection.Close();
            }
            catch
            {
                this.RaiseDatabaseErrorEventHander("Không thể kết nối được máy chủ.");

                return connection; ;
            }
            finally
            {
                Cursor.Current = cur;
            }

            return connection;
        }

        public DataTable GetAllDatabase(string server, string user, string password, bool auth)
        {
            string connectionString = String.Format("data source={0};integrated security=SSPI;Initial Catalog=master;", server);
            if (!auth)
                connectionString = String.Format("server={0};user id={1};password={2};", server, user, password);

            Cursor.Current = Cursors.WaitCursor;
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Database");
            SqlConnection cnn = Connection(connectionString);
            try
            {
                if (cnn.State != ConnectionState.Open) return dataTable;
                ServerConnection srvConn = new ServerConnection(cnn);
                Server srvSql = new Server(srvConn);

                foreach (Database dbServer in srvSql.Databases)
                {
                    if (dbServer.IsSystemObject) continue;
                    dataTable.Rows.Add(new object[] { dbServer.Name });
                    DATA item = new DATA(dbServer.Name, dbServer.Version.ToString(), dbServer.CreateDate, dbServer.PrimaryFilePath);
                    RaiseDatabaseFoundEventHander(item);
                    
                }

               
            }
            catch (Exception ex)
            {
                RaiseDatabaseErrorEventHander(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
            
            RaiseDatabaseCompleteEventHander(dataTable);
            return dataTable;

        }

        #endregion

        #region GetDatabase Of Perfect

        public event DatabasePercentEventHander DatabasePercent;

        private void RaiseDatabasePercentEventHander(int e)
        {
            if (DatabasePercent != null) DatabasePercent(this, e);
        }

        //public DataTable GetDatabase(string server, string user, string pass)
        //{
        //    return GetDatabase(new SqlConnection(new SqlHelper().RebuildConnectionString(server, user, pass)));
        //}

        //public DataTable GetDatabase(string server)
        //{
        //    SqlHelper sqlHelper = new SqlHelper();
        //    return GetDatabase(new SqlConnection(sqlHelper.RebuildConnectionString(server)));
        //}

        //public DataTable GetDatabase(SqlConnection mySqlConnection)
        //{
        //    ServerConnection srvConn = new ServerConnection(mySqlConnection);
        //    Server srvSql = new Server(srvConn);
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("STT");
        //    dt.Columns.Add("Database");
        //    dt.Columns.Add("Version");
        //    dt.Columns.Add("Created");
        //    dt.Columns.Add("Path");
        //    RaiseDatabasePercentEventHander(0);
        //    int Percent = 0;
        //    ///SqlHelper.ConnectString = mySqlConnection.ConnectionString;
        //    SYS_INFO sysInfo = new SYS_INFO();
        //    foreach (Database dbServer in srvSql.Databases)
        //    {
        //        try
        //        {
        //            if (dbServer.IsSystemObject) continue;
        //            if (dbServer.Tables["SYS_INFO"] == null) continue;
        //            Percent++;

        //            RaiseDatabasePercentEventHander((int)(((double)Percent / (double)srvSql.Databases.Count)) * 100);

        //            //if (sysInfo.GetInfo(dbServer.Name) == "OK")
        //            //{
        //            //    object[] ob = { dt.Rows.Count + 1, dbServer.Name, sysInfo.Version, dbServer.CreateDate, dbServer.PrimaryFilePath };
        //            //    DATA item = new DATA(dbServer.Name, sysInfo.Version, dbServer.CreateDate, dbServer.PrimaryFilePath);
        //            //    RaiseDatabaseFoundEventHander(item);
        //            //    dt.Rows.Add(ob);
        //            //}

        //            DATA item = new DATA(dbServer.Name, dbServer.Version.ToString(), dbServer.CreateDate, dbServer.PrimaryFilePath);
        //            object[] ob = { dt.Rows.Count + 1, dbServer.Name, sysInfo.Version, dbServer.CreateDate, dbServer.PrimaryFilePath };
        //            RaiseDatabaseFoundEventHander(item);
        //            dt.Rows.Add(ob);
        //        }
        //        catch
        //        {
        //            continue;
        //        }

        //        //}
        //        //catch { } continue;
        //    }
        //    // = srvSql.Databases;
        //    return dt;
        //    RaiseDatabaseCompleteEventHander(dt);
        //}


        #endregion

        public class DataMaker
        {
            //public static string Maker(string server, string userid, string password, string database, string folderData,
            //                           bool authen)
            //{
            //    var mysql = new SqlHelper(server, "master", userid, password, authen);
            //    if (mysql.Exists(database)!="OK")
            //    {
            //        return "Cơ Sở Dữ Liệu đã tồn tại.";
            //    }
            //    string mdfFile = folderData + "\\" + database + "_DATA.mdf";
            //    string ldfFile = folderData + "\\" + database + "_Log.ldf";
                
            //    //neu thu muc ko ton tai
            //    if (!Directory.Exists(folderData))
            //    {
            //        Directory.CreateDirectory(folderData);
            //    }

            //    string result;
            //    try
            //    {

            //        // File.Delete(mdfFile);
            //        // File.Delete(ldfFile);

            //        if (!Directory.Exists(folderData))
            //        {
            //            Directory.CreateDirectory(folderData);
            //        }

            //        int i=0;
            //        while (File.Exists(mdfFile))
            //        {
            //            i++;
            //            mdfFile = folderData + "\\" + database+i+ "_DATA.mdf";
            //        }

            //        i = 0;
            //        while (File.Exists(ldfFile))
            //        {
            //            i++;
            //            ldfFile = folderData + "\\" + database +i+ "_Log.ldf";
            //        }
            //        File.Copy(Application.StartupPath + "\\data.mdf", mdfFile);
            //        File.Copy(Application.StartupPath + "\\data.ldf", ldfFile);
                    
            //        SqlConnection.ClearAllPools();
                   
            //        result = mysql.Attach(mdfFile, ldfFile, database);
            //        if (result != "OK")
            //        {
            //            Delete(mdfFile);
            //            Delete(ldfFile);
            //        }
            //    }

            //    catch (Exception ex)
            //    {
            //        return ex.Message;
            //    }

            //    return result;
            //}

            //public static string MakerExample(string server, string userid, string password, string database, string folderData,
            //                          bool authen)
            //{
            //    var mysql = new SqlHelper(server, "master", userid, password, authen);
            //    if (mysql.Exists(database) != "OK")
            //    {
            //        return "Cơ Sở Dữ Liệu đã tồn tại.";
            //    }
            //    var mdfFile = folderData + "\\" + database + "_DATA.mdf";
            //    var ldfFile = folderData + "\\" + database + "_Log.ldf";

            //    //neu thu muc ko ton tai
            //    if (!Directory.Exists(folderData))
            //    {
            //        Directory.CreateDirectory(folderData);
            //    }

            //    string result;
            //    try
            //    {

            //        // File.Delete(mdfFile);
            //        // File.Delete(ldfFile);

            //        if (!Directory.Exists(folderData))
            //        {
            //            Directory.CreateDirectory(folderData);
            //        }

            //        int i = 0;
            //        while (File.Exists(mdfFile))
            //        {
            //            i++;
            //            mdfFile = folderData + "\\" + database + i + "_DATA.mdf";
            //        }

            //        i = 0;
            //        while (File.Exists(ldfFile))
            //        {
            //            i++;
            //            ldfFile = folderData + "\\" + database + i + "_Log.ldf";
            //        }
            //        File.Copy(Application.StartupPath + "\\SaleExample.mdf", mdfFile);
            //        File.Copy(Application.StartupPath + "\\SaleExample.ldf", ldfFile);

            //        SqlConnection.ClearAllPools();

            //        result = mysql.Attach(mdfFile, ldfFile, database);
            //        if (result != "OK")
            //        {
            //            Delete(mdfFile);
            //            Delete(ldfFile);
            //        }
            //    }

            //    catch (Exception ex)
            //    {
            //        return ex.Message;
            //    }

            //    return result;
            //}

            //static string Delete(string path)
            //{
            //    var fi = new FileInfo(path);
            //    if (fi.Exists)
            //    {
            //        try
            //        {
            //            fi.Delete();
            //        }
            //        catch (Exception ex)
            //        {
            //            return ex.Message;
            //        }
            //    }
            //    return "OK";
            //}


            //public static string SimpleMaker(string server, string userid, string password, string database,
            //                                 string folderData, bool authen)
            //{
            //    string mdfFile = folderData + "\\" + database + "_DATA.mdf";
            //    string ldfFile = folderData + "\\" + database + "_Log.ldf";
            //    //neu thu muc ko ton tai
            //    string Result;
            //    try
            //    {
            //        try
            //        {
            //            File.Delete(mdfFile);
            //            File.Delete(ldfFile);
            //        }
            //        catch (Exception ex)
            //        {
            //        }
            //        if (Directory.Exists(folderData) == false)
            //        {
            //            Directory.CreateDirectory(folderData);
            //        }

            //        if ((File.Exists(mdfFile) == false) & (File.Exists(ldfFile) == false))
            //        {
            //            File.Copy(Application.StartupPath + "\\Simple.mdf", mdfFile);
            //            File.Copy(Application.StartupPath + "\\Simple.ldf", ldfFile);
            //        }
            //        else
            //        {
            //            return
            //                "Có thể cơ sở dữ liệu này đã tồn tại rồi\n\nHay do có tồn tại tập tin cơ sở dữ liệu trùng nhau\n\nVui lòng chọn đường dẫn khác hoặc đặt tên cơ sở dữ liệu khác.";
            //        }
            //        SqlConnection.ClearAllPools();
            //        var clsDatabase = new SqlHelper(server, "master", userid, password, authen);

            //        Result = clsDatabase.Attach(mdfFile, ldfFile, database);
            //        if (Result == "OK")
            //        {
            //            var sql = new SqlHelper(server, database, userid, password, authen);

            //        }
            //        else
            //        {
            //            File.Delete(mdfFile);
            //            File.Delete(ldfFile);
            //        }
            //    }

            //    catch (Exception ex)
            //    {
            //        return ex.Message;
            //    }


            //    return Result;
            //}

            public static string GetLastDrive()
            {
                var dList = Environment.GetLogicalDrives();
                var result = "C:";

                for (int z = dList.Length - 1; z > 0; z--)
                {
                    var drv = new DriveInfo(dList[z]);
                    if (drv.DriveType == DriveType.Fixed)
                    {
                        result = drv.Name;
                        return result;
                    }
                }
                return result;
            }

            //public static string AutoBackup()
            //{
            //    var drv = GetLastDrive();
            //    var sPath = drv + "Backup";
            //    var cls = new SqlHelper();
            //    var fileName = cls.Database + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + "." +
            //                      DateTime.Now.Hour + "." + DateTime.Now.Minute + "." + DateTime.Now.Second;
            //    if (Directory.Exists(sPath) == false)
            //    {
            //        Directory.CreateDirectory(sPath);
            //    }


            //    string result = Backup(sPath, fileName);
            //    if (result != "OK")
            //    {
            //        MessageBox.Show(@"Lỗi" + result, @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    }
            //    return result;
            //}

            private static string Backup(string path, string fileName)
            {
                if (Directory.Exists(path) == false)
                {
                    Directory.CreateDirectory(path);
                }
                var gs = new SqlHelper();
                string result;
                //   if (gs.Open() == "OK")
                {
                    var strSql = "BACKUP DATABASE " + SqlHelper.Database + " TO  DISK = N'" + path + "\\" + fileName +
                                    "' WITH  INIT ,  NOUNLOAD ,  NAME = N'" + fileName +
                                    "backup',  NOSKIP ,  STATS = 10,  NOFORMAT";
                    result = gs.ExecuteNonQuery(strSql, null, null);
                }
                return result;
            }
        }
    }


}