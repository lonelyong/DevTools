using Microsoft.AspNetCore.Http;
using ShortUrl.Api.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortUrl.Api.App.Middlewares
{
	[Service()]
	public class HandleAppExceptionMiddleware : IMiddleware
	{
		public async Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			try
			{
				await next(context);
			}
			catch (AppException)
			{
				context.Response.StatusCode = 200;
				context.Response.ContentType = "text/plain";
				await context.Response.WriteAsync("Something went wrong!");
			}
		}
	}
}
