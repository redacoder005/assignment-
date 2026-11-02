using System;
using System.Collections.Generic;

namespace LinqAssignment
{
    public static class ListGenerators
    {
        public static List<Product> ProductList { get; } = new()
        {
            new Product(1, "Chai", "Beverages", 18.00m, 39),
            new Product(2, "Chang", "Beverages", 19.00m, 17),
            new Product(3, "Aniseed Syrup", "Condiments", 10.00m, 13),
            new Product(4, "Chef Anton's Cajun Seasoning", "Condiments", 22.00m, 53),
            new Product(5, "Grandma's Boysenberry Spread", "Condiments", 25.00m, 0),
            new Product(6, "Ikura", "Seafood", 31.00m, 24),
            new Product(7, "Konbu", "Seafood", 6.00m, 24),
            new Product(8, "Carnarvon Tigers", "Seafood", 62.50m, 42),
            new Product(9, "Mishi Kobe Niku", "Meat/Poultry", 97.00m, 29),
            new Product(10, "Tofu", "Produce", 23.25m, 35)
        };

        public static List<Customer> CustomerList { get; } = new()
        {
            new Customer
            {
                CustomerID = "ALFKI",
                CompanyName = "Alfreds Futterkiste",
                Country = "Germany",
                Orders = new List<Order>
                {
                    new Order { OrderDate = new DateTime(1996, 7, 4), Total = 100.00m },
                    new Order { OrderDate = new DateTime(1997, 8, 1), Total = 250.00m }
                }
            },
            new Customer
            {
                CustomerID = "ANATR",
                CompanyName = "Ana Trujillo Emparedados y helados",
                Country = "Mexico",
                Orders = new List<Order>
                {
                    new Order { OrderDate = new DateTime(1997, 10, 15), Total = 175.00m }
                }
            },
            new Customer
            {
                CustomerID = "ANTON",
                CompanyName = "Antonio Moreno Taquería",
                Country = "Mexico",
                Orders = new List<Order>
                {
                    new Order { OrderDate = new DateTime(1996, 11, 12), Total = 225.00m }
                }
            }
        };
    }

    public sealed class Product
    {
        public Product(int productID, string productName, string category, decimal unitPrice, int unitsInStock)
        {
            ProductID = productID;
            ProductName = productName;
            Category = category;
            UnitPrice = unitPrice;
            UnitsInStock = unitsInStock;
        }

        public int ProductID { get; }
        public string ProductName { get; }
        public string Category { get; }
        public decimal UnitPrice { get; }
        public int UnitsInStock { get; }
    }

    public sealed class Customer
    {
        public string CustomerID { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public List<Order> Orders { get; set; } = new();
    }

    public sealed class Order
    {
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }
    }
}
