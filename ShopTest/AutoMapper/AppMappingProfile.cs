using AutoMapper;
using ShopTest.Data.Entities;
using ShopTest.Models;
using System;

namespace ShopTest.AutoMapper
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Client, ClientDto>();               
        }
    }
}
