using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTools.Api.Models.ViewModels.Des
{
	public class DesEncryptDecryptInputViewModel : StringInputViewModel
	{
		public string Key { get; set; }
	}
}
