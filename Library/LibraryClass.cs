using System.Collections.Generic;
using System;
using System.Linq;

public class Library
{
    private List<Book> books;
    private List<Member> members;
    private List<Transaction> transactions;

    public Library()
    {
        books = new List<Book>();
        members = new List<Member>();
        transactions = new List<Transaction>();
    }

    public void AddBook(Book book , Member member)
    {
        books.Add(book);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nBook '{book.Title}' has been added to the library by {member.Name} and the Author of the book({book.Author}).");
        Console.ResetColor();
    }

    public void RemoveBook(string isbn, Member member)
    {
        if (member.Role != UserRole.Boss)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Only Boss can remove books.");
            Console.ResetColor();
            return;
        }

        var book = books.FirstOrDefault(b => b.ISBN == isbn);
        if (book != null)
        {
            books.Remove(book);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Book '{book.Title}' has been removed from the library.");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Book not found.");
            Console.ResetColor();
        }
    }


    public void RegisterMember(Member member)
    {
        members.Add(member);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"You Have Been Registered By The Name '{member.Name}' And Your Id is : {member.MemberId}.");
        Console.ResetColor();
    }

    public void RemoveMember(int memberId)
    {
        var member = members.FirstOrDefault(m => m.MemberId == memberId);
        if (member != null)
        {
            members.Remove(member);
            Console.WriteLine($"Member '{member.Name}' removed.");
        }
        else
        {
            Console.WriteLine("Member not found.");
        }
    }

    public void BorrowBook(int memberId, string isbn)
    {
        var member = members.FirstOrDefault(m => m.MemberId == memberId);
        var book = books.FirstOrDefault(b => b.ISBN == isbn && b.IsAvailable);

        if (member != null && book != null)
        {
            book.IsAvailable = false;
            var transaction = new Transaction(member, book, DateTime.Now, null);
            transactions.Add(transaction);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Book '{book.Title}' borrowed by '{member.Name}'.");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor= ConsoleColor.DarkRed;
            Console.WriteLine("Cannot borrow book. Either book is not available or member not found.");
            Console.ResetColor();
        }
    }


    public void ReturnBook(int memberId, string isbn)
    {
        var transaction = transactions.FirstOrDefault(t => t.Book.ISBN == isbn && t.Member.MemberId == memberId && t.ReturnDate == null);

        if (transaction != null)
        {
            transaction.Book.IsAvailable = true;
            transaction.ReturnDate = DateTime.Now;
            Console.WriteLine($"Book '{transaction.Book.Title}' returned by '{transaction.Member.Name}'.");
        }
        else
        {
            Console.WriteLine("Transaction not found.");
        }
    }

    public void DisplayAvailableBooks()
    {
        foreach (var book in books.Where(b => b.IsAvailable))
        {
            book.DisplayInfo();
        }
        if (books.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("There Is No Books To Show.");
            Console.ResetColor();
        }
    }


    public void DisplayMembers()
    {
        foreach (var member in members)
        {
            member.DisplayInfo();
        }
    }

    public void DisplayTransactions()
    {
        foreach (var transaction in transactions)
        {
            transaction.DisplayInfo();
        }
    }

    public bool IsRegisteredMember(int memberId)
    {
        return members.Any(m => m.MemberId == memberId);
    }
    public Member GetMemberById(int memberId)
    {
        return members.FirstOrDefault(m => m.MemberId == memberId);
    }


}
