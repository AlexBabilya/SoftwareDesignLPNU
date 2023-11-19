using Microsoft.EntityFrameworkCore;

public partial class AppDbContext : DbContext
{
    public DbSet<Author> Authors{ get; set; }
    public DbSet<Book> Books{ get; set; }
    public DbSet<Publisher> Publishers{ get; set; }
    public DbSet<Employee> Employees{ get; set; }
    public DbSet<Department> Departments{ get; set; }
    
    public AppDbContext()
    {

    }

    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {

    } 

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
          string connectionString = "Server=localhost,1433;Database=BookstoreKPZ;User Id=sa;Password=123;TrustServerCertificate=true";
        optionsBuilder.UseSqlServer(connectionString);
    }

}
