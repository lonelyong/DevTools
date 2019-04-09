using Microsoft.EntityFrameworkCore;
using DevTools.Api.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTools.Api.Data
{
	[Service(ServiceLife = Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped)]
	public class Repository<T> where T : Entities.EntityBase, new()
	{
		public DbSet<T> Value { get; }

		public Repository(MssqlDbContext dbContext)
		{
			Value = dbContext.Set<T>();
		}
	}
}
