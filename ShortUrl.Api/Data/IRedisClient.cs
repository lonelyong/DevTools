using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace ShortUrl.Api.Data
{
	public interface IRedisClient : IDistributedCache
	{
		string StringGet(string key);

		void StringSet(string key, string value, DistributedCacheEntryOptions options);
	}
}
