using System.Collections.Generic;
using System.Linq;
using AutoMapper;

public class DepartmentRepository
{
    private readonly IMapper _mapper;

    public DepartmentRepository(IMapper mapper)
    {
        _mapper = mapper;
    }

    public List<DepartmentViewModel> GetAllDepartmentViewModels()
    {
        using (var context = new AppDbContext())
        {
            var departments = context.Departments.ToList();
            return _mapper.Map<List<DepartmentViewModel>>(departments);
        }
    }

    public DepartmentViewModel GetDepartmentViewModelById(int id)
    {
        using (var context = new AppDbContext())
        {
            var department = context.Departments.Find(id);
            return _mapper.Map<DepartmentViewModel>(department);
        }
    }

    public void AddDepartment(DepartmentViewModel departmentCreateViewModel)
    {
        using (var context = new AppDbContext())
        {
            var department = _mapper.Map<Department>(departmentCreateViewModel);
            context.Departments.Add(department);
            context.SaveChanges();
        }
    }

    public void UpdateDepartment(int id, DepartmentViewModel departmentUpdateViewModel)
    {
        using (var context = new AppDbContext())
        {
            var existingDepartment = context.Departments.Find(id);
            if (existingDepartment != null)
            {
                _mapper.Map(departmentUpdateViewModel, existingDepartment);
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

