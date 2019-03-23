using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Diagnostics;

using AcTools.Core;

using AcControls.AcMessageBox;
using AcControls.AcInputBox;

using AcToolsLibrary.Common;
using AcToolsLibrary.Core.Video;

namespace AcTools.Forms
{
    public partial class frmFrameRestoration : AcForm
    {
        private static Int32 trackBarStartMargin = 9;
        private static Int32 trackBarEndMargin = 9;

        private FrameRestorer fr;

        private Boolean fromUpdateGUI = false;

        private Thread videoPlayThread = null;

        public frmFrameRestoration()
        {
            InitializeComponent();
            InitColors();
            InitControls();
            showAllFrames();
            InitIcon(AcTools.Properties.Resources.FrameRestoration);
            this.Text = "Frame Restoration";
            fr = new FrameRestorer();
            //fr.vidPlayer = new VideoPlayer(this, VideoPlayerType.CurrentPreviousNextFrames);
        }

        private void txtProjectFile_DragDrop(object sender, DragEventArgs e)
        {
            String[] s = (String[])e.Data.GetData(DataFormats.FileDrop, false);
            ((TextBox)sender).Text = s[0];
        }

        private void txtProjectFile_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void btnBrowseVideoFile_Click(object sender, EventArgs e)
        {
            String[] filenames = ShowOpenFileDialog("Select a video file...", "", "", false);
            if (filenames != null)
            {
                if (filenames[0].Length > 0)
                {
                    txtVideoFile.Text = filenames[0];
                }
            }
        }

        private void btnBrowseAvisynthOutputFile_Click(object sender, EventArgs e)
        {
            String[] filename = ShowOpenFileDialog("Specify an AviSynth output file...", "", "AviSynth files (*.avs)|*.avs", false);
            if (filename != null)
            {
                if (filename[0].Length > 0)
                {
                    txtAvisynthOutputFile.Text = filename[0];
                }
            }
        }

        private void btnBrowseProjectFile_Click(object sender, EventArgs e)
        {
            String[] filename = ShowOpenFileDialog("Specify a project file...", "", "Project files (*.frproj)|*.frproj", false);
            if (filename != null)
            {
                if (filename[0].Length > 0)
                {
                    txtProjectFile.Text = filename[0];
                }
            }
        }

        private void btnHook_Click(object sender, EventArgs e)
        {
            HookUnHook();
            if (_HookState == FormHookState.Unhooked)
            {
                btnHook.Text = "Hook";
            }
            else
            {
                btnHook.Text = "UnHook";
            }
        }

        private void showAllFrames()
        {
            checkShowVideoFramePrevious.Checked = true;
            checkShowVideoFrameCurrent.Checked = true;
            checkShowVideoFrameNext.Checked = true;
        }

        private Int32 videoFramesShowing()
        {
            Int32 framesShowing = 0;
            if (checkShowVideoFramePrevious.Checked == true)
            {
                framesShowing++;
            }
            if (checkShowVideoFrameCurrent.Checked == true)
            {
                framesShowing++;
            }
            if (checkShowVideoFrameNext.Checked == true)
            {
                framesShowing++;
            }
            return framesShowing;
        }

        private void switchVisibleVideoFrames()
        {
            switch (videoFramesShowing())
            {
                case 1:
                    if (checkShowVideoFrameCurrent.Checked == true)
                    {
                        tblVideoFrames.ColumnStyles[0].Width = 0.0F;
                        tblVideoFrames.ColumnStyles[1].Width = 100.0F;
                        tblVideoFrames.ColumnStyles[2].Width = 0.0F;
                    }
                    else if (checkShowVideoFrameNext.Checked == true)
                    {
                        tblVideoFrames.ColumnStyles[0].Width = 0.0F;
                        tblVideoFrames.ColumnStyles[1].Width = 0.0F;
                        tblVideoFrames.ColumnStyles[2].Width = 100.0F;
                    }
                    else if (checkShowVideoFramePrevious.Checked == true)
                    {
                        tblVideoFrames.ColumnStyles[0].Width = 100.0F;
                        tblVideoFrames.ColumnStyles[1].Width = 0.0F;
                        tblVideoFrames.ColumnStyles[2].Width = 0.0F;
                    }
                    break;
                case 2:
                    if (checkShowVideoFramePrevious.Checked == true)
                    {
                        tblVideoFrames.ColumnStyles[0].Width = 50.0F;
                        if (checkShowVideoFrameCurrent.Checked == true)
                        {
                            tblVideoFrames.ColumnStyles[1].Width = 50.0F;
                            tblVideoFrames.ColumnStyles[2].Width = 0.0F;
                        }
                        else if (checkShowVideoFrameNext.Checked == true)
                        {
                            tblVideoFrames.ColumnStyles[1].Width = 0.0F;
                            tblVideoFrames.ColumnStyles[2].Width = 50.0F;
                        }
                    }
                    else
                    {
                        tblVideoFrames.ColumnStyles[0].Width = 0.0F;
                        tblVideoFrames.ColumnStyles[1].Width = 50.0F;
                        tblVideoFrames.ColumnStyles[2].Width = 50.0F;
                    }

                    break;
                case 3:
                    tblVideoFrames.ColumnStyles[0].Width = 33.3F;
                    tblVideoFrames.ColumnStyles[1].Width = 33.3F;
                    tblVideoFrames.ColumnStyles[2].Width = 33.3F;
                    break;
                case 0:
                    tblVideoFrames.ColumnStyles[0].Width = 0.0F;
                    tblVideoFrames.ColumnStyles[1].Width = 0.0F;
                    tblVideoFrames.ColumnStyles[2].Width = 0.0F;
                    break;
            }
        }

