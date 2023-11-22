
using AutoMapper;

public class EmployeeMapping : Profile
{
    public EmployeeMapping()
    {
        CreateMap<Employee, EmployeeViewModel>();
        CreateMap<EmployeeViewModel, Employee>();
        // Other mappings can be added here
    }
}
