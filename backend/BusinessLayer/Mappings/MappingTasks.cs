using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTOs.Tasks;
using Core.Entities;

namespace BusinessLayer.Mappings
{
    public class MappingTasks : Profile
    {
        public MappingTasks()
        {
            CreateMap<Core.Entities.Task, GetTaskDto>();
            CreateMap<CreateTaskDto, Core.Entities.Task>();
            CreateMap<UpdateTaskDto, Core.Entities.Task>();
        }
    }
}