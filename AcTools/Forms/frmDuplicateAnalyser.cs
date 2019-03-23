using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using AcTools.Core;
using AcToolsLibrary.Common;
using AcToolsLibrary.Core.Video;
using AcToolsLibrary.Core.Parsers;

namespace AcTools.Forms
{
    public partial class frmDuplicateAnalyser : AcForm
    {
        VideoFrameList vfl = new VideoFrameList();

        /// <summary>
        /// Default constructor
        /// </summary>
        public frmDuplicateAnalyser()
        {
            InitializeComponent();
            Init();
        }

        /// <summary>
        /// Opens the form with a prespecified file
        /// </summary>
        /// <param name="dupFile">the prespecified file</param>
        public frmDuplicateAnalyser(String dupFile)
        {
            InitializeComponent();
            Init();
            txtDuplicatesFile.Text = dupFile;
            AnalyseDuplicates();
        }

        private void Init()
        {
            InitColors();
            InitControls();
            InitIcon();
            fillComboThreshold();
            this.Text = "Duplicate Analyser";
        }

        private void txtDuplicatesFile_DragEnter(object sender, DragEventArgs e)
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

        private void txtDuplicatesFile_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                String[] s = (String[])e.Data.GetData(DataFormats.FileDrop, false);
                txtDuplicatesFile.Text = s[0];
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnBrowseDuplicatesFile_Click(object sender, EventArgs e)
        {
            try
            {
                String[] filenames = ShowOpenFileDialog("Select Duplicates File", "", "", false);
                if (filenames != null)
                {
                    if (filenames.Length > 0)
                    {
                        txtDuplicatesFile.Text = filenames[0];
                    }
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnHook_Click(object sender, EventArgs e)
        {
            HookUnHook(btnHook);
        }

        private void btnAnalyseDuplicates_Click(object sender, EventArgs e)
        {
            try
            {
                AnalyseDuplicates();
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex, "Error in analysing duplicates!");
            }
        }

        private void AnalyseDuplicates()
        {
            DuplicateParser.ParseDup(txtDuplicatesFile.Text, vfl);
            listDuplicates.Items.Clear();
            listDuplicates.Items.Add(String.Format("Total Frames : {0}", vfl.Count));
            refreshMap(true);
        }

        private void fillComboThreshold()
        {
            comMapThreshold.Items.Clear();
            comMapThreshold.Items.Add("50");
            comMapThreshold.Items.Add("40");
            comMapThreshold.Items.Add("30");
            comMapThreshold.Items.Add("20");
            comMapThreshold.Items.Add("10");
            comMapThreshold.Items.Add("5");
            comMapThreshold.SelectedIndex = 2;
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
            picMap.Image = DuplicateParser.GetMapBitmap(picMap.Width, picMap.Height, vfl, trackMap.Value, Convert.ToDecimal(comMapThreshold.SelectedItem));
        }

        private void trackMap_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (vfl.HasDuplicates)
                {
                    refreshMap(false);
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void DuplicateAnalyserForm_Resize(object sender, EventArgs e)
        {
            try
            {
                if (vfl.HasDuplicates)
                {
                    refreshMap(true);
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnRefreshMap_Click(object sender, EventArgs e)
        {
            try
            {
                if (vfl.HasDuplicates)
                {
                    refreshMap(true);
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }
    }
}
