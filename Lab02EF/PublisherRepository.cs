public class PublisherRepository
{
    public List<Publisher> GetAllPublishers()
    {
        using (var context = new AppDbContext())
        {
            return context.Publishers.ToList();
        }
    }

    public void AddPublisher(Publisher publisher)
    {
        using (var context = new AppDbContext())
        {
            var allPublishers = context.Publishers.ToList();
            int maxId = allPublishers.Any() ? allPublishers.Max(p => p.Id) : 0;
            publisher.Id = maxId + 1;
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
