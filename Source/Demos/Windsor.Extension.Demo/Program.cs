using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Windsor.Extension.Demo.Sample;

namespace Windsor.Extension.Demo
{
    class Program
    {
        private static readonly IWindsorContainer Container;

        static Program()
        {
            Container = new WindsorContainer();
            Container.Install(FromAssembly.This());
        }

        static void Main(string[] args)
        {
            var mathService = Container.Resolve<IMathService>();
            int result = mathService.Sum(1, 2);
            Debug.WriteLine(result);
        }
    }
}
