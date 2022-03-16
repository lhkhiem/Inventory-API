using Data.Entities;
using System;
using System.Collections.Generic;

namespace API.ViewModels.Catalog.Exports
{
    public class ExportViewModel
    {
        public int Id { get; set; }
        public string No { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
