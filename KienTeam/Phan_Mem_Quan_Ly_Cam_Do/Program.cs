using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Phan_Mem_Quan_Ly_Cam_Do.GiaoDienChinh;

namespace Phan_Mem_Quan_Ly_Cam_Do
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DanhSachChucNang());
        }
    }
}
