using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Phan_Mem_Quan_Ly_Cam_Do.DoiTuong;
using System.Data.SqlClient;

namespace Phan_Mem_Quan_Ly_Cam_Do.ThuChi
{
    public partial class PhieuThu : Form
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

        private decimal sotiencam;
        private DateTime ngayghisocamdo;
        private int loaithu;
        private string machungtucamdo;
        private string tenkhachhang;
        private string socmnd;
        private string socamdo;

        string tinh_trang = "them";
        public PhieuThu()
        {
            InitializeComponent();
            bbiTaoMoi_ItemClick(this, null);
            tinh_trang = "them";

            
        }

        public void Thiet_Lap(string ma_chung_tu_cam_do, string so, string ten_khach_hang, string so_cmnd, decimal so_tien_cam, decimal lai_suat_thang, DateTime ngay_ghi_so_cam_do ,int loai_thu)
        {
            machungtucamdo = ma_chung_tu_cam_do;
            socamdo = so;
            tenkhachhang = ten_khach_hang;
            socmnd = so_cmnd;
            sotiencam = so_tien_cam;
            ngayghisocamdo = ngay_ghi_so_cam_do;
            loaithu = loai_thu;

            txtMaChungTuCamDo.Text = ma_chung_tu_cam_do;
            txtSo.Text = so;
            txtTenKhachhang.Text = ten_khach_hang;
            txtSoCMND.Text = so_cmnd;
            txtLaiSuatThang.Value = lai_suat_thang;
            txtSoTienCam.Value = so_tien_cam;
            txtNgayCamDo.DateTime = ngay_ghi_so_cam_do;

            txtMaChungTuCamDo.Properties.ReadOnly = true;
            txtSo.Properties.ReadOnly = true;
            txtTenKhachhang.Properties.ReadOnly = true;

            var tinhToan = new TinhToan();
            //decimal tien_lai = tinhToan.Tinh_Tien_Lai(so_tien_cam, lai_suat_thang, ngay_ghi_so_cam_do, txtNgayGhiSo.DateTime);
            decimal tien_lai = tinhToan.Tinh_Tien_Lai_Theo_Chung_Tu(txtMaChungTuCamDo.Text, txtNgayGhiSo.DateTime);

            txtTienLai.Value = tien_lai;
            if (loai_thu == 0) // chuộc
            {
                txtSoTien.EditValue = so_tien_cam + tien_lai;
            }
            else if (loai_thu == 1) // khách trả tiền lời
            {
                txtSoTien.EditValue = tien_lai;
            }
            else if (loai_thu == 2) // khách trả bớt tiền
            {
                txtSoTien.EditValue = 0;
            }
            else
            {
                txtSoTien.EditValue = 0;
                lyThoiHanTinhLai.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lyLaiSuatThang.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            cbLoai.SelectedIndex = loai_thu;
        }

        public PhieuThu(string ma)
        {
            InitializeComponent();
            bbiTaoMoi_ItemClick(this, null);
            
            DB_Quan_Ly_Cam_DoDataContext db = new DB_Quan_Ly_Cam_DoDataContext(SqlHelper.ConnectionString);

            var cttc = (from ct in db.CHUNG_TU_THU_CHIs
                        where ct.Ma == ma
                        select ct).FirstOrDefault();

            int loai = 0;
            if (cttc.Ma_Phan_Loai == "Chuoc")
            {
                loai = 0;
            }
            else if (cttc.Ma_Phan_Loai == "Loi")
            {
                loai = 1;
            }
            else if (cttc.Ma_Phan_Loai == "Bot")
            {
                loai = 2;
            }
            else if (cttc.Ma_Phan_Loai == "Thu Khac")
            {
                loai = 3;
            }

            cbLoai.SelectedIndex = loai;

            txtMaChungTuCamDo.Properties.ReadOnly = true;
            txtSo.Properties.ReadOnly = true;
            txtTenKhachhang.Properties.ReadOnly = true;

            var ctcd = (from cd in db.CHUNG_TUs
                        where cd.Ma_Chung_Tu == cttc.Ma_Chung_Tu_Cam_Do
                        select cd).FirstOrDefault();

            if (ctcd != null)
            {
                txtSo.Text = ctcd.So;
                txtTenKhachhang.Text = ctcd.Ten_Khach_Hang;
                txtSoCMND.Text = ctcd.So_CMND;
                txtLaiSuatThang.Value = ctcd.Lai_Suat_Thang ?? 0;
                txtSoTienCam.Value = TinhToan.So_Tien_Cam(cttc.Ma_Chung_Tu_Cam_Do);
                txtNgayCamDo.DateTime = ctcd.Ngay ?? DateTime.MinValue;
            }

            txtMa.Text = cttc.Ma;
            txtMa.Properties.ReadOnly = true;
            txtNgay.DateTime = cttc.Ngay;
            txtNgayGhiSo.DateTime = cttc.Ngay_Ghi_So ?? Convert.ToDateTime(null);
            txtMaChungTuCamDo.Text = cttc.Ma_Chung_Tu_Cam_Do;

            if (cttc.Ma_Phan_Loai == "Thu Khac")
            {
                txtSoTienCam.Value = cttc.So_Tien_Cam ?? 0;
            }
            txtTienLai.Value = cttc.Tien_Lai ?? 0;
            txtSoTien.Value = cttc.So_Tien_Thu ?? 0;
            txtGhi_Chu.Text = cttc.Ghi_Chu;

            machungtucamdo = txtMaChungTuCamDo.Text;
            socamdo = txtSo.Text;
            ngayghisocamdo = txtNgayCamDo.DateTime;
            socmnd = txtSoCMND.Text;
            tenkhachhang = txtTenKhachhang.Text;

            tinh_trang = "sua";
        }

        private void bbiDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
            
        }

