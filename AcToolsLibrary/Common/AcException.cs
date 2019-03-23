using System;

namespace AcToolsLibrary.Common
{

    [Serializable]
    /// <summary>
    /// Represents a custom made exception 
    /// Reference material:
    /// http://msdn.microsoft.com/en-us/library/87cdya3t%28v=vs.100%29.aspx
    /// </summary>
    public class AcException : Exception
    {
        public AcException()
        {
        }

        public AcException(String message)
            : base(message)
        {
        }

        public AcException(String message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
