using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortUrl.Api.Models.ViewModels.Account
{
	public class LoginOutputModel
	{
		public string AccessToken { get; set; }

		public string UserName { get; set; }

		public string NickName { get; set; }
	}
}
