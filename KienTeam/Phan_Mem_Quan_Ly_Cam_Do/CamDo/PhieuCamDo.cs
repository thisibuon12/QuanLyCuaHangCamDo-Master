using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Phan_Mem_Quan_Ly_Cam_Do.DoiTuong;
using DevExpress.XtraGrid.Views.Grid;
using Phan_Mem_Quan_Ly_Cam_Do.CamDo.PhieuIn;
using DevExpress.XtraReports.UI;
using Phan_Mem_Quan_Ly_Cam_Do.CamDo.DS.dsCamDoTableAdapters;
using Phan_Mem_Quan_Ly_Cam_Do.CamDo.DS;
using DevExpress.XtraEditors;


namespace Phan_Mem_Quan_Ly_Cam_Do.CamDo
{
    public partial class PhieuCamDo : Form
    {

        AutoCompleteStringCollection mangDanhSachHangHoa = new AutoCompleteStringCollection();

        public delegate void ReloadEventHander(object sender);
        public event ReloadEventHander Reload;
        private void RaiseReloadEventHander()
        {
            if (Reload != null)
            {
                Reload(this);
            }
        }

        bool InPhieu = false;

        DB_Quan_Ly_Cam_DoDataContext db;
        string tinh_trang = "them";
        public PhieuCamDo()
        {
            InitializeComponent();

            Hang_Hoa();

            db = new DB_Quan_Ly_Cam_DoDataContext(SqlHelper.ConnectionString);
            bbiTaoMoi_ItemClick(this, null);
            _mColumn = new Column();
            _mColumn = Column.None;
            tinh_trang = "them";

            bm.SetPopupContextMenu(gcList, pm);

            gbList_HangHoa.ShownEditor += (s, e) => 
            {
                var view = s as GridView;
                view.ActiveEditor.DoubleClick += Chon_Hang_Hoa;
            };

            NapDanhSachKhachHang();
            NapDanhSachDiaChi();
            NapDanhSachHangHoa();
        }

        private void NapDanhSachHangHoa()
        {
            foreach (DataRow dr in dsCamDo.DANH_SACH_HANG_HOA.Rows)
            {
                mangDanhSachHangHoa.Add(dr["Ten_Tai_San"].ToString());
                rptTenTaiSan.Items.Add(dr["Ten_Tai_San"].ToString());
            }
        }

        private void NapDanhSachDiaChi()
        {
            var dtDanhSachDiaChi = new Phan_Mem_Quan_Ly_Cam_Do.CamDo.DS.dsCamDo.DANH_SACH_DIA_CHIDataTable();

            var adapterDiaChi = new DANH_SACH_DIA_CHITableAdapter();
            adapterDiaChi.Connection.ConnectionString = SqlHelper.ConnectionString;
            adapterDiaChi.ClearBeforeFill = true;
            adapterDiaChi.Fill(dtDanhSachDiaChi);

            AutoCompleteStringCollection mangDanhSachDiaChi = new AutoCompleteStringCollection();

            foreach (DataRow dr in dtDanhSachDiaChi.Rows)
            {
                mangDanhSachDiaChi.Add(dr["Dia_Chi"].ToString());
            }

            var txtDiaChi_AutoComplete = txtDiaChi.MaskBox;
            txtDiaChi_AutoComplete.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtDiaChi_AutoComplete.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtDiaChi_AutoComplete.AutoCompleteCustomSource = mangDanhSachDiaChi;
        }

        private void NapDanhSachKhachHang()
        {
            var dtDanhSachKhachHang = new Phan_Mem_Quan_Ly_Cam_Do.CamDo.DS.dsCamDo.DANH_SACH_KHACH_HANGDataTable();

            var adapterKhachHang = new DANH_SACH_KHACH_HANGTableAdapter();
            adapterKhachHang.Connection.ConnectionString = SqlHelper.ConnectionString;
            adapterKhachHang.ClearBeforeFill = true;
            adapterKhachHang.Fill(dtDanhSachKhachHang);

            AutoCompleteStringCollection mangDanhSachKhachHang = new AutoCompleteStringCollection();

            foreach (DataRow dr in dtDanhSachKhachHang.Rows)
            {
                mangDanhSachKhachHang.Add(dr["Ten_Khach_Hang"].ToString());
            }

            var txtKhacHang_AutoComplete = txtKhachHang.MaskBox;

            txtKhacHang_AutoComplete.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtKhacHang_AutoComplete.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtKhacHang_AutoComplete.AutoCompleteCustomSource = mangDanhSachKhachHang;
        }

