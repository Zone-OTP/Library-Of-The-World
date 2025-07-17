using LibraryApi.Data;
using LibraryApi.Models;
using LibraryApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly LibraryContext _context;

        public CustomersController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await CustomerService.GetCustomers(_context);
        }

        [HttpGet("spesificcustomerget/{customerId}/{customerName}")]
        public async Task<ActionResult<Customer>> GetCustomer(int customerId, string customerName)
        {
            try
            {
                if (customerId == 0)
                {
                    return await CustomerService.GetCustomerByName(customerName, _context);
                }
                else if (customerName == "empty")
                {
                    return await CustomerService.GetCustomerById(customerId, _context);
                }
                else { Console.WriteLine("No Customer Found With that data"); return null; }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return null; }
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            if (await CustomerService.AddCustomer(customer, _context))
            {
                return Created($"/api/customers/{customer.CustomerId}", customer);
            }
            else
            {
                return Conflict("Customer Exists");
            }
        }

        [HttpPost("Validate")]
        public async Task<ActionResult<Customer>> ValidateCustomer(Customer customer)
        {

            if (await CustomerService.ValidateLoginAsync(customer, _context))
            {
                return Ok(true);
            }
            else { return NotFound(false); }

        }

        [HttpPatch("passwordReset/{token}")]
        public async Task<ActionResult<Customer>> PasswordReset(string token)
        {
            return Ok();
        }

        [HttpDelete("deletecustomer/{customerId}")]

        public async Task<ActionResult<Customer>> DeleteCustomer(int customerId)
        {

            if (await CustomerService.RemoveCustomer(customerId, _context))
            {
                return Ok("Delete Worked");
            }
            else
            {
                return Conflict("Failed To Delete Customer,Customer Could have Checkouts");
            }

        }

    }
}