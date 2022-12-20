using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class EmployeeController : Controller
	{
		private readonly EmpoyeesAPIDbContext db;
		public EmployeeController(EmpoyeesAPIDbContext db) { 
			this.db = db;
		}
		[HttpGet]
		public async Task<IActionResult> GetEmployees()
		{
			return Ok(await db.Employeess.ToListAsync());
		}
		[HttpPost]
		public async Task<IActionResult> AddEmployee(AddEmployees add)
		{
			var employees = new Employees()
			{
				Id = Guid.NewGuid(),
				FullName = add.FullName,
				Age = add.Age,
				Sex = add.Sex,
				HomeTown = add.HomeTown
			}; 
			await db.Employeess.AddAsync(employees);
			await db.SaveChangesAsync();


			return Ok(employees);
		}
		[HttpPut]
		[Route("{id:guid}")]
		public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, UpdateEmployee update)
		{
			var employee = await db.Employeess.FindAsync(id);
			if(employee != null)
			{
				employee.FullName = update.FullName;
				employee.Age = update.Age;
				employee.HomeTown = update.HomeTown;
				employee.Sex = update.Sex;
				await db.SaveChangesAsync();
				return Ok(employee);
			}
			return NotFound();
			
		}
		[HttpGet]
		[Route("{id:guid}")]
		public async Task<IActionResult> GetEmployee([FromRoute] Guid id)
		{
			var employee = await db.Employeess.FindAsync(id);
			if (employee == null)
			{
				
				return NotFound();
			}
			return Ok(employee);

		}
		[HttpDelete]
		[Route("{id:guid}")]
		public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
		{
			var employee = await db.Employeess.FindAsync(id);
			if (employee != null)
			{

				db.Remove(employee);
				await db.SaveChangesAsync();
				return Ok(employee);
			}
			return NotFound();

		}
	}
}
