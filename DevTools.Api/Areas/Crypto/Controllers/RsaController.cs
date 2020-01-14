using DevTools.Api.Models;
using DevTools.Api.Models.ViewModels.Rsa;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Security;

namespace DevTools.Api.Controllers.Crypto
{
	[Area("Crypto")]
	[Route("[area]/[controller]")]
	public class RsaController : ControllerBase
	{
		[Route("[action]")]
		[HttpPost]
		[AllowAnonymous]
		public ActionResult<string> Encrypt([FromBody]RsaEncryptInputViewModel input)
		{
			return Json(TResponse<string>.Ok(RsaHelper.Encrypt(input.PublicKey, input.Text)));
		}

		[HttpPost]
		[Route("[action]")]
		[AllowAnonymous]
		public ActionResult<string> Decrypt([FromBody]RsaDecryptInputViewModel input)
		{
			return Json(TResponse<string>.Ok(RsaHelper.Decrypt(input.PrivateKey, input.Text)));
		}

		[HttpGet]
		[Route("Key/Generate")]
		[AllowAnonymous]
		public ActionResult<string> GenerateKey([FromQuery]int keySize)
		{
			var rsaHelper = new RsaHelper(keySize);
			return Json(TResponse<string>.Ok(rsaHelper.ToXmlString(true)));
		}
	}
}
