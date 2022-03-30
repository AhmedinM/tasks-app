using AutoMapper;
using Core.DTOs.Tasks;

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