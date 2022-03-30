using EFCore.Context;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Repositories.Tasks
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DataContext _context;
        public TaskRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Core.Entities.Task> CreateTask(Core.Entities.Task task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();

            return task;
        }

        public async System.Threading.Tasks.Task DeleteTask(int taskId)
        {
            var task = await GetTask(taskId);

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }

        public async Task<Core.Entities.Task> GetTask(int taskId)
        {
            return await _context.Tasks.SingleOrDefaultAsync(t => t.Id == taskId);
        }

        public async Task<List<Core.Entities.Task>> GetTasks(int listId)
        {
            return await _context.Tasks.Where(t => t.ListId == listId).OrderByDescending(t => t.CreatedAt).ToListAsync();
        }

        public async Task<Core.Entities.Task> UpdateTask(Core.Entities.Task task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();

            return await GetTask(task.Id);
        }
    }
}