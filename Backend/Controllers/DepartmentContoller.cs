using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/departments")]
[ApiController]
public class DepartmentController : ControllerBase
{
    private readonly DepartmentRepository _departmentRepository;

    public DepartmentController(DepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    // GET: api/departments
    [HttpGet]
    public ActionResult<IEnumerable<Department>> GetAllDepartments()
    {
        var departments = _departmentRepository.GetAllDepartments();
        return Ok(departments);
    }

    // GET: api/departments/1
    [HttpGet("{id}")]
    public ActionResult<Department> GetDepartmentById(int id)
    {
        var department = _departmentRepository.GetDepartmentById(id);

        if (department == null)
        {
            return NotFound();
        }

        return Ok(department);
    }

    // POST: api/departments
    [HttpPost]
    public IActionResult AddDepartment([FromBody] Department department)
    {
        if (department == null)
        {
            return BadRequest("Department object is null");
        }

        _departmentRepository.AddDepartment(department);

        return CreatedAtAction(nameof(GetDepartmentById), new { id = department.Id }, department);
    }

    // PUT: api/departments/1
    [HttpPut("{id}")]
    public IActionResult UpdateDepartment(int id, [FromBody] Department department)
    {
        if (department == null || id != department.Id)
        {
            return BadRequest("Invalid data or department ID mismatch");
        }

        var existingDepartment = _departmentRepository.GetDepartmentById(id);

        if (existingDepartment == null)
        {
            return NotFound();
        }

        _departmentRepository.UpdateDepartment(department);

        return NoContent();
    }

    // DELETE: api/departments/1
    [HttpDelete("{id}")]
    public IActionResult DeleteDepartment(int id)
    {
        var department = _departmentRepository.GetDepartmentById(id);

        if (department == null)
        {
            return NotFound();
        }

        _departmentRepository.DeleteDepartment(id);

        return NoContent();
    }
}

