using System;

namespace Windsor.ExtensionTests.Registration.Decorator
{
    public class DefaultCalculator: ICalculator
    {
        private readonly ExecutionRegistry executionRegistry;

        public DefaultCalculator(ExecutionRegistry executionRegistry)
        {
            this.executionRegistry = executionRegistry;
        }

        public int Sum(Guid executionId, int x, int y)
        {
            executionRegistry.Push(executionId, this);
            return x + y;
        }
    }
}