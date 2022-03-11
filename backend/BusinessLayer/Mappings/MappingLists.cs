using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTOs.Lists;
using Core.Entities;

namespace BusinessLayer.Mappings
{
    public class MappingLists : Profile
    {
        public MappingLists()
        {
            CreateMap<List, GetListDto>();
            CreateMap<GetListDto, List>();
            CreateMap<List, CreateListDto>();
            CreateMap<CreateListDto, List>();
            CreateMap<UpdateListDto, List>();
        }
    }
}