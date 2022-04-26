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
using System.Data.SqlTypes;

namespace Phan_Mem_Quan_Ly_Cam_Do.ThuChi
{
    public partial class DanhSachThuChi : Form
    {
        
        public DanhSachThuChi()
        {
            InitializeComponent();

            DateTime tu = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime den = tu.AddMonths(1).AddDays(-1);

            dtTu.DateTime = tu;
            dtDen.DateTime = den;

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

        void Set_Date(int month)
        {
            DateTime tu = new DateTime(DateTime.Now.Year, month, 1);
            DateTime den = tu.AddMonths(1).AddDays(-1);

            dtTu.DateTime = tu;
            dtDen.DateTime = den;
        }

        private void cbChonNgay_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = cbChonNgay.SelectedItem.ToString();
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
                    dtTu.DateTime = (DateTime)SqlDateTime.MinValue;
                    dtDen.DateTime = (DateTime)SqlDateTime.MaxValue;
                    break;
            }
        }

        private void bbiXem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cHUNG_TU_THU_CHITableAdapter.Connection.ConnectionString = SqlHelper.ConnectionString;
            cHUNG_TU_THU_CHITableAdapter.ClearBeforeFill = true;
            cHUNG_TU_THU_CHITableAdapter.Fill(dsThuChi.CHUNG_TU_THU_CHI, dtTu.DateTime, dtDen.DateTime);

            gbList.BestFitColumns();
        }

        public void BestFitColumn()
        {
            gbList.BestFitColumns();
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

        private void bbiXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            gbList.Focus();

            int[] selectedRows = gbList.GetSelectedRows();
            string[] chungtuthuchi = new string[selectedRows.Length];
            for (int i = selectedRows.Length; i > 0; i--)
            {
                var arg = gbList.GetRowCellValue(selectedRows[i - 1], colMa);
                if (arg == null)
                    continue;
                chungtuthuchi[i - 1] = arg.ToString();
            }

            DB_Quan_Ly_Cam_DoDataContext db = new DB_Quan_Ly_Cam_DoDataContext(SqlHelper.ConnectionString);

            var cttc = from ct in db.CHUNG_TU_THU_CHIs
                     where chungtuthuchi.Contains(ct.Ma)
                     select ct;


            foreach (var c in cttc)
            {
                db.CHUNG_TU_THU_CHIs.DeleteOnSubmit(c);
            }

            try
            {
                db.SubmitChanges();
                bbiXem_ItemClick(this, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bbiSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var ma = gbList.GetRowCellValue(gbList.FocusedRowHandle, colMa);
            if (ma == null)
                return;

            var loai = gbList.GetRowCellValue(gbList.FocusedRowHandle, colLoai);
            if (loai == null)
                return;

            if (loai.ToString() == "Thu")
            {
                var frm = new PhieuThu(ma.ToString());
                frm.Reload += (sx) => 
                {
                    bbiXem_ItemClick(this, null);
                };
                frm.ShowDialog();
            }
            else
            {
                var frm = new PhieuChi(ma.ToString());
                frm.Reload += (sx) =>
                {
                    bbiXem_ItemClick(this, null);
                };
                frm.ShowDialog();
            }
        }

        private void bbiLapPhieuThu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new PhieuThu();
            frm.Reload += (sx) =>
            {
                bbiXem_ItemClick(this, null);
            };
            frm.ShowDialog();
        }

        private void bbiLapPhieuChi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new PhieuChi();
            frm.Reload += (sx) =>
            {
                bbiXem_ItemClick(this, null);
            };
            frm.ShowDialog();
        }

        private void bbiXuatExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new XuLy();
            frm.Export(gbList);
        }
    }
}
