using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rent_Cars_API.Models;

public class MsCarImages
{
    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    [Key]
    [Required]
    [MaxLength(36)]
    public string Image_car_id { get; set; }
    [MaxLength(2000)]
    public string? Image_link { get; set; }
    [ForeignKey("MsCar")]
    public string Car_id { get; set; }
    public MsCar Car { get; set; }
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
}
