namespace API.ViewModels.Catalog.Products
{
    public class ProductCreateRequest
    {
        public string Code { set; get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public byte UnitId { get; set; }
        public byte CategoryId { get; set; }
    }
}