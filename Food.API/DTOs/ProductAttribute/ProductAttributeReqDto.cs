using System.ComponentModel.DataAnnotations;

namespace Food.API.DTOs.ProductAttribute;

public class ProductAttributeReqDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public Guid ProductId { get; set; }
    public int LanguageId { get; set; }
    public int PriceUnitId { get; set; }
}