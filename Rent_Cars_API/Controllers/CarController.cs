using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rent_Cars_API.Data;
using Rent_Cars_API.Models;
using Rent_Cars_API.Models.Result;

namespace Rent_Cars_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CarController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarResult>>> Get()
        {
            var cars = await _context.MsCar
            .Select(x => new CarResult{
                CarId = x.Car_id,
                Name = x.name,
                Model = x.model,
                Year = x.year,
                LicensePlate = x.license_plate,
                NumberOfCarSeats = x.number_of_car_seats,
                Transmission = x.transmission,
                PricePerDay = x.price_per_day,
                Status  = x.status
            }).ToListAsync();

            var response = new APIResponse<IEnumerable<CarResult>>
            {
                StatusCode = StatusCodes.Status200OK,
                RequestMethod = HttpContext.Request.Method,
                Data = cars
            };
            return Ok(response);
        }
    }
}
