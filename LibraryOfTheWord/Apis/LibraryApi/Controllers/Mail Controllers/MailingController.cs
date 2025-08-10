using LibraryApi.Data;
using LibraryApi.Models;
using LibraryApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailingController : ControllerBase
    {
        private readonly LibraryContext _context;

        public MailingController(LibraryContext context)
        {
            _context = context;
        }
        [HttpPost("send-login-email")]
        public async Task<IActionResult> NotifyOfLogIn(Customer customer)
        {
            if (await MailingService.SendMailPostSginIn(customer.Email, customer.Name)) {
                return Ok("Mail Has Been Sent");
            }else { return BadRequest("We don't know what happened but we will fix it"); }  
        }
    }
}
