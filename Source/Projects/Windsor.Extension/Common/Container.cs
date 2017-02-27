using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Windsor.Extension.Common
{
    public class Container
    {
        public static IWindsorContainer Instance;
        public class Installer : IWindsorInstaller
        {
            public void Install(IWindsorContainer container, IConfigurationStore store)
            {
                Instance = container;
            }
        }
    }
}
