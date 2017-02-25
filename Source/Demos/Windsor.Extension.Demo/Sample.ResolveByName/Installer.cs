using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Windsor.Extension.Common;
using Windsor.Extension.Registration;
using Windsor.Extension.Resolver;
using Windsor.Extension.Resolver.ByName;

namespace Windsor.Extension.Demo.Sample.ResolveByName
{
    public class Installer: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Kernel.Resolver.AddSubResolver(new ResolveByNameConvention(container));

            RegisterAllWithGeneric(container);
            //RegisterAllWithNonGeneric(container);
            //RegisterOneByOne(container);

            container.Register(
                Component
                    .For<ResolveByNameDemo>()
            );
        }

        private void RegisterOneByOne(IWindsorContainer container)
        {
            container.Register(
                Component
                    .For<ILogger>()
                    .ImplementedBy<ConsoleLogger>()
                    .Named("consoleLogger")
                    .IsDefault(),

                Component
                    .For<ILogger>()
                    .ImplementedBy<TraceLogger>()
                    .Named("traceLogger")
            );
        }

        private void RegisterAllWithNonGeneric(IWindsorContainer container)
        {
            container.Register(
                Classes
                    .FromAssemblyInThisApplication()
                    .BasedOn(typeof(ILogger))
                    .WithService
                    .FromInterface()
                    .NamedAsParameter()
                    .DefaultIs(typeof(TraceLogger))
            );
        }

        private void RegisterAllWithGeneric(IWindsorContainer container)
        {
            container.Register(
                Classes
                    .FromAssemblyInThisApplication()
                    .BasedOn<ILogger>()
                    .WithService
                    .FromInterface()
                    .NamedAsParameter()
                    .DefaultIs<ConsoleLogger>()
            );
        }
    }
}
