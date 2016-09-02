using System.Diagnostics;

namespace CashJobSite.Application.Logging
{
    public class Logger : ILogger
    {
        public void Debug(string message)
        {
            Trace.WriteLine("Debug - " + message);
        }

        public void Info(string message)
        {
            Trace.WriteLine("Info - " + message);
        }

        public void Warn(string message)
        {
            Trace.WriteLine("Warn - " + message);
        }

        public void Error(string message)
        {
            Trace.WriteLine("Error - " + message);
        }
    }
}