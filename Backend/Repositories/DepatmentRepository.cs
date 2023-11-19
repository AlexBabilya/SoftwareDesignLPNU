using System.Collections.Generic;
using System.Linq;

public class DepartmentRepository
{
    public List<Department> GetAllDepartments()
    {
        using (var context = new AppDbContext())
        {
            return context.Departments.ToList();
        }
    }
    
    public Department GetDepartmentById(int id)
    {
        using (var context = new AppDbContext())
        {
            return context.Departments.Find(id);
        }
    }

    public void AddDepartment(Department department)
    {
        using (var context = new AppDbContext())
        {
            context.Departments.Add(department);
            context.SaveChanges();
        }
    }
        
    public void UpdateDepartment(Department department)
    {
        using (var context = new AppDbContext())
        {
            var existingDepartment = context.Departments.Find(department.Id);
            if (existingDepartment != null)
            {
                existingDepartment.Name = department.Name;
                existingDepartment.Location = department.Location;

                context.SaveChanges();
            }
        }
    }

    public void DeleteDepartment(int id)
    {
        using (var context = new AppDbContext())
        {
            var department = context.Departments.Find(id);
            if (department != null)
            {
                context.Departments.Remove(department);
                context.SaveChanges();
            }
        }
    }
}

