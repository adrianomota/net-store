namespace NetStore.Catalog.Application.MapConfig;

using AutoMapper;
using NetStore.Catalog.Application.Dtos;
using NetStore.Catalog.Domain;
using NetStore.Catalog.Domain.ValueObjects;

public class CatalogMapConfig : Profile
{
    public CatalogMapConfig()
    {
        #region Product
        CreateMap<Product, ProductDto>()
            .ForMember(s => s.Id, o => o.MapFrom(pro => pro.Id.ToString()))
            .ForMember(s => s.CategoryId, o => o.MapFrom(cat => cat.CategoryId.ToString()))
            .ForMember(s => s.Height, o => o.MapFrom(pro => pro.Dimensions.Height))
            .ForMember(s => s.Width, o => o.MapFrom(pro => pro.Dimensions.Width))
            .ForMember(s => s.Depth, o => o.MapFrom(pro => pro.Dimensions.Depth));
    
        CreateMap<ProductDto, Product>()
            .ConstructUsing(p => 
                    new Product(p.Name,
                                p.Active.Value,
                                p.Price.Value,
                                new Dimensions(
                                    p.Height.Value, 
                                    p.Width.Value, 
                                    p.Depth.Value
                                ),
                                new Guid(p.CategoryId)));
        #endregion

        #region Category
        CreateMap<Category, CategoryDto>()
             .ForMember(s => s.Id, o => o.MapFrom(cat => cat.Id.ToString()));

        CreateMap<CategoryDto, Category>()
            .ConstructUsing(c => new Category(c.Name));
        #endregion
    }
}