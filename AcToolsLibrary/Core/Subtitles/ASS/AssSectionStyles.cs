using System;
using System.Collections.Generic;
using System.Text;

namespace AcToolsLibrary.Core.Subtitles.ASS
{
    public class AssSectionStyles
    {
        public static String SECTION_HEADER = "[V4+ Styles]";

        private List<String> _comments = new List<String>();
        private List<AssLineStyle> _styleLines = new List<AssLineStyle>();
        private Dictionary<String, Int32> _fieldIndex = new Dictionary<String, Int32>();

        public List<String> Comments
        {
            get { return _comments; }
        }
        
        public List<AssLineStyle> StyleLines
        {
            get { return _styleLines; }
        }

        public Dictionary<String, Int32> FieldDictionary
        {
            get { return _fieldIndex; }
        }

        public void FallbackToDefaultDictionary()
        {
            //clear the dictionary
            _fieldIndex.Clear();

            //fill with default data
            _fieldIndex.Add("Name", 0);
            _fieldIndex.Add("Fontname", 1);
            _fieldIndex.Add("Fontsize", 2);
            _fieldIndex.Add("PrimaryColour", 3);
            _fieldIndex.Add("SecondaryColour", 4);
            _fieldIndex.Add("OutlineColour", 5);
            _fieldIndex.Add("BackColour", 6);
            _fieldIndex.Add("Bold", 7);
            _fieldIndex.Add("Italic", 8);
            _fieldIndex.Add("Underline", 9);
            _fieldIndex.Add("StrikeOut", 10);
            _fieldIndex.Add("ScaleX", 11);
            _fieldIndex.Add("ScaleY", 12);
            _fieldIndex.Add("Spacing", 13);
            _fieldIndex.Add("Angle", 14);
            _fieldIndex.Add("BorderStyle", 15);
            _fieldIndex.Add("Outline", 16);
            _fieldIndex.Add("Shadow", 17);
            _fieldIndex.Add("Alignment", 18);
            _fieldIndex.Add("MarginL", 19);
            _fieldIndex.Add("MarginR", 20);
            _fieldIndex.Add("MarginV", 21);
            _fieldIndex.Add("Encoding", 22);
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public AssSectionStyles()
        {

        }

    }
}
