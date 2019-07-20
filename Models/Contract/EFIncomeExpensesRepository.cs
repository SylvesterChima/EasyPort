using EasyPort.Models.Abstract;
using EasyPort.Models.EasyPortData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyPort.Models.Contract
{
    public class EFIncomeExpensesRepositroy : GenericRepository<IncomeExpenses>, IIncomeExpensesRepository
    {
        public EFIncomeExpensesRepositroy(EFDbContext context) : base(context)
        {

        }
    }
}
