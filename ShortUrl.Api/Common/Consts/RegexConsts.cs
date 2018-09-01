using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortUrl.Api.Common.Consts
{
	/// <summary>
	/// 正则常量
	/// </summary>
    public static class RegexConsts
    {
		/// <summary>
		/// 短链接格式
		/// </summary>
        public const string SHORTLINK = "^[0-9a-zA-Z]{1,8}$";

		/// <summary>
		/// 长链接格式
		/// </summary>
        public const string LONGLINK = @"^((https|http|ftp|rtsp|mms)?://)?(([0-9a-z_!~*\'().&=+$%-]+: )?[0-9a-z_!~*\'().&=+$%-]+@)?(([0-9]{1,3}.){3}[0-9]{1,3}|([0-9a-z_!~*\'()-]+.)*([0-9a-z][0-9a-z-]{0,61})?[0-9a-z].[a-z]{2,6})(:[0-9]{1,4})?((/?)|(/[0-9a-z_!~*\'().;?:@&=+$,%#-]+)+/?)$";
    }
}
