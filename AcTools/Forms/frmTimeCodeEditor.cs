using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

using AcTools.Core;
using AcToolsLibrary.Common;
using AcToolsLibrary.Core.Video;

namespace AcTools.Forms
{
    public partial class frmTimeCodeEditor : AcForm
    {
        private VideoFrameList vfl = new VideoFrameList();
        private Boolean ignoreUpdateText = false;

        public frmTimeCodeEditor()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            InitColors();
            InitControls();
            InitIcon();
            fillVersions();
            this.Text = "Timecodes File Editor";
            numUpDownDecimalDigits.Value = 3;
            radioFrameDuration.Checked = true;
        }

        private void fillVersions()
        {
            cmbTimecodesVersion.Items.Clear();
            cmbTimecodesVersion.Items.Add("Version 1");
            cmbTimecodesVersion.Items.Add("Version 2");
        }

        private void txtTimecodesFile_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void txtTimecodesFile_DragDrop(object sender, DragEventArgs e)
        {
            String[] s = (String[])e.Data.GetData(DataFormats.FileDrop, false);
            ((TextBox)sender).Text = s[0];
        }

        private void btnBrowseTimecodesFile_Click(object sender, EventArgs e)
        {
            String[] filenames = ShowOpenFileDialog("Select timecodes file...", "", "", false);
            if (filenames != null)
            {
                if (filenames.Length > 0)
                {
                    txtTimecodesFile.Text = filenames[0];
                }
            }
        }

