using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
	public class Employees
	{
		public Guid Id { get; set; }
		public string FullName { get; set; }
		public int Age { get; set; }
		public string Sex { get; set; }
		public string HomeTown { get; set; }

	}
}
