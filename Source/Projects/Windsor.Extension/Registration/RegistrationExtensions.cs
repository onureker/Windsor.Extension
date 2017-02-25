using System;
using Castle.MicroKernel.Registration;

namespace Windsor.Extension.Registration
{
    public static class RegistrationExtensions
    {
        public static BasedOnDescriptor DefaultIs<TImplementation>(this BasedOnDescriptor extended)
        {
            var result = extended.DefaultIs(typeof(TImplementation));
            return result;
        }

        public static BasedOnDescriptor DefaultIs(this BasedOnDescriptor extended, Type implementationType)
        {
            var result = extended.ConfigureIf(
                    registration => registration.Implementation == implementationType,
                    registration => registration.IsDefault()
                );
            return result;
        }

    }
}
