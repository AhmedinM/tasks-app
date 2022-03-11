using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs.Tasks;
using Core.Entities;

namespace EFCore.Repositories.Tasks
{
    public interface ITaskRepository
    {
        Task<List<Core.Entities.Task>> GetTasks(int listId);
        Task<Core.Entities.Task> CreateTask(Core.Entities.Task task);
        Task<Core.Entities.Task> UpdateTask(Core.Entities.Task task);
        System.Threading.Tasks.Task DeleteTask(int taskId);
        Task<Core.Entities.Task> GetTask(int taskId);
    }
}