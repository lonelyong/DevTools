using Microsoft.EntityFrameworkCore;
using ShortUrl.Api.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortUrl.Api.Data
{
	[Service(ServiceLife = Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped)]
	public class Repository<T> where T : Entities.EntityBase, new()
	{
		public DbSet<T> Value { get; }

		public Repository(DefaultDbContext dbContext)
		{
			Value = dbContext.Set<T>();
		}
	}
}
