using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTools.Api.Entities
{
	/// <summary>
	/// 用户状态
	/// </summary>
	public enum UserStatusCode
	{
		/// <summary>
		/// 正常
		/// </summary>
		Normal = 1,
		/// <summary>
		/// 冻结
		/// </summary>
		Freeze  =2
	}
}
