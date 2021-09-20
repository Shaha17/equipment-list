using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace equipment_list.Models
{
	public class Decommission
	{
		public Guid Id { get; set; }
		[Required(ErrorMessage = "Поле Причина обязательно к заполеннию")]
		[MinLength(3, ErrorMessage = "Минимальная длинна должна быть равна 3")]
		[MaxLength(100)]
		[Display(Name = "Причина списания")]
		public string Reason { get; set; }
		[Required(ErrorMessage = "Поле Дата списания обязательно к заполеннию")]
		[DataType(DataType.Date)]
		[Display(Name = "Дата списания")]
		public DateTime Date { get; set; }
		[Required(ErrorMessage = "Поле обязательно к заполеннию")]
		[Display(Name = "Сотрудник")]
		public Guid? EmployeeId { get; set; }
		[Required]
		[Display(Name = "Оборудование")]
		public Guid? EquipmentId { get; set; }
		[ForeignKey("EmployeeId")]
		public virtual Employee Employee { get; set; }
		[ForeignKey("EquipmentId")]
		public virtual Equipment Equipment { get; set; }
		public bool Removed { get; set; }


		[NotMapped]
		public string EquipmentStr { get; set; }
		[NotMapped]
		public List<SelectListItem> EmployeesList { get; set; }
	}
}