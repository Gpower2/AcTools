using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AcToolsLibrary.Common
{
    /// <summary>
    /// Log Levels
    /// </summary>
    public enum AcLogLevel
    {
        Debug,
        User,
        System,
        Info,
        Warning,
        Error,
        Fatal
    }

    /// <summary>
    /// Log Type (File or Logger)
    /// </summary>
    public enum AcLogType
    {
        /// <summary>
        /// Logs the message to the log file
        /// </summary>
        File,
        /// <summary>
        /// Logs the message to the Logger Object
        /// </summary>
        Logger,
        /// <summary>
        /// Logs the message to the log file and to the Logger Object
        /// </summary>
        FileAndLogger
    }

    /// <summary>
    /// Provides static methods to Write logs to a log file or to Logger Form
    /// </summary>
    public class AcLogger
    {
        public static String LOG_FILE = "log.txt";
        public static String DEBUG_FILE = "debug.txt";

        private static StringBuilder _LogBuilder = new StringBuilder();
        private static StringBuilder _DebugBuilder = new StringBuilder();

        public static String LogMessages
        {
            get { return _LogBuilder.ToString(); }
        }

        public static String DebugMessages
        {
            get { return _DebugBuilder.ToString(); }
        }

        /// <summary>
        /// Log to file
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="lType"></param>
        public static void Log(Exception ex, AcLogType lType)
        {
            switch (lType)
            {
                case AcLogType.File:
                    logToFile(ex.ToString(), AcLogLevel.System);
                    break;
                case AcLogType.Logger:
                    logToLogger(ex.ToString(), AcLogLevel.System);
                    break;
                case AcLogType.FileAndLogger:
                    logToFile(ex.ToString(), AcLogLevel.System);
                    logToLogger(ex.ToString(), AcLogLevel.System);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Log to file
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="lType"></param>
        public static void Log(AcException ex, AcLogType lType)
        {
            switch (lType)
            {
                case AcLogType.File:
                    logToFile(String.Format("[{0}]{1}", ex.InnerException.Source, ex.Message), AcLogLevel.Error);
                    break;
                case AcLogType.Logger:
                    logToLogger(String.Format("[{0}]{1}", ex.InnerException.Source, ex.Message), AcLogLevel.Error);
                    break;
                case AcLogType.FileAndLogger:
                    logToFile(String.Format("[{0}]{1}", ex.InnerException.Source, ex.Message), AcLogLevel.Error);
                    logToLogger(String.Format("[{0}]{1}", ex.InnerException.Source, ex.Message), AcLogLevel.Error);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Log to file
        /// </summary>
        /// <param name="str"></param>
        /// <param name="lType"></param>
        public static void Log(String str, AcLogType lType)
        {
            switch (lType)
            {
                case AcLogType.File:
                    logToFile(str, AcLogLevel.User);
                    break;
                case AcLogType.Logger:
                    logToLogger(str, AcLogLevel.User);
                    break;
                case AcLogType.FileAndLogger:
                    logToFile(str, AcLogLevel.User);
                    logToLogger(str, AcLogLevel.User);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Log to file
        /// </summary>
        /// <param name="str"></param>
        /// <param name="exL"></param>
        /// <param name="lType"></param>
        public static void Log(String str, AcLogLevel exL, AcLogType lType)
        {
            switch (lType)
            {
                case AcLogType.File:
                    logToFile(str, exL);
                    break;
                case AcLogType.Logger:
                    logToLogger(str, exL);
                    break;
                case AcLogType.FileAndLogger:
                    logToFile(str, exL);
                    logToLogger(str, exL);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Clear log file
        /// </summary>
        public static void ClearLog()
        {
            using (StreamWriter sw = new StreamWriter(LOG_FILE, false, Encoding.UTF8))
            {
                sw.Write(String.Empty);
            }
        }

        /// <summary>
        /// Clear debug file
        /// </summary>
        public static void ClearDebug()
        {
            using (StreamWriter sw = new StreamWriter(DEBUG_FILE, false, Encoding.UTF8))
            {
                sw.Write(String.Empty);
            }
        }

        /// <summary>
        /// Log to file
        /// </summary>
        /// <param name="str">the message to log</param>
        /// <param name="exLevel">the logging level</param>
        /// <remarks>the debug level messages are written to the debug file</remarks>
        private static void logToFile(String str, AcLogLevel exLevel)
        {
            String logDateStr = DateTime.Now.ToString("[yyyy-MM-dd][hh:mm:ss.fff]");
            StringBuilder textBuilder = new StringBuilder();
            String outputFilename = String.Empty;
            foreach (String logLine in str.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (exLevel == AcLogLevel.Debug)
                {
                    outputFilename = DEBUG_FILE;
                    textBuilder.AppendFormat("{0} {1}\r\n", logDateStr, logLine);
                }
                else
                {
                    outputFilename = LOG_FILE;
                    textBuilder.AppendFormat("{0}[{1}] {2}\r\n", logDateStr, Enum.GetName(typeof(AcLogLevel), exLevel), logLine);
                }
            }
            using (StreamWriter sw = new StreamWriter(outputFilename, true, Encoding.UTF8))
            {
                sw.Write(textBuilder.ToString());
            }
        }

        /// <summary>
        /// Log to Logger
        /// </summary>
        /// <param name="str">the message to log</param>
        /// <param name="exLevel">the logging level</param>
        private static void logToLogger(String str, AcLogLevel exLevel)
        {
            String logDateStr = DateTime.Now.ToString("[yyyy-MM-dd][hh:mm:ss.fff]");
            foreach (String logLine in str.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (exLevel == AcLogLevel.Debug)
                {
                    _DebugBuilder.AppendFormat("{0} {1}\r\n", logDateStr, logLine);
                }
                else
                {
                    _LogBuilder.AppendFormat("{0}[{1}] {2}\r\n", logDateStr, Enum.GetName(typeof(AcLogLevel), exLevel), logLine);
                }
            }
        }
    }
}
