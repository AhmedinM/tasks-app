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
            CreateMap<GetTaskDto, Core.Entities.Task>();
            CreateMap<Core.Entities.Task, CreateTaskDto>();
            CreateMap<CreateTaskDto, Core.Entities.Task>();
                
            // CreateMap<Core.Entities.Task, UpdateTaskDto>();
            CreateMap<UpdateTaskDto, Core.Entities.Task>();
        }
    }
}