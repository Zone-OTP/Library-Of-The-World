using LibraryApi.Data;
using LibraryApi.Models;
using LibraryApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly LibraryContext _context;

        public AdminsController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAdmins()
        {
            return await AdminService.GetAdminList(_context);
        }



        [HttpPost]
        public async Task<ActionResult<Admin>> PostAdmin(Admin admin)
        {

            if (await AdminService.AddUser(admin, _context))
            {
                return CreatedAtAction(nameof(GetAdmins), new { id = admin.AdminId }, admin);
            }
            else { return Conflict("Username already exists"); }

        }
        [HttpPost("Validate")]
        public async Task<ActionResult<Admin>> ValidateAdmin(Admin admin)
        {

            if (await AdminService.SignInCheck(admin, _context))
            {
                return Ok(true);
            }
            else { return NotFound(false); }

        }
    }
}