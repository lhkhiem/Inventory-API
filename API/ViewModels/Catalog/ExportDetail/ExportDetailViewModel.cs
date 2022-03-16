using Data.Entities;
using System;
using System.Collections.Generic;

namespace API.ViewModels.Catalog.ExportDetails
{
    public class ExportDetailViewModel
    {
        public int ExportId { get; set; }
        public Product Products { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }

        
    }
}
