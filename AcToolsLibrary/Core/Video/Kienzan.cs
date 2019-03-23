using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Globalization;
using System.Xml;
using System.Xml.Serialization;

using AcToolsLibrary.Common;
using AcToolsLibrary.Core.Audio;
using AcToolsLibrary.Core.Video.VideoProviders.AviSynth;

namespace AcToolsLibrary.Core.Video
{
    public class Kienzan : IDisposable
    {
        private VideoFrameList _VideoFrameList = new VideoFrameList();
        private String _OriginalVideoFile = "";
        private String _TimecodesFile = "";
        private String _DuplicatesFile = "";
        private String _SectionsFile = "";
        private Double _CurrentProgress = 0.0;
        private Decimal _TargetFramerate = 0.0m;
        private Boolean _CancelThread = false;
        private Boolean _Failed = false;
        private Exception _ThreadedException = null;

        public Boolean HasTimecodes { get { return _VideoFrameList.HasTimecodes; } }

        public Boolean HasDuplicates { get { return _VideoFrameList.HasDuplicates; } }

        public Boolean HasSections { get { return _VideoFrameList.CountSections > 0; } }

        public String TimecodesFile { get { return _TimecodesFile; } }

        public String DuplicatesFile { get { return _DuplicatesFile; } }

        public String SectionsFile { get { return _SectionsFile; } }

        public Double Progress { get { return _CurrentProgress; } }

        public String VideoFile
        {
            get { return _OriginalVideoFile; }
            set { _OriginalVideoFile = value; }
        }

        public Decimal TargetFramerate
        {
            get { return _TargetFramerate; }
            set { _TargetFramerate = value; }
        }

        public Boolean CancelThread
        {
            get { return _CancelThread; }
            set { _CancelThread = value; }
        }

        public Boolean Failed { get { return _Failed; } }

        public VideoFrameList VideoFrames { get { return _VideoFrameList; } }

        public Exception ThreadedException { get { return _ThreadedException; } }

        public Kienzan() { }

        public void Dispose()
        {
            _VideoFrameList.ClearSections();
            _VideoFrameList.ClearStats();
            _VideoFrameList.Clear();
        }

        public void LoadTimecodesThreaded(Object argTimecodesFilenameObj)
        {
            try
            {
                _ThreadedException = null;
                //Cast the object                
                LoadTimecodes((String)argTimecodesFilenameObj);
            }
            catch (Exception ex)
            {
                _ThreadedException = ex;
            }
        }

        public void LoadTimecodes(String argTimecodesFilename)
        {
            try
            {
                _Failed = false;
                //Load the Timecodes
                _VideoFrameList.LoadTimecodes(argTimecodesFilename, false, 3);
                _TimecodesFile = argTimecodesFilename;
            }
            catch (Exception)
            {
                _Failed = true;
                throw;
            }
        }

        public void LoadDuplicatesThreaded(Object argDuplicatesFilenameObj)
        {
            try
            {
                _ThreadedException = null;
                //Cast the object
                LoadDuplicates((String)argDuplicatesFilenameObj);
            }
            catch (Exception ex)
            {
                _ThreadedException = ex;
            }
        }

        public void LoadDuplicates(String argDuplicatesFilename)
        {
            try
            {
                _Failed = false;
                //Load the duplicates
                _VideoFrameList.LoadDuplicates(argDuplicatesFilename);
                _DuplicatesFile = argDuplicatesFilename;
            }
            catch (Exception)
            {
                _Failed = true;
                throw;
            }
        }

        public void LoadSectionsThreaded(Object argSectionsFilenameObj)
        {
            try
            {
                _ThreadedException = null;
                //Cast the object
                LoadSections((String)argSectionsFilenameObj);
            }
            catch (Exception ex)
            {
                _ThreadedException = ex;
            }
        }

        public void LoadSections(String argSectionsFilename)
        {
            try
            {
                _Failed = false;
                //Load the sections
                _VideoFrameList.LoadSections(argSectionsFilename);
                _SectionsFile = argSectionsFilename;
            }
            catch (Exception)
            {
                _Failed = true;
                throw;
            }
        }

        public void CreateCoolEditScriptThreaded(Object argCoolEditOutputFilenameObj)
        {
            try
            {
                _ThreadedException = null;
                CreateCoolEditScript((String)argCoolEditOutputFilenameObj);
            }
            catch (Exception ex)
            {
                _ThreadedException = ex;
            }
        }

