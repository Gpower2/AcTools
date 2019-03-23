using System;
using System.Collections.Generic;
using System.Text;

namespace AcToolsLibrary.Core.Video.VideoProviders.AviSynth.VideoSourceProviders
{
    public enum AviSynthSourceProvidersEnum
    {
        AviSource,
        DirectShowSource,
        DGMPGDec,
        DGAVCDec,
        FFMpegSource2,
        DirectShowSource2
    }

    public interface IAviSynthVideoSourceProvider
    {
        void CreateAviSynthScript(String scriptFilename, String videoFilename);

        void CreateAviSynthScript(String scriptFilename, String videoFilename, Double framerate);

        String GetOpenFileString(String videoFilename);          
    }
}
