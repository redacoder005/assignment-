using System;
using System.Collections.Generic;
using System.Text;

namespace ReadMoreBooks.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        public List<Book> Books { get; set; } = new();
    }
}