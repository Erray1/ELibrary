using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Shared.Dto.Requests
{
	public class BookingRequest
	{
		public string BookId { get; set; }
		public string LibraryId { get; set; }
	}
}
