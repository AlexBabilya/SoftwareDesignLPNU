public class AuthorRepository
{
    public List<Author> GetAllAuthors()
    {
        using (var context = new AppDbContext())
        {
            return context.Authors.ToList();
        }
    }
    
    public Author GetAuthorById(int id)
    {
        using (var context = new AppDbContext())
        {
            return context.Authors.Find(id);
        }
    }

    public void AddAuthor(Author author)
    {
        using (var context = new AppDbContext())
        {
            context.Authors.Add(author);
            context.SaveChanges();
        }
    }
        
    public void DeleteAuthor(int id)
    {
        using (var context = new AppDbContext())
        {
            var author = context.Authors.Find(id);
            if (author != null)
            {
                context.Authors.Remove(author);
                context.SaveChanges();
            }
        }
    }

    public void UpdateAuthor(Author author)
    {
        using (var context = new AppDbContext())
        {
            var existingAuthor = context.Authors.Find(author.Id);
            if (existingAuthor != null)
            {
                existingAuthor.FirstName = author.FirstName;
                existingAuthor.LastName = author.LastName;
                existingAuthor.Birthdate = author.Birthdate;
                existingAuthor.Nationality = author.Nationality;

                context.SaveChanges();
            }
        }
    }
}
