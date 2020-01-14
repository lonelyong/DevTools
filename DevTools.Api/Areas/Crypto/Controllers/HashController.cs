using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevTools.Api.Models;
using DevTools.Api.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utilities.Security;

namespace DevTools.Api.Controllers.Crypto
{
	[Area("Crypto")]
	[Route("[area]/[controller]/[action]")]
    public class HashController : ControllerBase
    {
		[HttpPost]
		[AllowAnonymous]
		public ActionResult<string> StringMD5([FromBody]StringInputViewModel input)
		{
			return Json(TResponse<string>.Ok(HashHelper.StringMd5(input.Text)));
		}

		[HttpPost]
		[AllowAnonymous]
		public ActionResult<string> StringSHA1([FromBody]StringInputViewModel input)
		{
			return Json(TResponse<string>.Ok(HashHelper.StringSHA1(input.Text)));
		}

		[HttpPost]
		[AllowAnonymous]
		public ActionResult<string> StringSHA256([FromBody]StringInputViewModel input)
		{
			return Json(TResponse<string>.Ok(HashHelper.StringSHA256(input.Text)));
		}

		[HttpPost]
		[AllowAnonymous]
		public ActionResult<string> StringSHA384([FromBody]StringInputViewModel input)
		{
			return Json(TResponse<string>.Ok(HashHelper.StringSHA384(input.Text)));
		}

		[HttpPost]
		[AllowAnonymous]
		public ActionResult<string> StringSHA512([FromBody]StringInputViewModel input)
		{
			return Json(TResponse<string>.Ok(HashHelper.StringSHA512(input.Text)));
		}
	}
}