using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

using AcTools.Core;
using AcToolsLibrary.Common;
using AcToolsLibrary.Core.Video;
using AcToolsLibrary.Core.Parsers;

namespace AcTools.Forms
{
    public partial class frmTimeCodeAnalyser : AcForm
    {
        private VideoFrameList vfl = new VideoFrameList();

        /// <summary>
        /// Default constructor
        /// </summary>
        public frmTimeCodeAnalyser()
        {
            InitializeComponent();
            Init();
        }

        /// <summary>
        /// Opens the form with a prespecified file
        /// </summary>
        /// <param name="timecodesFile">the prespecified file</param>
        public frmTimeCodeAnalyser(String timecodesFile)
        {
            InitializeComponent();
            Init();
            txtTimecodesFile.Text = timecodesFile;
            AnalyseTimecodes();
        }

        private void Init()
        {
            InitColors();
            InitControls();
            InitIcon();
            this.Text = "TimeCodes Analyser";
            numAccuracyDecimalDigits.Value = 3;
        }

        public override void InitControls()
        {
            base.InitControls();
            InitLegend();
        }

        private void btnTimecodeAnalyse_Click(object sender, EventArgs e)
        {
            try
            {
                AnalyseTimecodes();
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex, "Error in opening timecodes!");
            }
        }

        private void AnalyseTimecodes()
        {
            vfl.LoadTimecodes(txtTimecodesFile.Text, false, Convert.ToInt32(numAccuracyDecimalDigits.Value));
            String formatString = "000.".PadRight(4 + Convert.ToInt32(numAccuracyDecimalDigits.Value), '0');
            listTimecodes.Items.Clear();
            listTimecodes.Items.Add(String.Format("Total frames : {0}", vfl.Count));
            listTimecodes.Items.Add(String.Format("IsCFR : {0}", vfl.IsCFR));
            foreach (VideoFrameListStat vfls in vfl.FrameListStats)
            {
                listTimecodes.Items.Add(String.Format("FrameRate : {0} Duration : {1} Count : {2} {3}%",
                    vfls.FrameRate.ToString(formatString,CultureInfo.InvariantCulture),
                    vfls.FrameDuration.ToString(formatString, CultureInfo.InvariantCulture),
                    vfls.FrameCount.ToString("000000"),
                    (Convert.ToDouble(vfls.FrameCount) * 100.0 / Convert.ToDouble(vfl.Count)).ToString("000.000000", CultureInfo.InvariantCulture)));
            }
            refreshMap(true);
        }

        private void btnHook_Click(object sender, EventArgs e)
        {
            HookUnHook(btnHook);
        }

        private void btnBrowseTimecodesFile_Click(object sender, EventArgs e)
        {
            try
            {
                String[] filenames = ShowOpenFileDialog("Select Timecodes File", "", "", false);
                if (filenames != null)
                {
                    if (filenames.Length > 0)
                    {
                        txtTimecodesFile.Text = filenames[0];
                    }
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void txtTimecodesFile_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                String[] s = (String[])e.Data.GetData(DataFormats.FileDrop, false);
                txtTimecodesFile.Text = s[0];
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void txtTimecodesFile_DragEnter(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                    e.Effect = DragDropEffects.All;
                else
                    e.Effect = DragDropEffects.None;
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void refreshMap(Boolean resize)
        {
            if (resize)
            {
                Int32 newSteps = Convert.ToInt32(Convert.ToDouble(vfl.Count) / Convert.ToDouble(picMap.Width) + 0.5);
                Int32 oldSteps = trackMap.Maximum + 1;
                Int32 oldValue = trackMap.Value;
                Int32 newValue = Convert.ToInt32(Convert.ToDouble(newSteps * oldValue) / Convert.ToDouble(oldSteps));
                trackMap.Minimum = 0;
                trackMap.Maximum = newSteps - 1;
                trackMap.Value = newValue;
            }
            lblMapFrames.Text = String.Format("({0} - {1})", (trackMap.Value * picMap.Width), ((trackMap.Value + 1) * picMap.Width));
            if (picMap.Image != null)
            {
                picMap.Image.Dispose();
            }
            picMap.Image = TimeCodeParser.GetMapBitmap(picMap.Width, picMap.Height, vfl, trackMap.Value);
        }

        private void TimeCodeAnalyserForm_Resize(object sender, EventArgs e)
        {
            try
            {
                if (vfl.HasTimecodes)
                {
                    refreshMap(true);
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void trackMap_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (vfl.HasTimecodes)
                {
                    refreshMap(false);
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void InitLegend()
        {
            Bitmap bmpLegend = new Bitmap(picLegendMap.Width, picLegendMap.Height);
            Graphics g = Graphics.FromImage(bmpLegend);
            g.FillRectangle(new SolidBrush(Color.FromArgb(AcSettings.Instance.FormBackColor)), 0, 0, picLegendMap.Width, picLegendMap.Height);
            Int32 x = 0;
            g.DrawString("24", new Font(FontFamily.GenericMonospace, 8), Brushes.Blue, x, 0);
            x += Convert.ToInt32(g.MeasureString("24", new Font(FontFamily.GenericMonospace, 8)).Width) + 3;
            g.DrawString("30", new Font(FontFamily.GenericMonospace, 8), Brushes.ForestGreen, x, 0);
            x += Convert.ToInt32(g.MeasureString("30", new Font(FontFamily.GenericMonospace, 8)).Width) + 3;
            g.DrawString("60", new Font(FontFamily.GenericMonospace, 8), Brushes.Orange, x, 0);
            x += Convert.ToInt32(g.MeasureString("60", new Font(FontFamily.GenericMonospace, 8)).Width) + 3;
            g.DrawString("15", new Font(FontFamily.GenericMonospace, 8), Brushes.White, x, 0);
            x += Convert.ToInt32(g.MeasureString("15", new Font(FontFamily.GenericMonospace, 8)).Width) + 3;
            g.DrawString("other", new Font(FontFamily.GenericMonospace, 8), Brushes.Red, x, 0);
            x += Convert.ToInt32(g.MeasureString("other", new Font(FontFamily.GenericMonospace, 8)).Width) + 3;
            g.DrawString("no video", new Font(FontFamily.GenericMonospace, 8), Brushes.Black, x, 0);
            picLegendMap.Image = bmpLegend;
        }
    }
}
