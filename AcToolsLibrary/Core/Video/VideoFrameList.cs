using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Linq;
using System.Diagnostics;
using System.IO;

using AcToolsLibrary.Common;
using AcToolsLibrary.Core.Parsers;

namespace AcToolsLibrary.Core.Video
{
    /// <summary>
    /// A class that represents a Video Frame List
    /// with extended functionality
    /// </summary>
    public class VideoFrameList
    {
        public enum SortType
        {
            ByFrameNumber,
            ByFrameDifference,
            ByDuration
        }

        public enum SortOrder
        {
            Ascending,
            Descending
        }

        private List<VideoFrame> _FrameList = new List<VideoFrame>();
        private List<VideoFrameListStat> _FrameStatsList = new List<VideoFrameListStat>();
        private List<VideoFrameSection> _FrameSectionList = new List<VideoFrameSection>();
        private Boolean _HasTimeCodes = false;
        private Boolean _HasDuplicates = false;
        private Int64 _NumberOfLoadedFrameImages = 0;
        private Decimal _AverageFramerate = 0.0m;
        private Decimal _AssumedFramerate = 0.0m;
        private UInt16 _TimecodesVersionLoaded = 0;

        /// <summary>
        /// The list of the video frames
        /// </summary>
        public List<VideoFrame> FrameList
        {
            get
            {
                return _FrameList;
            }
            set
            {
                if (value == null)
                {
                    throw (new Exception("Invalid frame list! No null lists allowed!"));
                }
                _FrameList.Clear();
                _FrameList = value;
                _HasTimeCodes = scanForTimecodes();
                _HasDuplicates = scanForDuplicates();
            }
        }

        /// <summary>
        /// The list of the video list statistics
        /// </summary>
        public List<VideoFrameListStat> FrameListStats
        {
            get
            {
                return _FrameStatsList;
            }
        }

        /// <summary>
        /// The list of the video sections
        /// </summary>
        public List<VideoFrameSection> FrameSections
        {
            get
            {
                return _FrameSectionList;
            }
        }

        /// <summary>
        /// Flag that indicates whether timecodes are loaded (Read-only)
        /// </summary>
        public Boolean HasTimecodes
        {
            get
            {
                return _HasTimeCodes;
            }
        }
        
        /// <summary>
        /// Flag that indicates whether duplicates are loaded (Read-only)
        /// </summary>
        public Boolean HasDuplicates
        {
            get
            {
                return _HasDuplicates;
            }
        }

        /// <summary>
        /// The number of loaded video frame images (Read-only)
        /// </summary>
        public Int64 NumberOfLoadedFrameImages
        {
            get
            {
                return _NumberOfLoadedFrameImages;
            }
        }

        /// <summary>
        /// Flag that indicates whether the list contains any frames or not (Read-only)
        /// </summary>
        public Boolean IsEmpty
        {
            get
            {
                return _FrameList.Count == 0;
            }
        }

        /// <summary>
        /// Gets the number of frames contained in the list
        /// </summary>
        public int Count
        {
            get
            {
                return _FrameList.Count;
            }
        }

        /// <summary>
        /// Gets the number of stats
        /// </summary>
        public int CountStats
        {
            get
            {
                return _FrameStatsList.Count;
            }
        }

        /// <summary>
        /// Gets the number of frame Sections
        /// </summary>
        public int CountSections
        {
            get
            {
                return _FrameSectionList.Count;
            }
        }

        /// <summary>
        /// Gets the average frame rate of the frame list
        /// </summary>
        public Decimal AverageFrameRate
        {
            get
            {
                return _AverageFramerate;
            }
        }

        /// <summary>
        /// Gets the assumed framerate of the frame list accirding to the timecodes
        /// NOTE: Only if version 1 timecodes were loaded
        /// </summary>
        public Decimal AssumedFrameRate
        {
            get { return _AssumedFramerate; }
        }

        /// <summary>
        /// Gets the version of the timecodes file loaded
        /// </summary>
        public UInt16 TimecodesVersionLoaded
        {
            get { return _TimecodesVersionLoaded; }
        }

