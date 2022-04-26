using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlTypes;
using Phan_Mem_Quan_Ly_Cam_Do.DoiTuong;

namespace Phan_Mem_Quan_Ly_Cam_Do.QuyTienMat
{
    public partial class QuyTienMat : Form
    {
        public QuyTienMat()
        {
            InitializeComponent();

            DateTime tu = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime den = tu.AddMonths(1).AddDays(-1);

            dtTu.DateTime = tu;
            dtDen.DateTime = den;

            bbiXem_ItemClick(this, null);
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
            string sql =
            @"
                --DECLARE @FromDate DATETIME
                --DECLARE @ToDate DATETIME
                --
                --SET @FromDate = '5/1/2014'
                --SET @ToDate = '5/31/2014'

                DECLARE @Bang_Quy_Tien_Mat TABLE (
                            Ma NVARCHAR(250) NULL,
                            So NVARCHAR(250) NULL,
                            Ngay DATETIME NULL,
                            Ngay_Ghi_So DATETIME NULL,
                            Ma_Chung_Tu_Cam_Do NVARCHAR(250) NULL,
                            So_Tien_Thu MONEY NULL,
                            So_Tien_Chi MONEY NULL,
                            So_Tien_Ton MONEY NULL,
                            Tien_Lai_Cu MONEY NULL,
                            Loai NVARCHAR(50) NULL,
                            Phan_Loai NVARCHAR(50) NULL,
                            Ten_Loai NVARCHAR(50) NULL,
                            Ghi_Chu NVARCHAR(250) NULL,
                            Ten_Khach_Hang NVARCHAR(250) NULL,
                            Sap_Xep BIGINT NULL
                        )

                DECLARE getDanhSach CURSOR  
                FOR
                    SELECT *
                    FROM   (
                               SELECT cttc.Ma,
                                      cttc.Ma AS So,
                                      cttc.Ngay,
                                      cttc.Ngay_Ghi_So,
                                      cttc.Ma_Chung_Tu_Cam_Do,
                                      cttc.So_Tien_Thu,
                                      cttc.So_Tien_Chi,
                                      cttc.Tien_Lai_Cu,
                                      cttc.Loai,
                                      cttc.Phan_Loai,
                                      cttc.Ten_Loai,
                                      cttc.Ghi_Chu,
                                      ct.Ten_Khach_Hang,
                                      cttc.Sap_Xep
                               FROM   CHUNG_TU_THU_CHI cttc
                                      LEFT OUTER JOIN CHUNG_TU ct
                                           ON  cttc.Ma_Chung_Tu_Cam_Do = ct.Ma_Chung_Tu
                               WHERE  DATEDIFF(DAY, @FromDate, cttc.Ngay) >= 0
                                      AND DATEDIFF(DAY, @ToDate, cttc.Ngay) <= 0
                               
                               UNION ALL
                               
                               SELECT ct.Ma_Chung_Tu,
                                      ct.So,
                                      ct.Ngay,
                                      ct.Ngay AS NgayGhiSo,
                                      ct.Ma_Chung_Tu AS Ma_Chung_Tu_Cam_Do,
                                      0 AS So_Tien_Thu,
                                      ct.So_Tien_Cam AS So_Tien_Chi,
                                      ct.Tien_Lai_Cu,
                                      N'Chi' AS Loai,
                                      N'Chứng từ cầm đồ' AS Phan_Loai,
                                      N'Cầm đồ' AS Ten_Loai,
                                      ct.Ghi_Chu,
                                      ct.Ten_Khach_Hang,
                                      ct.Sap_Xep
                               FROM   CHUNG_TU ct
                               WHERE  DATEDIFF(DAY, @FromDate, ct.Ngay) >= 0
                                      AND DATEDIFF(DAY, @ToDate, ct.Ngay) <= 0
                           )DANH_SACH
                       
                DECLARE @Ma NVARCHAR(250)
                DECLARE @So NVARCHAR(250)
                DECLARE @Ngay DATETIME
                DECLARE @Ngay_Ghi_So DATETIME
                DECLARE @Ma_Chung_Tu_Cam_Do NVARCHAR(250)
                DECLARE @So_Tien_Thu MONEY
                DECLARE @So_Tien_Chi MONEY
                DECLARE @Tien_Lai_Cu MONEY
                DECLARE @Loai NVARCHAR(50)
                DECLARE @Phan_Loai NVARCHAR(50)
                DECLARE @Ten_Loai NVARCHAR(50)
                DECLARE @Ghi_Chu NVARCHAR(250)
                DECLARE @Ten_Khach_Hang NVARCHAR(250)
                DECLARE @Sap_Xep BIGINT 
                            
                DECLARE @So_Tien_Ton MONEY

                SELECT @So_Tien_Ton = SUM(DAU_KY.So_Tien_Thu - DAU_KY.So_Tien_Chi)
                FROM   (
                           SELECT cttc.So_Tien_Thu,
                                  cttc.So_Tien_Chi,
                                  cttc.Loai
                           FROM   CHUNG_TU_THU_CHI cttc
                                  LEFT OUTER JOIN CHUNG_TU ct
                                       ON  cttc.Ma_Chung_Tu_Cam_Do = ct.Ma_Chung_Tu
                           WHERE  DATEDIFF(DAY, @FromDate, cttc.Ngay) < 0
                           
                           UNION ALL
                           
                           SELECT 0 AS So_Tien_Thu,
                                  ct.So_Tien_Cam AS So_Tien_Chi,
                                  N'Chi' AS Loai
                           FROM   CHUNG_TU ct
                           WHERE  DATEDIFF(DAY, @FromDate, ct.Ngay) < 0
                       )DAU_KY

                SET @So_Tien_Ton = ISNULL(@So_Tien_Ton, 0)

                INSERT INTO @Bang_Quy_Tien_Mat
                  (
                    So_Tien_Ton,
                    Ghi_Chu
                  )
                VALUES
                  (
                    @So_Tien_Ton,
                    N'Số dư đầu kỳ'
                  )

                            
                            OPEN getDanhSach
                            FETCH NEXT FROM getDanhSach INTO @Ma, @So, @Ngay, @Ngay_Ghi_So,
                                                              @Ma_Chung_Tu_Cam_Do, @So_Tien_Thu,
                                                              @So_Tien_Chi, @Tien_Lai_Cu, @Loai,
                                                              @Phan_Loai, @Ten_Loai, @Ghi_Chu,
                                                              @Ten_Khach_Hang, @Sap_Xep  
                                                              
                WHILE @@FETCH_STATUS = 0
                BEGIN
                    PRINT @Ma
                    
                    SET @So_Tien_Ton = @So_Tien_Ton + @So_Tien_Thu - @So_Tien_Chi
                    INSERT INTO @Bang_Quy_Tien_Mat
                      (
                        Ma,
                        So,
                        Ngay,
                        Ngay_Ghi_So,
                        Ma_Chung_Tu_Cam_Do,
                        So_Tien_Thu,
                        So_Tien_Chi,
                        So_Tien_Ton,
                        Tien_Lai_Cu,
                        Loai,
                        Phan_Loai,
                        Ten_Loai,
                        Ghi_Chu,
                        Ten_Khach_Hang,
                        Sap_Xep
                      )
                    VALUES
                      (
                        @Ma,
                        @So,
                        @Ngay,
                        @Ngay_Ghi_So,
                        @Ma_Chung_Tu_Cam_Do,
                        @So_Tien_Thu,
                        @So_Tien_Chi,
                        @So_Tien_Ton,
                        @Tien_Lai_Cu,
                        @Loai,
                        @Phan_Loai,
                        @Ten_Loai,
                        @Ghi_Chu,
                        @Ten_Khach_Hang,
                        @Sap_Xep
                      )
                    FETCH NEXT FROM getDanhSach INTO @Ma, @So, @Ngay, @Ngay_Ghi_So,
                    @Ma_Chung_Tu_Cam_Do, @So_Tien_Thu,
                    @So_Tien_Chi, @Tien_Lai_Cu, @Loai,
                    @Phan_Loai, @Ten_Loai, @Ghi_Chu,
                    @Ten_Khach_Hang, @Sap_Xep
                END   

                CLOSE getDanhSach   
                DEALLOCATE getDanhSach          

                INSERT INTO @Bang_Quy_Tien_Mat
                  (
                    So_Tien_Ton,
                    Ghi_Chu
                  )
                VALUES
                  (
                    @So_Tien_Ton,
                    N'Số dư cuối kỳ'
                  )

                SELECT *
                FROM   @Bang_Quy_Tien_Mat bqtm
            ";

            string[] myPara = { "@FromDate", "@ToDate" };
            object[] myValue = { dtTu.DateTime, dtDen.DateTime };

            var mySql = new SqlHelper();

            dsQuyTienMat.Quy_Tien_Mat_Theo_Ngay.Rows.Clear();
            dsQuyTienMat.Quy_Tien_Mat_Theo_Ngay.Merge(mySql.ExecuteDataTable(sql, myPara, myValue));

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

        private void bbiXuatExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var xuly = new XuLy();
            xuly.Export(gbList);
        }

        
    }
}
