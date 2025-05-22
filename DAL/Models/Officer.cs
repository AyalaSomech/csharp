using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Officer
    {
        //private int id;
        private string officerCode;
        private string name;
        private int phone;

        // Default constructor
        public Officer() { }

        // Parameterized constructor
        public Officer( string officerCode, string name, int phone)
        {
            this.officerCode = officerCode;
            this.name = name;
            this.phone = phone;
        }

        // Getter and Setter for officerCode

        [Key]
        public string OfficerCode
        {
            get { return officerCode; }
            set { officerCode = value; }
        }

        // Getter and Setter for name
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // Getter and Setter for phone
        public int Phone
        {
            get { return phone; }
            set { phone = value; }
        }
    }
}