        private void bbiTaoMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtMa.Text = SqlHelper.GenCode("CHUNG_TU_THU_CHI", "Ma", "PT", 1);
            txtMa.Properties.ReadOnly = false;
            txtMaChungTuCamDo.Text = "";
            txtTenKhachhang.Text = "";
            txtSoCMND.Text = "";
            txtSoTien.Value = 0;
            txtGhi_Chu.Text = "";
            txtNgay.DateTime = DateTime.Now;
            txtNgayGhiSo.DateTime = DateTime.Now;
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
                case "Thu tiền khách chuộc đồ":
                    phan_loai = "Chuộc";
                    ma_phan_loai = "Chuoc";
                    break;
                case "Thu tiền khách trả tiền lời":
                    phan_loai = "Trả tiền lời";
                    ma_phan_loai = "Loi";
                    break;
                case "Thu tiền khách trả bớt tiền":
                    phan_loai = "Trả bớt tiền";
                    ma_phan_loai = "Bot";
                    break;
                default:
                    phan_loai = "Thu khác";
                    ma_phan_loai = "Thu Khac";
                    break;
            }

            try
            {
                DB_Quan_Ly_Cam_DoDataContext db = new DB_Quan_Ly_Cam_DoDataContext(SqlHelper.ConnectionString);
                if (tinh_trang == "them")
                {
                    CHUNG_TU_THU_CHI cttc = new CHUNG_TU_THU_CHI();
                    cttc.Ma = txtMa.Text;
                    cttc.Ngay = txtNgay.DateTime;
                    cttc.Ngay_Ghi_So = txtNgayGhiSo.DateTime;
                    cttc.Ma_Chung_Tu_Cam_Do = txtMaChungTuCamDo.Text;
                    cttc.Loai = "Thu";
                    cttc.Ma_Phan_Loai = ma_phan_loai;
                    cttc.Phan_Loai = phan_loai;
                    cttc.Ten_Loai = cbLoai.Text;
                    cttc.So_Tien_Cam = txtSoTienCam.Value;
                    cttc.Tien_Lai = txtTienLai.Value;
                    cttc.So_Tien_Thu = txtSoTien.Value;
                    cttc.So_Tien_Chi = 0;
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
                    cttc.Ma_Chung_Tu_Cam_Do = txtMaChungTuCamDo.Text;
                    cttc.Loai = "Thu";
                    cttc.Ma_Phan_Loai = ma_phan_loai;
                    cttc.Phan_Loai = phan_loai;
                    cttc.Ten_Loai = cbLoai.Text;
                    cttc.So_Tien_Cam = txtSoTienCam.Value;
                    cttc.Tien_Lai = txtTienLai.Value;
                    cttc.So_Tien_Thu = txtSoTien.Value;
                    cttc.So_Tien_Chi = 0;
                    cttc.Ghi_Chu = txtGhi_Chu.Text;
                    cttc.Sap_Xep = 0;
                }

                db.SubmitChanges();

                CapNhatCMNDPhieuCamDo();

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
            if (!txtMa.Properties.ReadOnly)
            {
                DB_Quan_Ly_Cam_DoDataContext db = new DB_Quan_Ly_Cam_DoDataContext(SqlHelper.ConnectionString);

                var cttc = (from ct in db.CHUNG_TU_THU_CHIs
                            where ct.Ma == txtMa.Text
                            select ct);

                if (cttc.Count() > 0)
                {
                    if (MessageBox.Show("Mã trùng. Bạn có muốn đổi mã khác hay không ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        txtMa.Text = SqlHelper.GenCode("CHUNG_TU_THU_CHI", "Ma", "PT", 1);
                    }
                    return false;
                }
            }

            if (string.IsNullOrEmpty(txtMa.Text))
            {
                MessageBox.Show("Mã không được rỗng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtMaChungTuCamDo.Text) && cbLoai.Text != "Thu tiền khác")
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

        private void cbThoiHanThuTien_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sothang = cbThoiHanTinhLai.SelectedIndex - 2;
            if (sothang > 0)
            {
                decimal so_tien = (sotiencam / 100) * txtLaiSuatThang.Value * sothang;
                string tien_tam = String.Format("{0:##,##0}", so_tien);
                so_tien = Convert.ToDecimal(tien_tam) - Convert.ToDecimal(tien_tam) % Convert.ToDecimal(Math.Pow(10, 3));
                txtNgayGhiSo.DateTime = ngayghisocamdo.AddMonths(sothang);
                if (cbLoai.SelectedIndex == 0)
                {
                    txtSoTien.Value = sotiencam + so_tien;
                }
                else
                {
                    txtSoTien.Value = so_tien;
                }
                txtTienLai.Value = so_tien;
            }
            else if(sothang == -2)
            {
                if (cbLoai.SelectedIndex != 3)
                {
                    txtNgay.DateTime = DateTime.Now;
                    txtNgayGhiSo.DateTime = DateTime.Now;
                }

                var tinh_toan = new TinhToan();
                //decimal so_tien = tinh_toan.Tinh_Tien_Lai(sotiencam, txtLaiSuatThang.Value, ngayghisocamdo, txtNgayGhiSo.DateTime);
                decimal so_tien = tinh_toan.Tinh_Tien_Lai_Theo_Chung_Tu(txtMaChungTuCamDo.Text, txtNgayGhiSo.DateTime);
                if (cbLoai.SelectedIndex == 0)
                {
                    txtSoTien.Value = sotiencam + so_tien;
                }
                else
                {
                    txtSoTien.Value = so_tien;
                }
                txtTienLai.Value = so_tien;
            }
            else if (sothang == -1)
            {
                var tinh_toan = new TinhToan();
                //decimal so_tien = tinh_toan.Tinh_Tien_Lai(sotiencam, txtLaiSuatThang.Value, ngayghisocamdo, txtNgayGhiSo.DateTime);
                decimal so_tien = tinh_toan.Tinh_Tien_Lai_Theo_Chung_Tu(txtMaChungTuCamDo.Text, txtNgayGhiSo.DateTime);
                if (cbLoai.SelectedIndex == 0)
                {
                    txtSoTien.Value = sotiencam + so_tien;
                }
                else
                {
                    txtSoTien.Value = so_tien;
                }
                txtTienLai.Value = so_tien;
            }
            else if (sothang == 0)
            {
                var tinh_toan = new TinhToan();
                //decimal so_tien = tinh_toan.Tinh_Tien_Lai(sotiencam, txtLaiSuatThang.Value, ngayghisocamdo, txtNgay.DateTime);
                decimal so_tien = tinh_toan.Tinh_Tien_Lai_Theo_Chung_Tu(txtMaChungTuCamDo.Text, txtNgayGhiSo.DateTime);
                if (cbLoai.SelectedIndex == 0)
                {
                    txtSoTien.Value = sotiencam + so_tien;
                }
                else
                {
                    txtSoTien.Value = so_tien;
                }
                txtTienLai.Value = so_tien;
            }
            
        }

        private void cbLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbThoiHanThuTien_SelectedIndexChanged(this, null);
            if (cbLoai.SelectedIndex == 3)
            {
                txtSoTienCam.Value = 0;
                txtSoTienCam.Properties.ReadOnly = false;
                txtTienLai.Value = 0;
                txtTienLai.Properties.ReadOnly = false;

                txtMaChungTuCamDo.Text = "";
                txtSo.Text = "";
                txtNgayCamDo.EditValue = null;
                txtSoCMND.Text = "";
                txtTenKhachhang.Text = "";
            }
            else
            {
                txtSoTienCam.Value = sotiencam;
                txtSoTienCam.Properties.ReadOnly = true;

                txtMaChungTuCamDo.Text = machungtucamdo;
                txtSo.Text = socamdo;
                txtNgayCamDo.EditValue = ngayghisocamdo;
                txtSoCMND.Text = socmnd;
                txtTenKhachhang.Text = tenkhachhang;
                txtTienLai.Properties.ReadOnly = false;

                if (cbLoai.SelectedIndex == 2)
                {
                    txtTienLai.Value = 0;
                    txtTienLai.Properties.ReadOnly = true;
                }
            }
        }

        public void CapNhatCMNDPhieuCamDo()
        {
            if (cbCapNhatCMND.Checked && !string.IsNullOrEmpty(txtSoCMND.Text.Trim()))
            {
                try
                {
                    DB_Quan_Ly_Cam_DoDataContext db = new DB_Quan_Ly_Cam_DoDataContext(SqlHelper.ConnectionString);

                    var chung_tu_cam_do = (from ct in db.CHUNG_TUs
                                           where ct.Ma_Chung_Tu == txtMaChungTuCamDo.Text
                                           select ct).First();

                    chung_tu_cam_do.So_CMND = txtSoCMND.Text;
                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void txtSoCMND_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSoCMND.Text))
            {
                if (socmnd != txtSoCMND.Text)
                {
                    cbCapNhatCMND.Checked = true;
                }
                else
                {
                    cbCapNhatCMND.Checked = false;
                }
            }
            else
            {
                cbCapNhatCMND.Checked = false;
            }
            
        }

        private void txtSoTienCam_EditValueChanged(object sender, EventArgs e)
        {
            TinhTongTien();
        }

        private void txtTienLai_EditValueChanged(object sender, EventArgs e)
        {
            TinhTongTien();
        }

        private void TinhTongTien()
        {
            var loai = cbLoai.SelectedIndex;
            txtSoTien.Value = ((loai == 0 || loai == 3) ? txtSoTienCam.Value : 0) + txtTienLai.Value;
        }

        private void txtTienLai_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag.ToString() == "TinhLai")
            {
                cbThoiHanThuTien_SelectedIndexChanged(this, null);
            }
        }

        private void bbiChiTiet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var chitiet = new frmChiTietTinhTienLoi(txtMaChungTuCamDo.Text, txtNgayGhiSo.DateTime);
            chitiet.ShowDialog();
        }

        private void txtNgayGhiSo_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag.ToString() == "TinhLai")
            {
                cbThoiHanTinhLai.SelectedIndex = 1;
                cbThoiHanThuTien_SelectedIndexChanged(this, null);
            }
        }

        private void txtNgay_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag.ToString() == "TinhLai")
            {
                cbThoiHanTinhLai.SelectedIndex = 0;
                cbThoiHanThuTien_SelectedIndexChanged(this, null);
            }
        }
    }
}
