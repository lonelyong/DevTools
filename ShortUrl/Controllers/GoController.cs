using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShortUrl.Utils;

namespace ShortUrl.Controllers
{
    public class GoController : Controller
    {
        public IActionResult Index(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return RedirectToAction("Index", "Home");
            else
            {
                try
                {
                    var _real = Logic.ShortUrlManagement.Default.Get(id.FromNum64());
                    if (string.IsNullOrWhiteSpace(_real))
                    {
                        throw new ArgumentNullException();
                    }
                    return Redirect(_real);
                }
                catch(ArgumentNullException)
                {
                    ViewBag.Error = "您访问的短网址不存在";
                }
                catch (Exception)
                {
                    ViewBag.Error = "短链接不合法或出现服务器内部错误";
                }
                finally
                {
                    
                }
                return View();
            }
        }
    }
}