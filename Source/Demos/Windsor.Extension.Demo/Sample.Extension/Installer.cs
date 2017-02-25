using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Windsor.Extension.Demo.Sample.Extension
{
    public class Installer: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<IWindsorContainer>()
                    .Instance(container),

                Component
                    .For<ExtensionDemo>(),

                Component
                    .For<GenericRedacter>(),

                Component
                    .For<IRedacter<SampleModel>>()
                    .ImplementedBy<SampleRedacter>()
            );
        }
    }
}
