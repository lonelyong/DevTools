﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortUrl.Api.Models.Configuration
{
	public class AuthenticationSettings
	{
		public JwtClaimTypeSettings Jwt { get; set; }
	}
}
