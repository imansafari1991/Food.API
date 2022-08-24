namespace Food.API.DTOs.SliderAttribute;

public class SliderAttributeResDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int LanguageId { get; set; }
    public Guid SliderId { get; set; }
}