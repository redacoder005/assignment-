using System.Text;

namespace assignment_2
{
    internal class Program
    {
        static void PrintFirstBook(string[] books)
        {
            if (books.Length == 0)
            {
                return;
            }

            Console.WriteLine(books[0]);
        }

        static void Main(string[] args)
        {
            
            string title = "clean code";

            string upperTitle = title.ToUpper();

            Console.WriteLine(title);
            Console.WriteLine(upperTitle);

            
            string book1 = "Clean Code";
            string book2 = "Clean Code";

            Console.WriteLine(ReferenceEquals(book1, book2));

            
            StringBuilder booksList = new StringBuilder();

            booksList.Append("Book List");
            booksList.Append(" - Updated");

            Console.WriteLine(booksList);

            
            booksList.Replace("Book List", "Library");

            Console.WriteLine(booksList);

            
            string bookTitle = "Clean Code";
            int pages = 464;

            string sentence1 = "Book: " + bookTitle + ", Pages: " + pages;

            Console.WriteLine(sentence1);

            
            string sentence2 = $"Book: {bookTitle}, Pages: {pages}";

            Console.WriteLine(sentence2);

            
            string sentence3 = string.Format("Book: {0}, Pages: {1}", bookTitle, pages);

            Console.WriteLine(sentence3);

            
            if (pages > 300)
            {
                Console.WriteLine("Long Book");
            }
            else
            {
                Console.WriteLine("Short Book");
            }

            
            bool isAvailable = true;

            if (pages > 300 && isAvailable == true)
            {
                Console.WriteLine("You can borrow this book");
            }

           
            string title2 = "Refactoring";

            switch (title2)
            {
                case "Clean Code":
                    Console.WriteLine("Great choice");
                    break;

                case "Refactoring":
                    Console.WriteLine("Nice pick");
                    break;

                default:
                    Console.WriteLine("Never heard of it");
                    break;
            }

            
            string sizeLabel;

            if (pages > 300)
            {
                sizeLabel = "Long Book";
            }
            else
            {
                sizeLabel = "Short Book";
            }

            Console.WriteLine(sizeLabel);

            string[] books =
            {
            "Clean Code",
            "The Pragmatic Programmer",
            "Refactoring"
        };

            for (int i = 0; i < books.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + books[i]);
            }

            
            int j = 0;

            while (j < books.Length)
            {
                Console.WriteLine(books[j]);
                j++;
            }

            
            int count = 0;

            do
            {
                Console.WriteLine("Checking book");
                count++;
            }
            while (count < 3);

           
            foreach (string book in books)
            {
                Console.WriteLine(book);
            }

            
            for (int i = 0; i < books.Length; i++)
            {
                Console.WriteLine(books[i]);

                if (books[i] == "Refactoring")
                {
                    break;
                }
            }

            
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i] == "The Pragmatic Programmer")
                {
                    continue;
                }

                Console.WriteLine(books[i]);
            }

            
            PrintFirstBook(books);
        }
    }
}
