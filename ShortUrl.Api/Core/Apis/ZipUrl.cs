using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ShortUrl.Api.Models;

namespace ShortUrl.Api.Core.Apis
{
    public class ZipUrl : ApiBase
    {
        public ZipUrl(ShortUrlManagement shortUrlManagement) : base(shortUrlManagement)
        {

        }
        public string Zip(string longUrl)
        {
            return UrlManagement.Zip(longUrl);
        }
    }
}
