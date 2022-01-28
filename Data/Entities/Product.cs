namespace Data.Entities
{
    public class Product
    {
        public int Id { set; get; }
        public string Code { set; get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Unit Unit{ get; set; }
        public bool Status { get; set; }
    }
}