        public void CreateCoolEditScript(String argCoolEditOutputFilename)
        {
            try
            {
                _Failed = false;
                StringBuilder scriptBuilder = new StringBuilder();
                //Write Header
                scriptBuilder.AppendLine("Collection: AcTools Kienzan Kai");
                scriptBuilder.AppendLine("Title: Cut Sections");
                scriptBuilder.AppendLine("Description: Cut Sections");
                scriptBuilder.AppendLine("Mode: 2");
                scriptBuilder.AppendLine();
                List<VideoFrameSection> CutFrames = new List<VideoFrameSection>();

                Int32 sectionCounter = 0;

                //Find which frame sections to cut
                foreach (VideoFrameSection vfs in _VideoFrameList.FrameSections)
                {
                    //If First frame section
                    if (sectionCounter == 0)
                    {
                        if (vfs.FrameStart != 0)
                        {
                            VideoFrameSection t = new VideoFrameSection();
                            t.FrameStart = 0;
                            t.FrameEnd = vfs.FrameStart;
                            CutFrames.Add(t);
                        }
                    }
                    //If last frame section
                    else if (sectionCounter == (_VideoFrameList.CountSections - 1))
                    {
                        if (vfs.FrameEnd != 0 || vfs.FrameEnd != _VideoFrameList.Count)
                        {
                            VideoFrameSection t = new VideoFrameSection();
                            t.FrameStart = vfs.FrameEnd + 1;
                            t.FrameEnd = _VideoFrameList.Count - 1;
                            CutFrames.Add(t);
                        }
                    }
                    else
                    {
                        if (vfs.FrameStart != (_VideoFrameList.FrameSections[sectionCounter - 1].FrameEnd + 1))
                        {
                            VideoFrameSection t = new VideoFrameSection();
                            t.FrameStart = _VideoFrameList.FrameSections[sectionCounter - 1].FrameEnd + 1;
                            t.FrameEnd = vfs.FrameStart;
                            CutFrames.Add(t);
                        }
                    }
                    //Increase the counter
                    sectionCounter++;
                }
                scriptBuilder.AppendFormat("Selected: none at 0 scaled {0} SR 48000", Convert.ToInt32(Math.Ceiling(_VideoFrameList.FrameList[_VideoFrameList.FrameList.Count - 1].FrameEndTime * 48.0m)));
                scriptBuilder.AppendLine();
                scriptBuilder.AppendLine("Freq: Off");
                scriptBuilder.AppendLine("cmd: Channel Both");
                scriptBuilder.AppendLine();

                //Write the script, starting with reverse order
                for (int i = CutFrames.Count - 1; i >= 0; i--)
                {
                    int FrameSampleStart, FrameSampleEnd;

                    FrameSampleStart = Convert.ToInt32(_VideoFrameList.FrameList[CutFrames[i].FrameStart].FrameStartTime * 48m);
                    FrameSampleEnd = Convert.ToInt32(_VideoFrameList.FrameList[CutFrames[i].FrameEnd].FrameEndTime * 48m);

                    scriptBuilder.AppendFormat("Selected: {0} to {1} SR 48000\r\n", FrameSampleStart, FrameSampleEnd);
                    scriptBuilder.AppendLine("Freq: Off");
                    scriptBuilder.AppendLine("cmd: Delete");
                    scriptBuilder.AppendLine();
                }

                scriptBuilder.AppendLine("Freq: Off");
                scriptBuilder.AppendLine("End:");

                using (StreamWriter writer = new StreamWriter(argCoolEditOutputFilename, false, Encoding.UTF8))
                {
                    writer.Write(scriptBuilder);
                }
            }
            catch (Exception)
            {
                _Failed = true;
                throw;
            }
        }

        public void CreateMeGUIScriptThreaded(Object argMeGUIOutputScriptObj)
        {
            try
            {
                _ThreadedException = null;
                //Cast the object
                CreateMeGUIScript((String)argMeGUIOutputScriptObj);
            }
            catch (Exception ex)
            {
                _ThreadedException = ex;
            }
        }

