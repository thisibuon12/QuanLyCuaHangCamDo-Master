using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using Phan_Mem_Quan_Ly_Cam_Do.DoiTuong;
using DevExpress.XtraEditors;

namespace Phan_Mem_Quan_Ly_Cam_Do
{
    public partial class CauHinhCSDL : Form
    {
        public delegate void ThanhCongEventHander(object sender);

        public event ThanhCongEventHander ThanhCong;
        private void KetThucThanhCongEventHander()
        {
            if (ThanhCong != null)
            {
                ThanhCong(this);
            }
        }

        public delegate void BoEventHander(object sender);

        public event BoEventHander Bo;
        private void KetThucBoEventHander()
        {
            if (Bo != null)
            {
                Bo(this);
            }
        }

        public CauHinhCSDL()
        {
            InitializeComponent();

            var dt = new DataTable("CauHinhCSDL");
            dt.Columns.Add("MayChu");
            dt.Columns.Add("SuDungTaiKhoanWindows");
            dt.Columns.Add("TaiKhoanSQL");
            dt.Columns.Add("Password");
            dt.Columns.Add("CSDL");
            dt.Columns.Add("TenTiem");
            dt.Columns.Add("BienNhanCamDo");
            dt.Columns.Add("DiaChi");
            dt.Columns.Add("DienThoai");
            dt.Columns.Add("LaiSuat");
            dt.Columns.Add("ThoiHanQuyDinh");


            var fi = new FileInfo(Application.StartupPath + "\\CauHinhCSDL.xml");
            if (!fi.Exists) return;
            
            dt.ReadXml(Application.StartupPath + "\\CauHinhCSDL.xml");
            try
            {
                if (dt.Rows.Count > 0)
                {
                    //txtUserName.Text = MyEncryption.Decrypt(dt.Rows[0]["user"].ToString(), "963147", true);
                    //txtPassword.Text = MyEncryption.Decrypt(dt.Rows[0]["pass"].ToString(), "963147", true);

                    txtMayChuSQL.Text = dt.Rows[0]["MayChu"].ToString();
                    cbSuDungTaiKhoanWindows.Checked = (dt.Rows[0]["SuDungTaiKhoanWindows"] == DBNull.Value ? "" : dt.Rows[0]["SuDungTaiKhoanWindows"]).ToString().ToLower() == "true" ? true : false;
                    txtTaiKhoanSQL.Text = dt.Rows[0]["TaiKhoanSQL"].ToString();
                    txtPassword.Text = dt.Rows[0]["Password"].ToString();
                    txtTenCSDL.Text = dt.Rows[0]["CSDL"].ToString();
                    txtTenTiem.Text = dt.Rows[0]["TenTiem"].ToString();
                    txtBienNhanCamDo.Text = dt.Rows[0]["BienNhanCamDo"].ToString();
                    txtDiaChi.Text = dt.Rows[0]["DiaChi"].ToString();
                    txtDienThoai.Text = dt.Rows[0]["DienThoai"].ToString();

                    decimal laisuat = 0;
                    
                    try
                    {
                        laisuat = Convert.ToDecimal(dt.Rows[0]["LaiSuat"]);
                    }
                    catch (Exception ex)
                    {
                        laisuat = 0;
                    }

                    decimal thoihanquydinh = 0;

                    try
                    {
                        thoihanquydinh = Convert.ToDecimal(dt.Rows[0]["ThoiHanQuyDinh"]);
                    }
                    catch (Exception ex)
                    {
                        thoihanquydinh = 0;
                    }

                    txtLaiSuat.Value = laisuat;
                    txtThoiHanQuyDinh.Value = thoihanquydinh;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            //Data Source=.\SQLEXPRESS;Initial Catalog=QLK_quang_make;User ID=sa
            //Data Source=.\SQLEXPRESS;Initial Catalog=QLK_quang_make;Integrated Security=True

            if (!cbSuDungTaiKhoanWindows.Checked)
            {
                SqlHelper.ConnectionString = "Data Source=" + txtMayChuSQL.Text + ";Initial Catalog=" + txtTenCSDL.Text + ";User ID=" + txtTaiKhoanSQL.Text + ";Password=" + txtPassword.Text + ";";
            }
            else
            {
                SqlHelper.ConnectionString = "Data Source=" + txtMayChuSQL.Text + ";Initial Catalog=" + txtTenCSDL.Text + ";Integrated Security=True;";
            }

            //var mySql = new SqlHelper();

            SqlHelper.TenTiem = txtTenTiem.Text;
            SqlHelper.BienNhanCamDoBenB = txtBienNhanCamDo.Text;
            SqlHelper.DiaChi = txtDiaChi.Text;
            SqlHelper.DienThoai = txtDienThoai.Text;
            SqlHelper.LaiSuat = txtLaiSuat.Value;
            SqlHelper.Server = txtMayChuSQL.Text;
            SqlHelper.IsWindowsAuthentication = cbSuDungTaiKhoanWindows.Checked;
            SqlHelper.User = txtTaiKhoanSQL.Text;
            SqlHelper.Password = txtPassword.Text;
            SqlHelper.Database = txtTenCSDL.Text;
            SqlHelper.ThoiHanQuyDinh = txtThoiHanQuyDinh.Value;


            //this.Close();

            //FrmMain main = new FrmMain();
            //main.WindowState = FormWindowState.Maximized;
            //main.Show();

            if (Kiem_Tra_Ket_Noi(SqlHelper.ConnectionString))
            {
                KetThucThanhCongEventHander();
                Luu_Cau_Hinh();
                Close();
            }
            else
            {
                return;
            }

            
        }

        private void cbSuDungTaiKhoanWindows_CheckedChanged(object sender, EventArgs e)
        {
          //  txtTaiKhoanSQL.Properties.ReadOnly = cbSuDungTaiKhoanWindows.Checked;
            //txtPassword.Properties.ReadOnly = cbSuDungTaiKhoanWindows.Checked;
        }

        public bool Kiem_Tra_Ket_Noi(string ConnectionString)
        {
            var connection = new SqlConnection(ConnectionString);
            
            try
            {
                connection.Open();
                connection.Close();
            }
            catch
            {
                MessageBox.Show(this, "Không thể kết nối với máy chủ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            
            return true;
        }

        public void Luu_Cau_Hinh()
        {
            try 
            {
                var ds = new DataSet();
                var dt = new DataTable("CauHinhCSDL");

                dt.Columns.Add("MayChu");
                dt.Columns.Add("SuDungTaiKhoanWindows");
                dt.Columns.Add("TaiKhoanSQL");
                dt.Columns.Add("Password");
                dt.Columns.Add("CSDL");
                dt.Columns.Add("TenTiem");
                dt.Columns.Add("BienNhanCamDo");
                dt.Columns.Add("DiaChi");
                dt.Columns.Add("DienThoai");
                dt.Columns.Add("LaiSuat");
                dt.Columns.Add("ThoiHanQuyDinh");

                //dt.Rows[0]["MayChu"] = txtMayChuSQL.Text;
                //dt.Rows[0]["TaiKhoanSQL"] = txtTaiKhoanSQL.Text;
                //dt.Rows[0]["Password"] = txtPassword.Text;
                //dt.Rows[0]["CSDL"] = txtTenCSDL.Text;
                //dt.Rows[0]["BienNhanCamDo"] = txtBienNhanCamDo.Text;
                //dt.Rows[0]["DiaChi"] = txtDiaChi.Text;
                //dt.Rows[0]["LaiSuat"] = txtLaiSuat.Value;

                dt.Rows.Clear();
                dt.Rows.Add(
                    new object[] 
                    { 
                        txtMayChuSQL.Text,
                        cbSuDungTaiKhoanWindows.Checked.ToString(),
                        txtTaiKhoanSQL.Text,
                        txtPassword.Text,
                        txtTenCSDL.Text,
                        txtTenTiem.Text,
                        txtBienNhanCamDo.Text,
                        txtDiaChi.Text,
                        txtDienThoai.Text,
                        txtLaiSuat.Value,
                        txtThoiHanQuyDinh.Value
                    }
                    );

                ds.Tables.Add(dt);
                ds.WriteXml("CauHinhCSDL.xml");

            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CauHinhCSDL_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void CauHinhCSDL_Load(object sender, EventArgs e)
        {

        }
    }
}
