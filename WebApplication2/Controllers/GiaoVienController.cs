using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Api.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class GiaoVienController : ApiController
    {


        private ApiDBContext _db;
        public GiaoVienController()
        {
            this._db = new ApiDBContext();

        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var listgvs = this._db.GiaoViens.Select(x => new GiaoVienModel()
            {
                HoTen = x.HoTen

            });
            return Ok(listgvs);
        }


        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            IHttpActionResult httpActionResult;
            var gv = _db.GiaoViens.FirstOrDefault(x => x.Id == id);

            if (gv == null)
            {
                ErrorModel errors = new ErrorModel();
                errors.Add("Không tìm thấy Gíao viên");

                httpActionResult = Ok(errors);
            }
            else
            {
                httpActionResult = Ok(new GiaoVienModel(gv));
            }

            return httpActionResult;
        }


        [HttpPost]
        public IHttpActionResult TaoGV(CreateGiaoVienModel model)
        {
            IHttpActionResult httpActionResult;
            ErrorModel errors = new ErrorModel();

            
            if (string.IsNullOrEmpty(model.TenGV))
            {
                errors.Add("Tên GV là bat buoc");
            }

            if (errors.Errors.Count == 0)
            {
                GiaoVien gv = new GiaoVien();
                gv.HoTen = model.TenGV;


                gv = _db.GiaoViens.Add(gv);

                this._db.SaveChanges();

                GiaoVienModel viewModel = new GiaoVienModel(gv);

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
