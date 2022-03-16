using Data.Entities;
using System;

namespace API.ViewModels.Catalog.ExportDetails
{
    public class ExportDetailCreateRequest
    {
        public int ExportId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }

    }
}
