using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace EmployeeManagement.BL.Utilities;

public class EmailService
{
    IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void SendConfirmation(string to, string url)
    {
        SmtpClient smtp = new (_configuration["Email:Host"], Convert.ToInt32(_configuration["Email:Port"]))
        {
            Credentials = new NetworkCredential(_configuration["Email:Login"], _configuration["Email:Passcode"]),
            EnableSsl = true
        };

        MailAddress from = new (_configuration["Email:Login"]);
        MailAddress destination = new (to);

        MailMessage message = new (from, destination)
        {
            Subject = "Email Confirmation",
            Body = $"<a href={url}>Click here to confirm your account!</a>",
            IsBodyHtml = true
        };

        smtp.Send(message);
    }
}
