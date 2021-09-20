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
	public class EquipmentController : Controller
	{
		private readonly ILogger<EquipmentController> _logger;
		private readonly EquipmentContext _context;

		public EquipmentController(ILogger<EquipmentController> logger, EquipmentContext context)
		{
			_logger = logger;
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			var equipments = await _context.Equipments.Where(eq => eq.Removed == false).ToListAsync();
			var decommissions = await _context.Decommissions.ToListAsync();

			equipments.ForEach(eq =>
			{
				if (decommissions.Exists(dec => dec.EquipmentId == eq.Id))
				{
					eq.IsDecommissioned = true;
				};
			});

			return View(equipments);
		}
		[HttpGet]
		public IActionResult Create()
		{
			Equipment eq = new Equipment();
			eq.DeliveryDate = DateTime.Now;
			return View(eq);
		}
		[HttpPost]
		public async Task<IActionResult> Create(Equipment model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			_context.Equipments.Add(model);

			await _context.SaveChangesAsync();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public async Task<IActionResult> Delete(Guid Id)
		{
			var eq = await _context.Equipments.FirstOrDefaultAsync(p => p.Id.Equals(Id));
			if (eq == null)
			{
				return RedirectToAction("Index", "Equipment");
			}

			eq.Removed = true;

			await _context.SaveChangesAsync();

			return RedirectToAction("Index", "Equipment");
		}




		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
