namespace assignment_3
{
    internal class Program
    {
        static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to the Library!");
        }


        static void PrintBookTitle(string title)
        {
            Console.WriteLine("Book title: " + title);
        }


        static void AddBonusPages(int pages)
        {
            pages = pages + 50;
        }


        static void ApplyDiscount(double[] prices)
        {
            prices[0] = prices[0] - 5;
        }

        static void AddBonusPagesByRef(ref int pages)
        {
            pages = pages + 50;
        }

        static void ReplaceArray(ref double[] prices)
        {
            prices = new double[] { 10.0, 12.5, 15.0 };
        }


        static bool TryGetPrice(string title, out double price)
        {
            if (title == "Clean Code")
            {
                price = 25.5;
                return true;
            }
            else
            {
                price = 0;
                return false;
            }
        }


        static void PrintBookInfo(string title, int pages = 300)
        {
            Console.WriteLine("Title: " + title);
            Console.WriteLine("Pages: " + pages);
        }


        static void PrintAllTitles(params string[] titles)
        {
            foreach (string title in titles)
            {
                Console.WriteLine(title);
            }
        }

        static void Main(string[] args)
        {

            double[] prices = { 25.5, 40.0, 33.75 };

            Console.WriteLine(prices[1]);



            int[,] shelfCopies =
            {
            { 3, 5 },
            { 1, 4 }
        };

            Console.WriteLine(shelfCopies[1, 0]);


            PrintWelcomeMessage();


            PrintBookTitle("Clean Code");


            int pages = 400;

            AddBonusPages(pages);

            Console.WriteLine(pages);




            double[] bookPrices = { 25.5, 40.0 };

            ApplyDiscount(bookPrices);

            Console.WriteLine(bookPrices[0]);



            AddBonusPagesByRef(ref pages);

            Console.WriteLine(pages);




            ReplaceArray(ref bookPrices);

            Console.WriteLine(bookPrices.Length);


            double price;

            bool found = TryGetPrice("Clean Code", out price);

            if (found)
            {
                Console.WriteLine(price);
            }


            
            PrintBookInfo("Clean Code");

            PrintBookInfo("The Pragmatic Programmer", 352);


           
            PrintBookInfo(pages: 464, title: "Refactoring");


           
            PrintAllTitles("Clean Code", "Refactoring", "The Pragmatic Programmer");
        }
    }
}

       
 
