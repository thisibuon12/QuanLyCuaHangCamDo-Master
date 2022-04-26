using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Phan_Mem_Quan_Ly_Cam_Do.DoiTuong;
using System.Data.SqlClient;

namespace Phan_Mem_Quan_Ly_Cam_Do.ThuChi
{
    public partial class frmChiTietTinhTienLoi : Form
    {
        public delegate void ReloadEventHander(object sender);

        public event ReloadEventHander Reload;
        private void RaiseReloadEventHander()
        {
            if (Reload != null)
            {
                Reload(this);
            }
        }

        private decimal sotiencam;
        private DateTime ngayghisocamdo;
        private int loaithu;
        private string machungtucamdo;
        private string tenkhachhang;
        private string socmnd;
        private string socamdo;

        public frmChiTietTinhTienLoi()
        {
            InitializeComponent();
        }

        public void Thiet_Lap(string ma_chung_tu_cam_do, string so, string ten_khach_hang, string so_cmnd, decimal so_tien_cam, decimal lai_suat_thang, DateTime ngay_ghi_so_cam_do ,int loai_thu)
        {
            machungtucamdo = ma_chung_tu_cam_do;
            socamdo = so;
            tenkhachhang = ten_khach_hang;
            socmnd = so_cmnd;
            sotiencam = so_tien_cam;
            ngayghisocamdo = ngay_ghi_so_cam_do;
            loaithu = loai_thu;

            txtMaChungTuCamDo.Text = ma_chung_tu_cam_do;
            txtSo.Text = so;
            txtTenKhachhang.Text = ten_khach_hang;
            txtSoCMND.Text = so_cmnd;
            txtLaiSuatThang.Value = lai_suat_thang;
            txtSoTienCam.Value = so_tien_cam;
            txtNgayCamDo.DateTime = ngay_ghi_so_cam_do;

            txtMaChungTuCamDo.Properties.ReadOnly = true;
            txtSo.Properties.ReadOnly = true;
            txtTenKhachhang.Properties.ReadOnly = true;
        }

