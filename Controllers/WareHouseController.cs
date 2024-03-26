using LibraryAPI.Repositories;
using LibraryAPI.Request;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers;
public class WareHouseController : LibraryApiBaseController
{
	private readonly BookRepository _bookRepository;

	public WareHouseController(BookRepository bookRepository)
	{
		_bookRepository = bookRepository;
	}

	[HttpGet("get-all/")]
	[ProducesResponseType(typeof(List<BookRepository>), StatusCodes.Status200OK)]
	[ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
	public IActionResult Index()
	{
		return Ok(_bookRepository.GetAllBooks());
	}

	[HttpGet("get-one/")]
	[ProducesResponseType(typeof(BookRepository), StatusCodes.Status200OK)]
	[ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
	public IActionResult GetBookById([FromQuery] int id)
	{
		var getBook = _bookRepository.GetBookForId(id);

		return Ok(getBook);
	}

	[HttpPost("create/")]
	[ProducesResponseType(typeof(RequestCreateBook), StatusCodes.Status201Created)]
	public IActionResult CreateBook([FromBody] RequestCreateBook request)
	{
		var getAllBooks = _bookRepository.GetAllBooks();
		var lastKey = getAllBooks.Last();

		_bookRepository.SetNewBook(lastKey.Key + 1, request.Title);

		//Uncomment to see the result in the array
		//return Ok(getAllBooks);

		return Created();
	}

	[HttpPut("edit/")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	public IActionResult EditBook([FromQuery] int id, [FromBody] RequestCreateBook request)
	{
		var getBook = _bookRepository.GetBookForId(id);

		if (getBook != null)
		{
			try
			{
				getBook["title"] = request.Title.Trim();

				//Uncomment to see the result in the array
				//return Ok(_bookRepository.GetAllBooks());

				return NoContent();

			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
				//throw new InvalidOperationException("Não foi possivel atualizar");
			}
		}

		return NoContent();
	}

	[HttpDelete("delete/")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	public IActionResult DeleteBook([FromQuery] int id)
	{
		_bookRepository.GetAllBooks().Remove(id);

		//Uncomment to see the result in the array
		//return Ok(_bookRepository.GetAllBooks());

		return NoContent();
	}
}
