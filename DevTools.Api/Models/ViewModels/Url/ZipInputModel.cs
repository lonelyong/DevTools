using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevTools.Api.Models.ViewModels.Url
{
    /// <summary>
    /// 压缩网址提交数据
    /// </summary>
    public class ZipInputModel
    {
        /// <summary>
        /// 长链接，必须包含协议头（http、https、ftp等）
        /// </summary>
        [Required]
        [RegularExpression(Common.Consts.RegexConsts.LONGLINK, ErrorMessage = "长链接不合法")]
        public string LLink { get; set; }
    }
}
