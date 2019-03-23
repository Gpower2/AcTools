using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Media;
using System.Diagnostics;

using AcTools.Core;
using AcTools.CommonForms;

using AcToolsLibrary.Common;
using AcToolsLibrary.Core.Video;
using AcToolsLibrary.Core.Video.VideoProviders.AviSynth;
using AcToolsLibrary.Core.Video.VideoProviders.AviSynth.VideoSourceProviders;

using AcControls.AcVideoFramePictureBox;
using AcControls.AcVideoSlider;
using AcControls.Utilities;
using AcControls.AcMessageBox;
using System.Threading.Tasks;

namespace AcTools.Forms
{

    public partial class frmVideoPlayer : AcForm
    {
        private AvsFile avs = null;
        private frmVideoPlayerCrop vpcf = null;
        private frmSectionEditor sef = null;
        private VideoFrameList vfl = new VideoFrameList();
        private Boolean videoOpened = false;
        private Boolean videoPlaying = false;
        private String fileOpened = String.Empty;
        private String fileToOpen = String.Empty;
        private Thread videoPlayThread = null;
        private Decimal frameRate = 0.0m;
        private DateTime trackBarTooltipLastUpdate;

        private Int32 curFrame = 0;
        private Int32 startPlayFrame = 0;
        private Int32 endPlayFrame = 0;
        private Int32 cropX1 = 0, cropX2 = 0, cropY1 = 0, cropY2 = 0;
        private Int32 origPicVideoWidth = 0;
        private Int32 origPicVideoHeight = 0;

        private static String formName = "Video Player";
        private static UInt16 trackBarTooltipUpdateIntervall = 100;

        #region "Properties"

        public Int32 CropX1
        {
            get
            {
                return cropX1;
            }
            set
            {
                cropX1 = value;
            }
        }

        public Int32 CropX2
        {
            get
            {
                return cropX2;
            }
            set
            {
                cropX2 = value;
            }
        }

        public Int32 CropY1
        {
            get
            {
                return cropY1;
            }
            set
            {
                cropY1 = value;
            }
        }

        public Int32 CropY2
        {
            get
            {
                return cropY2;
            }
            set
            {
                cropY2 = value;
            }
        }

        /// <summary>
        /// Gets the current video frame
        /// </summary>
        public Int32 CurrentFrame
        {
            get
            {
                return curFrame;
            }
        }

        /// <summary>
        /// The Video Frame List
        /// </summary>
        public VideoFrameList FrameList
        {
            get
            {
                return vfl;
            }
            set
            {
                vfl = value;
            }
        }

        /// <summary>
        /// The Section Editor form
        /// </summary>
        public frmSectionEditor SectionForm
        {
            get
            {
                return sef;
            }
            set
            {
                sef = value;
            }
        }

