using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.ViewModels
{
    public class GiaoVienModel
    {
        
        public string HoTen { get; set; }


        public GiaoVienModel() { }
        public GiaoVienModel(GiaoVien giaoVien)
        {        
            this.HoTen = giaoVien.HoTen;

        }
    }

    public class CreateGiaoVienModel
    {
       
        public string TenGV { get; set; }
    }

    public class UpdateGiaoVienModel : CreateClassModel
    {
        public int Id { get; set; }
    }
}