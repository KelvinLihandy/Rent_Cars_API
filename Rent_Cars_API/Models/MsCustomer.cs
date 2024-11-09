using System;
using System.ComponentModel.DataAnnotations;

namespace Rent_Cars_API.Models;

public class MsCustomer
{
    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    [Key]
    [Required]
    [MaxLength(36)]
    public string Customer_id { get; set; }
    [Required]
    [MaxLength(100)]
    public string email { get; set; }
    [Required]
    [MaxLength(100)]
    public string password { get; set; }
    [Required]
    [MaxLength(200)]
    public string name { get; set; }
    [MaxLength(50)]
    public string? phone_number { get; set; }
    [MaxLength(500)]
    public string? address { get; set; }
    [MaxLength(100)]
    public string? driver_license_number { get; set; }
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
}
