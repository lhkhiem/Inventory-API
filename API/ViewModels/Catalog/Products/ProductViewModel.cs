using Data.Entities;

namespace API.ViewModels.Catalog.Products
{
    public class ProductViewModel
    {
        public int Id { set; get; }
        public string Code { set; get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Unit Unit { get; set; }
        public Category Category { get; set; }
        public bool Status { get; set; }
    }
}
