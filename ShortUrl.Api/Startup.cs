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
            services.AddMvc( options => {
                options.Filters.Add(new ExceptionFilter());
                options.Filters.Add(new App.ActionFilter());
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
            app.UseMvc();
            app.UseCors(t=>t.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());
        }
    }
}
