using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            ConfigFilePath = "App.config";
            ConfigFilePath_Development = "App.Development.config";
            ConfigFilePath_Production = "App.Production.config";
#if DEBUG


#elif RELEASE

#endif
        }
    }
}
