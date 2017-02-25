using System;
using System.Diagnostics;
using Castle.Core;
using Castle.Facilities.Startable;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Windsor.Extension.Demo.Sample.DecoratorExtension
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
                    .ExtendedProperties(new {Name = "Onur"})
                    .Activator<Temp>()
                    .OnCreate(OnCreate)
                    .OnDestroy(OnDestroy)
            );
        }

        private void OnCreate(IKernel kernel, IMathService item)
        {
            Debugger.Break();
        }

        private void OnDestroy(IKernel kernel, IMathService item)
        {
            Debugger.Break();
        }
    }

    public class Temp : IComponentActivator
    {
        private readonly ComponentModel model;
        private readonly IKernel kernel;
        private readonly ComponentInstanceDelegate onCreation;
        private readonly ComponentInstanceDelegate onDestruction;

        public Temp(ComponentModel model, IKernel kernel, ComponentInstanceDelegate onCreation, ComponentInstanceDelegate onDestruction)
        {
            this.model = model;
            this.kernel = kernel;
            this.onCreation = onCreation;
            this.onDestruction = onDestruction;
        }

        public object Create(CreationContext context, Burden burden)
        {
            throw new NotImplementedException();
        }

        public void Destroy(object instance)
        {
            throw new NotImplementedException();
        }
    }
}
