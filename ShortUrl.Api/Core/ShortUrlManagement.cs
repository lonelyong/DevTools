using ShortUrl.Api.Entities;
using ShortUrl.Api.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ShortUrl.Api.Data;
using ShortUrl.Api.App;
using Microsoft.Extensions.Configuration;
using ShortUrl.Api.Models;
using ShortUrl.Api.Exceptions;
using Microsoft.Extensions.Options;
using ShortUrl.Api.Models.Configuration;
using Microsoft.Extensions.Caching;
using Microsoft.Extensions.Caching.Redis;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;

namespace ShortUrl.Api.Core
{
    /// <summary>
    /// 所有方法都是线程安全的
    /// </summary>
    [Service(ServiceLifetime.Scoped)]
    public class ShortUrlManagement
    {
        private readonly MssqlDbContext _dbContext;

        private readonly AppSettings _appSettings;

		private readonly IRedisClient _redisClient;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        public ShortUrlManagement(MssqlDbContext dbContext, IRedisClient redisClient, IOptions<AppSettings> appSettings) 
        {
            _dbContext = dbContext;
			_redisClient = redisClient;
            _appSettings = appSettings.Value;
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
            Url _url = _dbContext.Urls.FirstOrDefault(t => t.Link == llink);
            if (_url == null)
            {
                _url = new Url()
                {
                    Link = llink
                };
                _dbContext.Urls.Add(_url);
                _dbContext.SaveChanges();
            }
            return string.Concat(_appSettings.Settings.Host, "/", _url.Id.ToNum64());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Get(long id)
        {
			var _url = _redisClient.GetString(id.ToString());
			if (string.IsNullOrEmpty(_url))
			{
				_url = _dbContext.Urls.FirstOrDefault(t => t.Id == id)?.Link;
				if (!string.IsNullOrEmpty(_url))
				{
					_redisClient.SetString(id.ToString(), _url, new DistributedCacheEntryOptions() { SlidingExpiration = TimeSpan.FromMinutes(1) });
				}
			}
            if (string.IsNullOrEmpty(_url))
                throw new ApiException(string.Format("指定的短网址不存在({0})", id.ToNum64()));
            return _url;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id64"></param>
        /// <returns></returns>
        public string Get(string id64)
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
