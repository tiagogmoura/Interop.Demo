namespace InteropDemo.Web.Models
{
    public class StudentViewModel
    {
		public int Id { get; set; }
	    public string Name { get; set; }
	    public string Email { get; set; }
	    public string Phone { get; set; }
	    public int CourseId { get; set; }
	    public virtual CourseViewModel Course { get; set; }
	}
}
