using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DevTools.Api.Models.ViewModels.Redis;

namespace DevTools.Api.Controllers.DbManagement
{
	[Area("DbManagement")]
	[Route("[area]/[controller]/[action]")]
    public class RedisController : ControllerBase
    {
		[HttpPost]
        public ActionResult AddServer([FromBody]AddServerInputModel input)
        {
            return View();
        }
		[HttpDelete]
		public ActionResult RemoveServer([FromQuery]int id)
		{
			return View();
		}
    }
}