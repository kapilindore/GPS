using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace YTGPS_Server
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormMain fmain = new FormMain();
            
            try
            {
                Application.Run(fmain);
            }
            
            catch
            {
                try
                {
                    fmain.ForceClose();
                    Application.Exit();
                }
                catch { }
            }
            //
        }
    }
}