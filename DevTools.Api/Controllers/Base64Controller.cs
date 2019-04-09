﻿using DevTools.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevTools.Api.Models.ViewModels.Base64;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace DevTools.Api.Controllers
{
	[Route("[controller]/[action]")]
	public class Base64Controller : ControllerBase
	{
		[HttpPost]
		[AllowAnonymous]
		public ActionResult<string> Encrypt([FromBody]Base64EncryptDecryptInputViewModel input)
		{
			return Json(TResponse<string>.Ok(NgNet.Security.Base64Helper.ToBase64String(input.Text, Encoding.GetEncoding(input.Encoding))));
		}

		[HttpPost]
		[AllowAnonymous]
		public ActionResult<string> Decrypt([FromBody]Base64EncryptDecryptInputViewModel input)
		{
			return Json(TResponse<string>.Ok(NgNet.Security.Base64Helper.FormBase64String(input.Text, Encoding.GetEncoding(input.Encoding))));
		}

	}
}
