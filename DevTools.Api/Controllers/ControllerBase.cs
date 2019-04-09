using Microsoft.AspNetCore.Mvc;
using DevTools.Api.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevTools.Api.App;
using DevTools.Api.Models;
using DevTools.Api.Models.Account;

namespace DevTools.Api.Controllers
{
    //[Service]
    public class ControllerBase : Controller
    {
		public CurrentUserInfo CurrentUser { get; private set; }

        public override JsonResult Json(object data)
        {
            return base.Json(data, JsonUtils.LowerCaseSerializerSettings);
        }
    }
}
