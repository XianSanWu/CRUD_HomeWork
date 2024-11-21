using System;
using System.Collections.Generic;

#nullable disable

namespace CRUD_HomeWork.Models.DBEntity
{
    public partial class ProductsAboveAveragePrice
    {
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
