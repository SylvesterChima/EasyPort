using EasyPort.Models.Abstract;
using EasyPort.Models.EasyPortData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyPort.Models.Contract
{
    public class EFCompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public EFCompanyRepository(EFDbContext context) : base(context)
        {

        }
    }
}
