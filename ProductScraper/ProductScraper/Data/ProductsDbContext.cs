using Microsoft.EntityFrameworkCore;

namespace ProductScraper.Data;

public class ProductsDbContext : DbContext
{
    public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasIndex(x => x.FilterHash);
            entity.Property(x => x.Id).ValueGeneratedOnAdd();
        });
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Product> Products { get; set; }
}
