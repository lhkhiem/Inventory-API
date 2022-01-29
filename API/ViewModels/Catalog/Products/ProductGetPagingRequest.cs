using API.ViewModels.Common;

namespace API.ViewModels.Catalog.Products
{
    public class ProductGetPagingRequest:PagingRequest
    {
        public string Keyword { get; set; }
        public int CategoryId { get; set; }
    }
}
