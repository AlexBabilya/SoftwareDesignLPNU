namespace WPF.Models;
using System;

public class Author
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTimeOffset? Birthdate { get; set; }
    public string Nationality { get; set; }
    public int id { get; set; }

    public Author(int ID, string firstName , string lastName, DateTimeOffset? birthdate, string nationality)
    {
        id = ID;
        FirstName = firstName;
        LastName = lastName;
        Birthdate = birthdate;
        Nationality = nationality;
    }
}