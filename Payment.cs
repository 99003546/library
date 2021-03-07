using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class Payment
    {
        public double CalculatePrice(int days,Books booksObj)
        {

            double TotalPrice = days*booksObj.BookRentalPrice;
            return TotalPrice;
        }
    }
}
