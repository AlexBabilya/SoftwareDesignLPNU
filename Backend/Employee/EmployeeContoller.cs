using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("api/employees")]
public class EmployeeController : ControllerBase
{
    private readonly EmployeeRepository _employeeRepository;

    public EmployeeController(EmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    // GET: api/employees
    [HttpGet]
    public ActionResult<IEnumerable<EmployeeViewModel>> GetAllEmployees()
    {
        var employees = _employeeRepository.GetAllEmployeeViewModels();
        return Ok(employees);
    }

    // GET: api/employees/1
    [HttpGet("{id}")]
    public ActionResult<EmployeeViewModel> GetEmployeeById(int id)
    {
        var employee = _employeeRepository.GetEmployeeViewModelById(id);
        if (employee == null)
        {
            return NotFound();
        }

        return Ok(employee);
    }

    // POST: api/employees
    [HttpPost]
    public IActionResult AddEmployee([FromBody] EmployeeViewModel employeeCreateViewModel)
    {
        if (employeeCreateViewModel == null)
        {
            return BadRequest("Employee object is null");
        }

        _employeeRepository.AddEmployee(employeeCreateViewModel);

        return CreatedAtAction(nameof(GetEmployeeById), new { id = employeeCreateViewModel.Id }, employeeCreateViewModel);
    }

    // PUT: api/employees/1
    [HttpPut("{id}")]
    public IActionResult UpdateEmployee(int id, [FromBody] EmployeeViewModel employeeUpdateViewModel)
    {
        if (employeeUpdateViewModel == null || id != employeeUpdateViewModel.Id)
        {
            return BadRequest("Invalid data or employee ID mismatch");
        }

        var existingEmployee = _employeeRepository.GetEmployeeViewModelById(id);

        if (existingEmployee == null)
        {
            return NotFound();
        }

        _employeeRepository.UpdateEmployee(id, employeeUpdateViewModel);

        return NoContent();
    }

    // DELETE: api/employees/1
    [HttpDelete("{id}")]
    public IActionResult DeleteEmployee(int id)
    {
        var employee = _employeeRepository.GetEmployeeViewModelById(id);

        if (employee == null)
        {
            return NotFound();
        }

        _employeeRepository.DeleteEmployee(id);

        return NoContent();
    }
}

