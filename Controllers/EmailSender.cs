using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace IdentityUserCustom.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmailSender : ControllerBase
    {
        [HttpPost(Name = "send-mail")]
        [Authorize]
        public async Task Mail(string email, string message)
        {
            // Replace these with your actual Ethereal SMTP credentials
            string smtpHost = "smtp.ethereal.email";
            int smtpPort = 587;
            string smtpUsername = "anna4@ethereal.email";
            string smtpPassword = "VzrGNdMz6s9jy63Kpb";

            // Create the email message
            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress("noreply@mail.com"),
                Subject = "Test Email",
                Body = message,
                IsBodyHtml = false
            };

            // Add recipient email address
            mailMessage.To.Add(email);

            // Configure the SMTP client
            SmtpClient smtpClient = new SmtpClient(smtpHost)
            {
                Port = smtpPort,
                Credentials = new NetworkCredential(smtpUsername, smtpPassword),
                EnableSsl = true
            };

            try
            {
                // Send the email
                await smtpClient.SendMailAsync(mailMessage);
                Console.WriteLine("Email sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        }
    }

}
