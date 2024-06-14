using ELibrary.Catalog.Application;
using ELibrary.Catalog.DataContext.Domain;
using ELibrary.Catalog.DataContext.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ELibrary.Catalog.Controllers
{
	[ApiController]
	[Route("[conroller]")]
	public class CatalogController : ControllerBase
	{
		private readonly BookRepository _repo;
		private readonly SearchEngine _search;
        public CatalogController(
			BookRepository repo,
			SearchEngine search)
        {
            _repo = repo;
			_search = search;
        }
        [HttpGet("search")]
		public async Task<IActionResult> Search() // filters
		{
			var requestQuey = HttpContext.Request.Query;
			var searchTerms = SearchTerms.FromRequestQuery(requestQuey);
			var books = await _search.SearchAsync(searchTerms);
			if (books.Count == 0)
			{
				return NotFound("Не найдено ни одной книги по данному запросу");
			}
			var dtos = books
				.Select(x => x.ToShortDto())
				.ToList();
			return Ok(dtos);
		}

		[HttpGet("{bookId}")]
		public async Task<IActionResult> GetBook(string bookId)
		{
			var result = await _repo.GetByIdAsync(bookId);
			if (!result.IsSuccess)
			{
				return NotFound(result.Errors);	
			}
			var dto = result.Value.ToDto();
			return Ok(dto);
		}

		[HttpGet("get-state")]
		public async Task<IActionResult> GetBookStateInLibrary([FromQuery] string libraryId, [FromQuery] string bookId)
		{
			var result = await _repo.GetBookStateForLibraryAsync(bookId, libraryId);
			if (!result.IsSuccess)
			{
				return BadRequest(result.Errors);
			}
			return Ok(result.Value);
		}
	}
}
