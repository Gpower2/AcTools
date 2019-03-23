using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using AcTools.Core;

using AcToolsLibrary.Common;
using AcToolsLibrary.Core.Other;

namespace AcTools.Forms
{
    public partial class frmChapterFromSections : AcForm
    {
        ChapterEditor cEdit = null;

        public frmChapterFromSections(ChapterEditor ced)
        {
            InitializeComponent();
            InitColors();
            InitControls();
            InitIcon();
            fillComboFramerate();
            this.Text = "Chapters from Sections";
            cEdit = ced;
            txtChaptersFile.Enabled = false;
            btnBrowseChaptersFile.Enabled = false;
        }

        private void btnBrowseSectionsFile_Click(object sender, EventArgs e)
        {
            try
            {
                String[] filenames = ShowOpenFileDialog("Select a sections file...", "", "", false);
                if (filenames != null)
                {
                    if (filenames[0].Length > 0)
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

        private void btnBrowseChaptersFile_Click(object sender, EventArgs e)
        {
            try
            {
                String[] filenames = ShowOpenFileDialog("Select a chapters file...", "", "(*.xml) XML chapter|*.xml|(*.txt) OGM chapter|*.txt", false);
                if (filenames != null)
                {
                    if (filenames[0].Length > 0)
                    {
                        txtChaptersFile.Text = filenames[0];
                    }
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                //Check prerequisites
                //Check if sections file was provided
                if (txtSectionsFile.Text.Length < 1)
                {
                    throw new Exception("Error making chapters from sections! Please provide with sections file!");
                }
                //Check if provided sections file exists
                if (!File.Exists(txtSectionsFile.Text))
                {
                    throw new Exception("Error making chapters from sections! Please provide with an existing sections file!");
                }
                //If use chapters is checked
                if (checkUseChaptersFile.Checked)
                {
                    //Check if chapters file was provided
                    if (txtChaptersFile.Text.Length < 1)
                    {
                        throw new Exception("Error making chapters from sections! Please provide with chapters file!");
                    }
                    //Check if provided chapters file exists
                    if (!File.Exists(txtChaptersFile.Text))
                    {
                        throw new Exception("Error making chapters from sections! Please provide with an existing chapters file!");
                    }
                }
                cEdit.CreateFromSections(txtSectionsFile.Text, txtChaptersFile.Text,
                    AcHelper.DecimalParse(comboFramerate.SelectedItem.ToString()),
                    checkUseChaptersFile.Checked, checkIsTrimFile.Checked);
                Close();
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void fillComboFramerate()
        {
            comboFramerate.Items.Clear();
            comboFramerate.Items.Add("29.97");
            comboFramerate.Items.Add("23.976");
            comboFramerate.Items.Add("25");
            comboFramerate.SelectedIndex = 1;
        }

        private void txtBox_DragDrop(object sender, DragEventArgs e)
        {
            String[] s = (String[])e.Data.GetData(DataFormats.FileDrop, false);
            ((TextBox)sender).Text = s[0];
        }

        private void txtBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void checkUseChaptersFile_CheckedChanged(object sender, EventArgs e)
        {
            txtChaptersFile.Enabled = checkUseChaptersFile.Checked;
            btnBrowseChaptersFile.Enabled = checkUseChaptersFile.Checked;
        }
    }
}
