using BLL.Interface;
using DAL.DBContext;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrderService : IOrder
    {
        private readonly IEmailService _emailService;
        public OrderService(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public void SaveOrder(string userId, string userName, double selectedSize, IImage _image, int phone, string email)
        {
            OrderManagment order = new(userId);
            try
            {
                _image.FindAndKeepDB(order.OrderCode, selectedSize);
            }
            catch (Exception ex) { Console.WriteLine($"SaveOrder falt: {ex.Message}"); }

            Customers customer = new(userId, userName, phone, email);

            //מריצים רק פעם אחת! 
            //Status S1 = new Status("new");
            //Status S2 = new Status("InTreatment");
            //Status S3 = new Status("finish");
            using (var context = new ApplicationDbContext())
            {
                //מריצים רק פעם אחת..
                //context.Statuse.Add(S1);
                //context.Statuse.Add(S2);
                //context.Statuse.Add(S3);
                context.Customers.Add(customer);
                context.OrderManagement.Add(order);
                context.SaveChanges(); // Save all changes to the database
            }
        }


        public void sendEmailByOrderId(string orderId)
        {


            string UserId;
            string UserName;
            string Email;
            int Phone;
            float SelectedSize;
            using (var context = new ApplicationDbContext())
            {
                var order = context.OrderManagement.FirstOrDefault(o => o.OrderCode == orderId);
                if (order == null)
                {
                    Console.WriteLine("the order is empty");
                    return;
                }

                context.SaveChanges();

                var image = context.SavingImages.FirstOrDefault(img => img.OrderCode == order.OrderCode);
                if (image != null)
                {
                    // שליפת פרטי הלקוח עבור שליחת מייל
                    var user = context.Customers.FirstOrDefault(u => u.CustomerCode == order.CustomerCode);
                    if (user != null)
                    {
                        UserId = user.CustomerCode.ToString();
                        UserName = user.NameE;
                        Email = user.Email;
                        Phone = user.Phone;
                        SelectedSize = (float)image.SizeImage;

                        _emailService.SendEmail(Email, UserName, UserId, Phone, SelectedSize);
                    }
                }
            }
        }
    }


}