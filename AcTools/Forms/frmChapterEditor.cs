using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

using AcTools.Core;

using AcToolsLibrary.Common;
using AcToolsLibrary.Core.Video;
using AcToolsLibrary.Core.Language;
using AcToolsLibrary.Core.Other;

namespace AcTools.Forms
{
    public partial class frmChapterEditor : AcForm
    {
        private CountryCodeCCTLD _Country = new CountryCodeCCTLD();
        private LanguageISO639_2 _Language = new LanguageISO639_2();
        private ChapterEditor _ChapterEditor = new ChapterEditor();
        private VideoChapter _TempChapter = new VideoChapter();
        private frmVideoPlayer _VidPlayerForm = null;
        private Boolean _IsLoaded = false;

        public frmChapterEditor()
        {
            try
            {
                InitializeComponent();
                InitColors();
                InitControls();
                InitIcon();
                fillComboLanguage();
                fillComboCountry();
                this.Text = "Chapter Editor";
                clearDetails(true);
                DisableFromVideoBtns();
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
                HookUnHook(btnHook);
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void fillComboLanguage()
        {
            cmbLanguage.Items.Clear();
            foreach (String str in _Language.LanguageCodes.Keys)
            {
                cmbLanguage.Items.Add(str);
            }
            cmbLanguage.SelectedIndex = 0;
            Tooltip.SetToolTip(cmbLanguage, _Language.LanguageCodes[cmbLanguage.SelectedItem.ToString()]);
        }

        private void fillComboCountry()
        {
            cmbCountry.Items.Clear();
            foreach (String str in _Country.CountryCodes.Keys)
            {
                cmbCountry.Items.Add(str);
            }
            cmbCountry.SelectedIndex = 0;
            Tooltip.SetToolTip(cmbCountry, _Country.CountryCodes[cmbCountry.SelectedItem.ToString()]);
        }

        private void comLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbLanguage.SelectedIndex > 0)
                {
                    Tooltip.SetToolTip(cmbLanguage, _Language.LanguageCodes[cmbLanguage.SelectedItem.ToString()]);
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void comCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbCountry.SelectedIndex > 0)
                {
                    Tooltip.SetToolTip(cmbCountry, _Country.CountryCodes[cmbCountry.SelectedItem.ToString()]);
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnAddChapter_Click(object sender, EventArgs e)
        {
            try
            {
                //Create the chapter
                VideoChapter chap = new VideoChapter();
                chap.Enabled = chkEnabled.Checked;
                chap.EndTime = txtEndTime.Text;
                chap.Hidden = chkHidden.Checked;
                chap.Name = txtName.Text;
                chap.StartTime = txtStartTime.Text;
                chap.UID = txtUID.Text;
                //Set Display list
                if (_IsLoaded)
                {
                    chap.DisplayList = _TempChapter.CloneDisplayList();
                }
                else
                {
                    chap.DisplayList = _TempChapter.DisplayList;
                }
                //Add it to the Chapter Editor
                _ChapterEditor.AddChapter(chap);
                //Clears all the form fields and the Temp object
                clearDetails(true);
                //Refresh the chapter list
                refreshChapterList();
                //Set the flag
                _IsLoaded = false;
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void clearDetails(Boolean cleanTempObject)
        {
            txtEndTime.Text = "";
            txtName.Text = "";
            txtNameLanguage.Text = "";
            txtStartTime.Text = "";
            txtUID.Text = "";
            cmbCountry.SelectedIndex = -1;
            cmbLanguage.SelectedIndex = -1;
            lstLanguages.Items.Clear();
            chkEnabled.Checked = true;
            chkHidden.Checked = false;
            if (cleanTempObject)
            {
                _TempChapter = new VideoChapter();
            }
        }

        private void refreshChapterList()
        {
            //Empty list first
            lstChapters.Items.Clear();
            foreach (VideoChapter chap in _ChapterEditor.ChapterList)
            {
                lstChapters.Items.Add(chap.ToString());
            }
        }

        private void refreshLanguageList()
        {
            //Empty list first
            lstLanguages.Items.Clear();
            foreach (VideoChapterDisplay chapDisp in _TempChapter.DisplayList)
            {
                lstLanguages.Items.Add(chapDisp.ToString());
            }
        }

        private void btnRemoveChapter_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if a chapter is selected
                if (lstChapters.SelectedIndex >= 0)
                {
                    _ChapterEditor.RemoveChapterAt(lstChapters.SelectedIndex);
                    refreshChapterList();
                }
                _IsLoaded = false;
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
                _ChapterEditor.ClearChapters();
                refreshChapterList();
                _IsLoaded = false;
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnUpdateChapter_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if an existing chapter is selected
                if (lstChapters.SelectedIndex >= 0)
                {
                    VideoChapter chap = _ChapterEditor.ChapterList[lstChapters.SelectedIndex];
                    chap.Enabled = chkEnabled.Checked;
                    chap.EndTime = txtEndTime.Text;
                    chap.Hidden = chkHidden.Checked;
                    chap.Name = txtName.Text;
                    chap.StartTime = txtStartTime.Text;
                    chap.UID = txtUID.Text;
                    //Set Display list
                    chap.DisplayList = _TempChapter.DisplayList;
                    //Clear all the form fields and the Temp object
                    clearDetails(true);
                    //Refresh the chapter list
                    refreshChapterList();
                    _IsLoaded = false;
                    ShowSuccessMessage("Chapter was updated properly!");
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                String filename = ShowSaveFileDialog("Select the chapter file to save...", "", "(*.xml) XML chapter|*.xml|(*.txt) OGM chapter|*.txt");
                if (filename != null)
                {
                    if (filename.Length > 0)
                    {
                        if (AcHelper.GetFilename(filename, GetFileNameMode.ExtensionOnly, GetDirectoryNameMode.NoPath).ToLowerInvariant() == "xml")
                        {
                            _ChapterEditor.Save(ChapterType.XML, filename);
                        }
                        else if (AcHelper.GetFilename(filename, GetFileNameMode.ExtensionOnly, GetDirectoryNameMode.NoPath).ToLowerInvariant() == "txt")
                        {
                            _ChapterEditor.Save(ChapterType.OGM, filename);
                        }
                        ShowSuccessMessage("Chapter written successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void listChapters_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Ensure a valid item is selected
                if (lstChapters.SelectedIndex >= 0)
                {
                    //First clear the details
                    clearDetails(false);
                    //Now fill the form with the data read
                    _TempChapter = _ChapterEditor.ChapterList[lstChapters.SelectedIndex];
                    txtStartTime.Text = _TempChapter.StartTime;
                    txtEndTime.Text = _TempChapter.EndTime;
                    txtName.Text = _TempChapter.Name;
                    txtUID.Text = _TempChapter.UID;
                    chkEnabled.Checked = _TempChapter.Enabled;
                    chkHidden.Checked = _TempChapter.Hidden;

                    refreshLanguageList();
                    //Set tooltip
                    Tooltip.SetToolTip(lstChapters, _TempChapter.ToString());
                    //Set flag
                    _IsLoaded = true;
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                String[] filenames = ShowOpenFileDialog("Select the chapter file to load...", "", "(*.xml) XML chapter|*.xml|(*.txt) OGM chapter|*.txt", false);
                if (filenames != null)
                {
                    if (filenames[0].Length > 0)
                    {
                        //First clear form and temp object
                        clearDetails(true);
                        _IsLoaded = false;
                        //Now load the file
                        if (AcHelper.GetFilename(filenames[0], GetFileNameMode.ExtensionOnly, GetDirectoryNameMode.NoPath).ToLowerInvariant() == "xml")
                        {
                            _ChapterEditor.Load(ChapterType.XML, filenames[0]);
                        }
                        else if (AcHelper.GetFilename(filenames[0], GetFileNameMode.ExtensionOnly, GetDirectoryNameMode.NoPath).ToLowerInvariant() == "txt")
                        {
                            _ChapterEditor.Load(ChapterType.OGM, filenames[0]);
                        }
                        refreshChapterList();
                        ShowSuccessMessage("Chapter file loaded successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnFromSectionsFile_Click(object sender, EventArgs e)
        {
            try
            {
                frmChapterFromSections cfsf = new frmChapterFromSections(_ChapterEditor);
                cfsf.ShowDialog();
                refreshChapterList();
                clearDetails(true);
                _IsLoaded = false;
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnNoLanguage_Click(object sender, EventArgs e)
        {
            cmbLanguage.SelectedIndex = -1;
        }

        private void btnNoCountry_Click(object sender, EventArgs e)
        {
            cmbCountry.SelectedIndex = -1;
        }

        private void btnAddLanguage_Click(object sender, EventArgs e)
        {
            try
            {
                VideoChapterDisplay chapDisp = new VideoChapterDisplay();
                if (cmbCountry.SelectedIndex >= 0)
                {
                    chapDisp.Country = _Country.CountryCodes[cmbCountry.SelectedItem.ToString()];
                }
                if (cmbLanguage.SelectedIndex >= 0)
                {
                    chapDisp.Language = _Language.LanguageCodes[cmbLanguage.SelectedItem.ToString()];
                }
                chapDisp.Name = txtNameLanguage.Text;
                _TempChapter.DisplayList.Add(chapDisp);
                //Refresh the language list
                refreshLanguageList();
                //Clear the fields
                txtNameLanguage.Text = "";
                cmbCountry.SelectedIndex = -1;
                cmbLanguage.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnUpdateLanguage_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstLanguages.SelectedIndex >= 0)
                {
                    VideoChapterDisplay chapDisp = _TempChapter.DisplayList[lstLanguages.SelectedIndex];
                    if (cmbCountry.SelectedIndex >= 0)
                    {
                        chapDisp.Country = _Country.CountryCodes[cmbCountry.SelectedItem.ToString()];
                    }
                    if (cmbLanguage.SelectedIndex >= 0)
                    {
                        chapDisp.Language = _Language.LanguageCodes[cmbLanguage.SelectedItem.ToString()];
                    }
                    chapDisp.Name = txtNameLanguage.Text;
                    //Refresh the language list
                    refreshLanguageList();
                    //Clear the fields
                    txtNameLanguage.Text = "";
                    cmbCountry.SelectedIndex = -1;
                    cmbLanguage.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnRemoveLanguage_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstLanguages.SelectedIndex >= 0)
                {
                    VideoChapterDisplay chapDisp = _TempChapter.DisplayList[lstLanguages.SelectedIndex];
                    _TempChapter.DisplayList.Remove(chapDisp);
                    refreshLanguageList();
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void listLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstLanguages.SelectedIndex >= 0)
                {
                    VideoChapterDisplay chapDisp = _TempChapter.DisplayList[lstLanguages.SelectedIndex];
                    if (chapDisp.Country.Length > 0)
                    {
                        cmbCountry.SelectedItem = _Country.CountryCodesInverse[chapDisp.Country];
                    }
                    else
                    {
                        cmbCountry.SelectedIndex = -1;
                    }
                    if (chapDisp.Language.Length > 0)
                    {
                        cmbLanguage.SelectedItem = _Language.LanguageCodesInverse[chapDisp.Language];
                    }
                    else
                    {
                        cmbLanguage.SelectedIndex = -1;
                    }
                    txtNameLanguage.Text = chapDisp.Name;
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnUseVideo_Click(object sender, EventArgs e)
        {
            try
            {
                if (_VidPlayerForm == null || _VidPlayerForm.IsDisposed)
                {
                    String[] filenames = ShowOpenFileDialog("Select a video to open...", "", "", false);
                    if (filenames != null)
                    {
                        if (filenames[0].Length > 0)
                        {
                                _VidPlayerForm = new frmVideoPlayer(filenames[0]);
                        }
                    }
                }
                ShowForm(_VidPlayerForm);
                EnableFromVideoBtns();
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        public void EnableFromVideoBtns()
        {
            btnFromVideoStart.Enabled = true;
            btnFromVideoEnd.Enabled = true;
        }

        public void DisableFromVideoBtns()
        {
            btnFromVideoStart.Enabled = false;
            btnFromVideoEnd.Enabled = false;
        }

        private void btnFromVideoStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (_VidPlayerForm != null)
                {
                    Decimal frameCalc = 0.0m;
                    if (_VidPlayerForm.CurrentFrame != 0)
                    {
                        frameCalc = Convert.ToDecimal(_VidPlayerForm.CurrentFrame) + 0.5m;
                    }
                    txtStartTime.Text = VideoFrame.FrameTimeFromFrameNumber(frameCalc,
                         _VidPlayerForm.Framerate, FrameFromType.FromFrameRate);
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnFromVideoEnd_Click(object sender, EventArgs e)
        {
            try
            {
                if (_VidPlayerForm != null)
                {
                    Decimal frameCalc = 0.0m;
                    if (_VidPlayerForm.CurrentFrame != 0)
                    {
                        frameCalc = Convert.ToDecimal(_VidPlayerForm.CurrentFrame) + 0.5m;
                    }
                    txtEndTime.Text = VideoFrame.FrameTimeFromFrameNumber(frameCalc,
                                   _VidPlayerForm.Framerate, FrameFromType.FromFrameRate);
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnChapterUidAuto_Click(object sender, EventArgs e)
        {
            try
            {
                Random rnd = new Random(DateTime.Now.Millisecond);
                byte[] buffer = new byte[sizeof(Int64)];
                rnd.NextBytes(buffer);
                txtUID.Text = BitConverter.ToInt64(buffer, 0).ToString("0000000000");
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

    }
}
