using System;
using System.ComponentModel.DataAnnotations;

namespace Rent_Cars_API.Models;

public class MsEmployee
{
    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    [Key]
    [Required]
    [MaxLength(36)]
    public string Employee_id { get; set; }
    [Required]
    [MaxLength(200)]
    public string name { get; set; }
    [MaxLength(4000)]
    public string? position { get; set; }
    [MaxLength(200)]
    public string? email { get; set; }
    [MaxLength(36)]
    public string? phone_number { get; set; }
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
}
