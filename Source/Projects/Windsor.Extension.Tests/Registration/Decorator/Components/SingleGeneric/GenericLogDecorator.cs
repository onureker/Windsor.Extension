using System;

namespace Windsor.Extension.Tests.Registration.Decorator.Components.SingleGeneric
{
    class GenericLogDecorator<T> : IGenericCalculator<T>
    {
        private readonly IGenericCalculator<T> decorated;
        private readonly ExecutionStack executionStack;

        public GenericLogDecorator(IGenericCalculator<T> decorated, ExecutionStack executionStack)
        {
            this.decorated = decorated;
            this.executionStack = executionStack;
        }

        public T Sum(Guid executionId, T x, T y)
        {
            var result = decorated.Sum(executionId, x, y);
            executionStack.PushInstance(executionId, this);
            Console.WriteLine("Sum executed");
            return result;
        }
    }
}
