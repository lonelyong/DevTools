using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTools.Api.Models.ViewModels.Redis
{
	public class AddServerInputModel : ViewModelBase
	{
		public string Host { get; set; }

		public int Port { get; set; }

		public string Password { get; set; }
	}
}
