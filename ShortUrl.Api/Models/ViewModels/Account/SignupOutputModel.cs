using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortUrl.Api.Models.ViewModels.Account
{
	/// <summary>
	/// 注册返回信息
	/// </summary>
	public class SignupOutputModel
	{
		/// <summary>
		/// 用户id
		/// </summary>
		public int UserId { get; set; }

		/// <summary>
		/// 用户名
		/// </summary>
		public string UserName { get; set; }
	}
}
