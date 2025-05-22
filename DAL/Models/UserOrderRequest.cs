using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class UserOrderRequest
    {


        public string UserId { get; set; }
        public string UserName { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public float SelectedSize { get; set; }


    }
}
