
using AutoMapper;

public class PublisherMapping : Profile
{
    public PublisherMapping()
    {
        CreateMap<Publisher, PublisherViewModel>();
        CreateMap<PublisherViewModel, Publisher>();
        // Other mappings can be added here
    }
}
