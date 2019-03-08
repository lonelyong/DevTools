using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using ShortUrl.Api.App;
using ShortUrl.Api.Data;
using ShortUrl.Api.Models;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using System.Reflection;

namespace ShortUrl.Api
{
	/// <summary>
	/// 
	/// </summary>
	public class Startup
    {
        IConfiguration configuration;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(configuration);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "ShortUrl接口文档",
                    //Description = "RESTful API for ShortUrl",
                    //TermsOfService = "None",
                    //Contact = new Contact { Name = "Lonelyong", Email = "778652286@qq.com", Url = "" }
                });

                //Set the comments path for the swagger json and ui.
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
                c.IncludeXmlComments(xmlPath);
            });
            services.AddCors();
            services.AddAuthorization(options=> {
               
            });
            services.AddMvc( options => {
                options.Filters.Add(new ExceptionFilter());
                options.Filters.Add(new ActionFilter());
				options.Filters.Add(new AuthoriztionFilter());
            });
            services.AddDbContext<DefaultDbContext>();
            services.Configure<IISOptions>(options => options.AutomaticAuthentication = false);
            services.AddServices();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(t => t.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials());
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShortUrl API V1");
				c.HeadContent = "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">";
				c.DocumentTitle = "ShortUrl接口文档";
            });
            app.Map("/test", builder=> {
                builder.Run(async x=> {
                    await x.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes("hello world"));
                    
                });
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                       name: "default",
                       template: "{id?}",
                       defaults: new { controller = "Home", action="Index"});
                routes.MapRoute(
                     name: "route",
                     template: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
