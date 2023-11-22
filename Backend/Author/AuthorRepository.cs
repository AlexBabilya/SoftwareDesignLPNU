using AutoMapper;

public class AuthorRepository
{
    private readonly IMapper _mapper;

    public AuthorRepository(IMapper mapper)
    {
        _mapper = mapper;
    }

    public List<AuthorViewModel> GetAllAuthorViewModels()
    {
        using (var context = new AppDbContext())
        {
            var authors = context.Authors.ToList();
            return _mapper.Map<List<AuthorViewModel>>(authors);
        }
    }

    public AuthorViewModel GetAuthorViewModelById(int id)
    {
        using (var context = new AppDbContext())
        {
            var author = context.Authors.Find(id);
            return _mapper.Map<AuthorViewModel>(author);
        }
    }

    public void AddAuthor(AuthorViewModel authorCreateViewModel)
    {
        using (var context = new AppDbContext())
        {
            var author = _mapper.Map<Author>(authorCreateViewModel);
            context.Authors.Add(author);
            context.SaveChanges();
        }
    }

    public void UpdateAuthor(int id, AuthorViewModel authorUpdateViewModel)
    {
        using (var context = new AppDbContext())
        {
            var existingAuthor = context.Authors.Find(id);
            if (existingAuthor != null)
            {
                _mapper.Map(authorUpdateViewModel, existingAuthor);
                context.SaveChanges();
            }
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
}

