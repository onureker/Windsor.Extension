using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Windsor.Extension.Demo.Sample
{
    public class Installer: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<IMathService>()
                    .ImplementedBy<DefaultMathService>()
                    .Decorated().By<LogDecorator>()
            );
        }
    }
}
