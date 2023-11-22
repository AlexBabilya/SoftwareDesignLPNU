using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("api/books")]
public class BookController : ControllerBase
{
    private readonly BookRepository _bookRepository;

    public BookController(BookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    // GET: api/books
    [HttpGet]
    public ActionResult<IEnumerable<BookViewModel>> GetAllBooks()
    {
        var books = _bookRepository.GetAllBookViewModels();
        return Ok(books);
    }

    // GET: api/books/1
    [HttpGet("{id}")]
    public ActionResult<BookViewModel> GetBookById(int id)
    {
        var book = _bookRepository.GetBookViewModelById(id);
        if (book == null)
        {
            return NotFound();
        }

        return Ok(book);
    }

    // POST: api/books
    [HttpPost]
    public IActionResult AddBook([FromBody] BookViewModel bookCreateViewModel)
    {
        if (bookCreateViewModel == null)
        {
            return BadRequest("Book object is null");
        }

        _bookRepository.AddBook(bookCreateViewModel);

        return CreatedAtAction(nameof(GetBookById), new { id = bookCreateViewModel.Id }, bookCreateViewModel);
    }

    // PUT: api/books/1
    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id, [FromBody] BookViewModel bookUpdateViewModel)
    {
        if (bookUpdateViewModel == null || id != bookUpdateViewModel.Id)
        {
            return BadRequest("Invalid data or book ID mismatch");
        }

        var existingBook = _bookRepository.GetBookViewModelById(id);

        if (existingBook == null)
        {
            return NotFound();
        }

        _bookRepository.UpdateBook(id, bookUpdateViewModel);

        return NoContent();
    }

    // DELETE: api/books/1
    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        var book = _bookRepository.GetBookViewModelById(id);

        if (book == null)
        {
            return NotFound();
        }

        _bookRepository.DeleteBook(id);

        return NoContent();
    }
}

