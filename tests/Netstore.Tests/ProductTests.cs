using Netstore.Tests.Support.Fixture;

namespace Netstore.Tests;

[Collection(nameof(ProductCollection))]
public class ProductTests
{
    private readonly ProductFixture _productFixture;

    public ProductTests(ProductFixture productFixture)
    {
        _productFixture = productFixture;
    }

    [Fact(DisplayName = "When i have valid product params then return success")]
    public void Whan_i_have_valid_product_params_then_return_success()
    {
         var product = _productFixture.GetProduct();
         product?.Validate();
         Assert.True(product?.IsValid());
    }

    [Fact(DisplayName = "When i don't have valid product params then return error")]
    public void Whan_i_do_not_have_valid_product_params_then_return_error()
    {
         var product = _productFixture.GetProduct();
         product?.ChangeName(string.Empty);
         product?.Validate();
         Assert.False(product?.IsValid());
    }
}