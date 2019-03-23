﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace AcToolsLibrary.Core.Video.VideoProviders.AviSynth
{
    public class AviSynthException : ApplicationException
    {
        // Methods
        public AviSynthException()
        {
        }

        public AviSynthException(string message)
            : base(message)
        {
        }

        public AviSynthException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public AviSynthException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
