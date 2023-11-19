public class EmployeeRepository
{
    public List<Employee> GetAllEmployees()
    {
        using (var context = new AppDbContext())
        {
            return context.Employees.ToList();
        }
    }
    
    public Employee GetEmployeeById(int id)
    {
        using (var context = new AppDbContext())
        {
            return context.Employees.Find(id);
        }
    }

    public void AddEmployee(Employee employee)
    {
        using (var context = new AppDbContext())
        {
            context.Employees.Add(employee);
            context.SaveChanges();
        }
    }
        
    public void UpdateEmployee(Employee employee)
    {
        using (var context = new AppDbContext())
        {
            var existingEmployee = context.Employees.Find(employee.Id);
            if (existingEmployee != null)
            {
                existingEmployee.FirstName = employee.FirstName;
                existingEmployee.LastName = employee.LastName;
                existingEmployee.DepartmentID = employee.DepartmentID;
                existingEmployee.HireDate = employee.HireDate;
                existingEmployee.Salary = employee.Salary;

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

