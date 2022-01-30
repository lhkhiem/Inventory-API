using API.ViewModels.Common;

namespace API.ViewModels.Catalog.Categories
{
    public class CategoryGetPagingRequest:PagingRequest
    {
        public string Keyword { get; set; }
    }
}
