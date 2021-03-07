using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class Librarian
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public int Login(string UserName,string Password)
        {
            if(UserName=="onkar"&&Password=="password")
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
