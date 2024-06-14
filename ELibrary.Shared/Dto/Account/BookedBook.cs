using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Shared.Dto.Account
{
    public class BookedBook
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<string> Authors { get; set; }
        public string LibraryName { get; set; }
        public DateTime ExpirationDate { get; set; }
        public BookBookingStatus Status { get; set; }
    }
}
