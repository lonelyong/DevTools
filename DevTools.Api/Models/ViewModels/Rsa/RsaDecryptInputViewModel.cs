using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTools.Api.Models.ViewModels.Rsa
{
	public class RsaDecryptInputViewModel : StringInputViewModel
	{
		public string PrivateKey { get; set; }
	}
}
