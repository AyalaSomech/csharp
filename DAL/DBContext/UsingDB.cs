using DAL.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;






namespace DAL.DBContext
{
    public class UsingDB
    {

        public void Create() {


            using (var context = new ApplicationDbContext())
            {
                List<string> images = new List<string>();
                context.Add(images);
                context.SaveChanges();
            }
        }

        public void Read()
        {


            using (var context = new ApplicationDbContext())
            {
                List<string> images = new List<string>();
                context.Add(images);
                context.SaveChanges();
            }
        }

    }
}
