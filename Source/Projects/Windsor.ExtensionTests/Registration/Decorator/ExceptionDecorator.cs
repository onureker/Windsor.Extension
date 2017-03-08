using System;

namespace Windsor.ExtensionTests.Registration.Decorator
{
    public class ExceptionDecorator : ICalculator
    {
        private readonly ICalculator decorated;
        private readonly ExecutionRegistry executionRegistry;

        public ExceptionDecorator(ICalculator decorated, ExecutionRegistry executionRegistry)
        {
            this.decorated = decorated;
            this.executionRegistry = executionRegistry;
        }

        public int Sum(Guid executionId, int x, int y)
        {
            var sum = decorated.Sum(executionId, x, y);
            executionRegistry.Push(executionId, this);
            return sum;
        }
    }
}