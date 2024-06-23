using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogConsole
{
    /// <summary>
    /// Built-in common logging levels for quick use in projects. <br/>
    /// To use one of them, just call one of the Info/Warn/Err/Init/Debug/R5 methods + log message. Like this:
    /// <code>
    /// Builtin.Info("This is an info message");
    /// Builtin.Warn("This is a warning message");
    /// Builtin.Err("This is an error message");
    /// </code>
    /// The meaning of these log levels is as follows:
    /// <remarks>
    /// - Info: General information messages. <br/>
    /// - Warn: Warning messages that indicate a potential issue. <br/>
    /// - Err: Error messages indicating a failure. <br/>
    /// - Init: Initialization messages. <br/>
    /// - Debug: Debugging messages. <br/>
    /// - R5: Software Special Operation(s) Messages.
    /// </remarks>
    /// </summary>
    /// <author>Lavaver</author>
    /// <version>1.0</version>
    internal class Builtin
    {
        /// <summary>
        /// Outputting an INFO to a standard output stream
        /// </summary>
        /// <param name="log">Log</param>
        public static void Info(string log)
        {
            Log.Customize("Info", log, ConsoleColor.Green);
        }

        /// <summary>
        /// Outputting WARN to a standard output stream
        /// </summary>
        /// <param name="log">Log</param>
        public static void Warn(string log)
        {
            Log.Customize("WARN", log, ConsoleColor.Yellow);
        }

        /// <summary>
        /// Outputting ERROR to the Error Output Stream
        /// </summary>
        /// <param name="log">Log</param>
        public static void Err(string log)
        {
            Log.Customize("ERROR", log, ConsoleColor.Red, true);
        }

        /// <summary>
        /// Outputting Init to a standard output stream
        /// </summary>
        /// <param name="log">Log</param>
        public static void Init(string log)
        {
            Log.Customize("Init", log, ConsoleColor.Blue);
        }

        /// <summary>
        /// Outputting Debug to a standard output stream
        /// </summary>
        /// <param name="log">Log</param>
        public static void Debug(string log)
        {
            Log.Customize("Debug", log, ConsoleColor.Green);
        }

        /// <summary>
        /// Outputting R5 to a standard output stream
        /// </summary>
        /// <param name="log">日志</param>
        public static void R5(string log)
        {
            Log.Customize("Console R5", log, ConsoleColor.Blue);
        }
    }
}
