using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShortUrl.Api.App;
using ShortUrl.Api.Models;
using Microsoft.Extensions.DependencyInjection;

namespace ShortUrl.Api.Core.Apis
{
    [Service(ServiceLifetime.Scoped)]
    public abstract class ApiBase
    {
        protected ShortUrlManagement UrlManagement { get; }

        public ApiBase(ShortUrlManagement shortUrlManagement){

            UrlManagement = shortUrlManagement;
        }           
        
    }
}
