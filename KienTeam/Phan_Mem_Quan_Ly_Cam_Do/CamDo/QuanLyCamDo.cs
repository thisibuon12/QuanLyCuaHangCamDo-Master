using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Phan_Mem_Quan_Ly_Cam_Do.CamDo
{
    public partial class QuanLyCamDo : Form
    {
        public QuanLyCamDo()
        {
            InitializeComponent();
            bbiDanhSach_ItemClick(this, null);
        }

        private void bbiLapPhieuCamDo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PhieuCamDo frm = new PhieuCamDo();
            frm.Reload += Reload;
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();
        }

        void Reload(object sender)
        {
            if (_ucDanhSach != null)
            {
                _ucDanhSach.Reload();
            }
            if (_ucChiTiet != null)
            {
                _ucChiTiet.Reload();
            }
        }

        private ucDanhSach _ucDanhSach;
        private void bbiDanhSach_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            plMain.Controls.Clear();
            if (_ucDanhSach == null)
            {
                _ucDanhSach = new ucDanhSach();
            }
            _ucDanhSach.Dock = DockStyle.Fill;

            plMain.Controls.Add(_ucDanhSach);
            _ucDanhSach.BestFitColumn();
            plMain.Text = @"Chứng Từ Cầm Đồ";

        }

        private ucChiTiet _ucChiTiet;
        private void bbiChiTiet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            plMain.Controls.Clear();
            if (_ucChiTiet == null)
            {
                _ucChiTiet = new ucChiTiet();
            }
            _ucChiTiet.Dock = DockStyle.Fill;

            plMain.Controls.Add(_ucChiTiet);
            _ucChiTiet.BestFitColumn();
            plMain.Text = @"Chi Tiết Cầm Đồ";
        }
    }
}
