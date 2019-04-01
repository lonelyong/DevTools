using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortUrl.Api.Data
{
	/// <summary>
	/// 分布式锁锁接口
	/// </summary>
	public interface IDistributedLocker
	{
		object GetLock(string lockName);

		void ReleaseLock(string lockName);
	}
}
