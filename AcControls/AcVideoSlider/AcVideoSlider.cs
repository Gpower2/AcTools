using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using AcControls.Utilities;

namespace AcControls.AcVideoSlider
{
    public class AcVideoSlider : TrackBar
    {
        private static UInt16 StartMargin = 9;
        private static UInt16 EndMargin = 9;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            //base.OnMouseDown(e);
            try
            {
                Int32 newValue = GetValueFromMouseClick(e.X);
                if (this.Value != newValue)
                {
                    this.Value = newValue;
                }
            }
            catch (Exception ex)
            {
                AcUtilities.DebugWrite(ex.ToString());
                AcMessageBox.AcMessageBox.Show("Error changing value!\r\n" + ex.Message, MessageBoxIcon.Error);
            }
        }

        public Int32 GetValueFromMouseClick(Int32 mouseX)
        {
            Double dblValue;
            Int32 intValue;

            // Jump to the clicked location
            Int32 normX = mouseX - AcVideoSlider.StartMargin;
            Int32 normWidth = Width - AcVideoSlider.StartMargin - AcVideoSlider.EndMargin;
            Double normRatio = Convert.ToDouble(Maximum - Minimum) / Convert.ToDouble(normWidth);
            dblValue = normX * normRatio;
            intValue = Convert.ToInt32(dblValue);
            if (intValue > Maximum)
            {
                intValue = Maximum;
            }
            else if (intValue < 0)
            {
                intValue = 0;
            }
            return intValue;
        }

    }
}
