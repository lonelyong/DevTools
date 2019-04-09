using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevTools.Api.Models.ViewModels.Url
{
    /// <summary>
    /// 解压缩网址提交数据
    /// </summary>
    public class UnzipInputModel
    {
        /// <summary>
        /// 短链接，不包含域名部分
        /// </summary>
        [Required]
        [RegularExpression(Common.Consts.RegexConsts.SHORTLINK, ErrorMessage = "短链接不合法")]
        public string SLink { get; set; }
    }
}
