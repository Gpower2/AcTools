using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;

using AcTools.Core;
using AcTools.CommonForms;

namespace AcTools
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                AcSettings.Load();
                Application.Run(new frmMain());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("Unhandled exception!\r\n" + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
