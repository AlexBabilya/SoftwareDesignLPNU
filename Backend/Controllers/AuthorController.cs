using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/authors")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly AuthorRepository _authorRepository;

    public AuthorController(AuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    // GET: api/authors
    [HttpGet]
    public ActionResult<IEnumerable<Author>> GetAllAuthors()
    {
        var authors = _authorRepository.GetAllAuthors();
        return Ok(authors);
    }

    // GET: api/authors/1
    [HttpGet("{id}")]
    public ActionResult<Author> GetAuthorById(int id)
    {
        var author = _authorRepository.GetAuthorById(id);

        if (author == null)
        {
            return NotFound();
        }

        return Ok(author);
    }

    // POST: api/authors
    [HttpPost]
    public IActionResult AddAuthor([FromBody] Author author)
    {
        if (author == null)
        {
            return BadRequest("Author object is null");
        }

        _authorRepository.AddAuthor(author);

        return CreatedAtAction(nameof(GetAuthorById), new { id = author.Id }, author);
    }

    // PUT: api/authors/1
    [HttpPut("{id}")]
    public IActionResult UpdateAuthor(int id, [FromBody] Author author)
    {
        if (author == null || id != author.Id)
        {
            return BadRequest("Invalid data or author ID mismatch");
        }

        var existingAuthor = _authorRepository.GetAuthorById(id);

        if (existingAuthor == null)
        {
            return NotFound();
        }

        _authorRepository.UpdateAuthor(author);

        return NoContent();
    }

    // DELETE: api/authors/1
    [HttpDelete("{id}")]
    public IActionResult DeleteAuthor(int id)
    {
        var author = _authorRepository.GetAuthorById(id);

        if (author == null)
        {
            return NotFound();
        }

        _authorRepository.DeleteAuthor(id);

        return NoContent();
    }
}