        public void Lap_Giay_Moi(string machungtucamdo)
        {
            //lcChungTuGoc.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            //lcTienLaiCu.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            var ct = (from c in db.CHUNG_TUs
                      where c.Ma_Chung_Tu == machungtucamdo
                      select c).FirstOrDefault();

            txtMaChungTu.Text = "";
            txtMaChungTu.Properties.ReadOnly = false;
            txtMaChungTu.Text = SqlHelper.GenCode("CHUNG_TU", "Ma_Chung_Tu", "CD", 1);

            txtSo.Text = ct.So;
            txtLien.Text = ct.Lien;
            txtNgay.EditValue = DateTime.Now;
            txtKhachHang.Text = ct.Ten_Khach_Hang;
            txtCMNDSo.Text = ct.So_CMND;
            txtNgayCap.Text = ct.Ngay_Cap_CMND;
            txtNoiCap.Text = ct.Noi_Cap;
            txtDiaChi.Text = ct.Dia_Chi;
            txtSoDienThoai.Text = ct.So_Dien_Thoai;
            txtChuTiem.Text = ct.Chu_Tiem;
            txtSoTienCam.Value = ct.So_Tien_Cam ?? 0;
            txtTuNgay.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Now);
            txtDenNgay.Text = "";
            txtGhiChu.Text = ct.Ghi_Chu;

            //txtChungTuGoc.Text = machungtucamdo;
            //txtTienLaiCu.Value = 0;

            var dt = new Phan_Mem_Quan_Ly_Cam_Do.CamDo.DS.dsCamDo.CHUNG_TU_CHI_TIETDataTable();
             
            cHUNG_TU_CHI_TIETTableAdapter.Connection.ConnectionString = SqlHelper.ConnectionString;
            cHUNG_TU_CHI_TIETTableAdapter.ClearBeforeFill = true;
            cHUNG_TU_CHI_TIETTableAdapter.Fill(dt, machungtucamdo);
            //cHUNG_TU_CHI_TIETTableAdapter.Fill(dsCamDo.CHUNG_TU_CHI_TIET, txtMaChungTu.Text);

