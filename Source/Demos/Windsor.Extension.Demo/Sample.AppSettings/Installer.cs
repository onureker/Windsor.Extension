using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Windsor.Extension.Resolver;

namespace Windsor.Extension.Demo.Sample.AppSettings
{
    public class Installer: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Kernel.Resolver.AddSubResolver(new AppSettingsConvention());

            container.Register(
                Component
                    .For<AppSettingsDemo>()
            );
        }
    }
}
