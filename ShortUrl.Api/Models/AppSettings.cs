using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortUrl.Api.Models
{
    public class AppSettings
    {
        public Settings Settings { get; set; }

        public ConnectionStrings ConnectionStrings { get; set; }
    }
}
