using Food.API.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Food.API.Entities;

public class Slider:BaseEntity
{
    [Required]
    [MaxLength(50)]
    public string Title { get; set; }

    [Required]
    [MaxLength(500)]
    public string ImageUrl { get; set; }
    [JsonIgnore]
    public ICollection<SliderAttribute> SliderAttributes { get; set; }
}