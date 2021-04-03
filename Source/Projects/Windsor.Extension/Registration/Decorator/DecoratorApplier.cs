using System;
using System.Collections.Generic;
using System.Linq;
using Castle.MicroKernel;
using Castle.MicroKernel.Handlers;
using Castle.MicroKernel.Registration;

namespace Windsor.Extension.Registration.Decorator
{
    //TODO: Take o look at goood article http://kozmic.net/2009/11/15/castle-windsor-lazy-loading/
    //TODO: Take o look at goood code https://github.com/castleproject/Windsor/blob/master/src/Castle.Facilities.Synchronize/CreateOnUIThreadActivator.cs
    public class DecoratorApplier : IResolveExtension
    {
        private IKernel currentKernel;
        private readonly IList<Type> decoratorTypes;
        private readonly IList<Func<IKernel, object, object>> decoratorFunctions;

        public DecoratorApplier()
        {
            decoratorTypes = new List<Type>();
            decoratorFunctions = new List<Func<IKernel, object, object>>();
        }

        public void Init(IKernel kernel, IHandler handler)
        {
            currentKernel = kernel;
            var filteredDecoratorTypes = decoratorTypes.Distinct().Where(type => !kernel.HasComponent(type));

            kernel.Register(
                Classes.From(filteredDecoratorTypes)
                    .Pick()
                    .WithService
                    .Self()
                    .LifestyleTransient()
            );
        }

        public void Add<TDecorator>()
        {
            Add(typeof(TDecorator));
        }

        public void Add(Type type)
        {
            decoratorTypes.Add(type);
            Add((kernel, instance) => ResolveDecorator(kernel, instance, type));
        }

        public void Add(Func<IKernel, dynamic, dynamic> decoratorFunction)
        {
            decoratorFunctions.Add(decoratorFunction);
        }

        private object ResolveDecorator(IKernel kernel, object instance, Type type)
        {
            Arguments arguments = new Arguments();
            object result = null;

            var mutualType = type.GetInterfaces().FirstOrDefault(t => t.IsInstanceOfType(instance));

            if (mutualType != null)
            {
                arguments.AddTyped(mutualType, instance);
            }

            if (arguments.Count == 0)
            {
                arguments.AddNamed("decorated", instance);
            }

            result = kernel.Resolve(type, arguments);
            return result;
        }

        public void Intercept(ResolveInvocation invocation)
        {
            invocation.Proceed();
            var currentInstance = invocation.ResolvedInstance;
            foreach (var decoratorFunction in decoratorFunctions)
            {
                currentInstance = decoratorFunction(currentKernel, currentInstance);
            }
            invocation.ResolvedInstance = currentInstance;
        }
    }
}