        private void btnLoadTimecodesFile_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                tlpMain.Enabled = false;
                loadTimecodes();
                tlpMain.Enabled = true;
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                tlpMain.Enabled = true;
                Cursor = Cursors.Default;
                ShowExceptionMessage(ex, "Error loading timecodes!");
            }
        }

        private void btnNewTimecodesFile_Click(object sender, EventArgs e)
        {
            try
            {                
                clearHeader();
                clearFrameList();
                txtTimecodesFile.Text = String.Empty;
                vfl = new VideoFrameList();
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex, "Error setting new timecodes file!");
            }
        }

        private void btnSaveTimecodesFile_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                tlpMain.Enabled = false;
                saveTimecodes();
                tlpMain.Enabled = true;
                Cursor = Cursors.Default;
                AcControls.AcMessageBox.AcMessageBox.Show("Successfully saved timecodes file!", "Success!", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                tlpMain.Enabled = true;
                Cursor = Cursors.Default;
                ShowExceptionMessage(ex, "Error saving timecodes file!");
            }
        }

        private void lstFrameTimecodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                fillFrameDataFromList();
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex, "Error selecting frame!");
            }
        }

        private void btnAddFrameTimecode_Click(object sender, EventArgs e)
        {
            try
            {
                addFrameToList(getFrameFromForm());
                tlpMain.Enabled = false;
                //Populate the list
                populateFrameList();
                tlpMain.Enabled = true;
            }
            catch (Exception ex)
            {
                tlpMain.Enabled = true;
                ShowExceptionMessage(ex, "Error adding frame!");
            }
        }

        private void btnAddFrameTimecodeRange_Click(object sender, EventArgs e)
        {
            try
            {
                tlpMain.Enabled = false;
                addFrameRangeToList();
                //Populate the list
                populateFrameList();
                tlpMain.Enabled = true;
            }
            catch (Exception ex)
            {
                tlpMain.Enabled = true;
                ShowExceptionMessage(ex, "Error adding frame range!");
            }
        }

        private void btnUpdateFrameTimecode_Click(object sender, EventArgs e)
        {
            try
            {
                tlpMain.Enabled = false;
                updateFrameToList();
                //Populate the list
                populateFrameList();
                tlpMain.Enabled = true;
            }
            catch (Exception ex)
            {
                tlpMain.Enabled = true;
                ShowExceptionMessage(ex, "Error updating frame!");
            }
        }

        private void btnDeleteFrameTimecode_Click(object sender, EventArgs e)
        {
            try
            {
                tlpMain.Enabled = false;
                deleteFrameFromList();
                //Populate the list
                populateFrameList();
                tlpMain.Enabled = true;
            }
            catch (Exception ex)
            {
                tlpMain.Enabled = true;
                ShowExceptionMessage(ex, "Error deleting frame!");
            }
        }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioFrameDuration.Checked)
                {
                    txtFrameDuration.ReadOnly = false;
                    txtFrameFrameRate.ReadOnly = true;
                }
                else
                {
                    txtFrameDuration.ReadOnly = true;
                    txtFrameFrameRate.ReadOnly = false;
                }
                InitColors();
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex, "Error selecting duration!");
            }
        }

        private void txtFrameDuration_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!ignoreUpdateText)
                {
                    txtFrameFrameRate.Text = Convert.ToString(VideoFrame.GetFrameRateFromDuration(AcHelper.DecimalParse(txtFrameDuration.Text)),
                        System.Globalization.CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                ignoreUpdateText = true;
                txtFrameFrameRate.Text = String.Empty;
                ignoreUpdateText = false;
            }
        }

        private void txtFrameFrameRate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!ignoreUpdateText)
                {
                    txtFrameDuration.Text = Convert.ToString(VideoFrame.GetDurationFromFrameRate(AcHelper.DecimalParse(txtFrameFrameRate.Text)),
                        System.Globalization.CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                ignoreUpdateText = true;
                txtFrameDuration.Text = String.Empty;
                ignoreUpdateText = false;
            }
        }

        private void clearHeader()
        {
            cmbTimecodesVersion.SelectedIndex = -1;
            txtAssumedFrameRate.Text = String.Empty;
        }

        private void clearFrameList()
        {
            lstFrameTimecodes.Items.Clear();
        }

        private void clearFrameInfo()
        {
            txtFrameNumber.Text = String.Empty;
            txtFrameStart.Text = String.Empty;
            txtFrameDuration.Text = String.Empty;
            txtFrameFrameRate.Text = String.Empty;                        
        }

        private void checkLoad()
        {
            if (txtTimecodesFile.Text.Trim().Length > 0)
            {
                if (!System.IO.File.Exists(txtTimecodesFile.Text))
                {
                    throw new Exception("The provided timecodes file does not exist!");
                }
            }
            else
            {
                throw new Exception("Please provide with a timecodes file!");
            }
        }

        private void loadTimecodes()
        {
            //Check for timecodes file
            checkLoad();
            //Load the timecodes
            vfl.LoadTimecodes(txtTimecodesFile.Text, false, Convert.ToInt32(numUpDownDecimalDigits.Value));
            //Write the header values
            String formatString = "";
            formatString = "000.".PadRight(4 + Convert.ToInt32(numUpDownDecimalDigits.Value), '0');
            cmbTimecodesVersion.SelectedIndex = vfl.TimecodesVersionLoaded - 1;
            txtAssumedFrameRate.Text = vfl.AssumedFrameRate.ToString(formatString, CultureInfo.InvariantCulture);
            //Populate the frame list
            populateFrameList();
        }

        private void populateFrameList()
        {
            //Get old selected index
            Int32 oldSelIdx = lstFrameTimecodes.SelectedIndex;
            String formatString = "000.".PadRight(4 + Convert.ToInt32(numUpDownDecimalDigits.Value), '0');
            //Sort list
            vfl.Sort(VideoFrameList.SortType.ByFrameNumber, VideoFrameList.SortOrder.Ascending);
            List<String> frameStrings = new List<String>();
            vfl.FrameList.ForEach(x => frameStrings.Add(String.Format("Frame : {0} [{1}ms][{2}fps] @ {3}ms",
                    x.FrameNumber,
                    x.FrameDuration.ToString(formatString, CultureInfo.InvariantCulture),
                    x.FrameRate.ToString(formatString, CultureInfo.InvariantCulture),
                    x.FrameStartTime.ToString(formatString, CultureInfo.InvariantCulture))));

            //foreach (VideoFrame vf in vfl.FrameList)
            //{
            //    String itemStr = String.Format("Frame : {0} [{1}ms][{2}fps] @ {3}ms",
            //        vf.FrameNumber,
            //        vf.FrameDuration.ToString(formatString, CultureInfo.InvariantCulture),
            //        vf.FrameRate.ToString(formatString, CultureInfo.InvariantCulture),
            //        vf.FrameStartTime.ToString(formatString, CultureInfo.InvariantCulture));
            //    lstFrameTimecodes.Items.Add(itemStr);
            //    Application.DoEvents();
            //}
            lstFrameTimecodes.SuspendLayout();
            //Clear list
            lstFrameTimecodes.Items.Clear();
            lstFrameTimecodes.Items.AddRange(frameStrings.ToArray<String>());
            lstFrameTimecodes.ResumeLayout();
            //Restore selection
            if (oldSelIdx > -1)
            {
                if (oldSelIdx < lstFrameTimecodes.Items.Count)
                {
                    lstFrameTimecodes.SelectedIndex = oldSelIdx;
                }
            }
        }

        private void checkSave()
        {
            if (vfl == null)
            {
                throw new Exception("No video frame list present!");
            }
            if (cmbTimecodesVersion.SelectedIndex == -1)
            {
                throw new Exception("No timecodes version is selected!");
            }
            if (cmbTimecodesVersion.SelectedIndex == 0 && txtAssumedFrameRate.Text.Trim().Length == 0)
            {
                throw new Exception("No assumed framerate is provided!");
            }
        }

        private void saveTimecodes()
        {
            //Check save
            checkSave();
            //Get output file
            String outputFile = String.Empty;
            if (txtTimecodesFile.Text.Trim().Length > 0)
            {
                outputFile = txtTimecodesFile.Text;
            }
            else
            {
                outputFile = ShowSaveFileDialog("Save timecodes file...", "", "All files (*.*)|*.*");
                if (outputFile == null)
                {
                    return;
                }
            }
            //Write timecodes file
            vfl.WriteTimecodes(outputFile, Convert.ToUInt16(cmbTimecodesVersion.SelectedIndex + 1), 
                AcHelper.DoubleParse(txtAssumedFrameRate.Text));
        }

        private void fillFrameDataFromList()
        {
            //Check if a frame is selected
            if (lstFrameTimecodes.SelectedIndex > -1)
            {
                VideoFrame svf = getSelectedFrameFromList();
                txtFrameNumber.Text = Convert.ToString(svf.FrameNumber, System.Globalization.CultureInfo.InvariantCulture);
                txtFrameStart.Text = Convert.ToString(svf.FrameStartTime, System.Globalization.CultureInfo.InvariantCulture);
                ignoreUpdateText = true;
                txtFrameDuration.Text = Convert.ToString(svf.FrameDuration, System.Globalization.CultureInfo.InvariantCulture);
                ignoreUpdateText = false;
                //txtFrameFrameRate.Text = Convert.ToString(svf.FrameRate, System.Globalization.CultureInfo.InvariantCulture);
            }
            else
            {
                clearFrameInfo();
            }
        }

        private VideoFrame getSelectedFrameFromList()
        {            
            //Get the selected video frame object
            String tmp = ((String)lstFrameTimecodes.SelectedItem).Substring(8);
            tmp = tmp.Substring(0, tmp.IndexOf("["));
            Int32 frameNumber = Convert.ToInt32(tmp);
            VideoFrame svf = null;
            foreach (VideoFrame vf in vfl.FrameList)
            {
                if (vf.FrameNumber == frameNumber)
                {
                    svf = vf;
                    break;
                }
            }
            if (svf == null)
            {
                throw new Exception("Could not find selected video frame!");
            }
            return svf;
        }

        private void addFrameRangeToList()
        {
            //Get start frame
            Object startFrameObj =AcControls.AcInputBox.AcInputBox.Show("Enter the start frame of the frame range:", "Enter frame...", "");
            if (startFrameObj == null)
            {
                return;
            }
            //Get end frame
            Object endFrameObj = AcControls.AcInputBox.AcInputBox.Show("Enter the end frame of the frame range:", "Enter frame...", "");
            if (endFrameObj == null)
            {
                return;
            }
            //Get start time
            Object startTimeObj = AcControls.AcInputBox.AcInputBox.Show("Enter the start time of the first frame:", "Enter start time...", "");
            if (startFrameObj == null)
            {
                return;
            }
            //Check for duration or frame rate
            Boolean useDuration = false;
            if (ShowQuestion("Do you want to enter duration in ms?\r\n(Answering No will prompt you to enter frame rate in fps))", 
                "Select duration type...") 
                == DialogResult.Yes)
            {
                useDuration = true;
            }
            Object durationObj = null; 
            Object frameRateObj = null;
            if (useDuration)
            {
                //Get duration
                durationObj = AcControls.AcInputBox.AcInputBox.Show("Enter the duration for each frame in ms:", "Enter frame duration...", "");
                if (durationObj == null)
                {
                    return;
                }
            }
            else
            {
                //Get frame rate
                frameRateObj = AcControls.AcInputBox.AcInputBox.Show("Enter the frame rate for each frame in fps:", "Enter frame rate...", "");
                if (frameRateObj == null)
                {
                    return;
                }
            }

            Decimal currentStartTime = AcHelper.DecimalParse((String)startTimeObj);
            Decimal durationAmount = Decimal.MinValue;
            durationAmount = useDuration ? AcHelper.DecimalParse((String)durationObj) : AcHelper.DecimalParse((String)frameRateObj);
            //Add frame range
            for (Int32 i = Convert.ToInt32(startFrameObj); i <= Convert.ToInt32(endFrameObj); i++)
            {
                // check if frame number already exists and if it does, skip it
                if (vfl.FrameList.Any(x => x.FrameNumber == i))
                {
                    continue;
                }
                VideoFrame vf = new VideoFrame();
                vf.FrameNumber = i;
                vf.FrameStartTime = currentStartTime;
                if (useDuration)
                {
                    vf.FrameDuration = durationAmount;
                }
                else
                {
                    vf.FrameRate = durationAmount;
                }
                //Update start time for next frame
                currentStartTime += vf.FrameDuration;
                //Add the frame to the list 
                vfl.Add(vf);
            }
        }

        private void addFrameToList(VideoFrame vf)
        {
            //Check if video frame already exists
            if (vfl.FrameList.Any(x => x.FrameNumber == vf.FrameNumber))
            {
                    throw new Exception("A videoframe with the same frame number already exists!");
            }
            //Add frame to the list
            vfl.Add(vf);
        }

        private void updateFrameToList()
        {
            VideoFrame vf = getFrameFromForm();
            VideoFrame foundVf = null;
            //Check if video frame exists
            foreach (VideoFrame tmpVf in vfl.FrameList)
            {
                if (tmpVf.FrameNumber == vf.FrameNumber)
                {
                    foundVf = tmpVf;
                    break;
                }
            }
            if (foundVf == null)
            {
                throw new Exception("There is no frame to update!");
            }
            //Update the frame to the frame list
            foundVf = vf;
        }

        private void deleteFrameFromList()
        {
            // Remove selected frame from list
            vfl.Remove(getSelectedFrameFromList());
        }

        private VideoFrame getFrameFromForm()
        {
            VideoFrame vf = new VideoFrame();
            vf.FrameNumber = Convert.ToInt32(txtFrameNumber.Text);
            if (radioFrameDuration.Checked)
            {
                vf.FrameDuration = AcHelper.DecimalParse(txtFrameDuration.Text);
            }
            else
            {
                vf.FrameRate = AcHelper.DecimalParse(txtFrameFrameRate.Text);
            }
            vf.FrameStartTime = AcHelper.DecimalParse(txtFrameStart.Text);
            return vf;
        }
    }
}
