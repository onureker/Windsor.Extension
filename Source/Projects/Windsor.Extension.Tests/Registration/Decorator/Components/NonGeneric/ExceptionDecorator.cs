using System;

namespace Windsor.Extension.Tests.Registration.Decorator.Components.NonGeneric
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