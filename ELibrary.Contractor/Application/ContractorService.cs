using Ardalis.Result;
using ELibrary.Contractor.DataContext;
using ELibrary.Contractor.DataContext.Entities;
using ELibrary.Shared.Contracts;
using ELibrary.Shared.Dto.Contractor;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.Contractor.Application
{
	public class ContractorService
	{
		private readonly ContractorDbContext _dbContext;
		private readonly IPublishEndpoint _publishEndpoint;
		private readonly int _bookHoldingDurationDays;
		public ContractorService(
			ContractorDbContext dbContext,
			IPublishEndpoint publishEndpoint,
			IConfiguration configuration) {
			_bookHoldingDurationDays = Convert.ToInt32(configuration.GetSection("BookHoldingDurationDays").Value);
		}
		public async Task<Result<List<ContractorOperation>>> GetOperations(string contractorId)
		{
			var contractorLibrary = await _dbContext.Libraries.SingleOrDefaultAsync(x => x.ContractorId == contractorId);
			if (contractorLibrary is null)
			{
				return Result.NotFound($"Исполнитель с id {contractorId} нигде не работает");
			}
			string libraryId = contractorLibrary.LibraryId;
			var commands = await _dbContext.Operations
				.Where(x => x.ContractorLibrary.ContractorId == contractorId && x.ContractorLibrary.LibraryId == libraryId)
				.ToListAsync();
			return Result.Success(commands);
		}

		public async Task<Result> ChangeOperationState(string operationId, BookOperation operation)
		{
			var operationEntity = await _dbContext.Operations
				.SingleOrDefaultAsync(x => x.Id == operationId);
			if (operationEntity is null)
			{
				return Result.NotFound($"Операция с id {operationId} не найдена");
			}
			if (operationEntity.Operation == operation)
			{
				return Result.Error($"Попытка изменения статуса на аналогичный");
			}
			if (operation == BookOperation.Completed)
			{
				await completeOperation(operationEntity);
				return Result.Success();
			}
			operationEntity.Operation = operation;
			await _dbContext.SaveChangesAsync();
			return Result.Success();
		}

		private async Task completeOperation(ContractorOperation operation)
		{
			if (operation.Operation == BookOperation.Recieve)
			{
				DateTime recieveTime = DateTime.Now;
				DateOnly returnDate = DateOnly.FromDateTime(recieveTime.AddDays(_bookHoldingDurationDays));
				BookWasTakenEvent newEvent = new(operation.BookId, operation.ContractorLibrary.LibraryId, operation.IssuerId, recieveTime, returnDate);
				await _publishEndpoint.Publish(newEvent);
			}
			else if (operation.Operation == BookOperation.Return)
			{
				DateOnly returnDate = DateOnly.FromDateTime(DateTime.Now);
				BookWasReturnedEvent newEvent = new(operation.BookId, operation.ContractorLibrary.LibraryId, operation.IssuerId, returnDate);
				await _publishEndpoint.Publish(newEvent);
			}
		}
	}
}
