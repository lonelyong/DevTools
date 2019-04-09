using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTools.Api.Models.Mq
{
	public class Message<T>
	{
		public MessageType Type { get; set; }

		public T Data { get; set; }
	}
}
