using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using Phan_Mem_Quan_Ly_Cam_Do.DoiTuong;
using Phan_Mem_Quan_Ly_Cam_Do.ThuChi;
using System.Data.SqlTypes;
using Phan_Mem_Quan_Ly_Cam_Do.CamDo.PhieuIn;
using DevExpress.XtraReports.UI;
using DevExpress.XtraEditors;

namespace Phan_Mem_Quan_Ly_Cam_Do.CamDo
{
    public partial class ucDanhSach : UserControl
    {
        public ucDanhSach()
        {
            InitializeComponent();

            var tu = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var den = tu.AddMonths(1).AddDays(-1);

            txtTu.DateTime = tu;
            txtDen.DateTime = den;

            bbiXem_ItemClick(this, null);

            gbList.ShownEditor += (s, e) =>
                {
                    var view = s as GridView;
                    view.ActiveEditor.DoubleClick += ActiveEditor_DoubleClick;
                };
        }

        private void ActiveEditor_DoubleClick(object sender, EventArgs e)
        {
            bbiSua_ItemClick(this, null);
        }

        private void bbiXem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //cHUNG_TU_Theo_NgayTableAdapter.Connection.ConnectionString = SqlHelper.ConnectionString;
            //cHUNG_TU_Theo_NgayTableAdapter.ClearBeforeFill = true;
            //cHUNG_TU_Theo_NgayTableAdapter.Fill(dsCamDo.CHUNG_TU_Theo_Ngay, txtTu.DateTime, txtDen.DateTime, cbTatCa.Checked);

            //cHUNG_TU_CHI_TIET_Theo_NgayTableAdapter.Connection.ConnectionString = SqlHelper.ConnectionString;
            //cHUNG_TU_CHI_TIET_Theo_NgayTableAdapter.ClearBeforeFill = true;
            //cHUNG_TU_CHI_TIET_Theo_NgayTableAdapter.Fill(dsCamDo.CHUNG_TU_CHI_TIET_Theo_Ngay, txtTu.DateTime, txtDen.DateTime);

            gbList.BestFitColumns();
            gbList.ClearSelection();
            gbList.CollapseAllDetails();
        }

        public void Reload()
        {
            bbiXem_ItemClick(this, null);
        }

        void Set_Date(int month)
        {
            DateTime tu = new DateTime(DateTime.Now.Year, month, 1);
            DateTime den = tu.AddMonths(1).AddDays(-1);

            txtTu.DateTime = tu;
            txtDen.DateTime = den;
        }

        private void bbiDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void bbiXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Khi xóa chứng từ thì tất cả các phiếu thu liên quan sẽ được xóa theo.\nBạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            gbList.Focus();

            int[] selectedRows = gbList.GetSelectedRows();
            string[] chungtu = new string[selectedRows.Length];
            for (int i = selectedRows.Length; i > 0; i--)
            {
                var arg = gbList.GetRowCellValue(selectedRows[i - 1], colMa_Chung_Tu);
                if (arg == null)
                    continue;
                if (!KiemTraPhieuDaChuoc(arg.ToString()))
                    continue;
                chungtu[i - 1] = arg.ToString();
            }

            var db = new DB_Quan_Ly_Cam_DoDataContext(SqlHelper.ConnectionString);

