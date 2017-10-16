using InteropDemo.Data.Mappers;
using InteropDemo.Domain;
using Microsoft.EntityFrameworkCore;

namespace InteropDemo.Data.Context
{
	public class InteropDemoContext : DbContext
	{
		public InteropDemoContext(DbContextOptions<InteropDemoContext> options) : base(options)
		{
		}

		public DbSet<Student> Students { get; set; }
		public DbSet<Course> Courses { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			new StudentMap(modelBuilder.Entity<Student>());
			new CourseMap(modelBuilder.Entity<Course>());
		}
	}
}
