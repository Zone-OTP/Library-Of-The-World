using LibraryApi.Data;
using LibraryApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordResetController : ControllerBase
    {
        private readonly LibraryContext _context;
        public PasswordResetController(LibraryContext context)
        {
            _context = context;
        }
        public class ResetPasswordDto
        {
            public string Token { get; set; }
            public string NewPassword { get; set; }
        }

        [HttpPost("request")]
        public async Task<IActionResult> RequestPasswordReset([FromBody] string email)
        {
            try
            {
                if (await PasswordResetService.RequestSending(email, _context))
                {
                    return Ok("Password Reset email sent.");
                }
                else { return BadRequest("can't send password Reset email"); }
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPatch("reset-password")]
        public async Task<IActionResult> PasswordReset([FromBody] ResetPasswordDto model)
        {
            try
            {
                if (await PasswordResetService.ResetPasswordAsync(model.Token, model.NewPassword, _context))
                {
                    return Ok("Password has been Reset");
                }
                else { return Conflict("Something Went Wrong in Changing the Password "); }
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}
