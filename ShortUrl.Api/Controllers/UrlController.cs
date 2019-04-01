using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShortUrl.Api.Core;
using ShortUrl.Api.Core.Url;
using ShortUrl.Api.Models;
using ShortUrl.Api.Models.ViewModels.Url;

namespace ShortUrl.Api.Controllers
{
	/// <summary>
	/// 链接压缩与解压
	/// </summary>
	[Route("[controller]")]
	public class UrlController : ControllerBase
    {
		private readonly UrlService _urlService;
        public UrlController(UrlService urlService)
        {
			this._urlService = urlService;
        }

        /// <summary>
        /// 将短链接还原为长链接
        /// </summary>
        /// <param name="input">长链接</param>
        /// <returns>短链接</returns>
        [HttpPost]
		[Authorize]
        [Route("[action]")]
        public ActionResult<string> Zip([FromBody]ZipInputModel input)
        {
            var slink = _urlService.Zip(input.LLink);
            return Json(TResponse<string>.Ok(slink));
        }

        /// <summary>
        /// 将长链接压缩为短链接
        /// </summary>
        /// <param name="input">短链接</param>
        /// <returns>长链接</returns>
        [HttpGet]
		[Authorize]
		[Route("[action]")]
        public ActionResult<string> Unzip([FromQuery]UnzipInputModel input)
        {
            var llink = _urlService.UnZip(input.SLink);
            return Json(TResponse<string>.Ok(llink));
        }

        /// <summary>
        /// 跳转地址
        /// </summary>
        /// <param name="input">短地址</param>
        /// <returns></returns>
        [Route("/{SLink}")]
        [HttpGet]
        public IActionResult Go([FromRoute]UnzipInputModel input)
        {
            var llink = _urlService.UnZip(input.SLink);
            return Redirect(llink);
        }
    }
}
