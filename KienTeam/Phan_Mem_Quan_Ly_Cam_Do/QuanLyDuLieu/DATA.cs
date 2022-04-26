using System;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Phan_Mem_Quan_Ly_Cam_Do.DoiTuong;

namespace Phan_Mem_Quan_Ly_Cam_Do.QuanLyDuLieu
{
	/// <summary>
	/// Project: 
	/// Generated Class for Table : DATA.
	/// Date: 14/08/2009
	/// Author: 
	/// </summary>
	public class DATA
	{
		#region Init
		private string m_Database;
		private string m_Version;
		private DateTime m_Created;
		private string m_Path;
		public DATA()
		{
			//
			// TODO: Add constructor logic here
			//
			 m_Database="";
			 m_Version="";
			 m_Created=DateTime.Now;
			 m_Path="";
		}
		public DATA(string Database,string Version,DateTime Created,string Path)
		{
			//
			// TODO: Add constructor logic here
			//
			 m_Database=Database;
			 m_Version=Version;
			 m_Created=Created;
			 m_Path=Path;
		}
		#endregion
		
		#region Property
		public string Database
		{
			get
			{
				return m_Database;
			}
			set
			{
				m_Database = value;
			}
		}
		public string Version
		{
			get
			{
				return m_Version;
			}
			set
			{
				m_Version = value;
			}
		}
		public DateTime Created
		{
			get
			{
				return m_Created;
			}
			set
			{
				m_Created = value;
			}
		}
		public string Path
		{
			get
			{
				return m_Path;
			}
			set
			{
				m_Path = value;
			}
		}
		public string ProductName
		{
			get
			{
				return "Class DATA";
			}
		}
		public string ProductVersion
		{
			get
			{
				return "1.0.0.0";
			}
		}
		#endregion
		
		#region Get

		public string NewID()
		{
			return SqlHelper.GenCode("DATA","DATAID","",4);
		}

        //public Boolean Exist(string Database)
        //{
        //    Boolean Result=false;
        //    string[] myPara={"@Database"};
        //    object[] myValue={Database};
        //    SqlHelper mySql=new SqlHelper();
        //    SqlDataReader myReader=mySql.ExecuteReader("DATA_Get",myPara,myValue);
        //    if (myReader !=null)
        //    {
        //            Result= myReader.HasRows;
        //        myReader.Close();
        //        mySql.Close();
        //        myReader = null;
        //    }
        //    return Result;
        //}

        //public string Get(string Database)
        //{
        //    string Result="";
        //    string[] myPara={"@Database"};
        //    object[] myValue={Database};
        //    SqlHelper mySql=new SqlHelper();
        //    SqlDataReader myReader=mySql.ExecuteReader("DATA_Get",myPara,myValue);
        //    if (myReader !=null)
        //    {
        //        while (myReader.Read())
        //        {
        //                m_Database =Convert.ToString(myReader["Database"]);
        //                m_Version =Convert.ToString(myReader["Version"]);
        //                m_Created =Convert.ToDateTime(myReader["Created"]);
        //                m_Path =Convert.ToString(myReader["Path"]);
        //                Result="OK";
        //        }
        //        myReader.Close();
        //        mySql.Close();
        //        myReader = null;
        //    }
        //    return Result;
        //}

        //public string Get(SqlConnection myConnection,string Database)
        //{
        //    string Result="";
        //    string[] myPara={"@Database"};
        //    object[] myValue={Database};
        //    SqlHelper mySql=new SqlHelper();
        //    SqlDataReader myReader=mySql.ExecuteReader(myConnection,"DATA_Get",myPara,myValue);
        //    if (myReader !=null)
        //    {
        //        while (myReader.Read())
        //        {
        //                m_Database =Convert.ToString(myReader["Database"]);
        //                m_Version =Convert.ToString(myReader["Version"]);
        //                m_Created =Convert.ToDateTime(myReader["Created"]);
        //                m_Path =Convert.ToString(myReader["Path"]);
        //                Result="OK";
        //        }
        //        myReader.Close();
        //        mySql.Close();
        //        myReader = null;
        //    }
        //    return Result;
        //}

        //public string Get(SqlTransaction myTransaction,string Database)
        //{
        //    string Result="";
        //    string[] myPara={"@Database"};
        //    object[] myValue={Database};
        //    SqlHelper mySql=new SqlHelper();
        //    SqlDataReader myReader=mySql.ExecuteReader(myTransaction,"DATA_Get",myPara,myValue);
        //    if (myReader !=null)
        //    {
        //        while (myReader.Read())
        //        {
        //                m_Database =Convert.ToString(myReader["Database"]);
        //                m_Version =Convert.ToString(myReader["Version"]);
        //                m_Created =Convert.ToDateTime(myReader["Created"]);
        //                m_Path =Convert.ToString(myReader["Path"]);
        //                Result="OK";
        //        }
        //        myReader.Close();
        //        mySql.Close();
        //        myReader = null;
        //    }
        //    return Result;
        //}
		#endregion
		

