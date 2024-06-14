using ELibrary.Contractor.DataContext.Entities;
using ELibrary.Shared.Dto.Contractor;

namespace ELibrary.Contractor.DataContext
{
	public static class Mapping
	{
		public static ContractorOperationDto ToDto(this ContractorOperation operation)
		{
			return new ContractorOperationDto()
			{
				IssuerId = operation.IssuerId,
				BookId = operation.BookId,
				Operation = operation.Operation,
				OperationId = operation.Id
			};
		}
	}
}
