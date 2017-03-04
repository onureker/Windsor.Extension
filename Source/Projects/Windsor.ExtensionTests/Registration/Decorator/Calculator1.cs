using System;

namespace Windsor.ExtensionTests.Registration.Decorator
{
    public class Calculator1: ICalculator
    {
        private readonly ExecutionStack executionStack;

        public Calculator1(ExecutionStack executionStack)
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