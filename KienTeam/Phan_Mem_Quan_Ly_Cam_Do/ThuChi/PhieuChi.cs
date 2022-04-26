using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Phan_Mem_Quan_Ly_Cam_Do.DoiTuong;

namespace Phan_Mem_Quan_Ly_Cam_Do.ThuChi
{
    public partial class PhieuChi : Form
    {
        public delegate void ReloadEventHander(object sender);

        public event ReloadEventHander Reload;
        private void RaiseReloadEventHander()
        {
            if (Reload != null)
            {
                Reload(this);
            }
        }

        DB_Quan_Ly_Cam_DoDataContext db = new DB_Quan_Ly_Cam_DoDataContext(SqlHelper.ConnectionString);
        string tinh_trang = "them";
        public PhieuChi()
        {
            InitializeComponent();
            bbiTaoMoi_ItemClick(this, null);
            tinh_trang = "them";
        }

        private decimal sotiencam;
        private DateTime ngayghisocamdo;
        private string machungtucamdo;
        private string tenkhachhang;
        private string socmnd;
        private string socamdo;

        public void Thiet_Lap(string ma_chung_tu_camdo, string so, string ten_khach_hang, string so_cmnd, decimal so_tien_cam, decimal lai_suat_thang, DateTime ngay_ghi_so_cam_do)
        {
            sotiencam = so_tien_cam;
            ngayghisocamdo = ngay_ghi_so_cam_do;
            machungtucamdo = ma_chung_tu_camdo;
            tenkhachhang = ten_khach_hang;
            socmnd = so_cmnd;
            socamdo = so;

            txtMa_Chung_Tu_Cam_Do.Text = machungtucamdo;
            txtSo.Text = so;
            txtTenKhachHang.Text = ten_khach_hang;
            txtSoCMND.Text = so_cmnd;
            txtNgayCamDo.DateTime = ngay_ghi_so_cam_do;

            txtMa_Chung_Tu_Cam_Do.Properties.ReadOnly = true;
            txtSo.Properties.ReadOnly = true;
            txtTenKhachHang.Properties.ReadOnly = true;

            //var tinhToan = new TinhToan();
            //decimal tien_lai = tinhToan.Tinh_Tien_Lai(so_tien_cam, lai_suat_thang, ngay_ghi_so_cam_do, txtNgayGhiSo.DateTime);
        }

        public PhieuChi(string ma)
        {
            InitializeComponent();
            bbiTaoMoi_ItemClick(this, null);

            var cttc = (from ct in db.CHUNG_TU_THU_CHIs
                        where ct.Ma == ma
                        select ct).FirstOrDefault();

            var ctcd = (from cd in db.CHUNG_TUs
                        where cd.Ma_Chung_Tu == cttc.Ma_Chung_Tu_Cam_Do
                        select cd).FirstOrDefault();

            if (ctcd != null)
            {
                txtMa_Chung_Tu_Cam_Do.Text = cttc.Ma_Chung_Tu_Cam_Do;
                txtSo.Text = ctcd.So;
                txtTenKhachHang.Text = ctcd.Ten_Khach_Hang;
                txtSoCMND.Text = ctcd.So_CMND;
                txtNgayCamDo.DateTime = ctcd.Ngay ?? DateTime.MinValue;
            }

            txtMa.Text = cttc.Ma;
            txtMa.Properties.ReadOnly = true;
            txtNgay.DateTime = cttc.Ngay;
            txtNgayGhiSo.DateTime = cttc.Ngay_Ghi_So ?? Convert.ToDateTime(null);
            txtMa_Chung_Tu_Cam_Do.Text = cttc.Ma_Chung_Tu_Cam_Do;
            cbLoai.SelectedText = cttc.Ten_Loai;
            txtSoTien.Value = cttc.So_Tien_Chi ?? 0;
            txtGhi_Chu.Text = cttc.Ghi_Chu;

            tinh_trang = "sua";
        }

        private void bbiDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void bbiTaoMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtMa.Text = SqlHelper.GenCode("CHUNG_TU_THU_CHI", "Ma", "PC", 1);
            txtMa.Properties.ReadOnly = false;
            txtMa_Chung_Tu_Cam_Do.Text = "";
            txtSo.Text = "";
            txtTenKhachHang.Text = "";
            txtSoTien.Value = 0;
            txtGhi_Chu.Text = "";
            txtNgay.DateTime = DateTime.Now;
            txtNgayGhiSo.DateTime = DateTime.Now;
            txtSoCMND.Text = "";
            txtNgayCamDo.EditValue = null;
            cbCapNhatSoCMND.Checked = false;
            tinh_trang = "them";
        }

