using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;

namespace Windsor.Extension.Resolver
{
    public class AppSettingsConvention: ISubDependencyResolver
    {
        public bool CanResolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model, DependencyModel dependency)
        {
            string appSettingsKey = BuildAppSettingsKey(model, dependency);
            var contains = ConfigurationManager.AppSettings.AllKeys.Contains(appSettingsKey);
            var convertible = TypeDescriptor.GetConverter(dependency.TargetType).CanConvertFrom(typeof(string));
            var result = contains && convertible;
            return result;
        }

        public object Resolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model, DependencyModel dependency)
        {
            string appSettingsKey = BuildAppSettingsKey(model, dependency);
            var settingValue = ConfigurationManager.AppSettings[appSettingsKey];
            var result = Convert.ChangeType(settingValue, dependency.TargetType);
            return result;
        }

        private string BuildAppSettingsKey(ComponentModel model, DependencyModel dependency)
        {
            var dependencyKey = dependency.DependencyKey;
            var fixedDependencyKey = dependencyKey.First().ToString().ToUpper() + dependencyKey.Substring(1);
            var result = $"{model.Implementation.Name}.{fixedDependencyKey}";
            return result;
        }

    }
}
