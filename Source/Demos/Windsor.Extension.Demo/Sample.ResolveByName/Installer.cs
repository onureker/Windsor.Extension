using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Windsor.Extension.Resolver;

namespace Windsor.Extension.Demo.Sample.ResolveByName
{
    public class Installer: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Kernel.Resolver.AddSubResolver(new ResolveByNameConvention(container));

            container.Register(
                Component
                    .For<ILogger>()
                    .ImplementedBy<ConsoleLogger>()
                    .Named("consoleLogger")
                    .IsDefault(),

                Component
                    .For<ILogger>()
                    .ImplementedBy<TraceLogger>()
                    .Named("traceLogger"),

                Component
                    .For<ResolveByNameDemo>()
            );
        }
    }
}
