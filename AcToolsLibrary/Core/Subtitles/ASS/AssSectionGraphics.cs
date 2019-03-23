using System;
using System.Collections.Generic;
using System.Text;

namespace AcToolsLibrary.Core.Subtitles.ASS
{
    public class AssSectionGraphics
    {
        public static String SECTION_HEADER = "[Fonts]";

        private List<AssLineGraphic> _graphicLines = new List<AssLineGraphic>();

        public List<AssLineGraphic> GraphicLines
        {
            get { return _graphicLines; }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public AssSectionGraphics()
        {

        }

    }
}
