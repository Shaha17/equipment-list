using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace equipment_list.Models
{
	public class Employee
	{
		public Guid Id { get; set; }
		[Required(ErrorMessage = "Поле Фамилия обязательно к заполеннию")]
		[MinLength(3, ErrorMessage = "Минимальная длинна должна быть равна 3")]
		[MaxLength(20)]
		[Display(Name = "Фамилия")]
		public string LastName { get; set; }
		[Required(ErrorMessage = "Поле Имя обязательно к заполеннию")]
		[MinLength(3, ErrorMessage = "Минимальная длинна должна быть равна 3")]
		[MaxLength(20)]
		[Display(Name = "Имя")]
		public string FirstName { get; set; }
		[Display(Name = "Отчество")]
		[MinLength(3, ErrorMessage = "Минимальная длинна должна быть равна 3")]
		[MaxLength(20)]
		public string MiddleName { get; set; }
		[Required(ErrorMessage = "Поле Должность обязательно к заполеннию")]
		[MinLength(3, ErrorMessage = "Минимальная длинна должна быть равна 3")]
		[MaxLength(40)]
		[Display(Name = "Должность")]
		public string Position { get; set; }
		[Required(ErrorMessage = "Поле Подразделение обязательно к заполеннию")]
		[MinLength(3, ErrorMessage = "Минимальная длинна должна быть равна 3")]
		[MaxLength(50)]
		[Display(Name = "Подразделение")]
		public string Department { get; set; }
		[Required(ErrorMessage = "Поле Дата приёма на работу обязательно к заполеннию")]
		[DataType(DataType.Date)]
		[Display(Name = "Дата приёма на работу")]
		public DateTime HiringDate { get; set; }
		public bool Removed{ get; set; }



	}
}