using System;
using System.Collections.Generic;
using System.Text;

namespace AcToolsLibrary.Core.Subtitles.ASS
{
    public class AssSectionScriptInfo
    {
        public static String SECTION_HEADER = "[Script Info]";

        private List<String> _comments = new List<String>();
        private List<String> _unknownFields = new List<String>();

        public List<String> Comments
        {
            get { return _comments; }
        }

        public List<String> UnknownFields
        {
            get { return _unknownFields; }
        }

        //ASS Standard fields
        public String Title;
        public String OriginalScript;
        //START OPTIONAL STANDARD FIELDS
        public String OriginalTranslation;
        public String OriginalEditing;
        public String OriginalTiming;
        public String SynchPoint;
        public String ScriptUpdatedBy;
        //END OPTIONAL STANDARD FIELDS
        public String UpdateDetails;
        public String ScriptType;
        public String Collisions;
        public String PlayResY;
        public String PlayResX;
        public String PlayDepth;
        public String Timer;
        public String WrapStyle;

        //Aegisub custom fields
        public String AudioFile;
        public String VideoFile;
        public String VideoAspectRatio;
        public String VideoZoom;
        public String AudioURI;
        public String VideoPosition;
        public String ScaledBorderAndShadow;
        public String LastStyleStorage;

        /// <summary>
        /// Default constructor
        /// </summary>
        public AssSectionScriptInfo()
        {

        }
    }
}
