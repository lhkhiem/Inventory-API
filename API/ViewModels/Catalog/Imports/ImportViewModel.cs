using Data.Entities;
using System;
using System.Collections.Generic;

namespace API.ViewModels.Catalog.Imports
{
    public class ImportViewModel
    {
        public int Id { get; set; }
        public string No { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
