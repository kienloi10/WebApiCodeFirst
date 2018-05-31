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

		

		[HttpGet]
		public IHttpActionResult GetAllLop()
		{
                var listLops = this._db.Lops.Select(x => new ClassModel()
                {
                    Id = x.Id,
                    MaLop = x.MaLop,
                    TenLop = x.TenLop

                });
			return Ok(listLops);
		}

        [HttpGet]
        public IHttpActionResult GetAllSV()
        {
            var listsvs = this._db.Students.Select(x => new StudentModel()
            {
                MaSV = x.MSSV,
                HoTenSV = x.HoTen,
                DiaChi = x.DiaChi

            });
            return Ok(listsvs);
        }
    }
}