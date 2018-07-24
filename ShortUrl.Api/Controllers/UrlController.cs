using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShortUrl.Api.Core.Apis;
using ShortUrl.Api.Models;

namespace ShortUrl.Api.Controllers
{
    [Route("url")]
    public class UrlController : ControllerBase
    {
        private UnZipUrl _apiUnZipUrl;
        private ZipUrl _apiZipUrl;
        public UrlController(UnZipUrl unZipUrl, ZipUrl zipUrl)
        {
            this._apiUnZipUrl = unZipUrl;
            this._apiZipUrl = zipUrl;
        }

        /// <summary>
        /// 将短链接还原为长链接
        /// </summary>
        /// <param name="llink"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("zip")]
        public IActionResult Zip([FromBody]string llink)
        {
            var slink = _apiZipUrl.Zip(llink);
            return Json(TReponse<string>.Ok(slink));
        }

        /// <summary>
        /// 将长链接压缩为短链接
        /// </summary>
        /// <param name="slink"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("unzip")]
        public IActionResult Unzip(string slink)
        {
            var llink = _apiUnZipUrl.UnZip(slink);
            return Json(TReponse<string>.Ok(llink));
        }
    }
}
