using System;

namespace Windsor.Extension.Demo.Sample
{
    public class LogDecorator : IMathService
    {
        private readonly IMathService decorated;

        public LogDecorator(IMathService decorated)
        {
            this.decorated = decorated;
        }

        public int Sum(int value1, int value2)
        {
            Console.WriteLine($"Calculation sum of: {value1}, {value2}");
            var result = decorated.Sum(value1, value2);
            Console.WriteLine($"Result is: {result}");
            return result;
        }
    }
}