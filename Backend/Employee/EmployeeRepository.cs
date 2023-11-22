using System.Collections.Generic;
using System.Linq;
using AutoMapper;

public class EmployeeRepository
{
    private readonly IMapper _mapper;

    public EmployeeRepository(IMapper mapper)
    {
        _mapper = mapper;
    }

    public List<EmployeeViewModel> GetAllEmployeeViewModels()
    {
        using (var context = new AppDbContext())
        {
            var employees = context.Employees.ToList();
            return _mapper.Map<List<EmployeeViewModel>>(employees);
        }
    }

    public EmployeeViewModel GetEmployeeViewModelById(int id)
    {
        using (var context = new AppDbContext())
        {
            var employee = context.Employees.Find(id);
            return _mapper.Map<EmployeeViewModel>(employee);
        }
    }

    public void AddEmployee(EmployeeViewModel employeeCreateViewModel)
    {
        using (var context = new AppDbContext())
        {
            var employee = _mapper.Map<Employee>(employeeCreateViewModel);
            context.Employees.Add(employee);
            context.SaveChanges();
        }
    }

    public void UpdateEmployee(int id, EmployeeViewModel employeeUpdateViewModel)
    {
        using (var context = new AppDbContext())
        {
            var existingEmployee = context.Employees.Find(id);
            if (existingEmployee != null)
            {
                _mapper.Map(employeeUpdateViewModel, existingEmployee);
                context.SaveChanges();
            }
        }
    }

    public void DeleteEmployee(int id)
    {
        using (var context = new AppDbContext())
        {
            var employee = context.Employees.Find(id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
        }
    }
}

