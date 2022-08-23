using Food.API.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Food.API.Entities;

public class CategoryAttribute:BaseEntity
{
    [Required]
    [MaxLength(50)]
    public string Title { get; set; }
    public int LanguageId{ get; set; }
    public Guid CategoryId { get; set; }

    public Category Category { get; set; }
    public Language Language { get; set; }
}