        private void checkShowVideoFrameCurrent_CheckedChanged(object sender, EventArgs e)
        {
            switchVisibleVideoFrames();
        }

        private void trackVideo_MouseDown(object sender, MouseEventArgs e)
        {
            double dblValue;
            Int32 intValue;

            // Jump to the clicked location
            Int32 normX = e.X - trackBarStartMargin;
            Int32 normWidth = trackVideo.Width - trackBarStartMargin - trackBarEndMargin;
            Double normRatio = Convert.ToDouble(trackVideo.Maximum - trackVideo.Minimum) / Convert.ToDouble(normWidth);
            dblValue = normX * normRatio;
            intValue = Convert.ToInt32(dblValue);
            if (intValue > trackVideo.Maximum)
            {
                intValue = trackVideo.Maximum;
            }
            else if (intValue < 0)
            {
                intValue = 0;
            }
            trackVideo.Value = intValue;
            txtCurrentTime.Select();
            txtCurrentTime.Focus();
        }

        private void btnBrowseTimecodesFile_Click(object sender, EventArgs e)
        {
            String[] filenames = ShowOpenFileDialog("Select a timecodes file...", "", "", false);
            if (filenames != null)
            {
                if (filenames[0].Length > 0)
                {
                    txtTimecodesFile.Text = filenames[0];
                }
            }
        }

        private delegate void UpdatePicVideoCurrentDelegate(Bitmap img);
        private void UpdatePicVideoCurrent(Bitmap img)
        {
            if (picVideoFrameCurrent.Image != null)
            {
                picVideoFrameCurrent.Image.Dispose();
            }
            picVideoFrameCurrent.Image = img;
        }
        private delegate void UpdatePicVideoPreviousDelegate(Bitmap img);
        private void UpdatePicVideoPrevious(Bitmap img)
        {
            if (picVideoFramePrevious.Image != null)
            {
                picVideoFramePrevious.Image.Dispose();
            }
            picVideoFramePrevious.Image = img;
        }
        private delegate void UpdatePicVideoNextDelegate(Bitmap img);
        private void UpdatePicVideoNext(Bitmap img)
        {
            if (picVideoFrameNext.Image != null)
            {
                picVideoFrameNext.Image.Dispose();
            }
            picVideoFrameNext.Image = img;
        }
        private delegate void UpdateTxtFrameDelegate(String str);
        private void UpdateTxtFrame(String str)
        {
            txtFrame.Text = str;
        }
        private delegate void UpdateTxtCurrentTimeDelegate(String str);
        private void UpdateTxtCurrentTime(String str)
        {
            txtCurrentTime.Text = str;
        }
        private delegate void UpdateTxtVideoFrameCurrentDelegate(String str);
        private void UpdateTxtVideoFrameCurrent(String str)
        {
            txtVideoFrameCurrent.Text = str;
        }
        private delegate void UpdateTxtVideoFramePreviousDelegate(String str);
        private void UpdateTxtVideoFramePrevious(String str)
        {
            txtVideoFramePrevious.Text = str;
        }
        private delegate void UpdateTxtVideoFrameNextDelegate(String str);
        private void UpdateTxtVideoFrameNext(String str)
        {
            txtVideoFrameNext.Text = str;
        }
        private delegate void UpdateTxtStatusCurrentDelegate(String str);
        private void UpdateTxtStatusCurrent(String str)
        {
            UpdateFrameStatus(txtStatusCurrent, str, 0);
        }
        private delegate void UpdateTxtStatusPreviousDelegate(String str);
        private void UpdateTxtStatusPrevious(String str)
        {
            UpdateFrameStatus(txtStatusPrevious, str, -1);
        }
        private delegate void UpdateTxtStatusNextDelegate(String str);
        private void UpdateTxtStatusNext(String str)
        {
            UpdateFrameStatus(txtStatusNext, str, 1);
        }
        private delegate void UpdateTrackVideoDelegate(Int32 value);
        private void UpdateTrackVideo(Int32 value)
        {
            trackVideo.Value = value;
        }

