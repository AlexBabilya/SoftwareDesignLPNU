// Program.cs
using System;
using System.Linq;

class Program
{
    static void Main()
    {
        AuthorRepository authorRepository = new AuthorRepository();
        
        Author newAuthor = new Author
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            Birthdate = new DateTime(1980, 5, 15),
            Nationality = "USA"
        };

        authorRepository.AddAuthor(newAuthor);
        Console.WriteLine("Author added.");

        var allAuthors = authorRepository.GetAllAuthors();
        Console.WriteLine("All Authors:");
        foreach (var author in allAuthors)
        {
            Console.WriteLine($"ID: {author.Id}, Name: {author.FirstName} {author.LastName}, Birthdate: {author.Birthdate}, Nationality: {author.Nationality}");
        }
        // Update an author
        Author authorToUpdate = allAuthors.FirstOrDefault();
        if (authorToUpdate != null)
        {
            authorToUpdate.FirstName = "UpdatedFirstName";
            authorToUpdate.LastName = "UpdatedLastName";
            authorRepository.UpdateAuthor(authorToUpdate);
            Console.WriteLine("Author updated.");
        }

        // Get all authors after the update
        var updatedAuthors = authorRepository.GetAllAuthors();
        Console.WriteLine("All Authors after Update:");
        foreach (var author in updatedAuthors)
        {
            Console.WriteLine($"ID: {author.Id}, Name: {author.FirstName} {author.LastName}, Birthdate: {author.Birthdate}, Nationality: {author.Nationality}");
        }

        // Delete an author
        Author authorToDelete = updatedAuthors.FirstOrDefault();
        if (authorToDelete != null)
        {
            authorRepository.DeleteAuthor(authorToDelete.Id);
            Console.WriteLine("Author deleted.");
        }

        // Get all authors after the delete
        var remainingAuthors = authorRepository.GetAllAuthors();
        Console.WriteLine("All Authors after Delete:");
        foreach (var author in remainingAuthors)
        {
            Console.WriteLine($"ID: {author.Id}, Name: {author.FirstName} {author.LastName}, Birthdate: {author.Birthdate}, Nationality: {author.Nationality}");
        }

        Console.ReadLine(); // Keep console window open for viewing the results
    }
}

