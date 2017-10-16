using InteropDemo.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InteropDemo.Data.Mappers
{
	public class CourseMap
    {
	    public CourseMap(EntityTypeBuilder<Course> entityBuilder)
	    {
		    entityBuilder.HasKey(c => c.Id);
		    
			entityBuilder.Property(c => c.Title)
				.HasMaxLength(200)
				.IsRequired();

		    entityBuilder.Property(c => c.Description)
			    .HasMaxLength(4000);

		    entityBuilder.Property(c => c.Room)
			    .HasMaxLength(10)
			    .IsRequired();

		    entityBuilder.Property(c => c.Investment)
			    .IsRequired();
	    }
	}
}
