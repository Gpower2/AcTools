using System;
using System.Collections.Generic;
using System.Text;

namespace AcToolsLibrary.Core.Subtitles.ASS
{
    public enum AssEventsSortType
    {
        ByStartTime,
        ByEndTime,
        ByStyle,
        ByEventType,
        ByOriginalOrder
    }

    public enum SortOrder
    {
        Ascending,
        Descending
    }

    public class AssSectionEvents
    {
        public static String SECTION_HEADER = "[Events]";

        private List<String> _comments = new List<String>();
        private List<AssLineEvent> _eventLines = new List<AssLineEvent>();
        private Dictionary<String, Int32> _fieldIndex = new Dictionary<String, Int32>();

        public List<String> Comments
        {
            get { return _comments; }
        }
        
        public List<AssLineEvent> EventLines
        {
            get { return _eventLines; }
        }

        public Dictionary<String, Int32> FieldDictionary
        {
            get { return _fieldIndex; }
        }

        public void FallbackToDefaultDictionary()
        {
            //clear the dictionary
            _fieldIndex.Clear();

            //fill with default data
            _fieldIndex.Add("Layer", 0);
            _fieldIndex.Add("Start", 1);
            _fieldIndex.Add("End", 2);
            _fieldIndex.Add("Style", 3);
            _fieldIndex.Add("Name", 4);
            _fieldIndex.Add("MarginL", 5);
            _fieldIndex.Add("MarginR", 6);
            _fieldIndex.Add("MarginV", 7);
            _fieldIndex.Add("Effect", 8);
            _fieldIndex.Add("Text", 9);
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public AssSectionEvents()
        {

        }

        /// <summary>
        /// Sorts the event lines according to the sort type and order
        /// </summary>
        /// <param name="sortType"></param>
        /// <param name="order"></param>
        public void SortEventLines(AssEventsSortType sortType, SortOrder order)
        {
            switch (sortType)
            {
                case AssEventsSortType.ByEndTime:
                    switch (order)
                    {
                        case SortOrder.Ascending:
                            _eventLines.Sort(CompareEventLinesByEndTimeAsc);
                            break;
                        case SortOrder.Descending:
                            _eventLines.Sort(CompareEventLinesByEndTimeDesc);
                            break;
                    }
                    break;
                case AssEventsSortType.ByEventType:
                    switch (order)
                    {
                        case SortOrder.Ascending:
                            _eventLines.Sort(CompareEventLinesByEventTypeAsc);
                            break;
                        case SortOrder.Descending:
                            _eventLines.Sort(CompareEventLinesByEventTypeDesc);
                            break;
                    }
                    break;
                case AssEventsSortType.ByStartTime:
                    switch (order)
                    {
                        case SortOrder.Ascending:
                            _eventLines.Sort(CompareEventLinesByStartTimeAsc);
                            break;
                        case SortOrder.Descending:
                            _eventLines.Sort(CompareEventLinesByStartTimeDesc);
                            break;
                    }
                    break;
                case AssEventsSortType.ByStyle:
                    switch (order)
                    {
                        case SortOrder.Ascending:
                            _eventLines.Sort(CompareEventLinesByStyleAsc);
                            break;
                        case SortOrder.Descending:
                            _eventLines.Sort(CompareEventLinesByStyleDesc);
                            break;
                    }
                    break;
                case AssEventsSortType.ByOriginalOrder:
                    switch (order)
                    {
                        case SortOrder.Ascending:
                            _eventLines.Sort(CompareEventLinesByOriginalOrderAsc);
                            break;
                        case SortOrder.Descending:
                            _eventLines.Sort(CompareEventLinesByOriginalOrderDesc);
                            break;
                    }
                    break;
            }
        }

        private int CompareEventLinesByStartTimeAsc(AssLineEvent x, AssLineEvent y)
        {
            if (x.StartValue > y.StartValue)
            {
                return 1;
            }
            else if (x.StartValue < y.StartValue)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private int CompareEventLinesByStartTimeDesc(AssLineEvent x, AssLineEvent y)
        {
            if (x.StartValue < y.StartValue)
            {
                return 1;
            }
            else if (x.StartValue > y.StartValue)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private int CompareEventLinesByEndTimeAsc(AssLineEvent x, AssLineEvent y)
        {
            if (x.EndValue > y.EndValue)
            {
                return 1;
            }
            else if (x.EndValue < y.EndValue)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private int CompareEventLinesByEndTimeDesc(AssLineEvent x, AssLineEvent y)
        {
            if (x.EndValue < y.EndValue)
            {
                return 1;
            }
            else if (x.EndValue > y.EndValue)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private int CompareEventLinesByOriginalOrderAsc(AssLineEvent x, AssLineEvent y)
        {
            if (x.OriginalOrder > y.OriginalOrder)
            {
                return 1;
            }
            else if (x.OriginalOrder < y.OriginalOrder)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private int CompareEventLinesByOriginalOrderDesc(AssLineEvent x, AssLineEvent y)
        {
            if (x.OriginalOrder < y.OriginalOrder)
            {
                return 1;
            }
            else if (x.OriginalOrder > y.OriginalOrder)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private int CompareEventLinesByStyleAsc(AssLineEvent x, AssLineEvent y)
        {
            return x.Style.CompareTo(y.Style);
        }

        private int CompareEventLinesByStyleDesc(AssLineEvent x, AssLineEvent y)
        {
            return y.Style.CompareTo(x.Style);
        }

        private int CompareEventLinesByEventTypeAsc(AssLineEvent x, AssLineEvent y)
        {
            return x.EventTypeValue.CompareTo(y.EventTypeValue);
        }

        private int CompareEventLinesByEventTypeDesc(AssLineEvent x, AssLineEvent y)
        {
            return y.EventTypeValue.CompareTo(x.EventTypeValue);
        }

    }
}
