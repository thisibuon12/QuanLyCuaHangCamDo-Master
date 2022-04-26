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

namespace Phan_Mem_Quan_Ly_Cam_Do.ChuocDo
{
    public partial class ucDanhSach : UserControl
    {
        public ucDanhSach()
        {
            InitializeComponent();

            DisableMenu();

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

        private void DisableMenu()
        {
            bbiSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            bbiXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            bbiKhachLayThemTien.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            bbiKhachTraBotTien.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            bbiTraTienLoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            bbiChuocDo.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        private void ActiveEditor_DoubleClick(object sender, EventArgs e)
        {
            bbiSua_ItemClick(this, null);
        }

        private void bbiXem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cHUNG_TU_Theo_NgayTableAdapter.Connection.ConnectionString = SqlHelper.ConnectionString;
            cHUNG_TU_Theo_NgayTableAdapter.ClearBeforeFill = true;
            cHUNG_TU_Theo_NgayTableAdapter.Fill(dsChuocDo.CHUNG_TU_Theo_Ngay, txtTu.DateTime, txtDen.DateTime);

            //cHUNG_TU_CHI_TIET_Theo_NgayTableAdapter.Connection.ConnectionString = SqlHelper.ConnectionString;
            //cHUNG_TU_CHI_TIET_Theo_NgayTableAdapter.ClearBeforeFill = true;
            //cHUNG_TU_CHI_TIET_Theo_NgayTableAdapter.Fill(dsChuocDo.CHUNG_TU_CHI_TIET_Theo_Ngay, txtTu.DateTime, txtDen.DateTime);

            cHUNG_TU_THU_CHI_Theo_NgayTableAdapter.Connection.ConnectionString = SqlHelper.ConnectionString;
            cHUNG_TU_THU_CHI_Theo_NgayTableAdapter.ClearBeforeFill = true;
            cHUNG_TU_THU_CHI_Theo_NgayTableAdapter.Fill(dsChuocDo.CHUNG_TU_THU_CHI_Theo_Ngay, txtTu.DateTime, txtDen.DateTime);

            gbList.BestFitColumns();
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
            //if (MessageBox.Show("Có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            //    return;

            //var db = new DB_Quan_Ly_Cam_DoDataContext(SqlHelper.ConnectionString);

            //int[] selectedRows = gbList.GetSelectedRows();
            //string[] chungtu = new string[selectedRows.Length];
            //for (int i = selectedRows.Length; i > 0; i--)
            //{
            //    var arg = gbList.GetRowCellValue(selectedRows[i - 1], colMa_Chung_Tu);
            //    if (arg == null)
            //        continue;
            //    chungtu[i - 1] = arg.ToString();
            //}

            //var ct = from c in db.CHUNG_TUs
            //         where chungtu.Contains(c.Ma_Chung_Tu)
            //         select c;


            //foreach (var c in ct)
            //{
            //    db.CHUNG_TUs.DeleteOnSubmit(c);
            //}

            //try
            //{
            //    db.SubmitChanges();
            //    bbiXem_ItemClick(this, null);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
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

        private void bbiSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //var arg = gbList.GetFocusedRowCellValue(colMa_Chung_Tu);
            //if (arg == null)
            //    return;

            //var frm = new PhieuCamDo(arg.ToString());
            //frm.Reload += Reload;
            //frm.WindowState = FormWindowState.Maximized;
            //frm.ShowDialog();
        }

        void Reload(object sender)
        {
            bbiXem_ItemClick(this, null);
        }

        private void bbiChuocDo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Phieu_Thu(0);
        }

        private void bbiTraTienLoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Phieu_Thu(1);
        }

        private void bbiKhachTraBotTien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Phieu_Thu(2);
        }

        //void Phieu_Thu(int loai)
        //{
        //    var arg = gbList.GetRowCellValue(gbList.FocusedRowHandle, colMa_Chung_Tu);
        //    if (arg == null)
        //        return;

        //    var so_tien = gbList.GetRowCellValue(gbList.FocusedRowHandle, colSo_Tien);
        //    var lai_suat_thang = gbList.GetRowCellValue(gbList.FocusedRowHandle, colLai_Suat_Thang);
        //    var ngay_ghi_so = gbList.GetRowCellValue(gbList.FocusedRowHandle, colNgay_Ghi_So);

        //    var frm = new PhieuThu();
        //    frm.Thiet_Lap(arg.ToString(), Convert.ToDecimal(so_tien), Convert.ToDecimal(lai_suat_thang), Convert.ToDateTime(ngay_ghi_so), loai);
        //    frm.ShowDialog();
        //}

        private void bbiKhachLayThemTien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //var arg = gbList.GetRowCellValue(gbList.FocusedRowHandle, colMa_Chung_Tu);
            //if (arg == null)
            //    return;

            //var frm = new PhieuChi();
            //frm.Thiet_Lap(arg.ToString());
            //frm.ShowDialog();
        }

        public void BestFitColumn()
        {
            gbList.BestFitColumns();
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

        private void gbList_Child_PaidReceive_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            int rowIndex = e.RowHandle;
            if (rowIndex >= 0)
            {
                rowIndex++;
                e.Info.DisplayText = rowIndex.ToString();
            }
        }

        private void bbiXuatExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new XuLy();
            frm.Export(gbList);
        }

        private void gbList_MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
        {
            GridView master = sender as GridView;
            GridView detail = master.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
            detail.BestFitColumns();
        }
    }
}
