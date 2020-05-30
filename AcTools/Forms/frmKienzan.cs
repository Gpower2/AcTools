using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Management;
using System.Threading;
using System.Globalization;
using System.Diagnostics;

using AcTools.Core;

using AcControls.Utilities;

using AcToolsLibrary.Common;
using AcToolsLibrary.Core.Video;
using AcToolsLibrary.Core.Parsers;

namespace AcTools.Forms
{
    public partial class frmKienzan : AcForm
    {
        private Kienzan _Kienzan = new Kienzan();
        private Boolean _CancelThread = false;
        private Boolean _FormClosing = false;

        public frmKienzan()
        {
            InitializeComponent();
            InitControls();
            InitColors();
            InitIcon(AcTools.Properties.Resources.Kienzan);
            this.Text = "Kienzan Kai";
            fillComboFramerate();
            progressKienzan.Minimum = 0;
            progressKienzan.Maximum = 100;
        }

        #region "Init Functions"

        private void fillComboFramerate()
        {
            comTargetFramerate.Items.Clear();
            comTargetFramerate.Items.Add("29.97");
            comTargetFramerate.Items.Add("23.976");
            comTargetFramerate.Items.Add("25");
            comTargetFramerate.SelectedIndex = 1;
        }

        #endregion

        #region "File handling"

