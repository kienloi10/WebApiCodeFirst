using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.ViewModels
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string MaSV { get; set; }
        public string HoTenSV { get; set; }
        public string DiaChi { get; set; }

        public StudentModel() { }
        public StudentModel(Student student)
        {
            
            this.HoTenSV = student.HoTen;
            this.MaSV = student.MSSV;
            this.DiaChi = student.DiaChi;

        }

        public class CreateClassModel
        {
            public string MaSV { get; set; }
            public string HoTenSV { get; set; }
            public string DiaChi { get; set; }
        }

        public class UpdateClassModel : CreateClassModel
        {
            public int Id { get; set; }
        }
    }
}