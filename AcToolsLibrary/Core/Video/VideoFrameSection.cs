using System;
using System.Collections.Generic;
using System.Text;

namespace AcToolsLibrary.Core.Video
{
    /// <summary>
    /// Class that represents a Trim Section of a VideoFrameList
    /// All objects here are copies of the original to protect data
    /// </summary>
    public class VideoFrameSection
    {

        private Int32 _FrameStart = 0;
        private Int32 _FrameEnd = 0;
        private VideoFrameList _FramesToDuplicate;
        private VideoFrameList _FramesToDelete;
        private String _SectionName = "";

        /// <summary>
        /// The starting video frame number
        /// </summary>
        public int FrameStart
        {
            get
            {
                return _FrameStart;
            }
            set
            {
                _FrameStart = value;
            }
        }

        /// <summary>
        /// The ending video frame number
        /// </summary>
        public int FrameEnd
        {
            get
            {
                return _FrameEnd;
            }
            set
            {
                _FrameEnd = value;
            }
        }

        /// <summary>
        /// The list of frames to delete
        /// </summary>
        public VideoFrameList FramesToDelete
        {
            get
            {
                return _FramesToDelete;
            }
        }

        /// <summary>
        /// The list of frames to duplicate
        /// </summary>
        public VideoFrameList FramesToDuplicate
        {
            get
            {
                return _FramesToDuplicate;
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public VideoFrameSection()
        {
            _FrameEnd = 0;
            _FrameStart = 0;
            _FramesToDelete = new VideoFrameList();
            _FramesToDuplicate = new VideoFrameList();
        }

        /// <summary>
        /// Constructor which initializes a video section
        /// </summary>
        /// <param name="secName"></param>
        /// <param name="fStart"></param>
        /// <param name="fEnd"></param>
        public VideoFrameSection(String secName, Int32 fStart, Int32 fEnd)
        {
            _SectionName = secName;
            _FrameStart = fStart;
            _FrameEnd = fEnd;
            _FramesToDelete = new VideoFrameList();
            _FramesToDuplicate = new VideoFrameList();
        }

        /// <summary>
        /// Get the count of frames to delete
        /// </summary>
        public int CountToDelete
        {
            get
            {
                return _FramesToDelete.Count;
            }
        }

        /// <summary>
        /// Get the count of frames to duplicate
        /// </summary>
        public int CountToDuplicate
        {
            get
            {
                return _FramesToDuplicate.Count;
            }
        }

        /// <summary>
        /// The name of this section
        /// </summary>
        public String SectionName
        {
            get
            {
                return _SectionName;
            }
            set
            {
                _SectionName = value;
            }
        }

        public void AddToDelete(VideoFrame vf)
        {
            VideoFrame nvf = vf.Clone();
            vf.ProcessType = FrameProcessType.ToDelete;
            nvf.ProcessType = FrameProcessType.ToDelete;
            _FramesToDelete.Add(nvf);
        }

        public void RemoveToDelete(VideoFrame vf)
        {
            _FramesToDelete.Remove(vf);
        }

        public void RemoveToDeleteAt(int idx)
        {
            _FramesToDelete.RemoveAt(idx);
        }

        public void ClearToDelete()
        {
            _FramesToDelete.Clear();
        }

        public void AddToDuplicate(VideoFrame vf)
        {
            VideoFrame nvf = vf.Clone();
            vf.ProcessType = FrameProcessType.ToDuplicate;
            nvf.ProcessType = FrameProcessType.ToDuplicate;
            nvf.DuplicateTimes = 1;
            _FramesToDuplicate.Add(nvf);
        }

        public void AddToDuplicate(VideoFrame vf, Int32 dupTimes)
        {
            VideoFrame nvf = vf.Clone();
            vf.ProcessType = FrameProcessType.ToDuplicate;
            vf.DuplicateTimes = dupTimes;
            nvf.ProcessType = FrameProcessType.ToDuplicate;
            nvf.DuplicateTimes = dupTimes;
            _FramesToDuplicate.Add(nvf);
        }


        public void RemoveToDuplicate(VideoFrame vf)
        {
            _FramesToDuplicate.Remove(vf);
        }

        public void RemoveToDuplicateAt(int idx)
        {
            _FramesToDuplicate.RemoveAt(idx);
        }

        public void ClearToDuplicate()
        {
            _FramesToDuplicate.Clear();
        }

        /// <summary>
        /// Returns the string to write to the kienzan avs
        /// It contains all the delete and duplicate frames
        /// statement accordingly
        /// </summary>
        /// <returns></returns>
        public String KienzanString()
        {
            //Create the string builder
            StringBuilder sb = new StringBuilder();
            //Write the comment line for the section
            sb.AppendFormat("#{0} FramesDeleted : {1} FramesDuplicated : {2}", _SectionName, 
                _FramesToDelete.Count, _FramesToDuplicate.Count);
            sb.AppendLine();
            //Write the first trim 
            sb.AppendFormat("{0} = trim(original, 0, {1})", _SectionName, _FrameEnd);
            sb.AppendLine();

            //Write the delete frames (if any)
            if (_FramesToDelete.Count > 0)
            {
                //Ensure sorted list by frame number 
                //Descending sorting order to avoid clumsy remapping later
                _FramesToDelete.Sort(VideoFrameList.SortType.ByFrameNumber, VideoFrameList.SortOrder.Descending);

                //Create counter
                Int32 framesDeleted = 0;

                //Write filter first
                sb.AppendFormat("{0} = DeleteFrame({1}", _SectionName, _SectionName);
                foreach (VideoFrame vf in _FramesToDelete.FrameList)
                {
                    if (framesDeleted == 900)
                    {
                        //Close the previous filter
                        sb.AppendLine(")");
                        //Begin a new one
                        sb.AppendFormat("{0} = DeleteFrame({1}", _SectionName, _SectionName);
                        //Write the frame
                        sb.AppendFormat(", {0}", vf.FrameNumber.ToString());
                        //Reset the counter
                        framesDeleted = 1;
                    }
                    else
                    {
                        //Write the frame
                        sb.AppendFormat(", {0}", vf.FrameNumber.ToString());
                        //Increase the counter
                        framesDeleted++;
                    }
                }
                //Close the last filter
                sb.AppendLine(")");
            }

            //Write the remapped duplicate frames (if any)
            if (_FramesToDuplicate.Count > 0)
            {
                //Create new remapped list of duplicate frames
                //First Delete the frames
                //So remap the frames to duplicate
                VideoFrameList remappedFramesToDuplicate = this.RemappedDuplicates();
                //Ensure sorted list by frame number
                //Descending sorting order to avoid clumsy remapping later
                remappedFramesToDuplicate.Sort(VideoFrameList.SortType.ByFrameNumber, VideoFrameList.SortOrder.Descending);

                //Create counter
                Int32 framesDuplicated = 0;

                //Write filter first
                sb.AppendFormat("{0} = DuplicateFrame({1}", _SectionName, _SectionName);

                foreach (VideoFrame vf in remappedFramesToDuplicate.FrameList)
                {
                    if (framesDuplicated == 900)
                    {
                        //Close the previous filter
                        sb.AppendLine(")");
                        //Begin a new one
                        sb.AppendFormat("{0} = DuplicateFrame({1}", _SectionName, _SectionName);
                        //Write the frame
                        sb.AppendFormat(", {0}", vf.FrameNumber.ToString());
                        //Reset the counter
                        framesDuplicated = 1;
                    }
                    else
                    {
                        //Write the frame
                        sb.AppendFormat(", {0}", vf.FrameNumber.ToString());
                        //Increase the counter
                        framesDuplicated++;
                    }
                }
                //Close the last filter
                sb.AppendLine(")");
            }

            //If framestart = 0 then there is no reason for the final trim
            if (_FrameStart > 0)
            {
                //Write the final trim
                sb.AppendFormat("{0} = trim({1}, {2}, 0)", _SectionName, _SectionName, _FrameStart);
                sb.AppendLine();
            }
            return sb.ToString();
        }

        /// <summary>
        /// Returns a VideoFrameList with the remapped duplicates of this section
        /// taking in mind the frames to delete
        /// </summary>
        /// <returns></returns>
        public VideoFrameList RemappedDuplicates()
        {
            //Merge the frame lists
            VideoFrameList mergeList = VideoFrameList.Merge(_FramesToDelete, _FramesToDuplicate);
            //Sort the merge list by frame number
            mergeList.Sort(VideoFrameList.SortType.ByFrameNumber, VideoFrameList.SortOrder.Ascending);

            //Create new remapped list of duplicate frames
            VideoFrameList remappedFramesToDuplicate = new VideoFrameList();

            //Remap the frames to duplicate
            Int32 framesDeletedSoFar = 0;
            foreach (VideoFrame vf in mergeList.FrameList)
            {
                if (vf.ProcessType == FrameProcessType.ToDelete)
                {
                    //Increase the counter
                    framesDeletedSoFar++;
                    continue;
                }
                else if (vf.ProcessType == FrameProcessType.ToDuplicate)
                {
                    //Remap the frame number
                    vf.FrameNumber -= framesDeletedSoFar;
                    //Add it many times according to duplicate times
                    for (int i = 0; i < vf.DuplicateTimes; i++)
                    {
                        //Add it to the remapped list
                        remappedFramesToDuplicate.Add(vf);
                    }
                }
            }
            return remappedFramesToDuplicate;
        }

        public Decimal TotalCutTime()
        {
            Decimal totTime = 0.0m;
            foreach (VideoFrame vf in _FramesToDelete.FrameList)
            {
                totTime += vf.FrameDuration;
            }
            return totTime;
        }

        public Decimal TotalCutTime(Int32 start, Int32 end)
        {
            Decimal totTime = 0.0m;
            foreach (VideoFrame vf in _FramesToDelete.FrameList)
            {
                if (vf.FrameNumber >= start && vf.FrameNumber <= end)
                {
                    totTime += vf.FrameDuration;
                }
            }
            return totTime;
        }

        public Decimal TotalAddTime()
        {
            Decimal totTime = 0.0m;
            foreach (VideoFrame vf in _FramesToDuplicate.FrameList)
            {
                totTime += vf.FrameDuration;
            }
            return totTime;
        }

        public Decimal TotalAddTime(Int32 start, Int32 end)
        {
            Decimal totTime = 0.0m;
            foreach (VideoFrame vf in _FramesToDuplicate.FrameList)
            {
                if (vf.FrameNumber >= start && vf.FrameNumber <= end)
                {
                    totTime += vf.FrameDuration;
                }
            }
            return totTime;
        }

        /// <summary>
        /// The string representation of the Video Frame Section
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("{0}: ({1}, {2})", _SectionName, _FrameStart, _FrameEnd); ;
        }

        /// <summary>
        /// A String to write this section to a file
        /// </summary>
        /// <returns></returns>
        public String StringForFile()
        {
            String secName = _SectionName;
            if (secName.Length < 1)
            {
                secName = "Section";
            }
            return String.Format("{0} = trim({1}, {2})", secName, _FrameStart, _FrameEnd);
        }

    }
}
