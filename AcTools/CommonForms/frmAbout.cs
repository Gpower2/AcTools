using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using AcTools.Core;
using AcToolsLibrary.Common.Windows;
using System.Threading;

namespace AcTools.CommonForms
{
    public partial class frmAbout : AcForm
    {
        public frmAbout()
        {
            InitializeComponent();
            InitControls();
            InitIcon();
            pictureBox1.Image = AcTools.Properties.Resources.acBig;
            StringBuilder aboutTxt = new StringBuilder();
            aboutTxt.AppendFormat("Coded and cared for by the proud AnimeClipse Developer Team!");
            aboutTxt.AppendLine();
            aboutTxt.AppendLine();
            aboutTxt.AppendFormat("Product Name : {0}", Application.ProductName);
            aboutTxt.AppendLine();
            aboutTxt.AppendFormat("Product Version : {0}", Assembly.GetExecutingAssembly().GetName().Version);
            Version ver = Assembly.GetEntryAssembly().GetName().Version;
            DateTime buildDateTime = new DateTime(2000, 1, 1).Add(new TimeSpan(
                TimeSpan.TicksPerDay * ver.Build + // days since 1 January 2000
                TimeSpan.TicksPerSecond * 2 * ver.Revision)); // seconds since midnight, (multiply by 2 to get original)
            aboutTxt.AppendLine();
            aboutTxt.AppendFormat("Product Build date : {0}", buildDateTime.ToString("dd/MM/yyyy HH:mm:ss"));
            txtAbout.Text = aboutTxt.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5000; i++)
            {
                Point originalMousePosition = Cursor.Position;
                Int32 arrowX = 1080;
                Int32 arrowY = 540;
                AcMouseHelper.MouseMove(arrowX, arrowY);
                AcMouseHelper.MouseLeftClick();
                AcMouseHelper.MouseMove(originalMousePosition.X, originalMousePosition.Y);
                Thread.Sleep(20);
            }
        }
    }
}
