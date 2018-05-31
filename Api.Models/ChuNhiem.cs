using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models
{
    public class ChuNhiem : Entity<int>
    {
        public virtual Lop Lop { get; set; } 
        public virtual GiaoVien GiaoVien { get; set; }
        public float Diem { get; set; }
    }
}
