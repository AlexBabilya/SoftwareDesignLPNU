using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


[ApiController]
[Route("api/authors")]
public class AuthorController : ControllerBase
{
    private readonly AuthorRepository _authorRepository;

    public AuthorController(AuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<AuthorViewModel>> GetAllAuthors()
    {
        var authors = _authorRepository.GetAllAuthorViewModels();
        return Ok(authors);
    }

    [HttpGet("{id}")]
    public ActionResult<AuthorViewModel> GetAuthorById(int id)
    {
        var author = _authorRepository.GetAuthorViewModelById(id);
        if (author == null)
        {
            return NotFound();
        }

        return Ok(author);
    }

    [HttpPost]
    public IActionResult AddAuthor([FromBody] AuthorViewModel authorCreateViewModel)
    {
        if (authorCreateViewModel == null)
        {
            return BadRequest("Author object is null");
        }

        _authorRepository.AddAuthor(authorCreateViewModel);

        return CreatedAtAction(nameof(GetAuthorById), new { id = authorCreateViewModel.Id }, authorCreateViewModel);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAuthor(int id, [FromBody] AuthorViewModel authorUpdateViewModel)
    {
        if (authorUpdateViewModel == null || id != authorUpdateViewModel.Id)
        {
            return BadRequest("Invalid data or author ID mismatch");
        }

        _authorRepository.UpdateAuthor(id, authorUpdateViewModel);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAuthor(int id)
    {
        _authorRepository.DeleteAuthor(id);
        return NoContent();
    }
}

