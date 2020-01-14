using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;
using Microsoft.Extensions;
using NLog.Web;
using Microsoft.Extensions.Hosting;

namespace DevTools.Api
{
    public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
		public static IWebHost BuildWebHost(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseIISIntegration()
				//.UseKestrel()
				.UseUrls("http://localhost:61003")
				//.UseContentRoot(Directory.GetCurrentDirectory())
				.UseStartup<Startup>()
				//.ConfigureLogging(options=> {
				//	options.ClearProviders();
				//	options.AddDebug();
				//	options.AddConsole();
				//})
				.ConfigureAppConfiguration(options=> {
					
				})
				//.UseNLog()
                .Build();
    }
}
