using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class Author
    {
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public Author()
        {

        }
        public Author(string AuthorId,string AuthorName)
        {
            this.AuthorId = AuthorId;
            this.AuthorName = AuthorName;
        }
    }
}
