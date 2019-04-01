using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShortUrl.Api.Core.Url;
using ShortUrl.Api.Models.ViewModels.Url;

namespace ShortUrl.Api.Controllers
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