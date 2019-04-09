using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTools.Api.Models.ViewModels.Rsa
{
	public class RsaEncryptInputViewModel : StringInputViewModel
	{
		public string PublicKey { get; set; }
	}
}
