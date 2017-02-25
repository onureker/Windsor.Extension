namespace Windsor.Extension.Demo.Sample.ResolveByName
{
    public class ResolveByNameDemo
    {
        private readonly ILogger logger;
        private readonly ILogger consoleLogger;
        private readonly ILogger traceLogger;

        public ResolveByNameDemo(ILogger logger, ILogger consoleLogger, ILogger traceLogger)
        {
            this.logger = logger;
            this.consoleLogger = consoleLogger;
            this.traceLogger = traceLogger;
        }

        public void Run()
        {
            logger.Log("This is default logger");
            consoleLogger.Log("This is console message");
            traceLogger.Log("This is trace message");
        }
    }
}