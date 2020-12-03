using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
	public class StudentEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Age { get; set; }
		public string Gander { get; set; }
		public decimal Score { get; set; }
		public string Say { get; set; }
	}
}