using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rent_Cars_API.Data;
using Rent_Cars_API.Models;
using Rent_Cars_API.Models.Request;
using Rent_Cars_API.Models.Result;
using System.Data;
using System.Linq;

namespace Rent_Cars_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CustomerController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerResult>>> Get()
        {
            var customers = await _context.MsCustomer
            .Select(x => new CustomerResult{
                CustomerId = x.Customer_id,
                Email = x.email,
                Password = x.password,
                name = x.name,
                PhoneNumber = x.phone_number,
                Address = x.address,
                DriverLicenseNumber = x.driver_license_number
            }).ToListAsync();

            var response = new APIResponse<IEnumerable<CustomerResult>>
            {
                StatusCode = StatusCodes.Status200OK,
                RequestMethod = HttpContext.Request.Method,
                Data = customers
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateCustomer request)
        {
            try
            {
                bool isEmailExists = await _context.MsCustomer
                .Where(x => x.email == request.email).AnyAsync();
                if(isEmailExists)
                {
                    throw new DuplicateNameException("Email already used!");
                };

                var lastCustomerId = await _context.MsCustomer
                .OrderByDescending(x => x.Customer_id)
                .Select(x => x.Customer_id)
                .FirstOrDefaultAsync();

                var substringId = lastCustomerId?.Substring(3);
                var currentId = int.Parse(substringId);
                currentId += 1;
                var newCustomerId = currentId.ToString("D3");

                var newCustomer = new MsCustomer{
                    Customer_id = $"CUS{newCustomerId}",
                    name = request.name,
                    email = request.email,
                    password = request.password,
                    phone_number = request.phone_number,
                    address = request.address
                };
                _context.MsCustomer.Add(newCustomer);
                await _context.SaveChangesAsync();

                var response = new APIResponse<string>{
                    StatusCode = StatusCodes.Status201Created,
                    RequestMethod = HttpContext.Request.Method,
                    Data = "Created new customer"
                };
                return Ok(response);
            }
            catch(Exception ex)
            {
                var response = new APIResponse<string>{
                    StatusCode = StatusCodes.Status400BadRequest,
                    RequestMethod = HttpContext.Request.Method,
                    Data = ex.Message
                };
                return BadRequest(response);
            }
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<CustomerResult>> CheckEmail(string email)
        {
            try{
                bool isEmailExists = await _context.MsCustomer
                .Where(x => x.email == email).AnyAsync();
                if(isEmailExists)
                {
                    var response = new APIResponse<string>
                    {
                        StatusCode = StatusCodes.Status200OK,
                        RequestMethod = HttpContext.Request.Method,
                        Data = "Email found!"
                    };
                    return Ok(response);
                }
                else
                {
                    var response = new APIResponse<string>
                    {
                        StatusCode = StatusCodes.Status200OK,
                        RequestMethod = HttpContext.Request.Method,
                        Data = "Email already exists!"
                    };
                    return Ok(response);
                }
            }
            catch(Exception ex)
            {
                var response = new APIResponse<String>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    RequestMethod = HttpContext.Request.Method,
                    Data = "Email is missing"
                };
                return BadRequest(response);
            }
        }
    }
}
