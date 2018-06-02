using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models
{
    public class GiaoVien:Entity<int>
    {
        public string HoTen { get; set; }
        [InverseProperty("GiaoViens")]
        public virtual ICollection<Lop> LopDays { get; set; }
        [InverseProperty("GVCN")]
        public virtual ICollection<Lop> LopCNs { get; set; }

    }
}
