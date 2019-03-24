using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
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
		private readonly ILogger<ExceptionFilter> _logger;

		public ExceptionFilter(ILogger<ExceptionFilter> logger){

			_logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
			_logger.LogError(new EventId((int)DateTime.Now.Ticks, context.ActionDescriptor.DisplayName), context.Exception, context.Exception.Message, null);
            if(context.Exception is ApiException)
            {
				context.ExceptionHandled = true;
				context.Result = new JsonResult(TResponse<string>.Error(context.Exception.Message), JsonUtils.LowerCaseSerializerSettings);
            }
			else
			{
				context.ExceptionHandled = true;
				context.Result = new JsonResult(TResponse<string>.Error(context.Exception), JsonUtils.LowerCaseSerializerSettings);
			}
        }
    }
}
