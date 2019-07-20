using System;
using System.Collections.Generic;

namespace EasyPort.Models.EasyPortData
{
    public partial class SalesMaster
    {
        public SalesMaster()
        {
            SalesItems = new HashSet<SalesItems>();
        }

        public int Id { get; set; }
        public int CompanyId { get; set; }
        public long SalesId { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string StaffId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountTendered { get; set; }
        public decimal Vat { get; set; }
        public decimal TotalDiscount { get; set; }
        public DateTime DateSold { get; set; }
        public string PaymentType { get; set; }
        public string Tcost { get; set; }
        public string Department { get; set; }
        public DateTime DateEntered { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateUploaded { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<SalesItems> SalesItems { get; set; }
    }
}
