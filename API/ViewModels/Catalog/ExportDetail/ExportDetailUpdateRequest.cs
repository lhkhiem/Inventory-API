using System;

namespace API.ViewModels.Catalog.ExportDetails
{
    public class ExportDetailUpdateRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }

    }
}
