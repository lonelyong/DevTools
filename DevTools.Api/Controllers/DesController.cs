using DevTools.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevTools.Api.Models.ViewModels.Des;
using Microsoft.AspNetCore.Authorization;

namespace DevTools.Api.Controllers
{
	[Route("[controller]/[action]")]
	public class DesController : ControllerBase
	{
		[HttpPost]
		[AllowAnonymous]
		public ActionResult<string> Encrypt([FromBody]DesEncryptDecryptInputViewModel input)
		{
			return Json(TResponse<string>.Ok(NgNet.Security.DesHelper.EncryptString(input.Text, input.Key)));
		}

		[HttpPost]
		[AllowAnonymous]
		public ActionResult<string> Decrypt([FromBody]DesEncryptDecryptInputViewModel input)
		{
			return Json(TResponse<string>.Ok(NgNet.Security.DesHelper.SDecryptString(input.Text, input.Key)));
		}

	}
}
