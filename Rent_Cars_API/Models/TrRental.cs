using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rent_Cars_API.Models;

public class TrRental
{
    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    [Key]
    [Required]
    [MaxLength(36)]
    public string Rental_id { get; set; }
    [Required]
    public DateTime rental_date { get; set; }
    public DateTime? return_date { get; set; }
    public decimal? total_price { get; set; }
    public bool? payment_status { get; set; }
    [ForeignKey("MsCustomer")]
    public string customer_id { get; set; }
    [ForeignKey("MsCar")]
    public string car_id { get; set; }
    public MsCustomer Customer { get; set; }
    public MsCar Car { get; set; }
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
}
