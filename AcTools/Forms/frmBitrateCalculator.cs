using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using AcTools.Core;
using AcToolsLibrary.Core.Video;
using AcToolsLibrary.Common;

namespace AcTools.Forms
{
    public partial class frmBitrateCalculator : AcForm
    {
        BitrateCalculator brCalc = new BitrateCalculator();

        public frmBitrateCalculator()
        {
            InitializeComponent();
            InitColors();
            InitControls();
            InitIcon();
            this.Text = "Bitrate Calculator";
            InitForm();
        }

        private void InitForm()
        {
            radioUseVideoBitrate.Checked = true;
            radioUseAudioBitrate.Checked = true;
            txtHours.Text = "0";
            txtMinutes.Text = "0";
            txtSeconds.Text = "0";
        }

        private void radioUseAudioBitrate_CheckedChanged(object sender, EventArgs e)
        {
            txtAudioBitrate.ReadOnly = !radioUseAudioBitrate.Checked;
            txtAudioSize.ReadOnly = radioUseAudioBitrate.Checked;
            InitColors();
        }

        private void radioTargetBitrate_CheckedChanged(object sender, EventArgs e)
        {
            txtTargetVideoBitrate.ReadOnly = !radioUseVideoBitrate.Checked;
            txtTargetVideoFileSize.ReadOnly = radioUseVideoBitrate.Checked;
            txtTargetTotalFileSize.ReadOnly = radioUseVideoBitrate.Checked;
            InitColors();
        }

        private void txtHours_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double duration = 0.0;
                Double audioSize = 0.0;
                Double audioBitrate = 0.0;
                AudioValueType audioValueType = AudioValueType.AudioBitrate;
                Double audioValue = 0.0;
                Double videoSize = 0.0;

                duration = brCalc.GetSecondsFromTime(Int32.Parse(txtHours.Text), Int32.Parse(txtMinutes.Text), Int32.Parse(txtSeconds.Text));
                txtCalculatedDuration.Text = duration.ToString("#.00");

                if (radioUseAudioBitrate.Checked)
                {
                    audioSize = brCalc.BitrateToSize(AcHelper.DoubleParse(txtAudioBitrate.Text), duration) / 1024.0 / 1024.0;
                    txtAudioSize.Text = (audioSize).ToString("#.00");
                    audioValueType = AudioValueType.AudioBitrate;
                    audioValue = AcHelper.DoubleParse(txtAudioBitrate.Text);
                }
                else if (radioUseAudioSize.Checked)
                {
                    audioBitrate = brCalc.SizeToBitrate(AcHelper.DoubleParse(txtAudioSize.Text) * 1024.0 * 1024.0, duration);
                    txtAudioBitrate.Text = audioBitrate.ToString("#.00");
                    audioValueType = AudioValueType.AudioFileSize;
                    audioValue = AcHelper.DoubleParse(txtAudioSize.Text) * 1024.0 * 1024.0;
                    audioSize = audioValue;
                }

                if (radioUseVideoBitrate.Checked)
                {
                    videoSize = brCalc.BitrateToSize(AcHelper.DoubleParse(txtTargetVideoBitrate.Text), duration);
                    txtTargetVideoFileSize.Text = (videoSize / 1024.0 / 1024.0).ToString("#.00");
                    txtTargetTotalFileSize.Text = ((videoSize + audioSize) / 1024.0 / 1024.0).ToString("#.00");// (brCalc.CalculateTarget(duration, audioValueType, audioValue, Video_Value_Type.Video_Bitrate, AcHelper.DoubleParse(txtTargetVideoBitrate.Text)) / 1024.0 / 1024.0).ToString("#.00");
                }
                else if (radioUseTotalFileSize.Checked)
                {
                    txtTargetVideoBitrate.Text = brCalc.CalculateTarget(duration, audioValueType, audioValue, VideoValueType.TotalFileSize, AcHelper.DoubleParse(txtTargetTotalFileSize.Text) * 1024.0 * 1024.0).ToString("#.00");
                    videoSize = brCalc.BitrateToSize(AcHelper.DoubleParse(txtTargetVideoBitrate.Text), duration);
                    txtTargetVideoFileSize.Text = (videoSize / 1024.0 / 1024.0).ToString("#.00");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

    }
}
