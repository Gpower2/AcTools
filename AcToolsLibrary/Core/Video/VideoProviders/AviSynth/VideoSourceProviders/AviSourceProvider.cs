using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using AcToolsLibrary.Common;

namespace AcToolsLibrary.Core.Video.VideoProviders.AviSynth.VideoSourceProviders
{
    public class AviSourceProvider: IAviSynthVideoSourceProvider
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public AviSourceProvider()
        {
        }

        public void CreateAviSynthScript(String scriptFilename, String videoFilename)
        {
            //Open the file for writing
            using (StreamWriter sw = new StreamWriter(scriptFilename, false, AcHelper.FindEncoding("1253")))
            {
                StringBuilder line = new StringBuilder();
                line.Append(String.Format("AviSource(\"{0}\")", videoFilename));
                sw.WriteLine(line);
            }
        }

        public void CreateAviSynthScript(String scriptFilename, String videoFilename, Double overrideFramerate)
        {
            //Open the file for writing
            using (StreamWriter sw = new StreamWriter(scriptFilename, false, AcHelper.FindEncoding("1253")))
            {
                StringBuilder line = new StringBuilder();
                line.AppendFormat("AviSource(\"{0}\")", videoFilename);
                line.AppendLine();
                line.AppendFormat("AssumeFPS({0})", AcHelper.DoubleToString(overrideFramerate, "###.000###"));
                sw.Write(line);
            }
        }

        public String GetOpenFileString(String videoFilename)
        {
            StringBuilder line = new StringBuilder();
            line.AppendFormat("AviSource(\"{0}\")", videoFilename);
            line.AppendLine();
            return line.ToString();
        }

    }
}
