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
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
           CreateMap<Product,ProductDTO>();

            CreateMap<UpdateProductDto, Product>();
        }
    }
}
