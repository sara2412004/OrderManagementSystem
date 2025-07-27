using AutoMapper;
using Domain.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MappingProfiles
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            
            CreateMap<Order,OrderDto>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.OrderItems));
        }
    }
}
