using DevTools.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevTools.Api.Models.ViewModels.Des;
using Microsoft.AspNetCore.Authorization;
using Utilities.Security;

namespace DevTools.Api.Controllers.Crypto
{
	[Area("Crypto")]
	[Route("[area]/[controller]/[action]")]
	public class DesController : ControllerBase
	{
		[HttpPost]
		[AllowAnonymous]
		public ActionResult<string> Encrypt([FromBody]DesEncryptDecryptInputViewModel input)
		{
			return Json(TResponse<string>.Ok(DesHelper.EncryptString(input.Text, input.Key)));
		}

		[HttpPost]
		[AllowAnonymous]
		public ActionResult<string> Decrypt([FromBody]DesEncryptDecryptInputViewModel input)
		{
			return Json(TResponse<string>.Ok(DesHelper.SDecryptString(input.Text, input.Key)));
		}

	}
}
