using System;
using System.Collections.Generic;
using Castle.MicroKernel;
using Castle.MicroKernel.Handlers;
using Castle.MicroKernel.Registration;

namespace Windsor.Extension.Decorator
{
    public class DecoratorApplier: IResolveExtension
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

            //TODO: Burayı düzelt..
            /*
            var alreadyRegisteredTypes = decoratorTypes.Where(kernel.HasComponent).ToArray();
            if (alreadyRegisteredTypes.Length != 0)
            {
                throw  new Exception($"Zaten registered. {alreadyRegisteredTypes[0]}");
            }
            */

            kernel.Register(
                Classes.From(decoratorTypes)
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
            var argument = new { decorated = instance };
            var result = kernel.Resolve(type, argument);
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
