using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Shared.Dto.Responses
{
	public class LoginResult
	{
		public bool IsSuccessful { get; set; }
		public string Token { get; set; }
		public string? Error { get; set; }
	}
}
