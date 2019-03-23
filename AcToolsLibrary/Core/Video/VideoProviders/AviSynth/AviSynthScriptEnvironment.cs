using System;
using System.Collections.Generic;
using System.Text;

namespace AcToolsLibrary.Core.Video.VideoProviders.AviSynth
{
    public sealed class AviSynthScriptEnvironment : IDisposable
    {
        // Methods
        public static string GetLastError()
        {
            return null;
        }

        public AviSynthClip OpenScriptFile(string filePath)
        {
            return this.OpenScriptFile(filePath, AviSynthColorspace.RGB24);
        }

        public AviSynthClip OpenScriptFile(string filePath, AviSynthColorspace forceColorspace)
        {
            return new AviSynthClip("Import", filePath, forceColorspace, this);
        }

        public AviSynthClip ParseScript(string script)
        {
            return this.ParseScript(script, AviSynthColorspace.RGB24);
        }

        public AviSynthClip ParseScript(string script, AviSynthColorspace forceColorspace)
        {
            return new AviSynthClip("Eval", script, forceColorspace, this);
        }

        void IDisposable.Dispose()
        {
        }

        // Properties
        public IntPtr Handle
        {
            get
            {
                return new IntPtr(0);
            }
        }
    }
}