        public frmChiTietTinhTienLoi(string ma, DateTime ngayTinhLai)
        {
            InitializeComponent();

            DB_Quan_Ly_Cam_DoDataContext db = new DB_Quan_Ly_Cam_DoDataContext(SqlHelper.ConnectionString);

            txtMaChungTuCamDo.Properties.ReadOnly = true;
            txtSo.Properties.ReadOnly = true;
            txtTenKhachhang.Properties.ReadOnly = true;

            var ctcd = (from cd in db.CHUNG_TUs
                        where cd.Ma_Chung_Tu == ma
                        select cd).FirstOrDefault();

            if (ctcd != null)
            {
                txtSo.Text = ctcd.So;
                txtTenKhachhang.Text = ctcd.Ten_Khach_Hang;
                txtSoCMND.Text = ctcd.So_CMND;
                txtLaiSuatThang.Value = ctcd.Lai_Suat_Thang ?? 0;
                txtSoTienCam.Value = ctcd.So_Tien_Cam ?? 0;
                txtNgayCamDo.DateTime = ctcd.Ngay ?? DateTime.MinValue;
                txtMaChungTuCamDo.Text = ma;
                txtGhi_Chu.Text = ctcd.Ghi_Chu;
            }

            machungtucamdo = txtMaChungTuCamDo.Text;
            socamdo = txtSo.Text;
            ngayghisocamdo = txtNgayCamDo.DateTime;
            socmnd = txtSoCMND.Text;
            tenkhachhang = txtTenKhachhang.Text;

            string sql =
            @"
                --DECLARE @Ma_CT VARCHAR(200)
                --DECLARE @Ngay_Tinh_Lai DATETIME
                --                
                --SET @Ma_CT = 'test'
                --SET @Ngay_Tinh_Lai = GETDATE()

                DECLARE @Chi_Tiet_Tinh_Tien_Lai TABLE (
                            Ma VARCHAR(200) NULL,
                            Ngay_Ghi_So DATETIME NULL,
                            So_Tien_Thu MONEY NULL,
                            So_Tien_Chi MONEY NULL,
                            Ma_Phan_Loai VARCHAR(200) NULL,
                            So_Thang_Cam MONEY NULL,
                            So_Ngay_Cam MONEY NULL,
                            So_Tien_Cam MONEY NULL,
                            Tien_Lai MONEY NULL,
                            Ghi_Chu NVARCHAR(250) NULL
                        )

                DECLARE @So_Tien_Cam_Do MONEY
                DECLARE @Ngay_Ghi_So_Cam_Do DATETIME
                DECLARE @Lai_Suat_Thang_Cam_Do MONEY
                DECLARE @Lai_Suat_Ngay_Cam_Do MONEY
                DECLARE @Ngay_Ghi_So_Cuoi_Cung DATETIME

                SELECT @So_Tien_Cam_Do = ct.So_Tien_Cam,
                        @Ngay_Ghi_So_Cam_Do        = ct.Ngay,
                        @Lai_Suat_Thang_Cam_Do     = ct.Lai_Suat_Thang,
                        @Lai_Suat_Ngay_Cam_Do      = ct.Lai_Suat_Ngay,
                        @Ngay_Ghi_So_Cuoi_Cung     = ct.Ngay
                FROM   CHUNG_TU ct
                WHERE  ct.Ma_Chung_Tu = @Ma_CT

                DECLARE @Ma VARCHAR(200)
                DECLARE @Ngay_Ghi_So DATETIME
                DECLARE @So_Tien_Thu MONEY
                DECLARE @So_Tien_Chi MONEY
                DECLARE @Ma_Phan_Loai VARCHAR(200)
                DECLARE @Ghi_Chu NVARCHAR(250)

                DECLARE @Tien_Lai_Tam MONEY
                DECLARE @Tien_Cam_Do_Tam MONEY

                SET @Tien_Lai_Tam = 0
                SET @Tien_Cam_Do_Tam = @So_Tien_Cam_Do
                       
                DECLARE db_cursor CURSOR  
                FOR
                    SELECT cttc.Ma,
                            cttc.Ngay_Ghi_So,
                            cttc.So_Tien_Thu,
                            cttc.So_Tien_Chi,
                            cttc.Ma_Phan_Loai,
                            cttc.Ghi_Chu
                    FROM   CHUNG_TU_THU_CHI cttc
                    WHERE  cttc.Ma_Chung_Tu_Cam_Do = @Ma_CT
                    ORDER BY
                            cttc.Ngay_Ghi_So

                                OPEN db_cursor  
                                FETCH NEXT FROM db_cursor INTO @Ma,@Ngay_Ghi_So,@So_Tien_Thu, @So_Tien_Chi,
                                                                @Ma_Phan_Loai, @Ghi_Chu  

                WHILE @@FETCH_STATUS = 0
                BEGIN
                    IF (@Ma_Phan_Loai != 'Loi')
                    BEGIN
                        SET @Tien_Lai_Tam = (
                                @Tien_Cam_Do_Tam / 100 * @Lai_Suat_Thang_Cam_Do * dbo.Lay_Thang(@Ngay_Ghi_So_Cuoi_Cung, @Ngay_Ghi_So)
                            ) + (
                                @Tien_Cam_Do_Tam / 100 * @Lai_Suat_Ngay_Cam_Do * dbo.Lay_Ngay(@Ngay_Ghi_So_Cuoi_Cung, @Ngay_Ghi_So)
                            )
        
                        IF (@Ma_Phan_Loai = 'Them' OR @Ma_Phan_Loai = 'Bot')
                        BEGIN
                            SET @Tien_Cam_Do_Tam = @Tien_Cam_Do_Tam + (@So_Tien_Chi - @So_Tien_Thu)
                            --SET @Ngay_Ghi_So_Cuoi_Cung = @Ngay_Ghi_So
                        END
                    END
    
                    INSERT INTO @Chi_Tiet_Tinh_Tien_Lai
                        (
                        Ma,
                        Ngay_Ghi_So,
                        So_Tien_Thu,
                        So_Tien_Chi,
                        Ma_Phan_Loai,
                        So_Thang_Cam,
                        So_Ngay_Cam,
                        So_Tien_Cam,
                        Tien_Lai,
                        Ghi_Chu
                        )
                    VALUES
                        (
                        @Ma,
                        @Ngay_Ghi_So,
                        @So_Tien_Thu,
                        @So_Tien_Chi,
                        @Ma_Phan_Loai,
                        dbo.Lay_Thang(@Ngay_Ghi_So_Cuoi_Cung, @Ngay_Ghi_So),
                        dbo.Lay_Ngay(@Ngay_Ghi_So_Cuoi_Cung, @Ngay_Ghi_So),
                        @Tien_Cam_Do_Tam,
                        @Tien_Lai_Tam,
                        @Ghi_Chu
                        )
                        IF (@Ma_Phan_Loai = 'Them' OR @Ma_Phan_Loai = 'Bot')
                        BEGIN
                            --SET @Tien_Cam_Do_Tam = @Tien_Cam_Do_Tam + (@So_Tien_Chi - @So_Tien_Thu)
                            SET @Ngay_Ghi_So_Cuoi_Cung = @Ngay_Ghi_So
                        END
                    SET @Tien_Lai_Tam = 0
    
                    FETCH NEXT FROM db_cursor INTO @Ma,@Ngay_Ghi_So,@So_Tien_Thu, @So_Tien_Chi,
                    @Ma_Phan_Loai, @Ghi_Chu
                END  

                                CLOSE db_cursor  
                                DEALLOCATE db_cursor 
                
                                /*them 1 dong tinh tien lai cuoi cung*/
                                -------------------------------------------------------------------
                
                SET @Tien_Lai_Tam = (
                                        @Tien_Cam_Do_Tam / 100 * @Lai_Suat_Thang_Cam_Do * dbo.Lay_Thang(@Ngay_Ghi_So_Cuoi_Cung, @Ngay_Tinh_Lai)
                                    ) + (
                                        @Tien_Cam_Do_Tam / 100 * @Lai_Suat_Ngay_Cam_Do * dbo.Lay_Ngay(@Ngay_Ghi_So_Cuoi_Cung, @Ngay_Tinh_Lai)
                                    )
                
                INSERT INTO @Chi_Tiet_Tinh_Tien_Lai
                    (
                    Ma,
                    Ngay_Ghi_So,
                    So_Tien_Thu,
                    So_Tien_Chi,
                    Ma_Phan_Loai,
                    So_Thang_Cam,
                    So_Ngay_Cam,
                    So_Tien_Cam,
                    Tien_Lai,
                    Ghi_Chu
                    )
                VALUES
                    (
                    CAST(NULL AS VARCHAR(200)),	--@Ma,
                    @Ngay_Tinh_Lai,	--@Ngay_Ghi_So,
                    CAST(NULL AS MONEY),	--@So_Tien_Thu,
                    CAST(NULL AS MONEY),	--@So_Tien_Chi,
                    CAST(NULL AS VARCHAR(5)),	--@Ma_Phan_Loai,
                    dbo.Lay_Thang(@Ngay_Ghi_So_Cuoi_Cung, @Ngay_Tinh_Lai),	--dbo.Lay_Thang(@Ngay_Ghi_So_Cam_Do, @Ngay_Ghi_So),
                    dbo.Lay_Ngay(@Ngay_Ghi_So_Cuoi_Cung, @Ngay_Tinh_Lai),	--dbo.Lay_Ngay(@Ngay_Ghi_So_Cam_Do, @Ngay_Ghi_So),
                    @Tien_Cam_Do_Tam,
                    @Tien_Lai_Tam,
                    N'Tiền lãi khi chuộc' --@Ghi_Chu
                    )
                                -------------------------------------------------------------------

                SELECT *,
                        @Ngay_Ghi_So_Cuoi_Cung,
                        @Tien_Cam_Do_Tam
                FROM   @Chi_Tiet_Tinh_Tien_Lai ctttl
       
                        --DECLARE @Tong_Tien_Lai MONEY
                        --DECLARE @Tong_Thu_Tien_Lai MONEY
                        --
                        --SELECT @Tong_Tien_Lai = SUM(ctttl.Tien_Lai)
                        --FROM   @Chi_Tiet_Tinh_Tien_Lai ctttl
                        --
                        --SELECT @Tong_Thu_Tien_Lai = SUM(cttc.So_Tien_Thu)
                        --FROM   CHUNG_TU_THU_CHI cttc
                        --WHERE  cttc.Ma_Chung_Tu_Cam_Do = @Ma_CT
                        --       AND cttc.Ma_Phan_Loai = 'Loi'
                        --
                        --SELECT ROUND(
                        --           (ISNULL(@Tong_Tien_Lai, 0) - ISNULL(@Tong_Thu_Tien_Lai, 0)) + (
                        --               dbo.Lay_Thang(@Ngay_Ghi_So_Cuoi_Cung, @Ngay_Tinh_Lai) * (@Tien_Cam_Do_Tam / 100)
                        --               * @Lai_Suat_Thang_Cam_Do
                        --           ) + (
                        --               dbo.Lay_Ngay(@Ngay_Ghi_So_Cuoi_Cung, @Ngay_Tinh_Lai) * (@Tien_Cam_Do_Tam / 100)
                        --               * @Lai_Suat_Ngay_Cam_Do
                        --           ),-3
                        --       )
            ";

            dsThuChi.CHI_TIET_TINH_TIEN_LAI.Rows.Clear();

            SqlConnection conn = new SqlConnection(SqlHelper.ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;

            cmd.Parameters.AddWithValue("@Ma_CT", ma);
            cmd.Parameters.AddWithValue("@Ngay_Tinh_Lai", ngayTinhLai);

            try
            {
                conn.Open();
                dsThuChi.CHI_TIET_TINH_TIEN_LAI.Load(cmd.ExecuteReader());
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            gbList.BestFitColumns();
        }

        private void bbiDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
            
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
    }
}
