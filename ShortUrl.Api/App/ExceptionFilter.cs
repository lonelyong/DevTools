using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ShortUrl.Api.Common.Utils;
using ShortUrl.Api.Exceptions;
using ShortUrl.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortUrl.Api.App
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception is ApiException)
            {
                context.Result = new JsonResult(TReponse<string>.Error(context.Exception.Message), JsonHelper.LowerCaseSerializerSettings);
            }
        }
    }
}
