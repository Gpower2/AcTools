using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace AcControls.AcRichTextBoxControl
{
    public class HighlightDescriptor
    {
        public HighlightDescriptor(String _token, Color _color, Font _font, DescriptorType _descriptorType, DescriptorRecognition _dr, Boolean _useForAutoComplete)
        {
            if (descriptorType == AcRichTextBoxControl.DescriptorType.ToCloseToken)
            {
                throw new ArgumentException("You may not choose ToCloseToken DescriptorType without specifing an end token.");
            }
            color = _color;
            font = _font;
            token = _token;
            descriptorType = _descriptorType;
            descriptorRecognition = _dr;
            closeToken = null;
            useForAutoComplete = _useForAutoComplete;
        }

        public HighlightDescriptor(String _token, String _closeToken, Color _color, Font _font, DescriptorType _descriptorType, DescriptorRecognition _dr, Boolean _useForAutoComplete)
        {
            color = _color;
            font = _font;
            token = _token;
            descriptorType = _descriptorType;
            closeToken = _closeToken;
            descriptorRecognition = _dr;
            useForAutoComplete = _useForAutoComplete;
        }

        private Color color;

        public Color Color
        {
            get
            {
                return color;
            }
        }
        
        private Font font;
        public Font Font
        {
            get
            {
                return font;
            }
        }

        private String token;
        public String Token
        {
            get
            {
                return token;
            }
        }

        private String closeToken;
        public String CloseToken
        {
            get
            {
                return closeToken;
            }
        }

        private DescriptorType descriptorType;
        public DescriptorType DescriptorType
        {
            get
            {
                return descriptorType;
            }
        }

        private DescriptorRecognition descriptorRecognition;
        public DescriptorRecognition DescriptorRecognition
        {
            get
            {
                return descriptorRecognition;
            }
        }

        private Boolean useForAutoComplete;
        public Boolean UseForAutoComplete
        {
            get
            {
                return useForAutoComplete;
            }
        }
    }


    public enum DescriptorType
    {
        /// <summary>
        /// Causes the highlighting of a single word
        /// </summary>
        Word,
        /// <summary>
        /// Causes the entire line from this point on the be highlighted, regardless of other tokens
        /// </summary>
        ToEOL,
        /// <summary>
        /// Highlights all text until the end token;
        /// </summary>
        ToCloseToken
    }

    public enum DescriptorRecognition
    {
        /// <summary>
        /// Only if the whole token is equal to the word
        /// </summary>
        WholeWord,
        /// <summary>
        /// If the word starts with the token
        /// </summary>
        StartsWith,
        /// <summary>
        /// If the word contains the Token
        /// </summary>
        Contains
    }
}