        private void UpdateFrameStatus(TextBox ctrl, String str, Int32 frameBias)
        {
            Int32 counter = 0;
            if (str.ToLowerInvariant() == "todelete")
            {
                ctrl.ForeColor = Color.Red;
            }
            else if (str.ToLowerInvariant() == "toduplicate")
            {
                ctrl.ForeColor = Color.Green;
                for (int i = 0; i < fr.frpf.FrameList.FrameSections[0].FramesToDuplicate.Count; i++)
                {
                    if (fr.frpf.FrameList.FrameSections[0].FramesToDuplicate.FrameList[i].FrameNumber == fr.vidPlayer.VideoData.CurrentFrame+frameBias )
                    {
                        counter++;
                    }
                }
            }
            else
            {
                ctrl.ForeColor = Color.Black;
            }
            if (counter > 0)
            {
                ctrl.Text = String.Format("{0} ({1})", str, counter);
            }
            else
            {
                ctrl.Text = str;
            }
        }

        public override void UpdateGUI(Object obj)
        {
            try
            {
                VideoPlayerUpdateData vpud = (VideoPlayerUpdateData)obj;
                IAsyncResult ar;
                ar = picVideoFrameCurrent.BeginInvoke(new UpdatePicVideoCurrentDelegate(this.UpdatePicVideoCurrent),
                    new Object[] { vpud.VideoFrameImage });
                ar = txtFrame.BeginInvoke(new UpdateTxtFrameDelegate(this.UpdateTxtFrame),
                    new Object[] { vpud.CurrentFrame.ToString() });
                txtFrame.EndInvoke(ar);
                Decimal frameRate = Convert.ToDecimal(vpud.Avs.Clip.Raten) / Convert.ToDecimal(vpud.Avs.Clip.Rated);
                ar = txtCurrentTime.BeginInvoke(new UpdateTxtCurrentTimeDelegate(this.UpdateTxtCurrentTime),
                    new Object[] { VideoFrame.FrameTimeFromFrameNumber(vpud.CurrentFrame, frameRate, FrameFromType.FromFrameRate) });
                fromUpdateGUI = true;
                trackVideo.Invoke(new UpdateTrackVideoDelegate(this.UpdateTrackVideo),
                    new Object[] { vpud.CurrentFrame });
                fromUpdateGUI = false;
                ar = txtVideoFrameCurrent.BeginInvoke(new UpdateTxtVideoFrameCurrentDelegate(this.UpdateTxtVideoFrameCurrent),
                    new Object[] { vpud.CurrentFrame.ToString() });
                ar = txtStatusCurrent.BeginInvoke(new UpdateTxtStatusCurrentDelegate(this.UpdateTxtStatusCurrent),
                    new Object[] { Enum.GetName(typeof(FrameProcessType), fr.frpf.FrameList.FrameList[vpud.CurrentFrame].ProcessType) });
                if (vpud.CurrentFrame == 0)
                {
                    ar = txtVideoFramePrevious.BeginInvoke(new UpdateTxtVideoFramePreviousDelegate(this.UpdateTxtVideoFramePrevious),
                        new Object[] { "-" });
                    ar = txtStatusPrevious.BeginInvoke(new UpdateTxtStatusPreviousDelegate(this.UpdateTxtStatusPrevious),
                        new Object[] { "-" });
                    ar = picVideoFramePrevious.BeginInvoke(new UpdatePicVideoPreviousDelegate(this.UpdatePicVideoPrevious),
                        new Object[] { vpud.VideoFrameImagePrevious });
                    ar = txtVideoFrameNext.BeginInvoke(new UpdateTxtVideoFrameNextDelegate(this.UpdateTxtVideoFrameNext),
                        new Object[] { (vpud.CurrentFrame + 1).ToString() });
                    ar = txtStatusNext.BeginInvoke(new UpdateTxtStatusNextDelegate(this.UpdateTxtStatusNext),
                        new Object[] { Enum.GetName(typeof(FrameProcessType), fr.frpf.FrameList.FrameList[vpud.CurrentFrame + 1].ProcessType) });
                    ar = picVideoFrameNext.BeginInvoke(new UpdatePicVideoNextDelegate(this.UpdatePicVideoNext),
                        new Object[] { vpud.VideoFrameImageNext });
                }
                else if (vpud.CurrentFrame == vpud.Avs.Clip.NumberOfFrames - 1)
                {
                    ar = txtVideoFramePrevious.BeginInvoke(new UpdateTxtVideoFramePreviousDelegate(this.UpdateTxtVideoFramePrevious),
                        new Object[] { (vpud.CurrentFrame - 1).ToString() });
                    ar = txtStatusPrevious.BeginInvoke(new UpdateTxtStatusPreviousDelegate(this.UpdateTxtStatusPrevious),
                        new Object[] { Enum.GetName(typeof(FrameProcessType), fr.frpf.FrameList.FrameList[vpud.CurrentFrame - 1].ProcessType) });
                    ar = picVideoFramePrevious.BeginInvoke(new UpdatePicVideoPreviousDelegate(this.UpdatePicVideoPrevious),
                        new Object[] { vpud.VideoFrameImagePrevious });
                    ar = txtVideoFrameNext.BeginInvoke(new UpdateTxtVideoFrameNextDelegate(this.UpdateTxtVideoFrameNext),
                        new Object[] { "-" });
                    ar = txtStatusNext.BeginInvoke(new UpdateTxtStatusNextDelegate(this.UpdateTxtStatusNext),
                        new Object[] { "-" });
                    ar = picVideoFrameNext.BeginInvoke(new UpdatePicVideoNextDelegate(this.UpdatePicVideoNext),
                        new Object[] { vpud.VideoFrameImageNext });
                }
                else
                {
                    ar = txtVideoFramePrevious.BeginInvoke(new UpdateTxtVideoFramePreviousDelegate(this.UpdateTxtVideoFramePrevious),
                       new Object[] { (vpud.CurrentFrame - 1).ToString() });
                    ar = txtStatusPrevious.BeginInvoke(new UpdateTxtStatusPreviousDelegate(this.UpdateTxtStatusPrevious),
                        new Object[] { Enum.GetName(typeof(FrameProcessType), fr.frpf.FrameList.FrameList[vpud.CurrentFrame - 1].ProcessType) });
                    ar = picVideoFramePrevious.BeginInvoke(new UpdatePicVideoPreviousDelegate(this.UpdatePicVideoPrevious),
                        new Object[] { vpud.VideoFrameImagePrevious });
                    ar = txtVideoFrameNext.BeginInvoke(new UpdateTxtVideoFrameNextDelegate(this.UpdateTxtVideoFrameNext),
                        new Object[] { (vpud.CurrentFrame + 1).ToString() });
                    ar = txtStatusNext.BeginInvoke(new UpdateTxtStatusNextDelegate(this.UpdateTxtStatusNext),
                        new Object[] { Enum.GetName(typeof(FrameProcessType), fr.frpf.FrameList.FrameList[vpud.CurrentFrame + 1].ProcessType) });
                    ar = picVideoFrameNext.BeginInvoke(new UpdatePicVideoNextDelegate(this.UpdatePicVideoNext),
                        new Object[] { vpud.VideoFrameImageNext });
                }
            }
            catch (Exception ex)
            {
                AcMessageBox.Show(ex.Message, "Error!", MessageBoxIcon.Error);
            }
        }

