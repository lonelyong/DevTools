using DevTools.Api.Common.Consts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevTools.Api.Models.ViewModels.Account
{
	/// <summary>
	/// 登录提交数据信息
	/// </summary>
	public class LoginInputModel
	{
		/// <summary>
		/// 用户名
		/// </summary>
		[MaxLength(16)]
		[MinLength(6)]
		[RegularExpression(RegexConsts.USERNAME)]
		[Required]
		public string UserName { get; set; }

		/// <summary>
		/// 密码
		/// </summary>
		[Required]
		[RegularExpression(RegexConsts.PASSWORD)]
		public string Password { get; set; }
	}
}
