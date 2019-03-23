using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using AcTools.Core;
using AcToolsLibrary.Core.Video;

namespace AcTools.Forms
{
    public partial class frmResizeCalculator : AcForm
    {
        private Resizer rsz = new Resizer();

        public frmResizeCalculator()
        {
            InitializeComponent();
            InitColors();
            InitControls();
            InitIcon(AcTools.Properties.Resources.ResizeCalculator);
            fillComboAspectRatio();
            fillComboTargetMod();
            this.Text = "Resize Calculator";
            CheckDesiredDimension();
        }

        private void fillComboAspectRatio()
        {
            comAspectRatio.Items.Clear();
            comAspectRatio.Items.Add("4/3");
            comAspectRatio.Items.Add("3/2");
            comAspectRatio.Items.Add("16/9");
            comAspectRatio.Items.Add("185/100");
            comAspectRatio.Items.Add("239/100");
            comAspectRatio.Items.Add("Custom");
            comAspectRatio.SelectedIndex = 2;
        }

        private void fillComboTargetMod()
        {
            comTargetMod.Items.Clear();
            comTargetMod.Items.Add("1");
            comTargetMod.Items.Add("2");
            comTargetMod.Items.Add("4");
            comTargetMod.Items.Add("8");
            comTargetMod.Items.Add("16");
            comTargetMod.SelectedIndex = 4;
        }

