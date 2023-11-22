using AutoMapper;

public class AuthorMapping : Profile
{
    public AuthorMapping()
    {
        CreateMap<Author, AuthorViewModel>();
        CreateMap<AuthorViewModel, Author>();
    }
}

