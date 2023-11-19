using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/books")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly BookRepository _bookRepository;

    public BookController(BookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    // GET: api/books
    [HttpGet]
    public ActionResult<IEnumerable<Book>> GetAllBooks()
    {
        var books = _bookRepository.GetAllBooks();
        return Ok(books);
    }

    // GET: api/books/1
    [HttpGet("{id}")]
    public ActionResult<Book> GetBookById(int id)
    {
        var book = _bookRepository.GetBookById(id);

        if (book == null)
        {
            return NotFound();
        }

        return Ok(book);
    }

    // POST: api/books
    [HttpPost]
    public IActionResult AddBook([FromBody] Book book)
    {
        if (book == null)
        {
            return BadRequest("Book object is null");
        }

        _bookRepository.AddBook(book);

        return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
    }

    // PUT: api/books/1
    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id, [FromBody] Book book)
    {
        if (book == null || id != book.Id)
        {
            return BadRequest("Invalid input");
        }

        var existingBook = _bookRepository.GetBookById(id);

        if (existingBook == null)
        {
            return NotFound();
        }

        _bookRepository.UpdateBook(book);

        return NoContent();
    }

    // DELETE: api/books/1
    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        var book = _bookRepository.GetBookById(id);

        if (book == null)
        {
            return NotFound();
        }

        _bookRepository.DeleteBook(id);

        return NoContent();
    }
}


