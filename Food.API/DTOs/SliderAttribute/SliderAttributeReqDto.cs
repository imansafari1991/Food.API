using System.ComponentModel.DataAnnotations;

namespace Food.API.DTOs.SliderAttribute;

public class SliderAttributeReqDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int LanguageId { get; set; }
    public Guid SliderId { get; set; }
}