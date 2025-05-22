using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Models
{
    public class Status
    {
        //private int id;
        private int processStatus;
        private string statusDescription;

        // Default constructor
        public Status() { }

        // Parameterized constructor
        public Status( string statusDescription)
        {
            this.statusDescription = statusDescription;
        }


        // Getter and Setter for processStatus

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // מספור אוטומטי
        public int ProcessStatus
        {
            get { return processStatus; }
            set { processStatus = value; }
        }

        // Getter and Setter for statusDescription
        public string StatusDescription
        {
            get { return statusDescription; }
            set { statusDescription = value; }
        }
    }

}
