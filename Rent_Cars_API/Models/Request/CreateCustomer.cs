using System;
using System.ComponentModel.DataAnnotations;

namespace Rent_Cars_API.Models.Request;

public class CreateCustomer
{
    [Required]
    [MaxLength(100)]
    public string email { get; set; }
    [Required]
    [MaxLength(100)]
    public string password { get; set; }
    [Required]
    [MaxLength(200)]
    public string name { get; set; }
    [Required]
    [MaxLength(50)]
    public string phone_number { get; set; }
    [Required]
    [MaxLength(500)]
    public string address { get; set; }
}
