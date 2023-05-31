using Bogus;
using NetStore.Catalog.Domain;

namespace Netstore.Tests.Support.Fixture;

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
                active: active
            ));
        
        return products.Generate(quantity);
    }

    public void Dispose() {}
}
