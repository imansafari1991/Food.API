using Food.API.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Food.API.Entities;

public class ProductAttribute:BaseEntity
{
    [Required]
    [MaxLength(50)]
    public string Title { get; set; }

    [Required]
    [MaxLength(500)]
    public string Description { get; set; }

    [Required]
    public int Price { get; set; }
    public Guid ProductId { get; set; }
    public int LanguageId { get; set; }
    public Language Language { get; set; }
    public Product Product { get; set; }
}