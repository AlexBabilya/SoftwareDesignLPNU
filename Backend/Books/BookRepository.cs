using System.Collections.Generic;
using System.Linq;
using AutoMapper;

public class BookRepository
{
    private readonly IMapper _mapper;

    public BookRepository(IMapper mapper)
    {
        _mapper = mapper;
    }

    public List<BookViewModel> GetAllBookViewModels()
    {
        using (var context = new AppDbContext())
        {
            var books = context.Books.ToList();
            return _mapper.Map<List<BookViewModel>>(books);
        }
    }

    public BookViewModel GetBookViewModelById(int id)
    {
        using (var context = new AppDbContext())
        {
            var book = context.Books.Find(id);
            return _mapper.Map<BookViewModel>(book);
        }
    }

    public void AddBook(BookViewModel bookCreateViewModel)
    {
        using (var context = new AppDbContext())
        {
            var book = _mapper.Map<Book>(bookCreateViewModel);
            context.Books.Add(book);
            context.SaveChanges();
        }
    }

    public void UpdateBook(int id, BookViewModel bookUpdateViewModel)
    {
        using (var context = new AppDbContext())
        {
            var existingBook = context.Books.Find(id);
            if (existingBook != null)
            {
                _mapper.Map(bookUpdateViewModel, existingBook);
                context.SaveChanges();
            }
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
}

