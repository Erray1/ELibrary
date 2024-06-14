using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Shared.Dto.Contractor
{
    public class AddNewBookContractorOperationModel
    {
        public string BookName { get; set; }
        public List<string> Authors { get; set; }
        public int WrittenYear { get; set; }
        [AllowedValues("Идеальное", "Потрёпанное")]
        public string Quality { get; set; }
    }
}
