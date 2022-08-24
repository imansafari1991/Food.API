namespace Food.API.DTOs.Slider
{
    public class SliderReqDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile? File { get; set; }
        public bool IsActive { get; set; }
    }
}
