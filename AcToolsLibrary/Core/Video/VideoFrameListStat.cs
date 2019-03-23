using System;
using System.Collections.Generic;
using System.Text;

namespace AcToolsLibrary.Core.Video
{
    /// <summary>
    /// Class that contains statistic info for
    /// a Video Frame List for a specific frame rate
    /// </summary>
    public class VideoFrameListStat
    {
        private Decimal _FrameRate = 0.0m;
        private Decimal _FrameDuration = 0.0m;
        private Int64 _FrameCount = 0;
        
        /// <summary>
        /// The frame rate
        /// </summary>
        public Decimal FrameRate
        {
            get
            {
                return _FrameRate;
            }
            set
            {
                _FrameRate = value;
            }
        }

        /// <summary>
        /// The frame duration
        /// </summary>
        public Decimal FrameDuration
        {
            get { return _FrameDuration; }
            set { _FrameDuration = value; }
        }

        /// <summary>
        /// The count of frames for the frame rate
        /// </summary>
        public Int64 FrameCount
        {
            get
            {
                return _FrameCount;
            }
            set
            {
                _FrameCount = value;
            }
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public VideoFrameListStat()
        {
        }

        /// <summary>
        /// Returns a duplicate Video FrameList Stat object
        /// </summary>
        /// <returns></returns>
        public VideoFrameListStat Clone()
        {
            VideoFrameListStat vfls = new VideoFrameListStat();
            vfls._FrameCount = _FrameCount;
            vfls._FrameRate = _FrameRate;
            vfls._FrameDuration = _FrameDuration;
            return vfls;
        }
    
    }
}
