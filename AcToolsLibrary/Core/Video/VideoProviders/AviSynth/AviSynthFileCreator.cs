using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using AcToolsLibrary.Core.Video.VideoProviders.AviSynth.VideoSourceProviders;
using AcToolsLibrary.Common;

namespace AcToolsLibrary.Core.Video.VideoProviders.AviSynth
{
    public class AviSynthFileCreator
    {
        private Dictionary<AviSynthSourceProvidersEnum, String> _AviSynthSourceProvidersDictionary = new Dictionary<AviSynthSourceProvidersEnum, string>();
        private String _AvsFilename = "";

        public String AviSynthScriptFilename
        {
            get
            {
                return _AvsFilename;
            }
        }

        /// <summary>
        /// Constructor with a video source provider
        /// </summary>
        /// <param name="filename">the filename of the video</param>
        /// <param name="provider">the video source provider</param>
        public AviSynthFileCreator(String filename, AviSynthSourceProvidersEnum provider)
        {
            fillAvisynthVideoSourceProvidersDictionary();
            //find the last unused filename
            _AvsFilename = AcHelper.GetLastUnusedFilename(filename, "avs", 3);

            IAviSynthVideoSourceProvider avsp = (IAviSynthVideoSourceProvider)Activator.CreateInstance(Type.GetType(_AviSynthSourceProvidersDictionary[provider]));
            avsp.CreateAviSynthScript(_AvsFilename, filename);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="provider"></param>
        /// <param name="frameRate"></param>
        public AviSynthFileCreator(String filename, AviSynthSourceProvidersEnum provider, Double frameRate)
        {
            fillAvisynthVideoSourceProvidersDictionary();
            //find the last unused filename
            _AvsFilename = AcHelper.GetLastUnusedFilename(filename, "avs", 3);

            IAviSynthVideoSourceProvider avsp = (IAviSynthVideoSourceProvider)Activator.CreateInstance(Type.GetType(_AviSynthSourceProvidersDictionary[provider]));
            avsp.CreateAviSynthScript(_AvsFilename, filename, frameRate);
        }

        public AviSynthFileCreator()
        {
            fillAvisynthVideoSourceProvidersDictionary();
        }

        public IAviSynthVideoSourceProvider GetAviSynthVideoSourceProvider(AviSynthSourceProvidersEnum provider)
        {
            return (IAviSynthVideoSourceProvider)Activator.CreateInstance(Type.GetType(_AviSynthSourceProvidersDictionary[provider]));
        }

        private void fillAvisynthVideoSourceProvidersDictionary()
        {
            _AviSynthSourceProvidersDictionary.Add(AviSynthSourceProvidersEnum.AviSource, "AcToolsLibrary.Core.Video.VideoProviders.AviSynth.VideoSourceProviders.AviSourceProvider");
            _AviSynthSourceProvidersDictionary.Add(AviSynthSourceProvidersEnum.DGAVCDec, "AcToolsLibrary.Core.Video.VideoProviders.AviSynth.VideoSourceProviders.DGAVCDecProvider");
            _AviSynthSourceProvidersDictionary.Add(AviSynthSourceProvidersEnum.DGMPGDec, "AcToolsLibrary.Core.Video.VideoProviders.AviSynth.VideoSourceProviders.DGMPGDecProvider");
            _AviSynthSourceProvidersDictionary.Add(AviSynthSourceProvidersEnum.DirectShowSource2, "AcToolsLibrary.Core.Video.VideoProviders.AviSynth.VideoSourceProviders.DirectShowSource2Provider");
            _AviSynthSourceProvidersDictionary.Add(AviSynthSourceProvidersEnum.DirectShowSource, "AcToolsLibrary.Core.Video.VideoProviders.AviSynth.VideoSourceProviders.DirectShowSourceProvider");
            _AviSynthSourceProvidersDictionary.Add(AviSynthSourceProvidersEnum.FFMpegSource2, "AcToolsLibrary.Core.Video.VideoProviders.AviSynth.VideoSourceProviders.FFMpegSource2Provider");
        }
    }
}
