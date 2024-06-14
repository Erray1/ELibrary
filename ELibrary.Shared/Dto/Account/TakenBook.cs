using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Shared.Dto.Account
{
    public class TakenBook
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<string> Authors { get; set; }
        public string LibraryName { get; set; }
        public DateTime RecieveTime { get; set; }
        public DateOnly ExpirationDate { get; set; }
        public bool IsExpired => ExpirationDate < DateOnly.FromDateTime(DateTime.Now);
    }
}
