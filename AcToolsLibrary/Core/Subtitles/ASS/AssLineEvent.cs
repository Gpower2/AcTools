using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace AcToolsLibrary.Core.Subtitles.ASS
{
    public enum AssEventTypes
    {
        Dialogue,
        Comment,
        Picture,
        Sound,
        Movie,
        Command
    }

    public class AssLineEvent
    {
        private AssEventTypes _EventType;
        private String _Marked;
        private String _Layer;
        private String _Start;
        private String _End;
        private String _Style;
        private String _Name;
        private String _MarginL;
        private String _MarginR;
        private String _MarginV;
        private String _Effect;
        private String _Text;

        private String _EventTypeValue;
        private Boolean _MarkedValue;
        private Int32 _LayerValue;
        private Int64 _StartValue;
        private Int64 _EndValue;
        private String _StyleValue;
        private String _NameValue;
        private Int32 _MarginLValue;
        private Int32 _MarginRValue;
        private Int32 _MarginVValue;
        private String _EffectValue;
        private String _TextValue;

        private String _RawData;
        private Int32 _OriginalOrder;

        public AssEventTypes EventType
        {
            get { return _EventType; }
            set 
            {
                _EventType = value;
                _EventTypeValue = Enum.GetName(typeof(AssEventTypes), value);
            }
        }

        public String Marked
        {
            get { return _Marked; }
            set
            {
                _Marked = value;
                _MarkedValue = Convert.ToInt32(value.Trim()) == 1;
            }
        }

        public String Layer
        {
            get { return _Layer; }
            set
            {
                _Layer = value;
                _LayerValue = Convert.ToInt32(value.Trim());
            }
        }

        public String Start
        {
            get { return _Start; }
            set
            {
                _Start = value;
                _StartValue = GetTimeInMs(value);
            }
        }

        public String End
        {
            get { return _End; }
            set
            {
                _End = value;
                _EndValue = GetTimeInMs(value);
            }
        }

        public String Style
        {
            get { return _Style; }
            set
            {
                _Style = value;
                _StyleValue = value;
            }
        }

        public String Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                _NameValue = value;
            }
        }

        public String MarginL
        {
            get { return _MarginL; }
            set
            {
                _MarginL = value;
                _MarginLValue = Convert.ToInt32(value.Trim());
            }
        }

        public String MarginR
        {
            get { return _MarginR; }
            set
            {
                _MarginR = value;
                _MarginRValue = Convert.ToInt32(value.Trim());
            }
        }

        public String MarginV
        {
            get { return _MarginV; }
            set
            {
                _MarginV = value;
                _MarginVValue = Convert.ToInt32(value.Trim());
            }
        }

        public String Effect
        {
            get { return _Effect; }
            set
            {
                _Effect = value;
                _EffectValue = value;
            }
        }

        public String Text
        {
            get { return _Text; }
            set
            {
                _Text = value;
                _TextValue = value;
            }
        }

        public String EventTypeValue
        {
            get { return _EventTypeValue; }
            set
            {
                _EventType = (AssEventTypes)Enum.Parse(typeof(AssEventTypes), value);
                _EventTypeValue = value;
            }
        }

        public Boolean MarkedValue
        {
            get { return _MarkedValue; }
            set
            {
                _MarkedValue = value;
                _Marked = _MarkedValue ? "1" : "0";
            }
        }

        public Int32 LayerValue
        {
            get { return _LayerValue; }
            set
            {
                _Layer = value.ToString();
                _LayerValue = value;
            }
        }

        public Int64 StartValue
        {
            get { return _StartValue; }
            set
            {
                _Start = GetTimeFromMs(value);
                _StartValue = value;
            }
        }

        public Int64 EndValue
        {
            get { return _EndValue; }
            set
            {
                _End = GetTimeFromMs(value);
                _EndValue = value;
            }
        }

        public String StyleValue
        {
            get { return _StyleValue; }
            set
            {
                _StyleValue = value;
                _Style = value;
            }
        }

        public String NameValue
        {
            get { return _NameValue; }
            set
            {
                _NameValue = value;
                _Name = value;
            }
        }

        public Int32 MarginLValue
        {
            get { return _MarginLValue; }
            set
            {
                _MarginL = value.ToString("#0");
                _MarginLValue = value;
            }
        }

        public Int32 MarginRValue
        {
            get { return _MarginRValue; }
            set
            {
                _MarginR = value.ToString("#0");
                _MarginRValue = value;
            }
        }

        public Int32 MarginVValue
        {
            get { return _MarginVValue; }
            set
            {
                _MarginV = value.ToString("#0");
                _MarginVValue = value;
            }
        }

        public String EffectValue
        {
            get { return _EffectValue; }
            set
            {
                _EffectValue = value;
                _Effect = value;
            }
        }

        public String TextValue
        {
            get { return _TextValue; }
            set 
            {
                _TextValue = value;
                _Text = value;
            }
        }


        public String RawData
        {
            get { return _RawData; }
            set { _RawData = value; }
        }

        public Int32 OriginalOrder
        {
            get { return _OriginalOrder; }
            set { _OriginalOrder = value; }
        }

        public Int64 Duration
        {
            get { return _EndValue - _StartValue; }
        }

        /// <summary>
        /// Returns the time in ms from an ASS time string
        /// </summary>
        /// <param name="timeString"></param>
        /// <returns></returns>
        public Int64 GetTimeInMs(String timeString)
        {
            try
            {
                return Convert.ToInt64(TimeSpan.ParseExact(timeString, 
                    @"h\:mm\:ss\.ff", System.Globalization.CultureInfo.InvariantCulture).TotalMilliseconds);

                //Int64 startTime = 0;
                //String[] fields = timeString.Split(new String[] { ":" }, StringSplitOptions.None);
                //startTime = Convert.ToInt64(fields[0]) * 60 * 60 * 1000 +
                //            Convert.ToInt64(fields[1]) * 60 * 1000 +
                //            Convert.ToInt64(fields[2].Substring(0, 2)) * 1000 +
                //            Convert.ToInt64(fields[2].Substring(3, 2)) * 10;
                //return startTime;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return -1;
            }
        }

        /// <summary>
        /// Gets an ASS time string from time value in ms
        /// </summary>
        /// <param name="timeMs"></param>
        /// <returns></returns>
        public String GetTimeFromMs(Int64 timeMs)
        {
            try
            {

                return TimeSpan.FromMilliseconds(timeMs).ToString(@"h\:mm\:ss\.ff");


                //String startTime = String.Empty;
                //Int32 hours, minutes, seconds, deciSeconds;

                ////Hours
                //hours = Convert.ToInt32(Math.Floor(Convert.ToDouble(timeMs) / (60.0 * 60.0 * 1000.0)));
                ////minutes
                //minutes = Convert.ToInt32(Math.Floor((Convert.ToDouble(timeMs - (hours * 60 * 60 * 1000)) / (60.0 * 1000.0))));
                ////seconds
                //seconds = Convert.ToInt32(Math.Floor(Convert.ToDouble(timeMs - (hours * 60 * 60 * 1000) - (minutes * 60 * 1000)) / (1000.0)));
                ////deciseconds
                //deciSeconds = Convert.ToInt32(Math.Floor(Convert.ToDouble(timeMs - (hours * 60 * 60 * 1000) - (minutes * 60 * 1000) - (seconds * 1000)) / 10.0));

                //startTime = hours.ToString("0") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00") + "." + deciSeconds.ToString("00");
                //return startTime;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return String.Empty;
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public AssLineEvent()
        {

        }

        public override string ToString()
        {
            String strFormat = "{0}: {1},{2},{3},{4},{5},{6},{7},{8},{9},{10}";
            return 
                String.Format(strFormat, _EventTypeValue, _Layer, _Start, _End, _Style, _Name, _MarginL, _MarginR, _MarginV, _Effect, _Text);
        }
    }
}
