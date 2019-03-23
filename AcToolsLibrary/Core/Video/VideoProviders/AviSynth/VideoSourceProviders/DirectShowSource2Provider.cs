using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using AcToolsLibrary.Common;

namespace AcToolsLibrary.Core.Video.VideoProviders.AviSynth.VideoSourceProviders
{
    public class DirectShowSource2Provider : IAviSynthVideoSourceProvider
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public DirectShowSource2Provider()
        {
        }

        public void CreateAviSynthScript(String scriptFilename, String videoFilename)
        {
            //Open the file for writing
            using (StreamWriter sw = new StreamWriter(scriptFilename, false, AcHelper.FindEncoding("1253")))
            {
                StringBuilder line = new StringBuilder();
                line.Append(String.Format("dss2(\"{0}\")", videoFilename));
                sw.WriteLine(line);
            }
        }

        public void CreateAviSynthScript(String scriptFilename, String videoFilename, Double overrideFramerate)
        {
            //Open the file for writing
            using (StreamWriter sw = new StreamWriter(scriptFilename, false, AcHelper.FindEncoding("1253")))
            {
                StringBuilder line = new StringBuilder();
                line.AppendFormat("dss2(\"{0}\")", videoFilename);
                line.AppendLine();
                line.AppendFormat("AssumeFPS({0})", AcHelper.DoubleToString(overrideFramerate, "###.000###"));
                sw.Write(line);
            }
        }

        public string GetOpenFileString(string videoFilename)
        {
            StringBuilder line = new StringBuilder();
            line.Append(String.Format("dss2(\"{0}\")", videoFilename));
            return line.ToString();
        }
    }
}
