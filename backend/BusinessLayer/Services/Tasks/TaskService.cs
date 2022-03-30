using AutoMapper;
using Core.DTOs.Tasks;
using EFCore.Repositories.Tasks;
using EFCore.Repositories.UnitOfWork;

namespace BusinessLayer.Services.Tasks
{
    public class TaskService : ITaskService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public TaskService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetTaskDto> CreateTask(CreateTaskDto createTaskDto)
        {
            return _mapper.Map<GetTaskDto>(await _unitOfWork.TaskRepository.CreateTask(_mapper.Map<Core.Entities.Task>(createTaskDto)));
        }

        public async System.Threading.Tasks.Task DeleteTask(int taskId)
        {
            await _unitOfWork.TaskRepository.DeleteTask(taskId);
        }

        public async Task<GetTaskDto> GetTask(int taskId)
        {
            return _mapper.Map<GetTaskDto>(await _unitOfWork.TaskRepository.GetTask(taskId));
        }

        public async Task<List<GetTaskDto>> GetTasks(int userId)
        {
            return _mapper.Map<List<GetTaskDto>>(await _unitOfWork.TaskRepository.GetTasks(userId));
        }

        public async Task<GetTaskDto> UpdateTask(UpdateTaskDto updateTaskDto)
        {
            var task = await _unitOfWork.TaskRepository.GetTask(updateTaskDto.Id);

            // KADA SE DVA OBJEKTA SPAJAJU U JEDAN, ONDA OVAKO - SA DVA ARGUMENTA
            // KADA SE JEDAN OBJEKAT PREPISUJE U DRUGI, ONDA SAMO JEDAN ARGUMENT

            return _mapper.Map<GetTaskDto>(await _unitOfWork.TaskRepository.UpdateTask(_mapper.Map<UpdateTaskDto, Core.Entities.Task>(updateTaskDto, task)));
        }

        public async Task<GetTaskDto> UpdateTaskStatus(int taskId)
        {
            var task = await _unitOfWork.TaskRepository.GetTask(taskId);
            task.Finished = !task.Finished;

            return _mapper.Map<GetTaskDto>(await _unitOfWork.TaskRepository.UpdateTask(task));
        }
    }
}