using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Shared.Dto.Account
{
    public class AccountDto
    {
        public string Name { get; set; }
        public List<TakenBook> TakenBooks { get; set; } = new();
        public List<BookedBook> BookedBooks { get; set; } = new();
    }
}