        public void CreateMeGUIScript(String argMeGUIOutputScript)
        {
            try
            {
                _Failed = false;
                //Create a new MeGUI Cuts Object
                MeguiCuts mcuts = new MeguiCuts();

                mcuts.Style = TransitionStyle.NO_TRANSITION;
                mcuts.Framerate = _TargetFramerate;

                //Sort the sections
                //vfl.FrameSections.Sort( ;

                CutSection sectionToAdd = null;

                for (Int32 i = 0; i < _VideoFrameList.FrameSections.Count; i++)
                {
                    //If no section exists, create a new one
                    if (sectionToAdd == null)
                    {
                        sectionToAdd = new CutSection();
                    }
                    //Check if no start frame is declared
                    if (sectionToAdd.startFrame == -1)
                    {
                        sectionToAdd.startFrame = _VideoFrameList.FrameSections[i].FrameStart;
                    }
                    //Check if we are at the last section
                    if (i == _VideoFrameList.FrameSections.Count - 1)
                    {
                        sectionToAdd.endFrame = _VideoFrameList.FrameSections[i].FrameEnd;
                        mcuts.AllCuts.Add(sectionToAdd);
                        sectionToAdd = null;
                        continue;
                    }
                    else
                    {
                        //Check next section's first frame
                        //1. if it is the same frame with this section's last frame
                        //2. if it is the next frame of this section's last frame
                        if (_VideoFrameList.FrameSections[i + 1].FrameStart == _VideoFrameList.FrameSections[i].FrameEnd ||
                            _VideoFrameList.FrameSections[i + 1].FrameStart == _VideoFrameList.FrameSections[i].FrameEnd + 1)
                        {
                            continue;
                        }
                        else
                        {
                            sectionToAdd.endFrame = _VideoFrameList.FrameSections[i].FrameEnd;
                            mcuts.AllCuts.Add(sectionToAdd);
                            sectionToAdd = null;
                            continue;
                        }
                    }
                }

                using (TextWriter textWriter = new StreamWriter(argMeGUIOutputScript, false, Encoding.UTF8))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(MeguiCuts));
                    serializer.Serialize(textWriter, mcuts);
                }
            }
            catch (Exception)
            {
                _Failed = true;
                throw;
            }
        }

        public void GenerateDuplicatesThreaded(Object argVideoFilenameObj)
        {
            try
            {
                _ThreadedException = null;
                //Cast the object
                GenerateDuplicates((String)argVideoFilenameObj);
            }
            catch (Exception ex)
            {
                _ThreadedException = ex;
            }
        }

        public void GenerateDuplicates(String argVideoFilename)
        {
            try
            {
                _Failed = false;
                //Define the filenames
                String dupAvsFile = AcHelper.GetLastUnusedFilename(argVideoFilename, "dup.avs", 3);
                String ffindexFile = AcHelper.GetFilename(dupAvsFile, GetFileNameMode.FilenameWithoutExtension, GetDirectoryNameMode.FullPath) + ".ffindex";
                String timecodesFile = AcHelper.GetFilename(dupAvsFile, GetFileNameMode.FilenameWithoutExtension, GetDirectoryNameMode.FullPath) + ".tc.txt";
                String dupFile = AcHelper.GetFilename(dupAvsFile, GetFileNameMode.FilenameWithoutExtension, GetDirectoryNameMode.FullPath) + ".txt";

                StringBuilder sb = new StringBuilder();

                sb.AppendFormat("FFVideoSource(source = \"{0}\", track = -1, cache = true, ", argVideoFilename);
                sb.AppendFormat("cachefile = \"{0}\", fpsnum = -1, fpsden = 1, threads = -1, ", ffindexFile);
                sb.AppendFormat("timecodes = \"{0}\", seekmode = 1)", timecodesFile);
                sb.AppendLine();

                sb.AppendFormat("DupMC(log = \"{0}\")", dupFile);
                sb.AppendLine();

                //Create the avs file
                using (StreamWriter sw = new StreamWriter(dupAvsFile, false, AcHelper.FindEncoding("1253")))
                {
                    sw.Write(sb.ToString());
                }

                //Open the avs dup file
                AvsFile avs = AvsFile.OpenScriptFile(dupAvsFile);

                try
                {
                    //Find total frames
                    Int32 totalFrames = avs.Clip.NumberOfFrames;

                    //Query all frames
                    for (int i = 0; i < totalFrames; i++)
                    {
                        if (!_CancelThread)
                        {
                            avs.GetVideoReader().QuickReadBitmap(i);
                            _CurrentProgress = Convert.ToDouble(i) / Convert.ToDouble(totalFrames) * 100.0;
                        }
                        else
                        {
                            _CancelThread = false;
                            break;
                        }
                    }
                    avs.Dispose();
                }
                finally
                {
                    if (avs != null)
                    {
                        avs.Dispose();
                    }
                    //sets the generated dup file
                    _DuplicatesFile = dupFile;
                    //reset progress
                    _CurrentProgress = 0.0;
                }
            }
            catch (Exception)
            {
                _Failed = true;
                throw;
            }
        }

        public void GenerateTimecodesThreaded(Object videoFileObj)
        {
            try
            {
                _Failed = false;
                _ThreadedException = null;
                //Cast the object
                GenerateTimecodes((String)videoFileObj);
            }
            catch (Exception ex)
            {
                _Failed = true;
                _ThreadedException = ex;
            }
        }

        public void GenerateTimecodes(String videoFile)
        {
            //Define the filenames
            String tcAvsFile = AcHelper.GetLastUnusedFilename(videoFile, "tc.avs", 3);
            String ffindexFile = AcHelper.GetFilename(tcAvsFile, GetFileNameMode.FilenameWithoutExtension, GetDirectoryNameMode.FullPath) + ".ffindex";
            String tcFile = AcHelper.GetFilename(tcAvsFile, GetFileNameMode.FilenameWithoutExtension, GetDirectoryNameMode.FullPath) + ".tc.txt";

            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("FFVideoSource(source = \"{0}\", track = -1, cache = true, ", videoFile);
            sb.AppendFormat("cachefile = \"{0}\", fpsnum = -1, fpsden = 1, threads = -1, ", ffindexFile);
            sb.AppendFormat("timecodes = \"{0}\", seekmode = 1)", tcFile);
            sb.AppendLine();

            //Create the avs file
            using (StreamWriter sw = new StreamWriter(tcAvsFile, false, AcHelper.FindEncoding("1253")))
            {
                //Write to file
                sw.WriteLine(sb.ToString());
            }

            AvsFile avsFile = null;
            try
            {
                //Open the avs timecodes file
                avsFile = AvsFile.OpenScriptFile(tcAvsFile);
            }
            finally
            {
                //Dispose the file
                if (avsFile != null)
                {
                    avsFile.Dispose();
                }
                //return the generated dup file
                _TimecodesFile = tcFile;
            }
        }

        public void RunNewKienzanThreaded(Object targetFramerateObj)
        {
            try
            {
                _Failed = false;
                _ThreadedException = null;
                //Cast the object (target framerate in frames/sec)
                RunNewKienzan((Decimal)targetFramerateObj);
            }
            catch (Exception ex)
            {
                _Failed = true;
                _ThreadedException = ex;
            }
        }

        public void RunNewKienzan(Decimal targetFramerate)
        {
            //Calculate target duration
            Decimal targetDuration = 1000.0m / targetFramerate;

            //Define maximum frame range 
            Int32 maxFrameRound = 5;
            //Check for sections
            if (_VideoFrameList.CountSections < 1)
            {
                //If no section, create a dummy section for the whole video
                VideoFrameSection vfs = new VideoFrameSection();
                vfs.FrameStart = 0;
                vfs.FrameEnd = _VideoFrameList.Count - 1;
                vfs.SectionName = "Whole_Video";
                _VideoFrameList.AddSection(vfs);
            }

            Int32 sectionCounter = 0;
            Decimal frameGlitch = 0.0m;
            Decimal frameSectionGlitch = 0.0m;

            //Loop for every section
            foreach (VideoFrameSection vfs in _VideoFrameList.FrameSections)
            {
                //Reset data
                vfs.ClearToDelete();
                vfs.ClearToDuplicate();

                //Declare needed variables
                Int32 currentSectionFrame = 0;
                Decimal timeToremove = _VideoFrameList.FrameList[vfs.FrameStart].FrameStartTime;
                Int32 gatherStartFrame = vfs.FrameStart;
                Int32 gatherEndFrame = vfs.FrameEnd;

                Decimal currentCheckTime = 0.0m;
                Decimal currentShouldBeTime = 0.0m;

                //Check Section Name
                if (vfs.SectionName == "")
                {
                    //If no name, set a default
                    vfs.SectionName = "Section" + (sectionCounter + 1).ToString();
                }

                //Loop for all the frames in the section
                for (int i = vfs.FrameStart; i <= vfs.FrameEnd; i++)
                {
                    //Increase the current frame counter
                    currentSectionFrame++;

                    //Check the current time with the should be time
                    currentCheckTime = (_VideoFrameList.FrameList[i].FrameEndTime - timeToremove);
                    //currentCheckTime += vfs.TotalCutTime();
                    //currentCheckTime -= vfs.TotalAddTime();

                    currentShouldBeTime = (currentSectionFrame - vfs.CountToDelete + vfs.CountToDuplicate) * targetDuration;

                    frameGlitch = (currentCheckTime - currentShouldBeTime) / targetDuration;
                    frameGlitch += frameSectionGlitch;

                    //Check if nothing happens
                    if (frameGlitch > -1.0m && frameGlitch < 1.0m)
                    {
                        continue;
                    }
                    else
                    {
                        //Check if frames need to be deleted
                        if (frameGlitch <= -1.0m)
                        {
                            gatherEndFrame = i;
                            //Check frame range
                            if (gatherEndFrame - gatherStartFrame > maxFrameRound)
                            {
                                gatherStartFrame = gatherEndFrame - maxFrameRound;
                            }
                            Int32 roundCutFrames = -Convert.ToInt32(Math.Ceiling(frameGlitch));
                            //Cut the frames
                            //Update frame section glitch
                            frameSectionGlitch = frameGlitch + CutFramesNew(vfs, gatherStartFrame, gatherEndFrame, roundCutFrames);
                        }
                        //Check if frames need to be added
                        else if (frameGlitch >= 1.0m)
                        {
                            gatherEndFrame = i;
                            //Check frame range
                            if (gatherEndFrame - gatherStartFrame > maxFrameRound)
                            {
                                gatherStartFrame = gatherEndFrame - maxFrameRound;
                            }
                            Int32 roundAddFrames = Convert.ToInt32(Math.Floor(frameGlitch));
                            //Add the frames
                            //Update frame section glitch
                            frameSectionGlitch = frameGlitch - AddFramesNew(vfs, gatherStartFrame, gatherEndFrame, roundAddFrames);
                        }

                        //Set the gather start frame
                        if (i + 1 > vfs.FrameEnd)
                        {
                            gatherStartFrame = vfs.FrameEnd;
                        }
                        else
                        {
                            gatherStartFrame = i + 1;
                        }
                    }

                }//End of the frame loop

                //Increase the section counter
                sectionCounter++;

                //Set the frame Section Glitch
                frameSectionGlitch = frameGlitch;

            }//End of the section loop

            //Create the final avs file
            String finalAvsFile = AcHelper.GetFilename(_TimecodesFile, GetFileNameMode.FilenameWithoutExtension, GetDirectoryNameMode.FullPath);
            finalAvsFile = AcHelper.GetLastUnusedFilename(finalAvsFile, "kienzan.avs", 3);

            //Define the filenames
            String ffindexFile = String.Format("{0}.ffindex", AcHelper.GetFilename(finalAvsFile, GetFileNameMode.FilenameWithoutExtension, GetDirectoryNameMode.FullPath));
            String tcFile = String.Format("{0}.tc.txt", AcHelper.GetFilename(finalAvsFile, GetFileNameMode.FilenameWithoutExtension, GetDirectoryNameMode.FullPath));

            StringBuilder sb = new StringBuilder();

            //Write the header
            sb.AppendLine("#Script generated by New Kienzan Kai (Courtesy of AC Tools)");
            sb.AppendLine();
            sb.AppendLine();

            //Write the video provider
            sb.AppendFormat("original = FFVideoSource(source = \"{0}\", track = -1, cache = true, ", _OriginalVideoFile);
            sb.AppendFormat("cachefile = \"{0}\", fpsnum = -1, fpsden = 1, threads = -1, ", ffindexFile);
            sb.AppendFormat("timecodes = \"{0}\", seekmode = 1)", tcFile);
            sb.AppendLine();

            //Assume framerate
            sb.AppendFormat("original = AssumeFPS(original, {0}, false)", AcHelper.DecimalToString(targetFramerate, "##0.000###"));
            sb.AppendLine();
            sb.AppendLine();

            //Write the delete and duplicate frame
            //for each section
            foreach (VideoFrameSection vfs in _VideoFrameList.FrameSections)
            {
                sb.AppendLine(vfs.KienzanString());
            }
            sb.AppendLine();

            //Write the last line to concat the sections
            sb.AppendFormat("last = ");
            for (int i = 0; i < _VideoFrameList.FrameSections.Count; i++)
            {
                if (i == 0)
                {
                    sb.AppendFormat("{0}", _VideoFrameList.FrameSections[i].SectionName);
                }
                else
                {
                    sb.AppendFormat(" + {0}", _VideoFrameList.FrameSections[i].SectionName);
                }
            }
            sb.AppendLine();

            //Write the return statement
            sb.AppendFormat("return last");

            //Create the avs file
            using (StreamWriter sw = new StreamWriter(finalAvsFile, false, AcHelper.FindEncoding("1253")))
            {
                //Write the final String
                sw.Write(sb.ToString());
            }
        }

        private Int32 AddFramesNew(VideoFrameSection vfs, Int32 startFrame, Int32 endFrame, Int32 addFrames)
        {
            VideoFrameList list = _VideoFrameList.CopyList(startFrame, endFrame);

            // if the list is CFR then sort by frame numer, else by frame difference
            if (!list.IsCFR)
            {
                //Sort the first addFrames by frame number
                list.Sort(VideoFrameList.SortType.ByFrameNumber, VideoFrameList.SortOrder.Ascending);
            }
            else
            {
                //Sort all frames by difference
                list.Sort(VideoFrameList.SortType.ByFrameDifference, VideoFrameList.SortOrder.Ascending);
            }

            //Sort all the frames by duration
            list.Sort(VideoFrameList.SortType.ByDuration, VideoFrameList.SortOrder.Descending);

            if (addFrames > endFrame - startFrame + 1)
            {
                Int32 framesDuppedCounter = 0;
                while (framesDuppedCounter < addFrames)
                {
                    foreach (VideoFrame vf in list.FrameList)
                    {
                        vfs.AddToDuplicate(vf);
                        framesDuppedCounter++;
                    }
                }
                return addFrames;
                //return list.Count;
            }
            else
            {
                //Add the first addframes to the video section
                for (int i = 0; i < addFrames; i++)
                {
                    vfs.AddToDuplicate(list.FrameList[i]);
                }
                return addFrames;
            }
        }

        private Int32 CutFramesNew(VideoFrameSection vfs, Int32 startFrame, Int32 endFrame, Int32 cutFrames)
        {
            //Create a temporary list
            VideoFrameList list = _VideoFrameList.CopyList(startFrame, endFrame);

            // if the list is CFR then sort by frame numer, else by frame difference
            if (list.IsCFR)
            {
                //Sort the first cutFrames by frame number
                list.Sort(VideoFrameList.SortType.ByFrameNumber, VideoFrameList.SortOrder.Ascending);
            }
            else
            {
                //Sort all frames by difference
                list.Sort(VideoFrameList.SortType.ByFrameDifference, VideoFrameList.SortOrder.Ascending);
            }

            //Sort all the frames by duration
            list.Sort(VideoFrameList.SortType.ByDuration, VideoFrameList.SortOrder.Descending);

            if (cutFrames > endFrame - startFrame + 1)
            {
                foreach (VideoFrame vf in list.FrameList)
                {
                    vfs.AddToDelete(vf);
                }
                return list.Count;
            }
            else
            {
                //Add the first cutFrames to the video section
                for (int i = 0; i < cutFrames; i++)
                {
                    vfs.AddToDelete(list.FrameList[i]);
                }
                return cutFrames;
            }
        }

        public void RunKienzanThreaded(Object targetFramerateObj)
        {
            try
            {
                _Failed = false;
                _ThreadedException = null;
                //Cast the object (target framerate in frames/sec)
                RunKienzan((Decimal)targetFramerateObj);
            }
            catch (Exception ex)
            {
                _Failed = true;
                _ThreadedException = ex;
            }
        }

        public void RunKienzan(Decimal targetFramerate)
        {
            //The time in ms to gather frames
            Decimal timeGatheredThreshold = 1000.0m;
            //The frames gathered threshold
            Decimal framesGatheredThreshold = targetFramerate;

            //Specify special framerates
            if (targetFramerate == 23.976m)
            {
                timeGatheredThreshold = 1001.0m;
                framesGatheredThreshold = 24.0m;
            }
            else if (targetFramerate == 29.97m)
            {
                timeGatheredThreshold = 1001.0m;
                framesGatheredThreshold = 30.0m;
            }

            //Check for sections
            if (_VideoFrameList.CountSections < 1)
            {
                //If no section, create a dummy section for the whole video
                VideoFrameSection vfs = new VideoFrameSection();
                vfs.FrameStart = 0;
                vfs.FrameEnd = _VideoFrameList.Count - 1;
                vfs.SectionName = "Whole_Video";
                _VideoFrameList.AddSection(vfs);
            }

            Int32 sectionCounter = 0;

            //Loop for every section
            foreach (VideoFrameSection vfs in _VideoFrameList.FrameSections)
            {
                //Clear tha list of the frames
                vfs.ClearToDelete();
                vfs.ClearToDuplicate();

                Decimal timeGathered = 0.0m;
                Int32 framesGathered = 0;
                Int32 totalFramesToCut = 0;
                Int32 totalFramesToAdd = 0;
                Int32 gatherStartFrame = vfs.FrameStart;
                Int32 gatherEndFrame = vfs.FrameEnd;

                //Check Section Name
                if (vfs.SectionName == "")
                {
                    //If no name, set a default
                    vfs.SectionName = "Section" + (sectionCounter + 1).ToString();
                }

                //Loop for all the frames in the section
                for (int i = vfs.FrameStart; i <= vfs.FrameEnd; i++)
                {
                    //Gather time
                    timeGathered += _VideoFrameList.FrameList[i].FrameDuration;
                    //Gather frames
                    framesGathered++;

                    //Check if we gathered enough time
                    if (timeGathered >= timeGatheredThreshold)
                    {
                        Int32 roundCutFrames = 0;
                        Int32 roundAddFrames = 0;
                        //Set the gather end frame
                        gatherEndFrame = i;
                        //Check what frames were gathered
                        if (framesGathered > framesGatheredThreshold)
                        {
                            //This round cut frames
                            roundCutFrames = Convert.ToInt32(Math.Floor(framesGathered - framesGatheredThreshold));
                            //Calculate the total frames to cut from this section
                            totalFramesToCut += roundCutFrames;
                            //Calculate which frames are to be cut
                            CutFrames(vfs, gatherStartFrame, gatherEndFrame, roundCutFrames);
                        }
                        else if (framesGathered < framesGatheredThreshold)
                        {
                            //This round add frames
                            roundAddFrames = Convert.ToInt32(Math.Floor(framesGatheredThreshold - framesGathered));
                            //Calculate the total frames to add to this section
                            totalFramesToAdd += roundAddFrames;
                            //Calculates which frames are to be added
                            AddFrames(vfs, gatherStartFrame, gatherEndFrame, roundAddFrames);
                        }
                        //Calculate time left
                        timeGathered -= timeGatheredThreshold;

                        //Reset the counter
                        framesGathered = 0;

                        //Set the gather start frame
                        if (i + 1 > vfs.FrameEnd)
                        {
                            gatherStartFrame = vfs.FrameEnd;
                        }
                        else
                        {
                            gatherStartFrame = i + 1;
                        }
                    }
                }
                //Set the gather end frame
                gatherEndFrame = vfs.FrameEnd;

                Int32 framesShouldBe = 0;

                //Check if any time is left
                if (timeGathered > 0.0m)
                {
                    //Calculate the frames that should be according to the CFR target frame rate
                    framesShouldBe = Convert.ToInt32(Math.Floor((timeGathered * (Convert.ToDecimal(framesGatheredThreshold) / timeGatheredThreshold)) + 0.5m));

                    //Check frames gathered
                    if (framesGathered > framesShouldBe)
                    {
                        //This round add frames
                        Int32 roundCutFrames = framesGathered - framesShouldBe;
                        //Calculate the total frames to cut from this section
                        totalFramesToCut += roundCutFrames;
                        //Calculate which frames are to be cut
                        CutFrames(vfs, gatherStartFrame, gatherEndFrame, roundCutFrames);
                    }
                    else if (framesGathered < framesShouldBe)
                    {
                        //This round add frames
                        Int32 roundAddFrames = framesShouldBe - framesGathered;
                        //Calculate the total frames to add to this section
                        totalFramesToAdd += roundAddFrames;
                        //Calculates which frames are to be added
                        AddFrames(vfs, gatherStartFrame, gatherEndFrame, roundAddFrames);
                    }
                }
                //Increase the counter
                sectionCounter++;
            }

            //Create the final avs file
            String finalAvsFile = AcHelper.GetFilename(_TimecodesFile, GetFileNameMode.FilenameWithoutExtension, GetDirectoryNameMode.FullPath);
            finalAvsFile = AcHelper.GetLastUnusedFilename(finalAvsFile, "kienzan.avs", 3);

            //Define the filenames
            String ffindexFile = AcHelper.GetFilename(finalAvsFile, GetFileNameMode.FilenameWithoutExtension, GetDirectoryNameMode.FullPath) + ".ffindex";
            String tcFile = AcHelper.GetFilename(finalAvsFile, GetFileNameMode.FilenameWithoutExtension, GetDirectoryNameMode.FullPath) + ".tc.txt";

            StringBuilder sb = new StringBuilder();

            //Write the header
            sb.AppendLine("#Script generated by Kienzan Kai (Courtesy of AC Tools)");
            sb.AppendLine();
            sb.AppendLine();

            //Write the video provider
            sb.AppendFormat("original = FFVideoSource(source = \"{0}\", track = -1, cache = true, ", _OriginalVideoFile);
            sb.AppendFormat("cachefile = \"{0}\", fpsnum = -1, fpsden = 1, threads = -1, ", ffindexFile);
            sb.AppendFormat("timecodes = \"{0}\", seekmode = 1)", tcFile);
            sb.AppendLine();

            //Assume framerate
            sb.AppendFormat("original = AssumeFPS(original, {0}, false)", targetFramerate.ToString("###.000###", CultureInfo.InvariantCulture));
            sb.AppendLine();
            sb.AppendLine();

            //Write the delete and duplicate frame
            //for each section
            foreach (VideoFrameSection vfs in _VideoFrameList.FrameSections)
            {
                sb.AppendLine(vfs.KienzanString());
            }
            sb.AppendLine();

            //Write the last line to concat the sections
            sb.AppendFormat("last = ");
            for (int i = 0; i < _VideoFrameList.FrameSections.Count; i++)
            {
                if (i == 0)
                {
                    sb.AppendFormat("{0}", _VideoFrameList.FrameSections[i].SectionName);
                }
                else
                {
                    sb.AppendFormat(" + {0}", _VideoFrameList.FrameSections[i].SectionName);
                }
            }
            sb.AppendLine();

            //Write the return statement
            sb.AppendFormat("return last");

            //Create the avs file
            using (StreamWriter sw = new StreamWriter(finalAvsFile, false, AcHelper.FindEncoding("1253")))
            {
                //Write the final String
                sw.WriteLine(sb.ToString());
            }
        }

        private void CutFrames(VideoFrameSection vfs, Int32 startFrame, Int32 endFrame, Int32 cutFrames)
        {
            //Create a temporary list
            VideoFrameList list = _VideoFrameList.CopyList(startFrame, endFrame);

            if (list.IsCFR)
            {
                //Sort the first cutFrames by frame number
                list.Sort(VideoFrameList.SortType.ByFrameNumber, VideoFrameList.SortOrder.Ascending);
            }
            else
            {
                //Sort all frames by difference
                list.Sort(VideoFrameList.SortType.ByFrameDifference, VideoFrameList.SortOrder.Ascending);
            }
            
            //Add the first cutFrames to the video section
            for (int i = 0; i < cutFrames; i++)
            {
                vfs.AddToDelete(list.FrameList[i]);
            }
        }

        private void AddFrames(VideoFrameSection vfs, Int32 startFrame, Int32 endFrame, Int32 addFrames)
        {
            //Create a temporary list
            VideoFrameList list = _VideoFrameList.CopyList(startFrame, endFrame);

            if (list.IsCFR)
            {
                //Sort the first addFrames by frame number
                list.Sort(VideoFrameList.SortType.ByFrameNumber, VideoFrameList.SortOrder.Ascending);
            }
            else
            {
                //Sort all frames by difference
                list.Sort(VideoFrameList.SortType.ByFrameDifference, VideoFrameList.SortOrder.Ascending);
            }

            //Sort all the frames by duration
            list.Sort(VideoFrameList.SortType.ByDuration, VideoFrameList.SortOrder.Descending);


            //Add the first addframes to the video section
            for (int i = 0; i < addFrames; i++)
            {
                vfs.AddToDuplicate(list.FrameList[i]);
            }
        }
    }
}
