using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AcTools.Core.Subtitles
{
    public class FormattedString
    {
        private List<FormattedString> _FormattedStrings = new List<FormattedString>();

        public List<FormattedString> FormattedStrings
        {
            get { return _FormattedStrings; }
            set { _FormattedStrings = value; }
        }

        private string _ClearText;

        public string ClearText
        {
            get { return _ClearText; }
            set { _ClearText = value; }
        }

        private string _RawText;

        public string RawText
        {
            get { return _RawText; }
            set { _RawText = value; }
        }


        /// <summary>
        /// Default empty Constructor
        /// </summary>
        public FormattedString() { }

        /// <summary>
        /// Constructor that 
        /// </summary>
        /// <param name="argString"></param>
        public FormattedString(String argString)
        {
            _RawText = argString;
            ParseRawString();
        }

        private void ParseRawString()
        {

        }


        public override string ToString()
        {
            return base.ToString();
        }

    }
}
