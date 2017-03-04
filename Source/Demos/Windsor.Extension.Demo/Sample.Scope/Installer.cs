using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Windsor.Extension.Demo.Sample.ResolveByName;
using Windsor.Extension.Scope;

namespace Windsor.Extension.Demo.Sample.Scope
{
    public class Installer: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<ScopeDemo>()
            );

            container.If(Perspective.Debug).If(Environmentt.Test).Register(
                Component
                    .For<ILogger>()
                    .ImplementedBy<TraceLogger>()
                    .IsDefault()
            );

            container.If(Perspective.Release).Register(
                Component
                    .For<ILogger>()
                    .ImplementedBy<ConsoleLogger>()
                    .IsDefault()
            );
        }
    }
}
