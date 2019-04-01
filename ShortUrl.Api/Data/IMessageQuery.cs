using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortUrl.Api.Data
{
	/// <summary>
	/// 消息队列基类
	/// </summary>
	public interface IMessageQuery<TMessageData> 
	{
		string MqName { get; set; }

		/// <summary>
		/// 推送消息
		/// </summary>
		/// <param name="message"></param>
		void Push(TMessageData message);

		void Start();

		void Stop();

		Action<TMessageData> OnMessage { get; set; }
	}
}
