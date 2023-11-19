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
    public ActionResult<IEnumerable<Publisher>> GetAllPublishers()
    {
        var publishers = _publisherRepository.GetAllPublishers();
        return Ok(publishers);
    }

    // GET: api/publishers/1
    [HttpGet("{id}")]
    public ActionResult<Publisher> GetPublisherById(int id)
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
    public IActionResult AddPublisher([FromBody] Publisher publisher)
    {
        if (publisher == null)
        {
            return BadRequest("Publisher object is null");
        }

        _publisherRepository.AddPublisher(publisher);

        return CreatedAtAction(nameof(GetPublisherById), new { id = publisher.Id }, publisher);
    }

    // DELETE: api/publishers/1
    [HttpDelete("{id}")]
    public IActionResult DeletePublisher(int id)
    {
        _publisherRepository.DeletePublisher(id);
        return NoContent();
    }

    // PUT: api/publishers/1
    [HttpPut("{id}")]
    public IActionResult UpdatePublisher(int id, [FromBody] Publisher publisher)
    {
        if (publisher == null || id != publisher.Id)
        {
            return BadRequest("Invalid request");
        }

        var existingPublisher = _publisherRepository.GetPublisherById(id);
        if (existingPublisher == null)
        {
            return NotFound();
        }

        _publisherRepository.UpdatePublisher(publisher);

        return NoContent();
    }
}

