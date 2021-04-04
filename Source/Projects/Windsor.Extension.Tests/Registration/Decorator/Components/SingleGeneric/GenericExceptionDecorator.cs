using System;

namespace Windsor.Extension.Tests.Registration.Decorator.Components.SingleGeneric
{
    class GenericExceptionDecorator<T> : IGenericCalculator<T>
    {
        private readonly IGenericCalculator<T> decorated;
        private readonly ExecutionStack executionStack;

        public GenericExceptionDecorator(IGenericCalculator<T> decorated, ExecutionStack executionStack)
        {
            this.decorated = decorated;
            this.executionStack = executionStack;
        }

        public T Sum(Guid executionId, T x, T y)
        {
            var sum = decorated.Sum(executionId, x, y);
            executionStack.PushInstance(executionId, this);
            return sum;
        }
    }
}
