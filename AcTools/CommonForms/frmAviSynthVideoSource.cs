using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using AcTools.Core;

using AcToolsLibrary.Core.Video.VideoProviders.AviSynth.VideoSourceProviders;
using AcToolsLibrary.Common;

namespace AcTools.CommonForms
{
    public partial class frmAviSynthVideoSource : AcForm
    {
        private Boolean _OkPressed = false;

        public AviSynthSourceProvidersEnum SelectedAviSynthVideoProvider
        {
            get
            {
                if (radioAviSource.Checked)
                {
                    return AviSynthSourceProvidersEnum.AviSource;
                }
                else if (radioDGAVCDec.Checked)
                {
                    return AviSynthSourceProvidersEnum.DGAVCDec;
                }
                else if (radioDGMPGDec.Checked)
                {
                    return AviSynthSourceProvidersEnum.DGMPGDec;
                }
                else if (radioDirectShowSource.Checked)
                {
                    return AviSynthSourceProvidersEnum.DirectShowSource;
                }
                else if (radioDirectShowSource2.Checked)
                {
                    return AviSynthSourceProvidersEnum.DirectShowSource2;
                }
                else if (radioFFMpegSource2.Checked)
                {
                    return AviSynthSourceProvidersEnum.FFMpegSource2;
                }
                else
                {
                    return AviSynthSourceProvidersEnum.FFMpegSource2;
                }
            }
        }

        /// <summary>
        /// Gets if OK button was pressed
        /// </summary>
        public Boolean OKPressed
        {
            get
            {
                return _OkPressed;
            }
        }

        /// <summary>
        /// Gets if override frame rate was checked
        /// </summary>
        public Boolean OverrideFramerateChecked
        {
            get
            {
                return checkFramerate.Checked;
            }
        }

        /// <summary>
        /// Gets the override frame rate value
        /// </summary>
        public Double OverrideFramerate
        {
            get
            {
                return AcHelper.DoubleParse(Convert.ToString(cmbFramerate.Text));
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public frmAviSynthVideoSource()
        {
            InitializeComponent();
            InitColors();
            InitControls();
            fillFramerates();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _OkPressed = true;
            this.Close();
        }

        /// <summary>
        /// Fills the combobox with the frame rates
        /// </summary>
        private void fillFramerates()
        {
            cmbFramerate.Items.Clear();
            cmbFramerate.Items.Add("29.97");
            cmbFramerate.Items.Add("23.976");
            cmbFramerate.Items.Add("25");
            //Select the first item
            cmbFramerate.SelectedIndex = 0;
        }

    }
}
