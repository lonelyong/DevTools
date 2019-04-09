using DevTools.Api.Entities;
using DevTools.Api.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using DevTools.Api.Data;
using DevTools.Api.App;
using Microsoft.Extensions.Configuration;
using DevTools.Api.Models;
using DevTools.Api.Exceptions;
using Microsoft.Extensions.Options;
using DevTools.Api.Models.Configuration;
using Microsoft.Extensions.Caching;
using Microsoft.Extensions.Caching.Redis;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using Microsoft.Extensions.Logging;

namespace DevTools.Api.Core.Url
{
    /// <summary>
    /// 所有方法都是线程安全的
    /// </summary>
    [Service(ServiceLifetime.Scoped)]
    public class UrlService
    {
        private readonly MssqlDbContext _dbContext;

        private readonly AppSettings _appSettings;

		private readonly IRedisClient _redisClient;

		private readonly MQManger _mqManagement;

		private readonly ILogger _logger;

		private readonly RedisSettings redisSettings;

		private const string REDIS_PREFIX = "shorturl:key:";

		private string BuildRedisCacheKey(long id)
		{
			return $"{REDIS_PREFIX}{id}";
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dbContext"></param>
		/// <param name="redisClient"></param>
		/// <param name="appSettings"></param>
		/// <param name="mqManagement"></param>
		/// <param name="logger"></param>
		public UrlService(MssqlDbContext dbContext, IRedisClient redisClient, IOptions<AppSettings> appSettings, MQManger mqManagement, ILogger<UrlService> logger, IOptionsSnapshot<RedisSettings> options) 
        {
            _dbContext = dbContext;
			_redisClient = redisClient;
            _appSettings = appSettings.Value;
			_mqManagement = mqManagement;
			_logger = logger;
			redisSettings = options.Get("default");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="llink"></param>
        /// <returns></returns>
        public string Zip(string llink)
        {
            if (string.IsNullOrWhiteSpace(llink))
            {
                throw new ApiException("网址不能为空");
            }
            llink = llink.Trim();
            if (!IsUrl(llink))
            {
                throw new ApiException("指定的网址不符合规范");
            }
			Entities.Url _url = _dbContext.Urls.FirstOrDefault(t => t.Link == llink);
            if (_url == null)
            {
                _url = new Entities.Url()
                {
                    Link = llink
                };
                _dbContext.Urls.Add(_url);
                _dbContext.SaveChanges();
            }
			_logger.LogInformation($"添加新地址:ID={_url.Id}");
            return string.Concat(_appSettings.Settings.Host, "/", _url.Id.ToNum64());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Get(long id)
        {
			var _url = _redisClient.GetString(BuildRedisCacheKey(id));
			if (string.IsNullOrEmpty(_url))
			{
				_url = _dbContext.Urls.FirstOrDefault(t => t.Id == id)?.Link;
				if (!string.IsNullOrEmpty(_url))
				{
					_redisClient.SetString(BuildRedisCacheKey(id), _url, new DistributedCacheEntryOptions() { SlidingExpiration = TimeSpan.FromMinutes(1) });
				}
			}
            if (string.IsNullOrEmpty(_url))
                throw new ApiException(string.Format("指定的短网址不存在({0})", id.ToNum64()));
			_logger.LogInformation($"解压地址:ID={id}");
			_logger.LogDebug($"解压地址:ID={id}");
			_logger.LogTrace($"解压地址:ID={id}");
			_logger.LogWarning($"解压地址:ID={id}");
			_logger.LogError($"解压地址:ID={id}");
			_mqManagement.TestMQ.Push($"{redisSettings.Configuration}={id}={_url}");
			redisSettings.Configuration += "%";
			return _url;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id64"></param>
        /// <returns></returns>
        public string UnZip(string id64)
        {
            if (string.IsNullOrWhiteSpace(id64))
                throw new ApiException("id不能为空");
            long _id;
            try
            {
                _id = id64.FromNum64();
            }
            catch 
            {
                throw new ApiException("输入的短网址不合法");
            }
            return Get(_id);
        }

        static bool IsUrl(string url)
        {
            return true;
        }
    }
}
