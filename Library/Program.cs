using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();
        bool keepRunning = true;

        Console.WriteLine("***********************************************************************************************");
        Console.WriteLine("******************************* ~ WELCOME TO MY LIBRARY :) ~ **********************************");
        Console.WriteLine("******************************* ~  Hope U Enjoy <3  ~ *****************************************");
        Console.WriteLine("***********************************************************************************************\n");

        while (keepRunning)
        {

            
            Console.WriteLine("\n(1) Add Book\t\t\t(2) Remove Book\n(3) Register \t\t\t(4) View Available Books\n(5) View Members\t\t(6) Transactions\n(7) Borrow Book\t\t\t(8) Return Book\n(9) Exit");
            Console.Write("Choose what you want to do:");
            string s = Console.ReadLine();

            switch (s)
            {
                case "1":
                    Console.Write("Enter your Member");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" ID ");
                    Console.ResetColor();
                    Console.Write("Of The Member: ");


                    int memberId = int.Parse(Console.ReadLine());

                    if (library.IsRegisteredMember(memberId))
                    {
                        Member member = library.GetMemberById(memberId);  
                        Console.Write("Enter number of Books You Want To Add: ");
                        int bookCount = int.Parse(Console.ReadLine());
                        if (bookCount != 1)
                        {
                            Console.WriteLine($"Adding {bookCount} Books");
                        }
                        else
                        {
                            Console.WriteLine($"Adding {bookCount} Book");
                        }
                        for (int i = 1; i <= bookCount; i++)
                        {
                            if (i == 1)
                            {
                                Console.Write($"Enter title of {i}st book: ");
                            }
                            else if (i == 2)
                            {
                                Console.Write($"Enter title of {i}nd book: ");
                            }
                            else if (i == 3)
                            {
                                Console.Write($"Enter title of {i}rd book: ");
                            }
                            else
                            {
                                Console.Write($"Enter title of {i}th book: ");
                            }
                            string title = Console.ReadLine();
                            Console.Write("Enter author: ");
                            string author = Console.ReadLine();
                            Console.Write("Enter ISBN (International Standard Book Number): ");
                            string isbn = Console.ReadLine();

                            Console.Write("Adding");
                            int r = 5;
                            while(r>0)  
                            {
                                System.Threading.Thread.Sleep(500); 
                                Console.Write(".");
                                r--;
                            }
                            Console.WriteLine();  

                            Book book = new Book(title, author, isbn);
                            library.AddBook(book, member);
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("You are not registered. Please register first before adding books.");
                        Console.ResetColor();
                    }
                    break;

                case "2":
                    Console.Write("Enter your Member");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" ID ");
                    Console.ResetColor();
                    Console.Write("Of The Member: ");


                    int MemberId = int.Parse(Console.ReadLine());

                    if (library.IsRegisteredMember(MemberId))
                    {
                        Member member = library.GetMemberById(MemberId);

                        Console.Write("Enter ISBN of the book to remove: ");
                        string removeIsbn = Console.ReadLine();


                        library.RemoveBook(removeIsbn, member);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("You are not registered. Only registered members can remove books.");
                        Console.ResetColor();
                    }
                    break;

                case "3":
                        Console.Write($"Enter Your Name: ");
                        string name = Console.ReadLine();

                        Console.WriteLine("Select Role (1) Member, (2) Staff, (3) Boss: ");
                        string roleInput = Console.ReadLine();

                        UserRole role = UserRole.Member; 

                        switch (roleInput)
                        {
                            case "1":
                                role = UserRole.Member;
                                break;
                            case "2":
                                role = UserRole.Staff;
                                break;
                            case "3":
                                role = UserRole.Boss;
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Invalid input, registration aborted. Please enter 1, 2, or 3 for role selection.");
                                Console.ResetColor();
                                continue;  
                        }

                        library.RegisterMember(new Member(name, role));

                    break;


                case "4":
                    Console.Write("Please Just Wait A Second , Data Is Loading");
                    int j = 5;
                    while (j > 0)
                    {
                        System.Threading.Thread.Sleep(500);
                        Console.Write(".");
                        j--;
                    }
                    System.Threading.Thread.Sleep(100);
                    library.DisplayAvailableBooks();
                    break;

                case "5":
                    Console.WriteLine("\nLibrary members:");
                    library.DisplayMembers();
                    break;

                case "6":
                    Console.WriteLine("\nTransactions:");
                    library.DisplayTransactions();
                    break;

                case "7":
                    Console.Write("\nEnter member");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" ID ");
                    Console.ResetColor();
                    Console.Write("of the member: ");
                    memberId = int.Parse(Console.ReadLine());
                    Console.Write("Enter ISBN of the book to borrow: ");
                    string borrowIsbn = Console.ReadLine();

                    library.BorrowBook(memberId, borrowIsbn);
                    break;

                case "8":
                    Console.Write("\nEnter member ID to return a book: ");
                    memberId = int.Parse(Console.ReadLine());
                    Console.Write("Enter ISBN of the book to return: ");
                    string returnIsbn = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    library.ReturnBook(memberId, returnIsbn);
                    Console.ResetColor();
                    break;

                case "9":
                    keepRunning = false;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Thank you for using the library, i hope to see you again :)!");
                    Console.ResetColor();
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("not a vaild option please try again.");
                    break;
            }
        }
        Console.ReadKey();
    }
}
