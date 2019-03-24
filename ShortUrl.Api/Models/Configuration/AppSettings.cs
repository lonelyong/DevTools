using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortUrl.Api.Models.Configuration
{
    public class AppSettings
    {
        public Settings Settings { get; set; }

        public ConnectionStrings ConnectionStrings { get; set; }

		public RedisSettings Redis { get; set; }

		public AuthenticationSettings Authentication { get; set; }
    }
}
