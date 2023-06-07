namespace NetStore.Catalog.Infrastructure;

using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetStore.Catalog.Domain;
using NetStore.Core.Data;

public class CatalogContext : DbContext, IUnitOfWork
{
    public CatalogContext(DbContextOptions<CatalogContext> options)
        :base(options) { }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
            x => x.GetProperties().Where(p => p.ClrType == typeof(string))))
                {
                    property.SetColumnType("varchar(100)");
                }
        // modelBuilder.Ignore<Event>();
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogContext).Assembly);
    }

    public async Task<bool> Commit()
    {
        foreach (var entry in ChangeTracker.Entries().Where(e => e.Entity.GetType().GetProperty("CreatedAt") != null))
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property("CreatedAt").CurrentValue = DateTime.UtcNow;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property("UpdatedAt").IsModified = false;
            }
        }
        return await base.SaveChangesAsync() > 0;
    }
}
