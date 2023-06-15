using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NetStore.Catalog.Domain;
using NetStore.Catalog.Domain.ValueObjects;
using NetStore.Catalog.Infrastructure.Contracts;
using NetStore.Core.Data;

namespace NetStore.Catalog.Infrastructure;

public class CatalogDbContext : DbContext, IUnitOfWork
{
    private readonly string _catalogConnectionString;
    public CatalogDbContext(IOptions<DbOptions> dbOptions)
    { 
       _catalogConnectionString = dbOptions.Value.ConnectionString;
    }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Product>? Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
            x => x.GetProperties().Where(p => p.ClrType == typeof(string))))
                {
                    property.SetColumnType("varchar(100)");
                }

        // modelBuilder.Ignore<Event>();
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_catalogConnectionString);
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
