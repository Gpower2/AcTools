using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using AcToolsLibrary.Common;

namespace AcToolsLibrary.Core.Video.VideoProviders.AviSynth.VideoSourceProviders
{
    public class DGMPGDecProvider : IAviSynthVideoSourceProvider
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public DGMPGDecProvider()
        {
        }

        public void CreateAviSynthScript(String scriptFilename, String videoFilename)
        {
            //Open the file for writing
            using (StreamWriter sw = new StreamWriter(scriptFilename, false, AcHelper.FindEncoding("1253")))
            {
                StringBuilder line = new StringBuilder();
                line.Append(String.Format("DGDecode_MPEG2Source(\"{0}\", info=3)", videoFilename));
                sw.WriteLine(line);
            }
        }

        public void CreateAviSynthScript(String scriptFilename, String videoFilename, Double overrideFramerate)
        {
            //Open the file for writing
            using (StreamWriter sw = new StreamWriter(scriptFilename, false, AcHelper.FindEncoding("1253")))
            {
                StringBuilder line = new StringBuilder();
                line.AppendFormat("DGDecode_MPEG2Source(\"{0}\", info=3)", videoFilename);
                line.AppendLine();
                line.AppendFormat("AssumeFPS({0})", AcHelper.DoubleToString(overrideFramerate, "###.000###"));
                sw.Write(line);
            }
        }

        public string GetOpenFileString(string videoFilename)
        {
            StringBuilder line = new StringBuilder();
            line.Append(String.Format("DGDecode_MPEG2Source(\"{0}\", info=3)", videoFilename));
            return line.ToString();
        }
    }
}
