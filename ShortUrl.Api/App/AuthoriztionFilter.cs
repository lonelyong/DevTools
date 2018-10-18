using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace ShortUrl.Api.App
{
	public class AuthoriztionFilter : IAuthorizationFilter
	{
		private static readonly KeyValuePair<string, StringValues> _header_x_powered_by = new KeyValuePair<string, StringValues>(NgNet.Net.HttpHeaders.X_POWERED_BY, Common.Consts.HttpConsts.V_X_POWERED_BY);

		public void OnAuthorization(AuthorizationFilterContext context)
		{
			context.HttpContext.Response.Headers.Add(_header_x_powered_by);
		}
	}
}
