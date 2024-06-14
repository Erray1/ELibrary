using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Shared.Dto.Requests
{
	public class RegisterModel
	{
		public string Name { get; set; }
		[DataType(DataType.EmailAddress, ErrorMessage = "Неверно указан адрес")]
		public string Email { get; set; }
		[RegularExpression("[0-9]{4} [0-9]{6}", ErrorMessage = "Неверные паспортные данные")]
		
		public string Passport { get; set; }
		[DataType(DataType.Password, ErrorMessage = "Слишком простой пароль")]
		public string Password { get; set; }
	}
}
