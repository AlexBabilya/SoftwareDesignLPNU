using Microsoft.EntityFrameworkCore;

public partial class AppDbContext : DbContext
{
    public DbSet<Author> Authors{ get; set; }
    public DbSet<Book> Books{ get; set; }
    public DbSet<Publisher> Publishers{ get; set; }
    
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("Books");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            
            entity.Property(e => e.PublicationDate)
                .HasColumnType("datetime")
                .IsRequired();

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(50);
            
            entity.Property(e => e.Price)
                .IsRequired();

            entity.Property(e => e.AuthorId)
                .IsRequired();
        });

        modelBuilder.Entity<Author>(entity =>
        {
            entity.ToTable("Authors");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);
            
            entity.Property(e => e.Nationality)
                .IsRequired()
                .HasMaxLength(3);
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.ToTable("Publishers");
            
            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .HasColumnName("ID");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(15);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
