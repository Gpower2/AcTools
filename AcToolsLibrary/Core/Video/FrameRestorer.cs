using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using AcToolsLibrary.Common;
using AcToolsLibrary.Core.Video.VideoProviders.AviSynth;

namespace AcToolsLibrary.Core.Video
{
    public class FrameRestorer
    {
        public VideoPlayer vidPlayer;
        public VideoPlayer prevPlayer;
        public FrameRestorationProjectFile frpf;

        /// <summary>
        /// Default constructor
        /// </summary>
        public FrameRestorer()
        {

        }

        public void AddDuplicate(Int32 frameNum)
        {
            frpf.FrameList.FrameSections[0].AddToDuplicate(frpf.FrameList.FrameList[frameNum]);
        }

        public void AddDelete(Int32 frameNum)
        {
            frpf.FrameList.FrameSections[0].AddToDelete(frpf.FrameList.FrameList[frameNum]);
        }

        public void RemoveDuplicate(Int32 frameNum)
        {
            Int32 counter = 0;
            Int32 delIdx = 0;
            for (int i = 0; i < frpf.FrameList.FrameSections[0].FramesToDuplicate.Count; i++)
            {
                if (frpf.FrameList.FrameSections[0].FramesToDuplicate.FrameList[i].FrameNumber == frameNum)
                {
                    counter++;
                    delIdx = i;
                }
            }
            //If the frame was duplicated only once
            //Then change its process type to unprocessed
            if (counter == 1)
            {
                frpf.FrameList.FrameList[frpf.FrameList.FrameSections[0].FramesToDuplicate.FrameList[delIdx].FrameNumber].ProcessType = FrameProcessType.UnProcessed;
            }
            //Delete ONY ONE command at the time
            frpf.FrameList.FrameSections[0].FramesToDuplicate.RemoveAt(delIdx);
            
            return;
        }

        public void RemoveDelete(Int32 frameNum)
        {
            for (int i = 0; i < frpf.FrameList.FrameSections[0].FramesToDelete.Count; i++)
            {
                if (frpf.FrameList.FrameSections[0].FramesToDelete.FrameList[i].FrameNumber == frameNum)
                {
                    //Change the process type to unprocessed
                    frpf.FrameList.FrameList[frpf.FrameList.FrameSections[0].FramesToDelete.FrameList[i].FrameNumber].ProcessType = FrameProcessType.UnProcessed;
                    frpf.FrameList.FrameSections[0].FramesToDelete.RemoveAt(i);
                    return;
                }
            }
        }

        /// <summary>
        /// Write the current project to the file
        /// </summary>
        public void WriteProject()
        {
            StreamWriter sw = new StreamWriter(frpf.ProjectFile, false, Encoding.UTF8);
            StringBuilder sbuilder = new StringBuilder();

            //Write header comments
            sbuilder.AppendLine("#Frame restoration project File");
            sbuilder.AppendLine("#Courtesy of AC Tools");
            sbuilder.AppendLine();

            //Write properties
            sbuilder.AppendLine("[Project Properties]");
            sbuilder.AppendLine(String.Format("VideoFile = \"{0}\"", frpf.VideoFile));
            sbuilder.AppendLine(String.Format("UseFakeTimecodes = {0}", frpf.UseFakeTimecodes ? "1" : "0"));
            sbuilder.AppendLine(String.Format("TimecodesFile = \"{0}\"", frpf.TimecodesFile));
            sbuilder.AppendLine(String.Format("AviSynthOutput = \"{0}\"", frpf.AviSynthOutputFile));
            sbuilder.AppendLine();

            //Write Frame Directives
            sbuilder.AppendLine("[Frame Directives]");
            foreach (VideoFrame vf in frpf.vfl.FrameSections[0].FramesToDelete.FrameList)
            {
                sbuilder.AppendLine(String.Format("Del:{0}", vf.FrameNumber));
            }
            foreach (VideoFrame vf in frpf.vfl.FrameSections[0].FramesToDuplicate.FrameList)
            {
                sbuilder.AppendLine(String.Format("Dup:{0}", vf.FrameNumber));
            }

            sw.Write(sbuilder.ToString());

            //Close the file
            sw.Close();
        }

        /// <summary>
        /// Write the AviSynth Output file
        /// </summary>
        public void WriteAvisynthOutputFile()
        {
            StreamWriter sw = new StreamWriter(frpf.AviSynthOutputFile, false, AcHelper.FindEncoding("1253"));
            StringBuilder sbuilder = new StringBuilder();

            //Write header comments
            sbuilder.AppendLine("#Frame restoration AviSynth File");
            sbuilder.AppendLine("#Courtesy of AC Tools");
            sbuilder.AppendLine();

            //Write open video file
            if (frpf.VideoFile.ToLowerInvariant().EndsWith(".avs"))
            {
                sbuilder.AppendLine(String.Format("original=Import(\"{0}\")", frpf.VideoFile));
                sbuilder.AppendLine();
            }
            else
            {
                AviSynthFileCreator afc = new AviSynthFileCreator();
                sbuilder.AppendLine("original=" + afc.GetAviSynthVideoSourceProvider(vidPlayer.AvisynthVideoProvider).GetOpenFileString(frpf.VideoFile));
                sbuilder.AppendLine();
            }

            //Write the delete and duplicate commands
            sbuilder.AppendLine(frpf.vfl.FrameSections[0].KienzanString());

            //Write the return command
            sbuilder.AppendLine("return Whole_Video");

            sw.Write(sbuilder.ToString());

            sw.Close();
        }


    }
}
