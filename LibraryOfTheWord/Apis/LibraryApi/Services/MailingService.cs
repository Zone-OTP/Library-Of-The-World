using LibraryErrorLogs;
using System.Net;
using System.Net.Mail;

namespace LibraryApi.Services
{
    public class MailingService
    {
        private readonly static ILoggerService _logger = new LoggerService("MailingServiceBackEnd");
        public static async Task<bool> SendMailPostRegistration(string customerEmail, string customerName)
        {
            try
            {
                var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
                var hostEmail = config["HostEmail:Email"];
                var hostPassword = config["HostEmail:Password"];
                var fromAddress = new MailAddress(hostEmail, "LibraryApp");
                var toAddress = new MailAddress(customerEmail, customerName);

                const string subject = "Registration";
                const string body = "You have successfully registered in the Library Of The World, Happy Reading";
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(fromAddress.Address, hostPassword),
                    Timeout = 20000
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
                return true;
            }
            catch (Exception ex) { await _logger.LogError(ex, $"Error Thrown at Mail Delivery{ex.Message}"); return false; }
        }
        public static async Task<bool> SendMailPostSginIn(string customerEmail, string customerName)
        {
            try {
                var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
                var hostEmail = config["HostEmail:Email"];
                var hostPassword = config["HostEmail:Password"];
                var fromAddress = new MailAddress(hostEmail, "LibraryApp");
                var toAddress = new MailAddress(customerEmail, customerName);

                const string subject = "Sign In";
                const string body = "Some one has signed in to your account, is it you? if not please change your password immediately";
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(fromAddress.Address, hostPassword),
                    Timeout = 20000
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
                return true;
            }
            catch (Exception ex) { await _logger.LogError(ex, $"Error Thrown at Mail Delivery{ex}"); return false; }
        }

        public static async Task<bool> SendMailToResetPassword(string customerEmail, string resetLink)
        {
            try
            {
                var config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .Build();
                var hostEmail = config["HostEmail:Email"];
                var hostPassword = config["HostEmail:Password"];
                var fromAddress = new MailAddress(hostEmail, "LibraryApp");
                var toAddress = new MailAddress(customerEmail);

                const string subject = "Password Reset";
                string body = $"<html><body><p>Click <a href=\"{resetLink}\" target=\"_blank\">here</a> to reset your password.</p></body></html>";
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(fromAddress.Address, hostPassword),
                    Timeout = 20000
                };


                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true,
                    BodyEncoding = System.Text.Encoding.UTF8
                })
                {
                    smtp.Send(message);
                }
                return true;
            }
            catch (Exception ex) { await _logger.LogError(ex, $"Error Thrown at Mail Delivery{ex}"); return false; }
        }
    }
}
