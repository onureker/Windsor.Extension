using Windsor.Extension.Demo.Sample.ResolveByName;

namespace Windsor.Extension.Demo.Sample.Scope
{
    public class ScopeDemo
    {
        private readonly ILogger logger;

        public ScopeDemo(ILogger logger)
        {
            this.logger = logger;
        }

        public void Run()
        {
            logger.Log("Deneme");
        }
    }
}