using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortUrl.Logic.Apis
{
    public abstract class ApiBase<TResult> where TResult:ResultBase, new()
    {
        protected ShortUrlManagement UrlManagement { get; set; }
    }
}
