using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Data
{
	public class EmpoyeesAPIDbContext : DbContext
	{
		public EmpoyeesAPIDbContext(DbContextOptions options) : base(options)
		{
		}
		public DbSet<Employees> Employeess { get; set; }
	}
}
