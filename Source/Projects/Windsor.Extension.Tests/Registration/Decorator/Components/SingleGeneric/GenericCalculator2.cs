using System;

namespace Windsor.Extension.Tests.Registration.Decorator.Components.SingleGeneric
{
    public class GenericCalculator2 : IGenericCalculator<int>
    {
        private readonly ExecutionStack executionStack;

        public GenericCalculator2(ExecutionStack executionStack)
        {
            this.executionStack = executionStack;
        }

        public int Sum(Guid executionId, int x, int y)
        {
            executionStack.PushInstance(executionId, this);
            return x + y;
        }
    }
}