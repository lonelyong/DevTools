using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching;
using StackExchange.Redis;
using StackExchange.Redis.KeyspaceIsolation;
using System.Collections;
using System.Collections.Concurrent;
using Microsoft.Extensions.Options;
using System.Text;

namespace ShortUrl.Api.Data
{
	public class StackExchangeRedisClient : IRedisClient
	{

		private StackExchange.Redis.IConnectionMultiplexer _connectionMultiplexer;

		private readonly ConfigurationOptions _configurationOptions;

		private readonly CustomStackExchangeConfigurationOptions _customOptions;

		public StackExchangeRedisClient(IOptions<ConfigurationOptions> options, IOptions<CustomStackExchangeConfigurationOptions> customOptions)
		{
			_configurationOptions = options.Value;
			_connectionMultiplexer = ConnectionMultiplexer.Connect(_configurationOptions);
			_customOptions = customOptions.Value;
		}

		private IDatabase GetDatabase()
		{
			if (!_connectionMultiplexer.IsConnected)
			{
				_connectionMultiplexer.Dispose();
				_connectionMultiplexer = ConnectionMultiplexer.Connect(_configurationOptions);
			}
			return _connectionMultiplexer.GetDatabase();
		}


		public byte[] Get(string key)
		{
			var db = GetDatabase();
			var value = db.StringGet(_customOptions.Prefix + key);
			return value.HasValue ? Encoding.UTF8.GetBytes(value) : null;
		}

		public async Task<byte[]> GetAsync(string key, CancellationToken token = default)
		{
			token.ThrowIfCancellationRequested();
			return await Task.Run<byte[]>(()=> {
				return Get(key);
			});
		}

		public void Refresh(string key)
		{
			throw new NotImplementedException(); 
		}

		public Task RefreshAsync(string key, CancellationToken token = default)
		{
			throw new NotImplementedException();
		}

		public void Remove(string key)
		{
			var db = GetDatabase();
			db.KeyDelete(_customOptions.Prefix + key);
		}

		public async Task RemoveAsync(string key, CancellationToken token = default)
		{
			token.ThrowIfCancellationRequested();
			await Task.Run(() => {
				Remove(key);
			});
		}

		public void Set(string key, byte[] value, DistributedCacheEntryOptions options = null)
		{
			StringSet(key, Encoding.UTF8.GetString(value), options);
		}

		public async Task SetAsync(string key, byte[] value, DistributedCacheEntryOptions options, CancellationToken token = default)
		{
			token.ThrowIfCancellationRequested();
			await Task.Run(() => {
				Set(key, value, options);
			});
		}

		public string StringGet(string key)
		{
			return GetDatabase().StringGet(_customOptions.Prefix + key);
		}

		public void StringSet(string key, string value, DistributedCacheEntryOptions options)
		{
			var db = GetDatabase();
			if (options != null)
			{
				TimeSpan? expire = null;
				var utcNow = DateTime.UtcNow;
				if (options.AbsoluteExpiration.HasValue)
				{
					expire = options.AbsoluteExpiration.Value - utcNow;
				}
				else if (options.AbsoluteExpirationRelativeToNow.HasValue)
				{
					expire = options.AbsoluteExpirationRelativeToNow.Value;
				}
				else if (options.SlidingExpiration.HasValue)
				{
					expire = options.SlidingExpiration.Value;
				}
				db.StringSet(_customOptions.Prefix + key, value, expire);
			}
		}
	}
}
