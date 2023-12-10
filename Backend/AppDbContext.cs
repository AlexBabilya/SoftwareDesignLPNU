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
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
    
}
