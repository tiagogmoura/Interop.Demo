using System.ComponentModel.DataAnnotations;

namespace InteropDemo.Web.Models
{
    public class StudentViewModel
    {
		public int Id { get; set; }
	    
		[Required]
		public string Name { get; set; }

	    [Required]
		[EmailAddress(ErrorMessage = "E-mail inválido")]
		public string Email { get; set; }
	    public string Phone { get; set; }
	    public int CourseId { get; set; }
	    public virtual CourseViewModel Course { get; set; }
	}
}
