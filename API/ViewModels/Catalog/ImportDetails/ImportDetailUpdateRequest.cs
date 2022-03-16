namespace API.ViewModels.Catalog.ImportDetails
{
    public class ImportDetailUpdateRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }
    }
}
