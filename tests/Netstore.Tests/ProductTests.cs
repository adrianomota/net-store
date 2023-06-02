namespace Netstore.Tests;

using FluentAssertions;
using Netstore.Tests.Support.Fixture;
using NetStore.Catalog.Domain.ValueObjects;

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
    
        product?.IsValid().Should().BeFalse();
        product?.ValidationResult?.Errors.Select(p => p.PropertyName).First().Should().Be("Name");
        product?.ValidationResult?.Errors.Where(p => p.ErrorMessage == "Product name can't be blank")
                                    .First().ErrorMessage
                                    .Should()
                                    .Be("Product name can't be blank");
    }

    [Fact(DisplayName = "When i have invalid product params with price equal 0 then return error")]
    public void Whan_i_have_invalid_product_params_with_price_equal_zero_then_return_error()
    {
        var product = _productFixture.GetProduct();
        product?.ChangePrice(0);
        product?.Validate();
    
        product?.IsValid().Should().BeFalse();
        product?.ValidationResult?.Errors.Select(p => p.PropertyName).First().Should().Be("Price");
        product?.ValidationResult?.Errors.Where(p => p.ErrorMessage == "Product price sbould be greater than 0")
                                    .First().ErrorMessage
                                    .Should()
                                    .Be("Product price sbould be greater than 0");
    }
    
    [Fact(DisplayName = "When i have invalid product params with dimensions equal 0 then return error")]
    public void Whan_i_have_invalid_product_params_with_height_dimensions_equal_zero_then_return_error()
    {
        var product = _productFixture.GetProduct();
        product?.ChangeDimensions(new Dimensions(0,3,3));
        product?.Validate();
        
        product?.IsValid().Should().BeFalse();
        product?.ValidationResult?.Errors.Select(p => p.PropertyName).First().Should().Be("Dimensions.Height");
        product?.ValidationResult?.Errors.Where(p => p.ErrorMessage == "Should be greather than 0")
                                    .First().ErrorMessage
                                    .Should()
                                    .Be("Should be greather than 0");
    }

    [Fact(DisplayName = "When i have invalid product params with width dimensions equal 0 then return error")]
    public void Whan_i_have_invalid_product_params_with_width_dimensions_equal_zero_then_return_error()
    {
        var product = _productFixture.GetProduct();
        product?.ChangeDimensions(new Dimensions(3,0,3));
        product?.Validate();
        
        product?.IsValid().Should().BeFalse();
        product?.ValidationResult?.Errors.Select(p => p.PropertyName).First().Should().Be("Dimensions.Width");
        product?.ValidationResult?.Errors.Where(p => p.ErrorMessage == "Should be greather than 0")
                                    .First().ErrorMessage
                                    .Should()
                                    .Be("Should be greather than 0");
    }

    [Fact(DisplayName = "When i have invalid product params depth dimensions equal 0 then return error")]
    public void Whan_i_have_invalid_product_params_depth_dimensions_equal_zero_then_return_error()
    {
        var product = _productFixture.GetProduct();
        product?.ChangeDimensions(new Dimensions(3,3,0));
        product?.Validate();
        
        product?.IsValid().Should().BeFalse();
        product?.ValidationResult?.Errors.Select(p => p.PropertyName).First().Should().Be("Dimensions.Depth");
        product?.ValidationResult?.Errors.Where(p => p.ErrorMessage == "Should be greather than 0")
                                    .First().ErrorMessage
                                    .Should()
                                    .Be("Should be greather than 0");
    }
}