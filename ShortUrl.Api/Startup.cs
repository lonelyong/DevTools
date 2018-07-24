using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ShortUrl.Api.Data;
using ShortUrl.Api.App;
using Swashbuckle.AspNetCore.SwaggerUI;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using Microsoft.Extensions.PlatformAbstractions;

namespace ShortUrl.Api
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "ShortUrl接口文档",
                    Description = "RESTful API for ShortUrl",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "Lonelyong", Email = "778652286@qq.com", Url = "" }
                });

                //Set the comments path for the swagger json and ui.
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "ShortUrl.Api.Xml");
                c.IncludeXmlComments(xmlPath);
            });

            services.AddMvc( options => {
                options.Filters.Add(new ExceptionFilter());
                options.Filters.Add(new ActionFilter());
            });
#if DEBUG
            services.AddDbContext<DefaultDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));
#else
            services.AddDbContext<DefaultDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
#endif 

            services.Configure<IISOptions>(options => options.AutomaticAuthentication = false);
            services.AddServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShortUrl API V1");
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                       name: "default",
                       template: "{id?}",
                       defaults: new { controller = "url" });
                routes.MapRoute(
                 name: "route",
                 template: "{controller}/{action}/{id?}");
            });
            app.UseCors(t=>t.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());
        }
    }
}
