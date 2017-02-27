using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;
using Windsor.Extension.Common;

namespace Windsor.Extension.Demo.Sample.Extension
{
    public static class RedacterExtensions
    {
        private static readonly GenericRedacter GenericRedacter;

        static RedacterExtensions()
        {
            GenericRedacter = Container.Instance.Resolve<GenericRedacter>();
        }

        public static string Redact(this object instance)
        {
            foreach (var assignableHandler in Container.Instance.Kernel.GetAssignableHandlers(typeof(object)))
            {
                Console.WriteLine(assignableHandler.ComponentModel.Name);
            }

            var result = GenericRedacter.Redact(instance.ToDynamic());
            return result;
        }
    }
}
