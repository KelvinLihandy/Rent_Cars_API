using System;
using System.ComponentModel.DataAnnotations;

namespace Rent_Cars_API.Models;

public class MsCar
{
    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    [Key]
    [Required]
    [MaxLength(36)]
    public string Car_id { get; set; }
    [MaxLength(200)]
    public string? name { get; set; }
    [MaxLength(100)]
    public string? model { get; set; }
    public int? year { get; set; }
    [MaxLength(50)]
    public string? license_plate { get; set; }
    public int? number_of_car_seats { get; set; }
    [MaxLength(100)]
    public string? transmission { get; set; }
    public decimal? price_per_day { get; set; }
    public bool? status { get; set; }
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
}
