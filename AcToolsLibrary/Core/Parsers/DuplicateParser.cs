using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using AcToolsLibrary.Common;
using System.Diagnostics;
using AcToolsLibrary.Core.Video;
using System.Globalization;

namespace AcToolsLibrary.Core.Parsers
{
    /// <summary>
    /// 
    /// </summary>
    public class DuplicateParser
    {

        /// <summary>
        /// Function to parse duplicates file
        /// </summary>
        /// <param name="dupFile">
        /// String with the path of the duplicates file
        /// </param>
        public static void ParseDup(String dupFile, VideoFrameList vfl)
        {
            using (StreamReader sr = new StreamReader(dupFile, Encoding.UTF8))
            {
                //Start timing
                //Stopwatch timer = new Stopwatch();
                //timer.Start();
                //AcLogger.Log("Starting Parsing Duplicates file : " + dupFile, AcLogger.AcLogType.Form);

                //Check if FrameList exists
                bool createList = (vfl.Count == 0);

                //Read file
                String line = "";
                Int32 frameNum = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    //Check for first line
                    if (line.ToLowerInvariant().StartsWith("dedup"))
                    {
                        //Do nothing and advance to the next line
                        continue;
                    }
                    //Check for frame difference line
                    else if (line.ToLowerInvariant().StartsWith("frm"))
                    {
                        //Get frame difference
                        String frameDiff = "";
                        int start = line.IndexOf("=");
                        int len = line.IndexOf("%") - start;
                        frameDiff = line.Substring(start + 1, len).Trim();
                        frameDiff = frameDiff.Substring(0, frameDiff.Length - 1);
                        //Check if new frame list
                        if (createList)
                        {
                            //Create new Video frame object
                            VideoFrame tmpFrm = new VideoFrame();
                            tmpFrm.FrameNumber = frameNum;
                            tmpFrm.FrameDifferenceFromPrevious = AcHelper.DecimalParse(frameDiff);
                            //Add it to list
                            vfl.Add(tmpFrm);
                        }
                        else
                        {
                            //Check if frame numbers don't match with the existing list
                            if (frameNum > vfl.Count - 1)
                            {
                                //Invalid dup file
                                throw (new AcException("Invalid Dup File! Frames are inconsistent with existing data!"));
                            }
                            else
                            {
                                //Set the difference
                                vfl.FrameList[frameNum].FrameDifferenceFromPrevious = AcHelper.DecimalParse(frameDiff);
                            }
                        }
                        //Advance frame number counter
                        frameNum++;
                    }
                }

                //timer.Stop();
                //AcLogger.Log("Parsing Timecodes finished!", AcLogger.AcLogType.Form);
                //AcLogger.Log("Total frames : " + frameNum, AcLogger.AcLogType.Form);
                //AcLogger.Log("Parsing took : " + timer.Elapsed, AcLogger.AcLogType.Form);
            }
        }

        public static Bitmap GetMapBitmap(Int32 picWidth, Int32 picHeight, VideoFrameList vfl, Int32 value, Decimal threshold)
        {
            Bitmap bmpMap = new Bitmap(picWidth, picHeight);
            Graphics g = Graphics.FromImage(bmpMap);
            Int32 startFrameNum = value * picWidth;
            Int32 endFrameNum = (value + 1) * picWidth;
            Int32 currentXPixel = 0;
            for (int i = startFrameNum; i < endFrameNum; i++)
            {
                if (i > vfl.Count - 1)
                {
                    g.DrawLine(Pens.Black, currentXPixel, 0, currentXPixel, bmpMap.Height);
                    currentXPixel++;
                    continue;
                }
                if (vfl.FrameList[i].FrameDifferenceFromPrevious <= threshold)
                {
                    g.DrawLine(Pens.Red, currentXPixel, 0, currentXPixel, bmpMap.Height);
                }
                else
                {
                    g.DrawLine(Pens.Blue, currentXPixel, 0, currentXPixel, bmpMap.Height);
                }
                currentXPixel++;
            }
            return bmpMap;
        }
    }
}
