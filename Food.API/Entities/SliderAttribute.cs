using Food.API.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Food.API.Entities;

public class SliderAttribute:BaseEntity
{
    [Required]
    [MaxLength(50)]
    public string Title { get; set; }
    [Required]
    [MaxLength(500)]
    public string Description { get; set; }
    public int LanguageId { get; set; }
    public Guid SliderId { get; set; }
    [JsonIgnore]
    public Language Language { get; set; }
    public Slider Slider { get; set; }
    
}