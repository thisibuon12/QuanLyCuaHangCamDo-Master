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
    public partial class frDanhSachLoaiVang : Form
    {

        public delegate void SetLoaiVangEventHander(string loaivang);

        public event SetLoaiVangEventHander SetLoaiVang;
        private void RaiseSetLoaiVangEventHander(string loaivang)
        {
            if (SetLoaiVang != null)
            {
                SetLoaiVang(loaivang);
            }
        }

        public frDanhSachLoaiVang()
        {
            InitializeComponent();
            bbiXem_ItemClick(this, null);

            gbList.ShownEditor += (s, e) => 
            {
                var view = s as GridView;
                view.ActiveEditor.DoubleClick += ActiveEditor_DoubleClick;
            };
        }

        private void ActiveEditor_DoubleClick(object sender, EventArgs e)
        {
            var loaivang= gbList.GetFocusedRowCellValue(colLoai_Vang);

            RaiseSetLoaiVangEventHander(
                loaivang.ToString()
                );

            this.Close();
        }

        private void bbiDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void bbiXem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            dANH_SACH_LOAI_VANGTableAdapter.Connection.ConnectionString = SqlHelper.ConnectionString;
            dANH_SACH_LOAI_VANGTableAdapter.ClearBeforeFill = true;
            dANH_SACH_LOAI_VANGTableAdapter.Fill(dsCamDo.DANH_SACH_LOAI_VANG);
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
