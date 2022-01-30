using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class Import
    {
        public int Id { get; set; }
        public string No { get; set; } = String.Empty;
        public DateTime Date { get; set; } = DateTime.Now;

        public List<ImportDetial> ImportDetails { get; set; }
    }
}