        /// <summary>
        /// Returns if the frame list has Constant Frame rate or not
        /// </summary>
        public Boolean IsCFR
        {
            get
            {
                // We don't care for more than 3 digits accuracy in ms duration
                return (_FrameList.GroupBy(x => AcHelper.Round(x.FrameDuration, 3)).Count() == 1);
                //return (frameStats.Count == 1);
            }
        }

        /// <summary>
        /// Constructor for an empty list
        /// </summary>
        public VideoFrameList()
        {
            ///TODO:
        }

        /// <summary>
        /// Add a Video Frame into the list
        /// </summary>
        /// <param name="vf">The Video frame to add</param>
        public void Add(VideoFrame vf)
        {
            if (vf == null)
            {
                throw (new Exception("Invalid VideoFrame! No null VideoFrames allowed!"));
            }
            _FrameList.Add(vf);
            //Check for timecodes
            if (!vf.HasTimecode)
            {
                _HasTimeCodes = false;
            }
            else
            {
                //If it's the first frame
                if (_FrameList.Count == 1)
                {
                    _HasTimeCodes = true;
                }
            }
            //Check for duplicates
            if (!vf.HasDuplicate)
            {
                _HasDuplicates = false;
            }
            else
            {
                //If it's the first frame
                if (_FrameList.Count == 1)
                {
                    _HasDuplicates = true;
                }
            }
        }

        /// <summary>
        /// Adds the frames from another VideoFrameList
        /// by copying the frames
        /// </summary>
        /// <param name="vfl">the VideoFrameList with the frames to add</param>
        public void Add(VideoFrameList vfl)
        {
            if (vfl == null)
            {
                throw (new Exception("Invalid VideoFrameList! No null VideoFrameList allowed!"));
            }
            foreach (VideoFrame vf in vfl._FrameList)
            {
                this.Add(vf.Clone());
            }
        }

        /// <summary>
        /// Remove the first occurence of the given Video Frame
        /// </summary>
        /// <param name="vf">the Video Frame to remove</param>
        /// <returns>true of the Video Frame was found and removed, false otherwise</returns>
        public Boolean Remove(VideoFrame vf)
        {
            if (vf == null)
            {
                throw (new Exception("Invalid VideoFrame! No null VideoFrames allowed!"));
            }
            return _FrameList.Remove(vf);
        }

        /// <summary>
        /// Remove the video frame at the specific index
        /// </summary>
        /// <param name="idx">the index of the frame to remove</param>
        public void RemoveAt(int idx)
        {
            if (idx < 0)
            {
                throw (new Exception("Invalid VideoFrame Index! Only positive or zero values allowed!"));
            }
            _FrameList.RemoveAt(idx);
        }

        /// <summary>
        /// Clears the frame list and its properties
        /// </summary>
        public void Clear()
        {
            _FrameList.Clear();
            _HasDuplicates = false;
            _HasTimeCodes = false;
            _NumberOfLoadedFrameImages = 0;
        }

        public void AddSection(VideoFrameSection vfs)
        {
            _FrameSectionList.Add(vfs);
        }

        public void RemoveSection(VideoFrameSection vfs)
        {
            _FrameSectionList.Remove(vfs);
        }

        public void RemoveSectionAt(int idx)
        {
            _FrameSectionList.RemoveAt(idx);
        }

        public void ClearSections()
        {
            _FrameSectionList.Clear();
        }

        public void ClearStats()
        {
            _FrameStatsList.Clear();
        }

