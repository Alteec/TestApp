using API.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{

		public class DataContext : DbContext
		{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}

		public DbSet<SecretPost> Posts { get; set; }

		}
	}