        private void bbiLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Kiem_Tra())
            {
                return;
            }

            string phan_loai = "";
            string ma_phan_loai = "";
            switch (cbLoai.Text)
            {
                case "Chi tiền khách lấy thêm tiền":
                    phan_loai = "Lấy thêm tiền";
                    ma_phan_loai = "Them";
                    break;
                default:
                    phan_loai = "Chi khác";
                    ma_phan_loai = "Chi Khac";
                    break;
            }

            try
            {
                if (tinh_trang == "them")
                {
                    CHUNG_TU_THU_CHI cttc = new CHUNG_TU_THU_CHI();
                    cttc.Ma = txtMa.Text;
                    cttc.Ngay = txtNgay.DateTime;
                    cttc.Ngay_Ghi_So = txtNgayGhiSo.DateTime;
                    cttc.Ma_Chung_Tu_Cam_Do = txtMa_Chung_Tu_Cam_Do.Text;
                    cttc.Loai = "Chi";
                    cttc.Ma_Phan_Loai = ma_phan_loai;
                    cttc.Phan_Loai = phan_loai;
                    cttc.Ten_Loai = cbLoai.Text;
                    cttc.So_Tien_Thu = 0;
                    cttc.So_Tien_Chi = txtSoTien.Value;
                    cttc.Ghi_Chu = txtGhi_Chu.Text;
                    cttc.Sap_Xep = 0;

                    db.CHUNG_TU_THU_CHIs.InsertOnSubmit(cttc);
                }
                else
                {
                    var cttc = (from ct in db.CHUNG_TU_THU_CHIs
                               where ct.Ma == txtMa.Text
                               select ct).FirstOrDefault();

                    cttc.Ma = txtMa.Text;
                    cttc.Ngay = txtNgay.DateTime;
                    cttc.Ngay_Ghi_So = txtNgayGhiSo.DateTime;
                    cttc.Ma_Chung_Tu_Cam_Do = txtMa_Chung_Tu_Cam_Do.Text;
                    cttc.Loai = "Chi";
                    cttc.Ma_Phan_Loai = ma_phan_loai;
                    cttc.Phan_Loai = phan_loai;
                    cttc.Ten_Loai = cbLoai.Text;
                    cttc.So_Tien_Thu = 0;
                    cttc.So_Tien_Chi = txtSoTien.Value;
                    cttc.Ghi_Chu = txtGhi_Chu.Text;
                    cttc.Sap_Xep = 0;
                }

                db.SubmitChanges();
                RaiseReloadEventHander();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        bool Kiem_Tra()
        {
            if (string.IsNullOrEmpty(txtMa.Text))
            {
                MessageBox.Show("Mã không được rỗng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtMa_Chung_Tu_Cam_Do.Text) && cbLoai.Text != "Chi tiền khác")
            {
                MessageBox.Show("Mã chứng từ cầm đồ không được rỗng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtSoTien.Value <= 0)
            {
                MessageBox.Show("Số tiền phải lớn hơn 0.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void txtSoCMND_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSoCMND.Text))
            {
                if (socmnd != txtSoCMND.Text)
                {
                    cbCapNhatSoCMND.Checked = true;
                }
                else
                {
                    cbCapNhatSoCMND.Checked = false;
                }
            }
            else
            {
                cbCapNhatSoCMND.Checked = false;
            }
        }

        private void cbLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLoai.SelectedIndex == 0)
            {
                txtMa_Chung_Tu_Cam_Do.Text = machungtucamdo;
                txtTenKhachHang.Text = tenkhachhang;
                txtNgayCamDo.EditValue = ngayghisocamdo;
                txtSoCMND.Text = socmnd;
                txtSo.Text = socamdo;
            }
            else
            {
                txtMa_Chung_Tu_Cam_Do.Text = "";
                txtTenKhachHang.Text = "";
                txtNgayCamDo.EditValue = null;
                txtSoCMND.Text = "";
                txtSo.Text = "";
            }
        }
    }
}
