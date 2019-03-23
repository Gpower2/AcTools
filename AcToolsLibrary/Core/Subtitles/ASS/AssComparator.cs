using System;
using System.Collections.Generic;
using System.Text;

namespace AcToolsLibrary.Core.Subtitles.ASS
{
    public class AssComparator
    {
        private AssFile _originalFile = null;
        private AssFile _newFile = null;

        public AssComparator()
        {
        }

        public AssComparator(AssFile originalFile, AssFile newFile)
        {
            Compare(originalFile, newFile);
        }

        public AssComparator(String originalFile, String newFile)
        {
            Compare(originalFile, newFile);
        }

        public void Compare(String originalFile, String newFile)
        {
            Compare(new AssFile(originalFile), new AssFile(newFile));
        }

        public void Compare(AssFile originalFile, AssFile newFile)
        {
            _originalFile = originalFile;
            _newFile = newFile;

        }
    }
}
