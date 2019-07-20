using System;
using System.Collections.Generic;

namespace EasyPort.Models.EasyPortData
{
    public partial class Company
    {
        public Company()
        {
            AspNetUsers = new HashSet<AspNetUsers>();
            SalesMaster = new HashSet<SalesMaster>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Logo { get; set; }
        public string Date { get; set; }
        public Guid UploadKey { get; set; }

        public virtual ICollection<AspNetUsers> AspNetUsers { get; set; }
        public virtual ICollection<SalesMaster> SalesMaster { get; set; }
    }
}
