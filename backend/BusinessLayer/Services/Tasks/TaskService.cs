using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTOs.Tasks;
using EFCore.Repositories.Tasks;
using Core.Entities;

namespace BusinessLayer.Services.Tasks
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _mapper = mapper;
            _taskRepository = taskRepository;
        }

        public async Task<GetTaskDto> CreateTask(CreateTaskDto createTaskDto)
        {
            var task = _mapper.Map<Core.Entities.Task>(createTaskDto);
            var result = await _taskRepository.CreateTask(task);
    
            return _mapper.Map<GetTaskDto>(result);
        }

        public async System.Threading.Tasks.Task DeleteTask(int taskId)
        {
            await _taskRepository.DeleteTask(taskId);
        }

        public async Task<GetTaskDto> GetTask(int taskId)
        {
            var task = await _taskRepository.GetTask(taskId);

            return _mapper.Map<GetTaskDto>(task);
        }

        public async Task<List<GetTaskDto>> GetTasks(int userId)
        {
            var tasks = await _taskRepository.GetTasks(userId);

            return _mapper.Map<List<GetTaskDto>>(tasks);
        }

        public async Task<GetTaskDto> UpdateTask(UpdateTaskDto updateTaskDto)
        {
            var task = await _taskRepository.GetTask(updateTaskDto.Id);
            // task.Text = updateTaskDto.Text;

            // KADA SE DVA OBJEKTA SPAJAJU U JEDAN, ONDA OVAKO - SA DVA ARGUMENTA
            // KADA SE JEDAN OBJEKAT PREPISUJE U DRUGI, ONDA SAMO JEDAN ARGUMENT
            var taskToUpdate = _mapper.Map<UpdateTaskDto, Core.Entities.Task>(updateTaskDto, task);

            var result = await _taskRepository.UpdateTask(taskToUpdate);

            return _mapper.Map<GetTaskDto>(result);
        }

        public async Task<GetTaskDto> UpdateTaskStatus(int taskId)
        {
            var task = await _taskRepository.GetTask(taskId);
            task.Finished = task.Finished ? false : true;

            var result = await _taskRepository.UpdateTask(task);

            return _mapper.Map<GetTaskDto>(result);
        }
    }
}