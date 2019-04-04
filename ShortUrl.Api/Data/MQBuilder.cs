using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortUrl.Api.Data
{
	public class MQBuilder
	{
		private readonly Microsoft.Extensions.DependencyInjection.IServiceCollection _services;

		public MQBuilder(IServiceCollection services)
		{
			_services = services;
		}

		public void UseRedis()
		{
			_services.AddTransient(typeof(IMessageQuery<>), typeof(RedisMQClient<>));
		}

		public void UseRabbitMQ()
		{
			_services.AddTransient(typeof(IMessageQuery<>), typeof(RabbitMQClient<>));
		}
	}
}
