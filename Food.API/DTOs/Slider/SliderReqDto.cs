namespace Food.API.DTOs.Slider
{
    public class SliderReqDto
    {
        public string Title { get; set; }
        public IFormFile? File { get; set; }
        public bool IsActive { get; set; }
    }
}
