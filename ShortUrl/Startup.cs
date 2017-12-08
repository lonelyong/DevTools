﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShortUrl.Dal;
using Microsoft.EntityFrameworkCore;

namespace ShortUrl
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            //services.AddDbContext<DbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.Configure<IISOptions>(options=> options.AutomaticAuthentication = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            GetConfig(env);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{id?}",
                    defaults: new { controller = "Go", action = "Index" });
                routes.MapRoute(
                    name:"route",
                    template:"{controller}/{action}/{id?}");
            });
        }

        void GetConfig(IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
<<<<<<< HEAD
                Utils.Configuration.DefaultConnectionString = Configuration.GetConnectionString("Dev");
                Utils.Configuration.Host = Configuration.GetSection("Settings").GetValue<string>("Host");
            }
            else
            {
                Utils.Configuration.DefaultConnectionString = Configuration.GetConnectionString("Dev");
                Utils.Configuration.Host = Configuration.GetSection("Settings").GetValue<string>("DevHost");
=======
                Utils.Configuration.Host = Configuration.GetSection("Settings").GetValue<string>("DevHost");
                Utils.Configuration.DefaultConnectionString = Configuration.GetConnectionString("DevConnection");
            }
            else
            {
                Utils.Configuration.Host = Configuration.GetSection("Settings").GetValue<string>("Host");
                Utils.Configuration.DefaultConnectionString = Configuration.GetConnectionString("DefaultConnection");
>>>>>>> a5998828ba12fd296cb70903ba768bf3d92eb282
            }
        }
    }
}
