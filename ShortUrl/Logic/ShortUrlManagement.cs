using ShortUrl.Entities;
using ShortUrl.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace ShortUrl.Logic
{
    /// <summary>
    /// 所有方法都是线程安全的
    /// </summary>
    public class ShortUrlManagement
    {
        public static ShortUrlManagement Default { get; } = new ShortUrlManagement();

        public ShortUrlManagement() :this(Utils.Configuration.Host)
        {

        }

        public ShortUrlManagement(string host)
        {
            Host = host;
        }

        public string Host { get; }

        public string Zip(string real)
        {
            if (string.IsNullOrWhiteSpace(real))
            {
                throw new Exception("网址不能为空");
            }
            real = real.Trim();
            if (!IsUrl(real))
            {
                throw new Exception("指定的网址不符合规范");
            }
            using (var scope = Program.Host.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<Data.DefaultDbContext>();
                Url _url = context.Urls.FirstOrDefault(t => t.Link == real);
                if (_url == null)
                {
                    _url = new Url()
                    {
                        Link = real
                    };
                    context.Urls.Add(_url);
                    context.SaveChanges();
                }
                return string.Concat(Host, "/", _url.Id.ToNum64());
            }
        }

        public string Get(long id)
        {
            using (var scope = Program.Host.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<Data.DefaultDbContext>();
                var _url = context.Urls.FirstOrDefault(t=>t.Id == id);
                if (_url == null)
                    throw new Exception(string.Format("指定的短网址不存在({0})", id.ToNum64()));
                return _url.Link;
            }
        }

        public string Get(string id64)
        {
            if (string.IsNullOrWhiteSpace(id64))
                throw new Exception("id不能为空");
            long _id;
            try
            {
                _id = id64.FromNum64();
            }
            catch 
            {
                throw new Exception("输入的短网址不合法");
            }
            return Get(_id);
        }

        static bool IsUrl(string url)
        {
            return true;
        }
    }
}
