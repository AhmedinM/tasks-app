using AutoMapper;
using Core.DTOs.Tasks;
using EFCore.Repositories.Tasks;

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
            return _mapper.Map<GetTaskDto>(await _taskRepository.CreateTask(_mapper.Map<Core.Entities.Task>(createTaskDto)));
        }

        public async System.Threading.Tasks.Task DeleteTask(int taskId)
        {
            await _taskRepository.DeleteTask(taskId);
        }

        public async Task<GetTaskDto> GetTask(int taskId)
        {
            return _mapper.Map<GetTaskDto>(await _taskRepository.GetTask(taskId));
        }

        public async Task<List<GetTaskDto>> GetTasks(int userId)
        {
            return _mapper.Map<List<GetTaskDto>>(await _taskRepository.GetTasks(userId));
        }

        public async Task<GetTaskDto> UpdateTask(UpdateTaskDto updateTaskDto)
        {
            var task = await _taskRepository.GetTask(updateTaskDto.Id);

            // KADA SE DVA OBJEKTA SPAJAJU U JEDAN, ONDA OVAKO - SA DVA ARGUMENTA
            // KADA SE JEDAN OBJEKAT PREPISUJE U DRUGI, ONDA SAMO JEDAN ARGUMENT

            return _mapper.Map<GetTaskDto>(await _taskRepository.UpdateTask(_mapper.Map<UpdateTaskDto, Core.Entities.Task>(updateTaskDto, task)));
        }

        public async Task<GetTaskDto> UpdateTaskStatus(int taskId)
        {
            var task = await _taskRepository.GetTask(taskId);
            task.Finished = !task.Finished;

            return _mapper.Map<GetTaskDto>(await _taskRepository.UpdateTask(task));
        }
    }
}