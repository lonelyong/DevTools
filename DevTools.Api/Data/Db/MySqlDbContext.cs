using Microsoft.EntityFrameworkCore;
using DevTools.Api.Entities.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTools.Api.Data
{
	public class MySqlDbContext : DbContext
	{
		public DbSet<MD5> MD5s { get; set; }

		public MySqlDbContext(DbContextOptions options) : base(options)
		{

		}
	}
}
