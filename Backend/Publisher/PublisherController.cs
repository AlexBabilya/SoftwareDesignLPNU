using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("api/publishers")]
public class PublisherController : ControllerBase
{
    private readonly PublisherRepository _publisherRepository;

    public PublisherController(PublisherRepository publisherRepository)
    {
        _publisherRepository = publisherRepository;
    }

    // GET: api/publishers
    [HttpGet]
    public ActionResult<IEnumerable<PublisherViewModel>> GetAllPublishers()
    {
        var publishers = _publisherRepository.GetAllPublishers();
        return Ok(publishers);
    }

    // GET: api/publishers/1
    [HttpGet("{id}")]
    public ActionResult<PublisherViewModel> GetPublisherById(int id)
    {
        var publisher = _publisherRepository.GetPublisherById(id);
        if (publisher == null)
        {
            return NotFound();
        }

        return Ok(publisher);
    }

    // POST: api/publishers
    [HttpPost]
    public IActionResult AddPublisher([FromBody] PublisherViewModel publisherCreateViewModel)
    {
        if (publisherCreateViewModel == null)
        {
            return BadRequest("Publisher object is null");
        }

        _publisherRepository.AddPublisher(publisherCreateViewModel);

        return CreatedAtAction(nameof(GetPublisherById), new { id = publisherCreateViewModel.Id }, publisherCreateViewModel);
    }

    // PUT: api/publishers/1
    [HttpPut("{id}")]
    public IActionResult UpdatePublisher(int id, [FromBody] PublisherViewModel publisherUpdateViewModel)
    {
        if (publisherUpdateViewModel == null || id != publisherUpdateViewModel.Id)
        {
            return BadRequest("Invalid data or publisher ID mismatch");
        }

        var existingPublisher = _publisherRepository.GetPublisherById(id);

        if (existingPublisher == null)
        {
            return NotFound();
        }

        _publisherRepository.UpdatePublisher(id, publisherUpdateViewModel);

        return NoContent();
    }

    // DELETE: api/publishers/1
    [HttpDelete("{id}")]
    public IActionResult DeletePublisher(int id)
    {
        var publisher = _publisherRepository.GetPublisherById(id);

        if (publisher == null)
        {
            return NotFound();
        }

        _publisherRepository.DeletePublisher(id);

        return NoContent();
    }
}

