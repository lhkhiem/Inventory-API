using Inventory.Data.Entities;
using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class Unit
    {
        public byte Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public List<Product> Products { get; set; }
    }
}
