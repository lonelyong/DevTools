using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTools.Api.Models.ViewModels.Base64
{
	public class Base64EncryptDecryptInputViewModel : StringInputViewModel
	{
		public string Encoding { get; set; }
	}
}
