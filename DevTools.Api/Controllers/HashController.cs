using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevTools.Api.Models;
using DevTools.Api.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevTools.Api.Controllers
{
	[Route("[controller]/[action]")]
    public class HashController : ControllerBase
    {
		[HttpPost]
		[AllowAnonymous]
		public ActionResult<string> StringMD5([FromBody]StringInputViewModel input)
		{
			return Json(TResponse<string>.Ok(NgNet.Security.HashHelper.StringMd5(input.Text)));
		}

		[HttpPost]
		[AllowAnonymous]
		public ActionResult<string> StringSHA1([FromBody]StringInputViewModel input)
		{
			return Json(TResponse<string>.Ok(NgNet.Security.HashHelper.StringSHA1(input.Text)));
		}

		[HttpPost]
		[AllowAnonymous]
		public ActionResult<string> StringSHA256([FromBody]StringInputViewModel input)
		{
			return Json(TResponse<string>.Ok(NgNet.Security.HashHelper.StringSHA256(input.Text)));
		}

		[HttpPost]
		[AllowAnonymous]
		public ActionResult<string> StringSHA384([FromBody]StringInputViewModel input)
		{
			return Json(TResponse<string>.Ok(NgNet.Security.HashHelper.StringSHA384(input.Text)));
		}

		[HttpPost]
		[AllowAnonymous]
		public ActionResult<string> StringSHA512([FromBody]StringInputViewModel input)
		{
			return Json(TResponse<string>.Ok(NgNet.Security.HashHelper.StringSHA512(input.Text)));
		}
	}
}