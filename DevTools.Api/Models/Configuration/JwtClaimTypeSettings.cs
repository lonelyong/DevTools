using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTools.Api.Models.Configuration
{
	public class JwtClaimTypeSettings
	{
		public string ValidIssuer { get; set; }

		public string ValidAudience { get; set; }
					 
		public string IssuerSigningKey { get; set; }

		public int ExpiredHours { get; set; } = 24;
	}
}
