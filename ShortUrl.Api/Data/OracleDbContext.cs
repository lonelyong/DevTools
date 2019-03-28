using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortUrl.Api.Data
{
	public class OracleDbContext : DbContext
	{

		public OracleDbContext(DbContextOptions options):base(options)
		{

		}
	}
}
