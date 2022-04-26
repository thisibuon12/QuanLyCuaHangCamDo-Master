using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using DevExpress.Skins;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using Phan_Mem_Quan_Ly_Cam_Do.CamDo;
using Phan_Mem_Quan_Ly_Cam_Do.ThuChi;
using Phan_Mem_Quan_Ly_Cam_Do.ChuocDo;
using System.Globalization;
using Phan_Mem_Quan_Ly_Cam_Do.QuanLyDuLieu;
using Phan_Mem_Quan_Ly_Cam_Do.DoiTuong;


namespace Phan_Mem_Quan_Ly_Cam_Do.GiaoDienChinh
{
    public partial class DanhSachChucNang : RibbonForm
    {
        bool dangnhapthanhcong = false;
        public DanhSachChucNang()
        {
            dangnhapthanhcong = false; ;
            CauHinhCSDL cauhinhCSDL = new CauHinhCSDL();
            cauhinhCSDL.ThanhCong += cauhinhCSDL_ThanhCong;
            cauhinhCSDL.Bo += cauhinhCSDL_Bo;
            cauhinhCSDL.FormClosed += (s, e) => 
            {
                if (!dangnhapthanhcong)
                {
                    Application.Exit();
                }
            };
            cauhinhCSDL.ShowDialog(this);

            //InitializeComponent();
        }

        private void cauhinhCSDL_ThanhCong(object sender)
        {
            //System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("vi-VN");

            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("vi-VN");

            InitializeComponent();

            lblDatabase.Caption += SqlHelper.Database;
            lblServer.Caption += SqlHelper.Server;

            bbiCamDo_ItemClick(this, null);
            dangnhapthanhcong = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private void cauhinhCSDL_Bo(object sender)
        {
            Application.Exit();
        }

        private void BbiCloseItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private QuanLyCamDo _QuanLyCamDo;
        private void bbiCamDo_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_QuanLyCamDo == null)
            {
                _QuanLyCamDo = new QuanLyCamDo();
                _QuanLyCamDo.FormClosing += (ss, ex) =>
                {
                    _QuanLyCamDo = null;
                };
                _QuanLyCamDo.MdiParent = this;
                _QuanLyCamDo.Show();
            }
            else
            {
                tabMdi.Pages[_QuanLyCamDo].MdiChild.Activate();
            }
        }

        private DanhSachThuChi _danhsachthuchi;
        private void bbIThuChi_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_danhsachthuchi == null)
            {
                _danhsachthuchi = new DanhSachThuChi();
                _danhsachthuchi.FormClosing += (ss, ex) =>
                {
                    _danhsachthuchi = null;
                };
                _danhsachthuchi.MdiParent = this;
                _danhsachthuchi.Show();
            }
            else
            {
                tabMdi.Pages[_danhsachthuchi].MdiChild.Activate();
            }
        }

        private QuanLyChuocDo _QuanLyChuocDo;
        private void bbiChuocDo_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_QuanLyChuocDo == null)
            {
                _QuanLyChuocDo = new QuanLyChuocDo();
                _QuanLyChuocDo.FormClosing += (ss, ex) =>
                {
                    _QuanLyChuocDo = null;
                };
                _QuanLyChuocDo.MdiParent = this;
                _QuanLyChuocDo.Show();
            }
            else
            {
                tabMdi.Pages[_QuanLyChuocDo].MdiChild.Activate();
            }
        }

        private void bbiSaoLuu_ItemClick(object sender, ItemClickEventArgs e)
        {
            var xfm = new xfmSaoLuu();
            xfm.ShowDialog();
            //var xfm = new xfmBackupDatabase();
            //xfm.ShowDialog();
        }

        private void bbiPhucHoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            var xfm = new xfmPhucHoi();
            xfm.ShowDialog();
            //var xfm = new xfmRestoreDatabase();
            //xfm.ShowDialog();
        }

        private QuyTienMat.QuyTienMat _quyTienMat; 
        private void bbiQuyTienMat_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_quyTienMat == null)
            {
                _quyTienMat = new QuyTienMat.QuyTienMat();
                _quyTienMat.FormClosing += (ss, ex) =>
                {
                    _quyTienMat = null;
                };
                _quyTienMat.MdiParent = this;
                _quyTienMat.Show();
            }
            else
            {
                tabMdi.Pages[_quyTienMat].MdiChild.Activate();
            }
        }

      
        private void bbiInMaVach_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }        

        
        

        //private QuanLyXuatKho _quanlyxuatkho;
        //private void bbiXuatKho_ItemClick(object sender, ItemClickEventArgs e)
        //{
        //    if (_quanlyxuatkho == null)
        //    {
        //        _quanlyxuatkho = new QuanLyXuatKho();
        //        _quanlyxuatkho.FormClosing += (ss, ex) =>
        //        {
        //            _quanlyxuatkho = null;
        //        };
        //        _quanlyxuatkho.MdiParent = this;
        //        _quanlyxuatkho.Show();
        //    }
        //    else
        //    {
        //        tabMdi.Pages[_quanlyxuatkho].MdiChild.Activate();
        //    }
        //}

        
    }
}