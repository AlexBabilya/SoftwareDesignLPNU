using System.Collections.Generic;
using System.Linq;
using AutoMapper;

public class PublisherRepository
{
    private readonly IMapper _mapper;

    public PublisherRepository(IMapper mapper)
    {
        _mapper = mapper;
    }

    public List<PublisherViewModel> GetAllPublishers()
    {
        using (var context = new AppDbContext())
        {
            var publishers = context.Publishers.ToList();
            return _mapper.Map<List<PublisherViewModel>>(publishers);
        }
    }

    public PublisherViewModel GetPublisherById(int id)
    {
        using (var context = new AppDbContext())
        {
            var publisher = context.Publishers.Find(id);
            return _mapper.Map<PublisherViewModel>(publisher);
        }
    }

    public void AddPublisher(PublisherViewModel publisherCreateViewModel)
    {
        using (var context = new AppDbContext())
        {
            var publisher = _mapper.Map<Publisher>(publisherCreateViewModel);
            context.Publishers.Add(publisher);
            context.SaveChanges();
        }
    }

    public void UpdatePublisher(int id, PublisherViewModel publisherUpdateViewModel)
    {
        using (var context = new AppDbContext())
        {
            var existingPublisher = context.Publishers.Find(id);
            if (existingPublisher != null)
            {
                _mapper.Map(publisherUpdateViewModel, existingPublisher);
                context.SaveChanges();
            }
        }
    }

    public void DeletePublisher(int id)
    {
        using (var context = new AppDbContext())
        {
            var publisher = context.Publishers.Find(id);
            if (publisher != null)
            {
                context.Publishers.Remove(publisher);
                context.SaveChanges();
            }
        }
    }
}

