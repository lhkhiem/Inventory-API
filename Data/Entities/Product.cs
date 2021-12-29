using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inventory.Data.Entities
{
    public class Product
    {
        public Guid Id { set; get; }
        public string Code { set; get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Guid Unit { get; set; }
        public bool Status { get; set; }
    }
}