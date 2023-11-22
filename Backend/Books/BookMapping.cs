using AutoMapper;

public class BookMapping : Profile
{
    public BookMapping()
    {
        CreateMap<Book, BookViewModel>();

        CreateMap<BookViewModel, Book>();
        
        // Other mappings can be added here
    }
}

