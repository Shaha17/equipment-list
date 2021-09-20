using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace equipment_list.Models
{
	public class Equipment
	{
		public Guid Id { get; set; }
		[Required(ErrorMessage = "Поле Название обязательно к заполеннию")]
		[MinLength(3, ErrorMessage = "Минимальная длинна должна быть равна 3")]
		[MaxLength(50)]
		[Display(Name = "Название оборудования")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Поле Тип оборудования обязательно к заполеннию")]
		[MinLength(3, ErrorMessage = "Минимальная длинна должна быть равна 3")]
		[MaxLength(40)]
		[Display(Name = "Тип оборудования")]
		public string Type { get; set; }
		[Required(ErrorMessage = "Поле Дата поступления обязательно к заполеннию")]
		[DataType(DataType.Date)]
		[Display(Name = "Дата поступления")]
		public DateTime DeliveryDate { get; set; }
		[Required(ErrorMessage = "Поле ФИО отвественного обязательно к заполеннию")]
		[MinLength(3, ErrorMessage = "Минимальная длинна должна быть равна 3")]
		[MaxLength(70)]
		[Display(Name = "ФИО ответственного")]
		public string ResponsiblePersonFullName { get; set; }
		[Required(ErrorMessage = "Поле Место установки обязательно к заполеннию")]
		[MinLength(3, ErrorMessage = "Минимальная длинна должна быть равна 3")]
		[MaxLength(100)]
		[Display(Name = "Место установки")]
		public string MountingLocation { get; set; }
		[NotMapped]
		[Display(Name = "Списано?")]
		public bool IsDecommissioned { get; set; }

		public bool Removed { get; set; }
	}
}