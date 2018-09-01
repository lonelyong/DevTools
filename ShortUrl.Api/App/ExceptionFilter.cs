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
	/// <summary>
	/// 全局异常过滤器
	/// </summary>
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception is ApiException)
            {
				context.ExceptionHandled = true;
				context.Result = new JsonResult(TReponse<string>.Error(context.Exception.Message), JsonUtils.LowerCaseSerializerSettings);
            }
        }
    }
}
