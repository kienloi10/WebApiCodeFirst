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
		public IHttpActionResult GetAll()
		{

            var listsvs = this._db.Students.Where(Select );
                var listLops = this._db.Lops.Select(x => new ClassModel()
                {
                    Id = x.Id,
                    MaLop = x.MaLop,
                    TenLop = x.TenLop

                });
            
                _

			return Ok(listLops);
		}

		
	}
}