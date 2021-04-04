using System;

namespace Windsor.Extension.Tests.Registration.Decorator.Components.SingleGeneric
{
    interface IGenericCalculator<T>
    {
        T Sum(Guid executionId, T x, T y);
    }
}