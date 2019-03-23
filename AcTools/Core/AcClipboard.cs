using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcTools.Core
{
    public static class AcClipboard
    {
        private static List<Object> _ClipboardItems = new List<Object>();
        public static List<Object> ClipboardItems { get { return _ClipboardItems; } }
    }
}
