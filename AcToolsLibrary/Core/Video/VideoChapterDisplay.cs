using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace AcToolsLibrary.Core.Video
{
    public class VideoChapterDisplay
    {
        private String _name = "";
        private String _language = "";
        private String _country = "";

        public String Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }


        public String Language
        {
            get
            {
                return _language;
            }
            set
            {
                _language = value;
            }
        }

        public String Country
        {
            get
            {
                return _country;
            }
            set
            {
                _country = value;
            }
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public VideoChapterDisplay()
        {
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} [{1}] [{2}]", _name, _language, _country);
            return sb.ToString();
        }

        public XmlNode GetXMLDetails(XmlDocument doc)
        {
            XmlNode chapSubNode = doc.CreateElement("ChapterDisplay");

            XmlNode chapSubValNode = doc.CreateElement("ChapterString");
            XmlNode chapSubVal = doc.CreateTextNode(_name);
            chapSubValNode.AppendChild(chapSubVal);
            chapSubNode.AppendChild(chapSubValNode);

            chapSubValNode = doc.CreateElement("ChapterLanguage");
            chapSubVal = doc.CreateTextNode(_language);
            chapSubValNode.AppendChild(chapSubVal);
            chapSubNode.AppendChild(chapSubValNode);

            if (_country.Length > 0)
            {
                chapSubValNode = doc.CreateElement("ChapterCountry");
                chapSubVal = doc.CreateTextNode(_country);
                chapSubValNode.AppendChild(chapSubVal);
                chapSubNode.AppendChild(chapSubValNode);
            }

            return chapSubNode;
        }

        public VideoChapterDisplay Clone()
        {
            VideoChapterDisplay chapDisp = new VideoChapterDisplay();
            chapDisp._country = _country;
            chapDisp._language = _language;
            chapDisp._name = _name;
            return chapDisp;
        }
    }
}
