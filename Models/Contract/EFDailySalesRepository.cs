using EasyPort.Models.Abstract;
using EasyPort.Models.EasyPortData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyPort.Models.Contract
{
    public class EFDailySalesRepository : GenericRepository<DailySales>, IDailySalesRepository
    {
        public EFDailySalesRepository(EFDbContext context) : base(context)
        {

        }
    }
}
