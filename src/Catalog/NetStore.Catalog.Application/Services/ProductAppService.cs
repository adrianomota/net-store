namespace NetStore.Catalog.Application.Services;

using AutoMapper;
using NetStore.Catalog.Application.Contracts;
using NetStore.Catalog.Application.Dtos;
using NetStore.Catalog.Domain;
using NetStore.Catalog.Domain.Contracts;

public class ProductAppService : IProductAppService
{
    private IMapper _mapper;
    private readonly IProductRepository _productRepo;
    public ProductAppService(IProductRepository productRepo, IMapper mapper)
    {
        _productRepo = productRepo;
        _mapper = mapper;
    }
    public async Task CreateProduct(ProductDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        await _productRepo.Create(product);
        await _productRepo.UnitOfWork.Commit();
    }
    public async Task<IEnumerable<ProductDto>> GetProductByCategoryId(Guid categoryId)
    {
       var products = await _productRepo.GetByCategory(categoryId);
       var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);
       return productsDto;
    }
    public async Task<ProductDto> GetProductById(Guid productId)
    {
        var product = await _productRepo.GetById(productId);
        var productDto = _mapper.Map<ProductDto>(product);
        return productDto;
    }
    public async Task<IEnumerable<ProductDto>> GetProducts(int page, int pageSize)
    {
        var products = await _productRepo.GetAll(page: page, pageSize: pageSize);
        var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);
        return productsDto;
    }
    public async Task UpdateProduct(ProductDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        await _productRepo.Update(product);
        await _productRepo.UnitOfWork.Commit();
    }
    
    public void Dispose() => _productRepo.Dispose();
}
