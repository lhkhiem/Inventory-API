using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Export
    {
        public int Id { get; set; }
        public string No { get; set; } = String.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
        public List<ExportDetail> ExportDetails { get; set; }
    }
}
