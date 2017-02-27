using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Windsor.Extension.Common;
using Windsor.Extension.Demo.Sample.AppSettings;
using Windsor.Extension.Demo.Sample.DecoratorExtension;
using Windsor.Extension.Demo.Sample.Extension;
using Windsor.Extension.Demo.Sample.ResolveByName;

namespace Windsor.Extension.Demo
{
    class Program
    {
        private static readonly IWindsorContainer Container;

        static Program()
        {
            Container = new WindsorContainer();
            Container.Install(FromAssembly.This());
            Container.Install(FromAssembly.Containing(typeof(Container)));
        }


        //[DebuggerDisplay("Id = {Id}, State = {GetStateForDebugger}")]
        //[DebuggerTypeProxy(typeof(AsyncLazy<>.DebugView))]

        static void Main(string[] args)
        {
            //Container.Resolve<DecoratorExtensionDemo>().Run();
            Container.Resolve<ResolveByNameDemo>().Run();
            //Container.Resolve<AppSettingsDemo>().Run();
            //Container.Resolve<ExtensionDemo>().Run();
        }

    }
}
