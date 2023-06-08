namespace NetStore.Catalog.Application.Dtos;

public class ProductDto
{
    public string? Id { get; set; }
    public string? Name { get;  set; }
    public bool? Active { get;  set; }
    public decimal? Price { get;  set; }
    public int? Height { get; set; }
    public int? Width { get; set; }
    public int? Depth { get; set; }
    public string? CategoryId { get;  set; }
    public CategoryDto? Category { get;  set; }
    public string? CreatedAt { get; set; }
    public string? UpdatedAt { get; set; }
}
