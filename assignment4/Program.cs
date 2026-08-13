namespace assignment4
{
    class Book
    {
        private string password = "secret";

        internal int copiesInStock = 5;

        public string Title;

        public Genre Genre;
    }

    enum Genre
    {
        Fiction,
        NonFiction,
        Science
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book();

            


            
            Console.WriteLine(book.copiesInStock);
           


          
            book.Title = "Clean Code";
            Console.WriteLine(book.Title);


            
            book.Genre = Genre.Science;
            Console.WriteLine(book.Genre);


            
            Console.WriteLine((int)Genre.Fiction);
            Console.WriteLine((int)Genre.NonFiction);
            Console.WriteLine((int)Genre.Science);


            
            int genreNumber = 1;

            Genre genre1 = (Genre)genreNumber;

            Console.WriteLine(genre1);


            
            Genre genre = Genre.Fiction;

            string genreString = genre.ToString();

            Console.WriteLine(genreString);


            
            string genreText = "Science";

            Genre genre2 = (Genre)Enum.Parse(typeof(Genre), genreText);

            Console.WriteLine(genre2);


            
            string genreText2 = "Mystery";

            Genre genre3;

            if (Enum.TryParse(genreText2, out genre3))
            {
                Console.WriteLine(genre3);
            }
            else
            {
                Console.WriteLine("Unknown genre");
            }
        }
    }
}
