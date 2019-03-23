using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using AcTools.Core;

using AcControls.AcMessageBox;

using AcToolsLibrary.Common;
using AcToolsLibrary.Core.Video;
using AcToolsLibrary.Core.Parsers;

namespace AcTools.Forms
{
    public partial class frmSectionEditor : AcForm
    {
        private VideoFrameList vfl = new VideoFrameList();
        private frmVideoPlayer vpf = null;

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
        /// Default constructor
        /// </summary>
        public frmSectionEditor()
        {
            Init();
        }

        /// <summary>
        /// Constructor to open a section file
        /// </summary>
        /// <param name="sectionFile"></param>
        public frmSectionEditor(String secFile)
        {
            Init();
            LoadSection(secFile);
        }

        /// <summary>
        /// Constructor to associate with a video player form
        /// </summary>
        /// <param name="vf"></param>
        public frmSectionEditor(frmVideoPlayer vf)
        {
            vpf = vf;
            Init();
        }

        /// <summary>
        /// Constructor to load a section file
        /// </summary>
        /// <param name="secFile"></param>
        /// <param name="vf"></param>
        public frmSectionEditor(String secFile, frmVideoPlayer vf)
        {
            vpf = vf;
            Init();
            LoadSection(secFile);
        }

        /// <summary>
        /// Common init functions
        /// </summary>
        private void Init()
        {
            InitializeComponent();
            InitColors();
            InitControls();
            InitIcon();
            this.Text = "Section Editor";
            if (vpf == null)
            {
                DisableFromVideoBtns();
            }
        }

        private void btnHook_Click(object sender, EventArgs e)
        {
            HookUnHook(btnHook);
        }

        private void LoadSection(String sectionFile)
        {
            vfl.ClearSections();
            SectionParser.ParseSections(sectionFile, vfl);
            this.Text = String.Format("Section Editor - {0}", sectionFile);
            RefreshSectionList();
        }

        public void RefreshSectionList()
        {
            listSections.Items.Clear();
            listSections.Items.AddRange(vfl.FrameSections.ToArray());
        }

        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (vfl.CountSections > 0)
                {
                    String filename = ShowSaveFileDialog("Select a section filename to save...", "", "(*.txt) Text files|*.txt|(*.*) All files|*.*");
                    if (filename != null)
                    {
                        if (filename.Length > 0)
                        {
                            SectionParser.WriteSections(vfl, filename);
                            this.Text = String.Format("Section Editor - {0}", filename);
                            ShowSuccessMessage("Successfully written section file!");
                        }
                    }
                }
                else
                {
                    throw new Exception("No sections to write!");
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //Prepare data for the new section
                String sName = txtSectionName.Text;
                Int32 fStart = 0;
                Int32 fEnd = 0;
                if (txtStartFrame.Text.Length > 0)
                {
                    fStart = Int32.Parse(txtStartFrame.Text);
                }
                else
                {
                    throw new Exception("Please provide with a start frame!");
                }
                if (txtEndFrame.Text.Length > 0)
                {
                    fEnd = Int32.Parse(txtEndFrame.Text);
                }
                else
                {
                    throw new Exception("Please provide with an end frame!");
                }
                //Create the new section
                VideoFrameSection vfs = new VideoFrameSection(sName, fStart, fEnd);
                //Add the section to the frame list
                vfl.AddSection(vfs);
                //Refresh the section list control
                RefreshSectionList();
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (listSections.SelectedIndex < 0)
                {
                    throw new Exception("Please select a section from the list first!");
                }
                //Remove the section the video frame list
                vfl.RemoveSectionAt(listSections.SelectedIndex);
                //Refresh the frame list control
                RefreshSectionList();
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                //Clear all the sections from the video frame list
                vfl.FrameSections.Clear();
                //refresh the section list control
                RefreshSectionList();
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnLoadFromFile_Click(object sender, EventArgs e)
        {
            try
            {
                //Prompt the user to elect a section file
                String[] filenames = ShowOpenFileDialog("Select a section file...", "", "(*.txt) Text files|*.txt|(*.*) All files|*.*", false);
                if (filenames != null)
                {
                    if (filenames[0].Length > 0)
                    {
                        LoadSection(filenames[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnStartFromVideo_Click(object sender, EventArgs e)
        {
            try
            {
                txtStartFrame.Text = vpf.CurrentFrame.ToString();
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnEndFromVideo_Click(object sender, EventArgs e)
        {
            try
            {
                txtEndFrame.Text = vpf.CurrentFrame.ToString();
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void listSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Ensure that selected index is not -1
                if (listSections.SelectedIndex > -1)
                {
                    VideoFrameSection vfs = vfl.FrameSections[listSections.SelectedIndex];
                    txtSectionName.Text = vfs.SectionName;
                    txtStartFrame.Text = vfs.FrameStart.ToString();
                    txtEndFrame.Text = vfs.FrameEnd.ToString();
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (listSections.SelectedIndex > -1)
                {
                    //Safe keep the old selected index
                    Int32 oldIdx = listSections.SelectedIndex;
                    //Update the section
                    VideoFrameSection vfs = vfl.FrameSections[listSections.SelectedIndex];
                    vfs.SectionName = txtSectionName.Text;
                    vfs.FrameStart = Convert.ToInt32(txtStartFrame.Text);
                    vfs.FrameEnd = Convert.ToInt32(txtEndFrame.Text);
                    //Refresh the list
                    RefreshSectionList();
                    //Select the same section
                    listSections.SelectedIndex = oldIdx;
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void checkOnTop_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = checkOnTop.Checked;
        }

        private void btnAutoName_Click(object sender, EventArgs e)
        {
            try
            {
                txtSectionName.Text = String.Format("Section{0}", (listSections.SelectedIndex + 1));
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        public void EnableFromVideoBtns()
        {
            btnEndFromVideo.Enabled = true;
            btnStartFromVideo.Enabled = true;
        }

        public void DisableFromVideoBtns()
        {
            btnEndFromVideo.Enabled = false;
            btnStartFromVideo.Enabled = false;
        }

        private void btnUseVideo_Click(object sender, EventArgs e)
        {
            try
            {
                if (vpf == null || vpf.IsDisposed)
                {
                    String[] filenames = ShowOpenFileDialog("Select a video to open...", "", "", false);
                    if (filenames != null)
                    {
                        if (filenames[0].Length > 0)
                        {
                            vpf = new frmVideoPlayer(filenames[0]);
                            vpf.FrameList = vfl;
                            vpf.SectionForm = this;
                        }
                    }
                }
                ShowForm(vpf);
                EnableFromVideoBtns();
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }
    }
}
