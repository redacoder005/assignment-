using ReadMoreBooks.Data;
using ReadMoreBooks.Models;

using var context = new BookStoreContext();


if (context.Database.CanConnect())
    Console.WriteLine("Connected to ReadMoreBooksDb successfully!");
else
    Console.WriteLine("Cannot connect to the database.");


if (!context.Books.Any())
{
    var category = new Category
    {
        Name = "Programming",
        Description = "Software development books",
        IsActive = true
    };

    var author = new Author
    {
        FirstName = "Ahmed",
        LastName = "Ali",
        Email = "ahmed@email.com",
        Biography = "Writes about C# and .NET",
        DateOfBirth = new DateTime(1985, 5, 20)
    };

    var book = new Book
    {
        Title = "Learn EF Core",
        ISBN = "978-1234567890",
        Price = 250.50m,
        NumberOfPages = 400,
        YearPublished = 2024,
        InStock = true,
        Category = category,
        Author = author
    };

    context.Books.Add(book);
    context.SaveChanges();
    Console.WriteLine("Sample data saved.");
}


foreach (var b in context.Books)
{
    Console.WriteLine($"Book #{b.Id}: {b.Title} | ISBN: {b.ISBN} | Price: {b.Price} | In stock: {b.InStock}");
}