        private void btnGoToStart_Click(object sender, EventArgs e)
        {
            if (fr.vidPlayer.VideoOpened && !fr.vidPlayer.VideoPlaying)
            {
                fr.vidPlayer.GetFrame(0);
            }
        }

        private void btnGoToEnd_Click(object sender, EventArgs e)
        {
            if (fr.vidPlayer.VideoOpened && !fr.vidPlayer.VideoPlaying)
            {
                fr.vidPlayer.GetLastFrame();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean useFakeTimecodes = false;

                if (tabCtrlFiles.SelectedTab == tabPageProject)
                {
                    //Check if project file is provided
                    if (txtProjectFile.Text == string.Empty)
                    {
                        throw new Exception("Please provide with a project file first!");
                    }
                    //Open the project file
                    fr.frpf = new FrameRestorationProjectFile(txtProjectFile.Text);
                    txtVideoFile.Text = fr.frpf.VideoFile;
                    txtTimecodesFile.Text = fr.frpf.TimecodesFile;
                    txtAvisynthOutputFile.Text = fr.frpf.AviSynthOutputFile;
                    if (fr.frpf.TimecodesFile == String.Empty)
                    {
                        useFakeTimecodes = true;
                    }
                    else
                    {
                        useFakeTimecodes = fr.frpf.UseFakeTimecodes;
                    }
                    //fr.vidPlayer.OpenVideo(fr.frpf.VideoFile);
                    if (useFakeTimecodes)
                    {
                        //Load fake timecodes
                        fr.frpf.FrameList.CreateFakeTimecodes(fr.vidPlayer.VideoData.Avs.Clip.NumberOfFrames, Convert.ToDecimal(fr.vidPlayer.VideoData.Avs.Clip.Rate));
                        //Create a new section
                        VideoFrameSection vfs = new VideoFrameSection("Whole_Video", 0, fr.frpf.FrameList.Count - 1);
                        fr.frpf.FrameList.AddSection(vfs);
                    }
                    trackVideo.Maximum = fr.vidPlayer.VideoData.Avs.Clip.NumberOfFrames - 1;
                    trackVideo.Minimum = 0;
                    fr.vidPlayer.GetFrame(0);
                }
                else if (tabCtrlFiles.SelectedTab == tabPageFiles)
                {
                    //Assume new project
                    //Check if video file exists
                    if (!File.Exists(txtVideoFile.Text))
                    {
                        throw new AcException("Error creating project! The video file provided does not exist!");
                    }
                    //Check if timecodes exist
                    if (!File.Exists(txtTimecodesFile.Text))
                    {
                        if (AcMessageBox.Show("Do you want to use fake timecodes?", "No timecodes found!", 
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            useFakeTimecodes = true;
                        }
                        else
                        {
                            throw new AcException("Error creating project! The Timecodes file provided does not exist!");
                        }
                    }
                    //Create the new project
                    fr.frpf = new FrameRestorationProjectFile();
                    fr.frpf.UseFakeTimecodes = useFakeTimecodes;
                    //Load the video
                    //fr.vidPlayer.OpenVideo(txtVideoFile.Text);
                    trackVideo.Maximum = fr.vidPlayer.VideoData.Avs.Clip.NumberOfFrames - 1;
                    trackVideo.Minimum = 0;
                    //Check for fake timecodes
                    if (useFakeTimecodes)
                    {
                        //Load fake timecodes
                        fr.frpf.FrameList.CreateFakeTimecodes(fr.vidPlayer.VideoData.Avs.Clip.NumberOfFrames, Convert.ToDecimal(fr.vidPlayer.VideoData.Avs.Clip.Rate));
                    }
                    else
                    {
                        //Load the timecodes
                        fr.frpf.FrameList.LoadTimecodes(txtTimecodesFile.Text, false, 3);
                    }
                    //Add the section
                    fr.frpf.FrameList.AddSection(new VideoFrameSection("Whole_Video", 0, fr.vidPlayer.VideoData.Avs.Clip.NumberOfFrames - 1));
                    //Check the validity of timecodes file
                    if (fr.frpf.FrameList.Count == 0)
                    {
                        AcLogger.Log(new AcException("Error creating project! Timecodes file didn't contain any frames!"), 
                            AcLogType.FileAndLogger);
                        fr.vidPlayer.Dispose();
                        return;
                    }
                    //Check that timecodes and video files match
                    if (fr.vidPlayer.VideoData.Avs.Clip.NumberOfFrames != fr.frpf.FrameList.Count)
                    {
                        AcLogger.Log(new AcException("Error creating project! Timecodes file doesn't match video!"), 
                            AcLogType.FileAndLogger);
                        fr.vidPlayer.Dispose();
                        return;
                    }
                    //Update the project data
                    fr.frpf.VideoFile = txtVideoFile.Text;
                    fr.frpf.TimecodesFile = txtTimecodesFile.Text;
                    //Prompt the user for a project file name
                    String filename = ShowSaveFileDialog("Select a project file to save...", "", "*.frproj (Frame Restoration Project)|*.frproj");
                    if (filename == null)
                    {
                        return;
                    }
                    fr.frpf.ProjectFile = filename;
                    //Create the new project file
                    fr.WriteProject();
                    txtProjectFile.Text = filename;
                    //Get the first form
                    fr.vidPlayer.GetFrame(0);
                }

                //Enable the controls
                btnDeleteChange.Enabled = true;
                btnDeleteFrame.Enabled = true;
                btnDuplicateFrame.Enabled = true;
                btnPreview.Enabled = true;
                btnSaveFiles.Enabled = true;
                btnUpdateProjectProperties.Enabled = true;
                checkAutoCommit.Enabled = true;
                checkZoom.Enabled = true;

                //refresh the list
                UpdateListChanges();

            }
            catch (Exception ex)
            {
                AcLogger.Log(new AcException("Error creating project!", ex), AcLogType.FileAndLogger);
                Debug.WriteLine(ex.StackTrace);
            }
        }

        private void trackVideo_ValueChanged(object sender, EventArgs e)
        {
            if (fr.vidPlayer.VideoOpened && !fromUpdateGUI && !fr.vidPlayer.VideoPlaying)
            {
                fr.vidPlayer.GetFrame(trackVideo.Value);
            }
        }

        private void FrameRestorationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (fr.vidPlayer != null && fr.vidPlayer.VideoOpened)
            {
                fr.vidPlayer.Dispose();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (fr.vidPlayer.VideoOpened && !fr.vidPlayer.VideoPlaying)
            {
                fr.vidPlayer.GetPrevFrame(10);
            }
        }

        private void btnSmallBack_Click(object sender, EventArgs e)
        {
            if (fr.vidPlayer.VideoOpened && !fr.vidPlayer.VideoPlaying)
            {
                fr.vidPlayer.GetPrevFrame();
            }
        }

        private void btnSmallForward_Click(object sender, EventArgs e)
        {
            if (fr.vidPlayer.VideoOpened && !fr.vidPlayer.VideoPlaying)
            {
                fr.vidPlayer.GetNextFrame();
            }
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            if (fr.vidPlayer.VideoOpened && !fr.vidPlayer.VideoPlaying)
            {
                fr.vidPlayer.GetNextFrame(10);
            }
        }

        private void btnGoToFrame_Click(object sender, EventArgs e)
        {
            try
            {
                if (fr.vidPlayer.VideoOpened && !fr.vidPlayer.VideoPlaying)
                {

                    fr.vidPlayer.GetFrame(Convert.ToInt32(txtFrame.Text));
                }
            }
            catch (Exception ex)
            {
                AcLogger.Log(ex, AcLogType.FileAndLogger);
            }
            
        }

        private void btnPlayVideo_Click(object sender, EventArgs e)
        {
            if (fr.vidPlayer.VideoPlaying)
            {
                fr.vidPlayer.VideoPlaying = false;
                //videoPlayThread.Join();
                videoPlayThread = null;
                btnPlayVideo.Text = "Play";
                //trackVideo.Value = vidPlayer.VideoData.CurrentFrame;
                return;
            }
            else
            {
                fr.vidPlayer.VideoPlaying = true;
                btnPlayVideo.Text = "Stop";
                videoPlayThread = new Thread(new ThreadStart(playVideo));
                videoPlayThread.Start();
                return;
            }
        }

        private void playVideo()
        {
            if (fr.vidPlayer.VideoOpened)
            {
                try
                {
                    Int32 frameDuration = Convert.ToInt32((Convert.ToDouble(fr.vidPlayer.VideoData.Avs.Clip.Rated) /
                        Convert.ToDouble(fr.vidPlayer.VideoData.Avs.Clip.Raten)) * 1000.0);
                    Int32 sleepTime = 0;
                    Stopwatch actime = new Stopwatch();
                    while (fr.vidPlayer.VideoData.CurrentFrame <= fr.vidPlayer.VideoData.Avs.Clip.NumberOfFrames - 1 && fr.vidPlayer.VideoPlaying)
                    {
                        actime.Start();
                        fr.vidPlayer.GetNextFrame();
                        actime.Stop();
                        sleepTime = Convert.ToInt32(frameDuration - actime.ElapsedMilliseconds);
                        if (sleepTime < 0)
                        {
                            sleepTime = 0;
                        }
                        Thread.Sleep(sleepTime);
                    }
                    //Check if stop was pressed
                    if (fr.vidPlayer.VideoData.CurrentFrame > trackVideo.Maximum)
                    {
                        //The video has reached the end frame
                        btnPlayVideo.Text = "Play";
                        fr.vidPlayer.VideoPlaying = false;
                    }
                }
                catch (Exception ex)
                {
                    AcLogger.Log(new AcException("Error playing video!", ex), AcLogType.FileAndLogger);
                }
            }

        }

        private void FrameRestorationForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (fr.vidPlayer.VideoOpened)
                {
                    if (e.KeyCode == Keys.Right)
                    {
                        if (e.Modifiers == Keys.Control)
                        {
                            if (fr.vidPlayer.VideoData.CurrentFrame + 10 >= fr.vidPlayer.VideoData.Avs.Clip.NumberOfFrames)
                            {
                                fr.vidPlayer.GetLastFrame();
                                refreshGUI();
                                //trackVideo.Value = vidPlayer.VideoData.Avs.Clip.NumberOfFrames - 1;
                                return;
                            }
                            else
                            {
                                fr.vidPlayer.GetNextFrame(10);
                                refreshGUI();
                                //trackVideo.Value += 10;
                                return;
                            }
                        }
                        else
                        {
                            if (fr.vidPlayer.VideoData.CurrentFrame + 1 >= fr.vidPlayer.VideoData.Avs.Clip.NumberOfFrames)
                            {
                                fr.vidPlayer.GetLastFrame();
                                refreshGUI();
                                //trackVideo.Value = vidPlayer.VideoData.Avs.Clip.NumberOfFrames - 1;
                                return;
                            }
                            else
                            {
                                fr.vidPlayer.GetNextFrame();
                                refreshGUI();
                                //trackVideo.Value++;
                                return;
                            }
                        }
                    }
                    else if (e.KeyCode == Keys.Left)
                    {
                        if (e.Modifiers == Keys.Control)
                        {
                            if (fr.vidPlayer.VideoData.CurrentFrame - 10 < 0)
                            {
                                fr.vidPlayer.GetFrame(0);
                                refreshGUI();
                                //trackVideo.Value = 0;
                                return;
                            }
                            else
                            {
                                fr.vidPlayer.GetPrevFrame(10);
                                refreshGUI();
                                //trackVideo.Value -= 10;
                                return;
                            }
                        }
                        else
                        {
                            if (fr.vidPlayer.VideoData.CurrentFrame - 1 < 0)
                            {
                                fr.vidPlayer.GetFrame(0);
                                refreshGUI();
                                //trackVideo.Value = 0;
                                return;
                            }
                            else
                            {
                                fr.vidPlayer.GetPrevFrame();
                                refreshGUI();
                                //trackVideo.Value--;
                                return;
                            }
                        }
                    }
                    else if (e.KeyCode == Keys.F2)
                    {
                        //btnReload_Click(null, null);
                        return;
                    }
                    else if (e.KeyCode == Keys.G && e.Modifiers == Keys.Control)
                    {
                        String result = AcInputBox.Show("Enter frame number :", "Enter frame number", "");
                        if (result != null)
                        {
                            txtFrame.Text = result;
                        }
                        btnGoToFrame_Click(null, null);
                        refreshGUI();
                        return;
                    }
                    else if (e.KeyCode == Keys.Space)
                    {
                        btnPlayVideo_Click(null, null);
                        return;
                    }
                    else if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.Subtract || e.KeyCode == Keys.Z)
                    {
                        btnDeleteFrame_Click(null, null);
                        refreshGUI();
                    }
                    else if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.Add || e.KeyCode == Keys.X)
                    {
                        btnDuplicate_Click(null, null);
                        refreshGUI();
                    }
                }
            }
            catch (Exception ex)
            {
                AcLogger.Log(ex, AcLogType.FileAndLogger);
            }
        }

        private void refreshGUI()
        {
            picVideoFrameCurrent.Refresh();
            picVideoFrameNext.Refresh();
            picVideoFramePrevious.Refresh();
            txtCurrentTime.Refresh();
            txtFrame.Refresh();
            txtStatusCurrent.Refresh();
            txtStatusNext.Refresh();
            txtStatusPrevious.Refresh();
            txtVideoFrameCurrent.Refresh();
            txtVideoFrameNext.Refresh();
            txtVideoFramePrevious.Refresh();
            Application.DoEvents();

        }

        private void checkKeepAspectRatio_CheckedChanged(object sender, EventArgs e)
        {
            if (checkKeepAspectRatio.Checked)
            {
                picVideoFrameCurrent.SizeMode = PictureBoxSizeMode.Zoom;
                picVideoFramePrevious.SizeMode = PictureBoxSizeMode.Zoom;
                picVideoFrameNext.SizeMode = PictureBoxSizeMode.Zoom;

                picVideoFrameCurrent.BackColor = Color.LightSteelBlue;
                picVideoFramePrevious.BackColor = Color.LightSteelBlue;
                picVideoFrameNext.BackColor = Color.LightSteelBlue;
            }
            else
            {
                picVideoFrameCurrent.SizeMode = PictureBoxSizeMode.StretchImage;
                picVideoFramePrevious.SizeMode = PictureBoxSizeMode.StretchImage;
                picVideoFrameNext.SizeMode = PictureBoxSizeMode.StretchImage;

                picVideoFrameCurrent.BackColor = Color.AliceBlue;
                picVideoFramePrevious.BackColor = Color.AliceBlue;
                picVideoFrameNext.BackColor = Color.AliceBlue;
            }
        }

        private void SaveFiles()
        {
            if (fr.frpf.ProjectFile == String.Empty)
            {
                throw new Exception("Please provide with a project file first!");
            }
            if (fr.frpf.AviSynthOutputFile == String.Empty)
            {
                fr.frpf.AviSynthOutputFile = fr.frpf.ProjectFile.Substring(0, fr.frpf.ProjectFile.LastIndexOf(".")) + ".avs";
            }
            //Write the AviSynth Output file
            fr.WriteAvisynthOutputFile();
            //Write the Frame Restoration Project file
            fr.WriteProject();
        }

        private void AutoCommit()
        {
            //Check if auto-commit is checked to save files
            if (checkAutoCommit.Checked)
            {
                SaveFiles();
            }
        }

        private void btnSaveFiles_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFiles();
            }
            catch (Exception ex)
            {
                AcLogger.Log(ex, AcLogType.FileAndLogger);
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                //Make sure that files have the latest edits
                SaveFiles();

                //Open the preview form (VideoPlayerForm)
                frmVideoPlayer vpf = new frmVideoPlayer(fr.frpf.AviSynthOutputFile);

                //Show the form
                vpf.Show();
            }
            catch (Exception ex)
            {
                AcLogger.Log(ex, AcLogType.FileAndLogger);
            }
        }

        private void UpdateCurrentFrameStatus() 
        {
            UpdateTxtStatusCurrent(Enum.GetName(typeof(FrameProcessType), fr.frpf.FrameList.FrameList[fr.vidPlayer.VideoData.CurrentFrame].ProcessType));
        }


        private void UpdateListChanges()
        {
            //Empty list
            listChanges.Items.Clear();

            //Add the deleted frames
            foreach (VideoFrame vf in fr.frpf.FrameList.FrameSections[0].FramesToDelete.FrameList)
            {
                //Add change to the list
                listChanges.Items.Add(vf.FrameNumber + " -> Delete");
            }

            //Add the duplicated frames
            foreach (VideoFrame vf in fr.frpf.FrameList.FrameSections[0].FramesToDuplicate.FrameList)
            {
                //Add change to the list
                listChanges.Items.Add(vf.FrameNumber + " -> Duplicate");
            }

            //Refresh the list
            listChanges.Refresh();
        }

        private void btnDeleteFrame_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean newOperation = true;
                //Check if this frame is already deleted or duplicated
                foreach (VideoFrame vf in fr.frpf.FrameList.FrameSections[0].FramesToDelete.FrameList)
                {
                    if (vf.FrameNumber == fr.vidPlayer.VideoData.CurrentFrame)
                    {
                        throw new Exception("Frame is already deleted!");
                    }
                }
                //Check if this frame is already deleted or duplicated
                foreach (VideoFrame vf in fr.frpf.FrameList.FrameSections[0].FramesToDuplicate.FrameList)
                {
                    if (vf.FrameNumber == fr.vidPlayer.VideoData.CurrentFrame)
                    {
                        vf.ProcessType = FrameProcessType.ToDelete;
                        newOperation = false;
                        break;
                    }
                }

                if (newOperation)
                {
                    //Add current frame to the deleted ones
                    fr.AddDelete(fr.vidPlayer.VideoData.CurrentFrame);
                }

                //Check if auto-commit is checked to save files
                AutoCommit();

                //Add change to the list
                UpdateListChanges();

                //Refresh the GUI
                UpdateCurrentFrameStatus();
            }
            catch (Exception ex)
            {
                AcLogger.Log(ex, AcLogType.FileAndLogger);
            }
        }

        private void btnDuplicate_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean newOperation = true;
                //Check if this frame is already deleted or duplicated
                foreach (VideoFrame vf in fr.frpf.FrameList.FrameSections[0].FramesToDelete.FrameList)
                {
                    if (vf.FrameNumber == fr.vidPlayer.VideoData.CurrentFrame)
                    {
                        vf.ProcessType = FrameProcessType.ToDuplicate;
                        newOperation = false;
                        break;
                    }
                }

                if (newOperation)
                {
                    //Add current frame to the duplicate ones
                    fr.AddDuplicate(fr.vidPlayer.VideoData.CurrentFrame);
                }

                //Check if auto-commit is checked to save files
                AutoCommit();

                //Add change to the list
                UpdateListChanges();

                //Refresh the GUI
                UpdateCurrentFrameStatus();
            }
            catch (Exception ex)
            {
                AcLogger.Log(ex, AcLogType.FileAndLogger);
            }
        }

        private void btnDeleteChange_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if an item is selected
                if (listChanges.SelectedIndex > -1)
                {
                    //Get the frame number of the change
                    Int32 frameNum = 0;
                    frameNum = Int32.Parse(listChanges.SelectedItem.ToString().Substring(0, listChanges.SelectedItem.ToString().IndexOf("->")).Trim());

                    //Check if the change is for deleted or duplicated frame
                    if (listChanges.SelectedItem.ToString().Contains("Delete"))
                    {
                        fr.RemoveDelete(frameNum);
                    }
                    else if (listChanges.SelectedItem.ToString().Contains("Duplicate"))
                    {
                        fr.RemoveDuplicate(frameNum);
                    }

                    //Remove the change from the list
                    UpdateListChanges();

                    //Check if auto-commit is checked to save files
                    AutoCommit();

                    //Refresh the GUI
                    UpdateCurrentFrameStatus();
                }
            }
            catch (Exception ex)
            {
                AcLogger.Log(ex, AcLogType.FileAndLogger);
            }
        }

        private void listChanges_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Get the frame number of the change
                Int32 frameNum = 0;
                frameNum = Int32.Parse(listChanges.SelectedItem.ToString().Substring(0, listChanges.SelectedItem.ToString().IndexOf("->")).Trim());

                //Go to the frame of the change
                fr.vidPlayer.GetFrame(frameNum);
            }
            catch (Exception ex)
            {
                AcLogger.Log(ex, AcLogType.FileAndLogger);
            }
        }

        private void picVideoFrameCurrent_Click(object sender, EventArgs e)
        {
            txtCurrentTime.Focus();
        }

        private void btnUpdateProjectProperties_Click(object sender, EventArgs e)
        {
            try
            {
                fr.frpf.VideoFile = txtVideoFile.Text;
                fr.frpf.TimecodesFile = txtTimecodesFile.Text;
                fr.frpf.AviSynthOutputFile = txtAvisynthOutputFile.Text;
                fr.frpf.ProjectFile = txtProjectFile.Text;

                SaveFiles();
            }
            catch (Exception ex)
            {
                AcLogger.Log(ex, AcLogType.FileAndLogger);
            }
        }

        private void checkUsePreview_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}
