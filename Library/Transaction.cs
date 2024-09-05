using System;

public class Transaction
{
    public Member Member { get; set; }
    public Book Book { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime? ReturnDate { get; set; }

    public Transaction(Member member, Book book, DateTime borrowDate, DateTime? returnDate)
    {
        Member = member;
        Book = book;
        BorrowDate = borrowDate;
        ReturnDate = returnDate;
    }

    public void DisplayInfo()
    {
        Console.Write($"Member: {Member.Name} has borrowed the book of the name ({Book.Title}) By the Author ({Book.Author})\n");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"Borrowed On:");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"\t{BorrowDate}\n");
        Console.ResetColor(); 
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write($"Returned On:");
        Console.ResetColor();       
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\t{ReturnDate?.ToString() ?? "Not Returned Yet"}");
        Console.ResetColor();
    }
}
