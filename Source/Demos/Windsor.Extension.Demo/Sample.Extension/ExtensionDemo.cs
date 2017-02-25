using System;
using System.Diagnostics;
using Windsor.Extension.Demo.Sample.DecoratorExtension;

namespace Windsor.Extension.Demo.Sample.Extension
{
    public class ExtensionDemo
    {
        public void Run()
        {
            SampleModel model = new SampleModel();
            model.Name = "Onur Eker";
            var redact = model.Redact();

            Console.WriteLine(redact);
        }
    }
}
