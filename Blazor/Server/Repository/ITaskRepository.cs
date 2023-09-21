namespace Blazor.Server.Repository;

public interface ITaskRepository
{
    Task<List<Shared.Task>> GetAllTaskAsync();
    Task<Shared.Task> GetTaskByIdAsync(int id);
}