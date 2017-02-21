using System.Diagnostics;

namespace Windsor.Extension.Demo.Sample.DecoratorExtension
{
    public class DecoratorExtensionDemo
    {
        private readonly IMathService mathService;

        public DecoratorExtensionDemo(IMathService mathService)
        {
            this.mathService = mathService;
        }

        public void Run()
        {
            int result = mathService.Sum(1, 2);
            Debug.WriteLine(result);
        }
    }
}
