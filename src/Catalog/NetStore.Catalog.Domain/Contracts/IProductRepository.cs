namespace NetStore.Catalog.Domain.Contracts;

using NetStore.Core.Data;
public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetAll(int page, int offset);
    Task<Product?> GetById(Guid? id);
    Task<IEnumerable<Product?>> GetByCategory(Guid? categoryId);
    Task<IEnumerable<Category>> GetCategories(int page, int offset);
    Task Create(Product product);
    Task Create(Category category);
    Task Update(Product product);
    Task Update(Category category);    
}
