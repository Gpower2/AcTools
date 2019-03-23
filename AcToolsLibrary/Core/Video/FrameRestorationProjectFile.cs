using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using AcToolsLibrary.Core.Video.VideoProviders.AviSynth.VideoSourceProviders;
using AcToolsLibrary.Common;

namespace AcToolsLibrary.Core.Video
{
    public class FrameRestorationProjectFile
    {
        private String videoFile = String.Empty;
        private String aviSynthOutputFile = String.Empty;
        private String timecodesFile = String.Empty;
        private String projectFile = String.Empty;
        public VideoFrameList vfl = new VideoFrameList();
        private Boolean isNew = false;
        private Boolean useFakeTimecodes = false;
        private String avisynthProvider = String.Empty;

        /// <summary>
        /// The video file of the project
        /// </summary>
        public String VideoFile
        {
            get
            {
                return videoFile;
            }
            set
            {
                videoFile = value;
            }
        }

        /// <summary>
        /// The avisynth output file of the project
        /// </summary>
        public String AviSynthOutputFile
        {
            get
            {
                return aviSynthOutputFile;
            }
            set
            {
                aviSynthOutputFile = value;
            }
        }

        /// <summary>
        /// The timecodes file of the video file
        /// </summary>
        public String TimecodesFile
        {
            get
            {
                return timecodesFile;
            }
            set
            {
                timecodesFile = value;
            }
        }

        public String ProjectFile
        {
            get
            {
                return projectFile;
            }
            set
            {
                projectFile = value;
            }
        }

        /// <summary>
        /// Flag that indicates whether the current project
        /// was loaded or created
        /// </summary>
        public Boolean IsNew
        {
            get
            {
                return isNew;
            }
        }

        /// <summary>
        /// Gets the Videoframe list
        /// </summary>
        public VideoFrameList FrameList
        {
            get
            {
                return vfl;
            }
        }

        /// <summary>
        /// Flag that specifies the use of fake timecodes
        /// </summary>
        public Boolean UseFakeTimecodes
        {
            get
            {
                return useFakeTimecodes;
            }
            set
            {
                useFakeTimecodes = value;
            }
        }

        /// <summary>
        /// the avisynth provider for the video
        /// </summary>
        public String AviSynthProvider
        {
            get
            {
                return avisynthProvider;
            }
            set
            {
                avisynthProvider = value;
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public FrameRestorationProjectFile()
        {
        }

        /// <summary>
        /// Constructor with a project file
        /// </summary>
        /// <param name="prFile">The project file</param>
        public FrameRestorationProjectFile(String prFile)
        {
            projectFile = prFile;
            //If project File exists
            if (File.Exists(projectFile))
            {
                //Parse the project
                ParseProject(projectFile);
                isNew = false;
            }
            else
            {
                //If project does not exists, create the project
                File.CreateText(projectFile);
                isNew = true;
            }
        }

        private void ParseProject(String prFile)
        {
            //Open the project file
            StreamReader sr = new StreamReader(prFile, Encoding.UTF8);
            //Start parsing the file
            while (!sr.EndOfStream)
            {
                String line = sr.ReadLine();
                //Check for comments
                if (line.StartsWith("#"))
                {
                    //Ignore line
                    continue;
                }
                //Check for section names
                else if (line.StartsWith("["))
                {
                    //Ignore line
                    continue;
                }
                //Check if it is a proper property
                else if (line.Contains("="))
                {
                    String[] elements = line.Split(new String[] { "=" }, StringSplitOptions.None);
                    if (elements[0].Trim().ToLower() == "usefaketimecodes")
                    {
                        useFakeTimecodes = Int32.Parse(elements[1].Trim()) == 1 ? true : false;
                    }
                    else if (elements[0].Trim().ToLower() == "videofile")
                    {
                        videoFile = elements[1].Trim().Replace("\"", "");
                    }
                    else if (elements[0].Trim().ToLower() == "avisynthoutput")
                    {
                        aviSynthOutputFile = elements[1].Trim().Replace("\"", "");
                    }
                    else if (elements[0].Trim().ToLower() == "timecodesfile")
                    {
                        timecodesFile = elements[1].Trim().Replace("\"", "");
                        //Check for fake timecodes
                        if (!useFakeTimecodes)
                        {
                            //Read the timecodes into the list
                            vfl.LoadTimecodes(timecodesFile, false, 3);
                            //Check if the timecodes were valid
                            if (vfl.Count == 0)
                            {
                                throw new AcException("Error parsing project file! Timecodes file didn't contain any frames!");
                            }
                            //Create a new section
                            VideoFrameSection vfs = new VideoFrameSection("Whole_Video", 0, vfl.Count - 1);
                            vfl.AddSection(vfs);
                        }
                    }
                }
                //Check if it contains a proper frame directive
                else if (line.Contains(":"))
                {
                    String[] elements = line.Split(new String[] { ":" }, StringSplitOptions.None);
                    if (elements[0].Trim().ToLower() == "del")
                    {
                        vfl.FrameSections[0].AddToDelete(vfl.FrameList[Convert.ToInt32(elements[1].Trim().ToLower())]);
                    }
                    else if (elements[0].Trim().ToLower() == "dup")
                    {
                        vfl.FrameSections[0].AddToDuplicate(vfl.FrameList[Convert.ToInt32(elements[1].Trim().ToLower())]);
                    }
                }
            }
            sr.Close();
        }

    }
}
