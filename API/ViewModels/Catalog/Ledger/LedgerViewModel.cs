using System;

namespace API.ViewModels.Catalog.Ledger
{
    public class LedgerViewModel
    {
        public string Period { get; set; }
        public Nullable<DateTime> CloseDate { get; set; }
        public bool IsClosed { get; set; }
    }
}
