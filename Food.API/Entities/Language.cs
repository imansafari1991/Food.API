using Food.API.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Food.API.Entities;

public class Language:BaseEntity<int>
{
    [Required]
    [MaxLength(20)]
    public string Title { get; set; }
    [Required]
    [MaxLength(10)]
    public string Code { get; set; }

    
}