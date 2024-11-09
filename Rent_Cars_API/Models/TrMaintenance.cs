using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rent_Cars_API.Models;

public class TrMaintenance
{
    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    [Key]
    [Required]
    [MaxLength(36)]
    public string Maintenance_id { get; set; }
    public DateTime? maintenance_date { get; set; }
    [MaxLength(4000)]
    public string? description { get; set; }
    public decimal? cost { get; set; }
    [ForeignKey("MsEmployee")]
    public string employee_id { get; set; }
    [ForeignKey("MsCar")]
    public string car_id { get; set; }
    public MsCar Car { get; set; }
    public MsEmployee Employee { get; set;}
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
}
