using System;

namespace Windsor.ExtensionTests.Registration.Decorator
{
    public class DefaultCalculator2 : ICalculator
    {
        public int Sum(Guid executionId, int x, int y)
        {
            return x + y;
        }
    }
}