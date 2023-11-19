public class BookRepository
{

    public List<Book> GetAllBooks()
    {
        using (var context = new AppDbContext())
        {
            return context.Books.ToList();
        }
    }

    public Book GetBookById(int id)
    {
        using (var context = new AppDbContext())
        {
            return context.Books.Find(id);
        }
    }
    
    public void AddBook(Book book)
    {
        using (var context = new AppDbContext())
        {
            context.Books.Add(book);
            context.SaveChanges();
        }
    }

    public void DeleteBook(int id)
    {
        using (var context = new AppDbContext())
        {
            var book = context.Books.Find(id);
            if (book != null)
            {
                context.Books.Remove(book);
                context.SaveChanges();
            }
        }
    }

    public void UpdateBook(Book book)
    {
        using (var context = new AppDbContext())
        {
            var existingBook = context.Books.Find(book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.PublicationDate = book.PublicationDate;
                existingBook.Price = book.Price;
                existingBook.AuthorId = book.AuthorId;
                existingBook.PublisherId = book.PublisherId;

                context.SaveChanges();
            }
        }
    }
}
