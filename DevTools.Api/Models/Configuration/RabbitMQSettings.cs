using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTools.Api.Models.Configuration
{
	public class RabbitMQSettings
	{
		public string HostName { get; set; }

		public string UserName { get; set; }

		public string Password { get; set; }

		public int Port { get; set; }
	}
}
