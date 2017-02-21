using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;
using Castle.Windsor;

namespace Windsor.Extension.Resolver
{
    public class ResolveByNameConvention<TService>: ISubDependencyResolver
    {
        private readonly IWindsorContainer container;

        public ResolveByNameConvention(IWindsorContainer container)
        {
            this.container = container;
        }

        public bool CanResolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model, DependencyModel dependency)
        {
            var result = dependency.TargetType == typeof(TService);
            return result;
        }

        public object Resolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model, DependencyModel dependency)
        {
            var result = container.Resolve<TService>(dependency.DependencyKey);
            return result;
        }
    }
}
