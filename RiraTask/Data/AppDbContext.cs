using Microsoft.EntityFrameworkCore;
using RiraTask.Entities;

namespace RiraTask.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
		{

		}
		public DbSet<Person> People { get; set; }
	}
}
