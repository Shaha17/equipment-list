using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using equipment_list.Context;
using equipment_list.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace equipment_list
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var host = CreateHostBuilder(args).Build();

			using var scope = host.Services.CreateScope();
			var services = scope.ServiceProvider;
			var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
			try
			{
				var context = services.GetRequiredService<EquipmentContext>();
				await context.Database.MigrateAsync();
				// var testEmployee = new Employee()
				// {
				// 	Id = Guid.NewGuid(),
				// 	LastName = "last",
				// 	FirstName = "first",
				// 	MiddleName = "middle",
				// 	HiringDate = DateTime.Now,
				// 	Position = "poss",
				// 	Department = "depart"
				// };
				// context.Employees.Add(testEmployee);
				// var testEquipment = new Equipment()
				// {
				// 	Id = Guid.NewGuid(),
				// 	Name = "test-name",
				// 	Type = "test-type",
				// 	DeliveryDate = DateTime.Now,
				// 	ResponsiblePersonFullName = "test-resp-name",
				// 	MountingLocation = "test-location",
				// };
				// context.Equipments.Add(testEquipment);
				// var testDecommission = new Decommission()
				// {
				// 	Id = Guid.NewGuid(),
				// 	Reason = "test-reason",
				// 	Date = DateTime.Now,
				// 	Employee = testEmployee,
				// 	Equipment = testEquipment,
				// };
				// context.Decommissions.Add(testDecommission);


				await context.SaveChangesAsync();

				logger.LogInformation("Migrate successfull");
			}
			catch (Exception ex)
			{
				logger.LogError(ex.Message);
			}

			await host.RunAsync();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
