using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using equipment_list.Context;
using equipment_list.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace equipment_list.Controllers
{
	public class DecommissionController : Controller
	{
		private readonly ILogger<DecommissionController> _logger;
		private readonly EquipmentContext _context;

		public DecommissionController(ILogger<DecommissionController> logger, EquipmentContext context)
		{
			_logger = logger;
			_context = context;
		}

		public async Task<IActionResult> Index()
		{

			var lst = await _context.Decommissions.Where(p=>p.Removed==false).ToListAsync();

			return View(lst);
		}



		[HttpGet]
		public async Task<IActionResult> Create([FromRoute] Guid id)
		{
			var eq = await _context.Equipments.Where(p => p.Removed == false).FirstOrDefaultAsync(p => p.Id.Equals(id));
			if (eq == null)
			{
				return RedirectToAction("Index", "Equipment");
			}
			var employees = await _context.Employees.Where(g => g.Removed == false).Select(p => new SelectListItem
			{
				Value = p.Id.ToString(),
				Text = $"{p.LastName} {p.FirstName} {p.MiddleName} ({p.Department})"
			}).ToListAsync();

			Decommission dec = new Decommission()
			{
				EquipmentId = eq.Id,
				Date = DateTime.Now,
				EmployeesList = employees,
				EquipmentStr = eq.Name + " " + eq.DeliveryDate.ToShortDateString()
			};

			return View("Create", dec);
		}
		[HttpPost]
		public IActionResult Create(Decommission model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			_context.Decommissions.Add(model);
			_context.SaveChangesAsync();

			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> Delete(Guid Id)
		{
			var dec = await _context.Decommissions.FirstOrDefaultAsync(p => p.Id.Equals(Id));
			if (dec == null)
			{
				return RedirectToAction("Index", "Decommission");
			}

			dec.Removed = true;

			await _context.SaveChangesAsync();

			return RedirectToAction("Index", "Decommission");

		}
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
