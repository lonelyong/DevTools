using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace ShortUrl.Api.Data
{
	public class RabbitMQClient
	{
		private RabbitMQ.Client.IConnection _connection;

		public RabbitMQClient()
		{

		}
	}
}
