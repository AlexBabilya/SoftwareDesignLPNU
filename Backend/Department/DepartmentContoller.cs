using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("api/departments")]
public class DepartmentController : ControllerBase
{
    private readonly DepartmentRepository _departmentRepository;

    public DepartmentController(DepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    // GET: api/departments
    [HttpGet]
    public ActionResult<IEnumerable<DepartmentViewModel>> GetAllDepartments()
    {
        var departments = _departmentRepository.GetAllDepartmentViewModels();
        return Ok(departments);
    }

    // GET: api/departments/1
    [HttpGet("{id}")]
    public ActionResult<DepartmentViewModel> GetDepartmentById(int id)
    {
        var department = _departmentRepository.GetDepartmentViewModelById(id);
        if (department == null)
        {
            return NotFound();
        }

        return Ok(department);
    }

    // POST: api/departments
    [HttpPost]
    public IActionResult AddDepartment([FromBody] DepartmentViewModel departmentCreateViewModel)
    {
        if (departmentCreateViewModel == null)
        {
            return BadRequest("Department object is null");
        }

        _departmentRepository.AddDepartment(departmentCreateViewModel);

        return CreatedAtAction(nameof(GetDepartmentById), new { id = departmentCreateViewModel.Id }, departmentCreateViewModel);
    }

    // PUT: api/departments/1
    [HttpPut("{id}")]
    public IActionResult UpdateDepartment(int id, [FromBody] DepartmentViewModel departmentUpdateViewModel)
    {
        if (departmentUpdateViewModel == null || id != departmentUpdateViewModel.Id)
        {
            return BadRequest("Invalid data or department ID mismatch");
        }

        var existingDepartment = _departmentRepository.GetDepartmentViewModelById(id);

        if (existingDepartment == null)
        {
            return NotFound();
        }

        _departmentRepository.UpdateDepartment(id, departmentUpdateViewModel);

        return NoContent();
    }

    // DELETE: api/departments/1
    [HttpDelete("{id}")]
    public IActionResult DeleteDepartment(int id)
    {
        var department = _departmentRepository.GetDepartmentViewModelById(id);

        if (department == null)
        {
            return NotFound();
        }

        _departmentRepository.DeleteDepartment(id);

        return NoContent();
    }
}

