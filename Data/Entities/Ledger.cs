using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class Ledger
    {
        public string Period { get; set; } = String.Empty;
        public Nullable<DateTime> CloseDate { get; set; }
        public bool IsClosed { get; set; } = false;
        public virtual List<LedgerDetail> LedgerDetails { get; set; }
    }
}