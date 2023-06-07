namespace Netstore.Tests.Support.Fixture;

using Bogus;
using NetStore.Catalog.Domain;
using NetStore.Catalog.Domain.ValueObjects;
public class ProductFixture : IDisposable
{
    public ProductFixture() {}
    public IEnumerable<Product> GetProducts()
    {
        var products = new List<Product>();
        products.AddRange(GetProducts(10, true));
        return products;
    }
    public Product? GetProduct() => GetProducts(1, true).FirstOrDefault();
    private IEnumerable<Product> GetProducts(int quantity, bool active)
    {
        var products = new Faker<Product>()
            .CustomInstantiator(p => new Product(
                name: p.Commerce.ProductName(),
                price: decimal.Parse(p.Commerce.Price(min: 1, max: 9999999, decimals: 2)),
                dimensions: new Dimensions(height:2,width:2,depth:3),
                categoryId: Guid.NewGuid(),
                active: active
            ));
        
        return products.Generate(quantity);
    }

    public void Dispose() {}
}
