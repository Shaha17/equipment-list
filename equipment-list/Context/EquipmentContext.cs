using equipment_list.Models;
using Microsoft.EntityFrameworkCore;

namespace equipment_list.Context
{
	public class EquipmentContext : DbContext
	{

		public EquipmentContext()
		{
		}
		public EquipmentContext(DbContextOptions options) : base(options)
		{
		}


		public DbSet<Employee> Employees { get; set; }
		public DbSet<Equipment> Equipments { get; set; }
		public DbSet<Decommission> Decommissions { get; set; }


		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}

	}
}