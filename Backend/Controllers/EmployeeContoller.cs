using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/employees")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly EmployeeRepository _employeeRepository;

    public EmployeeController(EmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    // GET: api/employees
    [HttpGet]
    public ActionResult<IEnumerable<Employee>> GetAllEmployees()
    {
        var employees = _employeeRepository.GetAllEmployees();
        return Ok(employees);
    }

    // GET: api/employees/1
    [HttpGet("{id}")]
    public ActionResult<Employee> GetEmployeeById(int id)
    {
        var employee = _employeeRepository.GetEmployeeById(id);

        if (employee == null)
        {
            return NotFound();
        }

        return Ok(employee);
    }

    // POST: api/employees
    [HttpPost]
    public IActionResult AddEmployee([FromBody] Employee employee)
    {
        if (employee == null)
        {
            return BadRequest("Employee object is null");
        }

        _employeeRepository.AddEmployee(employee);

        return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
    }

    // PUT: api/employees/1
    [HttpPut("{id}")]
    public IActionResult UpdateEmployee(int id, [FromBody] Employee employee)
    {
        if (employee == null || id != employee.Id)
        {
            return BadRequest("Invalid data or employee ID mismatch");
        }

        var existingEmployee = _employeeRepository.GetEmployeeById(id);

        if (existingEmployee == null)
        {
            return NotFound();
        }

        _employeeRepository.UpdateEmployee(employee);

        return NoContent();
    }

    // DELETE: api/employees/1
    [HttpDelete("{id}")]
    public IActionResult DeleteEmployee(int id)
    {
        var employee = _employeeRepository.GetEmployeeById(id);

        if (employee == null)
        {
            return NotFound();
        }

        _employeeRepository.DeleteEmployee(id);

        return NoContent();
    }
}

