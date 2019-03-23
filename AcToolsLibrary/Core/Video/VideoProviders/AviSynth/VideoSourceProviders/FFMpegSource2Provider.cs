using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using AcToolsLibrary.Common;

namespace AcToolsLibrary.Core.Video.VideoProviders.AviSynth.VideoSourceProviders
{
    public class FFMpegSource2Provider : IAviSynthVideoSourceProvider
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public FFMpegSource2Provider()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scriptFilename"></param>
        /// <param name="videoFilename"></param>
        public void CreateAviSynthScript(String scriptFilename, String videoFilename)
        {
            //Open the file for writing
            using (StreamWriter sw = new StreamWriter(scriptFilename, false, AcHelper.FindEncoding("1253")))
            {
                //Write AVS file
                StringBuilder line = new StringBuilder();
                line.Append(String.Format("FFVideoSource(source = \"{0}\", ", videoFilename));
                line.Append(String.Format("track = -1, cache = true, cachefile = \"{0}{1}\", ", videoFilename, ".ffindex"));
                line.Append(String.Format("fpsnum = -1, fpsden = 1, threads = -1, timecodes = \"{0}{1}\", seekmode = 1)",
                    videoFilename, ".tcodes.txt"));
                sw.WriteLine(line);
            }
        }

        public void CreateAviSynthScript(String scriptFilename, String videoFilename, Double overrideFramerate)
        {
            //Open the file for writing
            using (StreamWriter sw = new StreamWriter(scriptFilename, false, AcHelper.FindEncoding("1253")))
            {
                //Write AVS file
                StringBuilder line = new StringBuilder();
                line.Append(String.Format("FFVideoSource(source = \"{0}\", ", videoFilename));
                line.Append(String.Format("track = -1, cache = true, cachefile = \"{0}{1}\", ", videoFilename, ".ffindex"));
                line.Append(String.Format("fpsnum = -1, fpsden = 1, threads = -1, timecodes  =\"{0}{1}\", seekmode = 1)",
                    videoFilename, ".tcodes.txt"));
                line.AppendLine();
                line.AppendFormat("AssumeFPS({0})", AcHelper.DoubleToString(overrideFramerate, "###.000###"));
                sw.Write(line);
            }
        }

        public String GetOpenFileString(String videoFilename)
        {
            StringBuilder line = new StringBuilder();
            line.Append(String.Format("FFVideoSource(source = \"{0}\", ", videoFilename));
            line.Append(String.Format("track = -1, cache = true, cachefile = \"{0}{1}\", ", videoFilename, ".ffindex"));
            line.Append(String.Format("fpsnum = -1, fpsden = 1, threads = -1, timecodes = \"{0}{1}\", seekmode = 1)", 
                videoFilename, ".tcodes.txt"));

            return line.ToString();
        }
    }
}
