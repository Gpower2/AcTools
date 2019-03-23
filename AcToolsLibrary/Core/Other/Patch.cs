using System;
using System.Collections.Generic;
using System.Text;

namespace AcToolsLibrary.Core.Other
{
    public class Patch
    {
        String _OldFile = "";
        String _NewFile = "";
        String _DiffFile = "";

        public String OldFile
        {
            get { return _OldFile; }
            set { _OldFile = value; }
        }

        public String NewFile
        {
            get { return _NewFile; }
            set { _NewFile = value; }
        }

        public String DiffFile
        {
            get { return _DiffFile; }
            set { _DiffFile = value; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="of">Old file</param>
        /// <param name="nf">New file</param>
        /// <param name="df">Diff file</param>
        public Patch(String of, String nf, String df)
        {
            _OldFile = of;
            _NewFile = nf;
            _DiffFile = df;
        }

        /// <summary>
        /// Returns the String representation of the Patch
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("\"{0}\" -> \"{1}\" = \"{2}\"", OldFile, NewFile, DiffFile);
        }
    }
}
