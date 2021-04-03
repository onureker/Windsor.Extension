using System;

namespace Windsor.Extension.Tests.Registration.Decorator.Components.NonGeneric
{
    public class Calculator2 : ICalculator
    {
        private readonly ExecutionStack executionStack;

        public Calculator2(ExecutionStack executionStack)
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