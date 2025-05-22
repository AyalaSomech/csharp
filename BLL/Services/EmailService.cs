using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

using Microsoft.Extensions.Configuration;

using BLL.Interface;
using DAL.DBContext;
using DAL.Models;


namespace BLL.Services
{
    public class EmailService : IEmailService
    {

        private readonly IConfiguration _config;
        
        public EmailService(IConfiguration config)
        {
            _config = config;
        }
        //send email function 
        public void SendEmail(string to, string UserName, string UserId, int Phone, float SelectedSize)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Technical support", _config["EmailSettings:Username"]));

            message.To.Add(new MailboxAddress(_config["EmailSettings:Username"], to));
            message.Subject = "מערכת לניהול הזמנות";
            message.Body = new TextPart("plain") { Text = "ההזמנה הושלמה, ניתן לבוא לקחת את התמונות. " };
            using var client = new SmtpClient();

            try
            {
                client.Connect("smtp.gmail.com", 587, SecureSocketOptions.None);
                client.Authenticate(_config["EmailSettings:Username"], _config["EmailSettings:Password"]);
                client.Send(message);
                Console.WriteLine("Email sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error:  {ex.Message}");
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}