            try
            {
                db.Connection.Open();
                System.Data.Common.DbTransaction transaction = db.Connection.BeginTransaction();
                db.Transaction = transaction;

                var ct = from c in db.CHUNG_TUs
                         where chungtu.Contains(c.Ma_Chung_Tu)
                         select c;


                foreach (var c in ct)
                {
                    db.CHUNG_TUs.DeleteOnSubmit(c);

                    var chung_tu_thu_chi = from cttcs in db.CHUNG_TU_THU_CHIs
                                           where cttcs.Ma_Chung_Tu_Cam_Do == c.Ma_Chung_Tu
                                           select cttcs;

                    foreach (var cttc in chung_tu_thu_chi)
                    {
                        db.CHUNG_TU_THU_CHIs.DeleteOnSubmit(cttc);
                    }

                }

                db.SubmitChanges();
                db.Transaction.Commit();
                db.Connection.Close();
                bbiXem_ItemClick(this, null);
            }
            catch (Exception ex)
            {
                db.Transaction.Rollback();
                MessageBox.Show(ex.Message);
            }
        }



        private void cbTuyChon_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = cbTuyChon.SelectedItem.ToString();
            switch (item)
            {
                case "Tháng 1":
                    Set_Date(1);
                    break;
                case "Tháng 2":
                    Set_Date(2);
                    break;
                case "Tháng 3":
                    Set_Date(3);
                    break;
                case "Tháng 4":
                    Set_Date(4);
                    break;
                case "Tháng 5":
                    Set_Date(5);
                    break;
                case "Tháng 6":
                    Set_Date(6);
                    break;
                case "Tháng 7":
                    Set_Date(7);
                    break;
                case "Tháng 8":
                    Set_Date(8);
                    break;
                case "Tháng 9":
                    Set_Date(9);
                    break;
                case "Tháng 10":
                    Set_Date(10);
                    break;
                case "Tháng 11":
                    Set_Date(11);
                    break;
                case "Tháng 12":
                    Set_Date(12);
                    break;
                case "Tất cả":
                    txtTu.DateTime = (DateTime)SqlDateTime.MinValue;
                    txtDen.DateTime = (DateTime)SqlDateTime.MaxValue;
                    break;
            }
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

        DB_Quan_Ly_Cam_DoDataContext db = new DB_Quan_Ly_Cam_DoDataContext(SqlHelper.ConnectionString);

        private void bbiSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var ma_chung_tu = gbList.GetFocusedRowCellValue(colMa_Chung_Tu);
            if (ma_chung_tu == null)
                return;

            //if (!KiemTraPhieuDaChuoc(ma_chung_tu.ToString()))
            //{
            //    return;
            //}

            var frm = new PhieuCamDo(ma_chung_tu.ToString());
            frm.Reload += (s_) => 
            {
                bbiXem_ItemClick(this, null);
            };
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();
        }

        //void Reload(object sender)
        //{
        //    bbiXem_ItemClick(this, null);
        //}

        private void bbiChuocDo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Phieu_Thu(0);
        }

        private void bbiTraTienLoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Phieu_Thu(1);
        }

        private void bbiKhachTraBotTien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Phieu_Thu(2);
        }

        private void Phieu_Thu(int loai)
        {
            var ma_chung_tu = gbList.GetRowCellValue(gbList.FocusedRowHandle, colMa_Chung_Tu);
            if (ma_chung_tu == null)
                return;

            string ten_khach_hang = gbList.GetRowCellValue(gbList.FocusedRowHandle, colTen_Khach_Hang) == null ? "" : gbList.GetRowCellValue(gbList.FocusedRowHandle, colTen_Khach_Hang).ToString();
            string so = gbList.GetRowCellValue(gbList.FocusedRowHandle, colSo) == null ? "" : gbList.GetRowCellValue(gbList.FocusedRowHandle, colSo).ToString();
            string so_cmnd = gbList.GetRowCellValue(gbList.FocusedRowHandle, colSo_CMND) == null ? "" : gbList.GetRowCellValue(gbList.FocusedRowHandle, colSo_CMND).ToString();
            if (!KiemTraPhieuDaChuoc(ma_chung_tu.ToString()))
            {
                return;
            }

            var so_tien = gbList.GetRowCellValue(gbList.FocusedRowHandle, colSo_Tien);
            var lai_suat_thang = gbList.GetRowCellValue(gbList.FocusedRowHandle, colLai_Suat_Thang);
            var ngay_ghi_so = gbList.GetRowCellValue(gbList.FocusedRowHandle, colNgay_Ghi_So);

            var frm = new PhieuThu();
            frm.Thiet_Lap(ma_chung_tu.ToString(), so, ten_khach_hang, so_cmnd, Convert.ToDecimal(so_tien), Convert.ToDecimal(lai_suat_thang), Convert.ToDateTime(ngay_ghi_so), loai);
            frm.Reload += (e) => 
            {
                bbiXem_ItemClick(this, null);
            };
            frm.ShowDialog();
        }

        private void bbiKhachLayThemTien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var arg = gbList.GetRowCellValue(gbList.FocusedRowHandle, colMa_Chung_Tu);
            if (arg == null)
                return;

            string ten_khach_hang = gbList.GetRowCellValue(gbList.FocusedRowHandle, colTen_Khach_Hang) == null ? "" : gbList.GetRowCellValue(gbList.FocusedRowHandle, colTen_Khach_Hang).ToString();
            string so = gbList.GetRowCellValue(gbList.FocusedRowHandle, colSo) == null ? "" : gbList.GetRowCellValue(gbList.FocusedRowHandle, colSo).ToString();
            string so_cmnd = gbList.GetRowCellValue(gbList.FocusedRowHandle, colSo_CMND) == null ? "" : gbList.GetRowCellValue(gbList.FocusedRowHandle, colSo_CMND).ToString();
            if (!KiemTraPhieuDaChuoc(arg.ToString()))
            {
                return;
            }

            var so_tien = gbList.GetRowCellValue(gbList.FocusedRowHandle, colSo_Tien);
            var lai_suat_thang = gbList.GetRowCellValue(gbList.FocusedRowHandle, colLai_Suat_Thang);
            var ngay_ghi_so = gbList.GetRowCellValue(gbList.FocusedRowHandle, colNgay_Ghi_So);


            var frm = new PhieuChi();
            frm.Thiet_Lap(arg.ToString(), so, ten_khach_hang,so_cmnd, Convert.ToDecimal(so_tien), Convert.ToDecimal(lai_suat_thang), Convert.ToDateTime(ngay_ghi_so));
            frm.Reload += (e_) =>
            {
                bbiXem_ItemClick(this, null);
            };
            frm.ShowDialog();
        }

        public void BestFitColumn()
        {
            gbList.BestFitColumns();
        }

        private void cbTatCa_CheckedChanged(object sender, EventArgs e)
        {
            bbiXem_ItemClick(this, null);
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

        private void gbChild_List_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            int rowIndex = e.RowHandle;
            if (rowIndex >= 0)
            {
                rowIndex++;
                e.Info.DisplayText = rowIndex.ToString();
            }
        }

        private void bbiTheoDoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            object machungtucamdo = gbList.GetFocusedRowCellValue(colMa_Chung_Tu);
            if (machungtucamdo == null)
                return;

            var frm = new TheoDoi.TheoDoi(machungtucamdo.ToString());
            frm.ShowDialog();
        }

        private void bbiXuatExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var xuly = new XuLy();
            xuly.Export(gbList);
        }

        private void bbiInPhieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            object machungtucamdo = gbList.GetFocusedRowCellValue(colMa_Chung_Tu);
            if (machungtucamdo == null)
                return;

            bool inthongtinrutgon = false;
            if (XtraMessageBox.Show("Bạn có muốn hiển thị thông tin rút gọn trong phiếu in hay không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                inthongtinrutgon = true;
            }

            var rpt = new rptPhieuInCamDo(machungtucamdo.ToString(), inthongtinrutgon);
            //rpt.ShowPreview();

            rpt.AssignPrintTool(new ReportPrintTool(rpt));
            rpt.CreateDocument();
            rpt.ShowPreview();
        }

        private void bbiLapGiayMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bbiChuocDo_ItemClick(this, null);

            var machungtucamdo = gbList.GetFocusedRowCellValue(colMa_Chung_Tu);
            if (machungtucamdo == null)
                return;

            PhieuCamDo frm = new PhieuCamDo();
            frm.Reload += (e_) => 
            {
                bbiXem_ItemClick(this, null);
            };
            frm.WindowState = FormWindowState.Maximized;
            frm.Lap_Giay_Moi(machungtucamdo.ToString());
            frm.ShowDialog();
        }

        private void gbList_MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
        {
            GridView master = sender as GridView;
            GridView detail = master.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
            detail.BestFitColumns();
        }
    }
}
