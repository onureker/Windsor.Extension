using System;

namespace Windsor.Extension.Demo.Sample.DecoratorExtension
{
    public class ExceptionDecorator: IMathService
    {
        private readonly IMathService decorated;

        public ExceptionDecorator(IMathService decorated)
        {
            this.decorated = decorated;
        }

        public int Sum(int value1, int value2)
        {
            try
            {
                var result = decorated.Sum(value1, value2);
                return result;
            }
            catch (Exception exception)
            {
                throw new Exception("Sum failed", exception);
            }
        }
    }
}