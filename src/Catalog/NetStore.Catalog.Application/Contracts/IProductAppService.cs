namespace NetStore.Catalog.Application.Contracts;

using NetStore.Catalog.Application.Dtos;

public interface IProductAppService : IDisposable
{
    Task<ProductDto> GetProductById(Guid productId);
    Task<IEnumerable<ProductDto>> GetProductByCategoryId(Guid categoryId);
    Task<IEnumerable<ProductDto>> GetProducts(int page, int pageSize);
    Task CreateProduct(ProductDto product);
    Task UpdateProduct(ProductDto product);   
}
