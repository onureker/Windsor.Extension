﻿namespace Windsor.Extension.Demo.Sample.DecoratorExtension
{
    public class DefaultMathService : IMathService
    {
        public int Sum(int value1, int value2)
        {
            return value1 + value2;
        }
    }
}