using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using AcControls.AcRichTextBoxControl;
using AcTools.Core;

namespace AcTools.Forms
{
    public partial class frmAviSynthEditor : AcForm
    {
        public frmAviSynthEditor()
        {
            InitializeComponent();
            InitRichTextBox(rtxtAviSynthCode);
            InitColors();
            InitControls();
            InitIcon();
            this.Text = "AviSynth Editor";
        }

        private void InitRichTextBox(AcRichTextBox ctrl)
        {
            ctrl.Seperators.Add(' ');
            ctrl.Seperators.Add('\r');
            ctrl.Seperators.Add('\n');
            ctrl.Seperators.Add(',');
            ctrl.Seperators.Add('.');
            ctrl.Seperators.Add('-');
            ctrl.Seperators.Add('+');
            ctrl.WordWrap = false;
            ctrl.ScrollBars = RichTextBoxScrollBars.Both;
            
            ctrl.FilterAutoComplete = true;
            ctrl.Font = new Font("Courier New", 10, FontStyle.Regular); 
            ctrl.HighlightDescriptors.Add(new HighlightDescriptor("Hello", Color.Red, null, DescriptorType.Word, DescriptorRecognition.WholeWord, true));
            ctrl.HighlightDescriptors.Add(new HighlightDescriptor("Hellofatime", Color.Green, null, DescriptorType.Word, DescriptorRecognition.WholeWord, true));
            ctrl.HighlightDescriptors.Add(new HighlightDescriptor("Helsinky", Color.Maroon, null, DescriptorType.Word, DescriptorRecognition.WholeWord, true));
            ctrl.HighlightDescriptors.Add(new HighlightDescriptor("World", Color.Blue, null, DescriptorType.Word, DescriptorRecognition.WholeWord, true));
            ctrl.HighlightDescriptors.Add(new HighlightDescriptor("/*", "*/", Color.Magenta, null, DescriptorType.ToCloseToken, DescriptorRecognition.StartsWith, false));
            ctrl.HighlightDescriptors.Add(new HighlightDescriptor("#", Color.Green, null, DescriptorType.ToEOL, DescriptorRecognition.StartsWith, false));

        }

    }
}
