using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ShortUrl.Controllers
{
    public class ApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult Zip(string url) 
        {
            var _short = new Logic.Apis.ZipUrl().Zip(url);
            return Json(_short, new Newtonsoft.Json.JsonSerializerSettings() { ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver()});
        }
    }
}