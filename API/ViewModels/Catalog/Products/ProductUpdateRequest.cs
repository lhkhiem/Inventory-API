namespace API.ViewModels.Catalog.Products
{
    public class ProductUpdateRequest
    {
        public int Id { get; set; }
        public string Code { set; get; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
