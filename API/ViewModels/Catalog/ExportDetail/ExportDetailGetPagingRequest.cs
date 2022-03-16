using API.ViewModels.Common;

namespace API.ViewModels.Catalog.ExportDetails
{
    public class ExportDetailGetPagingRequest: PagingRequest
    {
        public string Keyword { get; set; }
    }
}
