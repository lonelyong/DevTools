using ShortUrl.Api.App;
using ShortUrl.Api.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ShortUrl.Api.Data
{
	public class MQManagement
	{
		public IMessageQuery<string> TestMQ { get; set; }

		public MQManagement(IMessageQuery<string> testMq)
		{
			TestMQ = testMq;
			TestMQ.MqName = "test";
			TestMQ.OnMessage = (msg)=>{
				Debug.Print(msg + "\r\n");
			};
			TestMQ.Start();
		}
	}
}
