namespace assignment_11
{
    using System;
    using System.Collections.Generic;

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }

    class Program
    {
        static List<Product> SearchProducts(
            List<Product> products,
            Func<Product, bool> filter)
        {
            List<Product> result = new List<Product>();

            foreach (Product product in products)
            {
                if (filter(product))
                {
                    result.Add(product);
                }
            }

            return result;
        }

        static void PrintProducts(List<Product> products)
        {
            foreach (Product product in products)
            {
                Console.WriteLine(
                    product.Name + " - $" + product.Price +
                    " (Stock: " + product.Stock + ")"
                );
            }
        }

        static void PrintReport(
            List<Product> products,
            Action<Product> action)
        {
            foreach (Product product in products)
            {
                action(product);
            }
        }

        static List<string> TransformProducts(
            List<Product> products,
            Func<Product, string> function)
        {
            List<string> result = new List<string>();

            foreach (Product product in products)
            {
                result.Add(function(product));
            }

            return result;
        }

        static List<Product> FilterProducts(
            List<Product> products,
            Predicate<Product> predicate)
        {
            List<Product> result = new List<Product>();

            foreach (Product product in products)
            {
                if (predicate(product))
                {
                    result.Add(product);
                }
            }

            return result;
        }

        static void Main()
        {
            List<Product> catalog = new List<Product>()
        {
            new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 1200, Stock = 10 },
            new Product { Id = 2, Name = "Phone", Category = "Electronics", Price = 800, Stock = 25 },
            new Product { Id = 3, Name = "T-Shirt", Category = "Clothing", Price = 30, Stock = 100 },
            new Product { Id = 4, Name = "Jeans", Category = "Clothing", Price = 60, Stock = 50 },
            new Product { Id = 5, Name = "Chocolate", Category = "Food", Price = 5, Stock = 200 },
            new Product { Id = 6, Name = "Coffee Beans", Category = "Food", Price = 15, Stock = 80 },
            new Product { Id = 7, Name = "C# Book", Category = "Books", Price = 45, Stock = 30 },
            new Product { Id = 8, Name = "Novel", Category = "Books", Price = 20, Stock = 60 },
            new Product { Id = 9, Name = "Headphones", Category = "Electronics", Price = 150, Stock = 40 },
            new Product { Id = 10, Name = "Jacket", Category = "Clothing", Price = 120, Stock = 15 }
        };

            Console.WriteLine("--- Electronics ---");

            List<Product> electronics = SearchProducts(
                catalog,
                p => p.Category == "Electronics"
            );

            PrintProducts(electronics);


            Console.WriteLine();
            Console.WriteLine("--- Under $50 ---");

            List<Product> under50 = SearchProducts(
                catalog,
                p => p.Price < 50
            );

            PrintProducts(under50);


            Console.WriteLine();
            Console.WriteLine("--- In Stock ---");

            List<Product> inStock = SearchProducts(
                catalog,
                p => p.Stock > 0
            );

            PrintProducts(inStock);


            Console.WriteLine();
            Console.WriteLine("--- Clothing Under $100 ---");

            List<Product> clothing = SearchProducts(
                catalog,
                p => p.Category == "Clothing" && p.Price < 100
            );

            PrintProducts(clothing);


            Console.WriteLine();
            Console.WriteLine("--- Short Report ---");

            PrintReport(
                catalog,
                p => Console.WriteLine(p.Name + " - $" + p.Price)
            );


            Console.WriteLine();
            Console.WriteLine("--- Detailed Report ---");

            PrintReport(
                catalog,
                p => Console.WriteLine(
                    "[" + p.Category + "] " +
                    p.Name +
                    " | Price: $" + p.Price +
                    " | Stock: " + p.Stock
                )
            );


            Console.WriteLine();
            Console.WriteLine("--- Summary List ---");

            List<string> summary = TransformProducts(
                catalog,
                p => p.Name + " ($" + p.Price + ")"
            );

            foreach (string item in summary)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine();
            Console.WriteLine("--- Price Labels ---");

            List<string> priceLabels = TransformProducts(
                catalog,
                p =>
                {
                    if (p.Price > 100)
                    {
                        return p.Name + ": Expensive!";
                    }
                    else
                    {
                        return p.Name + ": Affordable";
                    }
                }
            );

            foreach (string item in priceLabels)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine();
            Console.WriteLine("--- Low Stock ---");

            List<Product> lowStock = FilterProducts(
                catalog,
                p => p.Stock < 20
            );

            foreach (Product product in lowStock)
            {
                Console.WriteLine(
                    "[LOW STOCK] " +
                    product.Name +
                    ": only " +
                    product.Stock +
                    " left!"
                );
            }
        }
    }
}
