using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AcTools.Core;
using System.Diagnostics;

namespace AcTools.Forms
{
    public partial class frmVideoPlayerCrop : AcForm
    {
        private frmVideoPlayer vpf;
        private Boolean fromFunction = false;

        public frmVideoPlayerCrop(frmVideoPlayer masterForm, Int32 maximumWidth, Int32 maximumHeight)
        {
            InitializeComponent();
            InitColors();
            InitControls();
            InitIcon();
            this.Text = "Video Player Crop";
            vpf = masterForm;
            numX1.Maximum = maximumWidth;
            numX2.Maximum = maximumWidth;
            numY1.Maximum = maximumHeight;
            numY2.Maximum = maximumHeight;
        }

        private void Crop_ValueChanged(object sender, EventArgs e)
        {
            if (!fromFunction)
            {
                vpf.CropX1 = Convert.ToInt32(numX1.Value);
                vpf.CropX2 = Convert.ToInt32(numX2.Value);
                vpf.CropY1 = Convert.ToInt32(numY1.Value);
                vpf.CropY2 = Convert.ToInt32(numY2.Value);
                txtAvisynthCrop.Text = "crop(" + vpf.CropX1 + ", " + vpf.CropY1 + ", -" + vpf.CropX2 + ", -" + vpf.CropY2 + ")";
                vpf.UpdateVideoFrameImage();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            numX1.Value = 0;
            numX2.Value = 0;
            numY1.Value = 0;
            numY2.Value = 0;
        }

        private void btnHook_Click(object sender, EventArgs e)
        {
            HookUnHook();
            if (HookState == FormHookState.Unhooked)
            {
                btnHook.Text = "Hook";
            }
            else
            {
                btnHook.Text = "UnHook";
            }
        }

        private void checkOnTop_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = checkOnTop.Checked;
        }

        public void SetCropValues(Int32 x1, Int32 y1, Int32 x2, Int32 y2)
        {
            fromFunction = true;
            numX1.Value = x1;
            numX2.Value = x2;
            numY1.Value = y1;
            numY2.Value = y2;
            fromFunction = false;
        }
    }
}
