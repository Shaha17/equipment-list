using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using equipment_list.Context;
using equipment_list.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace equipment_list.Controllers
{
	public class EmployeeController : Controller
	{
		private readonly ILogger<EmployeeController> _logger;
		private readonly EquipmentContext _context;

		public EmployeeController(ILogger<EmployeeController> logger, EquipmentContext context)
		{
			_logger = logger;
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			var lst = await _context.Employees.Where(emp => emp.Removed == false).ToListAsync();

			return View(lst);
		}
		[HttpGet]
		public IActionResult Create()
		{
			Employee emp = new Employee();
			emp.HiringDate = DateTime.Now;
			return View(emp);
		}
		[HttpPost]
		public async Task<IActionResult> Create(Employee model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			_context.Employees.Add(model);
			await _context.SaveChangesAsync();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public async Task<IActionResult> Delete(Guid Id)
		{
			var emp = await _context.Employees.FirstOrDefaultAsync(p => p.Id.Equals(Id));
			if (emp == null)
			{
				return RedirectToAction("Index", "Employee");
			}

			emp.Removed = true;

			await _context.SaveChangesAsync();

			return RedirectToAction("Index", "Employee");

		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
