using Data.Entities;

namespace API.ViewModels.Catalog.ImportDetails
{
    public class ImportDetailViewModel
    {
        public int ImportId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }

    }
}
