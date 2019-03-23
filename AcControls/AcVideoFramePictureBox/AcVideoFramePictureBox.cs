using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using AcControls.Utilities;

namespace AcControls.AcVideoFramePictureBox
{
    /// <summary>
    /// A sustom PictureBox Control that contains methods for 
    /// displaying a video frame image
    /// </summary>
    public class AcVideoFramePictureBox : PictureBox
    {
        /// <summary>
        /// The context menu that contains quick links for usefull procedures
        /// </summary>
        private ContextMenuStrip _ContextMenu = null;

        /// <summary>
        /// The context menu item for copying image to clipboard
        /// </summary>
        private ToolStripMenuItem _CopyImageToClipboard = null;

        /// <summary>
        /// The context menu item for saving image to file
        /// </summary>
        private ToolStripMenuItem _SaveImageToFile = null;

        /// <summary>
        /// The enumeration for handle image types
        /// </summary>
        private enum _HandleImageTypes
        {
            CopyToClipboard,
            SaveToFile
        }

        /// <summary>
        /// Constructor of the control
        /// Builds the context menu
        /// </summary>
        public AcVideoFramePictureBox()
        {
            buildContextMenu();
        }

        /// <summary>
        /// Builds the context menu
        /// Creates and adds the menu items
        /// Assigns the event handlers
        /// </summary>
        private void buildContextMenu()
        {
            //Create the menu and the necessary items
            _ContextMenu = new ContextMenuStrip();
            _CopyImageToClipboard = new ToolStripMenuItem("Copy Image to Clipboard");
            _SaveImageToFile = new ToolStripMenuItem("Save Image to file...");
            //Add the items to the menu
            _ContextMenu.Items.Add(_CopyImageToClipboard);
            _ContextMenu.Items.Add(_SaveImageToFile);
            //Add the menu to the picturebox
            this.ContextMenuStrip = _ContextMenu;
            //Add the events to the items
            _CopyImageToClipboard.Click += new EventHandler(OnCopyImageToClipboard);
            _SaveImageToFile.Click += new EventHandler(OnSaveImageToFile);
        }

        /// <summary>
        /// The event handler for copying the image to clipboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCopyImageToClipboard(object sender, EventArgs e)
        {
            try
            {
                HandleImage(_HandleImageTypes.CopyToClipboard);
            }
            catch (Exception ex)
            {
                AcUtilities.DebugWrite(ex.ToString());
                AcMessageBox.AcMessageBox.Show("Error while copying to clipboard!\r\n" + ex.Message, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// The event handler for saving the image to clipboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSaveImageToFile(object sender, EventArgs e)
        {
            try
            {
                HandleImage(_HandleImageTypes.SaveToFile);
            }
            catch (Exception ex)
            {
                AcUtilities.DebugWrite(ex.ToString());
                AcMessageBox.AcMessageBox.Show("Error while saving to file!\r\n" + ex.Message, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// The handler of the image processing
        /// </summary>
        private void HandleImage(_HandleImageTypes handleType)
        {
            if (this.Image == null)
            {
                throw new Exception("Image is null!");
            }
            else if (this.Image == this.ErrorImage)
            {
                throw new Exception("Image is error image!");
            }
            else if (this.Image == this.InitialImage)
            {
                throw new Exception("Image is initial image!");
            }
            else
            {
                switch (handleType)
                {
                    case _HandleImageTypes.CopyToClipboard:
                        Clipboard.SetImage((Image)this.Image.Clone());
                        AcUtilities.DebugWrite("Image successfully copied to Clipboard");
                        AcMessageBox.AcMessageBox.Show("Successfully copied to Clipboard!");
                        break;
                    case _HandleImageTypes.SaveToFile:
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Title = "Select the filename of the image...";
                        StringBuilder filterBuilder = new StringBuilder();
                        filterBuilder.AppendFormat("{0} files (*.{0})|*.{0}", "png");
                        filterBuilder.AppendFormat("|{0} files (*.{0})|*.{0}", "jpg");
                        filterBuilder.AppendFormat("|{0} files (*.{0})|*.{0}", "gif");
                        filterBuilder.AppendFormat("|{0} files (*.{0})|*.{0}", "tiff");
                        filterBuilder.AppendFormat("|{0} files (*.{0})|*.{0}", "bmp");
                        sfd.Filter = filterBuilder.ToString();
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            System.Drawing.Imaging.ImageFormat imgFormat = null;
                            switch (sfd.FilterIndex)
                            {
                                case 1:
                                    imgFormat = System.Drawing.Imaging.ImageFormat.Png;
                                    break;
                                case 2:
                                    imgFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
                                    break;
                                case 3:
                                    imgFormat = System.Drawing.Imaging.ImageFormat.Gif;
                                    break;
                                case 4:
                                    imgFormat = System.Drawing.Imaging.ImageFormat.Tiff;
                                    break;
                                case 5:
                                    imgFormat = System.Drawing.Imaging.ImageFormat.Bmp;
                                    break;
                            }
                            this.Image.Save(sfd.FileName, imgFormat);
                            AcUtilities.DebugWrite("Image successfully copied to file " + sfd.FileName);
                            AcMessageBox.AcMessageBox.Show("Successfully saved to file!");
                        }
                        break;
                }
            }
        }
    }
}
