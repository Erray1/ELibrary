using ELibrary.Shared.Dto.Contractor;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELibrary.Contractor.DataContext.Entities
{
	public class ContractorOperation
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string Id { get; set; }
		public BookOperation Operation { get; set; }
		public string BookId { get; set; }
		public ContractorLibrary ContractorLibrary { get; set; }
		public string IssuerId { get; set; }
	}
}
