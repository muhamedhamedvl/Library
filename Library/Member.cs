using System;

public enum UserRole
{
    Member,
    Staff,
    Boss
}

public class Member
{
    public int MemberId { get; }
    public string Name { get; }
    public UserRole Role { get; }  

    public Member(string name, UserRole role)
    {
        Name = name;
        Role = role;
        MemberId = new Random().Next(1000, 9999);  
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"ID: {MemberId}, Name: {Name}, Role: {Role}");
    }
}
