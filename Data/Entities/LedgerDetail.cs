namespace Data.Entities
{
    public class LedgerDetail
    {
        public string LedgerId { get; set; }
        public int ProductId { get; set; }
        public int Opening { get; set; }
        public int Ending { get; set; }

        public virtual Ledger Ledger { get; set; }
        public virtual Product Product { get; set; }
    }
}