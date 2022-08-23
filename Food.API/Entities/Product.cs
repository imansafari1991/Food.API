using Food.API.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Food.API.Entities;

public class Product:BaseEntity
{
    public Product()
    {
        ProductAttributes = new List<ProductAttribute>();
  

    }
    [Required]
    [MaxLength(50)]
    public string Title { get; set; }

    //public string ImageUrl { get; set; }

    public bool IsPopular { get; set; }
    public Guid CategoryId { get; set; }
    [JsonIgnore]
    public virtual Category Category { get; set; }
    [JsonIgnore]
    public virtual ICollection<ProductAttribute> ProductAttributes { get; set; }
    public virtual List<ProductImage> ProductImages { get; set; }
}