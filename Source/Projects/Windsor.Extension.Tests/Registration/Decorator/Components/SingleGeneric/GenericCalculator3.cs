using System;

namespace Windsor.Extension.Tests.Registration.Decorator.Components.SingleGeneric
{
    public class GenericCalculator3 : IGenericCalculator<long>
    {
        private readonly ExecutionStack executionStack;

        public GenericCalculator3(ExecutionStack executionStack)
        {
            this.executionStack = executionStack;
        }

        public long Sum(Guid executionId, long x, long y)
        {
            executionStack.PushInstance(executionId, this);
            return x + y;
        }
    }
}
