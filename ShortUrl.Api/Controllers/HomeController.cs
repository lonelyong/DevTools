using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShortUrl.Api.Core.Apis;
using ShortUrl.Api.Models.ViewModels.Url;

namespace ShortUrl.Api.Controllers
{
    public class HomeController : ControllerBase
	{
		private UnZipUrl _apiUnZipUrl;
		public HomeController(UnZipUrl unZipUrl)
		{
			_apiUnZipUrl = unZipUrl;
		}

        public IActionResult Index()
        {
            return Redirect("/swagger");
        }
	}
}