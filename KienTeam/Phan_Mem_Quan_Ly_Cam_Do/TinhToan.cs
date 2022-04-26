using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Phan_Mem_Quan_Ly_Cam_Do.DoiTuong;
using System.Globalization;

namespace Phan_Mem_Quan_Ly_Cam_Do
{
    public class TinhToan
    {
        public decimal Tinh_Tien_Lai(decimal SoTien, decimal LaiSuatThang, DateTime NgayGhiSoCamDo, DateTime NgayLapPhieuThu)
        {
            decimal tongTienLai = 0;
            string sql =
            @"
                --DECLARE @NgayGhiSoCamDo DATETIME
                --DECLARE @NgayGhiSoPhieuThu DATETIME
                --DECLARE @SoTien MONEY
                --DECLARE @LaiSuatThang MONEY
                --
                --SET @NgayGhiSoCamDo = CAST('2012-08-22' AS DATETIME)
                --SET @NgayGhiSoPhieuThu = CAST('2013-09-23' AS DATETIME)
                --SET @SoTien = 2500000
                --SET @LaiSuatThang = 3

                DECLARE @LaiTheoThang MONEY
                DECLARE @LaiTheoNgay MONEY

                SET @LaiTheoThang = 0
                SET @LaiTheoNgay = 0


                SELECT @LaiTheoThang = (
                           dbo.Lay_Thang(@NgayGhiSoCamDo, @NgayGhiSoPhieuThu) * (@SoTien / 100) 
                           * @LaiSuatThang
                       ),
                       @LaiTheoNgay = (((@SoTien / 100) * @LaiSuatThang) / 30) * dbo.Lay_Ngay(@NgayGhiSoCamDo, @NgayGhiSoPhieuThu)
                                       
                SELECT ROUND(ISNULL(@LaiTheoThang, 0) + ISNULL(@LaiTheoNgay, 0), -3)
            ";

            SqlConnection conn = new SqlConnection(SqlHelper.ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@SoTien", SoTien);
            cmd.Parameters.AddWithValue("@LaiSuatThang", LaiSuatThang);
            cmd.Parameters.AddWithValue("@NgayGhiSoCamDo", NgayGhiSoCamDo);
            cmd.Parameters.AddWithValue("@NgayGhiSoPhieuThu", NgayLapPhieuThu);

            try
            {
                conn.Open();
                tongTienLai = (Decimal)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                tongTienLai = 0;
            }

            return tongTienLai;
        }

        public decimal Tinh_Tien_Lai_Theo_Chung_Tu(string ma, DateTime ngayLapPhieuThu)
        {
            decimal tongTienLai = 0;
//            string sql =
//            @"
//                --DECLARE @Ma_CT VARCHAR(200)
//                --DECLARE @Ngay_Tinh_Lai DATETIME
//                --
//                --SET @Ma_CT = 'test'
//                --SET @Ngay_Tinh_Lai = GETDATE()
//
//                DECLARE @Chi_Tiet_Tinh_Tien_Lai TABLE (
//                            Ma VARCHAR(200) NULL,
//                            Ngay_Ghi_So DATETIME NULL,
//                            So_Tien_Thu MONEY NULL,
//                            So_Tien_Chi MONEY NULL,
//                            Ma_Phan_Loai VARCHAR(200) NULL,
//                            So_Thang_Cam MONEY NULL,
//                            So_Ngay_Cam MONEY NULL,
//                            So_Tien_Cam MONEY NULL,
//                            Tien_Lai MONEY NULL,
//                            Ghi_Chu NVARCHAR(250) NULL
//                        )
//
//                DECLARE @So_Tien_Cam_Do MONEY
//                DECLARE @Ngay_Ghi_So_Cam_Do DATETIME
//                DECLARE @Lai_Suat_Thang_Cam_Do MONEY
//                DECLARE @Lai_Suat_Ngay_Cam_Do MONEY
//                DECLARE @Ngay_Ghi_So_Cuoi_Cung DATETIME
//
//                SELECT @So_Tien_Cam_Do = ct.So_Tien_Cam,
//                       @Ngay_Ghi_So_Cam_Do = ct.Ngay,
//                       @Lai_Suat_Thang_Cam_Do = ct.Lai_Suat_Thang,
//                       @Lai_Suat_Ngay_Cam_Do = ct.Lai_Suat_Ngay,
//                       @Ngay_Ghi_So_Cuoi_Cung = ct.Ngay
//                FROM   CHUNG_TU ct
//                WHERE  ct.Ma_Chung_Tu = @Ma_CT
//
//                DECLARE @Ma VARCHAR(200)
//                DECLARE @Ngay_Ghi_So DATETIME
//                DECLARE @So_Tien_Thu MONEY
//                DECLARE @So_Tien_Chi MONEY
//                DECLARE @Ma_Phan_Loai VARCHAR(200)
//                DECLARE @Ghi_Chu NVARCHAR(250)
//
//                DECLARE @Tien_Lai_Tam MONEY
//                DECLARE @Tien_Cam_Do_Tam MONEY
//
//                SET @Tien_Lai_Tam = 0
//                SET @Tien_Cam_Do_Tam = @So_Tien_Cam_Do
//                       
//                DECLARE db_cursor CURSOR  
//                FOR
//                    SELECT cttc.Ma,
//                           cttc.Ngay_Ghi_So,
//                           cttc.So_Tien_Thu,
//                           cttc.So_Tien_Chi,
//                           cttc.Ma_Phan_Loai,
//                           cttc.Ghi_Chu
//                    FROM   CHUNG_TU_THU_CHI cttc
//                    WHERE  cttc.Ma_Chung_Tu_Cam_Do = @Ma_CT
//                    ORDER BY
//                           cttc.Ngay_Ghi_So
//
//                OPEN db_cursor  
//                FETCH NEXT FROM db_cursor INTO @Ma,@Ngay_Ghi_So,@So_Tien_Thu, @So_Tien_Chi,
//                                               @Ma_Phan_Loai, @Ghi_Chu  
//
//                WHILE @@FETCH_STATUS = 0
//                BEGIN
//                    IF (@Ma_Phan_Loai != 'Loi')
//                    BEGIN
//                        SET @Tien_Lai_Tam = (
//                                @Tien_Cam_Do_Tam / 100 * @Lai_Suat_Thang_Cam_Do * dbo.Lay_Thang(@Ngay_Ghi_So_Cam_Do, @Ngay_Ghi_So)
//                            ) + (
//                                @Tien_Cam_Do_Tam / 100 * @Lai_Suat_Ngay_Cam_Do * dbo.Lay_Ngay(@Ngay_Ghi_So_Cam_Do, @Ngay_Ghi_So)
//                            )
//                        
//                        IF (@Ma_Phan_Loai = 'Them' OR @Ma_Phan_Loai = 'Bot')
//                        BEGIN
//                            SET @Tien_Cam_Do_Tam = @Tien_Cam_Do_Tam + (@So_Tien_Chi - @So_Tien_Thu)
//                            SET @Ngay_Ghi_So_Cuoi_Cung = @Ngay_Ghi_So
//                        END
//                    END
//                    
//                    INSERT INTO @Chi_Tiet_Tinh_Tien_Lai
//                      (
//                        Ma,
//                        Ngay_Ghi_So,
//                        So_Tien_Thu,
//                        So_Tien_Chi,
//                        Ma_Phan_Loai,
//                        So_Thang_Cam,
//                        So_Ngay_Cam,
//                        So_Tien_Cam,
//                        Tien_Lai,
//                        Ghi_Chu
//                      )
//                    VALUES
//                      (
//                        @Ma,
//                        @Ngay_Ghi_So,
//                        @So_Tien_Thu,
//                        @So_Tien_Chi,
//                        @Ma_Phan_Loai,
//                        dbo.Lay_Thang(@Ngay_Ghi_So_Cam_Do, @Ngay_Ghi_So),
//                        dbo.Lay_Ngay(@Ngay_Ghi_So_Cam_Do, @Ngay_Ghi_So),
//                        @Tien_Cam_Do_Tam,
//                        @Tien_Lai_Tam,
//                        @Ghi_Chu
//                      )
//                    
//                    SET @Tien_Lai_Tam = 0
//                    
//                    FETCH NEXT FROM db_cursor INTO @Ma,@Ngay_Ghi_So,@So_Tien_Thu, @So_Tien_Chi,
//                    @Ma_Phan_Loai, @Ghi_Chu
//                END  
//
//                CLOSE db_cursor  
//                DEALLOCATE db_cursor 
//
//                --SELECT *,
//                --       @Ngay_Ghi_So_Cuoi_Cung,
//                --       @Tien_Cam_Do_Tam
//                --FROM   @Chi_Tiet_Tinh_Tien_Lai ctttl
//
//                DECLARE @Tong_Tien_Lai MONEY
//                DECLARE @Tong_Thu_Tien_Lai MONEY
//
//                SELECT @Tong_Tien_Lai = SUM(ctttl.Tien_Lai)
//                FROM   @Chi_Tiet_Tinh_Tien_Lai ctttl
//
//                SELECT @Tong_Thu_Tien_Lai = SUM(cttc.So_Tien_Thu)
//                FROM   CHUNG_TU_THU_CHI cttc
//                WHERE  cttc.Ma_Chung_Tu_Cam_Do = @Ma_CT
//                       AND cttc.Ma_Phan_Loai = 'Loi'
//                       
//                SELECT ROUND(
//                           (ISNULL(@Tong_Tien_Lai, 0) - ISNULL(@Tong_Thu_Tien_Lai, 0)) + (
//                               dbo.Lay_Thang(@Ngay_Ghi_So_Cuoi_Cung, @Ngay_Tinh_Lai) * (@Tien_Cam_Do_Tam / 100) 
//                               * @Lai_Suat_Thang_Cam_Do
//                           ) + (
//                               dbo.Lay_Ngay(@Ngay_Ghi_So_Cuoi_Cung, @Ngay_Tinh_Lai) * (@Tien_Cam_Do_Tam / 100) 
//                               * @Lai_Suat_Ngay_Cam_Do
//                           ),-3
//                       )
//            ";

            string sql =
            @"
                SELECT dbo.Tinh_Tien_Lai(@Ma_CT, @Ngay_Tinh_Lai)
            ";

            SqlConnection conn = new SqlConnection(SqlHelper.ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Ma_CT", ma);
            cmd.Parameters.AddWithValue("@Ngay_Tinh_Lai", ngayLapPhieuThu);

            try
            {
                conn.Open();
                tongTienLai = (Decimal)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                tongTienLai = 0;
            }

            return tongTienLai;
        }

        public static string DocChu(string Expression)
        {
            string _currencySymbol = "đồng";
            {
                NumberFormatInfo nfi = CultureInfo.CurrentCulture.NumberFormat;
                Expression = Expression.Replace(nfi.NumberGroupSeparator, "");
                if (!IsNumeric(Expression)) return "Không đọc được số";
                string[] num = Expression.Split(Convert.ToChar(nfi.NumberDecimalSeparator));

                //if (_Currency == "VND")
                {
                    Expression = NumToText(num[0]);
                    if (num.Length > 1)
                    {
                        string temp = num[1];
                        if (temp.Length >= 3)
                        {
                            if (temp[0] == '0')
                            {
                                Expression = Expression + " " + _currencySymbol + " phẩy " + "không ";
                                if (temp[1] == '0')
                                {
                                    Expression = Expression + "không " + NumToText(temp[2].ToString());
                                }
                                else
                                {
                                    Expression = Expression + NumToText(temp.Substring(1, 2));
                                }
                            }
                            else
                            {
                                Expression = Expression + " phẩy " + NumToText(temp.Substring(0, 3));
                            }
                        }
                        else if (temp.Length == 2)
                        {
                            if (temp[0] == '0')
                            {
                                Expression = Expression + " phẩy " + "không ";
                                if (temp[1] == '0')
                                {
                                    Expression = Expression + NumToText(temp[1].ToString());
                                }
                                else
                                {
                                    Expression = Expression + NumToText(temp.Substring(1, 1));
                                }
                            }
                            else
                            {
                                Expression = Expression + " " + _currencySymbol + " phẩy " +
                                             NumToText(temp.Substring(0, 2));
                            }
                        }
                        else
                        {
                            Expression = Expression + " " + _currencySymbol + " phẩy " + NumToText(temp[0].ToString());
                        }
                    }
                    else
                    {
                        Expression = Expression + " " + _currencySymbol;
                    }
                    if (Expression.Length > 1)
                        Expression = Expression[0].ToString().ToUpper() + Expression.Substring(1);
                    return Expression;
                }

                if (Expression.Length > 1) Expression = Expression[0].ToString().ToUpper() + Expression.Substring(1);
                return Expression;
            }
        }

        public static bool IsNumeric(object Expression)
        {
            // Variable to collect the Return value of the TryParse method.
            bool isNum;

            // Define variable to collect out parameter of the TryParse method. If the conversion fails, the out parameter is zero.
            double retNum;

            // The TryParse method converts a string in a specified style and culture-specific format to its double-precision floating point number equivalent.
            // The TryParse method does not generate an exception if the conversion fails. If the conversion passes, True is returned. If it does not, False is returned.
            isNum = Double.TryParse(Convert.ToString(Expression), NumberStyles.Any, NumberFormatInfo.InvariantInfo,
                                    out retNum);
            return isNum;
        }

        private static string NumToText(string Expression)
        {
            string[] str;
            string result1 = "";
            string result2 = "";
            string result = "";
            NumberFormatInfo nfi;
            try
            {
                nfi = CultureInfo.CurrentCulture.NumberFormat;
                Expression = (Convert.ToInt64(Expression)).ToString("##,##0");
            }
            catch (ArgumentException Ae)
            {
                return Ae.Message;
            }
            catch (OverflowException Oe)
            {
                return Oe.Message;
            }
            catch (FormatException Fe)
            {
                return Fe.Message;
            }
            str = Expression.Split(Convert.ToChar(nfi.NumberGroupSeparator));
            int i;
            for (i = 0; i < str.Length - 3; i++)
            {
                string temp = str[i];
                if (temp.Equals("000"))
                    continue;
                for (int j = 0; j < temp.Length; j++)
                {
                    if (j < temp.Length - 1)
                    {
                        if ((int.Parse(Convert.ToString(temp[j])) == 1) && (temp.Length - j - 1 == 1))
                            result1 = result1 + " " + outputpostring(temp.Length - j - 1, temp[j], temp[j + 1]);

                        else
                            result1 = result1 + " " + outputnumberstring(temp[j], '0', j, temp.Length) + " " +
                                      outputpostring(temp.Length - j - 1, temp[j], temp[j + 1]);
                    }
                    else if (temp.Length == 1)
                        result1 = result1 + " " + outputnumberstring(temp[j], '0', j, temp.Length) + " " +
                                  outputpostring(temp.Length - j - 1, temp[j], '0');
                    else
                        result1 = result1 + " " + outputnumberstring(temp[j], temp[j - 1], j, temp.Length) + " " +
                                  outputpostring(temp.Length - j - 1, temp[j], '0');
                }
                result1 = result1.Trim();
                result1 = result1 + " " + outputgrouptring(str.Length - i - 1);
            }

            for (; i < str.Length; i++)
            {
                try
                {
                    string temp = str[i];
                    if (temp.Equals("000"))
                        continue;
                    for (int j = 0; j < temp.Length; j++)
                    {
                        if (j < temp.Length - 1)
                        {
                            if ((int.Parse(Convert.ToString(temp[j])) == 1) && (temp.Length - j - 1 == 1))
                                result2 = result2 + " " + outputpostring(temp.Length - j - 1, temp[j], temp[j + 1]);

                            else
                                result2 = result2 + " " + outputnumberstring(temp[j], '0', j, temp.Length) + " " +
                                          outputpostring(temp.Length - j - 1, temp[j], temp[j + 1]);
                        }
                        else if (temp.Length == 1)
                            result2 = result2 + " " + outputnumberstring(temp[j], '0', j, temp.Length) + " " +
                                      outputpostring(temp.Length - j - 1, temp[j], '0');
                        else
                            result2 = result2 + " " + outputnumberstring(temp[j], temp[j - 1], j, temp.Length) + " " +
                                      outputpostring(temp.Length - j - 1, temp[j], '0');
                    }
                    result2 = result2.Trim();
                    result2 = result2 + " " + outputgrouptring(str.Length - i - 1);
                }
                catch (Exception excp)
                {
                    return null;
                }
            }

            result = result1 + ((result1.Equals("")) ? " " : " tỷ ") + result2;
            result = result.Trim();
            //if (result.Length > 1) { result = result[0].ToString().ToUpper() + result.Substring(1); };
            return result;
        }

        private static string outputpostring(int pos, char num, char nextnum)
        {
            switch (pos)
            {
                case 0:
                    return "";

                case 1:
                    if (int.Parse(Convert.ToString(num)) == 1)
                        return "mười";
                    else
                    {
                        if ((int.Parse(Convert.ToString(num)) == 0) && (int.Parse(Convert.ToString(nextnum)) == 0))
                            return "";
                        else if (((int.Parse(Convert.ToString(num)) == 0) && (int.Parse(Convert.ToString(nextnum)) != 0)))
                            return "lẻ";
                        return "mươi";
                    }
                case 2:

                    return "trăm";
            }
            return "";
        }

        private static string outputgrouptring(int group)
        {
            switch (group)
            {
                case 0:
                case 3:
                    return "";
                case 1:
                case 4:
                    return "nghìn";
                case 2:
                case 5:
                    return "triệu";
            }
            return "";
        }

        private static string outputnumberstring(char num, char prenum, int pos, int length)
        {
            switch (int.Parse(Convert.ToString(num)))
            {
                case 0:
                    if (pos >= 1)
                    {
                        //if (int.Parse(Convert.ToString(nextnum)) == 0)
                        return "";
                    }
                    else
                        return "không";

                case 1:
                    if ((pos == length - 1) && (int.Parse(Convert.ToString(prenum)) > 1))
                        return "mốt";
                    return "một";

                case 2:
                    return "hai";

                case 3:
                    return "ba";

                case 4:
                    return "bốn";

                case 5:
                    if ((pos == length - 1) && (!prenum.Equals('0')))
                        return "lăm";
                    else
                        return "năm";
                case 6:
                    return "sáu";

                case 7:
                    return "bảy";

                case 8:
                    return "tám";

                case 9:
                    return "chín";
            }
            return "";
        }

        public static string docTrongLuong(decimal trongluong)
        {
            string so = "";

            int phanchan = 0;
            int phanle = 0;

            phanchan = (int)trongluong;
            phanle = (int)((trongluong * 100) - (phanchan * 100));

            string luong = "";
            string chi = "";
            string phan = "";
            string ly = "";

            luong = (phanchan / 10) > 0 ? (phanchan / 10).ToString() + " lượng" : "";
            chi = (phanchan % 10) > 0 ? (phanchan % 10).ToString() + " chỉ" : "";
            phan = (phanle / 10) > 0 ? (phanle / 10).ToString() + " phân" : "";
            ly = (phanle % 10) > 0 ? (phanle % 10).ToString() + " ly" : "";

            so = luong + (!string.IsNullOrEmpty(luong) ? " " : "") + chi + (!string.IsNullOrEmpty(chi) ? " " : "") + phan + (!string.IsNullOrEmpty(phan) ? " " : "") + ly;
            return so;
        }

        public static decimal So_Tien_Cam(string ma)
        {
            decimal sotiencam = 0;
            string sql =
            @"
                --DECLARE @Ma VARCHAR(200)
                --SET @Ma = 'CD114'

                DECLARE @So_Tien MONEY
                SET @So_Tien = 0

                SELECT @So_Tien = ISNULL(ct.So_Tien_Cam, 0)
                FROM   CHUNG_TU ct
                WHERE  ct.Ma_Chung_Tu = @Ma

                SELECT @So_Tien = @So_Tien + ISNULL(
                           SUM(ISNULL(cttc.So_Tien_Chi, 0) - ISNULL(cttc.So_Tien_Thu, 0)),
                           0
                       )
                FROM   CHUNG_TU_THU_CHI cttc
                WHERE  cttc.Ma_Chung_Tu_Cam_Do = @Ma
                       AND (cttc.Ma_Phan_Loai = 'Them' OR cttc.Ma_Phan_Loai = 'Bot')
                       
                SELECT @So_Tien
            ";

            SqlConnection conn = new SqlConnection(SqlHelper.ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Ma", ma);

            try
            {
                conn.Open();
                sotiencam = (Decimal)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                sotiencam = 0;
            }

            return sotiencam;
        }
    }
}
