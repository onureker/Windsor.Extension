namespace Windsor.Extension.Demo.Sample.ResolveByName
{
    public class ResolveByNameDemo
    {
        private readonly ILogger consoleLogger;
        private readonly ILogger traceLogger;

        public ResolveByNameDemo(ILogger consoleLogger, ILogger traceLogger)
        {
            this.consoleLogger = consoleLogger;
            this.traceLogger = traceLogger;
        }

        public void Run()
        {
            consoleLogger.Log("This is console message");
            traceLogger.Log("This is trace message");
        }
    }
}