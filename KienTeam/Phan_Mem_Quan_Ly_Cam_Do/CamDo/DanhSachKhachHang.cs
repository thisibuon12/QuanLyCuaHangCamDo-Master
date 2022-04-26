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
    public partial class DanhSachKhachHang : Form
    {

        public delegate void SetCustomerEventHander(string tenkhachhang, string cmnd, string ngaycap, string noicap, string diachi, string sodienthoai);

        public event SetCustomerEventHander SetCustomer;
        private void RaiseSetCustomerEventHander(string tenkhachhang, string cmnd, string ngaycap, string noicap, string diachi, string sodienthoai)
        {
            if (SetCustomer != null)
            {
                SetCustomer(tenkhachhang, cmnd, ngaycap, noicap, diachi, sodienthoai);
            }
        }

        public DanhSachKhachHang()
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
            var tenkhachhang = gbList.GetFocusedRowCellValue(colTen_Khach_Hang);
            var cmnd = gbList.GetFocusedRowCellValue(colSo_CMND);
            var ngaycap = gbList.GetFocusedRowCellValue(colNgay_Cap_CMND);
            var noicap = gbList.GetFocusedRowCellValue(colNoi_Cap);
            var diachi = gbList.GetFocusedRowCellValue(colDia_Chi);
            var sodienthoai = gbList.GetFocusedRowCellValue(colSo_Dien_Thoai); 

            RaiseSetCustomerEventHander(
                tenkhachhang.ToString(), 
                cmnd.ToString(), 
                ngaycap.ToString(), 
                noicap.ToString(), 
                diachi.ToString(), 
                sodienthoai.ToString());

            this.Close();
        }

       

        

        private void bbiDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void DanhSachKhachHang_Load(object sender, EventArgs e)
        {
        }

        private void bbiXem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dANH_SACH_KHACH_HANGTableAdapter.Connection.ConnectionString = SqlHelper.ConnectionString;
            dANH_SACH_KHACH_HANGTableAdapter.ClearBeforeFill = true;
            dANH_SACH_KHACH_HANGTableAdapter.Fill(dsCamDo.DANH_SACH_KHACH_HANG);
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
