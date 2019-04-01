using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortUrl.Api.Data
{
	public class RedisLocker : IDistributedLocker
	{
		public object GetLock(string lockName)
		{
			throw new NotImplementedException();
		}

		public void ReleaseLock(string lockName)
		{
			throw new NotImplementedException();
		}
	}
}
