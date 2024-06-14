using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Shared.Contracts
{
	public record BookWasTakenEvent(
		string BookId,
		string LibraryId,
		string UserId,
		DateTime RecieveTime,
		DateOnly ReturnDate
		);
}
