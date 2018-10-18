using Microsoft.AspNetCore.Mvc;
using ShortUrl.Api.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShortUrl.Api.App;

namespace ShortUrl.Api.Controllers
{
    [Service]
    public class ControllerBase : Controller
    {
        public override JsonResult Json(object data)
        {
            return base.Json(data, JsonUtils.LowerCaseSerializerSettings);
        }
    }
}
