using ELibrary.Contractor.Application;
using ELibrary.Contractor.DataContext;
using ELibrary.Shared.Dto.Contractor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ELibrary.Contractor.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class ContractorController : ControllerBase
	{
		private readonly ContractorService _contractorService;
        public ContractorController(ContractorService contractorService)
        {
            _contractorService = contractorService;
        }
        private string contractorId => HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!;
		[HttpGet("operations")]
		public async Task<IActionResult> GetOperations()
		{
			var operationsResult = await _contractorService.GetOperations(contractorId);
			if (!operationsResult.IsSuccess)
			{
				return BadRequest(operationsResult.Errors);
			}
			var operations = operationsResult.Value;
			if (operations.Count == 0)
			{
				return NotFound("Операции закончились");
			}
			var dtos = operations
				.Select(x => x.ToDto())
				.ToList();
			return Ok(dtos);
		}

		[HttpPatch("change-state/{operationId}")]
		public async Task<IActionResult> ChangeOperationState(string operationId, [FromBody] BookOperation operation)
		{
			var result = await _contractorService.ChangeOperationState(operationId, operation);
			if (!result.IsSuccess)
			{
				return BadRequest(result.Errors);
			}
			return Accepted();
		}


		[HttpPost("add-book")]
		public async Task<IActionResult> AddBook()
		{
			return StatusCode(StatusCodes.Status501NotImplemented);
		}
	}
}
