using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class Program
    {
        static List<Books> BookList = new List<Books>();
       // static List<User> UserList = new List<User>();

        static void Main(string[] args)
        {
            
            Books[] BookObj = new Books[10];
            for(int i=0;i<5;i++)
            {
                BookObj[0] = new Books("A1","Onkar", 1, "Biology", 200, "Science");
                BookObj[1] = new Books("A1", "Onkar", 2, "Maths", 200, "Science");
                BookObj[2] = new Books("A1", "Onkar", 3, "Physics", 200, "Science");
                BookObj[3] = new Books("A2", "Shrileka", 4, "Chemistry", 200, "Science");
                BookObj[4] = new Books("A3", "Shrileka", 5, "English", 200, "Launguage");

                BookList.Add(BookObj[i]);
            }

            try
            {
                Librarian LibObj = new Librarian();
                Books BkObj = new Books();
                double values;
                Console.WriteLine("Enter Rent Price");
                BkObj.BookRentalPrice = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("1.Librarian\t2.User");
                int value = Convert.ToInt32(Console.ReadLine());
                if (value == 1)
                {
                    Console.WriteLine("Enter User Name");
                    string UserName = Console.ReadLine();
                    Console.WriteLine("Enter Password");
                    string pass = Console.ReadLine();
                    int lib = LibObj.Login(UserName, pass);
                    if (lib == 1)
                    {
                        while (true)
                        {
                            Console.WriteLine("1.Display Book\t2.Add Book\t3.Remove Book\t4.Exit");
                            int choice = Convert.ToInt32(Console.ReadLine());
                            if (choice == 1)
                            {
                                foreach (Books item in BookList)
                                {
                                    Console.WriteLine("BookId:" + item.BookId + "\tBook Name:" + item.BookName + "\tBook Price:" + item.BookPrice + "\tBook Category:" + item.BookCategory + "\tAuthor Id:" + item.AuthorId + "\tAuthor Name:" + item.AuthorName);
                                }
                            }
                            else if (choice == 2)
                            {
                                Books BObj = new Books();
                                Console.WriteLine("Enter how many book");
                                int n = Convert.ToInt32(Console.ReadLine());
                                for (int i = 0; i < n; i++)
                                {
                                    Console.WriteLine("Enter Book Id");
                                    BObj.BookId = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Enter Book Name");
                                    BObj.BookName = Console.ReadLine();
                                    Console.WriteLine("Enter Book Price");
                                    BObj.BookPrice = Convert.ToDouble(Console.ReadLine());
                                    Console.WriteLine("Enter Book Category");
                                    BObj.BookCategory = Console.ReadLine();
                                    Console.WriteLine("Enter Author Id");
                                    BObj.AuthorId = Console.ReadLine();
                                    Console.WriteLine("Enter Author Name");
                                    BObj.AuthorName = Console.ReadLine();

                                    BookList.Add(BObj);
                                }
                            }
                            else if (choice == 3)
                            {
                                foreach (Books item in BookList)
                                {
                                    Console.WriteLine("Enter Book Id to Delete");
                                    int id = Convert.ToInt32(Console.ReadLine());
                                    if (id == item.BookId)
                                    {
                                        BookList.Remove(item);
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Login Failed");
                    }

                }
                else if (value == 2)
                {
                    User UserObj = new User();
                    Books BObj = new Books();
                    Payment PObj = new Payment();
                    Console.WriteLine("List Of Books");
                    foreach (Books item in BookList)
                    {
                        Console.WriteLine("BookId:" + item.BookId + "\t\tBook Name:" + item.BookName + "\t\t\tBook Price:" + item.BookPrice);
                    }
                    Console.WriteLine("Enter Book Id you want to rent");
                    int BookId = Convert.ToInt32(Console.ReadLine());
                    foreach (Books item in BookList)
                    {
                        if (BookId == item.BookId)
                        {
                            Console.WriteLine("Enter User Id");
                            UserObj.UserId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter User Name");
                            UserObj.UserName = Console.ReadLine();
                            Console.WriteLine("Enter User Address");
                            UserObj.UserAddress = Console.ReadLine();
                            Console.WriteLine("Enter Phone Number");
                            UserObj.PhoneNumber = Convert.ToInt64(Console.ReadLine());
                            Console.WriteLine("Enter How many days");

                        }
                    }
                    int days = Convert.ToInt32(Console.ReadLine());
                    values = PObj.CalculatePrice(days, BkObj);

                    Console.WriteLine("Book Id:" + BookId + "\nUser Name:" + UserObj.UserName + "\nUser Id:" + UserObj.UserId + "\nUser Address:" + UserObj.UserAddress + "\nUser Phone Number:" + UserObj.PhoneNumber + "\nTotal Price:" + values);

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
                
            
        }
    }
}
