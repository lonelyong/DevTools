using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ShortUrl.Api.Models;
namespace ShortUrl.Api.Core.Apis
{
    public class UnZipUrl:ApiBase
    {
        public UnZipUrl(ShortUrlManagement shortUrlManagement) : base(shortUrlManagement)
        {

        }
        public string UnZip(string shortUrl)
        {
            return UrlManagement.Get(shortUrl);
        }
    }
}
