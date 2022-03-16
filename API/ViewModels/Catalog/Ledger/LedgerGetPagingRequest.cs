using API.ViewModels.Common;

namespace API.ViewModels.Catalog.Ledger
{
    public class LedgerGetPagingRequest: PagingRequest
    {
        public string Keyword { get; set; }
    }
}
