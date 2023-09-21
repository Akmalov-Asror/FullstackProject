using Blazor.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Server.Repository.Impl
{
    public class TaskRepository:ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context) => _context = context;

        public async Task<List<Shared.Task>> GetAllTaskAsync()
        {
            return await _context.Task.ToListAsync();
        }

        public async Task<Shared.Task> GetTaskByIdAsync(int id)
        {
            return await _context.Task.FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
