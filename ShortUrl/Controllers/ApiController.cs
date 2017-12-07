using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ShortUrl.Controllers
{
    public class ApiController : Controller
    {
        static Dictionary<string, string[]> _groups = new Dictionary<string, string[]>() { { "api", new string[] { "zip", "unzip" } } };

        public IActionResult Doc(string group, string item) 
        {
       
            if (!Request.Query.ContainsKey("group") && !Request.Query.ContainsKey("item"))
            {
                ViewBag.Group = _groups.First().Key;
                ViewBag.Item = _groups.First().Value.First();
            }
            else if (_groups.ContainsKey(group??"") && _groups[group].Contains(item??""))
            {
                ViewBag.Group = group;
                ViewBag.Item = item;
            }
            else
            {
                ViewBag.Group = "ERROR";
                ViewBag.Item = "404";
            }
            ViewBag.Partial = $"_{ViewBag.Group}_{ViewBag.Item}";
            return View();
        }

        public JsonResult Zip(string url) 
        {
            var _short = new Logic.Apis.ZipUrl().Zip(url);
            return Json(_short, new Newtonsoft.Json.JsonSerializerSettings() { ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver()});
        }

        public JsonResult UnZip(string surl) 
        {
            var _long = new Logic.Apis.UnZipUrl().UnZip(surl); 
            return Json(_long, new Newtonsoft.Json.JsonSerializerSettings() { ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver() });
        }
    }
}