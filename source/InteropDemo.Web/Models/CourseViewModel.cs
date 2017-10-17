using System.ComponentModel.DataAnnotations;

namespace InteropDemo.Web.Models
{
    public class CourseViewModel
	{
		public int Id { get; set; }
		
		[Required]
		public string Title { get; set; }
		public string Description { get; set; }
		[Required]
		public string Room { get; set; }
		public double Investment { get; set; }
	}
}
