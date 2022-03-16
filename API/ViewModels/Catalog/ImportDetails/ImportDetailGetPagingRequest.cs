using API.ViewModels.Common;

namespace API.ViewModels.Catalog.ImportDetails
{
    public class ImportDetailGetPagingRequest:PagingRequest
    {
        public string Keyword { get; set; }
    }
}
