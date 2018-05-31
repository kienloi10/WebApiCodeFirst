using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.ViewModels
{
	public class ClassModel
	{
        public int Id { get; set; }
        public string MaLop { get; set; }
		public string TenLop { get; set; }
		

		public ClassModel() { }
		public ClassModel(Lop lop )
		{
            this.Id = lop.Id;
			this.MaLop = lop.MaLop;
			this.TenLop = lop.TenLop;          
			
		}
	}

	public class CreateClassModel
	{
		public string MaLop { get; set; }
		public string TenLop { get; set; }
	}

	public class UpdateClassModel : CreateClassModel
	{
		public int Id { get; set; }
	}
}