        private void btnBrowseVideoFile_Click(object sender, EventArgs e)
        {
            try
            {
                String[] filenames = ShowOpenFileDialog("Select Video file...", "", "", false);
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

        private void btnBrowseTimecodesFile_Click(object sender, EventArgs e)
        {
            try
            {
                String filename = ShowSaveFileDialog("Save Timecodesfile file...", "", "");
                if (filename != null)
                {
                    txtTimecodesFile.Text = filename;
                }
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
                String filename = ShowSaveFileDialog("Save Duplicates file...", "", "");
                if (filename != null)
                {
                    txtDuplicatesFile.Text = filename;
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnBrowseSectionsFile_Click(object sender, EventArgs e)
        {
            try
            {
                String[] filenames = ShowOpenFileDialog("Select sections file...", "", "", false);
                if (filenames != null)
                {
                    if (filenames.Length > 0)
                    {
                        txtSectionsFile.Text = filenames[0];
                    }
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnBrowseAssFile_Click(object sender, EventArgs e)
        {
            try
            {
                String[] filenames = ShowOpenFileDialog("Select ass file...", "", "", false);
                if (filenames != null)
                {
                    if (filenames.Length > 0)
                    {
                        txtAssFile.Text = filenames[0];
                    }
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        #endregion

        #region "Drag Drop handling"

        private void txtBox_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                String[] s = (String[])e.Data.GetData(DataFormats.FileDrop, false);
                ((TextBox)sender).Text = s[0];
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void txtBox_DragEnter(object sender, DragEventArgs e)
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

        #endregion

        private void miniLog(String str)
        {
            //Add the String to the log list
            listLog.Items.Add(String.Format("{0} {1}", DateTime.Now.ToString("[yyyy-MM-dd][hh:mm:ss.fff]"), str));
            //Autoscroll list
            listLog.SelectedIndex = listLog.Items.Count - 1;
            listLog.SelectedIndex = -1;
        }

        private void btnPreviewVideo_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(txtVideoFile.Text))
                {
                    ShowForm(new frmVideoPlayer(txtVideoFile.Text.Trim()));
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnAnalyseTimecodes_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(txtTimecodesFile.Text))
                {
                    ShowForm(new frmTimeCodeAnalyser(txtTimecodesFile.Text.Trim()));
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnPreviewDuplicates_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(txtDuplicatesFile.Text))
                {
                    ShowForm(new frmDuplicateAnalyser(txtDuplicatesFile.Text));
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnPreviewSections_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtSectionsFile.Text))
            {
                ShowForm(new frmSectionEditor(txtSectionsFile.Text));
            }
            else
            {
                ShowForm(new frmSectionEditor());
            }
        }

        private void btnHook_Click(object sender, EventArgs e)
        {
            HookUnHook(btnHook);
        }

        private void SwapButtonsDuringExecution()
        {
            if (!_FormClosing)
            {
                btnBrowseDuplicatesFile.Enabled = !btnBrowseDuplicatesFile.Enabled;
                btnBrowseSectionsFile.Enabled = !btnBrowseSectionsFile.Enabled;
                btnBrowseTimecodesFile.Enabled = !btnBrowseTimecodesFile.Enabled;
                btnBrowseVideoFile.Enabled = !btnBrowseVideoFile.Enabled;
                btnBrowseAssFile.Enabled = !btnBrowseAssFile.Enabled;

                btnLoadDuplicates.Enabled = !btnLoadDuplicates.Enabled;
                btnLoadSections.Enabled = !btnLoadSections.Enabled;
                btnLoadTimecodes.Enabled = !btnLoadTimecodes.Enabled;
                btnGenerateDuplicates.Enabled = !btnGenerateDuplicates.Enabled;
                btnGenerateTimecodes.Enabled = !btnGenerateTimecodes.Enabled;

                btnResetAll.Enabled = !btnResetAll.Enabled;
                btnRunKienzan.Enabled = !btnRunKienzan.Enabled;
                btnRunKienzanOld.Enabled = !btnRunKienzanOld.Enabled;
                btnCreateCoolEditScript.Enabled = !btnCreateCoolEditScript.Enabled;
                btnCreateMeGUI.Enabled = !btnCreateMeGUI.Enabled;
                btnSyncAss.Enabled = !btnSyncAss.Enabled;
                btnFullyAuto.Enabled = !btnFullyAuto.Enabled;

                comTargetFramerate.Enabled = !comTargetFramerate.Enabled;
                txtDuplicatesFile.ReadOnly = !txtDuplicatesFile.ReadOnly;
                txtSectionsFile.ReadOnly = !txtSectionsFile.ReadOnly;
                txtTimecodesFile.ReadOnly = !txtTimecodesFile.ReadOnly;
                txtVideoFile.ReadOnly = !txtVideoFile.ReadOnly;
            }
        }

        private void ResetAll()
        {
            _Kienzan.Dispose();
            _Kienzan = new Kienzan();
            txtDuplicatesFile.Text = "";
            txtSectionsFile.Text = "";
            txtTimecodesFile.Text = "";
            txtVideoFile.Text = "";
            fillComboFramerate();
        }

        private void CheckVideo()
        {
            if (String.IsNullOrWhiteSpace(txtVideoFile.Text))
            {
                throw new Exception("Please provide with a video file first!");
            }
            if (!File.Exists(txtVideoFile.Text))
            {
                throw new Exception("Please provide with an existing video file first!");
            }
        }

        private void GenerateDuplicates()
        {
            //Check prerequisites
            CheckVideo();

            String videoFile = txtVideoFile.Text;
            Stopwatch actime = new Stopwatch();

            miniLog("Start generating Duplicates...");

            //Create the thread
            Thread genDupThread = new Thread(new ParameterizedThreadStart(_Kienzan.GenerateDuplicatesThreaded));
            //Start tioming
            actime.Start();
            //Start the thread
            genDupThread.Start(videoFile);

            //Wait for the thread to finish while keeping UI responsive
            while (genDupThread.ThreadState != System.Threading.ThreadState.Stopped)
            {
                Application.DoEvents();
                progressKienzan.Value = Convert.ToInt32(_Kienzan.Progress);
            }

            //Stop timing
            actime.Stop();

            if (!_CancelThread)
            {
                //Set the duplicates file
                txtDuplicatesFile.Text = _Kienzan.DuplicatesFile;
            }
            if (_Kienzan.Failed)
            {
                miniLog("Failed generating Duplicates!");
                throw _Kienzan.ThreadedException;
            }
            else
            {
                miniLog(String.Format("Finished generating Duplicates in {0}!", actime.Elapsed));
            }
        }

        private void GenerateTimecodes()
        {
            //Check prerequisites
            CheckVideo();

            String videoFile = txtVideoFile.Text;
            Stopwatch actime = new Stopwatch();
            miniLog("Start generating Timecodes...");

            //Create the thread
            Thread genTcThread = new Thread(new ParameterizedThreadStart(_Kienzan.GenerateTimecodesThreaded));
            //Start timing
            actime.Start();
            //Start the thread
            genTcThread.Start(videoFile);

            //Wait for the thread to finish while keeping UI responsive
            while (genTcThread.ThreadState != System.Threading.ThreadState.Stopped)
            {
                Application.DoEvents();
            }

            //Stop timing
            actime.Stop();

            //Set the timecodes file
            txtTimecodesFile.Text = _Kienzan.TimecodesFile;
            if (_Kienzan.Failed)
            {
                miniLog("Failed generating Timecodes!");
                throw _Kienzan.ThreadedException;
            }
            else
            {
                miniLog(String.Format("Finished generating Timecodes in {0}!", actime.Elapsed));
            }
        }

        private void LoadDuplicates()
        {
            //Check prerequisites
            CheckVideo();

            if (!_Kienzan.HasTimecodes)
            {
                throw new Exception("Please load timecodes first!");
            }
            if (String.IsNullOrWhiteSpace(txtDuplicatesFile.Text))
            {
                throw new Exception("Please provide with a duplicates file first!");
            }
            if (!File.Exists(txtDuplicatesFile.Text))
            {
                throw new Exception("Please provide with an existing duplicates file first!");
            }
            String dupFile = txtDuplicatesFile.Text;
            Stopwatch actime = new Stopwatch();
            //Create the thread
            Thread loadDupThread = new Thread(new ParameterizedThreadStart(_Kienzan.LoadDuplicatesThreaded));

            miniLog("Starting loading duplicates...");
            //Start timing
            actime.Start();
            //Start the thread
            loadDupThread.Start(dupFile);

            //Wait for the thread to finish while keeping UI responsive
            while (loadDupThread.ThreadState != System.Threading.ThreadState.Stopped)
            {
                Application.DoEvents();
            }
            //Stop timing
            actime.Stop();
            if (_Kienzan.Failed)
            {
                miniLog("Failed loading of duplicates!");
                throw _Kienzan.ThreadedException;
            }
            else
            {
                miniLog(String.Format("Successfully loaded duplicates in {0}!", actime.Elapsed));
            }
        }

        private void LoadTimecodes()
        {
            //Check prerequisites
            CheckVideo();

            if (String.IsNullOrWhiteSpace(txtTimecodesFile.Text))
            {
                throw new Exception("Please provide with a timecodes file first!");
            }
            if (!File.Exists(txtTimecodesFile.Text))
            {
                throw new Exception("Please provide with an existing timecodes file first!");
            }
            String tcFile = txtTimecodesFile.Text;
            Stopwatch actime = new Stopwatch();
            //Create the thread
            Thread loadTcThread = new Thread(new ParameterizedThreadStart(_Kienzan.LoadTimecodesThreaded));
            miniLog("Starting loading Timecodes...");
            //Start timing
            actime.Start();
            //Start the thread
            loadTcThread.Start(tcFile);

            //Wait for the thread to finish while keeping UI responsive
            while (loadTcThread.ThreadState != System.Threading.ThreadState.Stopped)
            {
                Application.DoEvents();
            }
            //Stop timing
            actime.Stop();
            if (_Kienzan.Failed)
            {
                miniLog("Failed loading Timecodes!");
                throw _Kienzan.ThreadedException;
            }
            else
            {
                miniLog(String.Format("Successfully loaded Timecodes in {0}!", actime.Elapsed));
            }
            // check if timecodes are CFR
            if (_Kienzan.VideoFrames.IsCFR)
            {
                miniLog("INFORMATION: Video has Constant Frame Rate (CFR), so duplicates ARE NOT required for Kienzan!");
            }
            else
            {
                miniLog("INFORMATION: Video has Variable Frame Rate (VFR), so duplicates ARE required for Kienzan!");
            }
        }

        private void LoadSections()
        {
            //Check prerequisites
            CheckVideo();

            if (!_Kienzan.HasTimecodes)
            {
                throw new Exception("Please load timecodes first!");
            }
            if (txtSectionsFile.Text.Length < 1)
            {
                throw new Exception("Please provide with a sections file first!");
            }
            if (!File.Exists(txtSectionsFile.Text))
            {
                throw new Exception("Please provide with an existing sections file first!");
            }
            String secFile = txtSectionsFile.Text;
            Stopwatch actime = new Stopwatch();
            //Create the thread
            Thread loadSecThread = new Thread(new ParameterizedThreadStart(_Kienzan.LoadSectionsThreaded));
            //Start timing
            actime.Start();
            //Start the thread
            loadSecThread.Start(secFile);
            //Wait for the thread to finish while keeping UI responsive
            while (loadSecThread.ThreadState != System.Threading.ThreadState.Stopped)
            {
                Application.DoEvents();
            }
            //Stop timing
            actime.Stop();
            if (_Kienzan.Failed)
            {
                miniLog("Failed loading sections!");
                throw _Kienzan.ThreadedException;
            }
            else
            {
                miniLog(String.Format("Successfully loaded Sections in {0}!", actime.Elapsed));
            }
        }

        private void RunKienzan(Boolean ignoreSections = false)
        {
            //Check prerequisites
            CheckVideo();

            if (!_Kienzan.HasTimecodes)
            {
                throw new Exception("Please load timecodes first!");
            }
            // check if duplicates are needed
            if (!_Kienzan.VideoFrames.IsCFR)
            {
                if (!_Kienzan.HasDuplicates)
                {
                    throw new Exception("Please load duplicates first!");
                }
            }
            if (!_Kienzan.HasSections && !ignoreSections)
            {
                if (ShowQuestion("No sections were loaded! Do you want to continue with the whole video as one section?",
                    "No sections were loaded!") == DialogResult.No)
                {
                    return;
                }
            }
            Stopwatch actime = new Stopwatch();
            Decimal targetFramerate = AcHelper.DecimalParse(Convert.ToString(comTargetFramerate.SelectedItem));
            //Create the thread
            Thread runKienzThread = new Thread(new ParameterizedThreadStart(_Kienzan.RunKienzanThreaded));
            //Set the video file
            _Kienzan.VideoFile = txtVideoFile.Text;
            //Start timing
            actime.Start();
            //Start the thread
            runKienzThread.Start(targetFramerate);

            //Wait for the thread to finish while keeping UI responsive
            while (runKienzThread.ThreadState != System.Threading.ThreadState.Stopped)
            {
                Application.DoEvents();
            }
            //Stop timing
            actime.Stop();
            if (_Kienzan.Failed)
            {
                miniLog("Failed running Kienzan!");
                throw _Kienzan.ThreadedException;
            }
            else
            {
                miniLog(String.Format("Successfully run Kienzan in {0}!", actime.Elapsed));
            }
        }

        private void RunKienzanNew(Boolean ignoreSections = false)
        {
            //Check prerequisites
            CheckVideo();

            if (!_Kienzan.HasTimecodes)
            {
                throw new Exception("Please load timecodes first!");
            }
            // check if duplicates are needed
            if (!_Kienzan.VideoFrames.IsCFR)
            {
                if (!_Kienzan.HasDuplicates)
                {
                    if (ShowQuestion("No duplicates were loaded! Do you want to continue?") != DialogResult.Yes)
                    {
                        return;
                    }
                }
            }
            if (!_Kienzan.HasSections && !ignoreSections)
            {
                if (ShowQuestion("No sections were loaded! Do you want to continue with the whole video as one section?",
                    "No sections were loaded!") == DialogResult.No)
                {
                    return;
                }
            }
            Stopwatch actime = new Stopwatch();
            Decimal targetFramerate = AcHelper.DecimalParse(Convert.ToString(comTargetFramerate.SelectedItem));
            //Create the thread
            Thread runKienzThread = new Thread(new ParameterizedThreadStart(_Kienzan.RunNewKienzanThreaded));
            //Set the video file
            _Kienzan.VideoFile = txtVideoFile.Text;
            //Start timing
            actime.Start();
            //Start the thread
            runKienzThread.Start(targetFramerate);

            //Wait for the thread to finish while keeping UI responsive
            while (runKienzThread.ThreadState != System.Threading.ThreadState.Stopped)
            {
                Application.DoEvents();
            }
            //Stop timing
            actime.Stop();
            if (_Kienzan.Failed)
            {
                miniLog("Failed running New Kienzan!");
                throw _Kienzan.ThreadedException;
            }
            else
            {
                miniLog(String.Format("Successfully run New Kienzan in {0}!", actime.Elapsed));
            }
        }

        private void FullyAuto()
        {
            Boolean noSectionsProvided = true;
            //Check prerequisites
            CheckVideo();

            if (String.IsNullOrWhiteSpace( txtSectionsFile.Text))
            {
                if (ShowQuestion("No section file was provided! Do you want to continue with the whole video as one section?",
                    "No section file was provided!") == DialogResult.No)
                {
                    return;
                }
                else
                {
                    noSectionsProvided = false;
                }
            }
            else
            {
                if (!File.Exists(txtSectionsFile.Text) && !noSectionsProvided)
                {
                    if (ShowQuestion("Not existing section file was provided! Do you want to continue with the whole video as one section?",
                        "Not existing section file was provided!") == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        noSectionsProvided = false;
                    }
                }
            }
            miniLog("Starting Fully Auto...");

            //Create and start the timer
            Stopwatch actime = new Stopwatch();
            actime.Start();

            // Check whether to generate timecodes or not
            if (String.IsNullOrWhiteSpace(txtTimecodesFile.Text) || !File.Exists(txtTimecodesFile.Text))
            {
                if (!_CancelThread)
                {
                    GenerateTimecodes();
                }
            }
            // Load the timecodes
            if (!_CancelThread)
            {
                LoadTimecodes();
            }

            // check if duplicates are necessary
            if (!_Kienzan.VideoFrames.IsCFR)
            {
                bool duplicatesProvided = !string.IsNullOrWhiteSpace(txtDuplicatesFile.Text) && File.Exists(txtDuplicatesFile.Text);
                bool duplicatesGenerated = false;

                // Check whether to generate duplicates or not
                if (!duplicatesProvided
                    && ShowQuestion("No duplicates were provided! Do you want to generate them?") == DialogResult.Yes)
                {
                    if (!_CancelThread)
                    {
                        GenerateDuplicates();
                        duplicatesGenerated = true;
                    }
                }

                // Load the duplicates
                if (duplicatesProvided || duplicatesGenerated)
                {
                    if (!_CancelThread)
                    {
                        LoadDuplicates();
                    }
                }
            }

            // Load the sections
            if (noSectionsProvided)
            {
                if (!_CancelThread)
                {
                    LoadSections();
                }
            }

            // Run Kinezan
            if (!_CancelThread)
            {
                //Use the new kienzan code
                RunKienzanNew(true);
            }

            //Stop the timer
            actime.Stop();

            if (!_CancelThread)
            {
                miniLog(String.Format("Successfully run Fully Auto in {0}!", actime.Elapsed));
            }
        }

        private void KienzanForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _FormClosing = true;
            _CancelThread = true;
            _Kienzan.CancelThread = true;
        }

        private void btnLoadTimecodes_Click(object sender, EventArgs e)
        {
            try
            {
                SwapButtonsDuringExecution();
                LoadTimecodes();
                ShowSuccessMessage("Successfully loaded timecodes!");
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
            SwapButtonsDuringExecution();
        }

        private void btnLoadDuplicates_Click(object sender, EventArgs e)
        {
            try
            {
                SwapButtonsDuringExecution();
                LoadDuplicates();
                ShowSuccessMessage("Successfully loaded duplicates!");
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
            SwapButtonsDuringExecution();
        }

        private void btnLoadSections_Click(object sender, EventArgs e)
        {
            try
            {
                SwapButtonsDuringExecution();
                LoadSections();
                ShowSuccessMessage("Successfully loaded sections!");
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
            SwapButtonsDuringExecution();
        }

        private void btnGenerateTimecodes_Click(object sender, EventArgs e)
        {
            try
            {
                SwapButtonsDuringExecution();
                GenerateTimecodes();
                ShowSuccessMessage("Successfully generated timecodes!");
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
            SwapButtonsDuringExecution();
        }

        private void btnGenerateDuplicates_Click(object sender, EventArgs e)
        {
            try
            {
                SwapButtonsDuringExecution();
                GenerateDuplicates();
                ShowSuccessMessage("Successfully generated duplicates!");
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
            SwapButtonsDuringExecution();
        }

        private void btnCreateMeGUI_Click(object sender, EventArgs e)
        {
            try
            {
                SwapButtonsDuringExecution();
                //Check prerequisites
                if (!_Kienzan.HasTimecodes)
                {
                    throw new Exception("Please load timecodes first!");
                }
                if (!_Kienzan.HasSections)
                {
                    throw new Exception("Please load sections first!");
                }
                //Select filename
                String filename = ShowSaveFileDialog("Select MeGUI script file...",
                    AcHelper.GetFilename(txtSectionsFile.Text, GetFileNameMode.NoFileName, GetDirectoryNameMode.FullPath), "*.clt|*.clt");
                Stopwatch actime = new Stopwatch();
                if (filename != null)
                {
                    if (filename.Length > 0)
                    {
                        //Create the thread
                        Thread createMeGUIThread = new Thread(new ParameterizedThreadStart(_Kienzan.CreateMeGUIScriptThreaded));
                        _Kienzan.TargetFramerate = AcHelper.DecimalParse(Convert.ToString(comTargetFramerate.Text));
                        //Start timing
                        actime.Start();
                        //Start the thread
                        createMeGUIThread.Start(filename);

                        //Wait for the thread to finish while keeping UI responsive
                        while (createMeGUIThread.ThreadState != System.Threading.ThreadState.Stopped)
                        {
                            Application.DoEvents();
                        }

                        //End timing
                        actime.Stop();
                        if (_Kienzan.Failed)
                        {
                            miniLog("Failed creating MeGUI cut file!");
                            throw _Kienzan.ThreadedException;
                        }
                        else
                        {
                            miniLog(String.Format("Finished creating MeGUI Cut File in {0}!", actime.Elapsed));
                            ShowSuccessMessage("Successfully created MeGUI Cut File!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
            SwapButtonsDuringExecution();
        }

        private void btnCreateCoolEditScript_Click(object sender, EventArgs e)
        {
            try
            {
                SwapButtonsDuringExecution();
                //Check prerequisites
                if (!_Kienzan.HasTimecodes)
                {
                    throw new Exception("Please load timecodes first!");
                }
                if (!_Kienzan.HasSections)
                {
                    throw new Exception("Please load sections first!");
                }

                String filename = ShowSaveFileDialog("Select CoolEdit/Audition script file...",
                    AcHelper.GetFilename(txtSectionsFile.Text, GetFileNameMode.NoFileName, GetDirectoryNameMode.FullPath), "*.scp|*.scp");

                //Start timing
                Stopwatch actime = new Stopwatch();
                actime.Start();

                //Select filename
                if (filename != null)
                {
                    if (filename.Length > 0)
                    {
                        //Create the thread
                        Thread createCoolThread = new Thread(new ParameterizedThreadStart(_Kienzan.CreateCoolEditScriptThreaded));
                        //Start the thread
                        createCoolThread.Start(filename);
                        //Wait for the thread to finish while keeping UI responsive
                        while (createCoolThread.ThreadState != System.Threading.ThreadState.Stopped)
                        {
                            Application.DoEvents();
                        }

                        //Stop timing
                        actime.Stop();

                        miniLog(String.Format("Finished creating Cool Edit Script File in {0}!", actime.Elapsed));
                        ShowSuccessMessage("Successfully created Cool Edit Script!");
                    }
                }
            }
            catch (Exception ex)
            {
                miniLog("Failed creating Cool Edit script file!");
                ShowExceptionMessage(ex, "Error in creating Cool Edit Script!");
            }
            SwapButtonsDuringExecution();
        }

        private void btnSyncAss_Click(object sender, EventArgs e)
        {
            try
            {
                AssParser assP = new AssParser();
                assP.ParseASS(txtAssFile.Text);
                VideoFrameList vfl = _Kienzan.VideoFrames;
                //Double framerate = AcHelper.ConvertToDouble(Convert.ToString(comTargetFramerate.SelectedItem));
                foreach (AssDialogue assD in assP.AssContents)
                {
                    Decimal timeToDelete = 0m;
                    for (Int32 currentSection = 0; currentSection < vfl.FrameSections.Count; currentSection++)
                    {
                        VideoFrameSection vfs = vfl.FrameSections[currentSection];
                        Decimal startSection = vfl.FrameList[vfs.FrameStart].FrameStartTime;
                        Decimal endSection = vfl.FrameList[vfs.FrameEnd].FrameEndTime;
                        //Check if the sub ends before the section
                        if (assD.time_end_double <= startSection)
                        {
                            assD.deleted = true;
                            break;
                        }
                        //Check if the sub starts after the section
                        if (assD.time_start_double >= endSection)
                        {
                            //If its the last sections, then delete the sub
                            if (currentSection == vfl.FrameSections.Count - 1)
                            {
                                assD.deleted = true;
                                break;
                            }
                            else
                            {
                                if (currentSection == 0)
                                {
                                    timeToDelete = startSection;
                                }
                                else
                                {
                                    Decimal start = startSection;
                                    Decimal end = endSection;
                                    Decimal prevEnd = vfl.FrameList[vfl.FrameSections[currentSection - 1].FrameEnd].FrameEndTime;
                                    timeToDelete += start - prevEnd;
                                }
                                continue;
                            }
                        }
                        //Time to resync the sub
                        if (currentSection == 0)
                        {
                            TimeSpan ts;
                            timeToDelete = startSection;
                            assD.time_start_double = assD.time_start_double - timeToDelete;
                            ts = TimeSpan.FromMilliseconds(Convert.ToDouble(assD.time_start_double));
                            assD.time_start = ts.Hours.ToString("0") + ":" + ts.Minutes.ToString("00")
                                + ":" + ts.Seconds.ToString("00") + "." + ts.Milliseconds.ToString("00");

                            assD.time_end_double = assD.time_end_double - timeToDelete;
                            ts = TimeSpan.FromMilliseconds(Convert.ToDouble(assD.time_end_double));
                            assD.time_end = ts.Hours.ToString("0") + ":" + ts.Minutes.ToString("00")
                                + ":" + ts.Seconds.ToString("00") + "." + ts.Milliseconds.ToString("00");
                            break;
                        }
                        else
                        {
                            TimeSpan ts;
                            Decimal start = startSection;
                            Decimal end = endSection;
                            Decimal prevEnd = vfl.FrameList[vfl.FrameSections[currentSection - 1].FrameEnd].FrameEndTime;
                            timeToDelete += start - prevEnd;
                            assD.time_start_double = assD.time_start_double - timeToDelete;
                            ts = TimeSpan.FromMilliseconds(Convert.ToDouble(assD.time_start_double));
                            assD.time_start = ts.Hours.ToString("0") + ":" + ts.Minutes.ToString("00")
                                + ":" + ts.Seconds.ToString("00") + "." + (ts.Milliseconds / 10).ToString("00");

                            assD.time_end_double = assD.time_end_double - timeToDelete;
                            ts = TimeSpan.FromMilliseconds(Convert.ToDouble(assD.time_end_double));
                            assD.time_end = ts.Hours.ToString("0") + ":" + ts.Minutes.ToString("00")
                                + ":" + ts.Seconds.ToString("00") + "." + (ts.Milliseconds / 10).ToString("00");
                            break;
                        }
                    }
                }
                assP.WriteFinalAss(txtAssFile.Text.Substring(0, txtAssFile.Text.LastIndexOf(".")) + ".resync.ass");
                ShowSuccessMessage("Resync complete!");
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnFullyAuto_Click(object sender, EventArgs e)
        {
            try
            {
                SwapButtonsDuringExecution();
                FullyAuto();
                if (!_CancelThread)
                {
                    ShowSuccessMessage("Successfully run Fully Auto!");
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
            SwapButtonsDuringExecution();
        }

        private void btnResetAll_Click(object sender, EventArgs e)
        {
            try
            {
                SwapButtonsDuringExecution();
                ResetAll();
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
            SwapButtonsDuringExecution();
        }

        private void btnRunKienzan_Click(object sender, EventArgs e)
        {
            try
            {
                SwapButtonsDuringExecution();
                RunKienzanNew();
                ShowSuccessMessage("Successfully run New Kienzan!");
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
            SwapButtonsDuringExecution();
        }
        
        private void btnRunKienzanOld_Click(object sender, EventArgs e)
        {
            try
            {
                SwapButtonsDuringExecution();
                RunKienzan();
                ShowSuccessMessage("Successfully run Kienzan!");
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
            SwapButtonsDuringExecution();
        }

    }
}
