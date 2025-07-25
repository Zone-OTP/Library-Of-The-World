using LibraryApi.Data;
using LibraryApi.Models;
using LibraryErrorLogs;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibraryApi.Services
{
    public class PasswordResetService
    {
        private readonly LibraryContext _context;
        private readonly static ILoggerService _logger = new LoggerService("PasswordResetServiceBackEnd");
        public static async Task<bool> ValidateTokenAsync(string token, LibraryContext _context)
        {
            var reset = await _context.PasswordResets
                .FirstOrDefaultAsync(pr => pr.Token == token && pr.ExpiresAt > DateTime.UtcNow);
            return reset != null;
        }
        public static async Task<bool> ResetPasswordAsync(string token, string newPassword, LibraryContext _context)
        {
            try
            {
                var reset = await _context.PasswordResets.FirstOrDefaultAsync(pr => pr.Token == token && pr.ExpiresAt > DateTime.UtcNow);
                var customer = await CustomerService.GetCustomerById(reset.CustomerId, _context);
                if (reset == null) return false;

                customer.Password = newPassword;
                _context.PasswordResets.Remove(reset);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { await _logger.LogError(ex, ex.Message);return false; }
        }
        public static async Task<bool> RequestSending(string email, LibraryContext _context)
        {
            try
            {
                var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);
                if (customer == null)
                {
                    throw new Exception("customer Not Found");
                }

                string token = Guid.NewGuid().ToString();

                var passwordReset = new PasswordReset
                {
                    CustomerId = customer.CustomerId,
                    Token = token,
                    ExpiresAt = DateTime.UtcNow.AddMinutes(30)
                };
                _context.PasswordResets.Add(passwordReset);
                _context.SaveChangesAsync();
                string resetLink = $"https://localhost:7169/reset?token={token}";
                await MailingService.SendMailToResetPassword(email, resetLink);
                return true;
            }
            catch (Exception ex) { await _logger.LogError(ex, ex.Message);return false; }
        }
    }
}
