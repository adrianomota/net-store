namespace NetStore.Catalog.Infrastructure;

using Microsoft.EntityFrameworkCore;
using NetStore.Catalog.Domain;
using NetStore.Catalog.Domain.Contracts;
using NetStore.Core.Data;

public class ProductRepository : IProductRepository
{
    private readonly CatalogDbContext _context;
    public IUnitOfWork UnitOfWork => _context;
    public ProductRepository(CatalogDbContext context)
    {
        _context = context;
    }
    public async Task Create(Product product) 
        => await _context.Products.AddAsync(product);
    public async Task Create(Category category)
        => await _context.Categories.AddAsync(category);
    public async Task<IEnumerable<Product>> GetAll(int page, int pageSize)
        =>  await _context.Products
                .AsNoTracking()
                .Skip(page)
                .Take(pageSize)
                .ToListAsync();
    public async Task<IEnumerable<Product?>> GetByCategory(Guid? categoryId)
        =>  await _context.Products
                .AsNoTracking()
                .Include(i => i.Category)
                .Where(p => p.Category.Id == categoryId)
                .ToListAsync();
    public async Task<IEnumerable<Category>> GetCategories(int page, int offset)
        =>  await _context.Categories
                    .AsNoTracking()
                    .ToListAsync();
    public async Task Update(Product product)
        => await Task.FromResult(_context.Products.Update(product));
    public async Task Update(Category category)
        => await Task.FromResult(_context.Categories.Update(category));    
    public async Task<Product?> GetById(Guid? id) 
        => await _context.Products.FindAsync(id);
        
    void IDisposable.Dispose() => _context.Dispose();

}

