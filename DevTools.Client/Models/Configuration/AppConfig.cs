using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DevTools.Client.Models.Configuration
{
    class AppConfig
    {
        public static readonly string ConfigFilePath;

        public static readonly string ConfigFilePath_Development;

        public static readonly string ConfigFilePath_Production;

        public AppSetings Settings { get; }

        static AppConfig()
        {
            var assembly = Assembly.GetEntryAssembly();
            var assemblyName = assembly.GetName().Name;
            ConfigFilePath = $"{assemblyName}.config";
            ConfigFilePath_Development = $"{assemblyName}.Development.config";
            ConfigFilePath_Production = $"{assemblyName}.Production.config";
#if DEBUG


#elif RELEASE

#endif
        }
    }
}
