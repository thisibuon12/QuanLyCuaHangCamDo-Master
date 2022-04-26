using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Phan_Mem_Quan_Ly_Cam_Do.DoiTuong;

namespace Phan_Mem_Quan_Ly_Cam_Do.TheoDoi
{
    public partial class TheoDoi : Form
    {
        string ma_chung_tu_cam_do = "";
        public TheoDoi()
        {
            InitializeComponent();
        }

        public TheoDoi(string machungtucamdo)
        {
            InitializeComponent();
            this.ma_chung_tu_cam_do = machungtucamdo;
            bbiXem_ItemClick(this, null);
        }

        private void bbiXem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sql =
            @"
                --DECLARE @Ma_Chung_Tu_Cam_Do VARCHAR(250)
                --SET @Ma_Chung_Tu_Cam_Do = 'CD88'

                SELECT ct.Ma_Chung_Tu AS Ma,
                       ct.So,
                       ct.Ngay,
                       ct.Ngay AS Ngay_Ghi_So,
                       ct.Ma_Chung_Tu AS Ma_Chung_Tu_Cam_Do,
                       ct.Ten_Khach_Hang,
                       ct.So_CMND,
                       ct.Dia_Chi,
                       CAST(NULL AS MONEY) AS So_Tien_Thu,
                       ct.So_Tien_Cam AS So_Tien_Chi,
                       'Thu' AS Loai,
                       N'Cầm đồ' AS Phan_Loai,
                       N'Chứng từ cầm đồ' AS Ten_Loai,
                       ct.Ghi_Chu,
                       ct.Mat_Giay
                FROM   CHUNG_TU ct
                WHERE  ct.Ma_Chung_Tu = @Ma_Chung_Tu_Cam_Do

                UNION ALL

                SELECT cttc.Ma,
                       CAST(NULL AS NVARCHAR(250)) AS So,
                       cttc.Ngay,
                       cttc.Ngay_Ghi_So,
                       cttc.Ma_Chung_Tu_Cam_Do,
                       ct.Ten_Khach_Hang,
                       ct.So_CMND,
                       ct.Dia_Chi,
                       cttc.So_Tien_Thu,
                       cttc.So_Tien_Chi,
                       cttc.Loai,
                       cttc.Phan_Loai,
                       cttc.Ten_Loai,
                       cttc.Ghi_Chu,
                       CAST(0 AS BIT) AS Mat_Giay
                FROM   CHUNG_TU_THU_CHI cttc
                       LEFT OUTER JOIN CHUNG_TU ct
                            ON  ct.Ma_Chung_Tu = cttc.Ma_Chung_Tu_Cam_Do
                WHERE  cttc.Ma_Chung_Tu_Cam_Do = @Ma_Chung_Tu_Cam_Do
            ";

            string[] myPara = { "@Ma_Chung_Tu_Cam_Do" };
            object[] myValue = { ma_chung_tu_cam_do };

            var mySql = new SqlHelper();

            dsTheoDoi.Theo_Doi.Rows.Clear();
            dsTheoDoi.Theo_Doi.Merge(mySql.ExecuteDataTable(sql, myPara, myValue));

            gbList.BestFitColumns();
        }

        private void bbiDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
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

        private void bbiXuatExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new XuLy();
            frm.Export(gbList);
        }


    }
}
