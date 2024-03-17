using APITest.Application.DTO;
using APITest.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Application.Mapper
{
    public class AutMapperProfile : Profile
    {
        public AutMapperProfile()
        {
            CreateMap<ApplicationUserDTO, UserMaster>();
            CreateMap<UserMaster, ApplicationUserDTO>();

            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();
        }
    }
}