        /// <summary>
        /// Scans the frame list for timecodes
        /// </summary>
        /// <returns>false if even 1 frame does not contains timecodes, otherwise true</returns>
        private Boolean scanForTimecodes()
        {
            if (_FrameList.Count == 0)
            {
                return false;
            }
            foreach (VideoFrame vf in _FrameList)
            {
                if (!vf.HasTimecode)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Scans the frame list for duplicate information
        /// </summary>
        /// <returns>false if even 1 frame does not contains duplicate information, otherwise true</returns>
        private Boolean scanForDuplicates()
        {
            if (_FrameList.Count == 0)
            {
                return false;
            }
            foreach (VideoFrame vf in _FrameList)
            {
                if (!vf.HasDuplicate)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Load timecodes from a timecode file
        /// WARNING, it cleans the previous frame list and builds a new one
        /// </summary>
        /// <param name="tcFile">the filename of the timecodes</param>
        /// <param name="accuracy">the number of decimal digits</param>
        public void LoadTimecodes(String tcFile, Boolean writeDump, Int32 accuracy)
        {
            _FrameList.Clear();
            _FrameStatsList.Clear();
            _FrameSectionList.Clear();
            TimeCodeParser tcparser = new TimeCodeParser();
            tcparser.ParseTimecodes(tcFile, this, writeDump);
            _AssumedFramerate = tcparser.AssumedFrameRate;
            _TimecodesVersionLoaded = tcparser.TimecodesFileVersion;
            CalculateStats(accuracy);
            _HasTimeCodes = true;
        }

        /// <summary>
        /// Creates a video frame list assuming CFR timecodes
        /// WARNING, it cleans the previous frame list and builds a new one
        /// </summary>
        /// <param name="numberOfFrames">the total number of frames of the new list to create</param>
        /// <param name="frameRate">the CFR framerate of the frames</param>
        public void CreateFakeTimecodes(Int32 numberOfFrames, Decimal frameRate)
        {
            _FrameList.Clear();
            _FrameStatsList.Clear();
            _FrameSectionList.Clear();
            Decimal frameDuration = 1.0m / frameRate;
            for (int i = 0; i < numberOfFrames; i++)
            {
                _FrameList.Add(new VideoFrame(i, frameDuration));
            }
            CalculateStats(3);
            _HasTimeCodes = true;
        }

        /// <summary>
        /// Writes the timecodes according to the frame data
        /// </summary>
        /// <param name="outputFile">the timecodes file to write</param>
        /// <param name="assumedRate">the assumed frame rate (valid only for v1 timecodes)</param>
        /// <param name="timecodesVersion">the timecodes file version</param>
        public void WriteTimecodes(String outputFile, UInt16 timecodesVersion, Double assumedRate)
        {
            //Check if there are no gaps
            Int32 previousFrameNumber = _FrameList[0].FrameNumber;
            //Sort the list by frame number
            Sort(SortType.ByFrameNumber, SortOrder.Ascending);
            for (int i = 1; i < _FrameList.Count; i++)
            {
                if (_FrameList[i].FrameNumber - previousFrameNumber > 1)
                {
                    throw new Exception("There are gaps in the timecodes!");
                }
                else if (_FrameList[i].FrameNumber == previousFrameNumber)
                {
                    throw new Exception("There are duplicate frames in the timecodes!");
                }
                else if (_FrameList[i].FrameNumber - previousFrameNumber < 0)
                {
                    throw new Exception("The timecodes list is not sorted!");
                }
                previousFrameNumber = i;
            }
            using (StreamWriter sw = new StreamWriter(outputFile, false, System.Text.Encoding.UTF8))
            {
                StringBuilder fileBuilder = new StringBuilder();
                switch (timecodesVersion)
                {
                    case 1:
                        fileBuilder.AppendLine("# timecode format v1");
                        fileBuilder.AppendLine("assume " + _AssumedFramerate.ToString("0.000000", CultureInfo.InvariantCulture));
                        foreach (VideoFrame vf in _FrameList)
                        {
                            //Lazy approach
                            fileBuilder.AppendFormat("{0},{0},{1}\r\n", vf.FrameNumber, vf.FrameRate.ToString("0.000000", CultureInfo.InvariantCulture));
                        }
                        sw.Write(fileBuilder.ToString());
                        break;
                    case 2:
                        fileBuilder.AppendLine("# timecode format v2");
                        foreach (VideoFrame vf in _FrameList)
                        {
                            fileBuilder.AppendLine(vf.FrameStartTime.ToString("0.000000", CultureInfo.InvariantCulture));
                        }
                        sw.Write(fileBuilder.ToString());
                        break;
                    default:
                        throw new Exception("Not supported timecodes version!");
                }
            }
        }

        /// <summary>
        /// Load duplicates from a duplicate file
        /// If a frame list exists, it updates the fields accordingly
        /// otherwise it creates a new one
        /// </summary>
        /// <param name="dpFile">the filename of the duplicates</param>
        public void LoadDuplicates(String dpFile)
        {
            DuplicateParser.ParseDup(dpFile, this);
            _HasDuplicates = true;
        }

        /// <summary>
        /// Load sections from a sections/trims file
        /// </summary>
        /// <param name="sectionsFile"></param>
        public void LoadSections(String sectionsFile)
        {
            SectionParser.ParseSections(sectionsFile, this);
        }

        /// <summary>
        /// Returns a new duplicate VideoFrameList object
        /// </summary>
        /// <returns>the Duplicate object</returns>
        public VideoFrameList Clone()
        {
            VideoFrameList vfl = new VideoFrameList();
            vfl._FrameList = new List<VideoFrame>();
            foreach (VideoFrame vf in _FrameList)
            {
                vfl._FrameList.Add(vf.Clone());
            }
            vfl._FrameStatsList = new List<VideoFrameListStat>();
            foreach (VideoFrameListStat vfls in _FrameStatsList)
            {
                vfl._FrameStatsList.Add(vfls.Clone());
            }
            vfl._HasDuplicates = _HasDuplicates;
            vfl._HasTimeCodes = _HasTimeCodes;
            vfl._NumberOfLoadedFrameImages = _NumberOfLoadedFrameImages;
            
            return vfl;
        }

        /// <summary>
        /// Calculates the stats for the timecode info of the current frame list
        /// </summary>
        public void CalculateStats(Int32 accuracyDecimals)
        {
            //Calculate FrameInfo Stats
            Decimal sum = 0.0m;
            for (int i = 0; i < _FrameList.Count; i++)
            {
                sum += AcHelper.Round(_FrameList[i].FrameRate, accuracyDecimals);

                bool found = false;
                for (int j = 0; j < _FrameStatsList.Count; j++)
                {
                    if (AcHelper.Round(_FrameStatsList[j].FrameRate, accuracyDecimals) ==
                        AcHelper.Round(_FrameList[i].FrameRate, accuracyDecimals))
                    {
                        _FrameStatsList[j].FrameCount++;
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    VideoFrameListStat t = new VideoFrameListStat();
                    t.FrameCount = 1;
                    t.FrameRate = AcHelper.Round(_FrameList[i].FrameRate, accuracyDecimals);
                    t.FrameDuration = AcHelper.Round(_FrameList[i].FrameDuration, accuracyDecimals);
                    //comboBox1.Items.Add("" + t.frame_fps);
                    _FrameStatsList.Add(t);
                }
            }
            _AverageFramerate = (sum / Convert.ToDecimal(Count));
            //AcLogger.Log("Average fps : " + averageFramerate, AcLogger.AcLogType.Form);
            //String formatString = "";
            //formatString = "000.".PadRight(4 + accuracyDecimals, '0');
            //for (int i = 0; i < frameStats.Count; i++)
            //{
                //AcLogger.Log("fps : " + frameStats[i].FrameRate.ToString(formatString) + " - Total frames : " +
                //    frameStats[i].FrameCount.ToString("0000000") +
                //    "  - Percent : " + Convert.ToDouble(Convert.ToDouble((frameStats[i].FrameCount) / Convert.ToDouble(Count)) * 100.0).ToString("#00.000000000") + "%"
                //    , AcLogger.AcLogType.Form);
            //}
        }

        public void Sort(SortType sortType, SortOrder sortOrder)
        {
            switch (sortOrder)
            {
                case SortOrder.Ascending:
                    switch (sortType)
                    {
                        case SortType.ByFrameNumber:
                            _FrameList.Sort(CompareVideoFramesByFrameNumberAsc);
                            break;
                        case SortType.ByFrameDifference:
                            _FrameList.Sort(CompareVideoFramesByFrameDifferenceAsc);
                            break;
                        case SortType.ByDuration:
                            _FrameList.Sort(CompareVideoFramesByDurationAsc);
                            break;
                    }
                    break;
                case SortOrder.Descending:
                    switch (sortType)
                    {
                        case SortType.ByFrameNumber:
                            _FrameList.Sort(CompareVideoFramesByFrameNumberDesc);
                            break;
                        case SortType.ByFrameDifference:
                            _FrameList.Sort(CompareVideoFramesByFrameDifferenceDesc);
                            break;
                        case SortType.ByDuration:
                            _FrameList.Sort(CompareVideoFramesByDurationDesc);
                            break;
                    }
                    break;
            }
            
        }

        private int CompareVideoFramesByFrameNumberAsc(VideoFrame x, VideoFrame y)
        {
            if (x.FrameNumber > y.FrameNumber)
            {
                return 1;
            }
            else if (x.FrameNumber < y.FrameNumber)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private int CompareVideoFramesByFrameNumberDesc(VideoFrame x, VideoFrame y)
        {
            if (x.FrameNumber < y.FrameNumber)
            {
                return 1;
            }
            else if (x.FrameNumber > y.FrameNumber)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private int CompareVideoFramesByFrameDifferenceAsc(VideoFrame x, VideoFrame y)
        {
            if (x.FrameDifferenceFromPrevious > y.FrameDifferenceFromPrevious)
            {
                return 1;
            }
            else if (x.FrameDifferenceFromPrevious < y.FrameDifferenceFromPrevious)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private int CompareVideoFramesByFrameDifferenceDesc(VideoFrame x, VideoFrame y)
        {
            if (x.FrameDifferenceFromPrevious < y.FrameDifferenceFromPrevious)
            {
                return 1;
            }
            else if (x.FrameDifferenceFromPrevious > y.FrameDifferenceFromPrevious)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private int CompareVideoFramesByDurationAsc(VideoFrame x, VideoFrame y)
        {
            if (x.FrameDuration > y.FrameDuration)
            {
                return 1;
            }
            else if (x.FrameDuration < y.FrameDuration)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private int CompareVideoFramesByDurationDesc(VideoFrame x, VideoFrame y)
        {
            if (x.FrameDuration < y.FrameDuration)
            {
                return 1;
            }
            else if (x.FrameDuration > y.FrameDuration)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Creates a new videoframelist and copies ONLY the frames
        /// All the other info are not copied
        /// </summary>
        /// <param name="start">the start frame index</param>
        /// <param name="end">the end frame index</param>
        /// <returns>the new videoframelist</returns>
        public VideoFrameList CopyList(Int32 start, Int32 end)
        {
            VideoFrameList vfl = new VideoFrameList();
            for (int i = start; i <= end; i++)
            {
                vfl.Add(this._FrameList[i].Clone());
            }
            return vfl;
        }

        /// <summary>
        /// Creates a new VideoFrameList which contains
        /// the merged frames from other two
        /// </summary>
        /// <param name="vfl1"></param>
        /// <param name="vfl2"></param>
        /// <returns>the merged VideoFrameList</returns>
        public static VideoFrameList Merge(VideoFrameList vfl1, VideoFrameList vfl2)
        {
            VideoFrameList vfl = new VideoFrameList();
            vfl.Add(vfl1);
            vfl.Add(vfl2);
            return vfl;
        }

        public Decimal TotalTime(Int32 start, Int32 end)
        {
            Decimal totTime = 0.0m;
            foreach (VideoFrame vf in _FrameList)
            {
                if (vf.FrameNumber >= start && vf.FrameNumber <= end)
                {
                    totTime += vf.FrameDuration;
                }
            }
            return totTime;
        }
    }
}
