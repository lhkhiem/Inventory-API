using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public List<Product> Products { get; set; }
    }
}
