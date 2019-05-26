using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Configuration.Provider;
namespace DevTools.Client.Models.Configuration
{
    static class ConfigReader
    {
        public static T FromXml<T>() where T : class, new()
        {
            
            return new T();
        }
    }
}
