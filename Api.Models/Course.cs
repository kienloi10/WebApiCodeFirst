using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models
{
	public class Course : Entity<int>
	{
		public string Ma { get; set; }
		public string Ten { get; set; }
		public virtual ICollection<Student> Students { get; set; }
	}
}
