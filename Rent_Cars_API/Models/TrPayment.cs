using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rent_Cars_API.Models;

public class TrPayment
{
    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    [Key]
    [Required]
    [MaxLength(36)]
    public string Payment_id { get; set; }
    public DateTime? Payment_date { get; set; }
    public decimal? amount { get; set; }
    [MaxLength(100)]
    public string? Payment_method { get; set; }
    [ForeignKey("TrRental")]
    public string rental_id {get; set; }
    public TrRental Rental { get; set; }
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
}
