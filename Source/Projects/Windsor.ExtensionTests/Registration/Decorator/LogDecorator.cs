using System;

namespace Windsor.ExtensionTests.Registration.Decorator
{
    public class LogDecorator: ICalculator
    {
        private readonly ICalculator decorated;
        private readonly ExecutionRegistry executionRegistry;

        public LogDecorator(ICalculator decorated, ExecutionRegistry executionRegistry)
        {
            this.decorated = decorated;
            this.executionRegistry = executionRegistry;
        }

        public int Sum(Guid executionId, int x, int y)
        {
            var result = decorated.Sum(executionId, x, y);
            Console.WriteLine("Sum executed");
            executionRegistry.Push(executionId, this);
            return result;
        }
    }
}