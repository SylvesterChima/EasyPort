using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyPort.Models.EasyPortData
{
    public partial class IncomeExpenses
    {
        public int IncomeExpensesId { get; set; }
        public int CompanyId { get; set; }
        public long BatchNo { get; set; }
        public decimal TotalCost { get; set; }
        public decimal Amount { get; set; }
        public bool IsIncome { get; set; }
        public string TransactionType { get; set; }
        public string Purpose { get; set; }
        public DateTime Date { get; set; }
        public DateTime EntryDate { get; set; }
        public virtual Company Company { get; set; }
    }
}
