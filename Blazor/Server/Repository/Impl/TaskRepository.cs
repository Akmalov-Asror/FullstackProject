using Blazor.Server.Data;
using Microsoft.EntityFrameworkCore;
using Task = Blazor.Shared.Task;

namespace Blazor.Server.Repository.Impl;

public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext context) => _context = context;

    public async Task<List<Shared.Task>> GetAllTaskAsync() => await _context.Task.ToListAsync();
    public async Task<Shared.Task> GetTaskByIdAsync(int id) => await _context.Task.FirstOrDefaultAsync(t => t.Id == id);
}