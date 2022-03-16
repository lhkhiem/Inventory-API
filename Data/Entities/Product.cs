using System.Collections.Generic;

namespace Data.Entities
{
    public class Product
    {
        public int Id { set; get; }
        public string Code { set; get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int UnitId { get; set; }
        public int CategoryId { get; set; }
        public bool Status { get; set; }

        virtual public Unit Unit { get; set; }
        virtual public Category Category { get; set; }
        virtual public List<LedgerDetail> LedgerDetails {get;set;}
        virtual public List<ImportDetail> ImportDetials { get; set; }
        virtual public List<ExportDetail> ExportDetials { get; set; }

    }
}