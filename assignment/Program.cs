namespace assignment
{
    class Book
    {
        public string Title;
        public int Pages;
    }
    internal class Program
    {
    

        
            static void Main(string[] args)
            {
                
                Book book = new Book();
                book.Title = "C# Programming";
                book.Pages = 464;

                object obj = book;
                Console.WriteLine(obj);

                
                Console.WriteLine(book.ToString());
                Console.WriteLine(book.Equals(book));
                Console.WriteLine(book.GetHashCode());
                Console.WriteLine(book.GetType());


                int pages = 464;
                Console.WriteLine(pages);

                
               
                
                int pagesNumber = 300;
                double pagesDouble = pagesNumber;

                Console.WriteLine(pagesDouble);

               
                double price = 49.99;
                int newPrice = (int)price;

                Console.WriteLine(newPrice);

             
                string pagesText = "464";
                int pageCount = Convert.ToInt32(pagesText);

                Console.WriteLine(pageCount);

                string yearText = "2023";
                int year = int.Parse(yearText);

                Console.WriteLine(year);

                string badText = "abc";

                if (int.TryParse(badText, out int value))
                {
                    Console.WriteLine(value);
                }
                else
                {
                    Console.WriteLine("Invalid number");
                }

                int bookPages = 464;
                string pagesString = bookPages.ToString();

                Console.WriteLine(pagesString);
                Console.WriteLine(pagesString.GetType());

                
                int copies = 100;

                object boxed = copies;

                int unboxed = (int)boxed;

                Console.WriteLine(boxed);
                Console.WriteLine(unboxed);

               
                int? publishYear = null;

                Console.WriteLine(publishYear.HasValue);

                publishYear = 2023;

                Console.WriteLine(publishYear.HasValue);
                Console.WriteLine(publishYear);

             
                string? reviewer = null;

                Console.WriteLine(reviewer == null);

                
                Book? book2 = null;

                string? title = book2?.Title;

                Console.WriteLine(title);

                Console.WriteLine(title ?? "Untitled");

                title ??= "Untitled";

                Console.WriteLine(title);

                
                string? name = "Ahmed";

                string confirmedName = name!;

                Console.WriteLine(confirmedName);
            }
        }
    }
