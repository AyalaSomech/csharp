using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace BLL.Interface
{
    public interface IEmailService
    {
        void SendEmail(string to, string UserName, string UserId, int Phone, float SelectedSize);
    }
}
