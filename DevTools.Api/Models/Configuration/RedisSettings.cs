using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTools.Api.Models.Configuration
{
	public class RedisSettings
	{
		public string Configuration { get; set; }
		public string InstanceName { get; set; }
		public string ClientName { get; set; }
		public string Prefix { get; set; }
		public string ChannelPrefix { get; set; }
		public string Password { get; set; }
		public int DefaultDatabase { get; set; } = -1;
		public int ConnectRetry { get; set; } = 2;
		public int ConnectTimeout { get; set; } = 1000;
	}
}
