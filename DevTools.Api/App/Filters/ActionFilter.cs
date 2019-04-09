using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using DevTools.Api.Common.Utils;
using DevTools.Api.Models;

namespace DevTools.Api.App.Filters
{
    public class ActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
			
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var ctr = context.Controller as Controller;
            if (!ctr.ModelState.IsValid)
            {
				context.Result = new JsonResult(TResponse<string>.Error(string.Join("", ctr.ModelState.Values.SelectMany(t => t.Errors).Select(t => t.ErrorMessage))), JsonUtils.LowerCaseSerializerSettings);
            }
        }
    }
}
