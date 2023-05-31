using Bogus;
using NetStore.Catalog.Domain;

namespace Netstore.Tests.Support.Fixture;

public class CategoryFixture : IDisposable
{
    public CategoryFixture()
    {
        
    }

    public IEnumerable<Category> GetCategories()
    {
        var categories = new List<Category>();
        categories.AddRange(GetCategories(10));
        return categories;
    }

    public Category? GetCategory() => GetCategories(1).FirstOrDefault();  

    private IEnumerable<Category> GetCategories(int quantity)
    {
        var categories = new Faker<Category>()
            .CustomInstantiator(c => new Category(
                name: c.Commerce.Categories(1)[0]
            ));
        return categories.Generate(quantity);
    }

    public void Dispose()
    {
       
    }
}
