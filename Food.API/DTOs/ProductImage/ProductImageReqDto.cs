namespace Food.API.DTOs.ProductImage;

public class ProductImageReqDto
{
    public Guid ProductId { get; set; }
    public IFormFile File { get; set; }
}