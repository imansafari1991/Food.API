using Food.API.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Food.API.Entities;

public class Category:BaseEntity
{
    public Category()
    {
        CategoryAttributes=new List<CategoryAttribute>();
        Products = new List<Product>();
    }

    [Required]
    [MaxLength(50)]
    public string Title { get; set; }
    [JsonIgnore]
    public virtual ICollection<CategoryAttribute> CategoryAttributes { get; set; }
    [JsonIgnore]

    public virtual ICollection<Product> Products { get; set; }
}