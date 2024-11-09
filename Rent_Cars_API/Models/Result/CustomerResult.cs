using System;

namespace Rent_Cars_API.Models.Result;

public class CustomerResult
{
    public string CustomerId { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string name { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public string? DriverLicenseNumber { get; set; }
}
