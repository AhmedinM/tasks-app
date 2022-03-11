using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs.Tasks;

namespace BusinessLayer.Services.Tasks
{
    public interface ITaskService
    {
        Task<List<GetTaskDto>> GetTasks(int userId);
        Task<GetTaskDto> CreateTask(CreateTaskDto createTaskDto);
        Task<GetTaskDto> UpdateTask(UpdateTaskDto updateTaskDto);
        Task DeleteTask(int taskId);
        Task<GetTaskDto> UpdateTaskStatus(int taskId);
        Task<GetTaskDto> GetTask(int taskId);
    }
}