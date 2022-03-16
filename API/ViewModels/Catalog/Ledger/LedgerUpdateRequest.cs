using System;

namespace API.ViewModels.Catalog.Ledger
{
    public class LedgerUpdateRequest
    {
        public Nullable<DateTime> CloseDate { get; set; }
        public bool IsClosed { get; set; }
    }
}
