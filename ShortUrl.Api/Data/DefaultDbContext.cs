using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ShortUrl.Api.Models;
using Microsoft.Extensions.Options;

namespace ShortUrl.Api.Data
{
    public class DefaultDbContext : DbContext
    {
		//private readonly AppSettings _appSettings;
		/*
		 Add-Migration UpdateDatabase
		 Update-Database -v
			 */

		public DbSet<Entities.Url> Urls { get; set; }

		public DbSet<Entities.User> Users { get; set; }

        public DefaultDbContext(DbContextOptions<DefaultDbContext> options/*, IOptions<AppSettings> appSettings*/) :base(options)
        {
            //this._appSettings = appSettings.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(_appSettings.ConnectionStrings.DefaultConnection);
        }
    }
}
