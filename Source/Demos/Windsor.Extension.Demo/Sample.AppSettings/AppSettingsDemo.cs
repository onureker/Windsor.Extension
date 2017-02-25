using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windsor.Extension.Demo.Sample.AppSettings
{
    public class AppSettingsDemo
    {
        private readonly string applicationName;
        private readonly int version;

        public AppSettingsDemo(string applicationName, int version)
        {
            this.applicationName = applicationName;
            this.version = version;
        }

        public void Run()
        {
            Console.WriteLine($"{applicationName}: {version}");
        }
    }
}
