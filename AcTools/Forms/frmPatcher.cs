using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;

using AcTools.Core;

using AcToolsLibrary.Common;
using AcToolsLibrary.Core.Other;

namespace AcTools.Forms
{
    public partial class frmPatcher : AcForm
    {
        private Patcher _Per = new Patcher();

        /// <summary>
        /// Constructor of the form
        /// </summary>
        public frmPatcher()
        {
            InitializeComponent();
            InitColors();
            InitControls();
            InitIcon();
            chkCopyXdelta.Checked = true;
            this.Text = "Patcher (xDelta)";
        }

        private void btnHook_Click(object sender, EventArgs e)
        {
            HookUnHook(btnHook);
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

        private void btnBrowseOldFile_Click(object sender, EventArgs e)
        {
            String[] filenames = ShowOpenFileDialog("Select old file...", "", "", false);
            if (filenames != null)
            {
                if (filenames[0].Length > 0)
                {
                    txtOldFile.Text = filenames[0];
                }
            }
        }

        private void btnBrowseNewFile_Click(object sender, EventArgs e)
        {
            String[] filenames = ShowOpenFileDialog("Select new file...", "", "", false);
            if (filenames != null)
            {
                if (filenames[0].Length > 0)
                {
                    txtNewFile.Text = filenames[0];
                }
            }
        }

        private void btnBrowsePatchFile_Click(object sender, EventArgs e)
        {
            String filename = ShowSaveFileDialog("Select diff file...", "", "");
            if (filename != null)
            {
                if (filename.Length > 0)
                {
                    txtDiffFile.Text = filename;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txtOldFile.Text))
                {
                    throw new Exception("Please provide with an old file first!");
                }
                if (!File.Exists(txtOldFile.Text))
                {
                    throw new Exception("Please provide with an existing old file first!");
                }
                if (String.IsNullOrWhiteSpace(txtNewFile.Text))
                {
                    throw new Exception("Please provide with a new file first!");
                }
                if (!File.Exists(txtNewFile.Text))
                {
                    throw new Exception("Please provide with an existing new file first!");
                }
                if (String.IsNullOrWhiteSpace(txtDiffFile.Text))
                {
                    throw new Exception("Please provide with a diff filename first!");
                }
                _Per.AddPatch(new Patch(txtOldFile.Text, txtNewFile.Text, txtDiffFile.Text));

                refreshPatchList();

                txtDiffFile.Text = "";
                txtNewFile.Text = "";
                txtOldFile.Text = "";
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void refreshPatchList()
        {
            listPatches.Items.Clear();
            if (_Per != null)
            {
                listPatches.Items.AddRange(_Per.PatchList.ToArray());
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (listPatches.SelectedIndex < 0)
                {
                    throw new Exception("Please select a patch from the list first!");
                }
                _Per.RemovePatchAt(listPatches.SelectedIndex);
                refreshPatchList();
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnMakePatches_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Per.PatchList.Count > 0)
                {
                    _Per.WithWindow = !checkHideConsole.Checked;
                    _Per.CopyXdelta = chkCopyXdelta.Checked;

                    Cursor = Cursors.WaitCursor;
                    toggleControls(false);
                    Thread t = new Thread(new ThreadStart(_Per.RunPatcherThreaded));
                    t.Start();
                    //Wait for the thread to finish while keeping UI responsive
                    while (t.ThreadState != System.Threading.ThreadState.Stopped)
                    {
                        Application.DoEvents();
                    }
                    // Check for errors in the operation
                    if (_Per.ThreadException != null)
                    {
                        throw _Per.ThreadException;
                    }
                    Cursor = Cursors.Default;
                    toggleControls(true);
                    ShowSuccessMessage("Finished making patches!", "Patcher completed!");
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                ShowExceptionMessage(ex, "Error in making patches!");
                toggleControls(true);
            }
        }

        private void listPatches_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listPatches.SelectedIndex > -1)
                {
                    Tooltip.SetToolTip(listPatches, listPatches.SelectedItem.ToString());
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Check if both fields are filled
                if (!String.IsNullOrWhiteSpace(txtOldFile.Text) && !String.IsNullOrWhiteSpace(txtNewFile.Text))
                {
                    txtDiffFile.Text = String.Format("{0}.diff", AcHelper.GetFilename(txtNewFile.Text, GetFileNameMode.FilenameWithoutExtension, GetDirectoryNameMode.FullPath));
                }
            }
            catch (Exception ex)
            {                
                ShowExceptionMessage(ex);
            }
        }

        private void toggleControls(Boolean status)
        {
            foreach (Control ctrl in Controls)
            {
                try
                {
                    ctrl.Enabled = status;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }
    }
}
