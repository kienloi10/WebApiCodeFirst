using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.ViewModels
{
	public class ErrorModel
	{
		public List<string> Errors { get; set; }
		public ErrorModel()
		{
			this.Errors = new List<string>();
		}
		public void Add(string error)
		{
			this.Errors.Add(error);
		}
	}
}