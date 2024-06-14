using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Shared.Dto.Contractor
{
    public class NewContractorOperationModel
    {
        public Guid OperationId { get; set; } = Guid.NewGuid();
        public string IssuerPassport { get; set; }
        public BookOperation BookOperation { get; set; }
        public string? BookId { get; set; }
    }
}
