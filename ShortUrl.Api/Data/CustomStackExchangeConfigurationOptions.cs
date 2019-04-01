using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortUrl.Api.Data
{
	public class CustomStackExchangeConfigurationOptions
	{
		/// <summary>
		/// key的前缀
		/// </summary>
		public string Prefix { get; set; }

		public CustomStackExchangeConfigurationOptions()
		{

		}
	}
}
