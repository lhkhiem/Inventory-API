﻿namespace API.ViewModels.Catalog.ImportDetails
{
    public class ImportDetailCreateRequest
    {
        public int ImportId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }
    }
}