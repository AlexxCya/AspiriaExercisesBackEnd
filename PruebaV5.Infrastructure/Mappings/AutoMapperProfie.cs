using AutoMapper;
using PruebaV5.Core.DTOs;
using PruebaV5.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaV5.Infrastructure.Mappings
{
    public class AutoMapperProfie : Profile
    {
        public AutoMapperProfie()
        {
            CreateMap<Toy, ToyDto>().ReverseMap();
        }
    }
}
