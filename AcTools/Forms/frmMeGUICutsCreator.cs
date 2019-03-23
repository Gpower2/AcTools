using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

using AcTools.Core;
using AcToolsLibrary.Common;
using AcToolsLibrary.Core.Video;
using System.Globalization;

namespace AcTools.Forms
{
    public partial class frmMeGUICutsCreator : AcForm
    {
        public frmMeGUICutsCreator()
        {
            InitializeComponent();
            InitColors();
            InitControls();
            InitIcon();
            fillComboFramerate();
            this.Text = "MeGUI Cuts Creator";
        }

        private void CheckInputData()
        {
            //Check for video file
            if (String.IsNullOrWhiteSpace( txtVideoFile.Text))
            {
                throw new Exception("No video file was provided!");
            }

            //Check for timecodes file
            if (String.IsNullOrWhiteSpace(txtTimecodesFile.Text))
            {
                throw new Exception("No timecodes file was provided!");
            }
            else
            {
                if (!System.IO.File.Exists(txtTimecodesFile.Text))
                {
                    throw new Exception("The provided timecodes file does not exist!");
                }
            }

            //Check for sections file
            if (String.IsNullOrWhiteSpace(txtSectionsFile.Text))
            {
                throw new Exception("No sections file was provided!");
            }
            else
            {
                if (!System.IO.File.Exists(txtSectionsFile.Text))
                {
                    throw new Exception("The provided sections file does not exist!");
                }
            }

            //Check for MeGUI Cut File
            if (String.IsNullOrWhiteSpace(txtMeguiCutsFile.Text))
            {
                throw new Exception("No output file was provided!");
            }
        }

        private void txt_DragEnter(object sender, DragEventArgs e)
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

        private void txt_DragDrop(object sender, DragEventArgs e)
        {
            String[] s = (String[])e.Data.GetData(DataFormats.FileDrop, false);
            ((TextBox)sender).Text = s[0];
        }

        private void btnBrowseVideoFile_Click(object sender, EventArgs e)
        {
            String[] filenames = ShowOpenFileDialog("Select video file...", "", "", false);
            if (filenames != null)
            {
                if (filenames.Length > 0)
                {
                    txtVideoFile.Text = filenames[0];
                }
            }
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

        private void btnBrowseSectionsFile_Click(object sender, EventArgs e)
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

        private void btnBrowseMeguiCutsFile_Click(object sender, EventArgs e)
        {
            String filename = ShowSaveFileDialog("Save MeGUI Cut file...", "", "MeGUI Cut File (*.clt)|*.clt");
            if (filename != null)
            {
                txtMeguiCutsFile.Text = filename;
            }
        }

        private void btnPreviewVideoFile_Click(object sender, EventArgs e)
        {
            if (txtVideoFile.Text.Trim().Length > 0)
            {
                ShowForm(new frmVideoPlayer(txtVideoFile.Text));
            }
        }

        private void btnPreviewSectionsFile_Click(object sender, EventArgs e)
        {
            if (txtSectionsFile.Text.Trim().Length > 0)
            {
                ShowForm(new frmSectionEditor(txtSectionsFile.Text));
            }
        }

        private void btnGenerateTimecodesFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtVideoFile.Text.Trim().Length > 0)
                {
                    tlpMain.Enabled = false;
                    GenerateTimecodes();
                    tlpMain.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                tlpMain.Enabled = true;
                ShowExceptionMessage(ex);
            }
        }

        private void btnGenerateMeguiCutsFile_Click(object sender, EventArgs e)
        {
            try
            {
                //First check if input data is valid
                CheckInputData();
                tlpMain.Enabled = false;
                CreateMeGUIScript();
                tlpMain.Enabled = true;
            }
            catch (Exception ex)
            {
                tlpMain.Enabled = true;
                ShowExceptionMessage(ex);
            }
        }

        private void fillComboFramerate()
        {
            cmbFrameRate.Items.Clear();
            cmbFrameRate.Items.Add("29.97");
            cmbFrameRate.Items.Add("23.976");
            cmbFrameRate.Items.Add("25");
            cmbFrameRate.SelectedIndex = 1;
        }

        private void GenerateTimecodes()
        {
            String videoFile = txtVideoFile.Text;
            Stopwatch actime = new Stopwatch();
            using (Kienzan kienz = new Kienzan())
            {
                //Create the thread
                Thread genTcThread = new Thread(new ParameterizedThreadStart(kienz.GenerateTimecodesThreaded));
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
                txtTimecodesFile.Text = kienz.TimecodesFile;

                if (!kienz.Failed)
                {
                    ShowSuccessMessage("Successfully generated timecodes!");
                }
            }
        }

        private void CreateMeGUIScript()
        {
            using (Kienzan kienz = new Kienzan())
            {
                //Check prerequisites
                //Select filename
                String filename = txtMeguiCutsFile.Text;
                Stopwatch actime = new Stopwatch();
                kienz.LoadTimecodes(txtTimecodesFile.Text);
                kienz.LoadSections(txtSectionsFile.Text);
                if (filename != null)
                {
                    if (filename.Length > 0)
                    {
                        //Create the thread                      
                        Thread createMeGUIThread = new Thread(new ParameterizedThreadStart(kienz.CreateMeGUIScriptThreaded));
                        kienz.TargetFramerate = AcHelper.DecimalParse(Convert.ToString(cmbFrameRate.SelectedItem));
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

                        if (!kienz.Failed)
                        {
                            ShowSuccessMessage("Successfully created MeGUI Cut File!");
                        }
                    }
                }
            }
        }

    }
}
