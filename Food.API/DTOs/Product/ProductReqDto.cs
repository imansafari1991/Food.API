namespace Food.API.DTOs.Product;

public class ProductReqDto
{
    public ProductReqDto()
    {
        Files = new List<IFormFile>();
    }
    public string Title { get; set; }
    public bool IsActive { get; set; }
    public Guid CategoryId  { get; set; }
    public List<IFormFile> Files { get; set; }
}