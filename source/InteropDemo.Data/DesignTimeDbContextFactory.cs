using System.IO;
using InteropDemo.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace InteropDemo.Data
{
	public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<InteropDemoContext>
	{
		public InteropDemoContext CreateDbContext(string[] args)
		{
			IConfigurationRoot configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();
			var builder = new DbContextOptionsBuilder<InteropDemoContext>();
			var connectionString = configuration.GetConnectionString("DefaultConnection");
			builder.UseSqlite(connectionString);
			return new InteropDemoContext(builder.Options);
		}
	}
}
