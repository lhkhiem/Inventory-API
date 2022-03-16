using API.ViewModels.Common;

namespace API.ViewModels.Catalog.Imports
{
    public class ImportGetPagingRequest: PagingRequest
    {
        public string Keyword { get; set; }
    }
}
