using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using AcToolsLibrary.Common;
using AcToolsLibrary.Core.Video;
using System.Diagnostics;

namespace AcToolsLibrary.Core.Parsers
{
    public class SectionParser
    {

        /// <summary>
        /// Function to parse the trims file
        /// </summary>
        /// <param name="sectionsFile">
        /// String with the path of the trims file
        /// </param>
        public static void ParseSections(String sectionsFile, VideoFrameList vfl)
        {
            StreamReader sr;
            String line = "";

            try
            {
                //Open trims file
                sr = new StreamReader(sectionsFile, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                throw (new AcException("Error opening trims file!", ex));
            }

            try
            {
                //Read file
                while ((line = sr.ReadLine()) != null)
                {
                    //Check for Avisynth style trims
                    if (line.ToLowerInvariant().Contains("trim") && !(line.StartsWith("#")))
                    {
                        String tmp = line.ToLowerInvariant().Substring(line.IndexOf("trim", StringComparison.InvariantCultureIgnoreCase));
                        tmp = tmp.ToLowerInvariant().Substring(tmp.IndexOf("(") + 1);
                        tmp = tmp.Substring(0, tmp.IndexOf(")"));
                        tmp = tmp.Trim();
                        VideoFrameSection vfsTmp = new VideoFrameSection();
                        if (line.Contains("="))
                        {
                            vfsTmp.SectionName = line.Substring(0, line.IndexOf("=")).Trim();
                        }
                        String[] elements = tmp.Split(new String[] { "," }, StringSplitOptions.None);
                        //Check trim's form
                        //1. trim(clip,start,end)
                        //2. trim(start,end)
                        if (elements.Length == 3)
                        {
                            vfsTmp.FrameStart = Convert.ToInt32(elements[1].Trim());
                            vfsTmp.FrameEnd = Convert.ToInt32(elements[2].Trim());
                            vfl.FrameSections.Add(vfsTmp);
                        }
                        else if (elements.Length == 2)
                        {
                            vfsTmp.FrameStart = Convert.ToInt32(elements[0].Trim());
                            vfsTmp.FrameEnd = Convert.ToInt32(elements[1].Trim());
                            vfl.FrameSections.Add(vfsTmp);
                        }
                        else
                        {
                            //No valid format found, write to debug
                            //AcLogger.Log(new AcException("Invalid Trim format!"), AcLogger.AcLogType.Form);
                        }
                    }
                    //Check for simple text trims
                    else if (line.Contains(",") || line.Contains("-"))
                    {
                        try
                        {
                            //Check if starts with number
                            Int32 chkTmp = 0;
                            if (Int32.TryParse(line.Substring(0, 1), out chkTmp))
                            {
                                //if starts with number check if it contains comments (#)
                                if (line.Contains("#"))
                                {
                                    line = line.Substring(0, line.IndexOf("#"));
                                    line = line.Trim();
                                }
                                VideoFrameSection vfsTmp = new VideoFrameSection();
                                String[] elements = new String[] { "" };
                                if (line.Contains(","))
                                {
                                    elements = line.Split(new String[] { "," }, StringSplitOptions.None);
                                }
                                else if (line.Contains("-"))
                                {
                                    elements = line.Split(new String[] { "-" }, StringSplitOptions.None);
                                }
                                //Check trim's form
                                //1. trim(clip,start,end)
                                //2. trim(start,end)
                                if (elements.Length == 3)
                                {
                                    vfsTmp.FrameStart = Convert.ToInt32(elements[1].Trim());
                                    vfsTmp.FrameEnd = Convert.ToInt32(elements[2].Trim());
                                    vfl.FrameSections.Add(vfsTmp);
                                }
                                else if (elements.Length == 2)
                                {
                                    vfsTmp.FrameStart = Convert.ToInt32(elements[0].Trim());
                                    vfsTmp.FrameEnd = Convert.ToInt32(elements[1].Trim());
                                    vfl.FrameSections.Add(vfsTmp);
                                }
                                else
                                {
                                    //No valid format found, write to debug
                                    //AcLogger.Log(new AcException("Invalid Trim format!"), AcLogger.AcLogType.Form);
                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex);
                            //No valid format found, write to debug
                            //AcLogger.Log(new AcException("Invalid Trim format!", ex), AcLogger.AcLogType.Form);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                sr.Close();
                throw (new AcException("Error in reading trims file!", ex));
            }

            try
            {
                //Close File
                sr.Close();
            }
            catch (Exception ex)
            {
                throw (new AcException("Error in closing trims file!", ex));
            }

        }

        /// <summary>
        /// Write a section file from a Video frame list
        /// </summary>
        /// <param name="vfl">The video frame list that contains the sections to be written</param>
        /// <param name="filename">the section file name</param>
        public static void WriteSections(VideoFrameList vfl, String filename)
        {
            StreamWriter sw = new StreamWriter(filename, false, AcHelper.FindEncoding("1253"));
            foreach (VideoFrameSection vfs in vfl.FrameSections)
            {
                sw.WriteLine(vfs.StringForFile());
            }
            sw.Close();
        }

    }
}
