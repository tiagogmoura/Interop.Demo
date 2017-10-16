using System;

namespace InteropDemo.Domain
{
    public class Student: BaseEntity
    {
	    public string Name { get; set; }
	    public string Email { get; set; }
		public string Phone { get; set; }
		public DateTime Birth { get; set; }
	    public int CourseId { get; set; }
		public virtual Course Course { get; set; }
    }
}
