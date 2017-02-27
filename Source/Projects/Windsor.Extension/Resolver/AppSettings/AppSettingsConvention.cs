using System;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;

namespace Windsor.Extension.Resolver.AppSettings
{
    public class AppSettingsConvention : ISubDependencyResolver
    {
        public bool CanResolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model, DependencyModel dependency)
        {
            string appSettingsKey = BuildAppSettingsKey(model, dependency);
            var contains = ConfigurationManager.AppSettings.AllKeys.Any(key => key.StartsWith(appSettingsKey, StringComparison.InvariantCulture));
            var convertible = TypeDescriptor.GetConverter(dependency.TargetType).CanConvertFrom(typeof(string));
            var result = contains && convertible;

            return result;
        }

        public object Resolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model, DependencyModel dependency)
        {
            string appSettingsKey = BuildAppSettingsKey(model, dependency);
            var stringValue = ConfigurationManager.AppSettings[appSettingsKey];
            var typeConverter = TypeDescriptor.GetConverter(dependency.TargetType);
            var result = typeConverter.ConvertFrom(stringValue);

            return result;
        }

        private static string BuildAppSettingsKey(ComponentModel model, DependencyModel dependency)
        {
            var dependencyKey = dependency.DependencyKey;
            var fixedDependencyKey = dependencyKey.First().ToString().ToUpperInvariant() + dependencyKey.Substring(1);

            var isGenericType = model.Implementation.IsGenericType;
            if (!isGenericType)
            {
                return $"{model.Implementation.Name}.{fixedDependencyKey}";
            }

            var isOpenGeneric = model.Implementation.IsGenericTypeDefinition;
            if (isOpenGeneric)
            {
                return $"{model.Implementation.Name}";
            }

            StringBuilder sb = new StringBuilder(model.Implementation.Name);
            foreach (Type genericTypeArgument in model.Implementation.GenericTypeArguments)
            {
                sb.Append($".{genericTypeArgument.Name}");
            }

            string result = $"{sb}.{fixedDependencyKey}";
            return result;
        }
    }
}
