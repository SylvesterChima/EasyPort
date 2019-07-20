using System;
using System.Collections.Generic;

namespace EasyPort.Models.EasyPortData
{
    public partial class SalesItems
    {
        public int Id { get; set; }
        public int SalesMasterId { get; set; }
        public long SalesId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal QtySold { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SalesVat { get; set; }
        public decimal Discount { get; set; }
        public decimal SalesDiscount { get; set; }
        public decimal CostPrice { get; set; }
        public DateTime? Date { get; set; }
        public bool IsDeleted { get; set; }

        public virtual SalesMaster SalesMaster { get; set; }
    }
}
