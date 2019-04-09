#define USE_CASTLE
#define USE_STACKEXCHANGE_REDIS
#define USE_NLOG
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.Extensions.Logging;
using DevTools.Api.App;
using DevTools.Api.Data;
using DevTools.Api.Models;
using DevTools.Api.Models.Configuration;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Text;
using StackExchange.Redis;
using StackExchange.Redis.KeyspaceIsolation;
using Microsoft.Extensions.Caching.Redis;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.IdentityModel.Tokens;
using DevTools.Api.Common.Consts;
using System;
using System.Collections.Generic;
using MongoDB.Driver.Core;
using MySql.Data.EntityFrameworkCore;
using Devart.Data.Oracle.Entity;
using log4net;
using NLog.Web;
using NLog.Extensions.Logging;
using Castle.Windsor.MsDependencyInjection;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.LoggingFacility.MsLogging;
using DevTools.Api.App.Filters;
using DevTools.Api.App.Middlewares;
using DevTools.Api.Exceptions;
using DevTools.Api.App.Swagger;

namespace DevTools.Api
{
	/// <summary>
	/// 
	/// </summary>
	public class Startup 
    {
        private readonly IConfiguration _config;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
			var _appSettings = _config.Get<AppSettings>();
			services.AddLogging(options=> {
				//options.AddProvider();
				//options.AddNLog();
				//options.ConfigureNLog("");
			});
            services.Configure<AppSettings>(_config);
			services.AddSwaggerGen(c =>
            {
				c.SwaggerDoc("v1", new Info
				{
					Version = "v1",
					Title = "DevTools接口文档",
					//Description = "RESTful API for ShortUrl",
					//TermsOfService = "None",
					//Contact = new Contact { Name = "Lonelyong", Email = "yong-zh@qq.com", Url = "" },
					//License = new License() { Name = "MIT", Url = "http://www.gnu.org/licenses/gpl-3.0.html" },
                });
				//Set the comments path for the swagger json and ui.
				var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
				c.DescribeAllParametersInCamelCase();
				c.DescribeStringEnumsInCamelCase();
                c.IncludeXmlComments(xmlPath);
				c.DocumentFilter<HiddenApiFilter>();
				//添加一个必须的全局安全信息，和AddSecurityDefinition方法指定的方案名称要一致，这里是Bearer。
				c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> { { "Bearer", new string[] { } }, });
				//Authorization的设置
				c.AddSecurityDefinition("Bearer", new ApiKeyScheme
				{
					Description = "请输入Token: \"Authorization: Bearer {token}\"",
					Name = "Authorization",//jwt默认的参数名称
					In = "header",//jwt默认存放Authorization信息的位置(请求头中)
					Type = "apiKey"
				});
			});
            services.AddCors();
			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options=> {
				options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters() {
					NameClaimType = JwtClaimTypes.Name,
					RoleClaimType = JwtClaimTypes.Role,

					ValidIssuer = _config["Authentication:Jwt:ValidIssuer"],
					ValidAudience = _config["Authentication:Jwt:ValidAudience"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:Jwt:IssuerSigningKey"])),
					

					/***********************************TokenValidationParameters的参数默认值***********************************/
					// RequireSignedTokens = true,
					// SaveSigninToken = false,
					// ValidateActor = false,
					// 将下面两个参数设置为false，可以不验证Issuer和Audience，但是不建议这样做。
					ValidateAudience = true,
					ValidateIssuer = true,
					ValidateIssuerSigningKey = true,
					// 是否要求Token的Claims中必须包含Expires
					// RequireExpirationTime = true,
					// 允许的服务器时间偏移量
					ClockSkew = TimeSpan.FromSeconds(1000),
					// 是否验证Token有效期，使用当前时间与Token的Claims中的NotBefore和Expires对比
					ValidateLifetime = true
				};
				options.Events = new JwtBearerEvents() {
					OnMessageReceived = (context) => {
						if (!string.IsNullOrEmpty(context.HttpContext.Request.Query[RequestConsts.NAME_ACCESS_TOKEN]))
						{
							context.Token = context.HttpContext.Request.Query[RequestConsts.NAME_ACCESS_TOKEN];
						}
						return Task.CompletedTask;
					},
					OnTokenValidated = (context) => {
						

						return Task.CompletedTask;
					}
				}; 
			});
            services.AddMvc( options => {
                //options.Filters.Add(typeof(ExceptionFilter));
                options.Filters.Add(new ActionFilter());
				options.Filters.Add(new AuthoriztionFilter());
            });
            services.AddDbContext<MssqlDbContext>(options=> {
				options.UseSqlServer(/*_config["ConnectionStrings:DefaultConnection"]*/ _config.GetConnectionString("SqlServer"));
			}, ServiceLifetime.Scoped);
			services.AddDbContext<MySqlDbContext>(options => {
				options.UseMySQL(_config.GetConnectionString("MySql"));
			}, ServiceLifetime.Scoped);
			services.AddDbContext<OracleDbContext>(options=> {
				options.UseOracle(_appSettings.ConnectionStrings.Oracle, opts=> {
				});
			});

#if USE_STACKEXCHANGE_REDIS
			services.AddStackExchangeRedisCache(
				options=> {
				options.Password = _config["Connections:Redis:Password"];
				options.ClientName = _config["Connections:Redis:ClientName"];
				options.ConnectRetry = _config.GetValue<int>("Connections:Redis:ConnectRetry");
				options.ConnectTimeout = _config.GetValue<int>("Connections:Redis:ConnectTimeout");
				options.DefaultDatabase = _config.GetValue<int>("Connections:Redis:DefaultDatabase");
				options.EndPoints.Add(_config["Connections:Redis:EndPoint"]);
				options.ChannelPrefix = _config["Connections:Redis:ChannelPrefix"];
			}, 
				customOptions=> {
					customOptions.Prefix = _config["Connections:Redis:Prefix"];
			});
#else
			services.AddDistributedRedisCache(options => {
				options.Configuration = _config["ConnectionStrings:Redis"];
				options.InstanceName = _config["Connections:Redis:InstanceName"];
				//options.ConfigurationOptions = new StackExchange.Redis.ConfigurationOptions() {
				//	ChannelPrefix = _config["Redis:Default:ChannelPrefix"],
				//	Password = _config["Redis:Default:Password"],
				//	DefaultDatabase = _config.GetValue<int>("Redis:Default:DefaultDatabase")
				//};
			});
#endif
		
