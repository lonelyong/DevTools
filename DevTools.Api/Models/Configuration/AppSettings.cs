using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTools.Api.Models.Configuration
{
    public class AppSettings
    {
        public Settings Settings { get; set; }

        public ConnectionStrings ConnectionStrings { get; set; }

		public Connections Connections { get; set; }

		public AuthenticationSettings Authentication { get; set; }

    }
}
