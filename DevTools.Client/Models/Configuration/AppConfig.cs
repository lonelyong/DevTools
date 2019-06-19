using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Configuration;
using System.IO;

namespace DevTools.Client.Models.Configuration
{
    static class AppConfig
    {
        public static readonly string ConfigFilePath;

        public static readonly string ConfigFilePath_Development;

        public static readonly string ConfigFilePath_Production;

        private static readonly System.Configuration.Configuration _configuration;

        public static AppSetings Settings { get; }

        static AppConfig()
        {
            var assemblyName = Path.GetFileName(Assembly.GetEntryAssembly().Location);
            ConfigFilePath = $"{assemblyName}.config";
            ConfigFilePath_Development = $"{assemblyName}.Development.config";
            ConfigFilePath_Production = $"{assemblyName}.Production.config";
            _configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            Settings = new AppSetings(_configuration);
#if DEBUG


#elif RELEASE

#endif
        }
    }
}
