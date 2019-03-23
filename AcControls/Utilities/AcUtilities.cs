using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace AcControls.Utilities
{
    /// <summary>
    /// Static class that provides utility methods
    /// </summary>
    public static class AcUtilities
    {
        /// <summary>
        /// Writes a debug message to the Debug Stream
        /// with datetime information and stack information
        /// </summary>
        /// <param name="debugMessage"></param>
        public static void DebugWrite(String debugMessage)
        {
            try
            {
                //We want to get the caller method
                StackFrame stFrame = new StackFrame(1, true);
                //Get the current date
                String currentDate = DateTime.Now.ToString("yyyy-MM-dd");
                //Get the current time
                String currentTime = DateTime.Now.ToString("hh:mm:ss.fff");
                //We get all the lines of the message
                String[] debugLines = debugMessage.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                //For each line in the debug message
                foreach (String debugLine in debugLines)
                {
                    StringBuilder debugBuilder = new StringBuilder();
                    debugBuilder.AppendFormat("[{0}][{1}]", currentDate, currentTime);
                    debugBuilder.AppendFormat("[{0}: {1} line {2}]", stFrame.GetFileName(), stFrame.GetMethod().Name, stFrame.GetFileLineNumber());
                    debugBuilder.AppendFormat(" {0}", debugLine);
                    Debug.WriteLine(debugBuilder.ToString());
                }
            }
            catch (Exception ex)
            {
                //Write the exception
                Debug.WriteLine(ex);
                //Write the message so as not to lose it
                Debug.WriteLine(debugMessage);
            }
        }
    }
}
