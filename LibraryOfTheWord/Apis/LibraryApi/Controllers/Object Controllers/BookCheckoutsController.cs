using LibraryApi.Data;
using LibraryApi.Models;
using LibraryApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookCheckoutsController : ControllerBase
    {
        private readonly LibraryContext _context;

        public BookCheckoutsController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookCheckout>>> GetBookCheckouts()
        {
            return await CheckoutService.GetCheckouts(_context);
        }



    }
}