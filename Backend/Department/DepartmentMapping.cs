using AutoMapper;

public class DepartmentMapping : Profile
{
    public DepartmentMapping()
    {
        CreateMap<Department, DepartmentViewModel>();
        CreateMap<DepartmentViewModel, Department>();

        // Other mappings can be added here
    }
}

