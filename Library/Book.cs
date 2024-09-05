using System;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public bool IsAvailable { get; set; }

    public Book(string title, string author, string isbn)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        IsAvailable = true;
    }

    public void DisplayInfo()
    {
        string availability = IsAvailable ? "available" : "not available";
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("Available Books:\n");
        Console.ResetColor();

        Console.Write($"ISBN:{ISBN} => Book by the Author {Author} and the title {Title} and it's ");
        if (IsAvailable)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(availability);
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(availability);
            Console.ResetColor();
        }
    }
}
