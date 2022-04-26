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
using System.Data.SqlTypes;

namespace Phan_Mem_Quan_Ly_Cam_Do.ChuocDo
{
    public partial class ucChiTiet : UserControl
    {
        public ucChiTiet()
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

            bbiSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        private void ActiveEditor_DoubleClick(object sender, EventArgs e)
        {
            bbiSua_ItemClick(this, null);
        }

        private void bbiXem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cHUNG_TU_CHI_TIET_Theo_NgayTableAdapter.Connection.ConnectionString = SqlHelper.ConnectionString;
            cHUNG_TU_CHI_TIET_Theo_NgayTableAdapter.ClearBeforeFill = true;
            cHUNG_TU_CHI_TIET_Theo_NgayTableAdapter.Fill(dsChuocDo.CHUNG_TU_CHI_TIET_Theo_Ngay, txtTu.DateTime, txtDen.DateTime);

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

        public void BestFitColumn()
        {
            gbList.BestFitColumns();
        }

        private void bbiXuatExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new XuLy();
            frm.Export(gbList);
        }
    }
}
