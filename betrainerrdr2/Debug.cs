///////////////////////////////////////////////
//   BE Trainer.NET for Red Dead Redemption 2
//               by BE.Tenner
//        Copyright (c) BE Group 2020
//                Thanks to
//   ScriptHookRdr2 & ScriptHookRdr2DotNet
//             Native Trainer
///////////////////////////////////////////////

using System;
using System.Text;
using System.IO;

namespace BETrainerRdr2
{
    /// <summary>
    /// Debugging tools.
    /// </summary>
    public static class Debug
    {
        // Log file
        private const string LOG_FILE = ".\\scripts\\BETrainerRdr2.log";

        // Log format
        private const string LOG_FORMAT = "[{0:yyyy-MM-dd HH:mm:ss.fff}][{1}] {2}";

        // Log file stream writer
        private static StreamWriter _sw = null;

        // Gets the stream writer for the log file
        private static StreamWriter GetSW()
        {
            _sw = _sw ?? new StreamWriter(LOG_FILE, false, Encoding.UTF8);
            return _sw;
        }

        /// <summary>
        /// Log debug message. (only works in DEBUG mode)
        /// </summary>
        /// <param name="msg">Message</param>
        public static void Log(string msg)
        {
#if DEBUG
            GetSW().WriteLine(string.Format(LOG_FORMAT, DateTime.Now, "Debug", msg));
            GetSW().Flush();
#endif
        }

        /// <summary>
        /// Log debug message in specified format.
        /// </summary>
        /// <param name="format">Message format</param>
        /// <param name="args">Arguments</param>
        public static void Log(string format, params object[] args)
        {
            Log(string.Format(format, args));
        }

        /// <summary>
        /// Log error message.
        /// </summary>
        /// <param name="msg">Message</param>
        public static void LogError(string msg)
        {
            GetSW().WriteLine(string.Format(LOG_FILE, DateTime.Now, "Error", msg));
            GetSW().Flush();
        }

        /// <summary>
        /// Log error message in specified format.
        /// </summary>
        /// <param name="format">Message format</param>
        /// <param name="args">Arguments</param>
        public static void LogError(string format, params object[] args)
        {
            LogError(string.Format(format, args));
        }
    }
}
