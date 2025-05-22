using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Models
{
    public class OrderManagment
    {
        private string orderCode;
        private int processStatus;
        private string officerCode;
        private string customerCode;

        
  

        public OrderManagment(string customerCode)
        {
            orderCode = randomOrderCode();
            processStatus = 1;
            officerCode = "Officer 10";
            this.customerCode = customerCode;
        }

        public string randomOrderCode()
        {
            string guid = Guid.NewGuid().ToString().Replace("-", "");
            return guid.Substring(0, 8); // קיצור ל-8 תווים
        }


        [Key]
        public string OrderCode
        {
            get { return orderCode; }
            set
            {
                
                orderCode = value;
            }
        }

        public int ProcessStatus
        {
            get { return processStatus; }
            set
            {
                if (value < 0 || value > 3) // לדוגמה: 0 = חדש, 1 = בעיבוד, 2 = מוכן, 3 = נשלח
                    throw new ArgumentException("סטטוס התהליך חייב להיות בין 0 ל-3.");
                processStatus = value;
            }
        }

        [ForeignKey("OfficerCode")]
        public string OfficerCode
        {
            get { return officerCode; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length != 3)
                    throw new ArgumentException("קוד הקצין חייב להכיל בדיוק 3 תווים.");
                officerCode = value.ToUpper(); // המרה לאותיות גדולות
            }
        }

        [ForeignKey("CustomerCode")]
        public string CustomerCode
        {
            get { return customerCode; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                    throw new ArgumentException("קוד הלקוח חייב להכיל לפחות 4 תווים.");
                customerCode = value;
            }
        }



    }
}
