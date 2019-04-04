using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortUrl.Api.App.Middlewares
{
	public static class MiddlewareExtensions
	{
		public static void UseAppExceptionErrorPage(this IApplicationBuilder app)
		{
			//app.Use((next)=> {
			//	return async (context) => {
			//		await next(context);
			//	};
			//});
			app.UseMiddleware<HandleAppExceptionMiddleware>();
		}
	}
}
