using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTools.Client.Models
{
    [AttributeUsage( AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class ServiceAttribute : Attribute
    {
        public ServiceLifetime ServiceLife { get; set; }

        public ServiceAttribute() : this(ServiceLifetime.Transient)
		{

		}

        public ServiceAttribute(ServiceLifetime ServiceLifetime)
        {
            ServiceLife = ServiceLifetime;
        }
    }
}
