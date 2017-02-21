using System;

namespace Windsor.Extension.Demo.Sample.ResolveByName
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}