using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Services.Tasks;
using Core.DTOs.Tasks;
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

        [HttpGet("one/{taskId}")]
        public async Task<ActionResult<GetTaskDto>> GetTask(int taskId)
        {
            return await _taskService.GetTask(taskId);
        }

        [HttpGet("tasks/{listId}")]
        public async Task<ActionResult<List<GetTaskDto>>> GetTasks(int listId)
        {
            return await _taskService.GetTasks(listId);
        }

        [HttpPost]
        public async Task<ActionResult<GetTaskDto>> CreateTask(CreateTaskDto createTaskDto)
        {
            return await _taskService.CreateTask(createTaskDto);
        }

        [HttpPut("task/{taskId}")]
        public async Task<ActionResult<string>> UpdateTask(int taskId, UpdateTaskDto updateTaskDto)
        {
            if (taskId != updateTaskDto.Id) return BadRequest("IDs are not the same");
            
            var task = await _taskService.UpdateTask(updateTaskDto);
            return Ok(task);
        }

        [HttpPut("status/{taskId}")]
        public async Task<ActionResult<GetTaskDto>> UpdateTaskStatus(int taskId)
        {
            var task = await _taskService.UpdateTaskStatus(taskId);
            return Ok(task);
        }

        [HttpDelete("{taskId}")]
        public async Task<ActionResult> DeleteList(int taskId)
        {
            await _taskService.DeleteTask(taskId);
            return NoContent();
        }
    }
}