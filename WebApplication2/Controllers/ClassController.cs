using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Api.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
	public class ClassController : ApiController
	{
		private ApiDBContext _db;

		public ClassController()
		{
			this._db = new ApiDBContext();

		}
        /**
        * @api [Post] /Class/TaoLop Tạo 1 lớp mới
        * @apigroup LOP
        * @apiPermission none 
        * 
        * @apiParam [string] MaLop Mã của lớp mới
        * @apiParam [string] TenLop Rên của lớp mới
        * @apiParam [int] [SoLuongLop] 
        * 
        * @apiParamExample [json] Request-Example:
        * {
        *   MaLop:"D14CQCN01",
        *   TenLop:"Công nghệ thông tin"
        * }
        * 
        * @apiSuccess [string] MaLop Mã của lớp vừa tạo
        * @apiSuccess [string] TenLop Rên của lớp vừa tạo
        * @apiSuccess [Id] Id của lớp mới
        * 
        * @apiSuccessExample [json] Success-Response:
        * {
        *   Id:1,
        *   MaLop:"D14CQCN01",
        *   TenLop: "Công nghệ thông tin"
        * 
        * }
        * 
        * @apiError [400] (string[]) Error các mảng lỗi
        * 
        * @apiErrorExample {json}
        * {
        *   "Errors":[
        *       MaLop là bat buoc,
        *       TenLop la bat buoc
        *   
        *   ]
        * }

        * */


        [HttpGet]
		public IHttpActionResult GetAll()
		{
                var listLops = this._db.Lops.Select(x => new ClassModel()
                {                  
                    MaLop = x.MaLop,
                    TenLop = x.TenLop,
                    Id = x.Id,
                });
			return Ok(listLops);
		}

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            IHttpActionResult httpActionResult;
            var lop = _db.Lops.FirstOrDefault(x => x.Id == id);

            if (lop == null)
            {
                ErrorModel errors = new ErrorModel();
                errors.Add("Không tìm thấy lớp");

                httpActionResult = Ok(errors);
            }
            else
            {
                httpActionResult = Ok(new ClassModel(lop));
            }

            return httpActionResult;
        }


        [HttpPost]
        public IHttpActionResult TaoLop(CreateClassModel model)
        {
            IHttpActionResult httpActionResult;
            ErrorModel errors = new ErrorModel();

            if (string.IsNullOrEmpty(model.MaLop))
            {
                errors.Add("Mã lop la bat buoc");
            }

            if (string.IsNullOrEmpty(model.TenLop))
            {
                errors.Add("Tên lop la bayt buoc");
            }

            if (errors.Errors.Count == 0)
            {
                Lop lop = new Lop();
                lop.MaLop = model.MaLop;
                lop.TenLop = model.TenLop;

                
               lop = _db.Lops.Add(lop);

                this._db.SaveChanges();

                ClassModel viewModel = new ClassModel(lop);

                httpActionResult = Ok(viewModel);
            }
            else
            {
                httpActionResult = Ok(errors);
            }

            return httpActionResult;
        }

        [HttpPut]
        public IHttpActionResult CapNhatLop(UpdateClassModel model)
        {
            IHttpActionResult httpActionResult;
            ErrorModel errors = new ErrorModel();

            Lop lop = this._db.Lops.FirstOrDefault(x => x.Id == model.Id);

            if (lop == null)
            {
                errors.Add("Không tìm thấy lớp");

                httpActionResult = Ok(errors);
            }
            else
            {
                lop.MaLop = model.MaLop ?? model.MaLop;
                lop.TenLop = model.TenLop ?? model.TenLop;

                this._db.Entry(lop).State = System.Data.Entity.EntityState.Modified;

                this._db.SaveChanges();

                httpActionResult = Ok(new ClassModel(lop));
            }

            return httpActionResult;
        }

    }
}