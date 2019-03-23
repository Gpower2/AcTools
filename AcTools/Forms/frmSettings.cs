using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using AcTools.Core;
using AcTools.CommonForms;

namespace AcTools.Forms
{
    public partial class frmSettings : AcForm
    {
        public frmSettings()
        {
            InitializeComponent();
            InitColors();
            InitControls();
            InitIcon();
            this.Text = "Settings";
            InitFromSettings();
        }

        private Image createImage(PictureBox pic, Color col)
        {
            Bitmap bmp = new Bitmap(pic.Width, pic.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(new SolidBrush(col), 0, 0, pic.Width, pic.Height);
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            return bmp;
        }

        private void InitFromSettings()
        {
            picFormBackColor.Image = createImage(picFormBackColor, Color.FromArgb(AcSettings.Instance.FormBackColor));
            picEnabledControlBackColor.Image = createImage(picEnabledControlBackColor, Color.FromArgb(AcSettings.Instance.EnabledControlBackColor));
            picDisabledControlBackColor.Image = createImage(picDisabledControlBackColor, Color.FromArgb(AcSettings.Instance.DisabledControlBackColor));
            picReadOnlyControlBackColor.Image = createImage(picReadOnlyControlBackColor, Color.FromArgb(AcSettings.Instance.ReadOnlyControlBackColor));
            txtFontSample.Font = AcSettings.Instance.MyFont;
        }

        private void ReInitAllForms()
        {
            //Re init all the open forms
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() != typeof(frmMain))
                {
                    if (frm is AcForm)
                    {
                        ((AcForm)frm).ReInit();
                    }
                }
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                ReInitAllForms();
            }
            catch (Exception ex)
            {
                AcControls.Utilities.AcUtilities.DebugWrite(ex.ToString());
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                //First Save the changes
                AcSettings.Save();
                ReInitAllForms();
                this.Close();
            }
            catch (Exception ex)
            {
                AcControls.Utilities.AcUtilities.DebugWrite(ex.ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                //Load the previous settings
                AcSettings.Load();
                ReInitAllForms();
                this.Close();
            }
            catch (Exception ex)
            {
                AcControls.Utilities.AcUtilities.DebugWrite(ex.ToString());
            }
        }

        private void picFormBackColor_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog cd = new ColorDialog();
                cd.Color = Color.FromArgb(AcSettings.Instance.FormBackColor);
                cd.AllowFullOpen = true;
                cd.FullOpen = true;
                if (cd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    AcSettings.Instance.FormBackColor = cd.Color.ToArgb();
                    picFormBackColor.Image = createImage(picFormBackColor, cd.Color);
                }
            }
            catch (Exception ex)
            {
                AcControls.Utilities.AcUtilities.DebugWrite(ex.ToString());
            }
        }

        private void picEnabledControlBackColor_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog cd = new ColorDialog();
                cd.Color = Color.FromArgb(AcSettings.Instance.EnabledControlBackColor);
                cd.AllowFullOpen = true;
                cd.FullOpen = true;
                if (cd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    AcSettings.Instance.EnabledControlBackColor = cd.Color.ToArgb();
                    picEnabledControlBackColor.Image = createImage(picEnabledControlBackColor, cd.Color);
                }
            }
            catch (Exception ex)
            {
                AcControls.Utilities.AcUtilities.DebugWrite(ex.ToString());
            }
        }

        private void picDisabledControlBackColor_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog cd = new ColorDialog();
                cd.Color = Color.FromArgb(AcSettings.Instance.DisabledControlBackColor);
                cd.AllowFullOpen = true;
                cd.FullOpen = true;
                if (cd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    AcSettings.Instance.DisabledControlBackColor = cd.Color.ToArgb();
                    picDisabledControlBackColor.Image = createImage(picDisabledControlBackColor, cd.Color);
                }
            }
            catch (Exception ex)
            {
                AcControls.Utilities.AcUtilities.DebugWrite(ex.ToString());
            }
        }

        private void picReadOnlyControlBackColor_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog cd = new ColorDialog();
                cd.Color = Color.FromArgb(AcSettings.Instance.ReadOnlyControlBackColor);
                cd.AllowFullOpen = true;
                cd.FullOpen = true;
                if (cd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    AcSettings.Instance.ReadOnlyControlBackColor = cd.Color.ToArgb();
                    picReadOnlyControlBackColor.Image = createImage(picReadOnlyControlBackColor, cd.Color);
                }
            }
            catch (Exception ex)
            {
                AcControls.Utilities.AcUtilities.DebugWrite(ex.ToString());
            }
        }

        private void btnChangeFont_Click(object sender, EventArgs e)
        {
            try
            {
                FontDialog fd = new FontDialog();
                fd.Font = AcSettings.Instance.MyFont;
                if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    AcSettings.Instance.FontName = fd.Font.FontFamily.Name;
                    AcSettings.Instance.FontSize = fd.Font.Size;
                    AcSettings.Instance.FontBold = fd.Font.Bold;
                    AcSettings.Instance.FontItalic = fd.Font.Italic;
                    AcSettings.Instance.FontUnderline = fd.Font.Underline;
                    AcSettings.Instance.FontStrikeout = fd.Font.Strikeout;
                    txtFontSample.Font = AcSettings.Instance.MyFont;
                }
            }
            catch (Exception ex)
            {
                AcControls.Utilities.AcUtilities.DebugWrite(ex.ToString());
            }
        }

        private void btnDefaults_Click(object sender, EventArgs e)
        {
            try
            {
                AcSettings.Reset();
                InitFromSettings();
            }
            catch (Exception ex)
            {
                AcControls.Utilities.AcUtilities.DebugWrite(ex.ToString());
            }
        }

    }
}
