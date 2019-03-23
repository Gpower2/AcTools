using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace AcToolsLibrary.Core.Video
{

    public enum FrameFromType{
        FromFrameRate,
        FromDuration
    }

    public enum FrameProcessType
    {
        UnProcessed,
        ToDelete,
        ToDuplicate
    }

    /// <summary>
    /// Class that represents a Video Frame
    /// </summary>
    public class VideoFrame
    {
        private Int32 _FrameNumber = -1;
        private Image _FrameImage = null;
        private Decimal _FrameStartTime = Decimal.MinValue;
        private Decimal _FrameDuration = Decimal.MinValue;
        private Decimal _FrameDifferenceFromPrevious = Decimal.MinValue;
        private FrameProcessType _ProcessType = FrameProcessType.UnProcessed;
        private Int32 _DuplicateTimes = 0;

        /// <summary>
        /// The specific frame number of the parent video
        /// </summary>
        public Int32 FrameNumber
        {
            get
            {
                return _FrameNumber;
            }
            set
            {
                if (value > -1)
                {
                    _FrameNumber = value;
                }
                else
                {
                    throw new Exception("Invalid Frame number! Only positive values allowed!");
                }
            }
        }

        /// <summary>
        /// The frame rate that corresponds to the current frame in frame/ms
        /// </summary>
        public Decimal FrameRate
        {
            get
            {
                if (_FrameDuration == 0)
                {
                    return 0.0m;
                }
                return 1000.0m / _FrameDuration;
            }
            set
            {
                if (value > 0.0m)
                {
                    _FrameDuration = 1000.0m / value;
                }
                else if (value == 0.0m)
                {
                    _FrameDuration = 0.0m;
                }
                else
                {
                    throw new Exception("Invalid Frame rate! Only positive or zero values allowed!");
                }
            }
        }

        /// <summary>
        /// The frame duration of the current frame in ms
        /// </summary>
        public Decimal FrameDuration
        {
            get
            {
                return _FrameDuration;
            }
            set
            {
                if (value >= 0.0m)
                {
                    _FrameDuration = value;
                }
                else
                {
                    throw new Exception("Invalid Frame duration! Only positive or zero values allowed!");
                }
            }
        }

        /// <summary>
        /// The start time of the frame in the corresponding video in ms
        /// </summary>
        public Decimal FrameStartTime
        {
            get
            {
                return _FrameStartTime;
            }
            set
            {
                //if (value < 0.0)
                //{
                //    throw (new Exception("Invalid Frame Start Time! Only positive values allowed."));
                //}
                //else
                //{
                    _FrameStartTime = value;
                //}
            }
        }

        /// <summary>
        /// The end time of the frame in the corresponding video in ms
        /// </summary>
        public Decimal FrameEndTime
        {
            get
            {
                return _FrameStartTime + _FrameDuration;
            }
            set
            {
                if (value >= _FrameDuration)
                {
                    _FrameStartTime = value - _FrameDuration;
                }
                else
                {
                    throw new Exception("Invalid Frame End Time! End time must be greater than the frame duration.");
                }
            }
        }

        /// <summary>
        /// The difference of the current frame from the previous one in the corresponding video in %
        /// </summary>
        public Decimal FrameDifferenceFromPrevious
        {
            get
            {
                return _FrameDifferenceFromPrevious;
            }
            set
            {
                //if (value <= 100.0)
                //{
                    _FrameDifferenceFromPrevious = value;
                //}
            //    else
            //    {
            //        throw (new Exception("Invalid Frame Difference! Difference cannot be more than 100%."));
            //    }
            }
        }

        /// <summary>
        /// The frame Image from the corresponding video
        /// </summary>
        public Image FrameImage
        {
            get
            {
                return _FrameImage;
            }
            set
            {
                if (value == null)
                {
                    throw new Exception("Invalid Image! Null images are not allowed!");
                }
                _FrameImage = value;
            }
        }


        /// <summary>
        /// Flag that indicates whether the frame has an image
        /// </summary>
        public Boolean HasImage
        {
            get
            {
                return (_FrameImage != null);
            }
        }

        /// <summary>
        /// Flag that indicates whether the frame has duration and start time (read-only)
        /// </summary>
        public Boolean HasTimecode
        {
            get
            {
                if ((Decimal.MinValue != _FrameDuration) && (Decimal.MinValue != _FrameStartTime))
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Flag that indicates whether the frame has difference information (read-only)
        /// </summary>
        public Boolean HasDuplicate
        {
            get
            {
                if (Decimal.MinValue == _FrameDifferenceFromPrevious)
                {
                    return false;
                }
                return true;
            }
        }

        /// <summary>
        /// The Frame Process Type of this video frame
        /// </summary>
        public FrameProcessType ProcessType
        {
            get
            {
                return _ProcessType;
            }
            set
            {
                _ProcessType = value;
            }
        }

        /// <summary>
        /// If frame is to be duplicated, it indicates how many times it will be
        /// duplicated.
        /// </summary>
        public Int32 DuplicateTimes
        {
            get
            {
                return _DuplicateTimes;
            }
            set
            {
                if (value < 0)
                {
                    throw (new Exception("Invalid Duplicate times! Only zero or positive values allowed!"));
                }
                _DuplicateTimes = value;
            }
        }

        /// <summary>
        /// Constructor for an empty frame
        /// </summary>
        public VideoFrame()
        {

        }

        /// <summary>
        /// Constructor for a video frame
        /// </summary>
        /// <param name="argFrameNumber">frame number</param>
        public VideoFrame(Int32 argFrameNumber)
        {
            FrameNumber = argFrameNumber;
        }

        /// <summary>
        /// Constructor for a video frame
        /// </summary>
        /// <param name="argFrameNumber">frame number</param>
        /// <param name="argFrameImage">frame Image</param>
        public VideoFrame(Int32 argFrameNumber, Image argFrameImage)
        {
            FrameNumber = argFrameNumber;
            FrameImage = argFrameImage;
        }

        /// <summary>
        /// Constructor for a video frame
        /// </summary>
        /// <param name="argFrameNumber">frame number</param>
        /// <param name="argFrameDuration">frame duration in ms</param>
        public VideoFrame(Int32 argFrameNumber, Decimal argFrameDuration)
        {
            FrameNumber = argFrameNumber;
            FrameDuration = argFrameDuration;
        }

        /// <summary>
        /// Constructor for a video frame
        /// </summary>
        /// <param name="argFrameNumber">frame number</param>
        /// <param name="argFrameDuration">frame duration in ms</param>
        /// <param name="argFrameStartTime">frame start time in ms</param>
        public VideoFrame(Int32 argFrameNumber, Decimal argFrameDuration, Decimal argFrameStartTime)
        {
            FrameNumber = argFrameNumber;
            FrameStartTime = argFrameStartTime;
            FrameDuration = argFrameDuration;
        }

        /// <summary>
        /// Constructor for a video frame
        /// </summary>
        /// <param name="argFrameNumber">frame number</param>
        /// <param name="argFrameDuration">frame duration in ms</param>
        /// <param name="argFrameStartTime">frame start time in ms</param>
        /// <param name="argFrameDifferenceFromPrevious">frame difference from previous frame in %</param>
        public VideoFrame(Int32 argFrameNumber, Decimal argFrameDuration, Decimal argFrameStartTime, Decimal argFrameDifferenceFromPrevious)
        {
            FrameNumber = argFrameNumber;
            FrameStartTime = argFrameStartTime;
            FrameDuration = argFrameDuration;
            FrameDifferenceFromPrevious = argFrameDifferenceFromPrevious;
        }

        /// <summary>
        /// Constructor for a video frame
        /// </summary>
        /// <param name="argFrameNumber">frame number</param>
        /// <param name="argFrameDuration">frame duration in ms</param>
        /// <param name="argFrameStartTime">frame start time in ms</param>
        /// <param name="argFrameDifferenceFromPrevious">frame difference from previous frame in %</param>
        /// <param name="argFrameImage">frame image</param>
        public VideoFrame(Int32 argFrameNumber, Decimal argFrameDuration, Decimal argFrameStartTime, Decimal argFrameDifferenceFromPrevious, Image argFrameImage)
        {
            FrameNumber = argFrameNumber;
            FrameStartTime = argFrameStartTime;
            FrameDuration = argFrameDuration;
            FrameDifferenceFromPrevious = argFrameDifferenceFromPrevious;
            FrameImage = argFrameImage;
        }	

        /// <summary>
        /// Calculates the corresponding frame rate from a given duration in ms
        /// </summary>
        /// <param name="dur">duration in ms</param>
        /// <returns>the corresponding frame rate in frames/sec</returns>
        public static Decimal GetFrameRateFromDuration(Decimal dur)
        {
            if (dur == 0m)
            {
                return 0m;
            }
            if (dur > 0m)
            {
                return 1000.0m / dur;
            }
            throw (new Exception("Invalid Frame duration! Only positive or zero values allowed."));
        }

        /// <summary>
        /// Calculates the corresponding duration from a given frame rate
        /// </summary>
        /// <param name="fr">the framerate in frames/sec</param>
        /// <returns>the corresponding duration in ms</returns>
        public static Decimal GetDurationFromFrameRate(Decimal fr)
        {
            if (fr == 0m)
            {
                return 0m;
            }
            if (fr > 0m)
            {
                return 1000.0m / fr;
            }
            throw (new Exception("Invalid Frame Rate! Only positive or zero values allowed!"));
        }

        /// <summary>
        /// Calculates the frame number from given start time and frame rate
        /// assuming CFR video
        /// </summary>
        /// <param name="start">the start time in ms</param>
        /// <param name="frameRate"><the frame rate in frames/sec/param>
        /// <returns>the calculated frame number</returns>
        public static Int32 GetFrameNumberFromStartTime(Decimal start, Decimal frameRate)
        {
            //if (start < 0.0)
            //{
            //    throw (new Exception("Invalid start time! Only positives or zero values allowed."));
            //}
            if (frameRate < 0.0m)
            {
                throw (new Exception("Invalid frame rate! Only positives or zero values allowed."));
            }
            return Convert.ToInt32(start * frameRate * 0.001m);
        }

        /// <summary>
        /// Calculates the start time from given frame number and frame rate
        /// assuming CFR video
        /// </summary>
        /// <param name="frameNumber">the frame number</param>
        /// <param name="frameRate">the frame rate in frames/sec</param>
        /// <returns>the calculated start time</returns>
        public static Decimal GetStartTimeFromFrameNumber(Int32 frameNumber, Decimal frameRate)
        {
            //if (frameNumber < 0)
            //{
            //    throw (new Exception("Invalid frame number! Only positives or zero values allowed."));
            //}
            if (frameRate < 0.0m)
            {
                throw (new Exception("Invalid frame rate! Only positives or zero values allowed."));
            }
            return Convert.ToDecimal(frameNumber) * 1000.0m / frameRate;
        }

        /// <summary>
        /// Return a new duplicate object
        /// </summary>
        /// <returns>the duplicate object</returns>
        public VideoFrame Clone()
        {
            return (VideoFrame)this.MemberwiseClone();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frameNumber"></param>
        /// <param name="frameInfo"></param>
        /// <param name="fromType"></param>
        /// <returns></returns>
        public static String FrameTimeFromFrameNumber(Int32 frameNumber, Decimal frameInfo, FrameFromType fromType)
        {
            Decimal frameMilliseconds;
            switch (fromType)
            {
                case FrameFromType.FromFrameRate:
                    frameMilliseconds = Convert.ToDecimal(frameNumber) / frameInfo * 1000.0m;
                    break;
                case FrameFromType.FromDuration:
                    frameMilliseconds = frameNumber * frameInfo;
                    break;
                default:
                    frameMilliseconds = 0.0m;
                    break;
            }
            
            TimeSpan ts = TimeSpan.FromMilliseconds(Convert.ToDouble(frameMilliseconds));
            return String.Format("{0}:{1}:{2}.{3}",
                ts.Hours.ToString("00"),
                ts.Minutes.ToString("00"),
                ts.Seconds.ToString("00"),
                ts.Milliseconds.ToString("000").PadRight(9, '0'));
        }

        public static String FrameTimeFromFrameNumber(Decimal frameNumber, Decimal frameInfo, FrameFromType fromType)
        {
            Decimal frameMilliseconds;
            switch (fromType)
            {
                case FrameFromType.FromFrameRate:
                    frameMilliseconds = frameNumber / frameInfo * 1000.0m;
                    break;
                case FrameFromType.FromDuration:
                    frameMilliseconds = frameNumber * frameInfo;
                    break;
                default:
                    frameMilliseconds = 0.0m;
                    break;
            }

            TimeSpan ts = TimeSpan.FromMilliseconds(Convert.ToDouble(frameMilliseconds));
            return String.Format("{0}:{1}:{2}.{3}",
               ts.Hours.ToString("00"),
               ts.Minutes.ToString("00"),
               ts.Seconds.ToString("00"),
               ts.Milliseconds.ToString("000").PadRight(9, '0'));
        }

    }
}
