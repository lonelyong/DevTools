using Microsoft.Extensions.Hosting;
using ShortUrl.Api.App;
using ShortUrl.Api.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShortUrl.Api.Data
{
	public class MQManger : IHostedService
	{
		public IMessageQuery<string> TestMQ { get; }

		public MQManger(IMessageQuery<string> testMq)
		{
			TestMQ = testMq;
			TestMQ.MqName = "test";
			TestMQ.OnMessage = (msg)=>{
				Debug.Print(msg + "\r\n");
			};
			TestMQ.Start();
		}

		public Task StartAsync(CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task StopAsync(CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
