using System.Linq;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;
using Castle.Windsor;

namespace Windsor.Extension.Resolver.ByName
{
    public class ResolveByNameConvention: ISubDependencyResolver
    {
        private readonly IWindsorContainer container;

        public ResolveByNameConvention(IWindsorContainer container)
        {
            this.container = container;
        }

        public bool CanResolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model, DependencyModel dependency)
        {
            var result = container.Kernel
                .GetAssignableHandlers(dependency.TargetType)
                .Any(handler => handler.ComponentModel.Name == dependency.DependencyKey);

            return result;
        }

        public object Resolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model, DependencyModel dependency)
        {
            var result = container.Resolve(dependency.DependencyKey, dependency.TargetType);
            return result;
        }
    }
}
