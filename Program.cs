using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMain;

namespace BookMain
{
    public class Program
    {
 


        public static void Main(string[] args)
        {
            List<BorrowDetails> borrowList = new List<BorrowDetails>();
            Book book = new Book();
            BorrowDetails borrow = new BorrowDetails();
            List<Book> bookList = new List<Book>();
            Payment pay = new Payment();
            User obj = new User();
            /* Console.WriteLine("Enter username");
             String Username = Console.ReadLine();
             Console.WriteLine("Enter Password");
             String Password = Console.ReadLine();
             int value = obj.Login(Username, Password);
             if(value==1)
             {
                 Console.WriteLine("Login Successful");
             }
             else
             {
                 Console.WriteLine("Invalid User");
             }*/
            List<User> UserList = new List<User>(20);

            Console.WriteLine("**************Sign Up**********************");

            Console.WriteLine("Enter User Name for Sign Up");
            String userName = Console.ReadLine();
            Console.WriteLine("Enter Password for Sign Up");
            String password = Console.ReadLine();
            Console.WriteLine("Enter Date of Birth ");
            DateTime dob = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter Mobile Number ");
            long mNo = Convert.ToInt64(Console.ReadLine());

            User UserObj = new User(userName, password, mNo);
            UserList.Add(UserObj);
            Console.WriteLine("*************Signup Successfull******************");

            Console.WriteLine("\n ");
            Console.WriteLine("Enter The User Name for Login");
            String UserName = Console.ReadLine();
            Console.WriteLine("Enter The Password for Login");
            String Password = Console.ReadLine();
            int value = UserObj.Login(UserName, Password);
            Book b = new Book();
            if (value == 1)
            {
                Console.WriteLine("**********Login Successful******************");
                bool close = true;
                while (close)
                {
                    Console.WriteLine("\nMenu\n" +
                    "1)Add book\n" +
                    "2)Delete book\n" +
                    "3)Search book\n" +
                    "4)Borrow book\n" +
                    "5)Close\n\n");
                    Console.Write("Choose your option from menu :");

                    int option = int.Parse(Console.ReadLine());

                    if (option == 1)
                    {
                        
                        GetBook();
                    }
                    else if (option == 2)
                    {
                        RemoveBook();
                    }
                    else if (option == 3)
                    {
                        SearchBook();
                    }
                    else if (option == 4)
                    {
                        Borrow();
                    }

                    else if (option == 5)
                    {
                        Console.WriteLine("Thank you");
                        close = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid option\nRetry !!!");
                    }
                }
            }


            else
            {
                Console.WriteLine("Invalid User");
            }


            void GetBook()
            {
                Console.WriteLine("Book Id:{0}", book.bookId = bookList.Count + 1);
                Console.Write("Book Name:");
                book.bookName = Console.ReadLine();
                Console.Write("Book Price:");
                book.bookPrice = int.Parse(Console.ReadLine());
                Console.Write("Number of Books:");
                book.xo = book.bookCount = int.Parse(Console.ReadLine());
                bookList.Add(book);
            }

            //To delete book details from the Library database 
            void RemoveBook()
            {
                Console.Write("Enter Book id to be deleted : ");

                int Del = int.Parse(Console.ReadLine());

                if (bookList.Exists(x => x.bookId == Del))
                {
                    bookList.RemoveAt(Del - 1);
                    Console.WriteLine("Book id - {0} has been deleted", Del);
                }
                else
                {
                    Console.WriteLine("Invalid Book id");
                }

                bookList.Add(book);
            }

            //To search book details from the Library database using Book id 
            void SearchBook()
            {
          
                Console.Write("Search by BOOK id :");
                int find = int.Parse(Console.ReadLine());

                if (bookList.Exists(x => x.bookId == find))
                {
                    foreach (Book searchId in bookList)
                    {
                        if (searchId.bookId == find)
                        {
                            Console.WriteLine("Book id :{0}\n" +
                            "Book name :{1}\n" +
                            "Book price :{2}\n" +
                            "Book Count :{3}", searchId.bookId, searchId.bookName, searchId.bookPrice, searchId.bookCount);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Book id {0} not found", find);
                }
            }
            void Borrow()
            {
                Console.WriteLine("User id : {0}", (borrow.userId = borrowList.Count + 1));
                Console.Write("Name :");

                borrow.userName = Console.ReadLine();

                Console.Write("Book id :");
                borrow.borrowBookId = int.Parse(Console.ReadLine());
                Console.Write("Number of Books : ");
                borrow.borrowCount = int.Parse(Console.ReadLine());
                Console.Write("Address :");
                borrow.userAddress = Console.ReadLine();
                borrow.borrowDate = DateTime.Now;
                Console.WriteLine("Date - {0} and Time - {1}", borrow.borrowDate.ToShortDateString(), borrow.borrowDate.ToShortTimeString());

                if (bookList.Exists(x => x.bookId == borrow.borrowBookId))
                {
                    foreach (Book searchId in bookList)
                    {
                        if (searchId.bookCount >= searchId.bookCount - borrow.borrowCount && searchId.bookCount - borrow.borrowCount >= 0)
                        {
                            if (searchId.bookId == borrow.borrowBookId)
                            {
                                searchId.bookCount = searchId.bookCount - borrow.borrowCount;
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Only {0} books are found", searchId.bookCount);
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Book id {0} not found", borrow.borrowBookId);
                }
                borrowList.Add(borrow);
            }


            Console.WriteLine("Enter your mode of Payment");
            int checkout_input = Convert.ToInt32(Console.ReadLine());
            //double price=Convert.ToDouble(Console.ReadLine());
            //int Quantity= Convert.ToInt32(Console.ReadLine());
            var Total = pay.CalculatePrice(bookPrice, bookCount);
            if (checkout_input == 1)
            {
                Console.WriteLine("1.Credit Card\n2.Debit Card\n");
                int payment_input = Convert.ToInt32(Console.ReadLine());
                if (payment_input == 1)
                {
                    Console.WriteLine("Enter your credit card number : \n");
                    string creditCardNumber = Console.ReadLine();
                    Console.WriteLine("\nEnter card holder name : \n");
                    string cardHolderName = Console.ReadLine();
                    Console.WriteLine("\nEnter expiry date : \n");
                    string expDate = Console.ReadLine();
                    Console.WriteLine("\n" + pay.PaymentMode(payment_input, creditCardNumber, cardHolderName, expDate));
                }
                else if (payment_input == 2)
                {
                    Console.WriteLine("Enter your debit card number : \n");
                    string debitCardNumber = Console.ReadLine();
                    Console.WriteLine("\nEnter card holder name : \n");
                    string cardHolderName = Console.ReadLine();
                    Console.WriteLine("\nEnter expiry date : \n");
                    string cvv = Console.ReadLine();
                    Console.WriteLine("\n" + pay.PaymentMode(payment_input, debitCardNumber, cardHolderName, cvv));
                }
            }
            else
            {
                Console.WriteLine("Pay By Cash");

            }

        }
    }
}
