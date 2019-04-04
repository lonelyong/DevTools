using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using ShortUrl.Api.Models.Mq;

namespace ShortUrl.Api.Data
{
	public class RedisMQClient<TMessageData> : IMessageQuery<TMessageData>
	{
		private readonly IRedisClient _redisClient;

		private bool _isStarted = false;

		private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

		public string MqName { get; set; }

		public Action<TMessageData> OnMessage { get; set; }

		public RedisMQClient(IRedisClient redisClient)
		{
			_redisClient = redisClient;
		}
		
		private void Listening()
		{
			while (true)
			{
				if (!_isStarted)
				{
					break;
				}
				var msg = _redisClient.ListRightPop<Models.Mq.Message<TMessageData>>(MqName);
				if (msg != null)
				{
					OnMessage(msg.Data);
				}
				else
				{
					System.Threading.Thread.Sleep(Common.Consts.MqConsts.REDIS_LISTEN_WAIT);
				}
			}
		}

		private void ListeningAsync()
		{
			Task.Run(Listening, _cancellationTokenSource.Token);
		}

		public void Push(TMessageData message)
		{
			_redisClient.ListLeftPush(MqName, new Message<TMessageData>() { Data = message });
		}

		public void Start()
		{
			_isStarted = true;
			ListeningAsync();
		}

		public void Stop()
		{
			_isStarted = false;
		}
	}
}
