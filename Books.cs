using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class Books:Author
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public double BookPrice { get; set; }
        public string BookCategory { get; set; }
        public double BookRentalPrice { get; set; }

        public Books()
        {

        }
        public Books(string AuthorId,string AuthorName,int BookId,string BookName,double BookPrice,string BookCategory):base(AuthorId,AuthorName)
        {
            this.AuthorId = AuthorId;
            this.AuthorName = AuthorName;
            this.BookId = BookId;
            this.BookName = BookName;
            this.BookPrice = BookPrice;
            this.BookCategory = BookCategory;
        }
    }
}
