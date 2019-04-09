using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTools.Api.App
{
    [AttributeUsage( AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class ServiceAttribute : Attribute
    {
        public ServiceLifetime ServiceLife { get; set; } = ServiceLifetime.Transient;

        public ServiceAttribute() { }

        public ServiceAttribute(ServiceLifetime ServiceLifetime)
        {
            ServiceLife = ServiceLifetime;
        }
    }
}
