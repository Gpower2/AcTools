using System;
using System.Collections.Generic;
using System.Text;
using AcToolsLibrary.Core.Video.VideoProviders.AviSynth;
using System.Threading;
using System.IO;
using AcToolsLibrary.Core.Video.VideoProviders.AviSynth.VideoSourceProviders;
using AcToolsLibrary.Common;
using System.Diagnostics;

namespace AcToolsLibrary.Core.Video
{
    public enum VideoPlayerType
    {
        SingleFrame,
        CurrentPreviousNextFrames
    }

    public class VideoPlayer
    {
        private AvsFile avs = null;
        private String fileOpened = "";
        private Int32 currentFrame = 0;
        private Boolean videoOpened = false;

        private Boolean videoPlaying = false;


        private VideoPlayerUpdateData videoData = null;

        private VideoPlayerType vpType = VideoPlayerType.SingleFrame;

        private AviSynthSourceProvidersEnum avisynthVideoProvider = AviSynthSourceProvidersEnum.FFMpegSource2;
        
        private Boolean isAvisynth = false;

        public Boolean VideoPlaying
        {
            get
            {
                return videoPlaying;
            }
            set
            {
                videoPlaying = value;
            }
        }

        public VideoPlayerUpdateData VideoData
        {
            get
            {
                return videoData;
            }
        }

        public Boolean VideoOpened
        {
            get
            {
                return videoOpened;
            }
        }

        public AviSynthSourceProvidersEnum AvisynthVideoProvider
        {
            get
            {
                return avisynthVideoProvider;
            }
        }

        public Boolean IsAviSynth
        {
            get
            {
                return isAvisynth;
            }
        }

        /// <summary>
        /// Constructor which simply sets the parent form
        /// </summary>
        public VideoPlayer(VideoPlayerType vt)
        {
            vpType = vt;
        }

        /// <summary>
        /// Opens a video file
        /// </summary>
        /// <param name="videoFile"></param>
        //public void OpenVideo(String videoFile)
        //{
        //    try
        //    {
        //        //Check if video filename is empty
        //        fileToOpen = videoFile;
        //        if (fileToOpen.Length < 1)
        //        {
        //            throw new AcException("Error opening video! Empty filename provided!");
        //        }

        //        //Check the avsfile object to avoid memory leaks
        //        if (avs != null)
        //        {
        //            avs.Dispose();
        //        }

        //        //Check if video file exists
        //        if (!File.Exists(fileToOpen))
        //        {
        //            throw new AcException("Error opening video! Video file does not exist!");
        //        }
        //        else
        //        {
        //            //Check if the video file is an AviSynth script
        //            if (!AcHelper.GetFilename(fileToOpen, GetFileNameMode.ExtensionOnly, GetDirectoryNameMode.NoPath).Contains("avs"))
        //            {
        //                isAvisynth = false;
        //               // AviSynthVideoSourceForm frm = new AviSynthVideoSourceForm();
        //               // frm.StartPosition = FormStartPosition.CenterParent;
        //              //  frm.ShowDialog();
        //                if (!frm.OKPressed)
        //                {
        //                    //User aborted
        //                    return;
        //                }
        //                else
        //                {
        //                    AviSynthFileCreator avsfc;
        //                    if (frm.OverrideFramerateChecked)
        //                    {
        //                        avsfc = new AviSynthFileCreator(fileToOpen, frm.SelectedAviSynthVideoProvider, frm.OverrideFramerate);
        //                    }
        //                    else
        //                    {
        //                        avsfc = new AviSynthFileCreator(fileToOpen, frm.SelectedAviSynthVideoProvider);
        //                    }
        //                    avisynthVideoProvider = frm.SelectedAviSynthVideoProvider;
        //                    fileToOpen = avsfc.AviSynthScriptFilename;
        //                }
        //            }
        //            else
        //            {
        //                isAvisynth = true;
        //            }

        //            try
        //            {
        //                avs = AvsFile.OpenScriptFile(fileToOpen);
        //                currentFrame = 0;
        //                videoOpened = true;
        //                fileOpened = fileToOpen;

        //                videoData = new VideoPlayerUpdateData(avs);
        //                updateVideoData();
        //                //acForm.UpdateGUI(videoData);
        //            }
        //            catch (Exception ex)
        //            {
        //                videoOpened = false;
        //                throw new AcException("Error opening video!", ex);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new AcException("Error opening video!", ex);
        //    }
        //}

