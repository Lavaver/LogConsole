using System.Diagnostics;

namespace LogConsole
{
    public class Log
    {
        private static readonly object _lock = new object();
        private static readonly string logFileName = $"log_{Guid.NewGuid().ToString()}.log";
        private static readonly string logPath = "Log";
        private static TextWriterTraceListener? _traceListener;

        /// <summary>
        /// Get Current Time
        /// </summary>
        /// <param name="withMilliseconds">(optional) determines whether three milliseconds are used (default is no, but this is forced if isError = true is explicitly specified in the use of the Customize method)</param>
        /// <returns>The current local time (with three additional milliseconds if you specify the withMilliseconds parameter to be set to true). (Three additional milliseconds if the withMilliseconds parameter is set to true, but three milliseconds are mandatory if the isError parameter is explicitly specified as true in the Customize method.)</returns>
        private static string GetCurrentTime(bool withMilliseconds = false)
        {
            return withMilliseconds ? $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}" : $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}";
        }

        /// <summary>
        /// Initializing the Logging Module
        /// </summary>
        public static void Initialize()
        {
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }
            _traceListener = new TextWriterTraceListener(Path.Combine(logPath, logFileName));
            Trace.Listeners.Add(_traceListener);
        }


        /// <summary>
        /// Customize logging levels, messages, foreground color and additional parameters
        /// </summary>
        /// <param name="logLevel">Logging Levels</param>
        /// <param name="log">Log Messages</param>
        /// <param name="color">Foreground color</param>
        /// <param name="isError">(Optional) Whether or not to log errors. Default is no (false)</param>
        /// <param name="logToFile">(Optional) Whether to write to the log file. Default is yes (true)</param>
        public static void Customize(string logLevel, string log, ConsoleColor color, bool isError = false, bool logToFile = true)
        {
            lock (_lock)
            {
                string currentTime = GetCurrentTime(isError);
                ConsoleColor originalColor = Console.ForegroundColor;
                try
                {
                    if (isError)
                    {
                        Console.Error.Write($"[{currentTime} / ");
                        Console.ForegroundColor = color;
                        Console.Error.Write($"{logLevel}");
                        Console.ForegroundColor = originalColor;
                        Console.Error.WriteLine($"] {log}");
                    }
                    else
                    {
                        Console.Write($"[{currentTime} / ");
                        Console.ForegroundColor = color;
                        Console.Write($"{logLevel}");
                        Console.ForegroundColor = originalColor;
                        Console.WriteLine($"] {log}");
                    }

                    if (logToFile && _traceListener != null)
                    {
                        Trace.WriteLine($"[{currentTime} / {logLevel}] {log}");
                    }
                }
                catch (Exception ex)
                {
                    HandleException(ex, "General logging error");
                }
                finally
                {
                    Trace.Flush();
                }
            }
        }

        /// <summary>
        /// Handling of exceptions
        /// </summary>
        /// <param name="ex">Exception(s)</param>
        /// <param name="message">Exception(s) Message(s)</param>
        private static void HandleException(Exception ex, string message)
        {
            string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            ConsoleColor originalColor = Console.ForegroundColor;

            Console.Error.Write($"[{currentTime} / ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Error.Write($"LogConsole ERROR");
            Console.ForegroundColor = originalColor;
            Console.Error.WriteLine($"] {message}: {ex.Message}");

            Trace.WriteLine($"[{currentTime} / LogConsole ERROR] {message}: {ex.Message}");
            Trace.WriteLine(ex.StackTrace);
        }
    }
}
