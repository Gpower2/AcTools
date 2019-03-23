using System;
using System.Collections.Generic;
using System.Text;

namespace AcToolsLibrary.Core.Video
{
    public enum AudioValueType
    {
        AudioFileSize,
        AudioBitrate
    }

    public enum VideoValueType
    {
        TotalFileSize,
        VideoFileSize,
        VideoBitrate
    }

    public class BitrateCalculator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public Double GetSecondsFromTime(Int32 hours, Int32 minutes, Int32 seconds)
        {
            return (hours * 3600.0) + (minutes * 60.0) + seconds;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitrate">in kbps</param>
        /// <param name="duration">in seconds</param>
        /// <returns>in bytes</returns>
        public Double BitrateToSize(Double bitrate, Double duration)
        {
            return ((bitrate * 1000.0) / 8.0) * duration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sizeValue">in bytes</param>
        /// <param name="duration">in seconds</param>
        /// <returns>in kbps</returns>
        public Double SizeToBitrate(Double sizeValue, Double duration)
        {
            return ((sizeValue * 8.0) / 1000.0) / duration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="duration">in seconds</param>
        /// <param name="audioValueType"></param>
        /// <param name="audioValue">in kbps for bitrate, in bytes for size</param>
        /// <param name="videoValueType"></param>
        /// <param name="videoValue">in kbps for bitrate, in bytes for size</param>
        /// <returns></returns>
        public Double CalculateTarget(Double duration, AudioValueType audioValueType, Double audioValue,
            VideoValueType videoValueType, Double videoValue)
        {
            Double targetValue = 0.0;
            Double audioSize = 0.0;
            Double videoSize = 0.0;

            switch (audioValueType)
            {
                case AudioValueType.AudioBitrate:
                    audioSize = BitrateToSize(audioValue, duration);
                    break;
                case AudioValueType.AudioFileSize:
                    audioSize = audioValue;
                    break;
            }
            switch (videoValueType)
            {
                case VideoValueType.TotalFileSize:
                    //Target Value is video bitrate
                    targetValue = SizeToBitrate(videoValue - audioSize, duration); 
                    break;
                case VideoValueType.VideoFileSize:
                    //Target Value is video bitrate
                    targetValue = SizeToBitrate(videoValue, duration);                  
                    break;
                case VideoValueType.VideoBitrate:
                    //Target Value is total filesize
                    videoSize = BitrateToSize(videoValue, duration);
                    targetValue = audioSize + videoSize;
                    break;
                default:
                    break;
            }

            return targetValue;
        }
    }
}
