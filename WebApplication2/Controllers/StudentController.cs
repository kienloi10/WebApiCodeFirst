using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Api.Models;
using WebApplication2.ViewModels;
using static WebApplication2.ViewModels.StudentModel;

namespace WebApplication2.Controllers
{
    public class StudentController : ApiController
    {
       
       
        private ApiDBContext _db;
        public StudentController()
        {
            this._db = new ApiDBContext();

        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var listsvs = this._db.Students.Select(x => new StudentModel()
            {
                MaSV = x.MSSV,
                HoTenSV = x.HoTen,
                DiaChi = x.DiaChi

            });
            return Ok(listsvs);
        }


        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            IHttpActionResult httpActionResult;
            var sv = _db.Students.FirstOrDefault(x => x.Id == id);

            if (sv == null)
            {
                ErrorModel errors = new ErrorModel();
                errors.Add("Không tìm thấy sinh viên");

                httpActionResult = Ok(errors);
            }
            else
            {
                httpActionResult = Ok(new StudentModel(sv));
            }

            return httpActionResult;
        }

        [HttpPost]
        public IHttpActionResult TaoSV(CreateStudentModel model)
        {
            IHttpActionResult httpActionResult;
            ErrorModel errors = new ErrorModel();

            if (string.IsNullOrEmpty(model.MaSV))
            {
                errors.Add("Mã sv la bat buoc");
            }

            if (string.IsNullOrEmpty(model.HoTenSV))
            {
                errors.Add("Tên sv la bat buoc");
            }

            if (errors.Errors.Count == 0)
            {
                Student sv = new Student();
                sv.MSSV = model.MaSV;
                sv.HoTen = model.HoTenSV;
                sv.DiaChi = model.DiaChi;

                sv = _db.Students.Add(sv);

                this._db.SaveChanges();

                StudentModel viewModel = new StudentModel(sv);

                httpActionResult = Ok(viewModel);
            }
            else
            {
                httpActionResult = Ok(errors);
            }

            return httpActionResult;
        }




    }
}