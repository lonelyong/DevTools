using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ShortUrl.Api.App
{
    public class ActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            context.HttpContext.Response.Headers.Add("X-Powered-By", new Microsoft.Extensions.Primitives.StringValues(new string[] { "ASP.NET CORE" }));
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var ctr = context.Controller as Controller;
            if (!ctr.ModelState.IsValid)
            {
                context.Result = new ContentResult() {
                    ContentType = Common.Consts.MimeTypes.APPLICATION_JSON,
                    Content = string.Join("", ctr.ModelState.Values)
                };
            }
        }
    }
}
