using System;
using System.Collections.Generic;

namespace LinqAssignment
{
    public static class ListGenerators
    {
        public static List<Product> ProductList { get; } = new()
        {
            new Product("Chai", "Beverages", 18.00m, 39),
            new Product("Chang", "Beverages", 19.00m, 17),
            new Product("Aniseed Syrup", "Condiments", 10.00m, 13),
            new Product("Chef Anton's Cajun Seasoning", "Condiments", 22.00m, 53),
            new Product("Grandma's Boysenberry Spread", "Condiments", 25.00m, 120),
            new Product("Ikura", "Seafood", 31.00m, 31),
            new Product("Konbu", "Seafood", 6.00m, 24),
            new Product("Carnarvon Tigers", "Seafood", 62.50m, 42)
        };

        public static List<Customer> CustomerList { get; } = new()
        {
            new Customer("ALFKI", new List<Order>
            {
                new Order(new DateTime(1996, 7, 4)),
                new Order(new DateTime(1997, 1, 15))
            }),
            new Customer("ANATR", new List<Order>
            {
                new Order(new DateTime(1997, 5, 6))
            }),
            new Customer("ANTON", new List<Order>
            {
                new Order(new DateTime(1996, 11, 12))
            })
        };
    }

    public sealed class Product
    {
        public Product(string productName, string category, decimal unitPrice, int unitsInStock)
        {
            ProductName = productName;
            Category = category;
            UnitPrice = unitPrice;
            UnitsInStock = unitsInStock;
        }

        public string ProductName { get; }
        public string Category { get; }
        public decimal UnitPrice { get; }
        public int UnitsInStock { get; }
    }

    public sealed class Customer
    {
        public Customer(string customerId, List<Order> orders)
        {
            CustomerID = customerId;
            Orders = orders;
        }

        public string CustomerID { get; }
        public List<Order> Orders { get; }
    }

    public sealed class Order
    {
        public Order(DateTime orderDate)
        {
            OrderDate = orderDate;
        }

        public DateTime OrderDate { get; }
    }
}