        public Decimal Framerate
        {
            get
            {
                return frameRate;
            }
        }

        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public frmVideoPlayer()
        {
            try
            {
                InitializeComponent();
                InitColors();
                InitControls();
                InitIcon();
                Init();
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        /// <summary>
        /// Opens the form with a prespecified video file
        /// </summary>
        /// <param name="videoFile">the video file</param>
        public frmVideoPlayer(String videoFile)
        {
            try
            {
                InitializeComponent();
                InitColors();
                InitControls();
                InitIcon();
                Init();
                txtVideoFile.Text = videoFile;
                btnOpen_Click(this, null);
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void Init()
        {
            this.Text = frmVideoPlayer.formName;
            fillSizes();
            picVideo.AllowDrop = true;
            origPicVideoWidth = picVideo.Width;
            origPicVideoHeight = picVideo.Height;
            chkDontDropFrames.Checked = true;
        }

        /// <summary>
        /// Open a video file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                OpenVideo();
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                ShowExceptionMessage(ex);
            }
        }

        private void OpenVideo()
        {
            try
            {
                fileToOpen = txtVideoFile.Text;
                if (fileToOpen.Length < 1)
                {
                    videoOpened = false;
                    return;
                }

                if (avs != null)
                {
                    avs.Dispose();
                }
                // check if file exists
                if (File.Exists(fileToOpen))
                {
                    // check if file is AviSynth Script
                    if (!AcHelper.GetFilename(fileToOpen, GetFileNameMode.ExtensionOnly, GetDirectoryNameMode.NoPath).Contains("avs"))
                    {
                        // If not Avisynth Script, prompt the user to select AviSynth Source Plugin
                        frmAviSynthVideoSource frm = new frmAviSynthVideoSource();
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.ShowDialog();
                        frm.Activate();
                        if (!frm.OKPressed)
                        {
                            return;
                        }
                        // Create the AviSynth Script
                        AviSynthFileCreator avsfc;
                        if (frm.OverrideFramerateChecked)
                        {
                            avsfc = new AviSynthFileCreator(fileToOpen, frm.SelectedAviSynthVideoProvider, frm.OverrideFramerate);
                        }
                        else
                        {
                            avsfc = new AviSynthFileCreator(fileToOpen, frm.SelectedAviSynthVideoProvider);
                        }
                        // Set the new file to open to the newly created AviSynth Script
                        fileToOpen = avsfc.AviSynthScriptFilename;
                    }
                    // Open the Avisynth Script using Task in order to have a responsive UI
                    using (Task t = Task.Factory.StartNew(() =>
                                {
                                    avs = AvsFile.OpenScriptFile(fileToOpen);
                                }))
                    {
                        while (!t.IsCompleted)
                        {
                            Application.DoEvents();
                        }
                        if (t.Exception != null)
                        {
                            Application.DoEvents();
                            if (t.Exception.InnerException != null)
                            {
                                throw t.Exception.InnerException;
                            }
                            else
                            {
                                throw t.Exception;
                            }
                        }
                    }
                    videoOpened = true;
                    //this.Width = avs.Clip.VideoWidth + this.Width - picVideo.Width;
                    this.Width = avs.Clip.VideoWidth + this.MinimumSize.Width - origPicVideoWidth;
                    //this.Height = avs.Clip.VideoHeight + this.Height - picVideo.Height;
                    this.Height = avs.Clip.VideoHeight + this.MinimumSize.Height - origPicVideoHeight;
                    //VideoPlayerForm_Resize(null, null);
                    this.frameRate = Convert.ToDecimal(avs.Clip.Raten) / Convert.ToDecimal(avs.Clip.Rated);
                    trackVideo.Maximum = avs.Clip.NumberOfFrames - 1;
                    trackVideo.Minimum = 0;
                    trackVideo.Value = 0;
                    cmbSize.SelectedIndex = 5;
                    fileOpened = fileToOpen;
                    this.Text = frmVideoPlayer.formName + " - " + fileOpened;
                    txtVideoFile.Text = fileOpened;
                    ChangeVideoFrame(0, false);
                }
                else
                {
                    videoOpened = false;
                }
            }
            catch (Exception)
            {
                videoOpened = false;
                throw;
            }
        }

        private void GoToFrame(Int32 value)
        {
            if (videoOpened)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    if (value > trackVideo.Maximum)
                    {
                        value = trackVideo.Maximum;
                    }
                    else if (value < 0)
                    {
                        value = 0;
                    }
                    trackVideo.Value = value;
                    this.Cursor = Cursors.Default;
                }
                catch (Exception ex)
                {
                    AcUtilities.DebugWrite(ex.ToString());
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                if (videoOpened)
                {
                    if (curFrame - 10 < 0)
                    {
                        trackVideo.Value = 0;
                    }
                    else
                    {
                        trackVideo.Value -= 10;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            try
            {
                if (videoOpened)
                {
                    if (curFrame + 10 >= avs.Clip.NumberOfFrames)
                    {
                        trackVideo.Value = avs.Clip.NumberOfFrames - 1;
                    }
                    else
                    {
                        trackVideo.Value += 10;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void trackVideo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                ChangeVideoFrame(trackVideo.Value, false);
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void ChangeVideoFrame(Int32 videoFrame, Boolean isCrossThread)
        {
            if (videoOpened && !videoPlaying)
            {
                //Fail safe check
                if (videoFrame > avs.Clip.NumberOfFrames - 1)
                {
                    return;
                }
                curFrame = videoFrame;
                Decimal rate = Convert.ToDecimal(avs.Clip.Raten) / Convert.ToDecimal(avs.Clip.Rated);
                Bitmap newFrame = avs.GetVideoReader().ReadFrameBitmap(curFrame);
                String newFrameText = curFrame + "/" + (avs.Clip.NumberOfFrames - 1);
                String newFrameTime = VideoFrame.FrameTimeFromFrameNumber(curFrame, rate, FrameFromType.FromFrameRate);
                if (!isCrossThread)
                {
                    UpdatePicVideo(ref newFrame);
                    UpdatetxtVideoFrame(newFrameText);
                    UpdatetxtVideoTime(newFrameTime);
                }
                else
                {
                    picVideo.BeginInvoke(new UpdateImageCallback(this.UpdatePicVideo),
                        new object[] { newFrame });
                    txtVideoFrame.BeginInvoke(new UpdateTextCallback(this.UpdatetxtVideoFrame),
                        new object[] { newFrameText });
                    txtVideoTime.BeginInvoke(new UpdateTextCallback(this.UpdatetxtVideoTime),
                        new object[] { newFrameTime });
                }
                if (chkDontDropFrames.Checked)
                {
                    picVideo.Refresh();
                }
            }
        }

        private void txtVideo_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void txtVideo_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                String[] s = (String[])e.Data.GetData(DataFormats.FileDrop, false);
                txtVideoFile.Text = s[0];
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnHook_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnResetSize_Click(object sender, EventArgs e)
        {
            try
            {
                if (videoOpened)
                {
                    Double zoom = AcHelper.DoubleParse(((String)cmbSize.SelectedItem).Replace("%", String.Empty)) / 100.0;
                    int width = Convert.ToInt32(Convert.ToDouble(avs.Clip.VideoWidth) * zoom);
                    int height = Convert.ToInt32(Convert.ToDouble(avs.Clip.VideoHeight) * zoom);
                    //this.Width = width + this.Width - picVideo.Width;
                    this.Width = width + this.MinimumSize.Width - origPicVideoWidth;
                    //this.Height = height + this.Height - picVideo.Height;
                    this.Height = height + this.MinimumSize.Height - origPicVideoHeight;
                    //VideoPlayerForm_Resize(null, null);
                    //picVideo.Width = width;
                    //picVideo.Height = height;
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnCopyFrameTime_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(txtVideoTime.Text);
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex, "Error copying frame time!");
            }
        }

        private void btnCopyFrameNumber_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(txtVideoFrame.Text.Substring(0, txtVideoFrame.Text.IndexOf("/")));
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex, "Error copying frame number!");
            }
        }

        private void picVideo_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                String[] s = (String[])e.Data.GetData(DataFormats.FileDrop, false);
                txtVideoFile.Text = s[0];
                btnOpen_Click(null, null);
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void picVideo_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void VideoPlayerForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Right)
                {
                    if (e.Modifiers == Keys.Control)
                    {
                        if (curFrame + 10 >= avs.Clip.NumberOfFrames)
                        {
                            trackVideo.Value = avs.Clip.NumberOfFrames - 1;
                            return;
                        }
                        else
                        {
                            trackVideo.Value += 10;
                            return;
                        }
                    }
                    else
                    {
                        if (curFrame + 1 >= avs.Clip.NumberOfFrames)
                        {
                            trackVideo.Value = avs.Clip.NumberOfFrames - 1;
                            return;
                        }
                        else
                        {
                            trackVideo.Value++;
                            return;
                        }
                    }
                }
                else if (e.KeyCode == Keys.Left)
                {
                    if (e.Modifiers == Keys.Control)
                    {
                        if (curFrame - 10 < 0)
                        {
                            trackVideo.Value = 0;
                            return;
                        }
                        else
                        {
                            trackVideo.Value -= 10;
                            return;
                        }
                    }
                    else
                    {
                        if (curFrame - 1 < 0)
                        {
                            trackVideo.Value = 0;
                            return;
                        }
                        else
                        {
                            trackVideo.Value--;
                            return;
                        }
                    }
                }
                else if (e.KeyCode == Keys.F2)
                {
                    btnReload_Click(null, null);
                    return;
                }
                else if (e.KeyCode == Keys.G && e.Modifiers == Keys.Control)
                {
                    if (videoOpened)
                    {
                        String result = AcControls.AcInputBox.AcInputBox.Show("Enter frame number :", "Enter frame number", curFrame.ToString());
                        if (result != null)
                        {
                            if (result.Trim().Length > 0)
                            {
                                GoToFrame(Int32.Parse(result.Trim()));
                            }
                        }
                    }
                    return;
                }
                else if (e.KeyCode == Keys.Space)
                {
                    btnPlayVideo_Click(null, null);
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void trackVideo_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                picVideo.Select();
                picVideo.Focus();
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void trackVideo_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (videoOpened)
                {
                    if ((DateTime.Now - trackBarTooltipLastUpdate).Milliseconds > trackBarTooltipUpdateIntervall)
                    {
                        Int32 intValue = trackVideo.GetValueFromMouseClick(e.X);
                        Decimal rate = Convert.ToDecimal(avs.Clip.Raten) / Convert.ToDecimal(avs.Clip.Rated);
                        Tooltip.UseFading = true;
                        Tooltip.SetToolTip(trackVideo, VideoFrame.FrameTimeFromFrameNumber(intValue, rate, FrameFromType.FromFrameRate) +
                            " (" + intValue + ")");
                        trackBarTooltipLastUpdate = DateTime.Now;
                    }
                    else
                    {
                        Application.DoEvents();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void VideoPlayerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (videoPlaying)
                {
                    videoPlaying = false;
                    videoPlayThread.Join();
                    videoPlayThread = null;
                }
                if (picVideo.Image != null)
                {
                    picVideo.Image.Dispose();
                    picVideo.Image = null;
                }
                if (!picVideo.IsDisposed)
                {
                    picVideo.Dispose();
                }
                if (avs != null)
                {
                    avs.Dispose();
                }
                if (vpcf != null && !vpcf.IsDisposed)
                {
                    vpcf.Dispose();
                }
                if (sef != null && !sef.IsDisposed)
                {
                    sef.DisableFromVideoBtns();
                }
                GC.Collect();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                AcLogger.Log(ex, AcLogType.Logger);
            }
        }

        private void btnSmallForward_Click(object sender, EventArgs e)
        {
            try
            {
                if (videoOpened)
                {

                    if (curFrame + 1 >= avs.Clip.NumberOfFrames)
                    {
                        trackVideo.Value = avs.Clip.NumberOfFrames - 1;
                        return;
                    }
                    else
                    {
                        trackVideo.Value++;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnSmallBack_Click(object sender, EventArgs e)
        {
            try
            {
                if (videoOpened)
                {
                    if (curFrame - 1 < 0)
                    {
                        trackVideo.Value = 0;
                        return;
                    }
                    else
                    {
                        trackVideo.Value--;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtVideoFile.Text.Length > 0)
                {
                    this.Cursor = Cursors.WaitCursor;
                    int prevFrame = trackVideo.Value;
                    if (avs != null)
                    {
                        avs.Dispose();
                    }
                    avs = AvsFile.OpenScriptFile(txtVideoFile.Text);
                    trackVideo.Maximum = avs.Clip.NumberOfFrames - 1;
                    trackVideo.Minimum = 0;
                    trackVideo.Value = prevFrame;
                    videoOpened = true;
                    trackVideo_ValueChanged(null, null);
                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                videoOpened = false;
                this.Cursor = Cursors.Default;
                ShowExceptionMessage(ex, "Error reloading video!");
            }
        }

        private void fillSizes()
        {
            cmbSize.Items.Clear();
            cmbSize.Items.Add("200%");
            cmbSize.Items.Add("175%");
            cmbSize.Items.Add("150%");
            cmbSize.Items.Add("133%");
            cmbSize.Items.Add("125%");
            cmbSize.Items.Add("100%");
            cmbSize.Items.Add("75%");
            cmbSize.Items.Add("50%");
            cmbSize.Items.Add("33%");
            cmbSize.Items.Add("25%");
            cmbSize.Items.Add("6%");
        }

        private void btnBrowseVideoFile_Click(object sender, EventArgs e)
        {
            try
            {
                String[] filenames = ShowOpenFileDialog("Select video file...", String.Empty, String.Empty, false);
                if (filenames != null)
                {
                    if (filenames.Length > 0)
                    {
                        txtVideoFile.Text = filenames[0];
                    }
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void playVideo()
        {
            if (videoOpened)
            {
                try
                {
                    curFrame = startPlayFrame;
                    Int32 sleepTime = 0;
                    Stopwatch actime = new Stopwatch();
                    Decimal frameDuration = (Convert.ToDecimal(avs.Clip.Rated) / Convert.ToDecimal(avs.Clip.Raten)) * 1000.0m;
                    Decimal rate = Convert.ToDecimal(avs.Clip.Raten) / Convert.ToDecimal(avs.Clip.Rated);
                    while (curFrame <= endPlayFrame && videoPlaying)
                    {
                        actime.Restart();
                        //actime.Start();
                        trackVideo.BeginInvoke(new UpdateTrackValueCallback(this.UpdateTrackValue),
                            new object[] { curFrame });
                        picVideo.BeginInvoke(new UpdateImageCallback(this.UpdatePicVideo),
                            new object[] { avs.GetVideoReader().ReadFrameBitmap(curFrame) });
                        txtVideoFrame.BeginInvoke(new UpdateTextCallback(this.UpdatetxtVideoFrame),
                            new object[] { curFrame + "/" + (avs.Clip.NumberOfFrames - 1) });
                        txtVideoTime.BeginInvoke(new UpdateTextCallback(this.UpdatetxtVideoTime),
                            new object[] { VideoFrame.FrameTimeFromFrameNumber(curFrame, rate, FrameFromType.FromFrameRate) });
                        actime.Stop();
                        sleepTime = Convert.ToInt32(frameDuration - actime.ElapsedMilliseconds);
                        if (sleepTime > 0)
                        {
                            Thread.Sleep(sleepTime);
                        }
                        curFrame++;
                    }
                    //Check if stop was pressed
                    if (curFrame > trackVideo.Maximum)
                    {
                        //The video has reached the end frame
                        btnPlayVideo.BeginInvoke(new UpdateBtnPlayValueCallback(this.UpdateBtnPlayValue),
                            new object[] { "Play" });
                        trackVideo.BeginInvoke(new UpdateTrackValueCallback(this.UpdateTrackValue),
                            new object[] { trackVideo.Maximum });
                    }
                    videoPlaying = false;
                }
                catch (Exception ex)
                {
                    videoPlaying = false;
                    ShowExceptionMessage(ex, "Error playing video!");
                }
            }
        }

        private void btnPlayVideo_Click(object sender, EventArgs e)
        {
            try
            {
                if (videoPlaying)
                {
                    videoPlaying = false;
                    videoPlayThread.Join();
                    videoPlayThread = null;
                    btnPlayVideo.Text = "Play";
                    trackVideo.Value = curFrame;
                    return;
                }
                else
                {
                    videoPlaying = true;
                    startPlayFrame = trackVideo.Value + 1;
                    endPlayFrame = trackVideo.Maximum;
                    btnPlayVideo.Text = "Stop";
                    videoPlayThread = new Thread(new ThreadStart(playVideo));
                    videoPlayThread.Start();
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void UpdatetxtVideoFrame(String text)
        {
            txtVideoFrame.Text = text;
        }
        private void UpdatetxtVideoTime(String text)
        {
            txtVideoTime.Text = text;
        }
        private void UpdatePicVideo(ref Bitmap img)
        {
            if (picVideo.Image != null)
            {
                picVideo.Image.Dispose();
            }
            picVideo.Image = PrepareVideoFrameImage(ref img);
        }
        private void UpdateTrackValue(Int32 value)
        {
            trackVideo.Value = value;
        }

        private void UpdateBtnPlayValue(String str)
        {
            btnPlayVideo.Text = str;
        }

        private delegate void UpdateTextCallback(String text);
        private delegate void UpdateImageCallback(ref Bitmap img);
        private delegate void UpdateTrackValueCallback(Int32 value);
        private delegate void UpdateBtnPlayValueCallback(String str);

        private void btnGoToStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (videoOpened)
                {
                    trackVideo.Value = 0;
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnGoToEnd_Click(object sender, EventArgs e)
        {
            try
            {
                if (videoOpened)
                {
                    trackVideo.Value = trackVideo.Maximum;
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnSaveScreenshot_Click(object sender, EventArgs e)
        {
            try
            {
                if (videoOpened)
                {
                    String filename = ShowSaveFileDialog("Select image", String.Empty, "*.png|*.png");
                    if (filename != null)
                    {
                        if (filename.Length > 0)
                        {
                            picVideo.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private Bitmap PrepareVideoFrameImage(ref Bitmap img)
        {
            if (cropX1 == 0 && cropX2 == 0 && cropY1 == 0 && cropY2 == 0)
            {
                return img;
            }

            Graphics g = Graphics.FromImage(img);
            if (cropX1 > 0)
            {
                g.FillRectangle(Brushes.Gray, 0, 0, cropX1, img.Height);
            }
            if (cropX2 > 0)
            {
                g.FillRectangle(Brushes.Gray, img.Width - cropX2, 0, cropX2, img.Height);
            }
            if (cropY1 > 0)
            {
                g.FillRectangle(Brushes.Gray, 0, 0, img.Width, cropY1);
            }
            if (cropY2 > 0)
            {
                g.FillRectangle(Brushes.Gray, 0, img.Height - cropY2, img.Width, cropY2);
            }
            g.Dispose();
            return img;
        }

        public void UpdateVideoFrameImage()
        {
            ChangeVideoFrame(CurrentFrame, true);
            //trackVideo_ValueChanged(null, null);
        }

        private void btnCrop_Click(object sender, EventArgs e)
        {
            try
            {
                if (videoOpened)
                {
                    if (vpcf != null)
                    {
                        if (vpcf.IsDisposed)
                        {
                            vpcf = new frmVideoPlayerCrop(this, avs.Clip.VideoWidth, avs.Clip.VideoHeight);
                        }
                    }
                    else
                    {
                        vpcf = new frmVideoPlayerCrop(this, avs.Clip.VideoWidth, avs.Clip.VideoHeight);
                    }
                    vpcf.SetCropValues(cropX1, cropY1, cropX2, cropY2);
                    ShowForm(vpcf);
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            try
            {
                using (AcToolsLibrary.Core.MediaInfo.AcMediaInfo mi = new AcToolsLibrary.Core.MediaInfo.AcMediaInfo(txtVideoFile.Text))
                {
                    AcMessageBox.Show(mi.InfoCustom, "Video Info", MessageBoxIcon.Information);
                }
                if (videoOpened)
                {
                    StringBuilder strb = new StringBuilder();
                    strb.AppendFormat("Video Resolution : {0}x{1}", avs.Clip.VideoWidth, avs.Clip.VideoHeight);
                    strb.AppendLine();
                    strb.AppendFormat("Video Framerate : {0} ({1}/{2})",
                        (Convert.ToDecimal(avs.Clip.Raten) / Convert.ToDecimal(avs.Clip.Rated)).ToString("###.000"), avs.Clip.Raten, avs.Clip.Rated);
                    strb.AppendLine();
                    strb.AppendFormat("Total frames : {0}", avs.Clip.NumberOfFrames);
                    strb.AppendLine();
                    strb.AppendFormat("Total duration : {0}", VideoFrame.FrameTimeFromFrameNumber(avs.Clip.NumberOfFrames,
                        Convert.ToDecimal(avs.Clip.Raten) / Convert.ToDecimal(avs.Clip.Rated), FrameFromType.FromFrameRate));
                    strb.AppendLine();
                    strb.AppendFormat("Colorspace : {0}", Enum.GetName(typeof(AviSynthColorspace), avs.Clip.OriginalColorspace));
                    strb.AppendLine();
                    strb.AppendFormat("Pixel type : {0}", Enum.GetName(typeof(AviSynthColorspace), avs.Clip.PixelType));
                    strb.AppendLine();
                    strb.AppendFormat("Aspect ratio : {0}/{1}", avs.Clip.aspectn, avs.Clip.aspectd);

                    Clipboard.SetDataObject(strb.ToString());
                    AcMessageBox.Show(strb.ToString(), "Video Info", MessageBoxIcon.Information);                    
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void picVideo_MouseClick(object sender, MouseEventArgs e)
        {
            txtVideoFrame.Focus();
        }

        private void btnSections_Click(object sender, EventArgs e)
        {
            try
            {
                if (sef != null)
                {
                    if (sef.IsDisposed)
                    {
                        sef = new frmSectionEditor(this);
                    }
                }
                else
                {
                    sef = new frmSectionEditor(this);
                }
                sef.FrameList = vfl;
                sef.RefreshSectionList();
                ShowForm(sef);
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void VideoPlayerForm_Resize(object sender, EventArgs e)
        {
            try
            {
                if (videoOpened)
                {
                    //Ensure that the video picture box will always have the correct size
                    int startHeight = this.Height - (this.MinimumSize.Height - origPicVideoHeight);
                    int startWidth = this.Width - (this.MinimumSize.Width - origPicVideoWidth);
                    //picVideo.Height = this.Height - (this.MinimumSize.Height - origPicVideoHeight);
                    //int height = picVideo.Height;
                    int height = Convert.ToInt32(Convert.ToDouble(startWidth * avs.Clip.VideoHeight) / Convert.ToDouble(avs.Clip.VideoWidth));
                    int width = Convert.ToInt32(Convert.ToDouble(startHeight * avs.Clip.VideoWidth) / Convert.ToDouble(avs.Clip.VideoHeight));
                    if (startWidth > width)
                    {
                        picVideo.Height = startHeight;
                        picVideo.Width = width;
                    }
                    else if (startWidth < width)
                    {
                        picVideo.Height = height;
                        picVideo.Width = startWidth;
                    }
                    else
                    {
                        picVideo.Height = startHeight;
                        picVideo.Width = startWidth;
                    }
                    picVideo.Location = new Point(2, 2);
                    picVideo.Refresh();
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void chkAlwaysOnTop_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.TopMost = chkAlwaysOnTop.Checked;
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnEditVideoFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(txtVideoFile.Text))
                {
                    if (!File.Exists(txtVideoFile.Text))
                    {
                        throw new FileNotFoundException("The AviSynth video file does not exist!");
                    }
                    ProcessStartInfo psi = new ProcessStartInfo(txtVideoFile.Text);
                    psi.UseShellExecute = true;
                    Process.Start(psi);
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }
    }
}
