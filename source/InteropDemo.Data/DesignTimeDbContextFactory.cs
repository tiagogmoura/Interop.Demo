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
			//var builder = new DbContextOptionsBuilder<InteropDemoContext>();
			//builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=pinchdb;Trusted_Connection=True;MultipleActiveResultSets=true");
			//return new InteropDemoContext(builder.Options);

			IConfigurationRoot configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();
			var builder = new DbContextOptionsBuilder<InteropDemoContext>();
			var connectionString = configuration.GetConnectionString("DefaultConnection");
			builder.UseSqlServer(connectionString);
			return new InteropDemoContext(builder.Options);
		}
	}
}
