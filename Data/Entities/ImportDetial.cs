using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class ImportDetial
    {
        public int ImporttId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }

        public virtual Import Import { get; set; }
    }
}
