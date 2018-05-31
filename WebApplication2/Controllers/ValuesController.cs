using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication2.Controllers
{
	public class ValuesController : ApiController
	{
		// GET api/values
		[HttpGet]
		public IEnumerable<string> GetAll()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/values/5
		[HttpGet]
		public string GetById(string   id)
		{
			return "value";
		}

		// POST api/values
		[HttpPost]
		public void TaoSinhVien([FromBody]string value)
		{
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/values/5
		public void Delete(int id)
		{
		}
	}
}
