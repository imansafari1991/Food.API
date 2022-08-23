using Food.API.DTOs.ProductImage;

namespace Food.API.DTOs;

public class CategoryAndProductResDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }

    public List<ProductResDto> Products { get; set; }
}

public class ProductResDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public int Price { get; set; }
    public string Description { get; set; }
    public List<ProductImageResDto> ProductImages { get; set; }
}

