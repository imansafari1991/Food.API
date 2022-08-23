using System.ComponentModel.DataAnnotations;

namespace Food.API.DTOs.Language;

public class LanguageReqDto
{
    public string Title { get; set; }
    public string Code { get; set; }
    public bool IsActive { get; set; }
}