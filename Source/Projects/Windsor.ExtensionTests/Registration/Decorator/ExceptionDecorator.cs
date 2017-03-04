using System;

namespace Windsor.ExtensionTests.Registration.Decorator
{
    internal class ExceptionDecorator : ICalculator
    {
        private readonly ICalculator decorated;
        private readonly ExecutionStack executionStack;

        public ExceptionDecorator(ICalculator decorated, ExecutionStack executionStack)
        {
            this.decorated = decorated;
            this.executionStack = executionStack;
        }

        public int Sum(Guid executionId, int x, int y)
        {
            var sum = decorated.Sum(executionId, x, y);
            executionStack.PushInstance(executionId, this);
            return sum;
        }
    }
}