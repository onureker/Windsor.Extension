using System;

namespace Windsor.Extension.Tests.Registration.Decorator.Components.NonGeneric
{
    public interface ICalculator
    {
        int Sum(Guid executionId, int x, int y);
    }
}