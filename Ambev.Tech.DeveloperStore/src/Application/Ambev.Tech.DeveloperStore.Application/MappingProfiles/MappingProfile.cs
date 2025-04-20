using Ambev.Tech.DeveloperStore.Application.Auth.Dto;
using Ambev.Tech.DeveloperStore.Application.Carts.Dto;
using Ambev.Tech.DeveloperStore.Application.Products.Dto;
using Ambev.Tech.DeveloperStore.Application.Users.Dto;
using Ambev.Tech.DeveloperStore.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Tech.DeveloperStore.Application.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapear entre as entidades e DTOs
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Cart, CartDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<AuthToken, AuthTokenDto>().ReverseMap();
        }
    }
}
