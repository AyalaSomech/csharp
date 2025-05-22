using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Customers
    {
        private string customerCode;
        private string nameE;
        private int phone;
        private string email;

        public Customers() { }  
        public Customers(string CustomerCode, string NameE, int Phone, string Email)
        {
            customerCode = CustomerCode;
            nameE = NameE;
            phone = Phone;
            email = Email;
        }

        [Key]
        public string CustomerCode
        {
            get => customerCode;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Customer code cannot be empty.");
                customerCode = value;
            }
        }

        public string NameE
        {
            get => nameE;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty.");
                if (value.Length < 2)
                    throw new ArgumentException("Name must be at least 2 characters long.");
                nameE = value;
            }
        }

        public int Phone
        {
            get => phone;
            set
            {
                if (value.ToString().Length < 9 || value.ToString().Length > 10)
                    throw new ArgumentException("Phone number must be 9 or 10 digits.");
                phone = value;
            }
        }
        public string Email
        {
            get => email;
            set
            {
                //if
                email = value;
            }
        }

        public OrderManagment CreatOrder(string customerCode)
        {
            return new OrderManagment(customerCode);
        }

    }
}
