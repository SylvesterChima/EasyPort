using EasyPort.Models.EasyPortData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyPort.Models
{
    public class DailySalesModel
    {
        public int CompanyId { get; set; }
        public string ProductName { get; set; }
        public string ProductId { get; set; }
        public int Quntity { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalAmount { get; set; }
        public virtual Company Company { get; set; }
    }
}
