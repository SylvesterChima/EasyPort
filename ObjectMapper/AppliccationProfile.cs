using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyPort.ObjectMapper
{
    public class AppliccationProfile: Profile
    {
        public AppliccationProfile()
        {
            //CreateMap<SalesMaster, SalesMasterRequest>().ReverseMap()
            //    .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerPhoneNumber));

            //CreateMap<SalesItem, SalesItemRequest>().ReverseMap();
        }
    }
}