        private Boolean refreshResizer()
        {
            //Original values
            if (txtOriginalWidth.Text.Length > 0)
            {
                try
                {
                    rsz.OriginalWidth = Int64.Parse(txtOriginalWidth.Text);
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            if (txtOriginalHeight.Text.Length > 0)
            {
                try
                {
                    rsz.OriginalHeight = Int64.Parse(txtOriginalHeight.Text);
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            //Crop values
            if (txtCropX1.Text.Length > 0)
            {
                try
                {
                    rsz.CropX1 = Int64.Parse(txtCropX1.Text);
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                rsz.CropX1 = 0;
            }

            if (txtCropX2.Text.Length > 0)
            {
                try
                {
                    rsz.CropX2 = Int64.Parse(txtCropX2.Text);
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                rsz.CropX2 = 0;
            }

            if (txtCropY1.Text.Length > 0)
            {
                try
                {
                    rsz.CropY1 = Int64.Parse(txtCropY1.Text);
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                rsz.CropY1 = 0;
            }

            if (txtCropY2.Text.Length > 0)
            {
                try
                {
                    rsz.CropY2 = Int64.Parse(txtCropY2.Text);
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                rsz.CropY2 = 0;
            }

            //Aspect ratio
            if (checkChangeAspectRatio.Checked)
            {
                if (Convert.ToString(comAspectRatio.SelectedItem).ToLowerInvariant().CompareTo("custom") == 0)
                {
                    try
                    {
                        rsz.StretchAspectRatioNum = Int64.Parse(txtCustomAspectRatioNum.Text.Trim());
                        rsz.StretchAspectRatioDenum = Int64.Parse(txtCustomAspectRatioDenum.Text.Trim());
                    }
                    catch
                    {
                        return false;
                    }
                }
                else
                {
                    String selRatio = Convert.ToString(comAspectRatio.SelectedItem);
                    String[] selValues = selRatio.Split(new String[] { "/" }, StringSplitOptions.None);
                    if (selValues.Length != 2)
                    {
                        return false;
                    }
                    else
                    {
                        try
                        {
                            rsz.StretchAspectRatioNum = Int64.Parse(selValues[0].Trim());
                            rsz.StretchAspectRatioDenum = Int64.Parse(selValues[1].Trim());
                        }
                        catch
                        {
                            return false;
                        }
                    }
                }
            }
            else
            {
                rsz.StretchAspectRatioNum = rsz.OriginalWidth;
                rsz.StretchAspectRatioDenum = rsz.OriginalHeight;
            }

            //Mod
            String selMod = Convert.ToString(comTargetMod.SelectedItem);
            try
            {
                rsz.TargetMod = Int64.Parse(selMod);
            }
            catch
            {
                return false;
            }
            return true;
        }

        private void refreshResults()
        {
            txtTrueWidth.Text = rsz.TrueWidth.ToString();
            txtTrueHeight.Text = rsz.TrueHeight.ToString();
            txtTruePixels.Text = rsz.TruePixels.ToString();
            txtTrueAspectRatio.Text = rsz.TrueStretchedAspectRatio.ToString();
            
            txtFinalWidth.Text = rsz.FinalStretchedWidth.ToString();
            txtFinalHeight.Text = rsz.FinalStretchedHeight.ToString();
            txtFinalPixels.Text = rsz.FinalStretchedPixels.ToString();
            txtFinalAspectRatio.Text = rsz.FinalStretchedAspectRatio.ToString();
            txtFinalError.Text = rsz.AspectRatioStretchedError.ToString() + "%";

            txtEncAnamWidth.Text = rsz.EncAnamorphicWidth.ToString();
            txtEncAnamHeight.Text = rsz.EncAnamorphicHeight.ToString();
            txtEncAnamError.Text = rsz.EncAnamorphicError.ToString() + "%";

            txtFinalAnamWidth.Text = rsz.FinalAnamorphicWidth.ToString();
            txtFinalAnamHeight.Text = rsz.FinalAnamorphicHeight.ToString();
            txtFinalAnamError.Text = rsz.FinalAnamorphicError.ToString() + "%";
        }

        private void clearResults()
        {
            txtTrueWidth.Text = "";
            txtTrueHeight.Text = "";
            txtTruePixels.Text = "";
            txtTrueAspectRatio.Text = "";

            txtFinalWidth.Text = "";
            txtFinalHeight.Text = "";
            txtFinalPixels.Text = "";
            txtFinalAspectRatio.Text = "";
            txtFinalError.Text = "";

            txtEncAnamWidth.Text = "";
            txtEncAnamHeight.Text = "";
            txtEncAnamError.Text = "";

            txtFinalAnamWidth.Text = "";
            txtFinalAnamHeight.Text = "";
            txtFinalAnamError.Text = "";
        }

        private void calculateValues()
        {
            if (refreshResizer())
            {
                String selMod = Convert.ToString(comTargetMod.SelectedItem);
                Int64 desW = 0;
                Int64 desH = 0;
                try
                {
                    if (chkDesiredHeight.Checked)
                    {
                        if (txtDesiredHeight.Text.Length > 0)
                        {
                            desH = Resizer.ClosestMod(Int64.Parse(txtDesiredHeight.Text), Int64.Parse(selMod));
                        }
                        else
                        {
                            desH = Resizer.ClosestMod(Int64.Parse(txtOriginalHeight.Text), Int64.Parse(selMod));
                        }
                        rsz.CalculateValuesForDesiredHeight(desH);
                    }
                    else
                    {
                        if (txtDesiredWidth.Text.Length > 0)
                        {
                            desW = Resizer.ClosestMod(Int64.Parse(txtDesiredWidth.Text), Int64.Parse(selMod));
                        }
                        else
                        {
                            desW = Resizer.ClosestMod(Int64.Parse(txtOriginalWidth.Text), Int64.Parse(selMod));
                        }
                        rsz.CalculateValuesForDesiredWidth(desW);
                    }
                    rsz.CalculateAnamorphicValues();
                    refreshResults();
                }
                catch
                {
                    clearResults();
                    return;
                }
            }
            else
            {
                clearResults();
            }
        }

        private void ControlValuesChanged(object sender, EventArgs e)
        {
            Boolean useCustomAR = ((String)comAspectRatio.SelectedItem).ToLower().Equals("custom");
            txtCustomAspectRatioNum.Enabled = useCustomAR;
            txtCustomAspectRatioDenum.Enabled = useCustomAR;
            calculateValues();
        }

        private void btnIncreaseDesiredWidth_Click(object sender, EventArgs e)
        {
            try
            {
                String selMod = Convert.ToString(comTargetMod.SelectedItem);
                txtDesiredWidth.Text = (Resizer.ClosestMod(Int64.Parse(txtDesiredWidth.Text), Int64.Parse(selMod)) + Int64.Parse(selMod)).ToString();
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnDecreaseDesiredWidth_Click(object sender, EventArgs e)
        {
            try
            {
                String selMod = Convert.ToString(comTargetMod.SelectedItem);
                txtDesiredWidth.Text = (Resizer.ClosestMod(Int64.Parse(txtDesiredWidth.Text), Int64.Parse(selMod)) - Int64.Parse(selMod)).ToString();
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void clearCrop()
        {
            txtCropX1.Text = "";
            txtCropX2.Text = "";
            txtCropY1.Text = "";
            txtCropY2.Text = "";
        }

        private void CheckDesiredDimension()
        {
            txtDesiredHeight.Enabled = chkDesiredHeight.Checked;
            btnIncreaseDesiredHeight.Enabled = chkDesiredHeight.Checked;
            btnDecreaseDesiredHeight.Enabled = chkDesiredHeight.Checked;
            txtDesiredWidth.Enabled = !chkDesiredHeight.Checked;
            btnIncreaseDesiredWidth.Enabled = !chkDesiredHeight.Checked;
            btnDecreaseDesiredWidth.Enabled = !chkDesiredHeight.Checked;
        }

        private void btnResetCrop_Click(object sender, EventArgs e)
        {
            clearCrop();
        }

        private void btnHook_Click(object sender, EventArgs e)
        {
            HookUnHook(btnHook);
        }

        private void btnIncreaseDesiredHeight_Click(object sender, EventArgs e)
        {
            try
            {
                String selMod = Convert.ToString(comTargetMod.SelectedItem);
                txtDesiredHeight.Text = (Resizer.ClosestMod(Int64.Parse(txtDesiredHeight.Text), Int64.Parse(selMod)) + Int64.Parse(selMod)).ToString();
            }
            catch(Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void btnDecreaseDesiredHeight_Click(object sender, EventArgs e)
        {
            try
            {
                String selMod = Convert.ToString(comTargetMod.SelectedItem);
                txtDesiredHeight.Text = (Resizer.ClosestMod(Int64.Parse(txtDesiredHeight.Text), Int64.Parse(selMod)) - Int64.Parse(selMod)).ToString();
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void chkDesiredHeight_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckDesiredDimension();
                calculateValues();
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }
    }
}
