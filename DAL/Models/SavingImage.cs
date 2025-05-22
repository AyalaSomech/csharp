using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DAL.Models
{
    public class SavingImage
    {
        private int id;
        private string orderCode;
        private Byte[] images;
        private int processStatus;
        private double sizeImage;


        public SavingImage() // Parameterless constructor

        {

        }
        public SavingImage(string _orderCode, byte[] _images, int _processStatus, double _sizeImage)
        {
            
            orderCode = _orderCode;
            images = _images;
            processStatus = _processStatus;
            sizeImage = _sizeImage;
        }
   


    public double SizeImage
        {
            get => sizeImage;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Size must be a non-negative number.");
                }
                sizeImage = value;
            }
        }

        [Key] // מזהה שזה מפתח ראשי
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // מספור אוטומטי
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        [ForeignKey("OrderCode")]
        public string OrderCode
        {
            get { return orderCode; }
            set { orderCode = value; }
        }
        public Byte[] Images
        {
            get { return images; }
            set { images = value; }
        }

        [ForeignKey("ProcessStatus")]
        public int ProcessStatus
        {
            get { return processStatus; }
            set { processStatus = value; }
        }

       
    }
}