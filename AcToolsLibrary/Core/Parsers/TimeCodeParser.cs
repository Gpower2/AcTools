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
    public class TimeCodeParser
    {
        private UInt16 timecodesFileVersion = 0;
        private Decimal assumedFrameRate = 0.0m;

        /// <summary>
        /// 
        /// </summary>
        public UInt16 TimecodesFileVersion
        {
            get { return timecodesFileVersion; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Decimal AssumedFrameRate
        {
            get { return assumedFrameRate; }
        }

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public TimeCodeParser()
        {
        }

        /// <summary>
        /// Function to parse timecodes file
        /// </summary>
        /// <param name="timecodeFile">the path for the timecode file to parse</param>
        /// <param name="vfl">the video frame list to write to</param>
        /// <param name="writeDump">flag whether to write dump file</param>
        public void ParseTimecodes(String timecodeFile, VideoFrameList vfl, Boolean writeDump)
        {
            String curLine = "";
            String prevLine = "";
            bool isV1 = false;
            bool isV2 = false;
            Decimal assumedFps = 0.0m;

            //Open timecodes file
            using (StreamReader reader = new StreamReader(timecodeFile, Encoding.UTF8))
            {
                try
                {
                    //Start timing
                    //Stopwatch timer = new Stopwatch();
                    //timer.Start();
                    //AcLogger.Log("Starting Parsing Timecodes file : " + timecodeFile, AcLogger.AcLogType.Form);

                    //Read timecodes file
                    while ((curLine = reader.ReadLine()) != null)
                    {
                        //Check for comment lines
                        if (curLine.StartsWith("#"))
                        {
                            if (curLine.ToLower().Contains("v1"))
                            {
                                //AcLogger.Log("Version 1 Timecodes File Detected", AcLogger.AcLogType.Form);
                                isV1 = true;
                                timecodesFileVersion = 1;
                            }
                            if (curLine.ToLower().Contains("v2"))
                            {
                                //AcLogger.Log("Version 2 Timecodes File Detected", AcLogger.AcLogType.Form);
                                isV2 = true;
                                timecodesFileVersion = 2;
                            }
                        }
                        //Check for assume line
                        else if (curLine.ToLower().Contains("assume"))
                        {
                            curLine = curLine.ToLower().Replace("assume", "").Replace(" ", "");
                            assumedFps = AcHelper.DecimalParse(curLine);
                            assumedFrameRate = assumedFps;
                            //AcLogger.Log("Assumed FPS : " + assumedFps, AcLogger.AcLogType.Form);
                        }
                        else
                        {
                            //Check for empty line
                            if (String.IsNullOrWhiteSpace(curLine))
                            {
                                //Do nothing
                                continue;
                            }
                            if (isV1)
                            {
                                AnalyseV1(curLine, vfl);
                            }
                            if (isV2)
                            {
                                //First Frame
                                if (String.IsNullOrWhiteSpace(prevLine))
                                {
                                    prevLine = reader.ReadLine();
                                    vfl.Add(AnalyseV2(curLine, prevLine, 0));
                                }
                                //Other Frames
                                else
                                {
                                    vfl.Add(AnalyseV2(prevLine, curLine, vfl.Count));
                                    prevLine = curLine;
                                }
                            }
                        }
                    }
                    //Calculate last frame's FrameInfo data if v2 timecodes
                    if (isV2)
                    {
                        vfl.Add(new VideoFrame() { 
                            FrameNumber = vfl.Count, 
                            FrameStartTime = AcHelper.DecimalParse(prevLine),
                            FrameDuration = vfl.FrameList[vfl.Count - 1].FrameDuration
                        });
                    }
                    //timer.Stop();
                }
                catch (Exception ex)
                {
                    throw (new AcException("Error in reading timecodes file!", ex));
                }
            }

            //AcLogger.Log("Parsing Timecodes finished!", AcLogger.AcLogType.Form);
            //AcLogger.Log("Parsing took : " + timer.Elapsed, AcLogger.AcLogType.Form);
            //AcLogger.Log("Total Frames : " + vfl.Count, AcLogger.AcLogType.Form);

            //Check timecode dump
            if (writeDump)
            {
                try
                {
                    //Write Timecode Dump 
                    StringBuilder dumpBuilder = new StringBuilder();
                    using (StreamWriter writer = new StreamWriter(timecodeFile + ".dmp", false, Encoding.UTF8))
                    {
                        for (int i = 0; i < vfl.Count; i++)
                        {
                            dumpBuilder.AppendFormat("Frame_Number:{0} Frame_Fps:{1} Frame_Duration:{2}\r\n", 
                                vfl.FrameList[i].FrameNumber, vfl.FrameList[i].FrameRate, vfl.FrameList[i].FrameDuration);
                        }
                        writer.Write(dumpBuilder.ToString());
                    }
                }
                catch (Exception ex)
                {
                    throw (new AcException("Error writing timecode dump!", ex));
                }
            }
        }

        /// <summary>
        /// Function to analyse a string line of a v1 timecodes file
        /// </summary>
        /// <param name="frame">string which contains a valid line</param>
        /// <param name="vfl">the video frame list to write to</param>
        private void AnalyseV1(String frame, VideoFrameList vfl)
        {
            //Get elements
            //elements[0] first frame
            //elememts[1] last frame
            //elements[2] framerate
            String[] elements = frame.Split(new String[] { "," }, StringSplitOptions.None);

            //check for valid elements
            if (elements.Length == 3)
            {
                //Calculate FrameInfo data
                int start = Convert.ToInt32(elements[0]);
                int end = Convert.ToInt32(elements[1]);
                for (int i = start; i <= end; i++)
                {
                    VideoFrame tmp = new VideoFrame();
                    tmp.FrameNumber = i;
                    tmp.FrameRate = AcHelper.DecimalParse(elements[2]);
                    
                    if (i == 0)
                    {
                        tmp.FrameStartTime = 0.0m;
                    }
                    else
                    {
                        tmp.FrameStartTime = vfl.FrameList[i - 1].FrameDuration + vfl.FrameList[i - 1].FrameStartTime;
                    }
                    
                    //Add FrameInfo to FrameList
                    vfl.Add(tmp);
                }
            }
            else
            {
                throw (new AcException("Invalid format v1 timecodes!"));
            }
        }

        /// <summary>
        /// Function to analyse data using 2 lines from a v2 timecodes file
        /// </summary>
        /// <param name="frame">
        /// string with the line for the current frame
        /// </param>
        /// <param name="nextFrame">
        /// string with the line the next frame
        /// </param>
        /// <param name="frameNum">
        /// the current frame's number
        /// </param>
        /// <returns>
        /// the VideoFrame structure for the current frame
        /// </returns>
        private VideoFrame AnalyseV2(String frame, String nextFrame, int frameNum)
        {
            //Calculate VideoFrame data
            return new VideoFrame() { 
                FrameNumber = frameNum, 
                FrameStartTime = AcHelper.DecimalParse(frame), 
                FrameDuration = AcHelper.DecimalParse(nextFrame) - AcHelper.DecimalParse(frame) 
            };
        }

        /// <summary>
        /// Calculates a bitmap for a timecodes map according to a video frame list
        /// </summary>
        /// <param name="vfl"></param>
        /// <param name="steps"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Bitmap GetMapBitmap(Int32 picWidth, Int32 picHeight, VideoFrameList vfl, Int32 value)
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
                Decimal currentFramerate = vfl.FrameList[i].FrameRate;
                if (currentFramerate >= 23.0m && currentFramerate <= 24.0m)
                {
                    g.DrawLine(Pens.Blue, currentXPixel, 0, currentXPixel, bmpMap.Height);
                }
                else if (currentFramerate >= 29.0m && currentFramerate <= 30.0m)
                {
                    g.DrawLine(Pens.ForestGreen, currentXPixel, 0, currentXPixel, bmpMap.Height);
                }
                else if (currentFramerate >= 59.0m && currentFramerate <= 60.0m)
                {
                    g.DrawLine(Pens.Orange, currentXPixel, 0, currentXPixel, bmpMap.Height);
                }
                else if (currentFramerate >= 14.0m && currentFramerate <= 16.0m)
                {
                    g.DrawLine(Pens.White, currentXPixel, 0, currentXPixel, bmpMap.Height);
                }
                else
                {
                    g.DrawLine(Pens.Red, currentXPixel, 0, currentXPixel, bmpMap.Height);
                }
                currentXPixel++;
            }

            return bmpMap;
        }
    }
}
