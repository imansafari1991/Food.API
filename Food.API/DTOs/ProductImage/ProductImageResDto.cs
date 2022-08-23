namespace Food.API.DTOs.ProductImage;

public class ProductImageResDto
{
    public int Id { get; set; }
    public Guid ProductId { get; set; }
    public string ImageUrl { get; set; }
}