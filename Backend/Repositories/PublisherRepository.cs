public class PublisherRepository
{
    public List<Publisher> GetAllPublishers()
    {
        using (var context = new AppDbContext())
        {
            return context.Publishers.ToList();
        }
    }
    public Publisher GetPublisherById(int id)
    {
        using (var context = new AppDbContext())
        {
            return context.Publishers.Find(id);
        }
    }
    
    public void AddPublisher(Publisher publisher)
    {
        using (var context = new AppDbContext())
        {
            context.Publishers.Add(publisher);
            context.SaveChanges();
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

    public void UpdatePublisher(Publisher publisher)
    {
        using (var context = new AppDbContext())
        {
            var existingPublisher = context.Publishers.Find(publisher.Id);
            if (existingPublisher != null)
            {
                existingPublisher.Name = publisher.Name;
                existingPublisher.Address = publisher.Address;
                existingPublisher.Phone = publisher.Phone;

                context.SaveChanges();
            }
        }
    }
}
