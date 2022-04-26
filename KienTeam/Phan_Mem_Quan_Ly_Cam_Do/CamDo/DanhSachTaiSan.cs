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

namespace Phan_Mem_Quan_Ly_Cam_Do.CamDo
{
    public partial class DanhSachTaiSan : Form
    {

        public delegate void SetTaiSanEventHander(string tentaisan);

        public event SetTaiSanEventHander SetTaiSan;
        private void RaiseSetTaiSanEventHander(string tentaisan)
        {
            if (SetTaiSan != null)
            {
                SetTaiSan(tentaisan);
            }
        }

        public DanhSachTaiSan()
        {
            InitializeComponent();

            //DateTime tu = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            //DateTime den = tu.AddMonths(1).AddDays(-1);

            //dtTu.DateTime = tu;
            //dtDen.DateTime = den;

            bbiXem_ItemClick(this, null);

            gbList.ShownEditor += (s, e) => 
            {
                var view = s as GridView;
                view.ActiveEditor.DoubleClick += ActiveEditor_DoubleClick;
            };
        }

        private void ActiveEditor_DoubleClick(object sender, EventArgs e)
        {
            var tentaisan= gbList.GetFocusedRowCellValue(colTen_Tai_San);

            RaiseSetTaiSanEventHander(
                tentaisan.ToString()
                );

            this.Close();
        }

        private void bbiDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void bbiXem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dANH_SACH_HANG_HOATableAdapter.Connection.ConnectionString = SqlHelper.ConnectionString;
            dANH_SACH_HANG_HOATableAdapter.ClearBeforeFill = true;
            dANH_SACH_HANG_HOATableAdapter.Fill(dsCamDo.DANH_SACH_HANG_HOA);
        }

        private void bbiChon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActiveEditor_DoubleClick(this, null);
        }

        private void gbList_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            int rowIndex = e.RowHandle;
            if (rowIndex >= 0)
            {
                rowIndex++;
                e.Info.DisplayText = rowIndex.ToString();
            }
        }
    }
}
