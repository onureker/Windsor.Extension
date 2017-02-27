using System;
using System.Linq;
using Castle.MicroKernel.Registration;

namespace Windsor.Extension.Resolver.ByName
{
    public static class ResolveByNameExtensions
    {
        public static BasedOnDescriptor NamedAsParameter(this BasedOnDescriptor extended)
        {
            var result = extended.Configure(registration => NamedAsParameter(registration));
            return result;
        }

        public static ComponentRegistration<TService> NamedAsParameter<TService>(this ComponentRegistration<TService> extended)
            where TService : class
        {
            var componentName = GetParameterName(extended.Implementation);
            var result = extended.Named(componentName);
            return result;
        }

        private static string GetParameterName(Type implementationType)
        {
            var implementationName = implementationType.Name;
            var result = implementationName.First().ToString().ToLowerInvariant() + implementationName.Substring(1);
            return result;
        }
    }
}