        public void PlayVideo()
        {
            try
            {
                //Check if any video is opened
                if (!videoOpened)
                {
                    throw new AcException("Error playing video! No Video opened!");
                }
                //Set the flag 
                videoPlaying = true;
                //Get the last valid video frame
                Int32 endPlayFrame = avs.Clip.NumberOfFrames - 1;
                //Get the frame duration
                Int32 frameDuration = Convert.ToInt32((Convert.ToDouble(avs.Clip.Rated) / Convert.ToDouble(avs.Clip.Raten)) * 1000.0);
                //
                Int32 sleepTime = 0;
                //Create timer
                Stopwatch actime = new Stopwatch();
                //Create the object for the update data
                VideoPlayerUpdateData videoData = new VideoPlayerUpdateData(avs, null, currentFrame);
                while (currentFrame <= endPlayFrame && videoPlaying)
                {
                    actime.Start();
                    updateVideoData();
                    // acForm.UpdateGUI(videoData);

                    actime.Stop();
                    sleepTime = Convert.ToInt32(frameDuration - actime.ElapsedMilliseconds);
                    if (sleepTime < 0)
                    {
                        sleepTime = 0;
                    }
                    Thread.Sleep(sleepTime);
                    currentFrame++;
                }
                //Set the flag
                videoPlaying = false;
                //Check if stop was pressed
                if (currentFrame > endPlayFrame)
                {
                    //The video has reached the end frame
                    updateVideoData();
                    //acForm.UpdateGUI(videoData);

                }
            }
            catch (Exception ex)
            {
                throw new AcException("Error playing video!", ex);
            }
        }

        public void GetNextFrame()
        {
            if (currentFrame + 1 <= avs.Clip.NumberOfFrames - 1)
            {
                currentFrame++;
                updateVideoData();
                //acForm.UpdateGUI(videoData);
            }
        }

        public void GetNextFrame(Int32 step)
        {
            if (currentFrame + step <= avs.Clip.NumberOfFrames - 1)
            {
                currentFrame += step;
                updateVideoData();
                //acForm.UpdateGUI(videoData);
            }
        }

        public void GetPrevFrame()
        {
            if (currentFrame - 1 >= 0)
            {
                currentFrame--;
                updateVideoData();
                //acForm.UpdateGUI(videoData);
            }
        }

        public void GetLastFrame()
        {
            currentFrame = avs.Clip.NumberOfFrames - 1;
            updateVideoData();
            //acForm.UpdateGUI(videoData);
        }

        public void GetPrevFrame(Int32 step)
        {
            if (currentFrame - step >= 0)
            {
                currentFrame -= step;
                updateVideoData();
                //acForm.UpdateGUI(videoData);
            }
        }

        private void updateVideoData()
        {
            try
            {
                videoData.CurrentFrame = currentFrame;
                videoData.VideoFrameImage = avs.GetVideoReader().ReadFrameBitmap(currentFrame);
                if (vpType == VideoPlayerType.CurrentPreviousNextFrames)
                {
                    if (currentFrame == 0)
                    {
                        videoData.VideoFrameImagePrevious = null;
                        videoData.VideoFrameImageNext = avs.GetVideoReader().ReadFrameBitmap(currentFrame + 1);
                    }
                    else if (currentFrame == avs.Clip.NumberOfFrames - 1)
                    {
                        videoData.VideoFrameImagePrevious = avs.GetVideoReader().ReadFrameBitmap(currentFrame - 1);
                        videoData.VideoFrameImageNext = null;
                    }
                    else
                    {
                        videoData.VideoFrameImagePrevious = avs.GetVideoReader().ReadFrameBitmap(currentFrame - 1);
                        videoData.VideoFrameImageNext = avs.GetVideoReader().ReadFrameBitmap(currentFrame + 1);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new AcException("Error updating video data!", ex);
            }
        }

        public void ReLoad()
        {
            try
            {
                if (avs != null)
                {
                    avs.Dispose();
                }
                avs = AvsFile.OpenScriptFile(fileOpened);
                videoOpened = true;

                videoData = new VideoPlayerUpdateData(avs, null, currentFrame);
                updateVideoData();
                //acForm.UpdateGUI(videoData);
            }
            catch (Exception ex)
            {
                throw new AcException("Error reloading video!", ex);
            }
        }

        public void GetFrame(Int32 frameNumber)
        {
            try
            {
                currentFrame = frameNumber;
                updateVideoData();
                //acForm.UpdateGUI(videoData);
            }
            catch (Exception ex)
            {
                throw new AcException("Error seeking frame!", ex);
            }
        }

        public void Dispose()
        {
            if (avs != null)
            {
                avs.Dispose();
            }
        }

    }
}
