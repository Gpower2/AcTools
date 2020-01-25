using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace AcToolsLibrary.Core.Video.VideoProviders.VapourSynth
{
    public class VapourSynthClip
    {
        /// <summary>
        /// Initialize the available scripting runtimes, returns zero on failure
        /// </summary>
        /// <returns></returns>
        [DllImport(@"C:\Program Files (x86)\VapourSynth-32\core\vsscript.dll", CharSet = CharSet.Ansi)]
        private static extern int vsscript_init();

        /// <summary>
        /// Free all scripting runtimes
        /// </summary>
        /// <returns></returns>
        [DllImport(@"C:\Program Files (x86)\VapourSynth-32\core\vsscript.dll", CharSet = CharSet.Ansi)]
        private static extern int vsscript_finalize();

        /// <summary>
        /// Get the api version 
        /// </summary>
        /// <returns></returns>
        [DllImport(@"C:\Program Files (x86)\VapourSynth-32\core\vsscript.dll", CharSet = CharSet.Ansi)] 
        private static extern int vsscript_getApiVersion();

        /// <summary>
        /// Create an empty environment for use in later invocations, mostly useful to set script variables before execution
        /// </summary>
        /// <param name="VSScriptHandle"></param>
        /// <returns></returns>
        [DllImport(@"C:\Program Files (x86)\VapourSynth-32\core\vsscript.dll", CharSet = CharSet.Ansi)]
        private static extern int vsscript_createScript(ref IntPtr VSScriptHandle);

        /// <summary>
        /// Pass a pointer to a null handle to create a new one
        /// The values returned by the query functions are only valid during the lifetime of the VSScript
        /// scriptFilename is if the error message should reference a certain file, NULL allowed in vsscript_evaluateScript()
        /// core is to pass in an already created instance so that mixed environments can be used,
        /// NULL creates a new core that can be fetched with vsscript_getCore() later OR implicitly uses the one associated with an already existing handle when passed
        /// If efSetWorkingDir is passed to flags the current working directory will be changed to the path of the script
        /// note that if scriptFilename is NULL in vsscript_evaluateScript() then __file__ won't be set and the working directory won't be changed
        /// Set efSetWorkingDir to get the default and recommended behavior
        /// </summary>
        /// <param name="VSScriptHandle"></param>
        /// <param name="script"></param>
        /// <param name="scriptFilename"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        [DllImport(@"C:\Program Files (x86)\VapourSynth-32\core\vsscript.dll", CharSet = CharSet.Ansi)]
        private static extern int vsscript_evaluateScript(ref IntPtr VSScriptHandle, string script, string scriptFilename, int flags);

        /// <summary>
        /// Convenience version that loads the script from a file
        /// </summary>
        /// <param name="VSScriptHandle"></param>
        /// <param name="scriptFilename"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        [DllImport(@"C:\Program Files (x86)\VapourSynth-32\core\vsscript.dll", CharSet = CharSet.Ansi)]
        private static extern int vsscript_evaluateFile(ref IntPtr VSScriptHandle, string scriptFilename, int flags);

       
        [DllImport(@"C:\Program Files (x86)\VapourSynth-32\core\vsscript.dll", CharSet = CharSet.Ansi)]
        private static extern void vsscript_freeScript(IntPtr VSScriptHandle);


        [DllImport(@"C:\Program Files (x86)\VapourSynth-32\core\vsscript.dll", CharSet = CharSet.Ansi)]
        private static extern string vsscript_getError(IntPtr VSScriptHandle);

        /// <summary>
        /// The node returned must be freed using freeNode() before calling vsscript_freeScript() 
        /// </summary>
        /// <param name="VSScriptHandle"></param>
        /// <param name="index"></param>
        /// <returns>VSNodeRef</returns>
        [DllImport(@"C:\Program Files (x86)\VapourSynth-32\core\vsscript.dll", CharSet = CharSet.Ansi)]
        private static extern IntPtr vsscript_getOutput(IntPtr VSScriptHandle, int index);

        /// <summary>
        /// Unset an output index
        /// </summary>
        /// <param name="VSScriptHandle"></param>
        /// <param name="index"></param>
        [DllImport(@"C:\Program Files (x86)\VapourSynth-32\core\vsscript.dll", CharSet = CharSet.Ansi)]
        private static extern int vsscript_clearOutput(IntPtr VSScriptHandle, int index);

        /// <summary>
        /// The core is valid as long as the environment exists
        /// </summary>
        /// <param name="VSScriptHandle"></param>
        /// <returns>VSCore</returns>
        [DllImport(@"C:\Program Files (x86)\VapourSynth-32\core\vsscript.dll", CharSet = CharSet.Ansi)]
        private static extern IntPtr vsscript_getCore(IntPtr VSScriptHandle);

        /// <summary>
        /// Convenience function for retrieving a vsapi pointer
        /// deprecated as of api 3.2 since it's impossible to tell the api version supported
        /// </summary>
        /// <returns>VSAPI</returns>
        [DllImport(@"C:\Program Files (x86)\VapourSynth-32\core\vsscript.dll", CharSet = CharSet.Ansi)]
        private static extern IntPtr vsscript_getVSApi();

        /// <summary>
        /// api 3.2, generally you should pass VAPOURSYNTH_API_VERSION
        /// </summary>
        /// <param name="version"></param>
        /// <returns>VSAPI</returns>
        [DllImport(@"C:\Program Files (x86)\VapourSynth-32\core\vsscript.dll", CharSet = CharSet.Ansi)]
        private static extern IntPtr vsscript_getVSApi2(int version);

        /// <summary>
        /// Tries to clear everything set in an environment, normally it is better to simply free an environment completely and create a new one 
        /// </summary>
        /// <param name="VSScriptHandle"></param>
        [DllImport(@"C:\Program Files (x86)\VapourSynth-32\core\vsscript.dll", CharSet = CharSet.Ansi)]
        private static extern void vsscript_clearEnvironment(IntPtr VSScriptHandle);


        private IntPtr _vs = new IntPtr(0);

        public void OpenScript(string scriptFilename)
        {
            int res = vsscript_init();

            if (res == 0)
            {
                throw new Exception($"Failed to call {nameof(vsscript_init)}!");
            }

            int vsVersion = vsscript_getApiVersion();

            IntPtr vsApiHandle = vsscript_getVSApi2(vsVersion);
            if (vsApiHandle == IntPtr.Zero)
            {
                throw new Exception($"Failed to call {nameof(vsscript_getVSApi2)}!");
            }

            IntPtr vsScriptHandle = IntPtr.Zero;
            res = vsscript_createScript(ref vsScriptHandle);
            if (vsScriptHandle == IntPtr.Zero)
            {                
                throw new Exception($"Failed to call {nameof(vsscript_createScript)}!");
            }

            res = vsscript_evaluateFile(ref vsScriptHandle, scriptFilename, 0);            
            if (res == 0)
            {
                string error = vsscript_getError(vsScriptHandle);
                throw new Exception($"Failed to call {nameof(vsscript_createScript)} with error: '{error}'!");
            }

            IntPtr vsNodeHandle = vsscript_getOutput(vsScriptHandle, 0);
            if (vsNodeHandle == IntPtr.Zero)
            {
                string error = vsscript_getError(vsScriptHandle);
                throw new Exception($"Failed to call {nameof(vsscript_createScript)} with error: '{error}'!");
            }

            //g_vsinfo = vsApiHandle->getVideoInfo(vsNodeHandle);

            //if (!g_vsinfo)
            //    throw;

        }
    }
}
