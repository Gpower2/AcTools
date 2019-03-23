using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace AcToolsLibrary.Core.Video
{
    public class VideoChapter
    {

        private String _name = "";
        private String _startTime = "";
        private String _endTime ="";
        private String _uID = "";
        private Boolean _hidden = false;
        private Boolean _enabled = false;
        private List<VideoChapterDisplay> _chapterDisplayList = new List<VideoChapterDisplay>();

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

        public String StartTime
        {
            get
            {
                return _startTime;
            }
            set
            {
                _startTime = value;
            }
        }

        public String EndTime
        {
            get
            {
                return _endTime;
            }
            set
            {
                _endTime = value;
            }
        }

        public String UID
        {
            get
            {
                return _uID;
            }
            set
            {
                _uID = value;
            }
        }

        public List<VideoChapterDisplay> DisplayList
        {
            get
            {
                return _chapterDisplayList;
            }
            set
            {
                _chapterDisplayList = value;
            }
        }

        public Boolean Hidden
        {
            get
            {
                return _hidden;
            }
            set
            {
                _hidden = value;
            }
        }

        public Boolean Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                _enabled = value;
            }
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public VideoChapter()
        {
        }

        /// <summary>
        /// Returns a String that represents the chapter details 
        /// in the OGM Chapter format
        /// </summary>
        /// <param name="chapterNumber">the chpater Number</param>
        /// <returns></returns>
        public String GetOgmDetails(Int32 chapterNumber)
        {
            //CHAPTER01=00:00:00.000
            //CHAPTER01NAME=Previous Episode Preview

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CHAPTER{0}={1}", chapterNumber.ToString("00"), _startTime.Substring(0, 12));
            sb.AppendLine();
            sb.AppendFormat("CHAPTER{0}NAME={1}", chapterNumber.ToString("00"), _name);

            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public XmlNode GetXmlDetails(XmlDocument doc)
        {
            //<ChapterAtom>
            //  <ChapterUID>1826097026</ChapterUID>
            //  <ChapterFlagHidden>0</ChapterFlagHidden>
            //  <ChapterFlagEnabled>1</ChapterFlagEnabled>
            //  <ChapterTimeStart>00:00:00.000000000</ChapterTimeStart>
            //  <ChapterTimeEnd>00:00:19.978000000</ChapterTimeEnd>
            //  <ChapterDisplay>
            //    <ChapterString>Previous Episode Preview</ChapterString>
            //    <ChapterLanguage>und</ChapterLanguage>
            //  </ChapterDisplay>
            //</ChapterAtom>

            XmlNode chapNode = doc.CreateElement("ChapterAtom");

            XmlNode chapValNode = doc.CreateElement("ChapterUID");
            XmlNode chapVal = doc.CreateTextNode(_uID);
            chapValNode.AppendChild(chapVal);
            chapNode.AppendChild(chapValNode);

            chapValNode = doc.CreateElement("ChapterFlagHidden");
            chapVal = doc.CreateTextNode(_hidden ? "1" : "0");
            chapValNode.AppendChild(chapVal);
            chapNode.AppendChild(chapValNode);

            chapValNode = doc.CreateElement("ChapterFlagEnabled");
            chapVal = doc.CreateTextNode(_enabled ? "1" : "0");
            chapValNode.AppendChild(chapVal);
            chapNode.AppendChild(chapValNode);

            chapValNode = doc.CreateElement("ChapterTimeStart");
            chapVal = doc.CreateTextNode(_startTime.PadRight(18, '0'));
            chapValNode.AppendChild(chapVal);
            chapNode.AppendChild(chapValNode);

            chapValNode = doc.CreateElement("ChapterTimeEnd");
            chapVal = doc.CreateTextNode(_endTime.PadRight(18, '0'));
            chapValNode.AppendChild(chapVal);
            chapNode.AppendChild(chapValNode);

            foreach (VideoChapterDisplay chapDisp in _chapterDisplayList)
            {
                chapNode.AppendChild(chapDisp.GetXMLDetails(doc));
            }

            return chapNode;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}: {1} - {2}", _name.PadRight(30, ' '), _startTime, _endTime);
            return sb.ToString();
        }

        public List<VideoChapterDisplay> CloneDisplayList()
        {
            List<VideoChapterDisplay> chapDispList = new List<VideoChapterDisplay>();
            foreach (VideoChapterDisplay chapDisp in _chapterDisplayList)
            {
                chapDispList.Add(chapDisp.Clone());
            }
            return chapDispList;
        }
    }
}
