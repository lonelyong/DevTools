using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DevTools.Api.Core.Url;
using DevTools.Api.Models.ViewModels.Url;

namespace DevTools.Api.Controllers
{
    public class HomeController : ControllerBase
	{
		public HomeController()
		{
		}

        public IActionResult Index()
        {
            return Redirect("/swagger");
        }
	}
}