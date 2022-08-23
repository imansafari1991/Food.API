namespace Food.API.DTOs.CategoryAttribute;

public class CategoryAttributeReqDto
{
    public string Title { get; set; }
    public int LanguageId { get; set; }
    public Guid CategoryId { get; set; }
}