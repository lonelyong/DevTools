using DevTools.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTools.Api.Models.ViewModels.Account
{
	/// <summary>
	/// 登录返回数据信息
	/// </summary>
	public class LoginOutputModel
	{
		/// <summary>
		/// Token
		/// </summary>
		public string AccessToken { get; set; }

		/// <summary>
		/// 用户名
		/// </summary>
		public string UserName { get; set; }

		/// <summary>
		/// 昵称
		/// </summary>
		public string NickName { get; set; }

		/// <summary>
		/// 用户id
		/// </summary>
		public int UserId { get; set; }

		/// <summary>
		/// 用户类型
		/// </summary>
		public UserRoleType RoleType { get; set; }

		/// <summary>
		/// 用户状态
		/// </summary>
		public UserStatusCode StatusCode { get; set; }
	}
}
