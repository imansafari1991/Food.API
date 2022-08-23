namespace Food.API.DTOs.Product;

public class PopularProductReqDto
{
    public Guid ProductId { get; set; }
    public bool IsPopular { get; set; }
}