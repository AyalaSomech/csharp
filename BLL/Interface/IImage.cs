using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IImage
    {
        //void display();
        List<string> ImageChoosing();
        void FindAndKeepDB(string OrderCode, double selectedSize);
    }
}
