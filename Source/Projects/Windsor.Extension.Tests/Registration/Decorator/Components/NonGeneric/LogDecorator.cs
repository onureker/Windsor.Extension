using System;

namespace Windsor.Extension.Tests.Registration.Decorator.Components.NonGeneric
{
    internal class LogDecorator : ICalculator
    {
        private readonly ICalculator decorated;
        private readonly ExecutionStack executionStack;

        public LogDecorator(ICalculator decorated, ExecutionStack executionStack)
        {
            this.decorated = decorated;
            this.executionStack = executionStack;
        }

        public int Sum(Guid executionId, int x, int y)
        {
            var result = decorated.Sum(executionId, x, y);
            executionStack.PushInstance(executionId, this);
            Console.WriteLine("Sum executed");
            return result;
        }
    }
}