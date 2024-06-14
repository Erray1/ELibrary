using ELibrary.Shared.Dto.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Shared.Dto.Contractor
{
    public class ContractorOperationDto
    {
        public string OperationId { get; set; }
        public string IssuerId { get; set; }
        public string BookId { get; set; }
        public BookOperation Operation { get; set; }
    }
}
