using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTOs.Users;
using Core.Entities;

namespace BusinessLayer.Mappings
{
    public class MappingUsers : Profile
    {
        public MappingUsers()
        {
            CreateMap<User, GetUserDto>();
            // CreateMap<GetUserDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}