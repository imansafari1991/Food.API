using Food.API.DTOs.ProductImage;

namespace Food.API.DTOs.Product;

public class ProductResDto
{
    public ProductResDto()
    {
        ProductImages = new List<ProductImageResDto>();
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public bool IsActive { get; set; }
    public Guid CategoryId { get; set; }
    public List<ProductImageResDto> ProductImages { get; set; }
}