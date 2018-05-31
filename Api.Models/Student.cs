using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models
{
	public class Student: Entity<long>
	{
		public string HoTen { get; set; }
		public string DiaChi { get; set; }
		public string MSSV { get; set; }
        public virtual Lop Lop { get; set; }
		//public virtual Course Course { get; set; }
		//public virtual ICollection<SinhVienMonHoc> Mon { get; set; }
	}
}
