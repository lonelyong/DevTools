using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTools.Api.Models.Account
{
	public class CurrentUserInfo
	{
		public int UserId { get; set; } 

		public int UserName { get; set; }

		public long DateOfIssue { get; set; }
	}
}
