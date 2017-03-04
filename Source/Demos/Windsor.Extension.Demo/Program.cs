using Castle.Windsor;
using Castle.Windsor.Installer;
using Windsor.Extension.Common;
using Windsor.Extension.Demo.Sample.Scope;
using Windsor.Extension.Scope;

namespace Windsor.Extension.Demo
{
    class Program
    {
        private static readonly IWindsorContainer Container;

        static Program()
        {
            Container = new WindsorContainer();
            Container.Is(Perspective.Release).Is(Environmentt.Test);
            Container.Install(FromAssembly.This());
            Container.Install(FromAssembly.Containing(typeof(Container)));
        }


        //[DebuggerDisplay("Id = {Id}, State = {GetStateForDebugger}")]
        //[DebuggerTypeProxy(typeof(AsyncLazy<>.DebugView))]

        static void Main(string[] args)
        {

            //Container.Resolve<DecoratorExtensionDemo>().Run();
            //Container.Resolve<ResolveByNameDemo>().Run();
            Container.Resolve<ScopeDemo>().Run();
            //Container.Resolve<AppSettingsDemo>().Run();
            //Container.Resolve<ExtensionDemo>().Run();
        }

    }

}
