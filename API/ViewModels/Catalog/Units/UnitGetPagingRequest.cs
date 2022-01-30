using API.ViewModels.Common;

namespace API.ViewModels.Catalog.Units
{
    public class UnitGetPagingRequest : PagingRequest
    {
        public string Keyword { get; set; }
    }
}
