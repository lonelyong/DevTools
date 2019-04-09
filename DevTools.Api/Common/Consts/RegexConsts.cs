using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTools.Api.Common.Consts
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

		/// <summary>
		/// 邮箱地址格式
		/// </summary>
		public const string EMAIL = "";

		/// <summary>
		/// 用户名格式
		/// </summary>
		public const string USERNAME = "^[a-z0-9_\\-]+$";

		/// <summary>
		/// 密码格式
		/// </summary>
		public const string PASSWORD = "^[a-zA-Z0-9_\\-.]+$";

		/// <summary>
		/// 移动电话号码格式
		/// </summary>
		public const string MOBILEPHONE = "^(\\d{3}-)?\\d{7}$";

		/// <summary>
		/// 固定电话号码格式
		/// </summary>
		public const string TELEPHONE = "^1[0-9]{10}$";
	}
}
