using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models
{
    public class GiaoVien:Entity<int>
    {
        public string HoTen { get; set; }

        public virtual ICollection<Lop> Lops { get; set; } 
    }
}
