using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class Ledger
    {
        public string Period { get; set; } = String.Empty;
        public DateTime CloseDate { get; set; }
        public virtual List<LedgerDetail> LedgerDetails { get; set; }
    }
}