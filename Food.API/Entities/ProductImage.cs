using Food.API.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Food.API.Entities;

public class ProductImage: BaseEntity<int>
{
    public Guid ProductId { get; set; }
    [Required]
    [MaxLength(500)]
    public string ImageUrl { get; set; }

    public virtual Product Product { get; set; }
}