		#region Add
		public string Insert()
		{
			string[] myPara={"@Database","@Version","@Created","@Path"};
			object[] myValue={m_Database,m_Version,m_Created,m_Path};
			SqlHelper mySql=new SqlHelper();
			return mySql.ExecuteNonQuery("DATA_Insert",myPara,myValue);
		}
		public string Insert(SqlTransaction myTransaction)
		{
			string[] myPara={"@Database","@Version","@Created","@Path"};
			object[] myValue={m_Database,m_Version,m_Created,m_Path};
			SqlHelper mySql=new SqlHelper();
			return mySql.ExecuteNonQuery(myTransaction,"DATA_Insert",myPara,myValue);
		}
		public string Insert(string Database,string Version,DateTime Created,string Path)
		{
			string[] myPara={"@Database","@Version","@Created","@Path"};
			object[] myValue={Database,Version,Created,Path};
			SqlHelper mySql=new SqlHelper();
			return mySql.ExecuteNonQuery("DATA_Insert",myPara,myValue);
		}
        //public string Insert(SqlConnection myConnection,string Database,string Version,DateTime Created,string Path)
        //{
        //    string[] myPara={"@Database","@Version","@Created","@Path"};
        //    object[] myValue={Database,Version,Created,Path};
        //    SqlHelper mySql=new SqlHelper();
        //    return mySql.ExecuteNonQuery(myConnection,"DATA_Insert",myPara,myValue);
        //}
        //public string Insert(SqlTransaction myTransaction,string Database,string Version,DateTime Created,string Path)
        //{
        //    string[] myPara={"@Database","@Version","@Created","@Path"};
        //    object[] myValue={Database,Version,Created,Path};
        //    SqlHelper mySql=new SqlHelper();
        //    return mySql.ExecuteNonQuery(myTransaction,"DATA_Insert",myPara,myValue);
        //}
		#endregion
		

		#region Update
		public string Update()
		{
			string[] myPara={"@Database","@Version","@Created","@Path"};
			object[] myValue={m_Database,m_Version,m_Created,m_Path};
			SqlHelper mySql=new SqlHelper();
			return mySql.ExecuteNonQuery("DATA_Update",myPara,myValue);
		}
		public string Update(SqlTransaction myTransaction)
		{
			string[] myPara={"@Database","@Version","@Created","@Path"};
			object[] myValue={m_Database,m_Version,m_Created,m_Path};
			SqlHelper mySql=new SqlHelper();
			return mySql.ExecuteNonQuery(myTransaction,"DATA_Update",myPara,myValue);
		}
		public string Update(string Database,string Version,DateTime Created,string Path)
		{
			string[] myPara={"@Database","@Version","@Created","@Path"};
			object[] myValue={Database,Version,Created,Path};
			SqlHelper mySql=new SqlHelper();
			return mySql.ExecuteNonQuery("DATA_Update",myPara,myValue);
		}
        //public string Update(SqlConnection myConnection,string Database,string Version,DateTime Created,string Path)
        //{
        //    string[] myPara={"@Database","@Version","@Created","@Path"};
        //    object[] myValue={Database,Version,Created,Path};
        //    SqlHelper mySql=new SqlHelper();
        //    return mySql.ExecuteNonQuery(myConnection,"DATA_Update",myPara,myValue);
        //}
        //public string Update(SqlTransaction myTransaction,string Database,string Version,DateTime Created,string Path)
        //{
        //    string[] myPara={"@Database","@Version","@Created","@Path"};
        //    object[] myValue={Database,Version,Created,Path};
        //    SqlHelper mySql=new SqlHelper();
        //    return mySql.ExecuteNonQuery(myTransaction,"DATA_Update",myPara,myValue);
        //}
		#endregion
		

		#region Delete
		public string Delete()
		{
			string[] myPara={"@Database"};
			object[] myValue={m_Database};
			SqlHelper mySql=new SqlHelper();
			return mySql.ExecuteNonQuery("DATA_Delete",myPara,myValue);
		}
		public string Delete(string Database)
		{
			string[] myPara={"@Database"};
			object[] myValue={Database};
			SqlHelper mySql=new SqlHelper();
			return mySql.ExecuteNonQuery("DATA_Delete",myPara,myValue);
		}
        //public string Delete(SqlConnection myConnection,string Database)
        //{
        //    string[] myPara={"@Database"};
        //    object[] myValue={Database};
        //    SqlHelper mySql=new SqlHelper();
        //    return mySql.ExecuteNonQuery(myConnection,"DATA_Delete",myPara,myValue);
        //}
        //public string Delete(SqlTransaction myTransaction,string Database)
        //{
        //    string[] myPara={"@Database"};
        //    object[] myValue={Database};
        //    SqlHelper mySql=new SqlHelper();
        //    return mySql.ExecuteNonQuery(myTransaction,"DATA_Delete",myPara,myValue);
        //}
		#endregion
		

		#region GetList
		
        //public DataTable GetList()
        //{
        //    SqlHelper mySql=new SqlHelper();
        //    return mySql.ExecuteDataTable("DATA_GetList");
        //}
		#endregion
		

		
	}
}
