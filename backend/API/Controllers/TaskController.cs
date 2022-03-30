using BusinessLayer.Services.Tasks;
using Core.DTOs.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TaskController : BaseApiController
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [Authorize(Roles = "User")]
        [HttpGet("one/{taskId}")]
        public async Task<ActionResult<GetTaskDto>> GetTask(int taskId)
        {
            var result = await _taskService.GetTask(taskId);

            return (result == null) ?
                NotFound() :
                Ok(result);
        }

        [Authorize(Roles = "User")]
        [HttpGet("tasks/{listId}")]
        public async Task<ActionResult<List<GetTaskDto>>> GetTasks(int listId)
        {
            var result = await _taskService.GetTasks(listId);

            return (result == null) ?
                NotFound() :
                Ok(result);
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<ActionResult<GetTaskDto>> CreateTask(CreateTaskDto createTaskDto)
        {
            var result = await _taskService.CreateTask(createTaskDto);

            return (result == null) ?
                NotFound() :
                Ok(result);
        }

        [Authorize(Roles = "User")]
        [HttpPut("task/{taskId}")]
        public async Task<ActionResult<string>> UpdateTask(int taskId, UpdateTaskDto updateTaskDto)
        {
            if (taskId != updateTaskDto.Id)
                return BadRequest("IDs are not the same");
            
            var result = await _taskService.UpdateTask(updateTaskDto);
            
            return (result == null) ?
                NotFound() :
                Ok(result);
        }

        [Authorize(Roles = "User")]
        [HttpPut("status/{taskId}")]
        public async Task<ActionResult<GetTaskDto>> UpdateTaskStatus(int taskId)
        {
            var result = await _taskService.UpdateTaskStatus(taskId);
            
            return (result == null) ?
                NotFound() :
                Ok(result);
        }

        [Authorize(Roles = "User")]
        [HttpDelete("{taskId}")]
        public async Task<ActionResult> DeleteList(int taskId)
        {
            await _taskService.DeleteTask(taskId);
            
            return NoContent();
        }
    }
}