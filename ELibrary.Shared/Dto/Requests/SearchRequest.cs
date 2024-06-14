using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Shared.Dto.Requests
{
    public class SearchRequest
    {
        public string Query { get; set; }
        public string LibrarySearchRule { get; set; }
        public bool SearchForNotTakenRule { get; set; } = true;
    }
}
