using System.Collections.Generic;

namespace InteropDemo.Domain
{
	public class Course : BaseEntity
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string Room { get; set; }
		public double Investment { get; set; }
		public virtual ICollection<Student> Students { get; set; }
	}
}
