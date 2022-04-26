using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Diagnostics;
using System.IO;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraPrinting;

namespace Phan_Mem_Quan_Ly_Cam_Do.DoiTuong
{
    public class XuLy : DevExpress.XtraEditors.XtraUserControl
    {
        private BaseView _exportView;

        public XuLy()
        { 
        
        }

        public void Export(BaseView view)
        {
            _exportView = view;
            Export();
        }

        public void Export()
        {
            SaveFileDialog sDlg = new SaveFileDialog();
            sDlg.Filter = "Microsoft Excel 97-2003(*.xls)|*.xls|Microsoft Excel 2007(*.xlsx)|*.xlsx|PDF(*.pdf)|*.pdf|Rich Text Format(*.rtf)|*.rtf|Webpage (*.htm)|*.htm";
            sDlg.FilterIndex = 0;
            sDlg.ShowDialog();
            if (sDlg.FileName != null)
            {
                try
                {
                    //btnExports.Enabled = false;

                    if (sDlg.FilterIndex == 1)
                    {
                        ExportToEx(sDlg.FileName, "xls");
                    }
                    else if (sDlg.FilterIndex == 2)
                    {
                        ExportToEx(sDlg.FileName, "xlsx");
                    }
                    else if (sDlg.FilterIndex == 3)
                    {
                        ExportToEx(sDlg.FileName, "pdf");
                    }
                    else if (sDlg.FilterIndex == 4)
                    {
                        ExportToEx(sDlg.FileName, "rtf");
                    }
                    else if (sDlg.FilterIndex == 5)
                    {
                        ExportToEx(sDlg.FileName, "htm");
                    }
                    //VnMessageBox.Info("Kết xuất thành công.");
                    if (File.Exists(sDlg.FileName))
                    {
                        if (XtraMessageBox.Show("Bạn muốn mở tài liệu này không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                        Process.Start(sDlg.FileName);
                    }

                }
                catch (System.Exception ex)
                {
                    //VnMessageBox.Error(ex.Message);
                    EndExport();
                }
                //btnExports.Enabled = true;
            }
        }

        private void ExportToEx(String filename, string ext)
        {
            StartExport();
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            if (_exportView == null)
            {
                EndExport();
                XtraMessageBox.Show("Đối tượng kết xuất chưa xác định");
                return;
            }

            //DevExpress.XtraPrinting.IPrintingSystem ps = DevExpress.XtraPrinting.PrintHelper.GetCurrentPS();

            DevExpress.XtraPrinting.IPrintingSystem ps = new PrintingSystem();
            
            ps.AfterChange += new DevExpress.XtraPrinting.ChangeEventHandler(Export_ProgressEx);
            if (ext == "rtf") _exportView.ExportToRtf(filename);
            if (ext == "pdf") _exportView.ExportToPdf(filename);
            if (ext == "mht") _exportView.ExportToMht(filename);
            if (ext == "htm") _exportView.ExportToHtml(filename, new HtmlExportOptions("utf-8"));
            if (ext == "txt") _exportView.ExportToText(filename, new TextExportOptions(" ", Encoding.Unicode));
            if (ext == "xls")
            {
                _exportView.ExportToXls(filename, new XlsExportOptions(TextExportMode.Value, true));
            }
#pragma warning disable 618,612
            if (ext == "xlsOld")
            {
                _exportView.ExportToExcelOld(filename);
            }

#pragma warning restore 618,612
            if (ext == "xlsx")
            {
                _exportView.ExportToXlsx(filename, new XlsxExportOptions(TextExportMode.Value, true));
            }
            ps.AfterChange -= new DevExpress.XtraPrinting.ChangeEventHandler(Export_ProgressEx);
            Cursor.Current = currentCursor;
            EndExport();

        }


        protected void Export_ProgressEx(object sender, DevExpress.XtraPrinting.ChangeEventArgs e)
        {
            if (e.EventName == DevExpress.XtraPrinting.SR.ProgressPositionChanged)
            {
                int pos = (int)e.ValueOf(DevExpress.XtraPrinting.SR.ProgressPosition);
                progressForm.SetProgressValue(pos);
            }
        }

        private void StartExport()
        {
            //if (this != null) MenuForm.Update();
            progressForm = new ProgressForm(this);
            progressForm.Show();
            progressForm.Refresh();
        }

        private void EndExport()
        {
            if (progressForm != null) progressForm.Dispose();
            progressForm = null;
        }
        private ProgressForm progressForm = null;
    }
}
