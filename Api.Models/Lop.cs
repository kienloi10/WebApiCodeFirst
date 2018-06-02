using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models
{
    public class Lop:Entity<int>
    {
        public string MaLop { get; set; }
        public string TenLop { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual GiaoVien GVCN { get; set; }
        public virtual ICollection<GiaoVien> GiaoViens { get; set; }

       
    }
}
