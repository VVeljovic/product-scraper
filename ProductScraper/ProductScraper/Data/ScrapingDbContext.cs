using Microsoft.EntityFrameworkCore;

namespace ProductScraper.Data;

public class ScrapingDbContext : DbContext
{
    public ScrapingDbContext(DbContextOptions<ScrapingDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasIndex(x => x.FilterHash);
            entity.Property(x => x.Id).ValueGeneratedOnAdd();
        });
        modelBuilder.Entity<FiltersMapping>(entity =>
        {
            entity.Property(x => x.Id).ValueGeneratedOnAdd();
        });

        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Product> Products { get; set; }

    public DbSet<FiltersMapping> FiltersMapping { get; set; }
}
