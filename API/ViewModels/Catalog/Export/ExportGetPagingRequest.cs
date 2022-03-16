using API.ViewModels.Common;

namespace API.ViewModels.Catalog.Exports
{
    public class ExportGetPagingRequest: PagingRequest
    {
        public string Keyword { get; set; }
    }
}
