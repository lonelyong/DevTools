using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Redis;
using Microsoft.Extensions.DependencyInjection;
using ShortUrl.Api.Data;
using StackExchange.Redis;

namespace Microsoft.Extensions.DependencyInjection
{
	public static class DataExtensions
	{
		public static IServiceCollection AddStackExchangeRedisCache(this IServiceCollection services, Action<ConfigurationOptions> setupAction, Action<CustomStackExchangeConfigurationOptions> customSetupAction)
		{

			if (services == null)
			{
				throw new ArgumentNullException(nameof(services));
			}
			if (setupAction == null)
			{
				throw new ArgumentNullException(nameof(setupAction));
			}
			OptionsServiceCollectionExtensions.AddOptions(services);
			OptionsServiceCollectionExtensions.Configure<ConfigurationOptions>(services, setupAction);
			OptionsServiceCollectionExtensions.Configure<CustomStackExchangeConfigurationOptions>(services, customSetupAction);
			((ICollection<ServiceDescriptor>)services).Add(ServiceDescriptor.Singleton<IRedisClient, StackExchangeRedisClient>());
			return services;
		}
	}
}
