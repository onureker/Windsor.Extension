using System.Diagnostics;

namespace Windsor.Extension.Demo.Sample.ResolveByName
{
    public class TraceLogger : ILogger
    {
        public void Log(string message)
        {
            Trace.WriteLine(message);
        }
    }
}