            foreach (DataRow dr in dt.Rows)
            {
                dsCamDo.CHUNG_TU_CHI_TIET.AddCHUNG_TU_CHI_TIETRow(
                    Guid.NewGuid(),
                    "",
                    dr[colTen_Tai_San.FieldName].ToString(),
                    dr[colLoai_Vang.FieldName].ToString(),
                    dr[colTrong_Luong.FieldName].ToString(),
                    dr[colChuan_Do.FieldName].ToString(),
                    Convert.ToDecimal(dr[colGia_Tri_Vat_Cam.FieldName]),
                    0,
                    0,
                    0,
                    0
                    );
            }
        }

        private void Chon_Hang_Hoa(object sender, EventArgs e)
        {
            dsCamDo.CHUNG_TU_CHI_TIET.AddCHUNG_TU_CHI_TIETRow(
                Guid.NewGuid(),
                txtMaChungTu.Text,
                gbList_HangHoa.GetFocusedRowCellValue(colTen_Tai_San1).ToString(),
                "",
                "",
                "",
                0,
                0,
                0,
                0,
                0
                );
        }

        public PhieuCamDo(string ma)
        {
            InitializeComponent();

            Hang_Hoa();

            db = new DB_Quan_Ly_Cam_DoDataContext(SqlHelper.ConnectionString);
            bbiTaoMoi_ItemClick(this, null);
            _mColumn = new Column();
            _mColumn = Column.None;
            tinh_trang = "sua";

            bm.SetPopupContextMenu(gcList, pm);

            var ct = (from c in db.CHUNG_TUs
                      where c.Ma_Chung_Tu == ma
                      select c).FirstOrDefault();

            txtMaChungTu.Text = ct.Ma_Chung_Tu;
            txtMaChungTu.Properties.ReadOnly = true;
            txtSo.Text = ct.So;
            txtNgay.EditValue = ct.Ngay;
            txtKhachHang.Text = ct.Ten_Khach_Hang;
            txtCMNDSo.Text = ct.So_CMND;
            txtNgayCap.Text = ct.Ngay_Cap_CMND;
            txtNoiCap.Text = ct.Noi_Cap;
            txtNgaySinh.Text = ct.Ngay_Sinh;
            txtDiaChi.Text = ct.Dia_Chi;
            txtSoDienThoai.Text = ct.So_Dien_Thoai;
            txtChuTiem.Text = ct.Chu_Tiem;
            txtSoTienCam.Value = ct.So_Tien_Cam ?? 0;
            txtTuNgay.Text = ct.Tu_Ngay;
            txtDenNgay.Text = ct.Den_Ngay;
            txtGhiChu.Text = ct.Ghi_Chu;
            //txtChungTuGoc.Text = ct.Chung_Tu_Goc;
            //txtTienLaiCu.Value = ct.Tien_Lai_Cu ?? 0;

            cHUNG_TU_CHI_TIETTableAdapter.Connection.ConnectionString = SqlHelper.ConnectionString;
            cHUNG_TU_CHI_TIETTableAdapter.ClearBeforeFill = true;
            cHUNG_TU_CHI_TIETTableAdapter.Fill(dsCamDo.CHUNG_TU_CHI_TIET, txtMaChungTu.Text);

            gbList_HangHoa.ShownEditor += (s, e) =>
            {
                var view = s as GridView;
                view.ActiveEditor.DoubleClick += Chon_Hang_Hoa;
            };
        }

        private void bbiDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void bbiTaoMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tinh_trang = "them";
            txtKhachHang.Text = null;

            txtMaChungTu.Text = "";
            txtMaChungTu.Properties.ReadOnly = false;
            txtMaChungTu.Text = SqlHelper.GenCode("CHUNG_TU", "Ma_Chung_Tu", "CD", 1);
            
            txtNgay.DateTime = DateTime.Now;
            txtSoTienCam.Value = 0;

            txtSo.Text = SqlHelper.GenCode("CHUNG_TU", "So", "", 1);
            txtLien.Text = "2";
            txtKhachHang.Text = "";
            txtCMNDSo.Text = "";
            txtNgayCap.Text = "";
            txtNoiCap.Text = "";
            txtNgaySinh.Text = "";
            txtSoDienThoai.Text = "";
            txtDiaChi.Text = "";
            txtTuNgay.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Now);
            txtDenNgay.Text = SqlHelper.ThoiHanQuyDinh == 0 ? "" : String.Format("{0:dd/MM/yyyy}", DateTime.Now.AddMonths(Convert.ToInt32(SqlHelper.ThoiHanQuyDinh)));
            txtLaiSuatNgay.Value = (decimal)(SqlHelper.LaiSuat / 30);
            txtLaiSuatThang.Value = SqlHelper.LaiSuat;
            txtGhiChu.Text = "";

            txtChuTiem.Text = SqlHelper.BienNhanCamDoBenB;

            dsCamDo.CHUNG_TU_CHI_TIET.Rows.Clear();

            Hang_Hoa();

            
        }

        private void gbList_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            int rowIndex = e.RowHandle;
            if (rowIndex >= 0)
            {
                rowIndex++;
                e.Info.DisplayText = rowIndex.ToString();
            }
        }

        private enum Column
        {
            None = 0,
            Gia_Tri_Vat_Cam = 1,
            Trong_Luong_18k = 2,
            Trong_Luong_24k = 3,
            Trong_Luong_Khac = 4,
            Lock = 5,
        }

        Column _mColumn;

        private void gbList_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            gbList.ClearColumnErrors();
            gbList.UpdateCurrentRow();
            if (_mColumn == Column.Lock) return;

            if (_mColumn == Column.None)
            {
                if (e.Column.FieldName == colGia_Tri_Vat_Cam.FieldName)
                {
                    _mColumn = Column.Gia_Tri_Vat_Cam;
                }
                else if (e.Column.FieldName == colTrong_Luong_Vang_18k.FieldName)
                {
                    _mColumn = Column.Trong_Luong_18k;
                }
                else if (e.Column.FieldName == colTrong_Luong_Vang_24k.FieldName)
                {
                    _mColumn = Column.Trong_Luong_24k;
                }
                else if (e.Column.FieldName == colTrong_Luong_Khac.FieldName)
                {
                    _mColumn = Column.Trong_Luong_Khac;
                }
            }

            switch (_mColumn)
            {
                case Column.None:
                    return;
                case Column.Gia_Tri_Vat_Cam:
                    {
                        _mColumn = Column.Lock;
                        Tinh_Thanh_Tien();
                        _mColumn = Column.None;
                        break;
                    }
                case Column.Trong_Luong_18k:
                    {
                        _mColumn = Column.Lock;
                        gbList.SetFocusedRowCellValue(colLoai_Vang, "18k");
                        DocTrongLuong(Convert.ToDecimal(e.Value == DBNull.Value ? 0 : e.Value));
                        _mColumn = Column.None;
                        break;
                    }
                case Column.Trong_Luong_24k:
                    {
                        _mColumn = Column.Lock;
                        gbList.SetFocusedRowCellValue(colLoai_Vang, "24k");
                        DocTrongLuong(Convert.ToDecimal(e.Value == DBNull.Value ? 0 : e.Value));
                        _mColumn = Column.None;
                        break;
                    }
                case Column.Trong_Luong_Khac:
                    {
                        _mColumn = Column.Lock;
                        gbList.SetFocusedRowCellValue(colLoai_Vang, "Khác");
                        DocTrongLuong(Convert.ToDecimal(e.Value == DBNull.Value ? 0 : e.Value));
                        _mColumn = Column.None;
                        break;
                    }
            }
            gbList.ClearColumnErrors();
            _mColumn = Column.None;
        }

        private void DocTrongLuong(decimal trongluong)
        {
            gbList.SetFocusedRowCellValue(colTrong_Luong, TinhToan.docTrongLuong(trongluong));
        }

        private void txtChietKhauPhanTram_EditValueChanged(object sender, EventArgs e)
        {
            Tinh_Thanh_Tien();
        }

        void Tinh_Thanh_Tien()
        {
            decimal tong_tien = Convert.ToDecimal(colGia_Tri_Vat_Cam.SummaryItem.SummaryValue);


            txtSoTienCam.Value = tong_tien;
        }

        private void txtVATPhanTram_EditValueChanged(object sender, EventArgs e)
        {
            Tinh_Thanh_Tien();
        }

        private void bbiLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gbList.FocusedRowHandle += 1;
            gbList.UpdateCurrentRow();

            if (!Kiem_Tra())
            {
                return;
            }

            DB_Quan_Ly_Cam_DoDataContext database = new DB_Quan_Ly_Cam_DoDataContext(SqlHelper.ConnectionString);
            try
            {
                database.Connection.Open();
                System.Data.Common.DbTransaction transaction = database.Connection.BeginTransaction();
                database.Transaction = transaction;

                if (tinh_trang == "them")
                {
                    CHUNG_TU chung_tu = new CHUNG_TU
                    {
                        Ma_Chung_Tu = txtMaChungTu.Text,
                        So = txtSo.Text,
                        Lien = txtLien.Text,
                        Ngay = txtNgay.DateTime,
                        Ten_Khach_Hang = txtKhachHang.Text,
                        So_CMND = txtCMNDSo.Text,
                        Ngay_Cap_CMND = txtNgayCap.Text,
                        Noi_Cap = txtNoiCap.Text,
                        Ngay_Sinh = txtNgaySinh.Text,
                        Dia_Chi = txtDiaChi.Text,
                        So_Dien_Thoai = txtSoDienThoai.Text,
                        Chu_Tiem = txtChuTiem.Text,
                        So_Tien_Cam = txtSoTienCam.Value,
                        Tu_Ngay = txtTuNgay.Text,
                        Den_Ngay = txtDenNgay.Text,
                        Lai_Suat_Ngay = txtLaiSuatNgay.Value,
                        Lai_Suat_Thang = txtLaiSuatThang.Value,
                        Da_Chuoc = false,
                        Ghi_Chu = txtGhiChu.Text,
                        //Tien_Lai_Cu = txtTienLaiCu.Value,
                        //Chung_Tu_Goc = txtChungTuGoc.Text,
                        Da_Lam_Lai_Giay = false,
                        Mat_Giay = false,
                        Sap_Xep = 0
                    };
                    database.CHUNG_TUs.InsertOnSubmit(chung_tu);

                }
                else
                {
                    var chung_tu = (from ct in database.CHUNG_TUs
                                    where ct.Ma_Chung_Tu == txtMaChungTu.Text
                                    select ct).FirstOrDefault();

                    chung_tu.Ma_Chung_Tu = txtMaChungTu.Text;
                    chung_tu.So = txtSo.Text;
                    chung_tu.Lien = txtLien.Text;
                    chung_tu.Ngay = txtNgay.DateTime;
                    chung_tu.Ten_Khach_Hang = txtKhachHang.Text;
                    chung_tu.So_CMND = txtCMNDSo.Text;
                    chung_tu.Ngay_Cap_CMND = txtNgayCap.Text;
                    chung_tu.Noi_Cap = txtNoiCap.Text;
                    chung_tu.Ngay_Sinh = txtNgaySinh.Text;
                    chung_tu.Dia_Chi = txtDiaChi.Text;
                    chung_tu.So_Dien_Thoai = txtSoDienThoai.Text;
                    chung_tu.Chu_Tiem = txtChuTiem.Text;
                    chung_tu.So_Tien_Cam = txtSoTienCam.Value;
                    chung_tu.Tu_Ngay = txtTuNgay.Text;
                    chung_tu.Den_Ngay = txtDenNgay.Text;
                    chung_tu.Lai_Suat_Ngay = txtLaiSuatNgay.Value;
                    chung_tu.Lai_Suat_Thang = txtLaiSuatThang.Value;
                    chung_tu.Da_Chuoc = false;
                    chung_tu.Ghi_Chu = txtGhiChu.Text;
                    //chung_tu.Tien_Lai_Cu = txtTienLaiCu.Value;
                    //chung_tu.Chung_Tu_Goc = txtChungTuGoc.Text;
                    chung_tu.Da_Lam_Lai_Giay = false;
                    chung_tu.Mat_Giay = false;
                    chung_tu.Sap_Xep = 0;
                }

                string ket_qua = "";

                //if (lcChungTuGoc.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Always && !string.IsNullOrEmpty(txtChungTuGoc.Text))
                //{
                //    ket_qua = Luu_Lam_Giay_Moi(database);
                //    if (ket_qua != "OK")
                //    {
                //        database.Transaction.Rollback();
                //        MessageBox.Show(ket_qua);
                //    }
                //}

                ket_qua = Luu_Chi_Tiet(database);
                if (ket_qua == "OK")
                {
                    database.SubmitChanges();
                    database.Transaction.Commit();
                    database.Connection.Close();

                    if (InPhieu)
                    {
                        var rpt = new rptPhieuInCamDo(txtMaChungTu.Text, cbInThongTinRutGon.Checked);
                        //rpt.AssignPrintTool(new ReportPrintTool(rpt));
                        rpt.CreateDocument();
                        //rpt.ShowPreview();

                        int lien = 0;
                        if (int.TryParse(txtLien.Text, out lien))
                        {
                            for (int i = 0; i < lien - 1; i++)
                            {
                                var rpt_add = new rptPhieuInCamDo(txtMaChungTu.Text, false);
                                rpt_add.CreateDocument();

                                rpt.Pages.AddRange(rpt_add.Pages);
                            }
                        }

                        rpt.PrintingSystem.ContinuousPageNumbering = true;
                        ReportPrintTool printTool = new ReportPrintTool(rpt);
                        printTool.ShowPreview();
                    }

                    InPhieu = false;
                    RaiseReloadEventHander();
                    Close();
                    
                }
                else
                {
                    database.Transaction.Rollback();
                    MessageBox.Show(ket_qua);
                }

                
            }
            catch (Exception ex)
            {
                database.Transaction.Rollback();
                MessageBox.Show(ex.ToString());
            }
        }

        string Luu_Chi_Tiet(DB_Quan_Ly_Cam_DoDataContext database)
        {
            var ket_qua = "OK";
            var dt = dsCamDo.CHUNG_TU_CHI_TIET;
            var id = "";
            var row = 0;
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i].RowState != DataRowState.Deleted)
                {
                    if (dt.Rows[i]["Ten_Tai_San"] == DBNull.Value || string.IsNullOrEmpty(dt.Rows[i]["Ten_Tai_San"].ToString()))
                    {

                        MessageBox.Show("Tên tài sản không được rỗng.", "Thông báo",
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        ket_qua = "Tên tài sản không được rỗng.";
                        gbList.FocusedRowHandle = row;
                        gbList.SetColumnError(colTen_Tai_San, "Tên tài sản không được rỗng.");
                        return ket_qua;
                    }
                    id = dt.Rows[i]["Ma_Chi_Tiet"].ToString();
                    row++;
                }
                var dr = dt.Rows[i];
                switch (dr.RowState)
                {
                    case DataRowState.Added:

                        var chung_tu_chi_tiet = new CHUNG_TU_CHI_TIET
                        {
                            Ma_Chi_Tiet = Guid.NewGuid(),
                            Ma_Chung_Tu = txtMaChungTu.Text,
                            Ten_Tai_San = dt.Rows[i]["Ten_Tai_San"].ToString(),
                            Loai_Vang = dt.Rows[i]["Loai_Vang"].ToString(),
                            Trong_Luong_Vang_18k = Convert.ToDecimal(dt.Rows[i][colTrong_Luong_Vang_18k.FieldName] == DBNull.Value ? 0 : dt.Rows[i][colTrong_Luong_Vang_18k.FieldName]),
                            Trong_Luong_Vang_24k = Convert.ToDecimal(dt.Rows[i][colTrong_Luong_Vang_24k.FieldName] == DBNull.Value ? 0 : dt.Rows[i][colTrong_Luong_Vang_24k.FieldName]),
                            Trong_Luong_Khac = Convert.ToDecimal(dt.Rows[i][colTrong_Luong_Khac.FieldName] == DBNull.Value ? 0 : dt.Rows[i][colTrong_Luong_Khac.FieldName]),
                            Trong_Luong = dt.Rows[i]["Trong_Luong"].ToString(),
                            Chuan_Do = dt.Rows[i]["Chuan_Do"].ToString(),
                            Gia_Tri_Vat_Cam = Convert.ToDecimal(dt.Rows[i]["Gia_Tri_Vat_Cam"] == DBNull.Value ? 0 : dt.Rows[i]["Gia_Tri_Vat_Cam"]),
                            Sap_Xep = 0
                        };
                        database.CHUNG_TU_CHI_TIETs.InsertOnSubmit(chung_tu_chi_tiet);

                        break;
                    case DataRowState.Modified:

                        var chi_tiet_sua = (from ctct in database.CHUNG_TU_CHI_TIETs
                                            where ctct.Ma_Chi_Tiet == new Guid(id)
                                            select ctct).FirstOrDefault();

                        chi_tiet_sua.Ma_Chi_Tiet = new Guid(id);
                        chi_tiet_sua.Ma_Chung_Tu = txtMaChungTu.Text;
                        chi_tiet_sua.Ten_Tai_San = dt.Rows[i]["Ten_Tai_San"].ToString();
                        chi_tiet_sua.Loai_Vang = dt.Rows[i]["Loai_Vang"].ToString();
                        chi_tiet_sua.Trong_Luong_Vang_18k = Convert.ToDecimal(dt.Rows[i][colTrong_Luong_Vang_18k.FieldName] == DBNull.Value ? 0 : dt.Rows[i][colTrong_Luong_Vang_18k.FieldName]);
                        chi_tiet_sua.Trong_Luong_Vang_24k = Convert.ToDecimal(dt.Rows[i][colTrong_Luong_Vang_24k.FieldName] == DBNull.Value ? 0 : dt.Rows[i][colTrong_Luong_Vang_24k.FieldName]);
                        chi_tiet_sua.Trong_Luong_Khac = Convert.ToDecimal(dt.Rows[i][colTrong_Luong_Khac.FieldName] == DBNull.Value ? 0 : dt.Rows[i][colTrong_Luong_Khac.FieldName]);
                        chi_tiet_sua.Trong_Luong = dt.Rows[i]["Trong_Luong"].ToString();
                        chi_tiet_sua.Chuan_Do = dt.Rows[i]["Chuan_Do"].ToString();
                        chi_tiet_sua.Gia_Tri_Vat_Cam = Convert.ToDecimal(dt.Rows[i]["Gia_Tri_Vat_Cam"] == DBNull.Value ? 0 : dt.Rows[i]["Gia_Tri_Vat_Cam"]);
                        chi_tiet_sua.Sap_Xep = 0;
                        break;
                    case DataRowState.Deleted:
                        var chi_tiet_xoa = (from ctct in database.CHUNG_TU_CHI_TIETs
                                            where ctct.Ma_Chi_Tiet == new Guid(dt.Rows[i]["Ma_Chi_Tiet", DataRowVersion.Original].ToString())
                                            select ctct).FirstOrDefault();
                        database.CHUNG_TU_CHI_TIETs.DeleteOnSubmit(chi_tiet_xoa);
                        break;
                }
                database.SubmitChanges();
            }
            return ket_qua;
        }

        //string Luu_Lam_Giay_Moi(DB_Quan_Ly_Cam_DoDataContext database)
        //{
        //    var chung_tu = (from ct in database.CHUNG_TUs
        //                    where ct.Ma_Chung_Tu == txtChungTuGoc.Text
        //                    select ct).FirstOrDefault();

        //    if (chung_tu == null)
        //        return "Không tìm thấy phiếu " + txtChungTuGoc.Text;

        //    chung_tu.Da_Lam_Lai_Giay = true;
        //    database.SubmitChanges();

        //    return "OK";
        //}

        bool Kiem_Tra()
        {
            if (!txtMaChungTu.Properties.ReadOnly)
            {
                DB_Quan_Ly_Cam_DoDataContext database = new DB_Quan_Ly_Cam_DoDataContext(SqlHelper.ConnectionString);
                var chung_tu = (from ct in database.CHUNG_TUs
                                where ct.Ma_Chung_Tu == txtMaChungTu.Text
                                select ct);

                if (chung_tu.Count() > 0)
                {
                    if (MessageBox.Show("Mã trùng. Bạn có muốn đổi mã khác hay không ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        txtMaChungTu.Text = SqlHelper.GenCode("CHUNG_TU", "Ma_Chung_Tu", "CD", 1);
                    }
                    return false;
                }
            }

            if (string.IsNullOrEmpty(txtMaChungTu.Text))
            {
                MessageBox.Show("Mã chứng từ rỗng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaChungTu.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtKhachHang.Text))
            {
                MessageBox.Show("Khách hàng rỗng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKhachHang.Focus();
                return false;
            }

            if (txtSoTienCam.Value == 0)
            {
                MessageBox.Show("Số tiền bằng 0.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoTienCam.Focus();
                return false;
            }

            if (dsCamDo.CHUNG_TU_CHI_TIET.Rows.Count == 0)
            {
                MessageBox.Show("Phiếu rỗng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!KiemTraPhieuDaChuoc(txtMaChungTu.Text))
            {
                return false;
            }

            return true;

        }

        private bool KiemTraPhieuDaChuoc(string ma)
        {
            var cttc = (from ct in db.CHUNG_TU_THU_CHIs
                        where ct.Phan_Loai == "Chuộc" && ct.Ma_Chung_Tu_Cam_Do == ma
                        select ct).Count();
            if (cttc > 0)
            {
                MessageBox.Show("Chứng từ " + ma + " này đã chuộc rồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void bbiXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            if (MessageBox.Show("Có muốn xóa dữ liệu đang chọn không ?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            gbList.DeleteSelectedRows();
            gbList.UpdateCurrentRow();
        }

        private void bbiXoaTatCa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Có muốn xóa tất cả dữ liệu không ?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            gbList.SelectAll();
            gbList.DeleteSelectedRows();
        }

        private void btnTimKhachHang_Click(object sender, EventArgs e)
        {
            var frm = new DanhSachKhachHang();
            frm.SetCustomer += (string tenkhachhang, string cmnd, string ngaycap, string noicap, string diachi, string sodienthoai) => 
            {
                txtKhachHang.Text = tenkhachhang;
                txtCMNDSo.Text = cmnd;
                txtNoiCap.Text = ngaycap;
                txtNgayCap.Text = noicap;
                txtDiaChi.Text = diachi;
                txtSoDienThoai.Text = sodienthoai;
            };
            frm.ShowDialog();
        }

        private void txtBo_Click(object sender, EventArgs e)
        {
            txtKhachHang.Text = "";
            txtCMNDSo.Text = "";
            txtNoiCap.Text = "";
            txtNgayCap.Text = "";
            txtDiaChi.Text = "";
            txtSoDienThoai.Text = "";
        }

        private void rptHyperlinkTim_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
        }

        private void rptHyperlinkTim_Click(object sender, EventArgs e)
        {
            var frm = new DanhSachTaiSan();
            frm.SetTaiSan += (string tentaisan) => 
            {
                gbList.SetFocusedRowCellValue(colTen_Tai_San, tentaisan);
            };
            frm.ShowDialog();
        }

        void Hang_Hoa()
        {
            dANH_SACH_HANG_HOATableAdapter.Connection.ConnectionString = SqlHelper.ConnectionString;
            dANH_SACH_HANG_HOATableAdapter.ClearBeforeFill = true;
            dANH_SACH_HANG_HOATableAdapter.Fill(dsCamDo.DANH_SACH_HANG_HOA);
        }

        private void txtNgay_EditValueChanged(object sender, EventArgs e)
        {
            txtTuNgay.Text = String.Format("{0:dd/MM/yyyy}", txtNgay.DateTime);
            if (SqlHelper.ThoiHanQuyDinh != 0)
            {
                txtDenNgay.Text = String.Format("{0:dd/MM/yyyy}", txtNgay.DateTime.AddMonths(Convert.ToInt32(SqlHelper.ThoiHanQuyDinh)));
            }
        }

        private void btnTimDiaChi_Click(object sender, EventArgs e)
        {
            var frm = new DanhSachDiaChi();
            frm.SetAddress += (string diachi) =>
            {
                txtDiaChi.Text = diachi;   
            };
            frm.ShowDialog();
        }

        private void gbList_HangHoa_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            int rowIndex = e.RowHandle;
            if (rowIndex >= 0)
            {
                rowIndex++;
                e.Info.DisplayText = rowIndex.ToString();
            }
        }

        private void bbiLuuVaIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InPhieu = true;
            bbiLuu_ItemClick(this, null);
        }

        private void btnChonHangHoa_Click(object sender, EventArgs e)
        {
            Chon_Hang_Hoa(this, null);
        }

        private void txtSoTienCam_EditValueChanged(object sender, EventArgs e)
        {
            txtSoTienCamBangChu.Text = TinhToan.DocChu(String.Format("{0:##,##0}",txtSoTienCam.Value));
        }

        private void rptTenTaiSan_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag.ToString() == "Chọn")
            {
                var chonTaisan = new DanhSachTaiSan();
                chonTaisan.SetTaiSan += (tentaisan) => 
                {
                    if (gbList.GetFocusedDataSourceRowIndex() < 0)
                    {
                        gbList.AddNewRow();
                    }
                    
                    gbList.SetFocusedRowCellValue(colTen_Tai_San, tentaisan);
                    gbList.UpdateCurrentRow();
                };
                chonTaisan.ShowDialog();
            }
        }

        private void rptLoaiVang_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag.ToString() == "Chọn")
            {
                var chonLoaiVang = new frDanhSachLoaiVang();
                chonLoaiVang.SetLoaiVang += (loaivang) =>
                {
                    if (gbList.GetFocusedDataSourceRowIndex() < 0)
                    {
                        gbList.AddNewRow();
                    }

                    gbList.SetFocusedRowCellValue(colLoai_Vang, loaivang);
                    gbList.UpdateCurrentRow();
                };
                chonLoaiVang.ShowDialog();
            }
        }

        private void txtLaiSuatThang_EditValueChanged(object sender, EventArgs e)
        {
            txtLaiSuatNgay.Value = (txtLaiSuatThang.Value / 30);
        }

        private void gbList_ShownEditor(object sender, EventArgs e)
        {
            //var view = sender as GridView;
            //if (view.FocusedColumn == colTen_Tai_San)
            //{
            //    TextEdit txtTenTaiSan_AutoComplete = view.ActiveEditor as TextEdit;
            //    if (txtTenTaiSan_AutoComplete != null)
            //    {
            //        txtTenTaiSan_AutoComplete.MaskBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            //        txtTenTaiSan_AutoComplete.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //        txtTenTaiSan_AutoComplete.MaskBox.AutoCompleteCustomSource = mangDanhSachHangHoa;
            //    }
            //}
            
        }
    }
}
