using LibraryApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Controllers
{
    public class ChecksController : Controller
    {
        private readonly LibraryContext _context;
        public ChecksController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet("{type}/id/{id}")]
        public async Task<bool> EntityExists(string type, string entityName)
        {
            switch ($"{type.ToLower()}s")
            {
                case "authors":
                    return await _context.Authors.AnyAsync(a => a.Name.Equals(entityName, StringComparison.OrdinalIgnoreCase));
                case "books":
                    return await _context.Books.AnyAsync(b => b.Name.Equals(entityName, StringComparison.OrdinalIgnoreCase));
                case "customers":
                    return await _context.Customers.AnyAsync(c => c.Name.Equals(entityName, StringComparison.OrdinalIgnoreCase));
                case "admins":
                    return await _context.Admins.AnyAsync(d => d.Name.Equals(entityName, StringComparison.OrdinalIgnoreCase));
                //case "bookcheckouts":
                //    return await _context.BookCheckouts.AnyAsync(e => e.BookCheckoutId == entityId);
                default:
                    return false;
            }
        }
    }
}
