using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyPort.Models.EasyPortData
{
    public partial class DailySales
    {
        public int DailySalesId { get; set; }
        public int CompanyId { get; set; }
        public string ProductName { get; set; }
        public long BatchNo { get; set; }
        public int Quntity { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime DateSold { get; set; }
        public DateTime EntryDate { get; set; }
        public virtual Company Company { get; set; }
    }
}
