using System;
using System.Collections.Generic;
using System.Text;

namespace AcToolsLibrary.Core.Subtitles.ASS
{
    public class AssSectionFonts
    {
        public static String SECTION_HEADER = "[Fonts]";

        private List<AssLineFont> _fontLines = new List<AssLineFont>();

        public List<AssLineFont> FontLines
        {
            get { return _fontLines; }
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public AssSectionFonts()
        {

        }

    }
}
