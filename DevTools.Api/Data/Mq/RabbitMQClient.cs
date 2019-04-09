using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using DevTools.Api.Models.Configuration;
using DevTools.Api.Models.Mq;

namespace DevTools.Api.Data
{
	public class RabbitMQClient<TMessageData> : IMessageQuery<TMessageData>, IDisposable
	{
		private readonly RabbitMQ.Client.ConnectionFactory _connectionFactory;

		private RabbitMQ.Client.IConnection _connection;

		private IModel _channel;

		private readonly AppSettings _appSettings;

		public RabbitMQClient(IOptions<AppSettings> appSettings)
		{
			_appSettings = appSettings.Value;
			_connectionFactory = new ConnectionFactory() {
				HostName = _appSettings.Connections.RabbitMQ.HostName,
				UserName = _appSettings.Connections.RabbitMQ.UserName,
				Password = _appSettings.Connections.RabbitMQ.Password,
				Port = _appSettings.Connections.RabbitMQ.Port,
			};
		}

		public string MqName { get; set; }

		public Action<TMessageData> OnMessage { get; set; }

		public void Dispose()
		{
			_connection.Dispose();
		}

		public void Push(TMessageData message)
		{
			using (var connection = _connectionFactory.CreateConnection())
			{
				using (var channel = connection.CreateModel())
				{
					channel.QueueDeclare(MqName, false, false, false, null);
					channel.BasicPublish(exchange: "",
						  routingKey: MqName,
						  basicProperties: null,
						  body: Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(new Message<TMessageData>() {
							  Data = message
						  })));
				}
			}
		}

		public void Start()
		{
			_connection = _connectionFactory.CreateConnection();
			_channel = _connection.CreateModel();
			_channel.QueueDeclare(MqName, false, false, false, null);
			var consumer = new EventingBasicConsumer(_channel);
			consumer.Received += (sender, e) => {
				OnMessage?.Invoke(Newtonsoft.Json.JsonConvert.DeserializeObject<Message<TMessageData>>(Encoding.UTF8.GetString(e.Body)).Data);
			};
			_channel.BasicConsume(MqName, true, consumer);
		}

		public void Stop()
		{
			_channel.Dispose();
		}
	}
}
