using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTools.Api.Models.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    public class ConnectionStrings
    {
        /// <summary>
        /// 
        /// </summary>
        public string SqlServer { get; set; }

		public string Redis { get; set; }

		public string MongoDB { get; set; }

		public string Zookeeper { get; set; }

		public string RabbitMQ { get; set; }

		public string Oracle { get; set; }
    }
}
