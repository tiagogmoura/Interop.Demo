using InteropDemo.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InteropDemo.Data.Mappers
{
    public class StudentMap
    {
		public StudentMap(EntityTypeBuilder<Student> entityBuilder)
	    {
			entityBuilder.HasKey(s => s.Id);

		    entityBuilder.Property(s => s.Name)
			    .HasMaxLength(100)
			    .IsRequired();

		    entityBuilder.Property(s => s.Email)
			    .HasMaxLength(200);

			entityBuilder.Property(s => s.Phone)
			    .HasMaxLength(30);

		    entityBuilder.HasOne(s => s.Course)
				.WithMany(c => c.Students)
				.HasForeignKey(s => s.CourseId);
	    }
	}
}
