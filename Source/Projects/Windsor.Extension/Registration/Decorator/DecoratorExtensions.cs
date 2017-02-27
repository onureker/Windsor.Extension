using Windsor.Extension.Common;
using Windsor.Extension.Registration.Decorator;

// ReSharper disable once CheckNamespace
namespace Castle.MicroKernel.Registration
{
    public static class DecoratorExtensions
    {
        public static DecorationRegistration<ComponentRegistration<TService>, TService> Decorated<TService>(this ComponentRegistration<TService> extended)
            where TService : class
        {
            var extensions = extended.GetResolveExtensions();
            var decoratorResolveExtension2 = extensions.Get<DecoratorApplier>();
            var result = new DecorationRegistration<ComponentRegistration<TService>, TService>(extended, decoratorResolveExtension2);
            return result;
        }

        public static DecorationRegistration<BasedOnDescriptor> Decorated(this BasedOnDescriptor extended)
        {
            DecoratorApplier decoratorApplier = new DecoratorApplier();
            var decorationRegistration = new DecorationRegistration<BasedOnDescriptor>(extended, decoratorApplier);
            extended.Configure(registration => registration.GetResolveExtensions().Add(decoratorApplier));

            return decorationRegistration;
        }

    }
}
