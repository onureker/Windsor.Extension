using System;

namespace Windsor.ExtensionTests.Registration.Decorator
{
    public interface ICalculator
    {
        int Sum(Guid executionId, int x, int y);
    }
}