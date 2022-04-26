using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Data;

namespace Phan_Mem_Quan_Ly_Cam_Do.DoiTuong
{
    public class SqlHelper
    {
        //Data Source=.\SQLEXPRESS;Initial Catalog=QLK_quang_make;User ID=sa
        //Data Source=.\SQLEXPRESS;Initial Catalog=QLK_quang_make;Integrated Security=True
        //public static string connectionString = "Data Source=.\\SQLEXPRESS2005;Initial Catalog=QLK_quang_make;Integrated Security=SSPI;";

        private static string _server;

        public static string Server
        {
            get { return _server; }
            set { _server = value; }
        }
        private static bool _isWindowsAuthentication;

        public static bool IsWindowsAuthentication
        {
            get { return _isWindowsAuthentication; }
            set { _isWindowsAuthentication = value; }
        }
        private static string _user;

        public static string User
        {
            get { return _user; }
            set { _user = value; }
        }
        private static string _password;

        public static string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        private static string _database;

        public static string Database
        {
            get { return _database; }
            set { _database = value; }
        }

        private static string tenTiem = "";

        public static string TenTiem
        {
            get { return SqlHelper.tenTiem; }
            set { SqlHelper.tenTiem = value; }
        }

        public static string bienNhanCamDoBenB = "";

        public static string BienNhanCamDoBenB
        {
            get { return bienNhanCamDoBenB; }
            set { bienNhanCamDoBenB = value; }
        }

        private static string diaChi = "";

        public static string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }

        private static string dienThoai = "";

        public static string DienThoai
        {
            get { return dienThoai; }
            set { dienThoai = value; }
        }


        public static decimal laiSuat = 0;

        public static decimal LaiSuat
        {
            get { return laiSuat; }
            set { laiSuat = value; }
        }

        private static decimal thoiHanQuyDinh = 0;

        public static decimal ThoiHanQuyDinh
        {
            get { return thoiHanQuyDinh; }
            set { thoiHanQuyDinh = value; }
        }

        

        private static string connectionString = "";
        public static string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        public static string GenCode(string tableName, string columnName, string fKey, int length)
        {
            string Result;

            string sql =
            @"
                SELECT MAX(CAST(REPLACE([" + columnName + @"], '" + fKey + @"', '') AS BIGINT))
                FROM   [" + tableName + @"]
                WHERE  [" + columnName + @"] LIKE N'" + @fKey + @"%'
                       AND ISNUMERIC(REPLACE([" + columnName + "], '" + fKey + @"', '')) = 1
            ";

            object ob = ExecuteScalar(sql);
            Result = ob == null ? "0" : ob.ToString();
            if (fKey.Length != 0) Result = Result.Replace(fKey, "").Trim();
            int num = 0;
            if (Int32.TryParse(Result,out num))
            {
                num = Convert.ToInt32(Result);
            }
            num++;
            string format = num.ToString();
            if (format.Length < length)
            {
                while (format.Length < length)
                {
                    format = "0" + format;
                }
            }

            return fKey + format;
        }

        public static string ExecuteScalar(string sql)
        {
            string value = "";
            
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    value = cmd.ExecuteScalar().ToString();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return value;
        }

        public DataTable ExecuteDataTable(string sql, string[] mypara, object[] myvalue)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                try
                {
                    if (mypara != null && myvalue != null)
                    {
                        for (int i = 0; i < mypara.Length; i++)
                        {
                            cmd.Parameters.Add(new SqlParameter(mypara[i], myvalue[i]));
                        }
                    }
                        
                    conn.Open();
                    dt.Load(cmd.ExecuteReader());
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            return dt;
        }

        public string ExecuteNonQuery(string sql, string[] mypara, object[] myvalue)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;

                try
                {
                    for (int i = 0; i < mypara.Length; i++)
                    {
                        cmd.Parameters.Add(new SqlParameter(mypara[i], myvalue[i]));
                    }
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    return "OK";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return "NOT OK";
                }
            }
        }

        public string ExecuteNonQuery(SqlTransaction transaction, string sql, string[] mypara, object[] myvalue)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;

                try
                {
                    for (int i = 0; i < mypara.Length; i++)
                    {
                        cmd.Parameters.Add(new SqlParameter(mypara[i], myvalue[i]));
                    }
                    conn.Open();
                    cmd.Transaction = transaction;
                    cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();
                    conn.Close();

                    return "OK";
                }
                catch (Exception ex)
                {
                    cmd.Transaction.Rollback();
                    MessageBox.Show(ex.Message);
                    return "NOT OK";
                }
            }
        }
    }
}
