using System.ComponentModel.DataAnnotations;
using Food.API.Entities.Common;

namespace Food.API.Entities;

public class PriceUnit:BaseEntity<int>
{
    [Required]
    [MaxLength(50)]
    public string Title { get; set; }
    [Required]
    [MaxLength(3)]
    public string Symbol { get; set; }

    
}