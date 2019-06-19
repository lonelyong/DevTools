using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DevTools.Client.Models.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    static class ConfigExtensions
    {
        public static void ConfigureConfigurations(this IServiceCollection services)
        {
            services.AddOptions();
            var configXml = new ConfigXmlDocument();
            configXml.Load(AppConfig.ConfigFilePath);
        }
    }
}
