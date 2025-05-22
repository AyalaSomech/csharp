using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IOrder
    {
        //string randomOrderCode();
        void SaveOrder(string userId, string userName, double selectedSize, IImage _image, int phone, string email);
        void sendEmailByOrderId(string orderId);
    }
}