			services.Configure<IISOptions>(options => 
			{
				options.AutomaticAuthentication = false;
			});
			services.AddMq(options=> {
				options.UseRabbitMQ();
			});
			services.AddDistributedLocker(options=> {
				options.UseZookeeper();
			});
            services.AddServices();
#if USE_CASTLE
	var windsorContainer = new WindsorContainer();
			//windsorContainer.Register(Component.For);
			var windsorCastleServiceProvider = WindsorRegistrationHelper.CreateServiceProvider(windsorContainer, services);
			return windsorCastleServiceProvider;
#else
			return services.BuildServiceProvider();
#endif
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="app"></param>
		/// <param name="env"></param>
		/// <param name="loggerFactory"></param>
		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime lifetime)
		{
			// env.ConfigureNLog("nlog.config");
			// loggerFactory.AddCastleLogger(new Castle.Core.Logging.ConsoleFactory());
			if (env.IsDevelopment())
			{
				// 越明确的异常越后注册
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else if(env.IsProduction())
			{
				app.UseHttpsRedirection();
				app.UseAppExceptionErrorPage();
				//app.UseExceptionHandler(new ExceptionHandlerOptions() {
				//	ExceptionHandler = (httpContext) => { return Task.Run(()=> { httpContext.Response.Body.Write(Encoding.UTF8.GetBytes("Something went wrong!")); }); },
				//});
			}
			app.UseCors(t => t.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials());
			app.Map("/test", builder => {
				builder.Run(async x => {
					await x.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes("hello world!"));

				});
			});
			app.UseAuthentication();
			app.UseSwagger(options=> {
				//options.RouteTemplate = "doc/{documentName}";
			});
            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShortUrl API V1");
				c.HeadContent = "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">";
				//c.DocumentTitle = "接口文档";
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

	public class StartupFilter : IStartupFilter
	{
		public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
		{
			throw new NotImplementedException();
		}
	}

	public class HostStartup : IHostingStartup
	{
		public void Configure(IWebHostBuilder builder)
		{
			throw new NotImplementedException();
		}
	}
}
