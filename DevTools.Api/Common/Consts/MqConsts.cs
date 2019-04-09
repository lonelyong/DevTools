using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTools.Api.Common.Consts
{
	public class MqConsts
	{
		public const string REDIS_ZIPURL_KEY = "query_url";

		/// <summary>
		/// 当队列为空时延迟查询下次数据的延迟时间
		/// </summary>
		public const int REDIS_LISTEN_WAIT = 1000;
	}
}
