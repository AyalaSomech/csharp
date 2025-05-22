
using BLL.Interface;
using BLL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Project_A.Models;
using System.Diagnostics;
//using NETCore.MailKit.Core;

namespace Project_A.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IImage _image;
        private readonly IOrder _order;
        private readonly IEmailService _email;
        public HomeController(ILogger<HomeController> logger, IImage image, IOrder order,IEmailService email)
        {
            _logger = logger;
            _image = image;
            _order = order;
            _email = email;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [HttpPost]
        public IActionResult SubmitOrder([FromBody] UserOrderRequest userOrder)
        {
            if (!string.IsNullOrEmpty(userOrder.UserId))
            {
                _order.SaveOrder(userOrder.UserId, userOrder.UserName, userOrder.SelectedSize, _image, userOrder.Phone, userOrder.Email);
;
                return Ok(new { success = true, message = "Order received successfully." });
            }
            return BadRequest(new { success = false, message = "Order not received. User ID is required." });
        }



        //public void sendEmailCtor(string email)
        //{
        //    //using (var )
        //    _email.SendEmail("as7674404@gmail.com");
        //}

        //[HttpPost]
        //public IActionResult SendEmail([FromBody] EmailRequest request)
        //{
        //    if (string.IsNullOrWhiteSpace(request?.To))
        //    {
        //        return BadRequest(new { success = false, message = "Email address is required." });
        //    }

        //    try
        //    {
        //        Console.WriteLine($"📩 Sending email to: {request.To}");
        //        _email.SendEmail(request.To); // קריאה לשירות השליחת מייל
        //        return Ok(new { success = true, message = "Email sent successfully." });
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"❌ ERROR sending email: {ex}");
        //        return StatusCode(500, new { success = false, message = "Failed to send email.", error = ex.Message });
        //    }
        //}

        //// מודל לבקשת שליחת אימייל
        //public class EmailRequest
        //{
        //    public string To { get; set; }
        //}





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}