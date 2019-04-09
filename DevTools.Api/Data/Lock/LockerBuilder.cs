using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTools.Api.Data
{
	public class LockerBuilder
	{
		private readonly IServiceCollection _services;

		public LockerBuilder(IServiceCollection services)
		{
			_services = services;
		}

		public void UseZookeeper()
		{
			_services.AddTransient(typeof(IDistributedLocker), typeof(ZookeeperClient));
		}

		public void UseRedis()
		{
			_services.AddTransient(typeof(IDistributedLocker), typeof(RedisLockerClient));
		}
	}
}
