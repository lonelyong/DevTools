using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ShortUrl.Controllers
{
    public class GoController : Controller
    {
        public IActionResult Index(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return RedirectToAction("Index", "Home");
            return View();
        }
    }
}