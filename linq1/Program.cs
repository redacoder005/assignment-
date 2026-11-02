using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            var ProductList = ListGenerators.ProductList;
            var CustomerList = ListGenerators.CustomerList;

            Console.WriteLine("----- Q1 -----");
            var seafood = ProductList.Where(p => p.Category == "Seafood");
            foreach (var p in seafood)
            {
                Console.WriteLine(p.ProductName + " - " + p.UnitPrice);
            }

            Console.WriteLine("----- Q2 -----");
            var names = ProductList.Select(p => p.ProductName);
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("----- Q3 -----");
            var sortedByPrice = ProductList.OrderBy(p => p.UnitPrice);
            foreach (var p in sortedByPrice)
            {
                Console.WriteLine(p.ProductName + " - " + p.UnitPrice);
            }

            Console.WriteLine("----- Q4 -----");
            var between10and30 = ProductList.Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 30);
            foreach (var p in between10and30)
            {
                Console.WriteLine(p.ProductName + " - " + p.UnitPrice);
            }

            Console.WriteLine("----- Q5 -----");
            var condiments = ProductList.Where(p => p.UnitsInStock > 0 && p.Category == "Condiments");
            foreach (var p in condiments)
            {
                Console.WriteLine(p.ProductName + " - Stock: " + p.UnitsInStock);
            }

            Console.WriteLine("----- Q6 -----");
            var stockInfo = ProductList.Select(p => new
            {
                Name = p.ProductName,
                Price = p.UnitPrice,
                StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
            });
            foreach (var item in stockInfo)
            {
                Console.WriteLine(item.Name + " | " + item.Price + " | " + item.StockStatus);
            }

            Console.WriteLine("----- Q7 -----");
            var withPosition = ProductList.Select((p, index) => (index + 1) + ". " + p.ProductName);
            foreach (var line in withPosition)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("----- Q8 -----");
            var sortedProducts = ProductList
                .OrderBy(p => p.Category)
                .ThenByDescending(p => p.UnitPrice);
            foreach (var p in sortedProducts)
            {
                Console.WriteLine(p.Category + " - " + p.ProductName + " - " + p.UnitPrice);
            }

            Console.WriteLine("----- Q9 -----");
            var beverages = ProductList
                .Where(p => p.Category == "Beverages")
                .OrderByDescending(p => p.UnitsInStock);
            foreach (var p in beverages)
            {
                Console.WriteLine(p.ProductName + " - Stock: " + p.UnitsInStock);
            }

            Console.WriteLine("----- Q10 -----");
            var orders1997 = from c in CustomerList
                             from o in c.Orders
                             where o.OrderDate.Year >= 1997
                             select new { c.CustomerID, o.OrderDate };
            foreach (var item in orders1997)
            {
                Console.WriteLine(item.CustomerID + " - " + item.OrderDate);
            }

            Console.WriteLine("----- Q11 -----");
            var numbered = ProductList.Select((p, i) => new { Number = i + 1, p.ProductName });
            foreach (var item in numbered)
            {
                Console.WriteLine(item.Number + " - " + item.ProductName);
            }

            Console.WriteLine("----- Q12 -----");
            string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var sortedWords = Arr
                .OrderBy(w => w.Length)
                .ThenBy(w => w, StringComparer.OrdinalIgnoreCase);
            foreach (var w in sortedWords)
            {
                Console.WriteLine(w);
            }

            Console.WriteLine("----- Q13 -----");
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var result = digits
                .Where(d => d[1] == 'i')
                .Reverse();
            foreach (var d in result)
            {
                Console.WriteLine(d);
            }

            Console.ReadKey();
        }
    }
}
