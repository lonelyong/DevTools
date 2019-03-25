using ShortUrl.Api.Common.Consts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShortUrl.Api.Models.ViewModels.Account
{
	/// <summary>
	/// 注册提交数据
	/// </summary>
	public class SignupInputModel : ViewModelBase
	{
		/// <summary>
		/// 用户名
		/// </summary>
		[MaxLength(16)]
		[MinLength(6)]
		[Required]
		[RegularExpression(RegexConsts.USERNAME)]
		public string UserName { get; set; }

		/// <summary>
		/// 密码
		/// </summary>
		[StringLength(128)]
		[Required]
		[RegularExpression(RegexConsts.PASSWORD)]
		public string Password { get; set; }

		/// <summary>
		/// 邮箱
		/// </summary>
		[MaxLength(32)]
		[MinLength(6)]
		[Required]
		[EmailAddress]
		public string Email { get; set; }

		/// <summary>
		/// 固定电话号码
		/// </summary>
		[MaxLength(11)]
		[MinLength(7)]
		[Phone]
		public string Telephone { get; set; }

		/// <summary>
		/// 移动电话号码
		/// </summary>
		[MaxLength(14)]
		[MinLength(11)]
		[RegularExpression(RegexConsts.MOBILEPHONE)]
		public string MobilePhone { get; set; }

		/// <summary>
		/// 昵称
		/// </summary>
		[MaxLength(8)]
		[MinLength(1)]
		public string NickName { get; set; }
	}
}
