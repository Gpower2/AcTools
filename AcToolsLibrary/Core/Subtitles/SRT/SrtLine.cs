using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcTools.Core.Subtitles.SRT
{
    public class SrtLine
    {
        public Int32 Number { get; set; }
        public Int64 StartTime { get; set; }
        public Int64 EndTime { get; set; }
        public String Text { get; set; }

        public static Int64 GetTimeInMsFromText(string argTime)
        {
            //00:00:35,302
            if (!argTime.Contains(":"))
            {
                return 0;
            }
            if (!argTime.Contains(",") && !argTime.Contains("."))
            {
                return 0;
            }
            String[] timeElements = argTime.Split(new string[] { ":" }, StringSplitOptions.None);
            if(timeElements.Length != 3)
            {
                return 0;
            }
            Int32 hours = Int32.Parse(timeElements[0]);
            Int32 minutes = Int32.Parse(timeElements[1]);
            Int32 seconds = 0;
            Int32 milliSeconds = 0;
            String splitSeparator = string.Empty;
            if (timeElements[2].Contains("."))
            {
                splitSeparator = ".";
            }
            else if (timeElements[2].Contains(","))
            {
                splitSeparator = ",";
            }
            
            if(!String.IsNullOrEmpty(splitSeparator))
            {
                String[] secondsElements = timeElements[2].Split(new string[] { splitSeparator }, StringSplitOptions.None);
                seconds = Int32.Parse(secondsElements[0]);
                milliSeconds = Int32.Parse(secondsElements[1]);
            }

            return Convert.ToInt64(new TimeSpan(0, hours, minutes, seconds, milliSeconds).TotalMilliseconds);
        }

        public static String GetTimeInTextFromMs(Int64 argTime)
        {
            return TimeSpan.FromMilliseconds(argTime).ToString(@"hh\:mm\:ss\,fff", System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
